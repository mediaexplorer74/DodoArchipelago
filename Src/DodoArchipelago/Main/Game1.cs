// Type: DodoTheGame.Game1

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.Storage;

//using System.Web.Script.Serialization;
//using FMOD;
//using FMOD.Studio;

using DodoTheGame.BackgroundEffects;
using DodoTheGame.BGM;
using DodoTheGame.Cutscene;
using DodoTheGame.ForegroundEffects;
using DodoTheGame.GUI;
using DodoTheGame.Localization;
using DodoTheGame.NPC;
using DodoTheGame.Saving;
using DodoTheGame.WorldObject;
using GameManager;

namespace DodoTheGame
{

  public partial class Game1 : Game
  {
    public const string Manifest = "DodoTheGame/The Dodo Archipelago RELEASE 1.0.1 (remake 2024)";
    public readonly Game1.WorldLoaderType WorldLoader;
    internal static GraphicsDeviceManager graphics;
    public SpriteBatch spriteBatch;
    public static Vector2 renderSize;
    public static Vector2 renderSizeUpscaled;
    public static Vector2 windowSize;
    public static bool isFullscreen = false;

    
    internal static World world;

    //[ThreadStatic]
    public static List<INPC> NPCs;

    public static Tile[,] tile = new Tile[5001, 2501]; // TEMP
    public static double worldSurface; //TEMP
    public static int spawnTileX; //TEMP
    public static int spawnTileY; //TEMP
    public static bool[] tileSolid = new bool[12]; //TEMP

    public static Vector2 dodoScreenLocation; //static ?
    public static Vector2 dodoCenteredScreenLocation; //static ?
        
    internal static PerformanceCounter frameCounter;
    internal static SpriteFont arial23SpriteFont;
    internal static SpriteFont arialSpriteFont;
    internal static SpriteFont rouliXLSpriteFont;
    internal static SpriteFont rouliLSpriteFont;
    internal static SpriteFont rouliMSpriteFont;
    internal static SpriteFont rouliSSpriteFont;
    private Sprite loadingFeatherSprite = new Sprite();
    internal Sprite dodoSprite = new Sprite();
    internal Sprite dodoSpriteMoving = new Sprite();
    internal Sprite dodoTakeNotes = new Sprite();
    internal Sprite dodoTakeSprite = new Sprite();
    internal Sprite dodoSpriteSwimIdle = new Sprite();
    internal Sprite dodoSpriteSwimPulse = new Sprite();
    internal Sprite dodoSpriteBuilding = new Sprite();
    internal Sprite dodoSpriteHarvesting = new Sprite();
    internal Sprite dodoWalkToBikeSprite = new Sprite();
    internal Sprite dodoBikeSprite = new Sprite();
    internal Sprite dodoBikeInWaterSprite;
    internal Sprite dodoBikeBSprite = new Sprite();
    internal Sprite dodoBikeInWaterBSprite = new Sprite();
    internal Sprite dodoWalkToBicycleSprite = new Sprite();
    internal Sprite dodoBicycle1Sprite = new Sprite();
    internal Sprite dodoBicycle2Sprite = new Sprite();
    internal Sprite dodoBicycle3Sprite = new Sprite();
    internal Sprite dodoSpriteSwimSink = new Sprite();
    internal Sprite dodoWakingUp = new Sprite();
    internal Sprite dodoLaying = new Sprite();
    internal Sprite[] harvestShadows;
    internal Sprite[] buildShadows;
    internal Sprite[] drowningIcons;
    internal Sprite timebar = new Sprite();
    internal Sprite buildingCloudSprite = new Sprite();
    internal Sprite preBuildingCloudSprite;
    internal Sprite harvestCloudSprite = new Sprite();
    internal static Sprite buildBoxSprite = new Sprite();
    internal static Sprite buildBox3Sprite = new Sprite();
    internal static Sprite buildPointSprite = new Sprite();
    internal static Sprite buildBoxPlusSprite = new Sprite();
    internal static Sprite buildBox3PlusSprite = new Sprite();
    internal Sprite BabyIdleSprite = new Sprite();
    internal Sprite BabyWalkSprite = new Sprite();
    internal Sprite AidleSprite = new Sprite();
    internal Sprite AwalkSprite = new Sprite();
    internal Sprite AtosleepSprite = new Sprite();
    internal Sprite AsleepSprite = new Sprite();
    internal Sprite AwakeSprite = new Sprite();
    internal Sprite BidleSprite = new Sprite();
    internal Sprite BwalkSprite = new Sprite();
    internal Sprite BtosleepSprite = new Sprite();
    internal Sprite BsleepSprite = new Sprite();
    internal Sprite BwakeSprite = new Sprite();
    internal Sprite CidleSprite = new Sprite();
    internal Sprite CwalkSprite = new Sprite();
    internal Sprite CtosleepSprite = new Sprite();
    internal Sprite CsleepSprite = new Sprite();
    internal Sprite CwakeSprite = new Sprite();
    internal Sprite DidleSprite = new Sprite();
    internal Sprite DwalkSprite = new Sprite();
    internal Sprite DtosleepSprite = new Sprite();
    internal Sprite DsleepSprite = new Sprite();
    internal Sprite DwakeSprite = new Sprite();
    internal Sprite EidleSprite = new Sprite();
    internal Sprite EwalkSprite = new Sprite();
    internal Sprite EtosleepSprite = new Sprite();
    internal Sprite EsleepSprite = new Sprite();
    internal Sprite EwakeSprite = new Sprite();
    internal Sprite ShidleSprite = new Sprite();
    internal Sprite ShwalkSprite = new Sprite();
    internal UserInput userInput = new UserInput(1);
    internal static Pathfinder pathfinder;
    internal static ScreenShake screenshake;
    internal static Player player;
    private Player.DodoMovement movementModeInLastDraw = new Player.DodoMovement();
    private UserInputStatus lastUIS = new UserInputStatus();
    internal static List<Sprite> commonSprites;
    private Texture2D whiteBackground;
    private Texture2D savingTexture;
    private Texture2D blackbar;
    private RenderTarget2D renderTarget;
    private RenderTarget2D renderTarget2;
    internal Texture2D lastFrame;
    
    // DEBUG MODE
    private bool debugEnabled = false;

    private DateTime compileDate = new DateTime();
    public Texture2D[] itemTextures;
    public static Texture2D[] smallItemTextures;
    public Texture2D[] miniFlowersTextures;
    public static Texture2D[] staticMiniFlowersTextures;
    public List<Texture2D> allTextures = new List<Texture2D>();
    internal List<Preset> presetList = new List<Preset>();
    public static Texture2D debugCursor;
    public static Texture2D redline;
    public static Texture2D debugCursor2;
    public static Texture2D[] wavesTextures = new Texture2D[4];
    public static Sprite[] windSprites;
    public static Texture2D itemsok;
    public static Texture2D itemsnok;
    public static Random rand;
    public bool contentReady;
    public Texture2D ressourceLoadingBackground720;
    public Texture2D ressourceLoadingBackground1080;
    internal static List<IBackgroundEffect> waves;
    internal static List<IBackgroundEffect> volcano;
    internal static List<IBackgroundEffect> waterfall;
    internal static List<IForegroundEffect> foregroundEffectList;
    private static Texture2D dodoteamlogo;
    private static Texture2D monogamelogo;
    private static Texture2D fmodlogo;
    public static SoundEffect startupLogoSoundEffect;

    private bool startupIntroDone = false;//!
    
    public string playtestStoragePath;
    internal float timeSinceLastAutosave;
    //public static RavenClient ravenClient;
    internal List<Sprite> knownSprites = new List<Sprite>();
    private float timeAwaitingForAuthorization;
    private MouseState previousMouseState;
    internal List<IWorldObject> woModifiedInGameEditor = new List<IWorldObject>();
    public static int wavecounterdebug = 0;
    public Vector2 backgroundPosition;
    private int startupIntroTimer;
    private int startupFadeOutTimer;
    private int startupFadeInTimer;
    private bool startupLogoEventPassed;
    private static List<Texture2D> affectedTexturesCache;

    internal static event EventHandler StartupLogo;

   

    // constructor
    public Game1()
    {
        System.Diagnostics.Debug.WriteLine("[i] Game initalizing... (constructor starts...)");
        int inputType = 1;
        int highcontrast = 0; // 1 - high contrast, 0 - normal mode      
        bool errorReporting = false;

        this.Content.RootDirectory = "Content";

        System.Diagnostics.Debug.WriteLine("====================================================");
        System.Diagnostics.Debug.WriteLine(File.ReadAllText(this.Content.RootDirectory+"\\ascii.txt"));
        System.Diagnostics.Debug.WriteLine("DodoTheGame/The Dodo Archipelago RELEASE 1.0.1");
        System.Diagnostics.Debug.WriteLine("(c) 2017-2020 Dodo Team");
        System.Diagnostics.Debug.WriteLine("====================================================");
        Game1.renderSize = new Vector2(1280f, 720f);

        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        
        Recorder.exportFolder = localFolder.Path + "\\DTGEXP\\";
        Save.saveFolder = localFolder.Path  +  "\\DTG\\";

        Game1.graphics = new GraphicsDeviceManager((Game) this);

        GameSettings gameSettings = SaveHandler.LoadSettings();
       
        try
        {
            Sound.sfxVolume = gameSettings.sfxVolume;
            Sound.bgmVolume = gameSettings.bgmVolume;
        }
        catch (Exception ex)
        {
           System.Diagnostics.Debug.WriteLine("[ex] Set sfxVolume error: " + ex.Message);
        }

        Game1.SetFullscreen(gameSettings.fullscreenSelected);
        this.IsMouseVisible = true;//false;
        Game1.windowSize = gameSettings.resolution;

        if ((double)Game1.windowSize.X / 16.0 > (double)Game1.windowSize.Y / 9.0)
        {
            Game1.renderSizeUpscaled = new Vector2((float)Convert.ToInt32((float)
                (16.0 * (double)Game1.windowSize.Y / 9.0)),
                (float)Convert.ToInt32(Game1.windowSize.Y));
        }
        else if ((double)Game1.windowSize.X / 16.0 < (double)Game1.windowSize.Y / 9.0)
        {
            Game1.renderSizeUpscaled = new Vector2((float)Convert.ToInt32(Game1.windowSize.X),
                (float)Convert.ToInt32((float)(9.0 * (double)Game1.windowSize.X / 16.0)));
        }
        else
        {
            if ((double)Game1.windowSize.X / 16.0 != (double)Game1.windowSize.Y / 9.0)
                throw new Exception("Unmanaged case");
            Game1.renderSizeUpscaled = Game1.windowSize;
        }

      this.Window.AllowUserResizing = true;
      this.Window.ClientSizeChanged += new EventHandler<EventArgs>(this.OnResize);
      string[] strArray = new string[5];
      int num = DateTime.Now.Month;
      strArray[0] = num.ToString();
      num = DateTime.Now.Day;
      strArray[1] = num.ToString();
      num = DateTime.Now.Hour;
      strArray[2] = num.ToString();
      num = DateTime.Now.Minute;
      strArray[3] = num.ToString();
      num = DateTime.Now.Second;
      strArray[4] = num.ToString();
      Recorder.sessionStartcode = string.Concat(strArray);

      
      this.userInput = new UserInput(inputType);

      Recorder.useHighContrast = highcontrast > 0;

      Game1.graphics.PreferredBackBufferWidth = (int) Game1.windowSize.X;
      Game1.graphics.PreferredBackBufferHeight = (int) Game1.windowSize.Y;

      //RnD
      Game1.graphics.HardwareModeSwitch = false;
      
      Game1.graphics.IsFullScreen = false;

      //TODO: explore this service!
      if (errorReporting)
      {
        //Game1.ravenClient = new RavenClient(
        //                    "https://5f63951fac564d55903f61afc20615e6@sentry.io/279323");
        //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(
        //    this.UnhandledException);
      }

     if (!Directory.Exists(Save.saveFolder))
     {
        try
        {
            Directory.CreateDirectory(Save.saveFolder);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("[ex] CreateDirectory - saveFolder error: "
                + ex.Message);
        }
     }

     System.Diagnostics.Debug.WriteLine("[i] Game initalized ok (constructor ends)");
    }//Game1()


    // SetFullscreen
    internal static void SetFullscreen(bool fullscreen)
    {
      if (fullscreen && !Game1.isFullscreen)
      {
        Game1.isFullscreen = true;
        Game1.graphics.IsFullScreen = true;
        Game1.graphics.ApplyChanges();
        System.Diagnostics.Debug.WriteLine("[i] Is full screen? Result: " + fullscreen.ToString());
      }
      else
      {
        if (fullscreen || !Game1.isFullscreen)
          return;
        Game1.isFullscreen = false;
        Game1.graphics.IsFullScreen = false;
        Game1.graphics.ApplyChanges();
        System.Diagnostics.Debug.WriteLine("[i] Is full screen? Result: " + fullscreen.ToString());
      }
    }

    internal static void ResizeWindow(Vector2 size)
    {
      Game1.windowSize = size;
      Game1.graphics.PreferredBackBufferWidth = (int) Game1.windowSize.X;
      Game1.graphics.PreferredBackBufferHeight = (int) Game1.windowSize.Y;
      Game1.graphics.ApplyChanges();

      if ((double)Game1.windowSize.X / 16.0 > (double)Game1.windowSize.Y / 9.0)
      {
        Game1.renderSizeUpscaled =
                    new Vector2((float)Convert.ToInt32((float)(16.0
                    * (double)Game1.windowSize.Y / 9.0)),
                    (float)Convert.ToInt32(Game1.windowSize.Y));
      }
      else if ((double)Game1.windowSize.X / 16.0 < (double)Game1.windowSize.Y / 9.0)
      {
        Game1.renderSizeUpscaled = new Vector2((float)Convert.ToInt32(Game1.windowSize.X),
            (float)Convert.ToInt32((float)(9.0 * (double)Game1.windowSize.X / 16.0)));
      }
      else
      {
        if ((double)Game1.windowSize.X / 16.0 != (double)Game1.windowSize.Y / 9.0)
            throw new Exception("Unmanaged case");
        Game1.renderSizeUpscaled = Game1.windowSize;
      }

      System.Diagnostics.Debug.WriteLine("[i] Window resized to (" 
          + Game1.windowSize.X.ToString() + "; "
          + Game1.windowSize.Y.ToString() + "). Game resized to (" 
          + Game1.renderSizeUpscaled.X.ToString() + "; " 
          + Game1.renderSizeUpscaled.Y.ToString() + ")");
    }

    public void OnResize(object sender, EventArgs e)
    {
      Game1.windowSize = new Vector2((float) this.Window.ClientBounds.Width, 
          (float) this.Window.ClientBounds.Height);

      if ((double) Game1.windowSize.X / 16.0 > (double) Game1.windowSize.Y / 9.0)
        Game1.renderSizeUpscaled = new Vector2((float) Convert.ToInt32(
            (float) (16.0 * (double) Game1.windowSize.Y / 9.0)), 
            (float) Convert.ToInt32(Game1.windowSize.Y));
      else if ((double) Game1.windowSize.X / 16.0 < (double) Game1.windowSize.Y / 9.0)
      {
        Game1.renderSizeUpscaled = new Vector2((float) Convert.ToInt32(Game1.windowSize.X), 
            (float) Convert.ToInt32((float) (9.0 * (double) Game1.windowSize.X / 16.0)));
      }
      else
      {
        if ((double) Game1.windowSize.X / 16.0 != (double) Game1.windowSize.Y / 9.0)
          throw new Exception("Unmanaged case");
        Game1.renderSizeUpscaled = Game1.windowSize;
      }
      System.Diagnostics.Debug.WriteLine("[i] Window resized to (" 
          + Game1.windowSize.X.ToString() + "; " 
          + Game1.windowSize.Y.ToString() + "). Game resized to (" 
          + Game1.renderSizeUpscaled.X.ToString() + "; "
          + Game1.renderSizeUpscaled.Y.ToString() + ")");
    }


    // Initialize
    protected override void Initialize()
    {
      System.Diagnostics.Debug.WriteLine("[i] Starting Monogame initialization");
      Game1.rand = new Random();

      GUIManager.Setup();

      Game1.player = new Player()
      {
        unlockedPlayerTools = new Dictionary<PlayerUnlockables.PlayerUnlockable, bool>()
        {
          {
            PlayerUnlockables.PlayerUnlockable.Bike,
            true/*false*/ //HACK
          },
          {
            PlayerUnlockables.PlayerUnlockable.Bicycle,
            true/*false*/ //HACK
          }
        },
        location = new Vector2(8950f, 8000f)
      };
      Game1.NPCs = new List<INPC>();
      Game1.screenshake = new ScreenShake();
      Game1.frameCounter = new PerformanceCounter();

      // last user interface state ?
      this.lastUIS = this.userInput.GetInput();
      
      Game1.affectedTexturesCache = new List<Texture2D>();
      
      this.IsMouseVisible = true;//this.debugEnabled;
      DebugAssistant.debugPanel = this.debugEnabled;

      this.renderTarget = new RenderTarget2D(
          Game1.graphics.GraphicsDevice, (int) Game1.renderSize.X, 
          (int) Game1.renderSize.Y, false, 
          this.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);

      this.renderTarget2 = new RenderTarget2D(
          Game1.graphics.GraphicsDevice, (int) Game1.renderSize.X, 
          (int) Game1.renderSize.Y, false, 
          this.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);

      Recorder.Player = Game1.player;

  
      Save.serializer.RegisterConverters((IEnumerable<JavaScriptConverter>) 
          new List<JavaScriptConverter>()
      {
        (JavaScriptConverter) new ItemStackConverter(),
        (JavaScriptConverter) new Texture2DConverter(),
        (JavaScriptConverter) new Vector2Converter(),
        (JavaScriptConverter) new IDodoInteractionConverter(),
        (JavaScriptConverter) new PresetConverter(),
        (JavaScriptConverter) new IWorldObjectConverter(),
        (JavaScriptConverter) new INPCConverter()
      });

      MediaPlayer.Volume = Sound.bgmVolume;
      this.IsFixedTimeStep = false;
      base.Initialize();
      System.Diagnostics.Debug.WriteLine("[i] Monogame initialization finished");
    }//

    // TODO: fix this multi-color console log :)
    /*
    public static void Log(string message, BreadcrumbLevel level, string category = "global")
    {
      string str = "";
      switch (level)
      {
        case BreadcrumbLevel.Critical:
          str = "CRIT";
          Console.BackgroundColor = ConsoleColor.DarkRed;
          break;
        case BreadcrumbLevel.Error:
          str = "ERROR";
          Console.BackgroundColor = ConsoleColor.Red;
          break;
        case BreadcrumbLevel.Warning:
          str = "WARN";
          Console.BackgroundColor = ConsoleColor.DarkMagenta;
          break;
        case BreadcrumbLevel.Info:
          str = "INFO";
          Console.BackgroundColor = ConsoleColor.DarkCyan;
          break;
        case BreadcrumbLevel.Debug:
          str = "DEBUG";
          Console.BackgroundColor = ConsoleColor.Black;
          break;
      }
      string[] strArray = new string[10];
      strArray[0] = "[";
      int num = DateTime.Now.Hour;
      strArray[1] = num.ToString().PadLeft(2, '0');
      strArray[2] = ":";
      num = DateTime.Now.Minute;
      strArray[3] = num.ToString().PadLeft(2, '0');
      strArray[4] = ":";
      num = DateTime.Now.Second;
      strArray[5] = num.ToString().PadLeft(2, '0');
      strArray[6] = "] [";
      strArray[7] = str;
      strArray[8] = "] ";
      strArray[9] = message;
      string.Concat(strArray);
    }
    */

    protected override void LoadContent()
    {
      ContentLoadingWrapper.contentManager = this.Content;
      this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
      Game1.arialSpriteFont = ContentLoadingWrapper.Load<SpriteFont>("Arial");
      Game1.arial23SpriteFont = ContentLoadingWrapper.Load<SpriteFont>("Arial23");
           
      //ThreadPool.QueueUserWorkItem(new WaitCallback(this.LoadAllContent));
      this.LoadAllContent(default);
    }

    private void LoadAllContent(object stateInfo)
    {
      System.Diagnostics.Debug.WriteLine("[i] Starting asset loading (LoadAllContent)");
      this.ressourceLoadingBackground720 = ContentLoadingWrapper.Load<Texture2D>("startup");
      
      GameSettings gs = SaveHandler.LoadSettings();

      LocalizationManager.Init();

      LocalizationManager.SetLanguage(LocalizationManager.Languages.First<Language>(
          (Func<Language, bool>) (p => p.LanguageCode == gs.languageCode/*"en_US"*/)));

      Game1.rouliXLSpriteFont = ContentLoadingWrapper.Load<SpriteFont>("RouliXL");
      Game1.rouliLSpriteFont = ContentLoadingWrapper.Load<SpriteFont>("Rouli");
      Game1.rouliMSpriteFont = ContentLoadingWrapper.Load<SpriteFont>("RouliMedium");
      Game1.rouliSSpriteFont = ContentLoadingWrapper.Load<SpriteFont>("RouliSmaller");

      this.loadingFeatherSprite = new Sprite("loading_feather",
          ContentLoadingWrapper.Load<Texture2D>("loading_feather"))
      {
        autoUpdate = false,
        animated = true,
        Width = 170,
        height = 138,
        MillisecondsPerFrame = 65
      };

      Game1.startupLogoSoundEffect = ContentLoadingWrapper.Load<SoundEffect>("soundeffects/logo");
      Game1.dodoteamlogo = ContentLoadingWrapper.Load<Texture2D>("dodoteam_black_small");
      Game1.monogamelogo = ContentLoadingWrapper.Load<Texture2D>("MonogameLogo");
      Game1.fmodlogo = ContentLoadingWrapper.Load<Texture2D>("FMODLogo");
      
      //TODO
      //Sound.InitSound(new List<SoundEffect>()
      //{
      //  ContentLoadingWrapper.Load<SoundEffect>("wavebge"),
      //  ContentLoadingWrapper.Load<SoundEffect>("soundeffects/volcano"),
      //  ContentLoadingWrapper.Load<SoundEffect>("soundeffects/cascade")
      //}, this);
      //Sound.InitEvents(this);

      TerrainBackground background = new TerrainBackground();
      TerrainBackground texture1 = new TerrainBackground();
      Game1.commonSprites = new List<Sprite>();
      Game1.waves = new List<IBackgroundEffect>();
      Game1.foregroundEffectList = new List<IForegroundEffect>();
      this.itemTextures = new Texture2D[18]
      {
        ContentLoadingWrapper.Load<Texture2D>("items/0"),
        ContentLoadingWrapper.Load<Texture2D>("items/1"),
        ContentLoadingWrapper.Load<Texture2D>("items/2"),
        ContentLoadingWrapper.Load<Texture2D>("items/3"),
        ContentLoadingWrapper.Load<Texture2D>("items/4"),
        ContentLoadingWrapper.Load<Texture2D>("items/5"),
        ContentLoadingWrapper.Load<Texture2D>("items/6"),
        ContentLoadingWrapper.Load<Texture2D>("items/7"),
        ContentLoadingWrapper.Load<Texture2D>("items/8"),
        ContentLoadingWrapper.Load<Texture2D>("items/9"),
        ContentLoadingWrapper.Load<Texture2D>("items/10"),
        ContentLoadingWrapper.Load<Texture2D>("items/11"),
        ContentLoadingWrapper.Load<Texture2D>("items/12"),
        ContentLoadingWrapper.Load<Texture2D>("items/13"),
        ContentLoadingWrapper.Load<Texture2D>("items/14"),
        ContentLoadingWrapper.Load<Texture2D>("items/15"),
        ContentLoadingWrapper.Load<Texture2D>("items/16"),
        ContentLoadingWrapper.Load<Texture2D>("items/17")
      };
      Game1.smallItemTextures = new Texture2D[18]
      {
        ContentLoadingWrapper.Load<Texture2D>("smallitems/0"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/1"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/2"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/3"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/4"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/5"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/6"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/7"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/8"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/9"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/10"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/11"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/12"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/13"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/14"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/15"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/16"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/17")
      };
      this.miniFlowersTextures = new Texture2D[13]
      {
        ContentLoadingWrapper.Load<Texture2D>("smallitems/81"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/82"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/83"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/84"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/85"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/86"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/87"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/88"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/89"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/90"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/91"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/92"),
        ContentLoadingWrapper.Load<Texture2D>("smallitems/93")
      };
      Game1.staticMiniFlowersTextures = this.miniFlowersTextures;
      Game1.wavesTextures = new Texture2D[4]
      {
        ContentLoadingWrapper.Load<Texture2D>("vague0"),
        ContentLoadingWrapper.Load<Texture2D>("vague1"),
        ContentLoadingWrapper.Load<Texture2D>("vague2"),
        ContentLoadingWrapper.Load<Texture2D>("vague3")
      };
      Game1.windSprites = new Sprite[4]
      {
        new Sprite("animated wind", ContentLoadingWrapper.Load<Texture2D>("animatedwind1"))
        {
          animated = true,
          height = 60,
          MillisecondsPerFrame = 45,
          Width = 300,
          horizontalMirroring = true,
          autoUpdate = false,
          loopAnimation = false
        },
        new Sprite("animated wind 2", ContentLoadingWrapper.Load<Texture2D>("animatedwind2"))
        {
          animated = true,
          height = 60,
          MillisecondsPerFrame = 40,
          Width = 300,
          horizontalMirroring = true,
          autoUpdate = false,
          loopAnimation = false
        },
        new Sprite("animated wind rev", ContentLoadingWrapper.Load<Texture2D>("animatedwind1rev"))
        {
          animated = true,
          height = 60,
          MillisecondsPerFrame = 45,
          Width = 300,
          horizontalMirroring = true,
          autoUpdate = false,
          loopAnimation = false
        },
        new Sprite("animated wind 2 rev", ContentLoadingWrapper.Load<Texture2D>("animatedwind2rev"))
        {
          animated = true,
          height = 60,
          MillisecondsPerFrame = 40,
          Width = 300,
          horizontalMirroring = true,
          autoUpdate = false,
          loopAnimation = false
        }
      };
      BirdShadowManager.sprite = new Sprite("seagull", ContentLoadingWrapper.Load<Texture2D>("seagull"))
      {
        animated = true,
        Width = 40,
        MillisecondsPerFrame = 110,
        autoUpdate = false
      };
      BirdShadowManager.BirdShadowList = new List<BirdShadow>();
      ButterflyManager.sprite = new Sprite("butterfly", 
          ContentLoadingWrapper.Load<Texture2D>("beurrevole"))
      {
        animated = true,
        Width = 38,
        MillisecondsPerFrame = 90,
        autoUpdate = false
      };
      ButterflyManager.butterflyList = new List<Butterfly>();
      System.Diagnostics.Debug.WriteLine("[i] Loading all textures...");
      this.allTextures = new List<Texture2D>();
      List<Texture2D> texture2DList = new List<Texture2D>();

      foreach (string texture2 in TextureList.textureList)
      {
        Texture2D texture2D = ContentLoadingWrapper.Load<Texture2D>(texture2);
        this.allTextures.Add(texture2D);
        texture2DList.Add(texture2D);
      }

      System.Diagnostics.Debug.WriteLine("[i] Loading background tiles...");
      string[] strArray = new string[35]
      {
        "Z1", "Z2", "Z3", "Z4",
        "Z5", "Z6", "Z7", "A1",
        "A2", "A3", "A4", "A5",
        "A6", "A7", "B1", "B2",
        "B3", "B4", "B5", "B6",
        "B7", "C1", "C2", "C3",
        "C4", "C5", "C6", "C7",
        "D1", "D2", "D3", "D4",
        "D5", "D6", "D7"
      };
      string[] source = new string[4]
      {
        "B3",
        "B4",
        "C3",
        "C4"
      };
      foreach (string str in strArray)
      {
        int y = 0;
        if (str.StartsWith("Z"))
          y = 0;
        if (str.StartsWith("A"))
          y = 3000;
        if (str.StartsWith("B"))
          y = 6000;
        if (str.StartsWith("C"))
          y = 9000;
        if (str.StartsWith("D"))
          y = 12000;
        int x = (Convert.ToInt32(Convert.ToString(str[1])) - 1) * 3000;
        TerrainBackgroundPart terrainBackgroundPart1;
        if (((IEnumerable<string>) source).Contains<string>(str))
        {
          Texture2D[] texture2DArray = new Texture2D[4]
          {
            ContentLoadingWrapper.Load<Texture2D>("tiles/" + str),
            ContentLoadingWrapper.Load<Texture2D>("tiles/" + str + "_1"),
            ContentLoadingWrapper.Load<Texture2D>("tiles/" + str + "_2"),
            ContentLoadingWrapper.Load<Texture2D>("tiles/" + str + "_3")
          };
          terrainBackgroundPart1 = new TerrainBackgroundPart(texture2DArray, 
              new Vector2((float) x, (float) y));
          texture2DList.AddRange((IEnumerable<Texture2D>) texture2DArray);
        }
        else
        {
          Texture2D texture2D = ContentLoadingWrapper.Load<Texture2D>("tiles/" + str);
          terrainBackgroundPart1 = new TerrainBackgroundPart(new Texture2D[1]
          {
            texture2D
          }, new Vector2((float) x, (float) y));
          texture2DList.Add(texture2D);
        }
        Recorder.resources = texture2DList;
        TerrainBackgroundPart terrainBackgroundPart2 = new TerrainBackgroundPart(new Texture2D[1]
        {
          ContentLoadingWrapper.Load<Texture2D>("behaviortiles/" + str)
        }, new Vector2((float) x, (float) y));
        Recorder.resources.Add(ContentLoadingWrapper.Load<Texture2D>("tiles/" + str));
        background.partList.Add(terrainBackgroundPart1);
        texture1.partList.Add(terrainBackgroundPart2);
      }//foreach


      //RnD
      //Game1.world = new World(background)
      //{
      //    name = "mainworld",
      //    objects = new List<IWorldObject>(),
      //    behaviorMap = new TerrainBehaviorMap(texture1),
      //    background = background // !
      //};
      
            
#region NPC_deals
     Game1.buildBoxSprite = new Sprite("buildbox2",
          ContentLoadingWrapper.Load<Texture2D>("ui/buildbox2"))
      {
        animated = true,
        Width = 363,
        MillisecondsPerFrame = 12,
        loopAnimation = false
      };

      Game1.buildBoxPlusSprite = new Sprite("buildbox2+",
          ContentLoadingWrapper.Load<Texture2D>("ui/buildbox2+"))
      {
        animated = true,
        Width = 507,
        MillisecondsPerFrame = 12,
        loopAnimation = false
      };

      Game1.buildBox3Sprite = new Sprite("buildbox3", 
          ContentLoadingWrapper.Load<Texture2D>("ui/buildbox3"))
      {
        animated = true,
        Width = 363,
        MillisecondsPerFrame = 12,
        loopAnimation = false
      };

      Game1.buildBox3PlusSprite = new Sprite("buildbox3+", 
          ContentLoadingWrapper.Load<Texture2D>("ui/buildbox3+"))
      {
        animated = true,
        Width = 507,
        MillisecondsPerFrame = 12,
        loopAnimation = false
      };

      this.presetList = PresetGenerator.GeneratePresets();
     
      Game1.buildPointSprite = new Sprite("buildpoint1", 
          ContentLoadingWrapper.Load<Texture2D>("ui/buildpoint1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("ombrebuild"),
        new Vector2(2f, 58f), opacity: 0.4f)
      });
      
      Game1.itemsok = ContentLoadingWrapper.Load<Texture2D>("ui/itemsok");
      Game1.itemsnok = ContentLoadingWrapper.Load<Texture2D>("ui/itemsnok");

      this.dodoSprite = new Sprite("dodo/walk_idle2", 
          ContentLoadingWrapper.Load<Texture2D>("dodo/walk_idle2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"),
        new Vector2(25f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        MillisecondsPerFrame = 120,
        Width = 120,
        height = 110,
        autoUpdate = false
      };
      this.dodoSpriteMoving = new Sprite("dodo/walk_moving_new2",
          ContentLoadingWrapper.Load<Texture2D>("dodo/walk_moving_new2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"),
        new Vector2(25f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        MillisecondsPerFrame = 50,
        Width = 120,
        height = 110,
        autoUpdate = false
      };
      this.dodoTakeNotes = new Sprite("dodo/takenotes", 
          ContentLoadingWrapper.Load<Texture2D>("dodo/takenotes"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"),
        new Vector2(25f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        MillisecondsPerFrame = 100,
        Width = 120,
        height = 110,
        autoUpdate = false
      };
      this.dodoSpriteSwimIdle = new Sprite("dodo/new_swim_idle", 
          ContentLoadingWrapper.Load<Texture2D>("dodo/new_swim_idle"))
      {
        animated = true,
        Width = 120,
        height = 102,
        MillisecondsPerFrame = 120,
        autoUpdate = false
      };
      this.dodoSpriteSwimPulse = new Sprite("dodo/swim_pulse2", 
          ContentLoadingWrapper.Load<Texture2D>("dodo/swim_pulse2"))
      {
        animated = true,
        Width = 120,
        MillisecondsPerFrame = 100,
        loopAnimation = false,
        autoUpdate = false
      };
      this.dodoSpriteSwimSink = new Sprite("dodo/sink", 
          ContentLoadingWrapper.Load<Texture2D>("dodo/sink"))
      {
        animated = true,
        Width = 280,
        height = 122,
        MillisecondsPerFrame = 100,
        loopAnimation = false,
        autoUpdate = false
      };
      
      this.dodoWalkToBikeSprite = new Sprite("dodo/walktobike", 
          ContentLoadingWrapper.Load<Texture2D>("dodo/walktobike"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo/walktobike_shadow"),
        new Vector2(0.0f, 267f), opacity: 0.5f)
        {
          renderOnCommonShadowBatch = false,
          animated = true,
          autoUpdate = false,
          MillisecondsPerFrame = 80,
          width = 296,
          height = 26
        }
      })
      {
        animated = true,
        MillisecondsPerFrame = 80,
        Width = 296,
        height = 281,
        autoUpdate = true,
        loopAnimation = false
      };
      this.dodoBikeSprite = new Sprite("dodo/bike/bikeA", 
          ContentLoadingWrapper.Load<Texture2D>("dodo/bike/bikeA"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo/bike/bikeshadow"), 
        new Vector2(5f, 189f), opacity: 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        autoUpdate = false,
        animated = true,
        MillisecondsPerFrame = 80,
        Width = 193,
        height = 210
      };
      this.dodoBikeInWaterSprite = new Sprite("dodo/bike/bikeA_inwater",
          ContentLoadingWrapper.Load<Texture2D>("dodo/bike/bikeA_inwater"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo/bike/bikeshadow"),
        new Vector2(5f, 189f), opacity: 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        autoUpdate = false,
        animated = true,
        MillisecondsPerFrame = 80,
        Width = 193,
        height = 210
      };
      this.dodoBikeBSprite = new Sprite("dodo/bike/bikeB", 
          ContentLoadingWrapper.Load<Texture2D>("dodo/bike/bikeB"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo/bike/bikeshadow"),
        new Vector2(5f, 189f), opacity: 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        MillisecondsPerFrame = 80,
        Width = 193,
        height = 210,
        autoUpdate = false
      };
      this.dodoBikeInWaterBSprite = new Sprite("dodo/bike/bikeB_inwaterb",
          ContentLoadingWrapper.Load<Texture2D>("dodo/bike/bikeB_inwater"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo/bike/bikeshadow"),
        new Vector2(5f, 189f), opacity: 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        autoUpdate = false,
        animated = true,
        MillisecondsPerFrame = 80,
        Width = 193,
        height = 210
      };
      this.dodoWalkToBicycleSprite = new Sprite("dodo/intobicycle", 
          ContentLoadingWrapper.Load<Texture2D>("dodo/intobicycle"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo/intobicycle_shadow"),
        new Vector2(0.0f, 172f), opacity: 0.5f)
        {
          renderOnCommonShadowBatch = false,
          animated = true,
          autoUpdate = false,
          MillisecondsPerFrame = 75,
          width = 210,
          height = 29
        }
      })
      {
        animated = true,
        MillisecondsPerFrame = 75,
        Width = 210,
        height = 208,
        autoUpdate = true,
        loopAnimation = false
      };
      this.dodoBicycle1Sprite = new Sprite("dodo/bicycle1", 
          ContentLoadingWrapper.Load<Texture2D>("dodo/bicycle1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo/bicycle_shadow"),
        new Vector2(0.0f, 124f), opacity: 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        MillisecondsPerFrame = 80,
        Width = 193,
        height = 137,
        loopAnimation = false,
        autoUpdate = false
      };
      this.dodoBicycle2Sprite = new Sprite("dodo/bicycle2", 
          ContentLoadingWrapper.Load<Texture2D>("dodo/bicycle2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo/bicycle_shadow"), 
        new Vector2(0.0f, 124f), opacity: 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        MillisecondsPerFrame = 60,
        Width = 193,
        height = 137,
        loopAnimation = false,
        autoUpdate = false
      };
      this.dodoBicycle3Sprite = new Sprite("dodo/bicycle3new",
          ContentLoadingWrapper.Load<Texture2D>("dodo/bicycle3new"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo/bicycle_shadow"),
        new Vector2(0.0f, 124f), opacity: 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        MillisecondsPerFrame = 40,
        Width = 193,
        height = 137,
        loopAnimation = true,
        autoUpdate = false
      };
      this.dodoTakeSprite = new Sprite("dodo/get",
          ContentLoadingWrapper.Load<Texture2D>("dodo/get"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo/get_shadow"), 
        new Vector2(0.0f, 124f), opacity: 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        MillisecondsPerFrame = 100,
        Width = 204,
        loopAnimation = false,
        autoUpdate = false
      };
      this.dodoSpriteBuilding = new Sprite("dodo/build", 
          ContentLoadingWrapper.Load<Texture2D>("dodo/build"))
      {
        animated = true,
        MillisecondsPerFrame = 90,
        Width = 250,
        autoUpdate = false
      };
      this.buildingCloudSprite = new Sprite("buildnuage", 
          ContentLoadingWrapper.Load<Texture2D>("buildnuage"))
      {
        animated = true,
        MillisecondsPerFrame = 100,
        Width = 180,
        autoUpdate = false
      };
      this.preBuildingCloudSprite = new Sprite("prebuildnuage2",
          ContentLoadingWrapper.Load<Texture2D>("prebuildnuage2"))
      {
        animated = true,
        MillisecondsPerFrame = 100,
        Width = 180
      };
      this.dodoSpriteHarvesting = new Sprite("dodo/harvest",
          ContentLoadingWrapper.Load<Texture2D>("dodo/harvest"))
      {
        animated = true,
        Width = 300,
        MillisecondsPerFrame = 60,
        autoUpdate = false
      };

      this.harvestCloudSprite = new Sprite("harvestcloud", 
          ContentLoadingWrapper.Load<Texture2D>("harvestcloud"))
      {
        animated = true,
        Width = 350,
        MillisecondsPerFrame = 85,
        autoUpdate = false
      };
      this.dodoWakingUp = new Sprite("dodo/waking",
          ContentLoadingWrapper.Load<Texture2D>("dodo/waking_up_v3_120"))
      {
        animated = true,
        Width = 120,
        MillisecondsPerFrame = 130,
        loopAnimation = false
      };
      this.dodoLaying = new Sprite("dodo/laying", 
          ContentLoadingWrapper.Load<Texture2D>("dodo/laying"))
      {
        animated = false
      };
      this.drowningIcons = new Sprite[4]
      {
        new Sprite("drowningIcon3", ContentLoadingWrapper.Load<Texture2D>("ui/jauge3"))
        {
          animated = true,
          Width = 46,
          MillisecondsPerFrame = 20,
          loopAnimation = false
        },
        new Sprite("drowningIcon2", ContentLoadingWrapper.Load<Texture2D>("ui/jauge2"))
        {
          animated = true,
          Width = 46,
          MillisecondsPerFrame = 20,
          loopAnimation = false
        },
        new Sprite("drowningIcon1", ContentLoadingWrapper.Load<Texture2D>("ui/jauge1"))
        {
          animated = true,
          Width = 46,
          MillisecondsPerFrame = 20,
          loopAnimation = false
        },
        new Sprite("drowningIcon0", ContentLoadingWrapper.Load<Texture2D>("ui/jauge0"))
        {
          animated = true,
          Width = 46,
          MillisecondsPerFrame = 20,
          loopAnimation = false
        }
      };
      this.timebar = new Sprite("ui/timebar", ContentLoadingWrapper.Load<Texture2D>("ui/timebar"))
      {
        animated = true,
        Width = 27,
        height = 101,
        MillisecondsPerFrame = 10000000,
        loopAnimation = false
      };
      this.harvestShadows = new Sprite[2]
      {
        new Sprite("dodo/harvestshadow1", ContentLoadingWrapper.Load<Texture2D>("dodo/harvestshadow1")),
        new Sprite("dodo/harvestshadow3", ContentLoadingWrapper.Load<Texture2D>("dodo/harvestshadow3"))
      };
      this.buildShadows = new Sprite[3]
      {
        new Sprite("dodo/buildshadow1", ContentLoadingWrapper.Load<Texture2D>("dodo/buildshadow1")),
        new Sprite("dodo/buildshadow2", ContentLoadingWrapper.Load<Texture2D>("dodo/buildshadow2")),
        new Sprite("dodo/buildshadow3", ContentLoadingWrapper.Load<Texture2D>("dodo/buildshadow3"))
      };
      this.AidleSprite = new Sprite("npc/Aidle", ContentLoadingWrapper.Load<Texture2D>("npc/Aidle"),
          new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"), new Vector2(15f, 101f),
        new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 120,
        MillisecondsPerFrame = 300
      };
      this.BabyIdleSprite = new Sprite("npc/BabyIdle", 
          ContentLoadingWrapper.Load<Texture2D>("npc/BabyIdle"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("npc/BabyShadow"),
        new Vector2(0.0f, 28f), new Vector2?(new Vector2(0.0f, 28f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 55,
        MillisecondsPerFrame = 320
      };
      this.BabyWalkSprite = new Sprite("npc/BabyWalk", 
          ContentLoadingWrapper.Load<Texture2D>("npc/BabyWalk"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("npc/BabyShadow"),
        new Vector2(0.0f, 28f), new Vector2?(new Vector2(0.0f, 28f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 55,
        MillisecondsPerFrame = 150
      };
      this.AwalkSprite = new Sprite("npc/Arun", 
          ContentLoadingWrapper.Load<Texture2D>("npc/Arun"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow")
        , new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 120,
        MillisecondsPerFrame = 115
      };
      this.AtosleepSprite = new Sprite("npc/Atosleep", 
          ContentLoadingWrapper.Load<Texture2D>("npc/Atosleep"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"),
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 120,
        MillisecondsPerFrame = 90,
        loopAnimation = false
      };
      this.AsleepSprite = new Sprite("npc/Asleep", 
          ContentLoadingWrapper.Load<Texture2D>("npc/Asleep"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"),
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 120,
        MillisecondsPerFrame = 410,
        loopAnimation = true
      };
      this.AwakeSprite = this.AsleepSprite;
      this.AwakeSprite.backwardAnimation = true;
      this.BidleSprite = new Sprite("npc/Bidle",
          ContentLoadingWrapper.Load<Texture2D>("npc/Bidle"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"), 
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 120,
        MillisecondsPerFrame = 300
      };
      this.BwalkSprite = new Sprite("npc/Brun", 
          ContentLoadingWrapper.Load<Texture2D>("npc/Brun"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"), 
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 120,
        MillisecondsPerFrame = 115
      };
      this.BtosleepSprite = new Sprite("npc/Btosleep", 
          ContentLoadingWrapper.Load<Texture2D>("npc/Btosleep"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"),
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 165,
        height = 120,
        MillisecondsPerFrame = 105,
        loopAnimation = false
      };

      this.BtosleepSprite = new Sprite("npc/Bsleep", 
          ContentLoadingWrapper.Load<Texture2D>("npc/Bsleep"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"), 
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 165,
        height = 120,
        MillisecondsPerFrame = 300
      };
      this.BwakeSprite = new Sprite("npc/Bwake", 
          ContentLoadingWrapper.Load<Texture2D>("npc/Bwake"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"), 
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 165,
        height = 120,
        MillisecondsPerFrame = 105,
        loopAnimation = false
      };
      this.CidleSprite = new Sprite("npc/Cidle",
          ContentLoadingWrapper.Load<Texture2D>("npc/Cidle"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"), 
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 110,
        MillisecondsPerFrame = 300
      };

      this.CwalkSprite = new Sprite("npc/Crun", 
          ContentLoadingWrapper.Load<Texture2D>("npc/Crun"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"),
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 110,
        MillisecondsPerFrame = 100
      };

      this.CtosleepSprite = new Sprite("npc/Ctosleep",
          ContentLoadingWrapper.Load<Texture2D>("npc/Ctosleep"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"), 
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 110,
        MillisecondsPerFrame = 95,
        loopAnimation = false
      };

      this.CsleepSprite = new Sprite("npc/Csleep",
          ContentLoadingWrapper.Load<Texture2D>("npc/Csleep"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"),
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 110,
        MillisecondsPerFrame = 350,
        loopAnimation = true
      };

      this.CwakeSprite = this.CsleepSprite;
      this.CwakeSprite.backwardAnimation = true;
      this.DidleSprite = new Sprite("npc/Didle", 
          ContentLoadingWrapper.Load<Texture2D>("npc/Didle"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"),
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 120,
        MillisecondsPerFrame = 350
      };
      this.DwalkSprite = new Sprite("npc/Drun",
          ContentLoadingWrapper.Load<Texture2D>("npc/Drun"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"), 
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 120,
        MillisecondsPerFrame = 130
      };
      this.EidleSprite = new Sprite("npc/Eidle",
          ContentLoadingWrapper.Load<Texture2D>("npc/Eidle"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"),
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 110,
        MillisecondsPerFrame = 300
      };
      this.EwalkSprite = new Sprite("npc/Ewalk",
          ContentLoadingWrapper.Load<Texture2D>("npc/Ewalk"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"),
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 110,
        MillisecondsPerFrame = 100
      };
      this.EtosleepSprite = new Sprite("npc/Etosleep",
          ContentLoadingWrapper.Load<Texture2D>("npc/Etosleep"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"), 
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 110,
        MillisecondsPerFrame = 95,
        loopAnimation = false
      };
      this.EsleepSprite = new Sprite("npc/Esleep",
          ContentLoadingWrapper.Load<Texture2D>("npc/Esleep"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"),
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 52,
        MillisecondsPerFrame = 350,
        loopAnimation = true
      };
      this.ShidleSprite = new Sprite("npc/Shidle",
          ContentLoadingWrapper.Load<Texture2D>("npc/Shidle"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"),
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 120,
        MillisecondsPerFrame = 300
      };
      this.ShwalkSprite = new Sprite("npc/Shrun",
          ContentLoadingWrapper.Load<Texture2D>("npc/Shrun"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"),
        new Vector2(15f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        Width = 110,
        height = 120,
        MillisecondsPerFrame = 100
      };
      Game1.debugCursor = ContentLoadingWrapper.Load<Texture2D>("debugcursor");
      Game1.debugCursor2 = ContentLoadingWrapper.Load<Texture2D>("debugcursor2");

      DebugAssistant.debugWindArrow = ContentLoadingWrapper.Load<Texture2D>("ui/windarrow");
      
      Game1.redline = ContentLoadingWrapper.Load<Texture2D>("bline");
      BuildBox.requirementIconList = new Texture2D[5]
      {
        ContentLoadingWrapper.Load<Texture2D>("ui/boardlevel2"),
        ContentLoadingWrapper.Load<Texture2D>("ui/boardlevel3"),
        ContentLoadingWrapper.Load<Texture2D>("ui/eau_courante"),
        ContentLoadingWrapper.Load<Texture2D>("ui/finirautres"),
        ContentLoadingWrapper.Load<Texture2D>("ui/shibananas_icon")
      };
      BuildBox.separator = ContentLoadingWrapper.Load<Texture2D>("bbSeparator");
            #endregion




#region Waves
   // * WAVES *
    Game1.waves = new List<IBackgroundEffect>();
    Game1.waves.Add((IBackgroundEffect) new Wave(new Vector2(3020f, 4950f), 150, 90.0));
    foreach (Tuple<Vector2, float> tuple in new List<Tuple<Vector2, float>>()
      {
        new Tuple<Vector2, float>(new Vector2(2786f, 4950f), 107.76f),
        new Tuple<Vector2, float>(new Vector2(3536f, 4269f), 149.59f),
        new Tuple<Vector2, float>(new Vector2(2660f, 5331f), 92.29f),
        new Tuple<Vector2, float>(new Vector2(2633f, 5724f), 79.11f),
        new Tuple<Vector2, float>(new Vector2(2705f, 6099f), 69.37f),
        new Tuple<Vector2, float>(new Vector2(2843f, 6444f), 62.5f),
        new Tuple<Vector2, float>(new Vector2(3020f, 6771f), 64.79f),
        new Tuple<Vector2, float>(new Vector2(3182f, 7116f), 57.34f),
        new Tuple<Vector2, float>(new Vector2(3374f, 7437f), 51.61f),
        new Tuple<Vector2, float>(new Vector2(3608f, 7737f), 47.6f),
        new Tuple<Vector2, float>(new Vector2(3875f, 8022f), 39.58f),
        new Tuple<Vector2, float>(new Vector2(4169f, 8265f), 32.7f),
        new Tuple<Vector2, float>(new Vector2(4487f, 8466f), 30.99f),
        new Tuple<Vector2, float>(new Vector2(4805f, 8643f), 35f),
        new Tuple<Vector2, float>(new Vector2(5114f, 8856f), 35.57f),
        new Tuple<Vector2, float>(new Vector2(5396f, 9078f), 40.15f),
        new Tuple<Vector2, float>(new Vector2(5675f, 9318f), 42.44f),
        new Tuple<Vector2, float>(new Vector2(5948f, 9567f), 47.6f),
        new Tuple<Vector2, float>(new Vector2(6203f, 9840f), 47.6f),
        new Tuple<Vector2, float>(new Vector2(6437f, 10071f), 67.65f),
        new Tuple<Vector2, float>(new Vector2(6542f, 10368f), 98.02f),
        new Tuple<Vector2, float>(new Vector2(6500f, 10806f), 40.15f),
        new Tuple<Vector2, float>(new Vector2(6827f, 11052f), 5.78f),
        new Tuple<Vector2, float>(new Vector2(7205f, 11100f), 4.06f),
        new Tuple<Vector2, float>(new Vector2(7577f, 11127f), 5.78f),
        new Tuple<Vector2, float>(new Vector2(7946f, 11163f), 5.78f),
        new Tuple<Vector2, float>(new Vector2(8312f, 11202f), 5.78f),
        new Tuple<Vector2, float>(new Vector2(8681f, 11238f), 5.78f),
        new Tuple<Vector2, float>(new Vector2(9065f, 11280f), 1.15f),
        new Tuple<Vector2, float>(new Vector2(9437f, 11298f), 0.0f),
        new Tuple<Vector2, float>(new Vector2(9824f, 11295f), 354.66f),
        new Tuple<Vector2, float>(new Vector2(10205f, 11259f), 348.36f),
        new Tuple<Vector2, float>(new Vector2(10577f, 11181f), 345.49f),
        new Tuple<Vector2, float>(new Vector2(10940f, 11079f), 343.77f),
        new Tuple<Vector2, float>(new Vector2(11300f, 10968f), 339.76f),
        new Tuple<Vector2, float>(new Vector2(11663f, 10845f), 334.03f),
        new Tuple<Vector2, float>(new Vector2(11999f, 10689f), 334.61f),
        new Tuple<Vector2, float>(new Vector2(12320f, 10533f), 341.48f),
        new Tuple<Vector2, float>(new Vector2(12674f, 10422f), 340.34f),
        new Tuple<Vector2, float>(new Vector2(13016f, 10296f), 346.64f),
        new Tuple<Vector2, float>(new Vector2(13379f, 10212f), 348.36f),
        new Tuple<Vector2, float>(new Vector2(13745f, 10143f), 346.64f),
        new Tuple<Vector2, float>(new Vector2(14120f, 10065f), 340.91f),
        new Tuple<Vector2, float>(new Vector2(14498f, 9936f), 325.44f),
        new Tuple<Vector2, float>(new Vector2(14747f, 9744f), 356.38f),
        new Tuple<Vector2, float>(new Vector2(15131f, 9720f), 346.07f),
        new Tuple<Vector2, float>(new Vector2(15503f, 9624f), 337.47f),
        new Tuple<Vector2, float>(new Vector2(15875f, 9471f), 317.99f),
        new Tuple<Vector2, float>(new Vector2(16163f, 9207f), 299.08f),
        new Tuple<Vector2, float>(new Vector2(16355f, 8865f), 288.2f),
        new Tuple<Vector2, float>(new Vector2(16490f, 8505f), 280.18f),
        new Tuple<Vector2, float>(new Vector2(16568f, 8139f), 276.74f),
        new Tuple<Vector2, float>(new Vector2(16619f, 7764f), 271.58f),
        new Tuple<Vector2, float>(new Vector2(16643f, 7395f), 264.71f),
        new Tuple<Vector2, float>(new Vector2(16613f, 7020f), 258.4f),
        new Tuple<Vector2, float>(new Vector2(16547f, 6645f), 255.54f),
        new Tuple<Vector2, float>(new Vector2(16454f, 6273f), 251.53f),
        new Tuple<Vector2, float>(new Vector2(16340f, 5907f), 240.07f),
        new Tuple<Vector2, float>(new Vector2(16142f, 5577f), 233.77f),
        new Tuple<Vector2, float>(new Vector2(15908f, 5274f), 228.61f),
        new Tuple<Vector2, float>(new Vector2(15650f, 4986f), 221.73f),
        new Tuple<Vector2, float>(new Vector2(15368f, 4731f), 220.59f),
        new Tuple<Vector2, float>(new Vector2(15080f, 4488f), 215.43f),
        new Tuple<Vector2, float>(new Vector2(14771f, 4260f), 206.26f),
        new Tuple<Vector2, float>(new Vector2(14420f, 4095f), 196.52f),
        new Tuple<Vector2, float>(new Vector2(14045f, 3987f), 185.07f),
        new Tuple<Vector2, float>(new Vector2(13670f, 3948f), 181.05f),
        new Tuple<Vector2, float>(new Vector2(13286f, 3942f), 174.75f),
        new Tuple<Vector2, float>(new Vector2(12905f, 3978f), 170.17f),
        new Tuple<Vector2, float>(new Vector2(12533f, 4041f), 165.63f),
        new Tuple<Vector2, float>(new Vector2(12158f, 4149f), 151.31f),
        new Tuple<Vector2, float>(new Vector2(11846f, 4335f), 158.75f),
        new Tuple<Vector2, float>(new Vector2(11531f, 4464f), 178.81f),
        new Tuple<Vector2, float>(new Vector2(11165f, 4467f), 181.67f),
        new Tuple<Vector2, float>(new Vector2(10784f, 4452f), 173.65f),
        new Tuple<Vector2, float>(new Vector2(10412f, 4494f), 171.36f),
        new Tuple<Vector2, float>(new Vector2(10076f, 4554f), 187.4f),
        new Tuple<Vector2, float>(new Vector2(9698f, 4512f), 181.67f),
        new Tuple<Vector2, float>(new Vector2(9323f, 4497f), 181.1f),
        new Tuple<Vector2, float>(new Vector2(8957f, 4482f), 182.82f),
        new Tuple<Vector2, float>(new Vector2(8591f, 4470f), 185.68f),
        new Tuple<Vector2, float>(new Vector2(8228f, 4434f), 187.4f),
        new Tuple<Vector2, float>(new Vector2(7856f, 4380f), 186.83f),
        new Tuple<Vector2, float>(new Vector2(7493f, 4329f), 189.69f),
        new Tuple<Vector2, float>(new Vector2(7124f, 4266f), 187.98f),
        new Tuple<Vector2, float>(new Vector2(6755f, 4209f), 186.83f),
        new Tuple<Vector2, float>(new Vector2(6389f, 4161f), 185.11f),
        new Tuple<Vector2, float>(new Vector2(6011f, 4125f), 182.25f),
        new Tuple<Vector2, float>(new Vector2(5630f, 4104f), 178.81f),
        new Tuple<Vector2, float>(new Vector2(5264f, 4104f), 179.38f),
        new Tuple<Vector2, float>(new Vector2(4886f, 4107f), 174.8f),
        new Tuple<Vector2, float>(new Vector2(4508f, 4137f), 171.36f),
        new Tuple<Vector2, float>(new Vector2(4139f, 4185f), 171.36f),
        new Tuple<Vector2, float>(new Vector2(3005f, 4617f), 123.23f),
        new Tuple<Vector2, float>(new Vector2(3335f, 4386f), 145f),
        new Tuple<Vector2, float>(new Vector2(3755f, 4242f), 162.77f),
        new Tuple<Vector2, float>(new Vector2(3536f, 4269f), 149.59f),
        new Tuple<Vector2, float>(new Vector2(3293f, 11484f), 42.44f),
        new Tuple<Vector2, float>(new Vector2(3593f, 11745f), 23.54f),
        new Tuple<Vector2, float>(new Vector2(3959f, 11913f), 355.23f),
        new Tuple<Vector2, float>(new Vector2(4358f, 11886f), 337.47f),
        new Tuple<Vector2, float>(new Vector2(4718f, 11751f), 324.29f),
        new Tuple<Vector2, float>(new Vector2(5033f, 11538f), 316.85f),
        new Tuple<Vector2, float>(new Vector2(5327f, 11289f), 306.53f),
        new Tuple<Vector2, float>(new Vector2(3743f, 11394f), 183.35f),
        new Tuple<Vector2, float>(new Vector2(4115f, 11412f), 182.2f),
        new Tuple<Vector2, float>(new Vector2(4424f, 11298f), 159.28f),
        new Tuple<Vector2, float>(new Vector2(4565f, 11022f), 122.61f),
        new Tuple<Vector2, float>(new Vector2(4499f, 10728f), 81.93f),
        new Tuple<Vector2, float>(new Vector2(4217f, 10674f), 21.2f),
        new Tuple<Vector2, float>(new Vector2(3881f, 10704f), 358.67f),
        new Tuple<Vector2, float>(new Vector2(3653f, 10932f), 317.42f),
        new Tuple<Vector2, float>(new Vector2(3326f, 11142f), 328.88f),
        new Tuple<Vector2, float>(new Vector2(3362f, 10674f), 109.04f),
        new Tuple<Vector2, float>(new Vector2(3554f, 10335f), 120.5f),
        new Tuple<Vector2, float>(new Vector2(3788f, 10032f), 125.66f),
        new Tuple<Vector2, float>(new Vector2(4130f, 9819f), 149.72f),
        new Tuple<Vector2, float>(new Vector2(4535f, 9810f), 176.65f),
        new Tuple<Vector2, float>(new Vector2(4916f, 9879f), 191.55f),
        new Tuple<Vector2, float>(new Vector2(5270f, 10053f), 207.59f),
        new Tuple<Vector2, float>(new Vector2(5537f, 10362f), 228.22f),
        new Tuple<Vector2, float>(new Vector2(5648f, 10716f), 253.43f),
        new Tuple<Vector2, float>(new Vector2(5564f, 11037f), 283.22f),
        new Tuple<Vector2, float>(new Vector2(13121f, 11669f), 155.32f),
        new Tuple<Vector2, float>(new Vector2(13466f, 11516f), 156.46f),
        new Tuple<Vector2, float>(new Vector2(13826f, 11378f), 160.47f),
        new Tuple<Vector2, float>(new Vector2(14156f, 11219f), 154.74f),
        new Tuple<Vector2, float>(new Vector2(14501f, 11060f), 154.74f),
        new Tuple<Vector2, float>(new Vector2(14831f, 10886f), 151.31f),
        new Tuple<Vector2, float>(new Vector2(12767f, 11823f), 151.88f),
        new Tuple<Vector2, float>(new Vector2(12404f, 12018f), 122.09f),
        new Tuple<Vector2, float>(new Vector2(12197f, 12387f), 85.99f),
        new Tuple<Vector2, float>(new Vector2(12224f, 12792f), 67.65f),
        new Tuple<Vector2, float>(new Vector2(12374f, 13161f), 49.89f),
        new Tuple<Vector2, float>(new Vector2(12647f, 13473f), 22.96f),
        new Tuple<Vector2, float>(new Vector2(13022f, 13620f), 5.73f),
        new Tuple<Vector2, float>(new Vector2(13408f, 13654f), 360f),
        new Tuple<Vector2, float>(new Vector2(13786f, 13672f), 360f),
        new Tuple<Vector2, float>(new Vector2(14164f, 13663f), 360f),
        new Tuple<Vector2, float>(new Vector2(14545f, 13660f), 352.55f),
        new Tuple<Vector2, float>(new Vector2(14935f, 13612f), 339.37f),
        new Tuple<Vector2, float>(new Vector2(15298f, 13477f), 330.21f),
        new Tuple<Vector2, float>(new Vector2(15637f, 13282f), 320.47f),
        new Tuple<Vector2, float>(new Vector2(15106f, 10667f), 142.71f),
        new Tuple<Vector2, float>(new Vector2(15373f, 10412f), 136.98f),
        new Tuple<Vector2, float>(new Vector2(15589f, 10124f), 127.82f),
        new Tuple<Vector2, float>(new Vector2(15826f, 9827f), 132.97f),
        new Tuple<Vector2, float>(new Vector2(16222f, 9704f), 163.34f),
        new Tuple<Vector2, float>(new Vector2(16615f, 9710f), 179.95f),
        new Tuple<Vector2, float>(new Vector2(16984f, 9890f), 206.31f),
        new Tuple<Vector2, float>(new Vector2(17092f, 10316f), 259.02f),
        new Tuple<Vector2, float>(new Vector2(16975f, 10712f), 287.1f),
        new Tuple<Vector2, float>(new Vector2(16783f, 11051f), 299.13f),
        new Tuple<Vector2, float>(new Vector2(16618f, 11375f), 295.12f),
        new Tuple<Vector2, float>(new Vector2(16537f, 11720f), 284.81f),
        new Tuple<Vector2, float>(new Vector2(16435f, 12083f), 284.81f),
        new Tuple<Vector2, float>(new Vector2(16336f, 12443f), 285.38f),
        new Tuple<Vector2, float>(new Vector2(16162f, 12776f), 297.98f),
        new Tuple<Vector2, float>(new Vector2(15922f, 13067f), 310.59f)
      })
      
      Game1.waves.Add((IBackgroundEffect) new Wave(tuple.Item1, 150, (double) tuple.Item2));
#endregion

#region StoryIntroCutscene
        // * StoryIntroCutscene *

      StoryIntroCutscene.bg = ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/bg");
      StoryIntroCutscene.lum = ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/lum");
      StoryIntroCutscene.fire = new Sprite("cutscene/intro/fire",
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/fire"))
      {
        animated = true,
        Width = 100,
        MillisecondsPerFrame = 60
      };

      StoryIntroCutscene.dood1sleep = new Sprite("cutscene/intro/dood1SLEEP",
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/dood1SLEEP"))
      {
        animated = true,
        Width = 129,
        height = 129,
        MillisecondsPerFrame = 350
      };

      StoryIntroCutscene.dood1wake = new Sprite("cutscene/intro/dood1WAKE", 
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/dood1WAKE"))
      {
        animated = true,
        Width = 140,
        height = 129,
        MillisecondsPerFrame = 110,
        loopAnimation = false
      };

      StoryIntroCutscene.dood2sleep = new Sprite("cutscene/intro/dood2SLEEP",
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/dood2SLEEP"))
      {
        animated = true,
        Width = 149,
        height = 183,
        MillisecondsPerFrame = 350
      };

      StoryIntroCutscene.dood2_shadow = new Sprite("cutscene/intro/dood2SLEEP_shadow",
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/dood2SLEEP_shadow"))
      {
        animated = true,
        Width = 237,
        height = 93,
        MillisecondsPerFrame = 120
      };

      StoryIntroCutscene.dood2wake = new Sprite("cutscene/intro/dood2WAKE",
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/dood2WAKE"))
      {
        animated = true,
        Width = 141,
        height = 55,
        MillisecondsPerFrame = 75,
        loopAnimation = false
      };

      StoryIntroCutscene.dood3sleep = new Sprite("cutscene/intro/dood3SLEEP", 
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/dood3SLEEP"))
      {
        animated = true,
        Width = 133,
        height = 164,
        MillisecondsPerFrame = 350
      };

      StoryIntroCutscene.dood3_shadow = new Sprite("cutscene/intro/dood3SLEEP_shadow",
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/dood3SLEEP_shadow"))
      {
        animated = true,
        Width = 227,
        height = 122,
        MillisecondsPerFrame = 120
      };

      StoryIntroCutscene.dood3wake = new Sprite("cutscene/intro/dood3WAKE",
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/dood3WAKE"))
      {
        animated = true,
        Width = 133,
        height = 164,
        MillisecondsPerFrame = 80,
        loopAnimation = false
      };

      StoryIntroCutscene.dood4sleep = new Sprite("cutscene/intro/dood4SLEEP", 
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/dood4SLEEP"))
      {
        animated = true,
        Width = 125,
        height = 155,
        MillisecondsPerFrame = 350
      };

      StoryIntroCutscene.dood4wake = new Sprite("cutscene/intro/dood4WAKE",
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/dood4WAKE"))
      {
        animated = true,
        Width = 135,
        height = 155,
        MillisecondsPerFrame = 90,
        loopAnimation = false
      };

      StoryIntroCutscene.dood4_shadow = new Sprite("cutscene/intro/dood4SLEEP_shadow", 
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/dood4SLEEP_shadow"))
      {
        animated = true,
        Width = 246,
        height = 133,
        MillisecondsPerFrame = 120
      };

      StoryIntroCutscene.walk = new Sprite("dodo/walk_moving_new2",
          ContentLoadingWrapper.Load<Texture2D>("dodo/walk_moving_new2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("dodo_shadow"),
        new Vector2(25f, 101f), new Vector2?(new Vector2(25f, 101f)), 0.5f)
        {
          renderOnCommonShadowBatch = false
        }
      })
      {
        animated = true,
        MillisecondsPerFrame = 50,
        Width = 120,
        height = 110,
        horizontalMirroring = true
      };

      StoryIntroCutscene.objshadow1100 = new Sprite("cutscene/intro/objshadow1100", 
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/objshadow1100"))
      {
        animated = true,
        Width = 1100,
        MillisecondsPerFrame = 120
      };

      StoryIntroCutscene.shocked = new Sprite("cutscene/intro/shocked", 
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/shocked"))
      {
        animated = true,
        Width = 160,
        height = 120,
        MillisecondsPerFrame = 85,
        loopAnimation = false
      };

      StoryIntroCutscene.idle = new Sprite("cutscene/intro/walk_idle2",
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/walk_idle2"))
      {
        animated = true,
        Width = 120,
        height = 110,
        MillisecondsPerFrame = 80
      };

      StoryIntroCutscene.run = new Sprite("cutscene/intro/runnoeggs2", 
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/runnoeggs2"))
      {
        animated = true,
        Width = 140,
        height = 110,
        MillisecondsPerFrame = 45
      };
      StoryIntroCutscene.runeggs = new Sprite("cutscene/intro/runeggs2",
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/runeggs2"))
      {
        animated = true,
        Width = 140,
        height = 110,
        MillisecondsPerFrame = 45
      };
      StoryIntroCutscene.jumpeggs = new Sprite("cutscene/intro/jumpeggs",
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/jumpeggs"))
      {
        animated = true,
        Width = 140,
        height = 150,
        MillisecondsPerFrame = 70,
        loopAnimation = false
      };
      StoryIntroCutscene.runtransition = new Sprite("cutscene/intro/runtransition",
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/runtransition"))
      {
        animated = true,
        Width = 140,
        height = 110,
        MillisecondsPerFrame = 45,
        loopAnimation = false
      };
      StoryIntroCutscene.bato = new Sprite("cutscene/intro/batoanimated", 
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/batoanimated"))
      {
        animated = true,
        Width = 824,
        height = 666,
        MillisecondsPerFrame = 100,
        loopAnimation = false
      };
      StoryIntroCutscene.eggs = new Sprite("cutscene/intro/eggs", 
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/eggs"));

      StoryIntroCutscene.rado = new Sprite("cutscene/intro/rado", 
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/rado"));

      StoryIntroCutscene.badwavehead = new Sprite("cutscene/intro/badwavehead", 
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/badwavehead"))
      {
        animated = true,
        Width = 80,
        MillisecondsPerFrame = 80
      };
      StoryIntroCutscene.badwave = new Sprite("cutscene/intro/badwaveanimated", 
          ContentLoadingWrapper.Load<Texture2D>("cutscene/intro/badwaveanimated"))
      {
        animated = true,
        Width = 1280,
        height = 720,
        MillisecondsPerFrame = 80
      };
            #endregion

#region SoundSystem
      System.Diagnostics.Debug.WriteLine("[i] Loading sounds...");
      Sound.soundEffectList = new List<SoundEffect>()
      {
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/collision"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/splash"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/bruitagebuild5"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/inventory_opening"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/inventory_closing"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/escapemenu_opening"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/escapemenu_closing"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/escapemenu_selecting"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/inventory_selecting"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/harvesting"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/swimming_1"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/bb_opening"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/bb_closing"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/walking_sable1"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/walking_sable2"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/walking_sable3"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/walking_sable4"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/walking_grass1"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/walking_grass2"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/walking_grass3"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/walking_grass4"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/walking_roche1"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/walking_roche2"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/walking_roche3"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/walking_roche4"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/aqua_pulse1"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/moto"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/fanfare1"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/bato en bois"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/braises"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/cigales"),
        ContentLoadingWrapper.Load<SoundEffect>("bgm/StoryIntro"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/dolphin1"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/dolphin2"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/dolphin3"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/owl"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/seagull"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/midnighttune"),
        ContentLoadingWrapper.Load<SoundEffect>("soundeffects/walk_to_bike")
      };


      Sound.BGMs["Village"] = (IBGM) new LoopingBGM()
      {
        introPart = ContentLoadingWrapper.Load<Song>("bgm/village1_adaptive/VillageSong1-Start"),
        loopingParts = new Song[2]
        {
          ContentLoadingWrapper.Load<Song>("bgm/village1_adaptive/VillageSong1-Loop1"),
          ContentLoadingWrapper.Load<Song>("bgm/village1_adaptive/VillageSong1-Loop2")
        },
        outroPart = ContentLoadingWrapper.Load<Song>("bgm/village1_adaptive/VillageSong1-End")
      };
      Sound.BGMs["Daily1"] = (IBGM) new SimpleBGM()
      {
        mainPart = ContentLoadingWrapper.Load<Song>("bgm/Dodo_Day_theme_1")
      };
      Sound.BGMs["Daily2"] = (IBGM) new SimpleBGM()
      {
        mainPart = ContentLoadingWrapper.Load<Song>("bgm/Dodo_Day_theme_2")
      };
      Sound.BGMs["Daily3"] = (IBGM) new SimpleBGM()
      {
        mainPart = ContentLoadingWrapper.Load<Song>("bgm/Dodo_Day_theme_3")
      };
      Sound.BGMs["Daily4"] = (IBGM) new SimpleBGM()
      {
        mainPart = ContentLoadingWrapper.Load<Song>("bgm/Dodo_Day_theme_4")
      };
            #endregion

#region DoDo_Center
      Game1.dodoCenteredScreenLocation = new Vector2((float) ((int) Game1.renderSize.X / 2
          - this.dodoSprite.Width / 2), (float) ((int) Game1.renderSize.Y / 2 
          - this.dodoSprite.height / 2));

      Game1.dodoScreenLocation = new Vector2((float) ((int) Game1.renderSize.X / 2 
          - this.dodoSprite.Width / 2), (float) ((int) Game1.renderSize.Y / 2 
          - this.dodoSprite.height / 2));
#endregion

#region HUDs
      System.Diagnostics.Debug.WriteLine("[i] Initializing HUDs...");
      GUIManager.LoadAssets(this);

      this.blackbar = ContentLoadingWrapper.Load<Texture2D>("blackbar");
      this.savingTexture = ContentLoadingWrapper.Load<Texture2D>("ui/saving1");
      this.whiteBackground = ContentLoadingWrapper.Load<Texture2D>("white");
      Recorder.ghost = ContentLoadingWrapper.Load<Texture2D>("dodoghost");
      Recorder.debugFont = Game1.arialSpriteFont;
      Texture2DConverter.commonTextures = this.allTextures;
      Game1.pathfinder = new Pathfinder(Game1.world);

      GUIManager.ClearThenSet((IGUI) GUIManager.mainmenu);

      Game1.NPCs = new List<INPC>()
      {
        (INPC) new BlueDodo()
        {
          IdleSprite = this.AidleSprite,
          RunSprite = this.AwalkSprite
        },
        (INPC) new RedDodo()
        {
          IdleSprite = this.BidleSprite,
          RunSprite = this.BwalkSprite
        },
        (INPC) new GreenDodo()
        {
          IdleSprite = this.CidleSprite,
          RunSprite = this.CwalkSprite
        },
        (INPC) new PinkDodo()
        {
          IdleSprite = this.DidleSprite,
          RunSprite = this.DwalkSprite
        },
        (INPC) new OrangeDodo()
        {
          IdleSprite = this.EidleSprite,
          RunSprite = this.EwalkSprite
        }
      };
      Game1.pathfinder.Pathfound += new EventHandler(GUIManager.editorHUD.PathCallback);
      this.movementModeInLastDraw = Game1.player.currentMovementType;
      this.contentReady = true;

            #endregion


            //RnD
            Game1.world = new World(background)
            {
                name = "mainworld",
                objects = new List<IWorldObject>(),
                behaviorMap = new TerrainBehaviorMap(texture1),
                background = background // !
            };
            WorldGenerator.NewWorldGen(Game1.world, this.presetList);

        }//LoadAllContent


   // LoadDefaultSave
   public void LoadDefaultSave()
    {
      if (this.WorldLoader == Game1.WorldLoaderType.staticDefinition)
      {
        Game1.player.inventory = new Inventory()
        {
          inventory = new ItemStack[24]
        };

        System.Diagnostics.Debug.WriteLine(
            "[!] Static world generation enabled. Generating world now.");
            
         //WorldGenerator.NewWorldGen(Game1.world, this.presetList);

        Game1.player.inventory.inventory[0] = new ItemStack(10, 6);
        Game1.NPCs = new List<INPC>();

        //TODO
        //Sound.InitEvents(this);
      }
      else if (SaveHandler.IsSlotRegistered(SaveHandler.LastSavedSlot))
      {
        System.Diagnostics.Debug.WriteLine("[i] Loading save (not default).");
        SaveHandler.LoadGame(SaveHandler.LastSavedSlot, Game1.commonSprites, this);
      }
      else
      {
        System.Diagnostics.Debug.WriteLine("[i] Loading save (default).");
        SaveHandler.LoadDefault(Game1.commonSprites, this);
      }
    }

   // UnloadContent
   protected override void UnloadContent()
    {
      Recorder.Terminate();
      if (this.contentReady)
      {
        try
        {
          SaveHandler.SaveGame(Game1.world, Game1.player, this.lastFrame);
        }
        catch (Exception ex)
        {
        }
      }
      if (this.Content == null)
        return;
      this.Content.Dispose();
   }//UnloadContent






   // Update
   protected override void Update(GameTime gameTime)
   {
      Stopwatch stopwatch = Stopwatch.StartNew();

      if (this.woModifiedInGameEditor == null)
        this.woModifiedInGameEditor = new List<IWorldObject>();

      //TODO
      //Sound.UpdateFMOD();
      
      if (!this.startupIntroDone)
      {
        if (this.spriteBatch != null && Game1.rouliLSpriteFont != null
            && this.ressourceLoadingBackground720 != null 
            && Game1.dodoteamlogo != null && Game1.monogamelogo != null && Game1.fmodlogo != null)
          this.startupIntroTimer += Convert.ToInt32(gameTime.ElapsedGameTime.TotalMilliseconds);

        if (!this.contentReady)
          return;
        
        this.startupFadeOutTimer += Convert.ToInt32(gameTime.ElapsedGameTime.TotalMilliseconds);
        
        if (this.startupFadeOutTimer <= 1100)
          return;
        
        this.startupIntroDone = true;
        GUIManager.currentHUDs.Add((IGUI) GUIManager.interactGUI);
      }
      else
      {
        if (this.startupFadeInTimer < 1100)
          this.startupFadeInTimer += Convert.ToInt32(gameTime.ElapsedGameTime.TotalMilliseconds);

        //TODO
        //Sound.Update(gameTime, this);
        
        MediaPlayer.Volume = Sound.bgmVolume;
        if (SaveHandler.CurrentlySaving)
        {
          base.Update(gameTime);
        }
        else
        {
          if (!GUIManager.IsGameObstructed && !CutsceneManager.CutsceneActive)
            this.timeSinceLastAutosave += Convert.ToSingle(gameTime.ElapsedGameTime.TotalMilliseconds);
          
          if ((double) this.timeSinceLastAutosave > 300000.0)
          {
            this.timeSinceLastAutosave = 0.0f;
            SaveHandler.SaveGame(Game1.world, Game1.player, this.lastFrame);
          }
          CutsceneManager.Update(gameTime, Game1.player, Game1.world);

          UserInputStatus userInputStatus = CutsceneManager.CutsceneActive 
                        ? CutsceneManager.InputStatus : this.userInput.GetInput();

          if (!GUIManager.IsInputLocked)
          {
            if ((double)userInputStatus.moveLeft > 0.0
                            || (double)userInputStatus.moveRight > 0.0
                            || (double)userInputStatus.moveDown > 0.0
                            || (double)userInputStatus.moveUp > 0.0)
            {
                Game1.player.HandleMovementRequest(gameTime, userInputStatus.moveLeft,
                    userInputStatus.moveRight, userInputStatus.moveUp,
                    userInputStatus.moveDown, Game1.world);
            }
            else if ((double)this.lastUIS.moveLeft > 0.0
                            || (double)this.lastUIS.moveRight > 0.0
                            || (double)this.lastUIS.moveUp > 0.0
                            || (double)this.lastUIS.moveDown > 0.0)
            {
                this.dodoSpriteMoving.ResetAnimation();
            }
          }

          if (Game1.player.currentMovementType != Player.DodoMovement.Drown)
            this.dodoSpriteSwimSink.ResetAnimation();

          if (userInputStatus.escape == UserInputStatus.InputState.Pressed)
          {
            if (GUIManager.OpenHudBesideInteract() == 0)
              GUIManager.ClearThenSet((IGUI) GUIManager.escapeGUI);
            else
              GUIManager.Clear();
          }

          if (userInputStatus.inventory == UserInputStatus.InputState.Pressed)
          {
            if (GUIManager.OpenHudBesideInteract() == 0)
            {
              GUIManager.inventoryGUI.Open();
              GUIManager.currentHUDs.Add((IGUI) GUIManager.inventoryGUI);
            }
            else
              GUIManager.Clear();
          }

          if (GUIManager.pendingExit && !SaveHandler.CurrentlySaving)
          {
            GUIManager.pendingExit = false;

            if (this.WorldLoader == Game1.WorldLoaderType.dynamicSaves)
            {
                try
                {
                    SaveHandler.SaveGame(Game1.world, Game1.player, this.lastFrame);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("[ex] SaveGame error: " + ex.Message);
                }
            }
            
            CoreApplication.Exit();
          }

          GUIManager.GUIInput(userInputStatus, this);
          GUIManager.Update(gameTime);

          if (GUIManager.currentHUDs.Contains((IGUI) GUIManager.escapeGUI) 
                        || GUIManager.currentHUDs.Contains((IGUI) GUIManager.inventoryGUI) 
                        || GUIManager.currentHUDs.Contains((IGUI) GUIManager.mainmenu) 
                        || GUIManager.currentHUDs.Contains((IGUI) GUIManager.loadGUI) 
                        || GUIManager.currentHUDs.Contains((IGUI) GUIManager.settings))
          {
            base.Update(gameTime);
          }
          else
          {
            if (Game1.player.currentMovementType == Player.DodoMovement.Bicycle)
            {
              if (Game1.player.actionTime <= this.dodoBicycle1Sprite.MillisecondsPerFrame 
                                * this.dodoBicycle1Sprite.TotalFrameCount)
              {
                DayCycle.dayTime += 1.5;
                DayCycle.timeSpeed = 2.0;
              }
              else if (Game1.player.actionTime <= this.dodoBicycle1Sprite.MillisecondsPerFrame 
                                * this.dodoBicycle1Sprite.TotalFrameCount 
                                + this.dodoBicycle2Sprite.MillisecondsPerFrame 
                                * this.dodoBicycle2Sprite.TotalFrameCount)
              {
                DayCycle.dayTime += 3.5;
                DayCycle.timeSpeed = 4.0;
              }
              else
              {
                DayCycle.dayTime += 7.0;
                DayCycle.timeSpeed = 8.0;
              }
            }
            else
              DayCycle.timeSpeed = 1.0;
            Game1.player.Update(gameTime, Game1.world, this, userInputStatus);
            ScreenShake.Update(gameTime, Game1.player);
            NPCManager.Update(Game1.world, gameTime);

            foreach (IWorldObject worldObject 
                in Game1.world.objects.Where<IWorldObject>(
                    (Func<IWorldObject, bool>) 
                    (p => p.StandardSprite != null && p.StandardSprite.animated 
                    || p is Growable)))
            {
              if (worldObject.StandardSprite != null 
                                && !this.knownSprites.Contains(worldObject.StandardSprite))
                this.knownSprites.Add(worldObject.StandardSprite);
              if (worldObject is Growable growable)
              {
                foreach (Sprite growSprite in growable.growSprites)
                {
                  if (growSprite.animated && !this.knownSprites.Contains(growSprite))
                    this.knownSprites.Add(growSprite);
                }
              }
            }

            this.knownSprites.ForEach((Action<Sprite>) (spr => spr.Update(gameTime)));

            if (Game1.player.inReachObject != null)
            {
              if (userInputStatus.interactLeft == UserInputStatus.InputState.Pressed
                                && Game1.player.inReachObject.Interactions[0] != null)
                Game1.player.inReachObject.Interact(Cardinal.Left, this, Game1.player);

              if (userInputStatus.interactRight == UserInputStatus.InputState.Pressed 
                                && Game1.player.inReachObject.Interactions[1] != null)
                Game1.player.inReachObject.Interact(Cardinal.Right, this, Game1.player);

              if (userInputStatus.interactUp == UserInputStatus.InputState.Pressed 
                                && Game1.player.inReachObject.Interactions[3] != null)
                Game1.player.inReachObject.Interact(Cardinal.Up, this, Game1.player);

              if (userInputStatus.interactDown == UserInputStatus.InputState.Pressed 
                                && Game1.player.inReachObject.Interactions[2] != null)
                Game1.player.inReachObject.Interact(Cardinal.Down, this, Game1.player);
            }
            this.lastUIS = userInputStatus;
            Wind.Update(gameTime, Game1.player);
            DayCycle.Update(this, gameTime);
            float num1 = Math.Abs(Game1.player.bikeVelocity.X) 
                            + Math.Abs(Game1.player.bikeVelocity.Y) / 15f;
            if ((double) num1 > 1.0)
              num1 = 1f;

            int num2 = (int) Math.Round(0.60000002384185791 * (300.0 - 220.0 * (double) num1));
            if ((double) num1 < 0.019999999552965164)
              num2 = 10000000;

            this.dodoBikeSprite.MillisecondsPerFrame = num2;
            this.dodoBikeInWaterSprite.MillisecondsPerFrame = num2;
            this.dodoBikeBSprite.MillisecondsPerFrame = num2;
            this.dodoBikeInWaterBSprite.MillisecondsPerFrame = num2;
            
            WindTrailManager.Update(Game1.player, gameTime);
            BirdShadowManager.Update(Game1.player, gameTime);
            BirdShadowManager.sprite.Update(gameTime);
            ButterflyManager.Update(Game1.player);
            EnvironmentalSoundManager.Update(gameTime, Game1.player);
            ButterflyManager.sprite.Update(gameTime);
            
            for (int index = Game1.foregroundEffectList.Count - 1; index >= 0; --index)
            {
              if (Game1.foregroundEffectList[index] 
                                is HarvestResults foregroundEffect && foregroundEffect.ToDiscard)
                Game1.foregroundEffectList.RemoveAt(index);
            }

            base.Update(gameTime);
            
            stopwatch.Stop();
            
            Game1.frameCounter.RegisterUpdateTicks((float) stopwatch.ElapsedTicks);
          }
        }
      }
    }//Update


    // Draw
    protected override void Draw(GameTime gameTime)
    {
      Game1.wavecounterdebug = 0;

      if (this.startupIntroDone && !Recorder.rerendering)
      {
        Stopwatch stopwatch = Stopwatch.StartNew();
        Recorder.drawCallCount = 0;
        Recorder.currentDrawTime = gameTime.TotalGameTime.TotalMilliseconds;
        this.GraphicsDevice.SetRenderTarget(this.renderTarget);
        this.GraphicsDevice.Clear(Color.Black);
        this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

        this.backgroundPosition = 
            new Vector2
            (
                Game1.dodoCenteredScreenLocation.X  - Game1.player.location.X,
                Game1.dodoCenteredScreenLocation.Y  - Game1.player.location.Y
            ) 
            + ScreenShake.CameraOffset;

        Game1.dodoScreenLocation = Game1.dodoCenteredScreenLocation;

        if (Game1.player.currentMovementType != Player.DodoMovement.Bicycle)
          Game1.dodoScreenLocation += ScreenShake.CameraOffset;

        if (!GUIManager.IsGameObstructed)
        {
          GameTime gameTime1 = 
                        GUIManager.currentHUDs.Contains((IGUI) GUIManager.inventoryGUI)
                        || GUIManager.currentHUDs.Contains((IGUI) GUIManager.escapeGUI)
                        || SaveHandler.CurrentlySaving 
                        ? new GameTime(gameTime.TotalGameTime, new TimeSpan(0L))
                        : gameTime;

          this.harvestCloudSprite.Update(gameTime1);
          this.dodoSpriteHarvesting.Update(gameTime1);
          this.dodoTakeSprite.Update(gameTime1);
          this.buildingCloudSprite.Update(gameTime1);
          this.dodoSpriteBuilding.Update(gameTime1);
          this.dodoSpriteSwimSink.Update(gameTime1);
          this.dodoSpriteSwimPulse.Update(gameTime1);
          this.dodoSpriteSwimIdle.Update(gameTime1);
          this.dodoSpriteMoving.Update(gameTime1);
          this.dodoTakeNotes.Update(gameTime1);
          this.dodoSprite.Update(gameTime1);
          this.dodoBikeSprite.Update(gameTime1);
          this.dodoBikeInWaterSprite.Update(gameTime1);
          this.dodoBikeInWaterBSprite.Update(gameTime1);
          this.dodoBicycle1Sprite.Update(gameTime1);
          this.dodoBicycle2Sprite.Update(gameTime1);
          this.dodoBicycle3Sprite.Update(gameTime1);
          this.dodoBikeBSprite.Update(gameTime1);

          if (!CutsceneManager.IsOverrideInEffect(RenderOverride.Terrain))
          {
            this.spriteBatch.Begin(SpriteSortMode.Immediate);
            Game1.world.background.DrawInRange(this.spriteBatch, 
                Game1.player.location, this.backgroundPosition, Game1.world.Level);
            this.spriteBatch.End();
          }
          else
            CutsceneManager.DrawOverride(RenderOverride.Terrain, this.spriteBatch,
                gameTime, this, this.backgroundPosition);

          if (!CutsceneManager.IsOverrideInEffect(RenderOverride.Waves))
          {
            this.spriteBatch.Begin(SpriteSortMode.Immediate);
            bool flag = !DebugAssistant.waveEditor;
            foreach (IBackgroundEffect wave in Game1.waves)
            {
              if (flag)
                flag = false;
              else
                wave.Draw(this.spriteBatch, gameTime1, this.backgroundPosition);
            }
            this.spriteBatch.End();
          }
          else
            CutsceneManager.DrawOverride(RenderOverride.Waves, this.spriteBatch, gameTime,
                this, Vector2.Zero);

          if (!CutsceneManager.IsOverrideInEffect(RenderOverride.LowestSubSprites))
          {
            this.spriteBatch.Begin(SpriteSortMode.Immediate);
            foreach (IWorldObject worldObject in Game1.world.objects)
            {
              if (worldObject.CurrentDrawSprite.groundSubsprite != null)
              {
                foreach (SubSprite sub in worldObject.CurrentDrawSprite.groundSubsprite)
                  worldObject.CurrentDrawSprite.DrawSubsprite(this.backgroundPosition,
                      this.spriteBatch, sub, Convert.ToSingle(DayCycle.NightFactor), worldObject.Location);
              }
            }
            this.spriteBatch.End();
          }
          else
            CutsceneManager.DrawOverride(RenderOverride.LowestSubSprites, this.spriteBatch,
                gameTime, this, Vector2.Zero);

          this.spriteBatch.Begin(SpriteSortMode.Immediate);

          Game1.world.objects.ForEach((Action<IWorldObject>) 
              (wo => wo.DrawShadow(this.spriteBatch, 
              new Vector2
              (
                  this.backgroundPosition.X + wo.Location.X,
                  this.backgroundPosition.Y + wo.Location.Y
              ), 
              gameTime, this)));

          this.spriteBatch.End();
          if (!CutsceneManager.IsOverrideInEffect(RenderOverride.BirdShadows))
          {
            this.spriteBatch.Begin(SpriteSortMode.Immediate);
            BirdShadowManager.Draw(this.spriteBatch, gameTime1, this.backgroundPosition);
            this.spriteBatch.End();
          }
          else
            CutsceneManager.DrawOverride(RenderOverride.BirdShadows, 
                this.spriteBatch, gameTime, this, Vector2.Zero);

          List<object> source = new List<object>();
          source.Add((object) Game1.player);
          source.AddRange((IEnumerable<object>) Game1.world.objects);
          source.AddRange((IEnumerable<object>) Game1.world.NPCs);
          List<object> list = source.OrderBy<object, int>((Func<object, int>) (o =>
          {
            switch (o)
            {
              case INPC _:
                return ((INPC) o).FeetY;
              case IWorldObject _:
                return ((IWorldObject) o).SpriteBottomY;
              case Player _:
                return ((Player) o).CurrentFeetY;
              default:
                throw new Exception("Unknown object type while sorting floor objects");
            }
          })).ToList<object>();


          this.spriteBatch.Begin(SpriteSortMode.Immediate);
          foreach (object obj in list)
          {
            switch (obj)
            {
               // Override.Terrain
                case IWorldObject parentWo when !CutsceneManager.IsOverrideInEffect(RenderOverride.Terrain):
                Color color = Color.White;

                if (parentWo is BuildPoint)
                  color = parentWo != Game1.player.inReachObject ? Color.White * 0.65f : Color.White * 1f;

                parentWo.Draw(this.spriteBatch, new Vector2(this.backgroundPosition.X + parentWo.Location.X, 
                    this.backgroundPosition.Y + parentWo.Location.Y), gameTime, this, colorn: new Color?(color), 
                    inReach: parentWo == Game1.player.inReachObject, 
                    inReachAndHasInteractions: parentWo == Game1.player.inReachObject 
                    && (parentWo.Interactions[0] != null 
                    && parentWo.Interactions[0].ComputeShowState(parentWo, Game1.player) 
                    || parentWo.Interactions[1] != null 
                    && parentWo.Interactions[1].ComputeShowState(parentWo, Game1.player) 
                    || parentWo.Interactions[2] != null 
                    && parentWo.Interactions[2].ComputeShowState(parentWo, Game1.player)
                    || parentWo.Interactions[3] != null 
                    && parentWo.Interactions[3].ComputeShowState(parentWo, Game1.player)));
                continue;

              case INPC npc when !CutsceneManager.IsOverrideInEffect(RenderOverride.Terrain):
                npc.Draw(this.spriteBatch, gameTime1, this.backgroundPosition);
                continue;

              case Player player:
                if (CutsceneManager.IsOverrideInEffect(RenderOverride.Dodo))
                {
                  this.spriteBatch.End();

                  CutsceneManager.DrawOverride(RenderOverride.Dodo, 
                      this.spriteBatch, gameTime, this, Game1.dodoScreenLocation);

                  this.spriteBatch.Begin(SpriteSortMode.Immediate);
                  continue;
                }

                SpriteEffects globaleffect = player.facing == 1 
                                    ? SpriteEffects.None
                                    : SpriteEffects.FlipHorizontally;

                UserInputStatus userInputStatus = CutsceneManager.CutsceneActive
                                    ? CutsceneManager.InputStatus
                                    : this.userInput.GetInput();


                switch (player.currentMovementType)
                {

                    case Player.DodoMovement.Walk:
                    if 
                    (
                      GUIManager.OpenHudBesideInteract() == 0
                            && ((double) userInputStatus.moveLeft > 0.0
                            || (double) userInputStatus.moveRight > 0.0
                            || (double) userInputStatus.moveDown > 0.0 
                            || (double) userInputStatus.moveUp > 0.0)
                            && ((double) userInputStatus.moveLeft != (double) userInputStatus.moveRight 
                            || (double) userInputStatus.moveUp != (double) userInputStatus.moveDown)
                    )
                      this.dodoSpriteMoving.Draw(this.spriteBatch,
                          new Vector2(Game1.dodoScreenLocation.X, Game1.dodoScreenLocation.Y - 10f),
                          gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                    else
                      this.dodoSprite.Draw(this.spriteBatch, new Vector2(Game1.dodoScreenLocation.X,
                          Game1.dodoScreenLocation.Y - 10f), gameTime, globaleffect,
                          nightFactor: DayCycle.NightFactor);

                    if (this.movementModeInLastDraw == Player.DodoMovement.Swim)
                    {
                      this.dodoSpriteSwimIdle.ResetAnimation();
                      this.dodoSpriteSwimPulse.ResetAnimation();
                      continue;
                    }
                    continue;

                   case Player.DodoMovement.Swim:
                    if (player.IsInSwimmingPulse && !player.IsSwimmingLocked)
                    {
                      this.dodoSpriteSwimIdle.ResetAnimation();
                      this.dodoSpriteSwimPulse.Draw(this.spriteBatch, 
                          Game1.dodoScreenLocation, gameTime, globaleffect, 
                          nightFactor: DayCycle.NightFactor);
                      continue;
                    }

                    this.dodoSpriteSwimPulse.ResetAnimation();
                    this.dodoSpriteSwimIdle.Draw(this.spriteBatch, 
                        Game1.dodoScreenLocation, gameTime, globaleffect,
                        nightFactor: DayCycle.NightFactor);
                    continue;


                    case Player.DodoMovement.Build:

                       //Vector2 location1 = new Vector2((float)(
                       //(double)this.backgroundPosition.X +
                       //200 - 95.0),
                       //(float)((double)this.backgroundPosition.Y +
                       //200 - 163.0));

                    Vector2 location1 = new Vector2
                    (
                        (float) ((double) this.backgroundPosition.X +
                                    (double) player.buildingObject.Epicenter.X - 95.0),
                        (float) ((double) this.backgroundPosition.Y + 
                                    (double) player.buildingObject.Epicenter.Y - 163.0)
                    );
                    

                    float num1 = Convert.ToSingle(DayCycle.NightFactor) + 0.18f;
                    
                    if ((double) num1 > 1.0)
                      num1 = 1f;

                    float num2 = 0.5f * num1;
                    if (this.dodoSpriteBuilding.CurrentFrame < 7)
                      this.buildShadows[0].Draw(this.spriteBatch, new Vector2(location1.X - 13f, 
                          location1.Y + 140f), gameTime, colorn: new Color?(Color.White * num2));
                    else if (this.dodoSpriteBuilding.CurrentFrame < 16)
                      this.buildShadows[1].Draw(this.spriteBatch, new Vector2(location1.X - 13f,
                          location1.Y + 140f), gameTime, colorn: new Color?(Color.White * num2));
                    else
                      this.buildShadows[2].Draw(this.spriteBatch, new Vector2(location1.X - 13f, 
                          location1.Y + 140f), gameTime, colorn: new Color?(Color.White * num2));
                   
                                        if (player.actionTime < 200)
                    {
                      this.preBuildingCloudSprite.Draw(this.spriteBatch, location1, gameTime);
                      continue;
                    }

                    this.dodoSpriteBuilding.Draw(this.spriteBatch, new Vector2(location1.X - 10f, 
                        location1.Y - 32f), gameTime);
                    this.buildingCloudSprite.Draw(this.spriteBatch, location1, gameTime);
                    continue;


                  case Player.DodoMovement.Harvest:
                    Vector2 location2 = new Vector2((float) ((double) this.backgroundPosition.X 
                        + (double) player.buildingObject.Epicenter.X - 120.0), 
                        (float) ((double) this.backgroundPosition.Y
                        + (double) player.buildingObject.Epicenter.Y - 160.0));

                    float num3 = Convert.ToSingle(DayCycle.NightFactor) + 0.18f;
                    if ((double) num3 > 1.0)
                      num3 = 1f;
                    float num4 = 0.5f * num3;

                    if (this.dodoSpriteHarvesting.CurrentFrame <= 11)
                      this.harvestShadows[0].Draw(this.spriteBatch,
                          new Vector2(location2.X - 10f, location2.Y - 32f),
                          gameTime, colorn: new Color?(Color.White * num4));
                    else
                      this.harvestShadows[1].Draw(this.spriteBatch, 
                          new Vector2(location2.X - 10f, location2.Y - 32f), 
                          gameTime, colorn: new Color?(Color.White * num4));

                    this.dodoSpriteHarvesting.Draw(this.spriteBatch,
                        new Vector2(location2.X - 10f, location2.Y - 32f), gameTime);
                    this.harvestCloudSprite.Draw(this.spriteBatch, location2, gameTime);
                    continue;

                  case Player.DodoMovement.Bike:
                    if (player.IsBikeInWater)
                    {
                      if (Wind.GetAngle == 7.0 * Math.PI / 4.0 || Wind.GetAngle == Math.PI / 4.0)
                      {
                        this.dodoBikeInWaterSprite.Draw(this.spriteBatch, new Vector2((float) ((double) Game1.dodoScreenLocation.X - 32.0 - 4.0), (float) ((double) Game1.dodoScreenLocation.Y - 90.0 - 14.0)), gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                        continue;
                      }
                      if (Wind.GetAngle == 3.0 * Math.PI / 4.0 || Wind.GetAngle == 5.0 * Math.PI / 4.0)
                      {
                        this.dodoBikeInWaterBSprite.Draw(this.spriteBatch, new Vector2((float) ((double) Game1.dodoScreenLocation.X - 32.0 - 4.0), (float) ((double) Game1.dodoScreenLocation.Y - 90.0 - 14.0)), gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                        continue;
                      }
                      if ((double) player.bikeVelocity.Y > 0.0)
                      {
                        this.dodoBikeInWaterBSprite.Draw(this.spriteBatch, new Vector2((float) ((double) Game1.dodoScreenLocation.X - 32.0 - 4.0), (float) ((double) Game1.dodoScreenLocation.Y - 90.0 - 14.0)), gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                        continue;
                      }
                      this.dodoBikeInWaterSprite.Draw(this.spriteBatch, new Vector2((float) ((double) Game1.dodoScreenLocation.X - 32.0 - 4.0), (float) ((double) Game1.dodoScreenLocation.Y - 90.0 - 14.0)), gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                      continue;
                    }

                    if (Wind.GetAngle == 7.0 * Math.PI / 4.0 || Wind.GetAngle == Math.PI / 4.0)
                    {
                      this.dodoBikeSprite.Draw(this.spriteBatch, new Vector2((float) ((double) Game1.dodoScreenLocation.X - 32.0 - 4.0), (float) ((double) Game1.dodoScreenLocation.Y - 90.0 - 14.0)), gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                      continue;
                    }

                    if (Wind.GetAngle == 3.0 * Math.PI / 4.0 || Wind.GetAngle == 5.0 * Math.PI / 4.0)
                    {
                      this.dodoBikeBSprite.Draw(this.spriteBatch, new Vector2((float) ((double) Game1.dodoScreenLocation.X - 32.0 - 4.0), (float) ((double) Game1.dodoScreenLocation.Y - 90.0 - 14.0)), gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                      continue;
                    }
                    if ((double) player.bikeVelocity.Y > 0.0)
                    {
                      this.dodoBikeBSprite.Draw(this.spriteBatch, new Vector2((float) ((double) Game1.dodoScreenLocation.X - 32.0 - 4.0), (float) ((double) Game1.dodoScreenLocation.Y - 90.0 - 14.0)), gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                      continue;
                    }
                    this.dodoBikeSprite.Draw(this.spriteBatch, new Vector2((float) ((double) Game1.dodoScreenLocation.X - 32.0 - 4.0), (float) ((double) Game1.dodoScreenLocation.Y - 90.0 - 14.0)), gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                    continue;
                  case Player.DodoMovement.Bicycle:
                    if (player.actionTime <= this.dodoBicycle1Sprite.MillisecondsPerFrame * this.dodoBicycle1Sprite.TotalFrameCount)
                    {
                      this.dodoBicycle1Sprite.Draw(this.spriteBatch, new Vector2(Game1.dodoScreenLocation.X + (player.facing == 0 ? -42f : -32f), Game1.dodoScreenLocation.Y - 34f), gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                      continue;
                    }
                    if (player.actionTime <= this.dodoBicycle1Sprite.MillisecondsPerFrame 
                                            * this.dodoBicycle1Sprite.TotalFrameCount + this.dodoBicycle2Sprite.MillisecondsPerFrame * this.dodoBicycle2Sprite.TotalFrameCount)
                    {
                      this.dodoBicycle2Sprite.Draw(this.spriteBatch, new Vector2(Game1.dodoScreenLocation.X + (player.facing == 0 ? -42f : -32f), Game1.dodoScreenLocation.Y - 34f), gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                      continue;
                    }
                    this.dodoBicycle3Sprite.Draw(this.spriteBatch,
                        new Vector2(Game1.dodoScreenLocation.X + (player.facing == 0 ? -42f : -32f), Game1.dodoScreenLocation.Y - 34f), gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                    continue;
                  case Player.DodoMovement.Drown:
                    this.dodoSpriteSwimSink.Draw(this.spriteBatch,
                        Game1.dodoScreenLocation - new Vector2(80f, 20f), gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                    continue;
                  case Player.DodoMovement.WalkToBike:
                    this.dodoWalkToBikeSprite.Draw(this.spriteBatch,
                        new Vector2((float) ((double) Game1.dodoScreenLocation.X - 32.0 - 4.0 - 54.0), (float) ((double) Game1.dodoScreenLocation.Y - 90.0 - 14.0 - 80.0)), gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                    continue;
                  case Player.DodoMovement.WalkToBicycle:
                    this.dodoWalkToBicycleSprite.Draw(this.spriteBatch, 
                        new Vector2(Game1.dodoScreenLocation.X + (player.facing == 0 ? -50f : -40f), Game1.dodoScreenLocation.Y - 85f), gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                    continue;
                  case Player.DodoMovement.TakeNotes:
                    this.dodoTakeNotes.Draw(this.spriteBatch, 
                        new Vector2(Game1.dodoScreenLocation.X, Game1.dodoScreenLocation.Y - 10f), gameTime, globaleffect, nightFactor: DayCycle.NightFactor);
                    continue;
                  default:
                    throw new Exception("Unknown player movement type");
                }
              default:
                continue;
            }
          }
          this.spriteBatch.End();

          if (!CutsceneManager.IsOverrideInEffect(RenderOverride.Butterflies))
          {
            this.spriteBatch.Begin(SpriteSortMode.Immediate);
            ButterflyManager.Draw(this.spriteBatch, gameTime1, this.backgroundPosition);
            this.spriteBatch.End();
          }
          else
            CutsceneManager.DrawOverride(RenderOverride.Butterflies, this.spriteBatch, gameTime, this, 
                Vector2.Zero);
         
          if (!CutsceneManager.IsOverrideInEffect(RenderOverride.WindTrails))
          {
            this.spriteBatch.Begin(SpriteSortMode.Immediate);
            WindTrailManager.Draw(this.spriteBatch, gameTime1, this.backgroundPosition);
            this.spriteBatch.End();
          }
          else
            CutsceneManager.DrawOverride(RenderOverride.WindTrails, this.spriteBatch, gameTime, 
                this, Vector2.Zero);

          if (!CutsceneManager.IsOverrideInEffect(RenderOverride.ForegroundEffects))
          {
            this.spriteBatch.Begin(SpriteSortMode.Immediate);
            Game1.foregroundEffectList
                            .ForEach((Action<IForegroundEffect>) (fe => fe.Draw(this.spriteBatch, gameTime, 
                            this.backgroundPosition)));

            this.spriteBatch.End();
          }
          else
            CutsceneManager.DrawOverride(RenderOverride.ForegroundEffects, this.spriteBatch, 
                gameTime, this, Vector2.Zero);
         
          if (!CutsceneManager.IsOverrideInEffect(RenderOverride.SwimCounter))
          {
            if (Game1.player.currentMovementType == Player.DodoMovement.Swim 
                            || Game1.player.currentMovementType == Player.DodoMovement.Drown)
            {
              this.spriteBatch.Begin(SpriteSortMode.Immediate);
              this.drowningIcons[Game1.player.SwimPulseCount > 3 
                  ? 
                  3 : Game1.player.SwimPulseCount].Draw(this.spriteBatch, 
                  new Vector2(Game1.dodoScreenLocation.X - 30f, Game1.dodoScreenLocation.Y - 60f),
                  gameTime, colorn: new Color?(Color.White * 1f));

              this.spriteBatch.End();
            }
            else
              ((IEnumerable<Sprite>) this.drowningIcons).ToList<Sprite>()
                                .ForEach((Action<Sprite>) (p => p.ResetAnimation()));
          }
          else
            CutsceneManager.DrawOverride(RenderOverride.SwimCounter, 
                this.spriteBatch, gameTime, this, Vector2.Zero);
         
          if (!CutsceneManager.IsOverrideInEffect(RenderOverride.TimeBar))
          {
            if (Game1.player.currentMovementType == Player.DodoMovement.Bicycle 
                            || Game1.player.currentMovementType == Player.DodoMovement.WalkToBicycle)
            {
              this.spriteBatch.Begin(SpriteSortMode.Immediate);
              this.timebar.CurrentFrame = (int) Math.Round(21.0 * (double) Game1.player.TimeBar / 100.0, 0);

              this.timebar.Draw(this.spriteBatch, 
                  new Vector2(Game1.dodoScreenLocation.X + 130f, Game1.dodoScreenLocation.Y - 90f),
                  gameTime, colorn: new Color?(Color.White * 1f));
              this.spriteBatch.End();
            }
          }
          else
            CutsceneManager.DrawOverride(RenderOverride.TimeBar, this.spriteBatch, gameTime, this, Vector2.Zero);
        }

        Texture2D renderTarget = (Texture2D) this.renderTarget;
        
        if (GUIManager.OpenHudBesideInteract() == 0)
          this.lastFrame = (Texture2D) this.renderTarget;
        this.GraphicsDevice.SetRenderTarget(this.renderTarget2);
        this.GraphicsDevice.Clear(Color.Black);
        this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
        this.spriteBatch.Begin(SpriteSortMode.Immediate);
        this.spriteBatch.Draw(renderTarget, new Vector2(0.0f, 0.0f), DayCycle.ColorFilter);
        this.spriteBatch.End();

        // ?
        if (!CutsceneManager.IsOverrideInEffect(RenderOverride.HUD))
        {
            this.spriteBatch.Begin(SpriteSortMode.Immediate);
            GUIManager.DrawGUI(this.spriteBatch, this, gameTime);
            this.spriteBatch.End();
        }
        else
        {
            //try
            //{
            CutsceneManager.DrawOverride(RenderOverride.HUD, this.spriteBatch, gameTime, this, Vector2.Zero);
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine("[ex] Game1 - CutsceneManager.DrawOverride bug: " + ex.Message);
            //}            
        }
        
        this.spriteBatch.Begin(SpriteSortMode.Immediate);

        if (Game1.player.timeSinceDrowning > 2200 && Game1.player.timeSinceDrowning < 2500)
        {
            Recorder.RDraw(this.spriteBatch, this.whiteBackground, Vector2.Zero, 
                Color.Black * Convert.ToSingle(Convert.ToDouble(Game1.player.timeSinceDrowning - 2200) / 300.0));
        }
        else if (Game1.player.timeSinceDrowning >= 2500 && Game1.player.timeSinceDrowning < 2900)
        { 
            Recorder.RDraw(this.spriteBatch, this.whiteBackground, Vector2.Zero, Color.Black); 
        }


        this.spriteBatch.End();
        if ((double) CutsceneManager.CurrentBlackFade > 0.0)
        {
          this.spriteBatch.Begin(SpriteSortMode.Immediate);
          Recorder.RDraw(this.spriteBatch, this.whiteBackground, Vector2.Zero, Color.Black * CutsceneManager.CurrentBlackFade);
          this.spriteBatch.End();
        }
        if ((double) CutsceneManager.CurrentWhiteFade > 0.0)
        {
          this.spriteBatch.Begin(SpriteSortMode.Immediate);
          Recorder.RDraw(this.spriteBatch, this.whiteBackground, Vector2.Zero, Color.White * CutsceneManager.CurrentWhiteFade);
          this.spriteBatch.End();
        }
        if (Game1.player.currentMovementType == Player.DodoMovement.Build && Game1.player.buildingObject != null && ((IEnumerable<string>) Game1.player.buildingObject.Tags).Contains<string>("boardAnimation") && Game1.player.actionTime > 1500)
        {
          this.spriteBatch.Begin(SpriteSortMode.Immediate);
          float num = Convert.ToSingle(Convert.ToDouble(Game1.player.actionTime - 1500) / 500.0);
          if ((double) num > 1.0)
            num = 1f;
          Recorder.RDraw(this.spriteBatch, this.whiteBackground, Vector2.Zero, Color.Black * num);
          this.spriteBatch.End();
        }
        if (SaveHandler.CurrentlySaving)
        {
          this.spriteBatch.Begin(SpriteSortMode.Immediate);
          Recorder.RDraw(this.spriteBatch, this.savingTexture, new Vector2((float) ((int) Game1.renderSize.X - 78), (float) ((int) Game1.renderSize.Y - 70)), Color.White);
          this.spriteBatch.End();
        }
        if (this.startupFadeInTimer < 1100)
        {
          float num = (float) (1.0 - (double) Convert.ToSingle(this.startupFadeInTimer) / 1100.0);
          this.spriteBatch.Begin(SpriteSortMode.Immediate);
          Recorder.RDraw(this.spriteBatch, this.whiteBackground, Vector2.Zero, Color.White * num);
          this.spriteBatch.End();
        }
        this.movementModeInLastDraw = Game1.player.currentMovementType;
        PerformanceCounter frameCounter = Game1.frameCounter;
        TimeSpan elapsedGameTime = gameTime.ElapsedGameTime;
        double totalSeconds = elapsedGameTime.TotalSeconds;
        elapsedGameTime = gameTime.ElapsedGameTime;
        double totalMilliseconds = elapsedGameTime.TotalMilliseconds;
        frameCounter.Update((float) totalSeconds, totalMilliseconds);
        Texture2D renderTarget2 = (Texture2D) this.renderTarget2;
        this.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
        this.GraphicsDevice.Clear(Color.Black);
        this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
        Vector2 vector2 = new Vector2((float) Math.Round(((double) Game1.windowSize.X 
            - (double) Game1.renderSizeUpscaled.X) / 2.0, 0), 
            (float) Math.Round(((double) Game1.windowSize.Y - (double) Game1.renderSizeUpscaled.Y) / 2.0,
            0));
        this.spriteBatch.Begin(SpriteSortMode.Immediate);
        this.spriteBatch.Draw(renderTarget2, 
            new Rectangle(Convert.ToInt32(vector2.X), Convert.ToInt32(vector2.Y),
            Convert.ToInt32(Game1.renderSizeUpscaled.X), Convert.ToInt32(Game1.renderSizeUpscaled.Y)), new Rectangle?(), Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.0f);
        this.spriteBatch.End();

        base.Draw(gameTime);

        stopwatch.Stop();

        Game1.frameCounter.RegisterDrawTicks((float) stopwatch.ElapsedTicks);
      }
      else if (this.startupIntroDone && Recorder.rerendering)
      {
        this.GraphicsDevice.SetRenderTarget(this.renderTarget);
        this.GraphicsDevice.Clear(Color.Black);
        this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
        this.spriteBatch.Begin(SpriteSortMode.Immediate);
        Recorder.Update(gameTime, this, this.spriteBatch);
        this.spriteBatch.End();
        Texture2D renderTarget = (Texture2D) this.renderTarget;
        this.GraphicsDevice.SetRenderTarget(this.renderTarget2);
        this.GraphicsDevice.Clear(Color.Black);
        this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
        this.spriteBatch.Begin(SpriteSortMode.Immediate);
        this.spriteBatch.Draw(renderTarget, new Vector2(0.0f, 0.0f), Recorder.rERcolorFilter);
        this.spriteBatch.End();
        Texture2D renderTarget2 = (Texture2D) this.renderTarget2;
        this.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
        this.GraphicsDevice.Clear(Color.Black);
        this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
        Vector2 vector2 = new Vector2((float) Math.Round(((double) Game1.windowSize.X - (double) Game1.renderSizeUpscaled.X) / 2.0, 0), (float) Math.Round(((double) Game1.windowSize.Y - (double) Game1.renderSizeUpscaled.Y) / 2.0, 0));
        this.spriteBatch.Begin(SpriteSortMode.Immediate);
        this.spriteBatch.Draw(renderTarget2, new Rectangle(Convert.ToInt32(vector2.X), Convert.ToInt32(vector2.Y), Convert.ToInt32(Game1.renderSizeUpscaled.X), Convert.ToInt32(Game1.renderSizeUpscaled.Y)), new Rectangle?(), Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.0f);
        this.spriteBatch.End();
      }
      else
      {
        this.GraphicsDevice.Clear(Color.Black);
        //LOADING_STATE state;

       if (this.spriteBatch != null && Game1.rouliLSpriteFont != null 
        && this.ressourceLoadingBackground720 != null 
        && Game1.dodoteamlogo != null 
        && Game1.monogamelogo != null
        && Game1.fmodlogo != null 
        //&& Sound.SoundSystemInitialized 
        //&& Sound.fmodEvents != null 
        //&& Sound.fmodEvents["event:/SFX/GameLogo"].getSampleLoadingState(out state) == RESULT.OK
        //&& state == LOADING_STATE.LOADED
        )
        {
          Vector2 position = new Vector2((float) Math.Round(
              ((double) Game1.windowSize.X - (double) Game1.renderSize.X) / 2.0, 0), 
              (float) Math.Round(((double) Game1.windowSize.Y 
              - (double) Game1.renderSize.Y) / 2.0, 0));

          this.spriteBatch.Begin(SpriteSortMode.Immediate);
          this.spriteBatch.Draw(this.ressourceLoadingBackground720, position, Color.White);
          this.spriteBatch.End();
          float num5 = 0.0f;
          float num6 = 0.0f;
          float num7 = 0.0f;
          float num8 = 0.0f;
          if (this.startupIntroTimer < 1000)
            num5 = (float) this.startupIntroTimer / 1000f;
          else if (this.startupIntroTimer < 3000)
            num5 = 1f;
          else if (this.startupIntroTimer < 3700)
            num5 = (float) (1.0 - ((double) Convert.ToSingle(this.startupIntroTimer) - 3000.0) / 700.0);
          else if (this.startupIntroTimer < 4400)
            num6 = (float) (((double) Convert.ToSingle(this.startupIntroTimer) - 3700.0) / 700.0);
          else if (this.startupIntroTimer < 6000)
            num6 = 1f;
          else if (this.startupIntroTimer < 6900)
            num6 = (float) (1.0 - ((double) Convert.ToSingle(this.startupIntroTimer) - 6000.0) / 700.0);
          else if (this.startupIntroTimer < 7600)
            num7 = (float) (((double) Convert.ToSingle(this.startupIntroTimer) - 6900.0) / 700.0);
          else if (this.startupIntroTimer < 8500)
            num7 = 1f;
          else if (this.startupIntroTimer < 9200)
            num7 = (float) (1.0 - ((double) Convert.ToSingle(this.startupIntroTimer) - 8500.0) / 700.0);
          else
            num8 = this.startupIntroTimer >= 9900 
                            ? 1f
                            : (float) (((double) Convert.ToSingle(
                                this.startupIntroTimer) - 9200.0) / 700.0);

          if ((double) num5 > 0.699999988079071 && !this.startupLogoEventPassed)
          {
            this.startupLogoEventPassed = true;
            Game1.StartupLogo?.Invoke(this, EventArgs.Empty);
          }
          this.spriteBatch.Begin(SpriteSortMode.Immediate);

          Recorder.RDraw(this.spriteBatch, Game1.dodoteamlogo, 
              new Vector2(position.X + Game1.renderSize.X / 2f
              - (float) (Game1.dodoteamlogo.Width / 2), 
              position.Y + Game1.renderSize.Y / 2f - 
              (float) (Game1.dodoteamlogo.Height / 2)), 
              Color.White * num5);

          Vector2 location3 = new Vector2(
              position.X + Game1.renderSize.X / 2f 
              - (float) (Game1.monogamelogo.Width / 2), position.Y + Game1.renderSize.Y / 2f 
              - (float) (Game1.monogamelogo.Height / 2));

          Recorder.RDraw(this.spriteBatch, Game1.monogamelogo, location3, 
              Color.White * num6);
          Vector2 location4 = new Vector2(position.X 
              + Game1.renderSize.X / 2f - (float) (Game1.fmodlogo.Width / 2), 
              position.Y + Game1.renderSize.Y / 2f - (float) (Game1.fmodlogo.Height / 2));

          Recorder.RDraw(this.spriteBatch, Game1.fmodlogo, location4, Color.White * num7);

          this.spriteBatch.End();
          this.spriteBatch.Begin(SpriteSortMode.Immediate);
          Recorder.RDrawString(this.spriteBatch, Game1.rouliLSpriteFont, 
              LocalizationManager.GetString("StartupLoadMsg"), 
              new Vector2(577f + position.X, 350f + position.Y), Color.Black * num8);
          this.loadingFeatherSprite.Draw(this.spriteBatch, 
              new Vector2(position.X + 553f, position.Y + 150f), 
              gameTime, colorn: new Color?(Color.White * num8));

          this.loadingFeatherSprite.Update(gameTime);

          this.spriteBatch.Draw(Game1.GenerateBox(new Vector2(500f, 3f), 
              Color.White), new Vector2((float) ((double) position.X 
              + (double) Game1.renderSize.X / 2.0 - 250.0), 420f + position.Y),
              Color.White * (0.4f * num8));

          this.spriteBatch.Draw(Game1.GenerateBox(new Vector2((float) (
              (double) Convert.ToSingle(ContentLoadingWrapper.loadedAssetCount) 
              / (double) Convert.ToSingle(ContentLoadingWrapper.expectedAssetCount) * 500.0), 3f),
              Color.White), new Vector2((float) ((double) position.X
              + (double) Game1.renderSize.X / 2.0 - 250.0), 420f + position.Y), 
              Color.White * num8);

          this.spriteBatch.End();

          this.spriteBatch.Begin();
          this.spriteBatch.Draw(Game1.GenerateBox(Vector2.One, Color.White), 
              new Rectangle(Convert.ToInt32(position.X), Convert.ToInt32(position.Y), 
              Convert.ToInt32(Game1.renderSize.X), 
              Convert.ToInt32(Game1.renderSize.Y)),
              new Rectangle?(), 
              Color.White * ((float) this.startupFadeOutTimer / 1100f));
          this.spriteBatch.End();
        }
        base.Draw(gameTime);
      }

      // if DEBUG mode then Draw debug panel
      if (this.debugEnabled)
      {
       DebugAssistant.DrawDebugPanel(this.spriteBatch, this);
      }

    }//Draw

    public static void SpawnDodo(Vector2 SpawnPosition)
    {
      NPCManager.SpawnDodo(Game1.world, SpawnPosition);
    }

    public void UnhandledException(object obj, UnhandledExceptionEventArgs args)
    {
      Exception exceptionObject = (Exception)args.Exception;//.ExceptionObject;
      exceptionObject.Data.Add((object) "Manifest", 
          (object) "DodoTheGame/The Dodo Archipelago RELEASE 1.0.1");
            int fileLineNumber = 0;// new StackTrace(exceptionObject, true).GetFrame(0).GetFileLineNumber();
      exceptionObject.Data.Add((object) "ErrorLine",
          (object) fileLineNumber);
      //Game1.ravenClient.Capture(new SentryEvent(exceptionObject));
    }

    public static Texture2D GenerateBox(Vector2 size, Color color)
    {
      Texture2D box = new Texture2D(Game1.graphics.GraphicsDevice, (int) size.X, (int) size.Y);
      Color[] data = new Color[(int) size.X * (int) size.Y];
      for (int index = 0; index < data.Length; ++index)
        data[index] = color;
      box.SetData<Color>(data);
      return box;
    }

    public static DateTime GetLinkerTime(Assembly assembly, TimeZoneInfo target = null)
    {
      //TODO
      string location = "";//assembly.Location;
      byte[] buffer = new byte[2048];
      using (FileStream fileStream = new FileStream(location, FileMode.Open, FileAccess.Read))
        fileStream.Read(buffer, 0, 2048);
      int int32 = BitConverter.ToInt32(buffer, 60);
            return  //TimeZoneInfo.ConvertTimeFromUtc()
                  new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                  .AddSeconds((double)BitConverter.ToInt32(buffer, int32 + 8));//, target 
            //?? TimeZoneInfo.Local;
    }

    public static Texture2D TextureBrightnessEffect(Texture2D texture, float strength)
    {
      Texture2D texture2D1 = Game1.affectedTexturesCache.FirstOrDefault<Texture2D>((Func<Texture2D, bool>) (p => p.Name == texture.Name));
      if (texture2D1 != null)
        return texture2D1;
      Texture2D texture2D2 = new Texture2D(Game1.graphics.GraphicsDevice, texture.Width, texture.Height);
      Color[] data1 = new Color[texture.Width * texture.Height];
      Color[] data2 = new Color[texture.Width * texture.Height];
      texture.GetData<Color>(data1);
      for (int index = 0; index < data1.Length; ++index)
      {
        float r;
        float g;
        float b;
        if ((double) data1[index].A > 0.30000001192092896)
        {
          r = Convert.ToSingle(data1[index].R) / (float) byte.MaxValue + strength;
          g = Convert.ToSingle(data1[index].G) / (float) byte.MaxValue + strength;
          b = Convert.ToSingle(data1[index].B) / (float) byte.MaxValue + strength;
        }
        else
        {
          r = (float) data1[index].R;
          g = (float) data1[index].G;
          b = (float) data1[index].B;
        }
        if ((double) r > 1.0)
          r = 1f;
        if ((double) g > 1.0)
          g = 1f;
        if ((double) b > 1.0)
          b = 1f;
        data2[index] = new Color(r, g, b, Convert.ToSingle((float) data1[index].A / (float) byte.MaxValue));
      }
      texture2D2.SetData<Color>(data2);
      texture2D2.Name = texture.Name;
      Game1.affectedTexturesCache.Add(texture2D2);
      return texture2D2;
    }

    public enum WorldLoaderType
    {
      dynamicSaves,
      staticDefinition,
    }
  }
}
