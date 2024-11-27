// Type: DodoTheGame.Saving.Save

using DodoTheGame.Localization;
using DodoTheGame.NPC;
using DodoTheGame.WorldObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using XSystem.Security.Cryptography;
using SHA512 = XSystem.Security.Cryptography.SHA512;
//using System.Web.Script.Serialization; // TODO: fit It and delete xact.core.pcl
using Windows.Storage;


namespace DodoTheGame.Saving
{
  internal class Save
  {
    public Player player;
    public World world;
    public int saveSlot;
    public bool currentlySaving;
    public Texture2D lastFrame;
    public static string saveFolder;
    private const string formatCounter = "000024";
    private const string verificationString = "ourhardworkbythishashguardedpleasedontcheat";
    public static readonly JavaScriptSerializer serializer = new JavaScriptSerializer()
    {
      MaxJsonLength = int.MaxValue
    };

    public Save()
    {
      if (Directory.Exists(Save.saveFolder))
        return;

      try
      {
         Directory.CreateDirectory(Save.saveFolder);
      }
      catch (Exception ex)
      {
         Debug.WriteLine("[ex] Save - CreateDirectory error: " + ex.Message);
      }
    }

    public SaveInfo GetSaveInfo(GraphicsDevice graphicsDevice)
    {
      string path = this.saveSlot != 0 ? Save.saveFolder 
                + "slot" + this.saveSlot.ToString() + ".dodomemory" : "Content\\slot0.dodomemory";
      string[] strArray = new string[5];
      string str1 = "";
      string str2 = "";
      object[] objArray1 = default;
            
        try
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                using (StreamReader streamReader = new StreamReader((Stream)fileStream))
                {
                    strArray[0] = streamReader.ReadLine();
                    strArray[1] = streamReader.ReadLine();
                    strArray[2] = streamReader.ReadLine();
                    strArray[3] = streamReader.ReadLine();
                    strArray[4] = streamReader.ReadLine();
                    str2 = streamReader.ReadLine();

                    objArray1 = Save.serializer.Deserialize<object[]>(strArray[0]);
                    
                    using (SHA512 shA512 = (SHA512)new SHA512Managed())
                    {
                        foreach (string str3 in strArray)
                            str1 += Convert.ToBase64String(shA512.ComputeHash(
                                Encoding.UTF8.GetBytes(str3 + 
                                "ourhardworkbythishashguardedpleasedontcheat")));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("[ex] Save - new FileStream path error: " + ex.Message);
        }


        if (str1 == str2)
        {
            if (objArray1 == null)
            {
                Debug.WriteLine("[!] A corrupted save was not loaded!");
                return new SaveInfo(false, 0, new DateTime(), (Texture2D)null);
            }

        if ((string) objArray1[3] != "000024")
          throw new Exception("This save file is not supported by this build");
        Texture2D texture = Save.BytePngToTexture(Convert.FromBase64String(strArray[4]), graphicsDevice);
        
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        
        object[] objArray2 = Save.serializer.Deserialize<object[]>(strArray[0]);

        //RnD
        DateTime localTime = DateTime.Now;

        try
        {
            localTime = dateTime.AddSeconds((double)(Int64)objArray2[7]).ToLocalTime();
        }
        catch (Exception ex)
        {
           Debug.WriteLine("[ex] Save - dateTime.Add error: " + ex.Message);
        }

        //RnD
        Int64 playTime = 1;

        try
        {
            playTime = (Int64)objArray2[14];
        }
        catch (Exception ex)
        {
            Debug.WriteLine("[ex] Save - playTime error: " + ex.Message);
        }

        Debug.WriteLine("[i] A save info was loaded.");
        
        return new SaveInfo(true, (int)playTime, localTime, texture);
      }

      Debug.WriteLine("[!] A corrupted save was not loaded. Try to update fake save data");
      return new SaveInfo(false, 0, new DateTime(), (Texture2D) null);
    }

    private static Texture2D BytePngToTexture(byte[] base64dat, GraphicsDevice graphicsDevice)
    {
      StorageFolder localFolder = ApplicationData.Current.LocalFolder;
           
      if (!Directory.Exists(/*Path.GetTempPath()*/localFolder.Path + "\\dtgtemp"))
        Directory.CreateDirectory(/*Path.GetTempPath()*/localFolder.Path + "\\dtgtemp");

      File.WriteAllBytes(/*Path.GetTempPath()*/localFolder.Path + "\\dtgtemp\\a.png", base64dat);

      FileStream fileStream = File.Open(/*Path.GetTempPath()*/localFolder.Path + "\\dtgtemp\\a.png", 
          FileMode.Open);
      
      StreamReader streamReader = new StreamReader((Stream) fileStream);

      Texture2D texture =  default;

      try
      {
        texture = Texture2D.FromStream(graphicsDevice, (Stream)fileStream);
      }
      catch (Exception ex)
      {
        Debug.WriteLine("[ex] Save - Texture2D.FromStream error: " + ex.Message);
      }


      fileStream.Dispose();

      try
      {
            File.Delete(/*Path.GetTempPath()*/localFolder.Path + "\\dtgtemp\\a.png");
      }
      catch 
      {
      }

      return texture;
    }

    // 
    public void LoadFromFile(List<Sprite> commonSprites, Game1 game)
    {
      Debug.WriteLine("[i] Loading save data...");
      string path = this.saveSlot != 0 ? Save.saveFolder + "slot" 
                + this.saveSlot.ToString() + ".dodomemory" : "Content\\slot0.dodomemory";
      string str1 = "";
      string str2;
      object[] objArray;
      Inventory inventory;
      List<IWorldObject> worldObjectList;
      List<INPC> npcList;
      Texture2D texture;
      using (FileStream fileStream = new FileStream(path, FileMode.Open))
      {
        using (StreamReader streamReader = new StreamReader((Stream) fileStream))
        {
          string[] strArray = new string[5]
          {
            streamReader.ReadLine(),
            streamReader.ReadLine(),
            streamReader.ReadLine(),
            streamReader.ReadLine(),
            streamReader.ReadLine()
          };
          str2 = streamReader.ReadLine();
          objArray = Save.serializer.Deserialize<object[]>(strArray[0]);
          inventory = Save.serializer.Deserialize<Inventory>(strArray[1]);
          worldObjectList = Save.serializer.Deserialize<List<IWorldObject>>(strArray[2]);
          npcList = Save.serializer.Deserialize<List<INPC>>(strArray[3]);
          texture = Save.BytePngToTexture(Convert.FromBase64String(strArray[4]), game.GraphicsDevice);
          using (SHA512 shA512 = (SHA512) new SHA512Managed())
          {
            foreach (string str3 in strArray)
              str1 += Convert.ToBase64String(shA512.ComputeHash(Encoding.UTF8.GetBytes(str3 + "ourhardworkbythishashguardedpleasedontcheat")));
          }
        }
      }
      if (str1 == str2)
      {
        if ((string) objArray[3] != "000024")
          throw new Exception("This save file is not supported by this build");

        //RnD
        Player player = new Player()
        {
          currentMovementType = default,//(Player.DodoMovement) objArray[10],
          facing = (int) objArray[11],
          location = new Vector2(Convert.ToSingle(objArray[12], (IFormatProvider) CultureInfo.InvariantCulture), Convert.ToSingle(objArray[13], (IFormatProvider) CultureInfo.InvariantCulture)),
          inventory = inventory,
          playTime = (int) objArray[14],
          unlockedPlayerTools = new Dictionary<PlayerUnlockables.PlayerUnlockable, bool>()
          {
            {
              PlayerUnlockables.PlayerUnlockable.Bike,
              false
            },
            {
              PlayerUnlockables.PlayerUnlockable.Bicycle,
              false
            }
          },
          bgmThemeDay = (int) objArray[18],
          bgmThemeCount = (int) objArray[19]
        };
        player.unlockedPlayerTools[PlayerUnlockables.PlayerUnlockable.Bike] = (bool) objArray[15];
        player.unlockedPlayerTools[PlayerUnlockables.PlayerUnlockable.Bicycle] = (bool) objArray[16];
        player.TimeBar = Convert.ToSingle(objArray[20], (IFormatProvider) CultureInfo.InvariantCulture);

        World world = new World()
        {
          name = (string) objArray[21],
          Level = (int) objArray[22],
          objects = worldObjectList,
          NPCs = npcList
        };

        DayCycle.dayTime = Convert.ToDouble(objArray[23], (IFormatProvider) CultureInfo.InvariantCulture);
        Wind.RawAngle = Convert.ToDouble(objArray[24], (IFormatProvider) CultureInfo.InvariantCulture);
        DayCycle.currentWindIndex = Convert.ToInt32(objArray[25]);
        this.lastFrame = texture;
        this.player = player;
        this.world = world;
      }
      else
      {
        Debug.WriteLine("[!] A corrupted save was not loaded. Default save will be loaded.");
        this.saveSlot = 0;
        this.LoadFromFile(commonSprites, game);
      }
    }

    public void SaveToFile(bool compressed = false, byte[] lastFramePngBytes = null)
    {
      string saveData = this.GenerateSaveData(lastFramePngBytes);
      File.WriteAllText(Save.saveFolder + "slot" + this.saveSlot.ToString() + ".dodomemory", saveData);
    }

    public string GenerateSaveData(byte[] lastFramePngBytes = null)
    {
      Debug.WriteLine("[i] Generating save data...");
      object[] objArray = new object[26]
      {
        (object) "",
        (object) "Archipelago-A",
        (object) "0.1",
        (object) "000024",
        (object) "",
        (object) "",
        (object) "",
        (object) (int) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
        (object) "",
        (object) "",
        (object) this.player.currentMovementType,
        (object) this.player.facing,
        (object) this.player.location.X,
        (object) this.player.location.Y,
        (object) this.player.playTime,
        (object) this.player.unlockedPlayerTools[PlayerUnlockables.PlayerUnlockable.Bike],
        (object) this.player.unlockedPlayerTools[PlayerUnlockables.PlayerUnlockable.Bicycle],
        (object) this.player.allowSuperdodo,
        (object) this.player.bgmThemeDay,
        (object) this.player.bgmThemeCount,
        (object) Convert.ToString(this.player.TimeBar, (IFormatProvider) CultureInfo.InvariantCulture),
        (object) this.world.name,
        (object) this.world.Level,
        (object) Convert.ToString(DayCycle.CurrentTime, (IFormatProvider) CultureInfo.InvariantCulture),
        (object) Wind.RawAngle,
        (object) DayCycle.currentWindIndex
      };
      byte[] inArray;
      if (lastFramePngBytes == null)
      {
        Debug.WriteLine("[i] Generating screenshot data...");
        MemoryStream memoryStream = new MemoryStream();
        this.lastFrame.SaveAsPng((Stream) memoryStream, Convert.ToInt32(Game1.renderSize.X), 
            Convert.ToInt32(Game1.renderSize.Y));
        inArray = memoryStream.ToArray();
      }
      else
        inArray = lastFramePngBytes;
      string base64String = Convert.ToBase64String(inArray);
      Debug.WriteLine("[i] Serializing everything...");
      string[] strArray = new string[5]
      {
        Save.serializer.Serialize((object) objArray),
        Save.serializer.Serialize((object) this.player.inventory),
        Save.serializer.Serialize((object) this.world.objects),
        Save.serializer.Serialize((object) this.world.NPCs),
        base64String
      };
      string str1 = strArray[0] + "\n" + strArray[1] + "\n" + strArray[2] + "\n" 
                + strArray[3] + "\n" + strArray[4];
      Debug.WriteLine("[i] Generating security hashes...");
      string str2;
      using (SHA512 shA512 = (SHA512) new SHA512Managed())
        str2 = Convert.ToBase64String(shA512.ComputeHash(
            Encoding.UTF8.GetBytes(strArray[0] + "ourhardworkbythishashguardedpleasedontcheat"))) 
            + Convert.ToBase64String(shA512.ComputeHash(
                Encoding.UTF8.GetBytes(strArray[1] + "ourhardworkbythishashguardedpleasedontcheat")))
                + Convert.ToBase64String(shA512.ComputeHash(Encoding.UTF8.GetBytes(strArray[2]
                + "ourhardworkbythishashguardedpleasedontcheat")))
                + Convert.ToBase64String(shA512.ComputeHash(
                    Encoding.UTF8.GetBytes(strArray[3]
                    + "ourhardworkbythishashguardedpleasedontcheat"))) 
                    + Convert.ToBase64String(shA512.ComputeHash(Encoding.UTF8.GetBytes(strArray[4] 
                    + "ourhardworkbythishashguardedpleasedontcheat")));

      Debug.WriteLine("[i] Save data generation done.");
      return str1 + "\n" + str2;
    }
  }
}
