
// Type: DodoTheGame.Sound

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DodoTheGame.BackgroundEffects;
using DodoTheGame.BGM;
using DodoTheGame.Cutscene;
using DodoTheGame.GUI;
using DodoTheGame.WorldObject;
using FMOD;
using FMOD.Studio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;


namespace DodoTheGame
{
  internal static class Sound
  {
    public static List<SoundEffect> soundEffectList;
    public static List<SoundEffectInstance> backgroundEffectList;
    public static List<float> backgroundEffectFactors;
    public static Dictionary<string, IBGM> BGMs = new Dictionary<string, IBGM>();
    public static float sfxVolume = 1f;
    public static float bgmVolume = 1f;
    public static float waveFactor = 0.0f;
    public const int BGE_WAVES = 0;
    public static IBGM currentBGM;
    private static double timeSinceLastRandomBGMCheck;
    private static EventHandler<EventArgs> MidnightTune;
    private static bool midnightTunePlayed = false;
    private static FMOD.Studio.System fmodSys;
    private static readonly Dictionary<string, string> fmodEventHandling = new Dictionary<string, string>()
    {
      {
        "Player.Dolphin",
        "event:/SFX/Dolphin"
      },
      {
        "Player.EnteredWater",
        "event:/SFX/EnterWater"
      },
      {
        "Player.MovedBike",
        "event:/SFX/BikeMove"
      },
      {
        "Player.StartedBuilding",
        "event:/SFX/Build"
      },
      {
        "Player.Walked",
        "event:/SFX/Footsteps/DodoStep"
      },
      {
        "InventoryGUI.Closed",
        "event:/SFX/UI/Inventory/Close"
      },
      {
        "InventoryGUI.Opened",
        "event:/SFX/UI/Inventory/Open"
      },
      {
        "InventoryGUI.MovedItemSelection",
        "event:/SFX/UI/Inventory/Selection"
      },
      {
        "EscapeGUI.Opened",
        "event:/SFX/UI/Escape/Open"
      },
      {
        "EscapeGUI.Closed",
        "event:/SFX/UI/Escape/Close"
      },
      {
        "EscapeGUI.MovedItemSelection",
        "event:/SFX/UI/Escape/Selection"
      },
      {
        "SettingsGUI.MovedItemSelection",
        "event:/SFX/UI/Settings/Selection"
      },
      {
        "Player.StartedHarvesting",
        "event:/SFX/Harvest"
      },
      {
        "Player.StartedSwimmingPulse",
        "event:/SFX/SwimPulse"
      },
      {
        "BuildPoint.BuildBoxOpened",
        "event:/SFX/UI/BuildBox/Open"
      },
      {
        "BuildPoint.BuildBoxClosed",
        "event:/SFX/UI/BuildBox/Close"
      },
      {
        "Game1.StartupLogo",
        "event:/SFX/GameLogo"
      },
      {
        "Sound.MidnightTune",
        "event:/BGM/MidnightTune"
      },
      {
        "EnvironmentalSoundManager.Owl",
        "event:/SFX/Owl"
      },
      {
        "BirdShadowManager.Seagull",
        "event:/SFX/Seagull"
      },
      {
        "Player.BikeAppearing",
        "event:/SFX/BikeAppear"
      },
      {
        "World.Progress",
        "event:/SFX/Progress"
      }
    };
    internal static Dictionary<string, EventDescription> fmodEvents;

    public static bool SoundSystemInitialized { get; private set; }

    [Obsolete("RegisterLegacyEvent may be used for the old non-Event registering of game events. For newer implementations, standard C# events should be used.")]
    public static void RegisterLegacyEvent(GlobalEvent gEvent)
    {
      switch (gEvent.gameEvent)
      {
        case GlobalEvent.Event.BoardBuilt:
        case GlobalEvent.Event.BoardUpgraded:
        case GlobalEvent.Event.VehicleUnlocked:
          Sound.ReceiveEvent((object) null, EventArgs.Empty, "World.Progress");
          break;
      }
    }

    private static void FmodCreateAndPlay(string eventName)
    {
      EventInstance instance;
      Sound.FMODErrCheck(Sound.fmodEvents[eventName].createInstance(out instance));
      Sound.FMODErrCheck(instance.start());
      Sound.FMODErrCheck(instance.release());
    }

    public static void ReceiveEvent(object sender, EventArgs e, string eventName)
    {
      if (Sound.fmodEventHandling.ContainsKey(eventName))
        Sound.FmodCreateAndPlay(Sound.fmodEventHandling[eventName]);
      else
        System.Diagnostics.Debug.WriteLine(
            "[!] Sound.ReceiveEvent count not find an FMOD event for event " + eventName);
    }

    internal static void FMODErrCheck(RESULT res)
    {
      if (res != RESULT.OK)
        throw new Exception(Error.String(res));
    }

    public static void InitSound(List<SoundEffect> backgroundEffects, Game1 game)
    {
      Sound.backgroundEffectList = new List<SoundEffectInstance>();
      foreach (SoundEffect backgroundEffect in backgroundEffects)
      {
        SoundEffectInstance instance = backgroundEffect.CreateInstance();
        instance.IsLooped = true;
        Sound.backgroundEffectList.Add(instance);
      }
      int num = (int) FMOD.Studio.System.create(out Sound.fmodSys);
      Sound.FMODErrCheck(Sound.fmodSys.initialize(32, FMOD.Studio.INITFLAGS.LIVEUPDATE, FMOD.INITFLAGS.NORMAL, (IntPtr) 0));
      Bank bank;
      Sound.FMODErrCheck(Sound.fmodSys.loadBankFile("Content/Master.bank", LOAD_BANK_FLAGS.NORMAL, out bank));
      Sound.FMODErrCheck(Sound.fmodSys.loadBankFile("Content/Master.strings.bank", LOAD_BANK_FLAGS.NORMAL, out Bank _));
      Sound.fmodEvents = new Dictionary<string, EventDescription>();
      EventDescription[] array;
      Sound.FMODErrCheck(bank.getEventList(out array));
      foreach (EventDescription eventDescription in array)
      {
        string path;
        Sound.FMODErrCheck(eventDescription.getPath(out path));
        Sound.fmodEvents.Add(path, eventDescription);
        Sound.FMODErrCheck(eventDescription.loadSampleData());
      }
      MediaPlayer.MediaStateChanged += new EventHandler<EventArgs>(Sound.StateSongChanged);
      Sound.SoundSystemInitialized = true;
    }

    public static void InitEvents(Game1 game)
    {
      Game1.player.Walked += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "Player.Walked"));
      Game1.player.CollisionWithObjectOrTerrain += (EventHandler<PlayerCollisionEventArgs>) ((sender, e) => Sound.ReceiveEvent(sender, (EventArgs) e, "Player.CollisionWithObjectOrTerrain"));
      Game1.player.Dolphin += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "Player.Dolphin"));
      Game1.player.EnteredWater += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "Player.EnteredWater"));
      Game1.player.LeftWater += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "Player.LeftWater"));
      Game1.player.StartedBuilding += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "Player.StartedBuilding"));
      Game1.player.StartedHarvesting += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "Player.StartedHarvesting"));
      Game1.player.StartedSwimmingPulse += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "Player.StartedSwimmingPulse"));
      Game1.player.MovedBike += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "Player.MovedBike"));
      Game1.player.BikeAppearing += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "Player.BikeAppearing"));
      GUIManager.inventoryGUI.Closed += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "InventoryGUI.Closed"));
      GUIManager.inventoryGUI.Opened += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "InventoryGUI.Opened"));
      GUIManager.inventoryGUI.MovedItemSelection += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "InventoryGUI.MovedItemSelection"));
      GUIManager.escapeGUI.Opened += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "EscapeGUI.Opened"));
      GUIManager.escapeGUI.Closed += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "EscapeGUI.Closed"));
      GUIManager.escapeGUI.MovedItemSelection += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "EscapeGUI.MovedItemSelection"));
      GUIManager.settings.MovedItemSelection += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "SettingsGUI.MovedItemSelection"));
      GUIManager.mainmenu.Opened += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "MainMenu.Opened"));
      GUIManager.mainmenu.Closed += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "MainMenu.Closed"));
      EnvironmentalSoundManager.Owl += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "EnvironmentalSoundManager.Owl"));
      BirdShadowManager.Seagull += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "BirdShadowManager.Seagull"));
      GUIManager.mainmenu.MovedItemSelection += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "MainMenu.MovedItemSelection"));
      BuildPoint.BuildBoxOpened += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "BuildPoint.BuildBoxOpened"));
      BuildPoint.BuildBoxClosed += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "BuildPoint.BuildBoxClosed"));
      Game1.StartupLogo += (EventHandler) ((sender, e) => Sound.ReceiveEvent(sender, e, "Game1.StartupLogo"));
      Sound.MidnightTune += (EventHandler<EventArgs>) ((sender, e) => Sound.ReceiveEvent(sender, e, "Sound.MidnightTune"));
    }

    private static void StateSongChanged(object sender, EventArgs e)
    {
      Sound.currentBGM.StateSongChanged(sender, e);
    }

    public static void UpdateBGE(int BGEId, float factor)
    {
      //TODO
      /*
      if ((double) factor == 0.0 && Sound.backgroundEffectList[BGEId].State == SoundState.Playing)
        Sound.backgroundEffectList[BGEId].Stop();
      else if ((double) factor > 0.0 && Sound.backgroundEffectList[BGEId].State == SoundState.Stopped)
        Sound.backgroundEffectList[BGEId].Play();
      Sound.backgroundEffectList[BGEId].Volume = Sound.sfxVolume * factor;
      */
    }

    public static void StartMusic(IBGM bgm)
    {
        //TODO
        /*
      if (Sound.currentBGM != null && Sound.currentBGM.Status != BGMStatus.Stopped)
        return;
      Sound.currentBGM = bgm;
      Sound.currentBGM.Start();
      */
    }

    public static void UpdateFMOD()
    {
      if (!Sound.SoundSystemInitialized)
        return;
      int num = (int) Sound.fmodSys.update();
    }

    public static void Update(GameTime gametime, Game1 game)
    {
      Sound.FMODErrCheck(Sound.fmodSys.setParameterByName("GroundStandingOn", Convert.ToSingle((int) Game1.player.StandingOnTerrainType)));
      Vector2 vector2 = new Vector2(9000f, 8100f);
      double num = Math.Sqrt(Math.Pow((double) Game1.player.location.X - (double) vector2.X, 2.0) + Math.Pow((double) Game1.player.location.Y - (double) vector2.Y, 2.0));
      if (!CutsceneManager.CutsceneActive && num < 900.0 && Game1.world.Level >= 1 && DayCycle.CurrentTime > 10.0 && DayCycle.CurrentTime < 275.0)
      {
        if (Sound.currentBGM == null || Sound.currentBGM == Sound.BGMs["Village"] || Sound.currentBGM.Status == BGMStatus.Stopped)
        {
          Sound.currentBGM = Sound.BGMs["Village"];
          Sound.currentBGM.Start();
          Sound.currentBGM.RequestStop(false);
        }
        else
          Sound.currentBGM.RequestStop(true);
      }
      else if (num > 1700.0 || DayCycle.CurrentTime < 10.0 || DayCycle.CurrentTime > 275.0)
        Sound.currentBGM?.RequestStop(true);
      if (!CutsceneManager.CutsceneActive)
      {
        Sound.timeSinceLastRandomBGMCheck += gametime.ElapsedGameTime.TotalMilliseconds;
        if (Sound.timeSinceLastRandomBGMCheck > 2000.0)
        {
          Sound.timeSinceLastRandomBGMCheck = 0.0;
          if (num > 3000.0 && DayCycle.CurrentTime > 10.0 && DayCycle.CurrentTime < 275.0 && Game1.player.bgmThemeCount < 3 && (Sound.currentBGM == null || Sound.currentBGM.Status == BGMStatus.Stopped) && Game1.player.currentMovementType != Player.DodoMovement.Bicycle && Game1.rand.Next(0, 10) == 1)
          {
            ++Game1.player.bgmThemeCount;
            ++Game1.player.bgmThemeDay;
            if (Game1.player.bgmThemeDay > 4)
              Game1.player.bgmThemeDay = 1;
            Sound.currentBGM = Sound.BGMs["Daily" + Game1.player.bgmThemeDay.ToString()];
            Sound.currentBGM.Start();
          }
        }
        if (DayCycle.CurrentTime > 430.0 && DayCycle.CurrentTime < 438.0 && !Sound.midnightTunePlayed && Game1.player.currentMovementType != Player.DodoMovement.Bicycle)
        {
          Sound.midnightTunePlayed = true;
          Sound.MidnightTune((object) null, new EventArgs());
        }
        else if (DayCycle.CurrentTime < 430.0 || DayCycle.CurrentTime > 438.0)
          Sound.midnightTunePlayed = false;
      }
      Sound.currentBGM?.Update(gametime);
    }

    public static void StopMusic()
    {
        Sound.currentBGM.RequestStop(true);
    }
  }
}
