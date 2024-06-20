// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Saving.SaveHandler
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using DodoTheGame.WorldObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;


namespace DodoTheGame.Saving
{
  internal static class SaveHandler
  {
    public static int slot = 1;
    private const int settingsSaveFormat = 1;

    public static bool CurrentlySaving { get; set; }

    public static bool IsSlotRegistered(int slot)
    {
            //TODO
            return true;//File.Exists(Save.saveFolder + nameof (slot) 
          //+ slot.ToString((IFormatProvider) CultureInfo.InvariantCulture) + ".dodomemory");
    }

    public static int LastSavedSlot
    {
      get
      {
        return !File.Exists(Save.saveFolder + "meta.dodointernal") 
        ? 9 
        : Convert.ToInt32(File.ReadAllText(Save.saveFolder + "meta.dodointernal"));
      }
    }

    public static void SaveSettings(GameSettings gs)
    {
      object[] objArray = new object[11]
      {
        (object) "",
        (object) "Archipelago-A",
        (object) 1,
        (object) "",
        (object) (int) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
        (object) gs.fullscreenSelected,
        (object) gs.resolution.X,
        (object) gs.resolution.Y,
        (object) gs.bgmVolume,
        (object) gs.sfxVolume,
        (object) gs.languageCode
      };

      File.WriteAllText(Save.saveFolder + "settings.dodointernal", 
          Save.serializer.Serialize((object) objArray));
    }

    public static GameSettings LoadSettings()
    {
      if (!File.Exists(Save.saveFolder + "settings.dodointernal"))
        return GameSettings.Default;

      object[] objArray = Save.serializer.Deserialize<object[]>(
          File.ReadAllText(Save.saveFolder + "settings.dodointernal"));

      return 1 == (int) objArray[2] 
         ? new GameSettings((bool) objArray[5], 
          new Vector2(Convert.ToSingle(objArray[6]), 
          Convert.ToSingle(objArray[7])), 
          Convert.ToSingle(objArray[8]), 
          Convert.ToSingle(objArray[9]), (string) objArray[10])
         : throw new Exception("This setting save is not supported by this version.");
    }

    public static Save LoadDefault(List<Sprite> commonSprites, Game1 game)
    {
      Save save = new Save();
      save.saveSlot = 0;
      save.LoadFromFile(commonSprites, game);
      Game1.player = save.player;
      save.world.background = Game1.world.background;
      save.world.behaviorMap = Game1.world.behaviorMap;
      Game1.world = save.world;
      game.knownSprites = new List<Sprite>();
      save.saveSlot = 1;
      SaveHandler.slot = 1;
      Sound.InitEvents(game);
      return save;
    }

    public static void SaveGame(World world, Player player, Texture2D lastFrame)
    {
      if (player.currentMovementType == Player.DodoMovement.Build 
                || player.currentMovementType == Player.DodoMovement.Harvest 
                || player.currentMovementType == Player.DodoMovement.Drown)
        return;

      SaveHandler.CurrentlySaving = true;
      File.WriteAllText(Save.saveFolder + "meta.dodointernal", SaveHandler.slot.ToString());
      Save sav = new Save()
      {
        world = world,
        player = player,
        saveSlot = SaveHandler.slot,
        lastFrame = lastFrame
      };
      MemoryStream memoryStream = new MemoryStream();
      lastFrame.SaveAsPng((Stream) memoryStream, Convert.ToInt32(Game1.renderSize.X), 
          Convert.ToInt32(Game1.renderSize.Y));
      //new Thread((ParameterizedThreadStart) (pngScreenData =>
      //{
        sav.SaveToFile(lastFramePngBytes: (byte[]) /*pngScreenData*/memoryStream.ToArray());
        SaveHandler.CurrentlySaving = false;
      //})).Start((object) memoryStream.ToArray());
    }

    public static Save LoadGame(int slot, List<Sprite> commonSprites, Game1 game)
    {
      SaveHandler.slot = slot;
      Save save = new Save();
      save.saveSlot = SaveHandler.IsSlotRegistered(slot) ? slot : 0;
      save.LoadFromFile(commonSprites, game);
      save.saveSlot = slot;
      Game1.player = save.player;
      save.world.background = Game1.world.background;
      save.world.behaviorMap = Game1.world.behaviorMap;
      Game1.world = save.world;
      game.knownSprites = new List<Sprite>();
      Sound.InitEvents(game);
      return save;
    }

    public static bool EraseSlot(int slot)
    {
      if (!SaveHandler.IsSlotRegistered(slot))
        return false;

      try
      {
        File.Delete(Save.saveFolder + nameof (slot) 
            + slot.ToString((IFormatProvider) CultureInfo.InvariantCulture) + ".dodomemory");
        return true;
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine("[ex] aveHandler - File.Delete error: " + ex.Message);
        return false;
      }
    }

    public static string SerializeSingleGameData(List<IWorldObject> objList)
    {
      return Save.serializer.Serialize((object) objList);
    }

    public static SaveInfo GetSlotInfo(int slot, GraphicsDevice graphicsDevice)
    {
      if (!SaveHandler.IsSlotRegistered(slot))
        return (SaveInfo) null;
      return new Save() { saveSlot = slot }.GetSaveInfo(graphicsDevice);
    }
  }
}
