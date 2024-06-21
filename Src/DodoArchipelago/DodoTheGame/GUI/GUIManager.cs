// Type: DodoTheGame.GUI.GUIManager

using DodoTheGame.Saving;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpRaven.Data;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DodoTheGame.GUI
{
  internal static class GUIManager
  {
    public static EscapeGUI escapeGUI;
    public static MainMenuGUI mainmenu;
    public static InteractGUI interactGUI;
    public static LoadGUI loadGUI;
    public static InventoryGUI inventoryGUI;
    public static EditorGUI editorHUD;
    public static TutorialGUI tutorialHUD;
    public static SettingsGUI settings;
    public static CreditsGUI credits;
    public static int GUITimer;
    public static int holdcount;
    public static bool SettingsOpenFromEscape;
    public static List<IGUI> currentHUDs;
    private static UserInputStatus lastUIS;
    public static bool pendingExit;

    public static void Setup()
    {
      GUIManager.escapeGUI = new EscapeGUI();
      GUIManager.interactGUI = new InteractGUI();
      GUIManager.loadGUI = new LoadGUI();
      GUIManager.inventoryGUI = new InventoryGUI();
      GUIManager.currentHUDs = new List<IGUI>();
      GUIManager.editorHUD = new EditorGUI();
      GUIManager.tutorialHUD = new TutorialGUI();
      GUIManager.mainmenu = new MainMenuGUI();
      GUIManager.settings = new SettingsGUI();
      GUIManager.credits = new CreditsGUI();
    }

    public static void LoadAssets(Game1 game)
    {
      GUIManager.interactGUI.a = ContentLoadingWrapper.Load<Texture2D>("hudkeys/a");
      GUIManager.interactGUI.e = ContentLoadingWrapper.Load<Texture2D>("hudkeys/e");
      GUIManager.interactGUI.m = ContentLoadingWrapper.Load<Texture2D>("hudkeys/m");
      GUIManager.interactGUI.bag_icon = ContentLoadingWrapper.Load<Texture2D>("ui/bag_icon");
      GUIManager.interactGUI.bike_icon = ContentLoadingWrapper.Load<Texture2D>("ui/bike_icon");
      GUIManager.interactGUI.bicycle_icon = ContentLoadingWrapper.Load<Texture2D>("ui/bicycle_icon");
      GUIManager.interactGUI.up = ContentLoadingWrapper.Load<Texture2D>("hudkeys/up");
      GUIManager.interactGUI.down = ContentLoadingWrapper.Load<Texture2D>("hudkeys/down");
      GUIManager.interactGUI.left = ContentLoadingWrapper.Load<Texture2D>("hudkeys/left");
      GUIManager.interactGUI.right = ContentLoadingWrapper.Load<Texture2D>("hudkeys/right");
      GUIManager.interactGUI.upsw = ContentLoadingWrapper.Load<Texture2D>("hudkeys/up_sw");
      GUIManager.interactGUI.downsw = ContentLoadingWrapper.Load<Texture2D>("hudkeys/down_sw");
      GUIManager.interactGUI.leftsw = ContentLoadingWrapper.Load<Texture2D>("hudkeys/left_sw");
      GUIManager.interactGUI.rightsw = ContentLoadingWrapper.Load<Texture2D>("hudkeys/right_sw");
      GUIManager.interactGUI.dirup = ContentLoadingWrapper.Load<Texture2D>("ui/icondirtop");
      GUIManager.interactGUI.dirupleft = ContentLoadingWrapper.Load<Texture2D>("ui/icondirdiagtop");
      GUIManager.interactGUI.dirleft = ContentLoadingWrapper.Load<Texture2D>("ui/icondirhorizontal");
      GUIManager.interactGUI.dirleftdown = ContentLoadingWrapper.Load<Texture2D>("ui/icondirdiagbottom");
      GUIManager.interactGUI.dirdown = ContentLoadingWrapper.Load<Texture2D>("ui/icondirbottom");
      GUIManager.interactGUI.dirdownright = ContentLoadingWrapper.Load<Texture2D>("ui/icondirdiagbottomright");
      GUIManager.interactGUI.dirright = ContentLoadingWrapper.Load<Texture2D>("ui/icondirhorizontalright");
      GUIManager.interactGUI.dirupright = ContentLoadingWrapper.Load<Texture2D>("ui/icondirdiagtopright");
      GUIManager.escapeGUI.background = ContentLoadingWrapper.Load<Texture2D>("ui/pause1");
      GUIManager.escapeGUI.text1 = ContentLoadingWrapper.Load<Texture2D>("ui/continuer");
      GUIManager.escapeGUI.text3 = ContentLoadingWrapper.Load<Texture2D>("ui/charger");
      GUIManager.escapeGUI.text2 = ContentLoadingWrapper.Load<Texture2D>("ui/parametres");
      GUIManager.escapeGUI.text4 = ContentLoadingWrapper.Load<Texture2D>("ui/menuprincipal");
      GUIManager.escapeGUI.text5 = ContentLoadingWrapper.Load<Texture2D>("ui/quitter");
      GUIManager.escapeGUI.text1s = ContentLoadingWrapper.Load<Texture2D>("ui/continuerselected");
      GUIManager.escapeGUI.text3s = ContentLoadingWrapper.Load<Texture2D>("ui/chargerselected");
      GUIManager.escapeGUI.text2s = ContentLoadingWrapper.Load<Texture2D>("ui/parametreselect");
      GUIManager.escapeGUI.text4s = ContentLoadingWrapper.Load<Texture2D>("ui/menuprincipalselected");
      GUIManager.escapeGUI.text5s = ContentLoadingWrapper.Load<Texture2D>("ui/quitterselected");
      GUIManager.mainmenu.mainbackground = ContentLoadingWrapper.Load<Texture2D>("mainmenu/bg");
      GUIManager.mainmenu.parameters = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters");
      GUIManager.mainmenu.parameters_selected = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters_selected");
      GUIManager.mainmenu.jouer = ContentLoadingWrapper.Load<Texture2D>("mainmenu/jouer");
      GUIManager.mainmenu.jouer_selected = ContentLoadingWrapper.Load<Texture2D>("mainmenu/jouer_selected");
      GUIManager.mainmenu.bande1 = ContentLoadingWrapper.Load<Texture2D>("mainmenu/bg_deco1");
      GUIManager.mainmenu.bande2 = ContentLoadingWrapper.Load<Texture2D>("mainmenu/bg_deco2");
      GUIManager.mainmenu.bande3 = ContentLoadingWrapper.Load<Texture2D>("mainmenu/bg_deco3");
      GUIManager.mainmenu.mainlogo = ContentLoadingWrapper.Load<Texture2D>("mainmenu/logo");
      GUIManager.mainmenu.exit = ContentLoadingWrapper.Load<Texture2D>("mainmenu/exit");
      GUIManager.mainmenu.exit_selected = ContentLoadingWrapper.Load<Texture2D>("mainmenu/exit_selected");
      GUIManager.loadGUI.mainbackground = ContentLoadingWrapper.Load<Texture2D>("mainmenu/bg");
      GUIManager.loadGUI.background = ContentLoadingWrapper.Load<Texture2D>("ui/pause1");
      GUIManager.loadGUI.slot = ContentLoadingWrapper.Load<Texture2D>("ui/saveslot");
      GUIManager.loadGUI.selectedslot = ContentLoadingWrapper.Load<Texture2D>("ui/saveslotselected");
      GUIManager.loadGUI.emptybin = ContentLoadingWrapper.Load<Texture2D>("ui/bin");
      GUIManager.loadGUI.selectedbin = ContentLoadingWrapper.Load<Texture2D>("ui/bin_selected");
      GUIManager.loadGUI.font26 = Game1.rouliXLSpriteFont;
      GUIManager.loadGUI.font22 = Game1.rouliLSpriteFont;
      GUIManager.loadGUI.font16 = Game1.rouliSSpriteFont;
      GUIManager.loadGUI.empty = ContentLoadingWrapper.Load<Texture2D>("ui/emptyslot");
      GUIManager.loadGUI.error = ContentLoadingWrapper.Load<Texture2D>("ui/errorslot");
      GUIManager.loadGUI.marker1 = ContentLoadingWrapper.Load<Texture2D>("marker1");
      GUIManager.loadGUI.marker2 = ContentLoadingWrapper.Load<Texture2D>("marker2");
      GUIManager.loadGUI.marker3 = ContentLoadingWrapper.Load<Texture2D>("marker3");
      GUIManager.loadGUI.bande1 = ContentLoadingWrapper.Load<Texture2D>("mainmenu/bg_deco1");
      GUIManager.loadGUI.bande2 = ContentLoadingWrapper.Load<Texture2D>("mainmenu/bg_deco2");
      GUIManager.loadGUI.bande3 = ContentLoadingWrapper.Load<Texture2D>("mainmenu/bg_deco3");
      GUIManager.settings.settingsbackground = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/bg");
      GUIManager.settings.cursor = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/cursor");
      GUIManager.settings.cursor_selected = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/cursor_selected");
      GUIManager.settings.retour = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/retour");
      GUIManager.settings.retour_selected = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/retour_selected");
      GUIManager.settings.arrow = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/fleche");
      GUIManager.settings.more = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/more");
      GUIManager.settings.more_mirror = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/more_mirror");
      GUIManager.settings.more_s = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/more_white");
      GUIManager.settings.more_mirror_s = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/more_mirror_white");
      GUIManager.settings.mainbackground = ContentLoadingWrapper.Load<Texture2D>("mainmenu/bg");
      GUIManager.settings.fullscreen = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/pleinecran");
      GUIManager.settings.windowed = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/fenetre");
      GUIManager.settings.fullscreen_s = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/pleinecran_s");
      GUIManager.settings.windowed_s = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/fenetre_s");
      GUIManager.settings.francais_s = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/francais_s");
      GUIManager.settings.francais = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/francais");
      GUIManager.settings.english_s = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/english_s");
      GUIManager.settings.english = ContentLoadingWrapper.Load<Texture2D>("mainmenu/parameters/english");
      GUIManager.settings.bande1 = GUIManager.loadGUI.bande1;
      GUIManager.settings.bande2 = GUIManager.loadGUI.bande2;
      GUIManager.settings.bande3 = GUIManager.loadGUI.bande3;
      GUIManager.credits.bande1 = GUIManager.loadGUI.bande1;
      GUIManager.credits.bande2 = GUIManager.loadGUI.bande2;
      GUIManager.credits.bande3 = GUIManager.loadGUI.bande3;
      GUIManager.credits.mainbackground = ContentLoadingWrapper.Load<Texture2D>("mainmenu/bg");
      GUIManager.credits.creditsbackground = ContentLoadingWrapper.Load<Texture2D>("mainmenu/credits");
      GUIManager.inventoryGUI.background = ContentLoadingWrapper.Load<Texture2D>("ui/inv_bg");
      GUIManager.inventoryGUI.animatedBackground = 
                new Sprite("inv_bg_animated", ContentLoadingWrapper.Load<Texture2D>("ui/inv_bg_animated"))
      {
        animated = true,
        Width = 1098,
        height = 570,
        MillisecondsPerFrame = 12,
        loopAnimation = false
      };
      GUIManager.inventoryGUI.inventaire = ContentLoadingWrapper.Load<Texture2D>("ui/inventaire");
      GUIManager.inventoryGUI.tile = ContentLoadingWrapper.Load<Texture2D>("ui/inventorytile");
      GUIManager.inventoryGUI.selectedtiletexture = 
                ContentLoadingWrapper.Load<Texture2D>("ui/inventorytile2");
      GUIManager.inventoryGUI.itemTextures = game.itemTextures;
      GUIManager.inventoryGUI.empty_flower = ContentLoadingWrapper.Load<Texture2D>("smallitems/empty");
      GUIManager.inventoryGUI.miniFlowersTextures = game.miniFlowersTextures;
      GUIManager.inventoryGUI.font = Game1.rouliLSpriteFont;
      GUIManager.editorHUD.background = ContentLoadingWrapper.Load<Texture2D>("ui/pause1");
      GUIManager.tutorialHUD.animatedBackground = 
                new Sprite("tuto", ContentLoadingWrapper.Load<Texture2D>("ui/tuto"))
      {
        animated = true,
        Width = 751,
        MillisecondsPerFrame = 12,
        loopAnimation = false
      };
    }

    public static void ClearThenSet(IGUI hud)
    {
      Game1.Log("HUDs cleared and " + hud.GetType().FullName + " added.", BreadcrumbLevel.Debug);
      if (hud == GUIManager.settings && GUIManager.currentHUDs.Contains((IGUI) GUIManager.escapeGUI))
        GUIManager.SettingsOpenFromEscape = true;
      else if (hud == GUIManager.escapeGUI && GUIManager.currentHUDs.Contains((IGUI) GUIManager.settings))
        GUIManager.SettingsOpenFromEscape = false;
      GUIManager.Clear();
      hud.Open();
      GUIManager.currentHUDs.Add(hud);
      if (!(hud.GetType() == typeof (LoadGUI)))
        return;
      GUIManager.loadGUI.saveInfo1 = SaveHandler.GetSlotInfo(1, Game1.graphics.GraphicsDevice);
      GUIManager.loadGUI.saveInfo2 = SaveHandler.GetSlotInfo(2, Game1.graphics.GraphicsDevice);
      GUIManager.loadGUI.saveInfo3 = SaveHandler.GetSlotInfo(3, Game1.graphics.GraphicsDevice);
      GUIManager.loadGUI.GenerateThumbnails(Game1.graphics.GraphicsDevice);
    }

    public static void Update(GameTime gameTime)
    {
      GUIManager.currentHUDs.RemoveAll((Predicate<IGUI>) (p => p.ReadyToRemove));

      if (GUIManager.currentHUDs.Contains((IGUI) GUIManager.settings)
                || GUIManager.currentHUDs.Contains((IGUI) GUIManager.loadGUI)
                || GUIManager.currentHUDs.Contains((IGUI) GUIManager.credits))
        GUIManager.GUITimer += gameTime.ElapsedGameTime.Milliseconds / 2;
      else
        GUIManager.GUITimer += gameTime.ElapsedGameTime.Milliseconds;
    }

    public static void Clear(bool includingInteractHUD = false, bool force = false)
    {
      if (!force)
      {
        foreach (IGUI currentHuD in GUIManager.currentHUDs)
          currentHuD.Close();
      }
      else
        GUIManager.currentHUDs.Clear();
      GUIManager.currentHUDs.RemoveAll((Predicate<IGUI>) (p => p.ReadyToRemove));
      if (!includingInteractHUD)
      {
        GUIManager.interactGUI.Open();
        GUIManager.currentHUDs.Add((IGUI) GUIManager.interactGUI);
      }
      GUIManager.inventoryGUI.ResetSelection();
    }

    public static int OpenHudBesideInteract()
    {
      int count = GUIManager.currentHUDs.Count;
      if (GUIManager.currentHUDs.OfType<InteractGUI>().Any<InteractGUI>())
        --count;
      return count;
    }

    public static bool IsInputLocked
    {
      get => GUIManager.currentHUDs.Count<IGUI>((Func<IGUI, bool>) (h => h.LockGameInput)) > 0;
    }

    public static bool IsGameObstructed
    {
      get => GUIManager.currentHUDs.Count<IGUI>((Func<IGUI, bool>) (h => h.IsObstructing)) > 0;
    }

    public static void DrawGUI(SpriteBatch spriteBatch, Game1 game, GameTime gameTime)
    {
      List<IGUI> list = GUIManager.currentHUDs.OrderBy<IGUI, int>(
          (Func<IGUI, int>) (h => h.Layer)).ToList<IGUI>();
      try
      {
        foreach (IGUI gui in list)
          gui.Draw(spriteBatch, game, gameTime);
      }
      catch (Exception ex)
      {
        Game1.Log("An IHUD.Draw has failed", BreadcrumbLevel.Error, "hud");
      }
    }

    public static void GUIInput(UserInputStatus uis, Game1 game)
    {
      if (GUIManager.lastUIS == null)
        GUIManager.lastUIS = uis;
      bool left = false;
      bool right = false;
      bool up = false;
      bool down = false;
      bool action1 = false;
      if ((double) GUIManager.lastUIS.moveLeft > 0.4 && (double) uis.moveLeft < 0.4)
        GUIManager.holdcount = 0;
      if ((double) GUIManager.lastUIS.moveRight > 0.4 && (double) uis.moveRight < 0.4)
        GUIManager.holdcount = 0;
      if ((double) uis.moveLeft > 0.4 && (double) GUIManager.lastUIS.moveLeft <= 0.4 
                && (double) uis.moveRight <= 0.4)
      {
        left = true;
        GUIManager.holdcount = 0;
      }
      else if ((double) GUIManager.lastUIS.moveLeft > 0.4)
      {
        ++GUIManager.holdcount;
        if (GUIManager.holdcount > 25 && GUIManager.holdcount % 2 == 0)
          left = true;
      }
      if ((double) uis.moveRight > 0.4 && (double) GUIManager.lastUIS.moveRight <= 0.4
                && (double) uis.moveLeft <= 0.4)
      {
        right = true;
        GUIManager.holdcount = 0;
      }
      else if ((double) GUIManager.lastUIS.moveRight > 0.4)
      {
        ++GUIManager.holdcount;
        if (GUIManager.holdcount > 25 && GUIManager.holdcount % 2 == 0)
          right = true;
      }
      if ((double) uis.moveUp > 0.4 && (double) GUIManager.lastUIS.moveUp <= 0.4)
        up = true;
      if ((double) uis.moveDown > 0.4 && (double) GUIManager.lastUIS.moveDown <= 0.4)
        down = true;
      if (uis.spacebar == UserInputStatus.InputState.Pressed)
        action1 = true;
      try
      {
        foreach (IGUI currentHuD in GUIManager.currentHUDs)
          currentHuD.Input(left, right, up, down, action1, (double) uis.moveDown > 0.4 || uis.spacebar == UserInputStatus.InputState.Held, uis.alt, game);
      }
      catch (Exception ex)
      {
        Game1.Log("An IHUD.Input has failed", BreadcrumbLevel.Error, "hud");
      }
      GUIManager.lastUIS = uis;
    }
  }
}
