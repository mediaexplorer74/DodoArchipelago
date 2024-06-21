// Type: DodoTheGame.Recorder

using DodoTheGame.Localization;
using DodoTheGame.Saving;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
//using System.Web.Script.Serialization;


namespace DodoTheGame
{
  internal static class Recorder
  {
    private static double lastDrawTime;
    public static double currentDrawTime;
    private static List<string[]> currentFrameCalls;
    public static List<List<string[]>> framesBuffer;
    private static StreamWriter currentWriter;
    public static string exportFolder;
    internal static string sessionStartcode;
    private const int recordFrameRatio = 2;
    private static int currentRatioCount = 1;
    public static bool recording;
    public static bool useHighContrast = false;
    public static bool rerendering = false;
    private static string[] fileList;
    private static int currentFileIndex;
    private static int currentFrameIndexInCurrentFile;
    public static List<Texture2D> resources;
    public static Texture2D ghost;
    public static SpriteFont debugFont;
    public static int drawCallCount = 0;
    private static int savedFramesCount = 0;
    private static string currentSavingFile;
    private static string csfCacheClone;
    private static JavaScriptSerializer jss = new JavaScriptSerializer()
    {
      MaxJsonLength = 2147483640
    };
    public static Color rERcolorFilter;
    public static TimeSpan rERTime;
    public static ItemStack[] rERinventory;
    private static int currentRerenderSpeed = 2;
    private static double timeSinceLastKeyboardRead;
    private static KeyboardState lastks;
    private static int playbackFrameRatio = 2;

    public static Player Player { private get; set; }

    public static void Terminate()
    {
      if (Recorder.currentWriter == null)
        return;
      Recorder.currentWriter.Flush();
      Recorder.currentWriter.Dispose();//.Close();
    }

    public static void StartRecording()
    {
      if (Recorder.recording)
        return;
      Recorder.jss.RegisterConverters((IEnumerable<JavaScriptConverter>) new ItemStackConverter[1]
      {
        new ItemStackConverter()
      });
      Recorder.currentFrameCalls = new List<string[]>();
      Recorder.framesBuffer = new List<List<string[]>>();
      if (!Directory.Exists(Recorder.exportFolder))
        Directory.CreateDirectory(Recorder.exportFolder);
      Recorder.recording = true;
      Recorder.currentSavingFile = Recorder.sessionStartcode 
                + "-" + Math.Round(Recorder.currentDrawTime)
                .ToString((IFormatProvider) CultureInfo.InvariantCulture);
      Recorder.currentWriter = File.AppendText(
          Recorder.exportFolder + Recorder.currentSavingFile + ".drc2");
    }

    public static void RDraw(
      SpriteBatch spriteBatch,
      Texture2D texture,
      Vector2 location,
      Color color)
    {
      if (Recorder.rerendering)
        return;
      if (Recorder.recording)
        Recorder.FrameRoutine();
      Vector2 vector2 = new Vector2(location.X + (float) texture.Width, 
          location.Y + (float) texture.Height);
      if (!new Rectangle(Convert.ToInt32(location.X), 
          Convert.ToInt32(location.Y), texture.Width, texture.Height)
                .Intersects(new Rectangle(0, 0, 1280, 720)))
        return;
      ++Recorder.drawCallCount;
      spriteBatch.Draw(texture, location, color);
      if (!Recorder.recording)
        return;
      List<string[]> currentFrameCalls = Recorder.currentFrameCalls;
      string[] strArray = new string[8]
      {
        "a",
        texture.Name,
        location.X.ToString((IFormatProvider) CultureInfo.InvariantCulture),
        location.Y.ToString((IFormatProvider) CultureInfo.InvariantCulture),
        null,
        null,
        null,
        null
      };
      byte num = color.R;
      strArray[4] = num.ToString();
      num = color.G;
      strArray[5] = num.ToString();
      num = color.B;
      strArray[6] = num.ToString();
      num = color.A;
      strArray[7] = num.ToString();
      currentFrameCalls.Add(strArray);
    }

    public static void RDraw(
      SpriteBatch spriteBatch,
      Texture2D texture,
      Vector2 location,
      Color color,
      float Size)
    {
      spriteBatch.Draw(texture, location 
          - new Vector2((float) ((double) Size
          * (double) texture.Width / 2.0), (float) ((double) Size * (double) texture.Height / 2.0)), 
          new Rectangle?(), Color.White, 0.0f, new Vector2(0.0f, 0.0f), Size, SpriteEffects.None, 0.0f);
    }

    [Obsolete("This draw call doesn't save to recorder and should be avoided when possible.")]
    public static void RDraw(
      SpriteBatch spriteBatch,
      Texture2D texture,
      Rectangle rectangle,
      Color color)
    {
      if (Recorder.rerendering)
        return;
      if (Recorder.recording)
        Recorder.FrameRoutine();
      ++Recorder.drawCallCount;
      spriteBatch.Draw(texture, rectangle, color);
    }

    public static void RDraw(
      SpriteBatch spriteBatch,
      Texture2D texture,
      Rectangle destinationRectangle,
      Rectangle? sourceRectangle,
      Color color,
      float rotation,
      Vector2 origin,
      SpriteEffects effects,
      float layerDepth)
    {
      if (Recorder.rerendering)
        return;
      if (Recorder.recording)
        Recorder.FrameRoutine();
      int int32 = Convert.ToInt32(Math.Ceiling(Math.Sqrt(Math.Pow((double) texture.Width, 2.0)
          + Math.Pow((double) texture.Height, 2.0))));
      if (!new Rectangle(Convert.ToInt32(destinationRectangle.X - int32), 
          Convert.ToInt32(destinationRectangle.Y - int32), int32 * 2, int32 * 2).Intersects(new Rectangle(0, 0, 1280, 720)))
        return;

      spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color,
          rotation, origin, effects, layerDepth);

      ++Recorder.drawCallCount;
      if (!Recorder.recording)
        return;
      if (sourceRectangle.HasValue)
      {
        Rectangle rectangle = sourceRectangle.Value;
        Recorder.currentFrameCalls.Add(new string[18]
        {
          "c",
          texture.Name,
          destinationRectangle.X.ToString(),
          destinationRectangle.Y.ToString(),
          destinationRectangle.Width.ToString(),
          destinationRectangle.Height.ToString(),
          rectangle.X.ToString(),
          rectangle.Y.ToString(),
          rectangle.Width.ToString(),
          rectangle.Height.ToString(),
          rotation.ToString((IFormatProvider) CultureInfo.InvariantCulture),
          origin.X.ToString((IFormatProvider) CultureInfo.InvariantCulture),
          origin.Y.ToString((IFormatProvider) CultureInfo.InvariantCulture),
          Convert.ToString((int) effects),
          color.R.ToString(),
          color.G.ToString(),
          color.B.ToString(),
          color.A.ToString()
        });
      }
      else
        Recorder.currentFrameCalls.Add(new string[14]
        {
          "d",
          texture.Name,
          destinationRectangle.X.ToString(),
          destinationRectangle.Y.ToString(),
          destinationRectangle.Width.ToString(),
          destinationRectangle.Height.ToString(),
          rotation.ToString((IFormatProvider) CultureInfo.InvariantCulture),
          origin.X.ToString((IFormatProvider) CultureInfo.InvariantCulture),
          origin.Y.ToString((IFormatProvider) CultureInfo.InvariantCulture),
          Convert.ToString((int) effects),
          color.R.ToString(),
          color.G.ToString(),
          color.B.ToString(),
          color.A.ToString()
        });
    }

    public static void RDraw(
      SpriteBatch spriteBatch,
      Texture2D texture,
      Vector2 position,
      Rectangle? sourceRectangle,
      Color color,
      float rotation,
      Vector2 origin,
      Vector2 scale,
      SpriteEffects effects,
      float layerDepth)
    {
      if (Recorder.rerendering)
        return;
      if (Recorder.recording)
        Recorder.FrameRoutine();

      int int32 = Convert.ToInt32(Math.Ceiling(Math.Sqrt(Math.Pow((double) texture.Width, 2.0) 
          + Math.Pow((double) texture.Height, 2.0))));
      if (!new Rectangle(Convert.ToInt32(position.X - (float) int32),
          Convert.ToInt32(position.Y - (float) int32), int32 * 2, int32 * 2).Intersects(
          new Rectangle(0, 0, 1280, 720)))
        return;
      ++Recorder.drawCallCount;
      spriteBatch.Draw(texture, position, sourceRectangle, color, 
          rotation, origin, scale, effects, layerDepth);
      if (!Recorder.recording)
        return;
      if (sourceRectangle.HasValue)
      {
        List<string[]> currentFrameCalls = Recorder.currentFrameCalls;
        string[] strArray = new string[16];
        strArray[0] = "e";
        strArray[1] = texture.Name;
        strArray[2] = position.X.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        strArray[3] = position.Y.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        strArray[4] = sourceRectangle.Value.X.ToString();
        Rectangle rectangle = sourceRectangle.Value;
        strArray[5] = rectangle.Y.ToString();
        rectangle = sourceRectangle.Value;
        strArray[6] = rectangle.Width.ToString();
        rectangle = sourceRectangle.Value;
        strArray[7] = rectangle.Height.ToString();
        strArray[8] = color.R.ToString();
        byte num = color.G;
        strArray[9] = num.ToString();
        num = color.B;
        strArray[10] = num.ToString();
        num = color.A;
        strArray[11] = num.ToString();
        strArray[12] = rotation.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        strArray[13] = origin.X.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        strArray[14] = origin.Y.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        strArray[15] = Convert.ToString((int) effects);
        currentFrameCalls.Add(strArray);
      }
      else
        Recorder.currentFrameCalls.Add(new string[16]
        {
          "f",
          texture.Name,
          position.X.ToString((IFormatProvider) CultureInfo.InvariantCulture),
          position.Y.ToString((IFormatProvider) CultureInfo.InvariantCulture),
          null,
          null,
          null,
          null,
          color.R.ToString(),
          color.G.ToString(),
          color.B.ToString(),
          color.A.ToString(),
          rotation.ToString((IFormatProvider) CultureInfo.InvariantCulture),
          origin.X.ToString((IFormatProvider) CultureInfo.InvariantCulture),
          origin.Y.ToString((IFormatProvider) CultureInfo.InvariantCulture),
          Convert.ToString((int) effects)
        });
    }

    public static void RDrawString(
      SpriteBatch spriteBatch,
      SpriteFont spriteFont,
      string text,
      Vector2 location,
      Color color)
    {
      if (Recorder.rerendering)
        return;
      if (Recorder.recording)
        Recorder.FrameRoutine();
      if (Recorder.useHighContrast && color.A > (byte) 30)
      {
        Color color1 = (double) color.R * 0.299 + (double) color.G * 0.587 
                    + (double) color.B * 0.114 <= 186.0 ? Color.White * 0.9f : Color.Black * 0.9f;
        Vector2 vector2 = spriteFont.MeasureString(text);
        spriteBatch.Draw(Recorder.GenerateBox(new Vector2(vector2.X + 4f, vector2.Y + 2f), 
            Color.White), new Vector2(location.X - 2f, location.Y - 1f), color1);
      }
      ++Recorder.drawCallCount;
      spriteBatch.DrawString(spriteFont, text, location, color);
    }

    private static void FrameRoutine()
    {
      if (Recorder.currentDrawTime == Recorder.lastDrawTime)
        return;
      ++Recorder.currentRatioCount;
      if (Recorder.currentRatioCount > 2)
        Recorder.currentRatioCount = 1;
      Recorder.lastDrawTime = Recorder.currentDrawTime;
      if (Recorder.currentFrameCalls == null)
        Recorder.currentFrameCalls = new List<string[]>();
      Recorder.currentWriter.WriteLine(Recorder.jss.Serialize((object) Recorder.currentFrameCalls));
      ++Recorder.savedFramesCount;
      List<string[]> strArrayList1 = new List<string[]>();
      List<string[]> strArrayList2 = strArrayList1;
      string[] strArray = new string[8];
      strArray[0] = "i";
      Color colorFilter = DayCycle.ColorFilter;
      int num = Convert.ToInt32(colorFilter.R);
      strArray[1] = num.ToString();
      colorFilter = DayCycle.ColorFilter;
      num = Convert.ToInt32(colorFilter.G);
      strArray[2] = num.ToString();
      colorFilter = DayCycle.ColorFilter;
      num = Convert.ToInt32(colorFilter.B);
      strArray[3] = num.ToString();
      colorFilter = DayCycle.ColorFilter;
      num = Convert.ToInt32(colorFilter.A);
      strArray[4] = num.ToString();
      strArray[5] = Convert.ToString(Recorder.currentDrawTime, 
          (IFormatProvider) CultureInfo.InvariantCulture);
      strArray[6] = Recorder.jss.Serialize((object) Recorder.Player.inventory?.inventory);
      num = Game1.frameCounter.OutputFramesPerSecond;
      strArray[7] = num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      strArrayList2.Add(strArray);
      Recorder.currentFrameCalls = strArrayList1;
      if (Recorder.savedFramesCount <= 3000)
        return;
      Recorder.savedFramesCount = 0;
      Recorder.currentWriter.Flush();
      //Recorder.currentWriter.Close();
      Recorder.currentWriter.Dispose();
      
      //RnD
      Recorder.csfCacheClone = (string)Recorder.currentSavingFile;//.Clone();
      Task.Run((Action) (() =>
      {
        //RnD
        string str = (string)Recorder.csfCacheClone;//.Clone();
        //Thread.Sleep(1000);
        using (ZipArchive destination = ZipFile.Open(Recorder.exportFolder + str + ".drc2zip", 
            ZipArchiveMode.Create))
          destination.CreateEntryFromFile(Recorder.exportFolder + str + ".drc2", str + ".drc2");
        File.Delete(Recorder.exportFolder + str + ".drc2");
      }));
      Recorder.currentSavingFile = Recorder.sessionStartcode + "-" 
                + Math.Round(Recorder.currentDrawTime).ToString((IFormatProvider)
                CultureInfo.InvariantCulture);
      Recorder.currentWriter = File.AppendText(Recorder.exportFolder 
          + Recorder.currentSavingFile + ".drc2");
    }

    public static void StartReRender(string folder, Game1 game)
    {
      Recorder.jss.RegisterConverters((IEnumerable<JavaScriptConverter>) new ItemStackConverter[1]
      {
        new ItemStackConverter()
      });
      game.IsFixedTimeStep = true;
      Recorder.framesBuffer = new List<List<string[]>>();
      Recorder.rerendering = true;
      Recorder.fileList = Directory.GetFiles(folder);
      Recorder.fileList = ((IEnumerable<string>) Recorder.fileList).OrderBy<string, string>(
          new Func<string, string>(Recorder.PadNumbers)).ToArray<string>();
      Recorder.currentFileIndex = 0;
      Recorder.LoadRerenderFile(Recorder.fileList[Recorder.currentFileIndex]);
    }

    private static string PadNumbers(string input)
    {
      return Regex.Replace(input, "[0-9]+", (MatchEvaluator) (match => match.Value.PadLeft(11, '0')));
    }

    public static void Update(GameTime gameTime, Game1 game, SpriteBatch spriteBatch)
    {
      if (!Recorder.rerendering)
        return;
      KeyboardState state = Keyboard.GetState();
      if (state.IsKeyDown(Keys.Right) && !Recorder.lastks.IsKeyDown(Keys.Right))
      {
        if (state.IsKeyDown(Keys.LeftControl) || state.IsKeyDown(Keys.RightControl))
        {
          Recorder.framesBuffer.Clear();
          ++Recorder.currentFileIndex;
          if (Recorder.currentFileIndex == Recorder.fileList.Length)
          {
            Console.WriteLine("Rerender ended.");
            CoreApplication.Exit();
          }
          Recorder.LoadRerenderFile(Recorder.fileList[Recorder.currentFileIndex]);
          Recorder.currentFrameIndexInCurrentFile = 1;
        }
        else
          ++Recorder.currentRerenderSpeed;
      }
      else if (state.IsKeyDown(Keys.Left) && !Recorder.lastks.IsKeyDown(Keys.Left))
      {
        if (state.IsKeyDown(Keys.LeftControl) || state.IsKeyDown(Keys.RightControl))
        {
          if (Recorder.currentFileIndex == 0)
          {
            Recorder.framesBuffer.Clear();
            Recorder.LoadRerenderFile(Recorder.fileList[Recorder.currentFileIndex]);
            Recorder.currentRerenderSpeed = 0;
            Recorder.currentFrameIndexInCurrentFile = 1;
          }
          else
          {
            Recorder.framesBuffer.Clear();
            --Recorder.currentFileIndex;
            Recorder.LoadRerenderFile(Recorder.fileList[Recorder.currentFileIndex]);
            Recorder.currentFrameIndexInCurrentFile = 1;
          }
        }
        else
          --Recorder.currentRerenderSpeed;
      }
      else if (state.IsKeyDown(Keys.Down) && !Recorder.lastks.IsKeyDown(Keys.Down))
        Recorder.currentRerenderSpeed = 2;
      Recorder.lastks = state;
      if (Recorder.currentRerenderSpeed > 5)
        Recorder.currentRerenderSpeed = 5;
      if (Recorder.currentRerenderSpeed < -4)
        Recorder.currentRerenderSpeed = -4;
      Recorder.playbackFrameRatio = Recorder.currentRerenderSpeed == 1 ? 6 : 2;
      ++Recorder.currentRatioCount;
      if (Recorder.currentRatioCount >= Recorder.playbackFrameRatio)
        Recorder.currentRatioCount = 1;
      if (Recorder.currentRatioCount == 1)
      {
        switch (Recorder.currentRerenderSpeed)
        {
          case -4:
            Recorder.currentFrameIndexInCurrentFile -= 7;
            break;
          case -3:
            Recorder.currentFrameIndexInCurrentFile -= 3;
            break;
          case -2:
            Recorder.currentFrameIndexInCurrentFile -= 2;
            break;
          case -1:
            --Recorder.currentFrameIndexInCurrentFile;
            break;
          case 1:
          case 2:
            ++Recorder.currentFrameIndexInCurrentFile;
            break;
          case 3:
            Recorder.currentFrameIndexInCurrentFile += 2;
            break;
          case 4:
            Recorder.currentFrameIndexInCurrentFile += 3;
            break;
          case 5:
            Recorder.currentFrameIndexInCurrentFile += 7;
            break;
        }
      }
      if (Recorder.currentFrameIndexInCurrentFile >= Recorder.framesBuffer.Count)
      {
        Recorder.framesBuffer.Clear();
        ++Recorder.currentFileIndex;
        if (Recorder.currentFileIndex == Recorder.fileList.Length)
        {
          Console.WriteLine("Rerender ended.");
          //Environment.Exit(0);
        }
        Recorder.LoadRerenderFile(Recorder.fileList[Recorder.currentFileIndex]);
        Recorder.currentFrameIndexInCurrentFile = 1;
      }
      else if (Recorder.currentFrameIndexInCurrentFile < 0)
      {
        if (Recorder.currentFileIndex == 0)
        {
          Recorder.framesBuffer.Clear();
          Recorder.LoadRerenderFile(Recorder.fileList[Recorder.currentFileIndex]);
          Recorder.currentRerenderSpeed = 0;
          Recorder.currentFrameIndexInCurrentFile = 1;
        }
        else
        {
          Recorder.framesBuffer.Clear();
          --Recorder.currentFileIndex;
          Recorder.LoadRerenderFile(Recorder.fileList[Recorder.currentFileIndex]);
          Recorder.currentFrameIndexInCurrentFile = Recorder.framesBuffer.Count - 1;
        }
      }
      try
      {
        foreach (string[] strArray in Recorder.framesBuffer[Recorder.currentFrameIndexInCurrentFile])
        {
          string[] elem = strArray;
          if (elem[0] == "i")
          {
            Recorder.rERcolorFilter = new Color(Convert.ToInt32(elem[1]), 
                Convert.ToInt32(elem[2]), Convert.ToInt32(elem[3]), Convert.ToInt32(elem[4]));
            Recorder.rERTime = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(
                Math.Round(Convert.ToDouble(elem[5], (IFormatProvider) CultureInfo.InvariantCulture))));
            Recorder.rERinventory = Recorder.jss.Deserialize<ItemStack[]>(elem[6]);
          }
          else
          {
            Texture2D texture1 = Recorder.resources.FirstOrDefault<Texture2D>(
                (Func<Texture2D, bool>) (texture => texture.Name == elem[1]));
            if (texture1 != null)
            {
              switch (elem[0])
              {
                case "a":
                  spriteBatch.Draw(texture1, new Vector2(Convert.ToSingle(elem[2],
                      (IFormatProvider) CultureInfo.InvariantCulture), Convert.ToSingle(elem[3], 
                      (IFormatProvider) CultureInfo.InvariantCulture)), 
                      new Color(Convert.ToInt32(elem[4]), Convert.ToInt32(elem[5]), 
                      Convert.ToInt32(elem[6]), Convert.ToInt32(elem[7])));
                  continue;
                case "c":
                  spriteBatch.Draw(texture1, new Rectangle(Convert.ToInt32(elem[2]), 
                      Convert.ToInt32(elem[3]), Convert.ToInt32(elem[4]), 
                      Convert.ToInt32(elem[5])), new Rectangle?(
                          new Rectangle(Convert.ToInt32(elem[6]), Convert.ToInt32(elem[7]),
                          Convert.ToInt32(elem[8]), Convert.ToInt32(elem[9]))), 
                          new Color(Convert.ToInt32(elem[14]), Convert.ToInt32(elem[15]), 
                          Convert.ToInt32(elem[16])), Convert.ToSingle(elem[10], 
                          (IFormatProvider) CultureInfo.InvariantCulture), 
                          new Vector2((float) Convert.ToInt32(elem[11]),
                          (float) Convert.ToInt32(elem[12])), 
                          (SpriteEffects) Convert.ToInt32(elem[13]), 0.0f);
                  continue;
                case "d":
                  spriteBatch.Draw(texture1, new Rectangle(Convert.ToInt32(elem[2]), 
                      Convert.ToInt32(elem[3]), Convert.ToInt32(elem[4]), 
                      Convert.ToInt32(elem[5])), new Rectangle?(),
                      new Color(Convert.ToInt32(elem[10]), 
                      Convert.ToInt32(elem[11]), Convert.ToInt32(elem[12]), 
                      Convert.ToInt32(elem[13])), Convert.ToSingle(elem[5],
                      (IFormatProvider) CultureInfo.InvariantCulture), 
                      new Vector2((float) Convert.ToInt32(elem[6]), (float) Convert.ToInt32(elem[7])), 
                      (SpriteEffects) Convert.ToInt32(elem[8]), 0.0f);
                  continue;
                case "e":
                  spriteBatch.Draw(texture1, new Vector2((float) Convert.ToInt32(elem[2]),
                      (float) Convert.ToInt32(elem[3])), new Rectangle?(
                          new Rectangle(Convert.ToInt32(elem[4]), Convert.ToInt32(elem[5]), 
                          Convert.ToInt32(elem[6]), Convert.ToInt32(elem[7]))), 
                          new Color(Convert.ToInt32(elem[8]), Convert.ToInt32(elem[9]),
                          Convert.ToInt32(elem[10]), Convert.ToInt32(elem[11])), 
                          Convert.ToSingle(elem[12], (IFormatProvider) CultureInfo.InvariantCulture), 
                          new Vector2((float) Convert.ToInt32(elem[12]), (float) Convert.ToInt32(elem[13])), 1f, (SpriteEffects) Convert.ToInt32(elem[15]), 0.0f);
                  continue;
                case "f":
                  spriteBatch.Draw(texture1, new Vector2(Convert.ToSingle(elem[2],
                      (IFormatProvider) CultureInfo.InvariantCulture), Convert.ToSingle(elem[3],
                      (IFormatProvider) CultureInfo.InvariantCulture)), new Rectangle?(),
                      new Color(Convert.ToInt32(elem[8]), Convert.ToInt32(elem[9]), 
                      Convert.ToInt32(elem[10]), Convert.ToInt32(elem[11])), Convert.ToSingle(elem[12], (IFormatProvider) CultureInfo.InvariantCulture), new Vector2((float) Convert.ToInt32(elem[13]), (float) Convert.ToInt32(elem[14])), 1f, (SpriteEffects) Convert.ToInt32(elem[15]), 0.0f);
                  continue;
                default:
                  throw new Exception("Invalid drawcall stored in Recorder.framesBuffer");
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Recorder.RDrawString(spriteBatch, Recorder.debugFont, "Render error.", Vector2.Zero, Color.Red);
      }
      spriteBatch.Draw(Recorder.GenerateBox(new Vector2(200f, 35f), Color.Black), new Vector2(20f, 20f), Color.White * 0.7f);
      spriteBatch.DrawString(Recorder.debugFont, Path.GetFileName(Recorder.fileList[Recorder.currentFileIndex]), new Vector2(20f, 20f), Color.White);
      spriteBatch.DrawString(Recorder.debugFont, "Play time: " + Convert.ToString(Recorder.rERTime.Hours).PadLeft(2, '0') + ":" + Convert.ToString(Recorder.rERTime.Minutes).PadLeft(2, '0') + ":" + Convert.ToString(Recorder.rERTime.Seconds).PadLeft(2, '0'), new Vector2(20f, 34f), Color.White);
      spriteBatch.Draw(Recorder.GenerateBox(new Vector2(100f, 15f), Color.Black), new Vector2(0.0f, 705f), Color.White * 0.7f);
      string text = "";
      switch (Recorder.currentRerenderSpeed)
      {
        case -4:
          text = "x-7";
          break;
        case -3:
          text = "x-3";
          break;
        case -2:
          text = "x-2";
          break;
        case -1:
          text = "x-1";
          break;
        case 0:
          text = "paused";
          break;
        case 1:
          text = "x0.3";
          break;
        case 2:
          text = "x1";
          break;
        case 3:
          text = "x2";
          break;
        case 4:
          text = "x3";
          break;
        case 5:
          text = "x7";
          break;
      }
      spriteBatch.DrawString(Recorder.debugFont, text, new Vector2(0.0f, 691f), Color.White);
      spriteBatch.Draw(Recorder.ghost, new Vector2(580f, 310f), Color.White * 0.5f);
    }

    private static void LoadRerenderFile(string filename)
    {
      JavaScriptSerializer scriptSerializer = new JavaScriptSerializer()
      {
        MaxJsonLength = 2147483640
      };
      Recorder.framesBuffer = new List<List<string[]>>();
      foreach (string readLine in File.ReadLines(filename))
        Recorder.framesBuffer.Add(scriptSerializer.Deserialize<List<string[]>>(readLine));
      Recorder.currentFrameIndexInCurrentFile = 1;
    }

    private static Texture2D GenerateBox(Vector2 size, Color color)
    {
      Texture2D box = new Texture2D(Game1.graphics.GraphicsDevice, (int) size.X, (int) size.Y);
      Color[] data = new Color[(int) size.X * (int) size.Y];
      for (int index = 0; index < data.Length; ++index)
        data[index] = color;
      box.SetData<Color>(data);
      return box;
    }
  }
}
