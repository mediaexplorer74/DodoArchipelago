
// Type: DodoTheGame.DebugAssistant

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DodoTheGame.BackgroundEffects;
using DodoTheGame.Cutscene;
using DodoTheGame.GUI;
using DodoTheGame.Interactions;
using DodoTheGame.Localization;
using DodoTheGame.Saving;
using DodoTheGame.WorldObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
//using System.Web.Script.Serialization;


namespace DodoTheGame
{
  public static class DebugAssistant
  {
    internal static bool waveEditor = false;
    public static Texture2D debugWindArrow;
    private static int debugKeyCooldown = 0;
    private static MouseState previousMouseState;
    private static KeyboardState previousks;
    internal static bool debugPanel;
    internal static List<IWorldObject> woModifiedInGameEditor;

    public static readonly List<Microsoft.Xna.Framework.Input.Keys> DebugMenuKeys
        = new List<Microsoft.Xna.Framework.Input.Keys>()
    {
        Microsoft.Xna.Framework.Input.Keys.A,
        Microsoft.Xna.Framework.Input.Keys.Z,
        Microsoft.Xna.Framework.Input.Keys.E,
        Microsoft.Xna.Framework.Input.Keys.R,
        Microsoft.Xna.Framework.Input.Keys.T,
        Microsoft.Xna.Framework.Input.Keys.Q,
        Microsoft.Xna.Framework.Input.Keys.S,
        Microsoft.Xna.Framework.Input.Keys.D
    };

    public static Microsoft.Xna.Framework.Input.Keys? debugPanelActiveMenu
        = new Microsoft.Xna.Framework.Input.Keys?();


    // ExportStaticWorld
    private static void ExportStaticWorld(Game1 game)
    {
      StorageFolder localFolder = ApplicationData.Current.LocalFolder;
      JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
      scriptSerializer.RegisterConverters((IEnumerable<JavaScriptConverter>) 
          new List<JavaScriptConverter>()
      {
        (JavaScriptConverter) new ItemStackConverter(),
        (JavaScriptConverter) new Texture2DConverter(),
        (JavaScriptConverter) new Vector2Converter(),
        (JavaScriptConverter) new IDodoInteractionConverter()
      });

      int totalSeconds = (int) DateTime.UtcNow.Subtract(
          new DateTime(1970, 1, 1)).TotalSeconds;

      File.WriteAllText(localFolder.Path +"\\"+ 
          "gameedit-ser-" + totalSeconds.ToString() + ".txt", 
          scriptSerializer.Serialize((object) DebugAssistant.woModifiedInGameEditor));

      List<string> stringList = new List<string>();

      foreach (Preset preset in Game1.presetList)
        stringList.Add(preset.name);

      string str1 = "//// World definition START" + Environment.NewLine;
      foreach (string str2 in stringList)
      {
        List<IWorldObject> worldObjectList = new List<IWorldObject>();
        foreach (IWorldObject worldObject in Game1.world.objects)
        {
          if (!(worldObject is BuildPoint) && worldObject.PresetMarker == str2)
            worldObjectList.Add(worldObject);
        }
        string str3 = "// " + str2 + Environment.NewLine
                    + "world.objects.AddRange(presetList.First(p => p.name == \""
                    + str2 + "\").MakeWOs(new List<Tuple<Vector2, string>>(){"
                    + Environment.NewLine;
        bool flag = true;
        int num = 0;
        foreach (IWorldObject worldObject in worldObjectList)
        {
          if (!flag)
            str3 += Environment.NewLine;
          str3 = str3 + "new Tuple<Vector2, string>(new Vector2(" 
                        + worldObject.Location.X.ToString() + ", "
                        + worldObject.Location.Y.ToString() + "), \""
                        + str2 + "-" + num.ToString() + "\"),";
          flag = false;
          ++num;
        }
        string str4 = str3.Remove(str3.Length - 1) + Environment.NewLine + "}));" 
                    + Environment.NewLine + Environment.NewLine;
        str1 += str4;
      }

      string str5 = str1 + Environment.NewLine + 
                "Game1.Log(\"Generating buildpoints...\", BreadcrumbLevel.Debug, \"worldgen\");" 
                + Environment.NewLine;

      int num1 = 1;

      foreach (IWorldObject worldObject 
          in Game1.world.objects.Where<IWorldObject>((Func<IWorldObject, bool>) (p => p is BuildPoint)))
      {
        string str6 = "";
        Build interaction = (Build) worldObject.Interactions[3];

        foreach (ItemStack itemStack in interaction.intake)
        {
          if (str6 != "")
            str6 += ", ";
          str6 = str6 + "new ItemStack(" + itemStack.itemId.ToString() + ", "
                        + itemStack.count.ToString() + ")";
        }
        string str7 = "";

        foreach (string tag in worldObject.Tags)
        {
          if (str7 != "")
            str7 += ", ";
          str7 = str7 + " \"" + tag + "\"";
        }
        string str8 = "";

        foreach (string bpIncompatibleTag in ((BuildPoint) worldObject).bpIncompatibleTags)
        {
          if (str8 != "")
            str8 += ", ";
          str8 = str8 + " \"" + bpIncompatibleTag + "\"";
        }
        string[] strArray = new string[34];
        strArray[0] = str5;
        strArray[1] = "BuildPoint bp";
        strArray[2] = num1.ToString();
        strArray[3] = " = new BuildPoint(\"bp";
        strArray[4] = num1.ToString();
        strArray[5] = "\", Game1.buildPointSprite, new Vector2(";
        strArray[6] = worldObject.Location.X.ToString();
        strArray[7] = ", ";
        strArray[8] = worldObject.Location.Y.ToString();
        strArray[9] = "), null, new Vector2(";
        Vector2 location = worldObject.Location;
        strArray[10] = location.X.ToString();
        strArray[11] = " + 20, ";
        location = worldObject.Location;
        strArray[12] = location.Y.ToString();
        strArray[13] = " + 65))";
        strArray[14] = Environment.NewLine;
        strArray[15] =
                    "{ExtraReach = new Vector2{ Y = -8 }, ExtraFloorHeight = 20, Interactions = { [(int)Cardinal.Up] = new Build(new List<ItemStack> { ";
        strArray[16] = str6;
        strArray[17] = " }, presetList.First(p => p.name == \"";
        strArray[18] = interaction.buildPreset.name;
        strArray[19] = "\"))";
        strArray[20] = Environment.NewLine;
        strArray[21] = "}, Tags = new string[] { ";
        strArray[22] = str7;
        strArray[23] = " }, requiredLevel = ";
        strArray[24] = ((BuildPoint) worldObject).requiredLevel.ToString();
        strArray[25] = ", bpIncompatibleTags = new string[]{ ";
        strArray[26] = str8;
        strArray[27] = " }}; ";
        strArray[28] = Environment.NewLine;
        strArray[29] = " world.objects.Add(bp";
        strArray[30] = num1.ToString();
        strArray[31] = ");";
        strArray[32] = Environment.NewLine;
        strArray[33] = Environment.NewLine;
        str5 = string.Concat(strArray);
        ++num1;
      }
      string contents = str5 + Environment.NewLine + "//// World definition END";

      File.WriteAllText(localFolder.Path + "\\"+
          "gameedit-" + totalSeconds.ToString() + ".txt", contents);

    }//ExportStaticWorld

    
    // KeyInput
    public static void KeyInput(KeyboardState ks, Game1 game, GameTime gameTime)
    {
      StorageFolder localFolder = ApplicationData.Current.LocalFolder;

      if (DebugAssistant.debugKeyCooldown > 0)
        --DebugAssistant.debugKeyCooldown;

      if (DebugAssistant.debugKeyCooldown < 0)
        DebugAssistant.debugKeyCooldown = 0;

      //***************************************************************

      /*if ( ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F5) && DebugAssistant.debugPanelActiveMenu.HasValue )
      {
            // F4 handling
            System.Diagnostics.Debug.WriteLine("[i] F5 pressed. Test Inventory AddItem !");

            for (int itemId = 0; itemId < 17; ++itemId)
                Game1.player.inventory.AddItem(new ItemStack(itemId, 99));
      }*/
      //***************************************************************

        //if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftAlt)
        //          || ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightAlt))
        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F4))
        {

          if (1==1)//(DebugAssistant.debugPanelActiveMenu.HasValue)
          {
          // F4 handling
           System.Diagnostics.Debug.WriteLine("[i] F4 pressed");

           Microsoft.Xna.Framework.Input.Keys? debugPanelActiveMenu1
                        = DebugAssistant.debugPanelActiveMenu;

            Microsoft.Xna.Framework.Input.Keys keys1 =
                            Microsoft.Xna.Framework.Input.Keys.H;//.A;
           if (debugPanelActiveMenu1.GetValueOrDefault() == 
                        keys1 & debugPanelActiveMenu1.HasValue)
           {
             System.Diagnostics.Debug.WriteLine("[i] F4 + H pressed. DayCycleTime += 7");

             DayCycle.dayTime += 7.0;
                        /*
            if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.E))
            DayCycle.dayTime += 4.5;
            else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.R))
              DayCycle.dayTime += 7.0;
            else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) 
                && !DebugAssistant.previousks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A))
              Wind.MainAngle = Wind.windDirections[Wind.windDirections.IndexOf(Wind.MainAngle) - 1 < 0
                  ? Wind.windDirections.Count - 1 : Wind.windDirections.IndexOf(Wind.MainAngle) - 1];
            else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z)
                  && !DebugAssistant.previousks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z))
              Wind.MainAngle = 
                Wind.windDirections[Wind.windDirections.IndexOf(Wind.MainAngle) + 1 
                    >= Wind.windDirections.Count ? 0 : Wind.windDirections.IndexOf(Wind.MainAngle) + 1];
                        */
          }
          else
          {
            Microsoft.Xna.Framework.Input.Keys? debugPanelActiveMenu2 
                            = DebugAssistant.debugPanelActiveMenu;
            Microsoft.Xna.Framework.Input.Keys keys2 = Microsoft.Xna.Framework.Input.Keys.Z;

            if (debugPanelActiveMenu2.GetValueOrDefault() == keys2
                            & debugPanelActiveMenu2.HasValue)
            {
              if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) 
                                && !DebugAssistant.previousks.IsKeyDown(
                                    Microsoft.Xna.Framework.Input.Keys.A))
                SaveHandler.SaveGame(Game1.world, Game1.player, game.lastFrame);
              else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z) 
                                && !DebugAssistant.previousks.IsKeyDown(
                                    Microsoft.Xna.Framework.Input.Keys.Z))
                SaveHandler.LoadGame(SaveHandler.slot, Game1.commonSprites, game);
              else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.E) 
                                && !DebugAssistant.previousks.IsKeyDown(
                                    Microsoft.Xna.Framework.Input.Keys.E))
                SaveHandler.LoadDefault(Game1.commonSprites, game);
              else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Q) 
                                && !DebugAssistant.previousks.IsKeyDown(
                                    Microsoft.Xna.Framework.Input.Keys.Q))
                SaveHandler.LoadGame(1, Game1.commonSprites, game);
              else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S)
                                && !DebugAssistant.previousks.IsKeyDown(
                                    Microsoft.Xna.Framework.Input.Keys.S))
                SaveHandler.LoadGame(2, Game1.commonSprites, game);
              else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D) 
                                && !DebugAssistant.previousks.IsKeyDown(
                                    Microsoft.Xna.Framework.Input.Keys.D))
                SaveHandler.LoadGame(3, Game1.commonSprites, game);
              else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W) 
                                && !DebugAssistant.previousks.IsKeyDown(
                                    Microsoft.Xna.Framework.Input.Keys.W))
              {
                SaveHandler.slot = 1;
                SaveHandler.SaveGame(Game1.world, Game1.player, game.lastFrame);
              }
              else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.X) 
                                && !DebugAssistant.previousks.IsKeyDown(
                                    Microsoft.Xna.Framework.Input.Keys.X))
              {
                SaveHandler.slot = 2;
                SaveHandler.SaveGame(Game1.world, Game1.player, game.lastFrame);
              }
              else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.C) 
                                && !DebugAssistant.previousks.IsKeyDown(
                                    Microsoft.Xna.Framework.Input.Keys.C))
              {
                SaveHandler.slot = 3;
                SaveHandler.SaveGame(Game1.world, Game1.player, game.lastFrame);
              }
            }
            else
            {
              Microsoft.Xna.Framework.Input.Keys? debugPanelActiveMenu3 
                                = DebugAssistant.debugPanelActiveMenu;

              Microsoft.Xna.Framework.Input.Keys keys3 = Microsoft.Xna.Framework.Input.Keys.E;

              if (debugPanelActiveMenu3.GetValueOrDefault() == keys3 & debugPanelActiveMenu3.HasValue)
              {
                if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) 
                                    && !DebugAssistant.previousks.IsKeyDown(
                                        Microsoft.Xna.Framework.Input.Keys.A))
                  Game1.player.unlockedPlayerTools = 
                                        new Dictionary<PlayerUnlockables.PlayerUnlockable, bool>()
                  {
                    {
                      PlayerUnlockables.PlayerUnlockable.Bicycle,
                      true
                    },
                    {
                      PlayerUnlockables.PlayerUnlockable.Bike,
                      true
                    }
                  };
                else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z) 
                                    && !DebugAssistant.previousks.IsKeyDown(
                                        Microsoft.Xna.Framework.Input.Keys.Z))
                  Game1.player.unlockedPlayerTools = 
                                        new Dictionary<PlayerUnlockables.PlayerUnlockable, bool>()
                  {
                    {
                      PlayerUnlockables.PlayerUnlockable.Bicycle,
                      false
                    },
                    {
                      PlayerUnlockables.PlayerUnlockable.Bike,
                      false
                    }
                  };
              }
              else
              {
                Microsoft.Xna.Framework.Input.Keys? debugPanelActiveMenu4 
                                    = DebugAssistant.debugPanelActiveMenu;
                Microsoft.Xna.Framework.Input.Keys keys4 = Microsoft.Xna.Framework.Input.Keys.R;
                if (debugPanelActiveMenu4.GetValueOrDefault() == keys4 & debugPanelActiveMenu4.HasValue)
                {
                  if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) 
                       && !DebugAssistant.previousks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) 
                       && Game1.world.Level > 0)
                    --Game1.world.Level;
                  else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z) 
                          && !DebugAssistant.previousks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z) 
                          && Game1.world.Level < 3)
                    ++Game1.world.Level;
                  else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.E) 
                        && !DebugAssistant.previousks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.E))
                    DebugAssistant.ExportStaticWorld(game);
                }
                else
                {
                  Microsoft.Xna.Framework.Input.Keys? debugPanelActiveMenu5
                                        = DebugAssistant.debugPanelActiveMenu;
                  Microsoft.Xna.Framework.Input.Keys keys5 = Microsoft.Xna.Framework.Input.Keys.T;
                  if (debugPanelActiveMenu5.GetValueOrDefault() == keys5
                                        & debugPanelActiveMenu5.HasValue)
                  {
                    if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) 
                                            && !DebugAssistant.previousks.IsKeyDown(
                                                Microsoft.Xna.Framework.Input.Keys.A))
                      game.userInput.inputMethod = 1;
                    else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z)
                                            && !DebugAssistant.previousks.IsKeyDown(
                                                Microsoft.Xna.Framework.Input.Keys.Z))
                      game.userInput.inputMethod = 2;
                    else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.E)
                                            && !DebugAssistant.previousks.IsKeyDown(
                                                Microsoft.Xna.Framework.Input.Keys.E))
                      game.userInput.inputMethod = 3;
                    else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.R)
                                            && !DebugAssistant.previousks.IsKeyDown(
                                                Microsoft.Xna.Framework.Input.Keys.R))
                    {
                      ++game.userInput.deviceIncrement;
                      if (game.userInput.deviceIncrement > 20)
                        game.userInput.deviceIncrement = 0;
                    }
                  }
                  else
                  {
                    Microsoft.Xna.Framework.Input.Keys? debugPanelActiveMenu6 = DebugAssistant.debugPanelActiveMenu;
                    Microsoft.Xna.Framework.Input.Keys keys6 = Microsoft.Xna.Framework.Input.Keys.Q;
                    if (!(debugPanelActiveMenu6.GetValueOrDefault() == keys6 & debugPanelActiveMenu6.HasValue))
                    {
                      Microsoft.Xna.Framework.Input.Keys? debugPanelActiveMenu7 = DebugAssistant.debugPanelActiveMenu;
                      Microsoft.Xna.Framework.Input.Keys keys7 = Microsoft.Xna.Framework.Input.Keys.S;
                      if (debugPanelActiveMenu7.GetValueOrDefault() == keys7 & debugPanelActiveMenu7.HasValue)
                      {
                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) && !DebugAssistant.previousks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A))
                        {
                          for (int itemId = 0; itemId < 17; ++itemId)
                            Game1.player.inventory.AddItem(new ItemStack(itemId, 99));
                        }
                        else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z)
                            && !DebugAssistant.previousks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z))
                          Game1.player.inventory.inventory = new ItemStack[Game1.player.inventory.inventory.Length];
                      }
                      else
                      {
                        /*
                        Microsoft.Xna.Framework.Input.Keys? debugPanelActiveMenu8 = DebugAssistant.debugPanelActiveMenu;
                        Microsoft.Xna.Framework.Input.Keys keys8 = Microsoft.Xna.Framework.Input.Keys.D;
                        if (debugPanelActiveMenu8.GetValueOrDefault() == keys8 & debugPanelActiveMenu8.HasValue)
                        {
                          if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) && !DebugAssistant.previousks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A))
                            CutsceneManager.StartCutscene((ICutscene) new StoryIntroCutscene(), gameTime, Game1.player, Game1.world);
                          else if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z) && !DebugAssistant.previousks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z))
                            CutsceneManager.StartCutscene((ICutscene) new ArchipelagoArrivalCutscene(), gameTime, Game1.player, Game1.world);
                        }
                        */
                      }
                    }
                  }
                }
              }
            }
          }
        }
        else
        {
         
          foreach (Microsoft.Xna.Framework.Input.Keys debugMenuKey 
                                                in DebugAssistant.DebugMenuKeys)
          {
            System.Diagnostics.Debug.WriteLine("[i] Debug menu mode...");

            if (ks.IsKeyDown(debugMenuKey))
            {
              DebugAssistant.debugPanelActiveMenu = 
                                new Microsoft.Xna.Framework.Input.Keys?(debugMenuKey);
              if (debugMenuKey == Microsoft.Xna.Framework.Input.Keys.Q)
                DebugAssistant.waveEditor = !DebugAssistant.waveEditor;
            }
          }
        }
      }
      else
      {
        // F3 Handling

        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F3)
                    && DebugAssistant.debugKeyCooldown == 0)
        {
          DebugAssistant.debugPanel = !DebugAssistant.debugPanel;
          DebugAssistant.debugKeyCooldown = 60;
        }
        DebugAssistant.debugPanelActiveMenu = new Microsoft.Xna.Framework.Input.Keys?();


                if (DebugAssistant.debugPanel)
                {


                    // "mousing" :)
                    MouseState state = Mouse.GetState();
                    Rectangle rectangle =
                                  new Rectangle((int)Math.Round(((double)Game1.windowSize.X
                                  - (double)Game1.renderSizeUpscaled.X) / 2.0, 0),
                                  (int)Math.Round(((double)Game1.windowSize.Y - (double)Game1.renderSizeUpscaled.Y) / 2.0, 0),
                                  Convert.ToInt32(Game1.renderSizeUpscaled.X), Convert.ToInt32(Game1.renderSizeUpscaled.Y));
                    if (state.RightButton
                                  == Microsoft.Xna.Framework.Input.ButtonState.Pressed
                                  && DebugAssistant.previousMouseState.RightButton
                                  == Microsoft.Xna.Framework.Input.ButtonState.Released && game.IsActive
                                  && state.X >= rectangle.X && state.X
                                  < rectangle.Width + rectangle.X && state.Y >= rectangle.Y && state.Y < rectangle.Height + rectangle.Y)
                    {
                        Vector2 point = new Vector2(Convert.ToSingle(
                            Math.Round((double)Convert.ToSingle(state.X - rectangle.X) / (double)rectangle.Width * (double)Game1.renderSize.X)),
                            Convert.ToSingle(Math.Round((double)Convert.ToSingle(state.Y - rectangle.Y) / (double)rectangle.Height * (double)Game1.renderSize.Y)));
                        if (GUIManager.currentHUDs.OfType<EditorGUI>().Any<EditorGUI>()
                                        && (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift)
                                        || ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightShift)))
                            GUIManager.editorHUD.AddPoint(point, game);
                        else if (GUIManager.currentHUDs.OfType<EditorGUI>().Any<EditorGUI>()
                                        && !ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightAlt)
                                        && !ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftAlt))
                        {
                            GUIManager.Clear();
                        }
                        else
                        {
                            GUIManager.editorHUD.SetPoint(point, game);
                            GUIManager.ClearThenSet((IGUI)GUIManager.editorHUD);
                        }
                    }

                    DebugAssistant.previousMouseState = state;


                    if (GUIManager.currentHUDs.OfType<EditorGUI>().Any<EditorGUI>())
                    {
                        if (DebugAssistant.woModifiedInGameEditor == null)
                            DebugAssistant.woModifiedInGameEditor = new List<IWorldObject>();
                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Delete))
                        {
                            foreach (IWorldObject worldObject in GUIManager.editorHUD.woInTarget)
                                Game1.world.objects.Remove(worldObject);
                            GUIManager.editorHUD.woInTarget.Clear();
                        }
                        int num = 1;
                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl))
                            num = 6;


                        if (
                            (
                             ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl)
                             || ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightControl)
                            )
                            && ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D) && DebugAssistant.debugKeyCooldown == 0
                           )
                        {
                            DebugAssistant.debugKeyCooldown = 40;

                            System.Diagnostics.Debug.WriteLine("[i] CTRL + D activated !");

                            //Clipboard.SetText(SaveHandler.SerializeSingleGameData(GUIManager.editorHUD.woInTarget));
                            System.Diagnostics.Debug.WriteLine("[i] SaveHandler.SerializeSingleGameData="
                                + SaveHandler.SerializeSingleGameData(GUIManager.editorHUD.woInTarget).ToString());
                        }



                        //if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right) 
                        //      && !GUIManager.editorHUD.presetMenuOpen && DebugAssistant.debugKeyCooldown == 0)
                        if (
                            (
                                ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl)
                                || ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightControl)
                            )
                            && ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W) && DebugAssistant.debugKeyCooldown == 0
                            )
                        {
                            DebugAssistant.debugKeyCooldown = 40;

                            System.Diagnostics.Debug.WriteLine("[i] CTRL + W activated ! Some World experiments...");

                            foreach (IWorldObject worldObject in GUIManager.editorHUD.woInTarget)
                            {
                                IWorldObject wo = worldObject;
                                if (!(wo is BuildPoint))
                                {
                                    wo.Location = new Vector2(wo.Location.X + (float)num, wo.Location.Y);
                                    Vector2 explicitEpicenter1 = wo.ExplicitEpicenter;
                                    Vector2 explicitEpicenter2 = wo.ExplicitEpicenter;
                                    explicitEpicenter2.X += (float)num;
                                    wo.ExplicitEpicenter = explicitEpicenter2;

                                    if (DebugAssistant.woModifiedInGameEditor.All<IWorldObject>(
                                        (Func<IWorldObject, bool>)(p => p.ObjectId != wo.ObjectId)))
                                        DebugAssistant.woModifiedInGameEditor.Add(wo);
                                }
                            }
                        }

                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left)
                                        && !GUIManager.editorHUD.presetMenuOpen
                                        && DebugAssistant.debugKeyCooldown == 0)
                        {
                            foreach (IWorldObject worldObject in GUIManager.editorHUD.woInTarget)
                            {
                                IWorldObject wo = worldObject;
                                if (!(wo is BuildPoint))
                                {
                                    wo.Location = new Vector2(wo.Location.X - (float)num, wo.Location.Y);
                                    Vector2 explicitEpicenter3 = wo.ExplicitEpicenter;
                                    Vector2 explicitEpicenter4 = wo.ExplicitEpicenter;
                                    explicitEpicenter4.X -= (float)num;
                                    wo.ExplicitEpicenter = explicitEpicenter4;
                                    if (DebugAssistant.woModifiedInGameEditor.All<IWorldObject>(
                                        (Func<IWorldObject, bool>)(p => p.ObjectId != wo.ObjectId)))
                                        DebugAssistant.woModifiedInGameEditor.Add(wo);
                                }
                            }
                        }
                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up))
                        {
                            if (GUIManager.editorHUD.presetMenuOpen && DebugAssistant.debugKeyCooldown == 0)
                            {
                                DebugAssistant.debugKeyCooldown = 14;
                                --GUIManager.editorHUD.selectedPresetIndex;
                            }
                            else if (DebugAssistant.debugKeyCooldown == 0)
                            {
                                foreach (IWorldObject worldObject in GUIManager.editorHUD.woInTarget)
                                {
                                    IWorldObject wo = worldObject;
                                    if (!(wo is BuildPoint))
                                    {
                                        wo.Location = new Vector2(wo.Location.X, wo.Location.Y - (float)num);
                                        Vector2 explicitEpicenter5 = wo.ExplicitEpicenter;
                                        Vector2 explicitEpicenter6 = wo.ExplicitEpicenter;
                                        explicitEpicenter6.Y -= (float)num;
                                        wo.ExplicitEpicenter = explicitEpicenter6;
                                        if (DebugAssistant.woModifiedInGameEditor.All<IWorldObject>(
                                            (Func<IWorldObject, bool>)(p => p.ObjectId != wo.ObjectId)))
                                            DebugAssistant.woModifiedInGameEditor.Add(wo);
                                    }
                                }
                            }
                        }

                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down))
                        {
                            if (GUIManager.editorHUD.presetMenuOpen && DebugAssistant.debugKeyCooldown == 0)
                            {
                                DebugAssistant.debugKeyCooldown = 14;
                                ++GUIManager.editorHUD.selectedPresetIndex;
                            }
                            else if (DebugAssistant.debugKeyCooldown == 0)
                            {
                                foreach (IWorldObject worldObject in GUIManager.editorHUD.woInTarget)
                                {
                                    if (!(worldObject is BuildPoint))
                                    {
                                        worldObject.Location = new Vector2(worldObject.Location.X,
                                            worldObject.Location.Y + (float)num);
                                        Vector2 explicitEpicenter7 = worldObject.ExplicitEpicenter;
                                        Vector2 explicitEpicenter8 = worldObject.ExplicitEpicenter;
                                        explicitEpicenter8.Y += (float)num;
                                        worldObject.ExplicitEpicenter = explicitEpicenter8;
                                        if (!DebugAssistant.woModifiedInGameEditor.Contains(worldObject))
                                            DebugAssistant.woModifiedInGameEditor.Add(worldObject);
                                    }
                                }
                            }
                        }

                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Tab)
                                        && DebugAssistant.debugKeyCooldown == 0)
                        {
                            DebugAssistant.debugKeyCooldown = 30;
                            GUIManager.editorHUD.presetMenuOpen = !GUIManager.editorHUD.presetMenuOpen;
                        }

                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right)
                                        && DebugAssistant.debugKeyCooldown == 0
                                        && GUIManager.editorHUD.presetMenuOpen)
                        {
                            DebugAssistant.debugKeyCooldown = 15;
                            int index = GUIManager.editorHUD.categoryList.FindIndex(
                                (Predicate<string>)(p => p == GUIManager.editorHUD.selectedPresetCategory)) + 1;

                            if (index >= GUIManager.editorHUD.categoryList.Count)
                                index = GUIManager.editorHUD.categoryList.Count - 1;

                            GUIManager.editorHUD.selectedPresetCategory = GUIManager.editorHUD.categoryList[index];
                        }

                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left)
                                        && DebugAssistant.debugKeyCooldown == 0
                                        && GUIManager.editorHUD.presetMenuOpen)
                        {
                            DebugAssistant.debugKeyCooldown = 15;
                            int index = GUIManager.editorHUD.categoryList.FindIndex(
                                (Predicate<string>)(p => p == GUIManager.editorHUD.selectedPresetCategory)) - 1;
                            if (index < 0)
                                index = 0;
                            GUIManager.editorHUD.selectedPresetCategory = GUIManager.editorHUD.categoryList[index];
                        }
                    }

                    // Handling Wave editor 
                    #region WaveEditor
                    if (DebugAssistant.waveEditor)
                    {
                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad0))
                            ((Wave)Game1.waves[0]).startingPoint = Game1.player.location;
                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad8))
                        {
                            if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl))
                                ((Wave)Game1.waves[0]).startingPoint.Y -= 30f;
                            else
                                ((Wave)Game1.waves[0]).startingPoint.Y -= 3f;
                        }
                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad5))
                        {
                            if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl))
                                ((Wave)Game1.waves[0]).startingPoint.Y += 30f;
                            else
                                ((Wave)Game1.waves[0]).startingPoint.Y += 3f;
                        }
                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad4))
                        {
                            if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl))
                                ((Wave)Game1.waves[0]).startingPoint.X -= 30f;
                            else
                                ((Wave)Game1.waves[0]).startingPoint.X -= 3f;
                        }
                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad6))
                        {
                            if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl))
                                ((Wave)Game1.waves[0]).startingPoint.X += 30f;
                            else
                                ((Wave)Game1.waves[0]).startingPoint.X += 3f;
                        }
                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad7))
                        {
                            if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl))
                                ((Wave)Game1.waves[0]).waveAngle -= 0.05000000074505806;
                            else
                                ((Wave)Game1.waves[0]).waveAngle -= 0.0099999997764825821;
                        }
                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad9))
                        {
                            if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl))
                                ((Wave)Game1.waves[0]).waveAngle += 0.05000000074505806;
                            else
                                ((Wave)Game1.waves[0]).waveAngle += 0.0099999997764825821;
                        }
                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad2)
                                        && DebugAssistant.debugKeyCooldown == 0)
                        {
                            Wave wave = (Wave)Game1.waves[0];

                            File.AppendAllText("waves.txt", "new Tuple<Vector2, float>(" +
                                "new Vector2(" + wave.startingPoint.X.ToString() + ", "
                                + wave.startingPoint.Y.ToString() + "), "
                                + Math.Round(wave.waveAngle * (180.0 / Math.PI), 2)
                                .ToString((IFormatProvider)CultureInfo.InvariantCulture) + ")"
                                + Environment.NewLine);

                            DebugAssistant.debugKeyCooldown = 60;
                            Game1.waves.Add((IBackgroundEffect)
                                new Wave(wave.startingPoint, wave.length, wave.waveAngle, true));
                        }
                        if (((Wave)Game1.waves[0]).waveAngle > 2.0 * Math.PI)
                            ((Wave)Game1.waves[0]).waveAngle = 2.0 * Math.PI;
                        if (((Wave)Game1.waves[0]).waveAngle < 0.0)
                            ((Wave)Game1.waves[0]).waveAngle = 0.0;
                    }//
                    #endregion

                    // F12 Handling Recorder
                    if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F12)
                    && DebugAssistant.debugKeyCooldown == 0)
                    {
                        DebugAssistant.debugKeyCooldown = 60;


                        #region Recorder
                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S))
                        {
                            System.Diagnostics.Debug.WriteLine("[ii] F12 + S pressed when debug panel active. " +
                                "Test Recorder.StartReRender >>");

                            Recorder.StartReRender(localFolder.Path + "\\DTGEXP\\", game);
                        }


                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.R))
                        {
                            System.Diagnostics.Debug.WriteLine("[ii] F12 + R pressed when debug panel active. " +
                                "Test Recorder.StartRecording >>");

                            Recorder.StartRecording();
                        }

                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.T))
                        {
                            System.Diagnostics.Debug.WriteLine("[ii] F12 + T pressed. " +
                                "Call Recorder.Terminate to stop recording session!>>");

                            Recorder.StartRecording();
                        }

                        #endregion


                    }//if...Keys.F12... 

 #region WorldControl
                    // F9. Handling some World Control 
                    if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F9) && DebugAssistant.debugKeyCooldown == 0)
                    {
                        DebugAssistant.debugKeyCooldown = 60;

                        System.Diagnostics.Debug.WriteLine("[ii] F9 pressed  (World Control...)");

                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D)
                            && Game1.world.Level > 0)
                        {
                            System.Diagnostics.Debug.WriteLine("[ii] F9+D pressed. Decrease World level.");
                            --Game1.world.Level;
                        }

                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.I)
                           && Game1.world.Level < 3)
                        {
                            System.Diagnostics.Debug.WriteLine("[ii] F9+I pressed. Increase World level.");
                            ++Game1.world.Level;
                        }

                        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.E))
                        {
                            System.Diagnostics.Debug.WriteLine("[ii] F9+E pressed. Test Static World Export !");
                            DebugAssistant.ExportStaticWorld(game);
                        }                       
                    }

#endregion


                    // F8. Handling some World tune 
                    if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F8) && DebugAssistant.debugKeyCooldown == 0)
        {
            DebugAssistant.debugKeyCooldown = 60;

            System.Diagnostics.Debug.WriteLine("[ii] F8 pressed when debug panel active. Some World tune...");

            int num = 1;
            if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl))
            {
                System.Diagnostics.Debug.WriteLine("[ii] L.CTRL increases num to 6 :)");
                num = 6;
            }

            foreach (IWorldObject worldObject in GUIManager.editorHUD.woInTarget)
            {
                IWorldObject wo = worldObject;
                if (!(wo is BuildPoint))
                {
                    wo.Location = new Vector2(wo.Location.X - (float)num, wo.Location.Y);
                    Vector2 explicitEpicenter3 = wo.ExplicitEpicenter;
                    Vector2 explicitEpicenter4 = wo.ExplicitEpicenter;
                    explicitEpicenter4.X -= (float)num;
                    wo.ExplicitEpicenter = explicitEpicenter4;
                    if (DebugAssistant.woModifiedInGameEditor.All<IWorldObject>(
                        (Func<IWorldObject, bool>)(p => p.ObjectId != wo.ObjectId)))
                        DebugAssistant.woModifiedInGameEditor.Add(wo);
                }
            }
        }


      // F7. Handling Cutscene Manager
        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F7) && DebugAssistant.debugKeyCooldown == 0)
        {
            DebugAssistant.debugKeyCooldown = 60;

            System.Diagnostics.Debug.WriteLine("[ii] F7 pressed when debug panel active. Test Scene switch !");

            //CutsceneManager.StartCutscene((ICutscene)new ArchipelagoArrivalCutscene(),
            //gameTime, Game1.player, Game1.world);
            CutsceneManager.StartCutscene((ICutscene)new StoryIntroCutscene(), 
                gameTime, Game1.player, Game1.world);

        }

        // F6. Handling Inventory
        if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F6) && DebugAssistant.debugKeyCooldown == 0)
        {
            DebugAssistant.debugKeyCooldown = 60;

            System.Diagnostics.Debug.WriteLine("[ii] F6 pressed. Add items to Inventory!");

            for (int itemId = 0; itemId < 17; ++itemId)
            {
                // itemId -- id of item; 99 - count
                Game1.player.inventory.AddItem(new ItemStack(itemId, 99));                
            }

        }

                          
       // F5. Handling Load game      
        if ( ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F5)   && DebugAssistant.debugKeyCooldown == 0  )
        {
            DebugAssistant.debugKeyCooldown = 60;

            System.Diagnostics.Debug.WriteLine("[ii] F5 pressed. Test Load game !");

            SaveHandler.LoadGame(1, Game1.commonSprites, game);
        }
     

      // F4. Handling Save game
        if ( ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F4)   && DebugAssistant.debugKeyCooldown == 0 
                        && GUIManager.OpenHudBesideInteract() == 0)
        {
            DebugAssistant.debugKeyCooldown = 60;

            System.Diagnostics.Debug.WriteLine("[ii] F4 pressed. Test Save game !");

            SaveHandler.SaveGame(Game1.world, Game1.player, game.lastFrame);
        }
     
      }
    }

    DebugAssistant.previousks = ks;
  }//KeyInput


    // DrawDebugPanel
  public static void DrawDebugPanel(SpriteBatch sb, Game1 game)
  {
    if (!DebugAssistant.debugPanel)
      return;

    // DEBUG
    if 
    ( 
       (DebugAssistant.previousks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftAlt)
        || DebugAssistant.previousks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightAlt)
        ) 
        && !GUIManager.currentHUDs.OfType<EditorGUI>().Any<EditorGUI>()
    )
    {
        sb.Begin(SpriteSortMode.Immediate);

        if (DebugAssistant.debugPanelActiveMenu.HasValue)
        {
            List<string> stringList = new List<string>();
            Microsoft.Xna.Framework.Input.Keys? debugPanelActiveMenu
                        = DebugAssistant.debugPanelActiveMenu;
            Microsoft.Xna.Framework.Input.Keys keys1 = Microsoft.Xna.Framework.Input.Keys.A;
            if (debugPanelActiveMenu.GetValueOrDefault() == keys1 & debugPanelActiveMenu.HasValue)
            {
                stringList.Add("[A] Previous wind step");
                stringList.Add("[Z] Next wind step");
                stringList.Add("[E] Fast forward");
                stringList.Add("[R] Fast forward (faster)");
                stringList.Add("");
                stringList.Add("Time is " + Math.Round(DayCycle.dayTime, 0).ToString()
                    + "(" + DayCycle.CyclePart + ")");
            }
            else
            {
                debugPanelActiveMenu = DebugAssistant.debugPanelActiveMenu;
                Microsoft.Xna.Framework.Input.Keys keys2 = Microsoft.Xna.Framework.Input.Keys.Z;
                if (debugPanelActiveMenu.GetValueOrDefault() == keys2 & debugPanelActiveMenu.HasValue)
                {
                    stringList.Add("[A] Save to current slot");
                    stringList.Add("[Z] Load from current slot");
                    stringList.Add("[E] Load dynamic savefile (slot 0)");
                    stringList.Add("[Q] Load from slot 1");
                    stringList.Add("[S] Load from slot 2");
                    stringList.Add("[D] Load from slot 3");
                    stringList.Add("[W] Save to slot 1");
                    stringList.Add("[X] Save to slot 2");
                    stringList.Add("[C] Save to slot 3");
                    stringList.Add("");
                    stringList.Add("Current slot: " + SaveHandler.slot.ToString());
                    stringList.Add("Next autosave in "
                        + Math.Round((300000.0 - (double)game.timeSinceLastAutosave) / 1000.0)
                        .ToString());
                }
                else
                {
                    debugPanelActiveMenu = DebugAssistant.debugPanelActiveMenu;
                    Microsoft.Xna.Framework.Input.Keys keys3 
                                = Microsoft.Xna.Framework.Input.Keys.E;
                    if (debugPanelActiveMenu.GetValueOrDefault() == keys3 
                                & debugPanelActiveMenu.HasValue)
                    {
                        stringList.Add("[A] Unlock all");
                        stringList.Add("[Z] Lock all");
                        stringList.Add("[E] (Dis)Allow Superdodo");
                    }
                    else
                    {
                        debugPanelActiveMenu = DebugAssistant.debugPanelActiveMenu;
                        Microsoft.Xna.Framework.Input.Keys keys4 = Microsoft.Xna.Framework.Input.Keys.R;
                        if (debugPanelActiveMenu.GetValueOrDefault() == keys4 & debugPanelActiveMenu.HasValue)
                        {
                            stringList.Add("[A] Decrement level");
                            stringList.Add("[Z] Increment level");
                            stringList.Add("[E] Export static code definition");
                            stringList.Add("");
                            stringList.Add("Current level: " + Game1.world.Level.ToString());
                        }
                        else
                        {
                            debugPanelActiveMenu = DebugAssistant.debugPanelActiveMenu;
                            Microsoft.Xna.Framework.Input.Keys keys5 = Microsoft.Xna.Framework.Input.Keys.T;
                            if (debugPanelActiveMenu.GetValueOrDefault() == keys5 & debugPanelActiveMenu.HasValue)
                            {
                                stringList.Add("[A] Set input to Keyboard");
                                stringList.Add("[Z] Set input to Joy-Con (requires external driver)");
                                stringList.Add("[E] Set input to Wiimote");
                                stringList.Add("[R] Cycle peripheral");
                                stringList.Add("");
                                stringList.Add(game.userInput.inputError ? "Input error" : "Input OK");
                            }
                            else
                            {
                                debugPanelActiveMenu = DebugAssistant.debugPanelActiveMenu;
                                Microsoft.Xna.Framework.Input.Keys keys6 
                                            = Microsoft.Xna.Framework.Input.Keys.Q;
                                if (!(debugPanelActiveMenu.GetValueOrDefault()
                                            == keys6 & debugPanelActiveMenu.HasValue))
                                {
                                    debugPanelActiveMenu = DebugAssistant.debugPanelActiveMenu;
                                    Microsoft.Xna.Framework.Input.Keys keys7 
                                                = Microsoft.Xna.Framework.Input.Keys.S;
                                    if (debugPanelActiveMenu.GetValueOrDefault() == keys7 
                                                & debugPanelActiveMenu.HasValue)
                                    {
                                        stringList.Add("[A] Give 99 of each item");
                                        stringList.Add("[Z] Empty");
                                    }
                                    else
                                    {
                                        debugPanelActiveMenu = DebugAssistant.debugPanelActiveMenu;
                                        Microsoft.Xna.Framework.Input.Keys keys8 
                                                    = Microsoft.Xna.Framework.Input.Keys.D;
                                        if (debugPanelActiveMenu.GetValueOrDefault() 
                                                    == keys8 & debugPanelActiveMenu.HasValue)
                                        {
                                            stringList.Add("[A] StoryIntroCutscene");
                                            stringList.Add("[Z] ArchipelagoArrivalCutscene");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            float num = 0.0f;
            foreach (string text in stringList)
            {
                float x = Game1.arialSpriteFont.MeasureString(text).X;
                if ((double)num < (double)x)
                    num = x;
            }

            Recorder.RDraw(sb, Game1.GenerateBox(new Vector2(num + 2f,
                (float)(stringList.Count * 14 + 2)), Color.White), Vector2.Zero, Color.White * 0.8f);

            int y = 1;
            foreach (string text in stringList)
            {
                Recorder.RDrawString(sb, Game1.arialSpriteFont, text, new Vector2(1f, (float)y),
                    Color.Black);
                y += 14;
            }
        }
        else
        {
            List<string> stringList = new List<string>();
            stringList.Add("[A] Time & Wind");
            stringList.Add("[Z] Saving");
            stringList.Add("[E] Player");
            stringList.Add("[R] World");
            stringList.Add("[T] User input");
            stringList.Add("[Q] Wave placement tool");
            stringList.Add("[S] Inventory");
            stringList.Add("[D] Cutscene");
            float num = 0.0f;
            foreach (string text in stringList)
            {
                float x = Game1.arialSpriteFont.MeasureString(text).X;
                if ((double)num < (double)x)
                    num = x;
            }

            if (DebugAssistant.previousks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftAlt)
                            || DebugAssistant.previousks.IsKeyDown(
                                Microsoft.Xna.Framework.Input.Keys.RightAlt))
            { 
                Recorder.RDraw(sb, Game1.GenerateBox(new Vector2(num + 2f,
                    (float)(stringList.Count * 14 + 2)), Color.White),
                    Vector2.Zero, Color.White * 0.8f);
            }
          int y = 1;
          foreach (string text in stringList)
          {
            Recorder.RDrawString(sb, Game1.arialSpriteFont, text, 
                new Vector2(1f, (float) y), Color.Black);
            y += 14;
          }
        }
        sb.End();
      }
      else
      {
        string str1 = string.Format("FPS: " + Game1.frameCounter.OutputFramesPerSecond.ToString());
        Color color1 = Color.Black;
        if (GUIManager.currentHUDs.OfType<EditorGUI>().Any<EditorGUI>())
          color1 = Color.White;
        sb.Begin(SpriteSortMode.Immediate);
        List<string> stringList1 = new List<string>();
        List<string> stringList2 = new List<string>();

        stringList1.Add("DodoTheGame/The Dodo Archipelago RELEASE 1.0.2");
        stringList1.Add(str1 + " ; " + Recorder.drawCallCount.ToString() 
            + " draw calls ; TPU: " + Game1.frameCounter.updateTicksAverage.ToString()
            + "(" + Game1.frameCounter.maxUpdateTicks.ToString() + ") ; TPD: "
            + Game1.frameCounter.drawTicksAverage.ToString() + "("
            + Game1.frameCounter.maxDrawTicks.ToString() + ")");
        List<string> stringList3 = stringList1;
        string[] strArray1 = new string[10]
        {
          "x=",
          Game1.player.location.X.ToString(),
          " y=",
          Game1.player.location.Y.ToString(),
          " f=",
          Game1.player.facing.ToString(),
          " fy=",
          null,
          null,
          null
        };

        int num1 = Game1.player.CurrentFeetY;
        strArray1[7] = num1.ToString();
        strArray1[8] = " mvm=";
        strArray1[9] = Game1.player.currentMovementType.ToString();
        string str2 = string.Concat(strArray1);
        stringList3.Add(str2);
        List<string> stringList4 = stringList1;
        string[] strArray2 = new string[8]
        {
          "Time:",
          Math.Round(DayCycle.dayTime, 0).ToString(),
          "(",
          DayCycle.CyclePart,
          ") Time speed:",
          null,
          null,
          null
        };

        double num2 = Math.Round(DayCycle.timeSpeed, 5);
        strArray2[5] = num2.ToString();
        strArray2[6] = "Time jauge:";
        num2 = Math.Round((double) Game1.player.TimeBar, 1);
        strArray2[7] = num2.ToString();
        string str3 = string.Concat(strArray2);
        stringList4.Add(str3);

        if (DebugAssistant.waveEditor)
        {
          Vector2 startingPoint = ((Wave) Game1.waves[0]).startingPoint;
          stringList1.Add("NUMPAD0 to bring the wave to the player");
          stringList1.Add("NUMPAD4/5/6/8 to move (CTRL to move faster)");
          stringList1.Add("NUMPAD7/9 to rotate (CTRL to rotate faster)");
          stringList1.Add("NUMPAD2 to write to world");
          stringList1.Add("Location: " + startingPoint.X.ToString() +" ; "+ startingPoint.Y.ToString());
          List<string> stringList5 = stringList1;
          num2 = Math.Round(((Wave) Game1.waves[0]).waveAngle * (180.0 / Math.PI), 2);
          string str4 = "Angle: " + num2.ToString();
          stringList5.Add(str4);
        }

        if (Game1.player.SwimPulseCount > 0)
        {
          List<string> stringList6 = stringList1;
          num1 = Game1.player.SwimPulseCount;
          string str5 = "Swim pulse count: " + num1.ToString();
          stringList6.Add(str5);
        }

        if (game.WorldLoader == Game1.WorldLoaderType.staticDefinition)
          stringList1.Add("World loaded from static definition. " +
              "Saving may not be supported in this build.");

        if (game.userInput.inputError)
          stringList2.Add("Input error! Check controller status.");

        if (CutsceneManager.CutsceneActive)
          stringList1.Add("Playing cutscene " + CutsceneManager.CurrentCutsceneType.ToString());
        
        int y = 1;

        foreach (string text in stringList1)
        {
          Recorder.RDrawString(sb, Game1.arialSpriteFont, text, new Vector2(1f, (float) y), color1);
          y += 14;
        }

        foreach (string text in stringList2)
        {
          Recorder.RDrawString(sb, Game1.arialSpriteFont, text, new Vector2(1f, (float) y), Color.Red);
          y += 14;
        }

        float getSpeed = (float) Wind.GetSpeed;
        Color color2 = new Color(1f, 1f - getSpeed, 1f - getSpeed);

        Recorder.RDraw(sb, DebugAssistant.debugWindArrow, 
            new Vector2(50f, 270f), new Rectangle?(), 
            color2, Convert.ToSingle(Wind.GetAngle - Math.PI / 2.0), 
            new Vector2(30f, 15f), new Vector2(1f, 1f), SpriteEffects.None, 0.0f);
        sb.End();
      }

    }//DrawDebugPanel

  }//DebugAssistant 
}
