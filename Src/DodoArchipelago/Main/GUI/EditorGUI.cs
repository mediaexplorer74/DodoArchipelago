// Type: DodoTheGame.GUI.EditorGUI

using DodoTheGame.Interactions;
using DodoTheGame.NPC;
using DodoTheGame.WorldObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace DodoTheGame.GUI
{
  internal class EditorGUI : IGUI
  {
    public Texture2D background;
    public int selectedPresetIndex = 0; //!
    public Preset selectedPreset = new Preset(); //!
    public string selectedPresetCategory = ""; //!
    public bool presetMenuOpen;
    public List<string> categoryList  = new List<string>(); //!
    public List<Tuple<Vector2, Vector2>> interactPoints = new List<Tuple<Vector2, Vector2>>(); //!
    public List<IWorldObject> woInTarget = new List<IWorldObject>(); //!
    public List<INPC> npcsInTarget = new List<INPC>();
    private Vector2 backgroundPosition;
    private int PathfindRequestId = 0; //!

    public int Layer => 400;

    public bool LockGameInput => true;

    public bool IsObstructing => false;

    public bool ReadyToRemove { get; private set; }

    internal void PathCallback(object sender, EventArgs e)
    {
      PathfoundEventArgs pathfoundEventArgs = (PathfoundEventArgs) e;
      if (pathfoundEventArgs.RequestId != this.PathfindRequestId)
        return;
      this.PathfindRequestId = 0;
      this.interactPoints = new List<Tuple<Vector2, Vector2>>();
      foreach (Vector2 vector2 in pathfoundEventArgs.Path)
        this.interactPoints.Add(new Tuple<Vector2, Vector2>(vector2 + this.backgroundPosition, vector2));
    }

    public void AddPoint(Vector2 point, Game1 game)
    {
      Vector2 vector2_1 = point;
      this.backgroundPosition = new Vector2(Game1.dodoScreenLocation.X 
          - Game1.player.location.X, Game1.dodoScreenLocation.Y - Game1.player.location.Y);
      Vector2 vector2_2 = vector2_1 - this.backgroundPosition;
      foreach (IWorldObject worldObject in Game1.world.objects)
      {
        if (!this.woInTarget.Contains(worldObject) && (double) vector2_2.X
                    >= (double) worldObject.Location.X && (double) vector2_2.X
                    <= (double) worldObject.Location.X
                    + (double) worldObject.CurrentDrawSprite.Width 
                    && (double) vector2_2.Y >= (double) worldObject.Location.Y 
                    && (double) vector2_2.Y <= (double) worldObject.Location.Y 
                    + (double) worldObject.CurrentDrawSprite.height)
          this.woInTarget.Add(worldObject);
      }
      foreach (INPC npC in Game1.world.NPCs)
      {
        if (!this.npcsInTarget.Contains(npC) 
                    && (double) vector2_2.X >= (double) npC.Location.X
                    && (double) vector2_2.X <= (double) npC.Location.X 
                    + (double) npC.CurrentDrawSprite.Width && (double) vector2_2.Y
                    >= (double) npC.Location.Y 
                    && (double) vector2_2.Y <= (double) npC.Location.Y 
                    + (double) npC.CurrentDrawSprite.height)
          this.npcsInTarget.Add(npC);
      }
      this.interactPoints.Add(new Tuple<Vector2, Vector2>(vector2_1, vector2_2));
      int count = this.interactPoints.Count;
    }

    public void SetPoint(Vector2 point, Game1 game)
    {
      this.woInTarget = new List<IWorldObject>();
      this.npcsInTarget = new List<INPC>();
      this.interactPoints = new List<Tuple<Vector2, Vector2>>();
      this.AddPoint(point, game);
    }

    public void Draw(SpriteBatch spriteBatch, Game1 game, GameTime gameTime)
    {
      if (this.ReadyToRemove)
        return;
      Recorder.RDraw(spriteBatch, this.background, Vector2.Zero, Color.Black * 0.5f);
      if (this.interactPoints.Count == 1)
      {
        Vector2 vector2_1 = this.interactPoints[0].Item1;
        Vector2 vector2_2 = this.interactPoints[0].Item2;
        int x = (int) Game1.arial23SpriteFont.MeasureString("(" 
            + vector2_2.X.ToString() + " " + vector2_2.Y.ToString() + ") ").X;
        Recorder.RDrawString(spriteBatch, Game1.arial23SpriteFont, "(" 
            + vector2_2.X.ToString() + " " + vector2_2.Y.ToString() + ") ",
            new Vector2(500f, 20f), Color.White);
        Recorder.RDrawString(spriteBatch, Game1.arialSpriteFont, "(" 
            + vector2_1.X.ToString() + " " + vector2_1.Y.ToString() + ") on screen",
            new Vector2((float) (500 + x), 38f), Color.White);
      }
      else
        Recorder.RDrawString(spriteBatch, Game1.arial23SpriteFont, 
            this.interactPoints.Count.ToString() + " select points", 
            new Vector2(500f, 20f), Color.White);
      Recorder.RDrawString(spriteBatch, Game1.arialSpriteFont, 
          this.woInTarget.Count.ToString() + " object(s) and " 
          + this.npcsInTarget.Count.ToString() + " NPC(s) selected", new Vector2(500f, 52f),
          Color.White);
      if (this.woInTarget.Count > 0)
        Recorder.RDrawString(spriteBatch, Game1.arialSpriteFont,
            "Ctrl+D to copy JSON saving data (Windows only)", new Vector2(500f, 66f), 
            Color.White);
      int y1 = 24;
      foreach (IWorldObject worldObject in this.woInTarget)
      {
        Texture2D box1 = EditorGUI.GenerateBox(
            new Vector2((float) worldObject.CurrentDrawSprite.Width, 
            (float) worldObject.CurrentDrawSprite.height), Color.LimeGreen * 0.4f);
        Recorder.RDraw(spriteBatch, box1, 
            new Vector2(this.backgroundPosition.X + worldObject.Location.X, 
            this.backgroundPosition.Y + worldObject.Location.Y), Color.White);

        foreach (SubSprite subSprite in worldObject.CurrentDrawSprite.subSprites)
        {
          Texture2D box2 = EditorGUI.GenerateBox(new Vector2((float) subSprite.width,
              (float) subSprite.height), Color.GreenYellow * 0.4f);
          Vector2 location = new Vector2(this.backgroundPosition.X 
              + worldObject.Location.X + subSprite.offset.X, 
              this.backgroundPosition.Y
              + worldObject.Location.Y + subSprite.offset.Y);
          Recorder.RDraw(spriteBatch, box2, location, Color.White);
        }
        if (worldObject.Hitbox != null && worldObject.Hitbox.Count > 0)
        {
          foreach (Rectangle rectangle in worldObject.Hitbox)
          {
            if (rectangle.Width > 0 && rectangle.Height > 0)
            {
              Texture2D box3 = EditorGUI.GenerateBox(new Vector2((float) rectangle.Width, 
                  (float) rectangle.Height), Color.Red * 0.5f);
              Recorder.RDraw(spriteBatch, box3, new Vector2(this.backgroundPosition.X
                  + worldObject.Location.X + (float) rectangle.X, this.backgroundPosition.Y
                  + worldObject.Location.Y + (float) rectangle.Y), Color.White);
            }
          }
        }
        Recorder.RDraw(spriteBatch, Game1.debugCursor2, new Vector2((float) (
            (double) game.backgroundPosition.X + (double) worldObject.Epicenter.X - 5.0),
            (float) ((double) game.backgroundPosition.Y + (double) worldObject.Epicenter.Y - 5.0)), 
            Color.White);

        Color color1 = Color.White;
        if (game.woModifiedInGameEditor.Contains(worldObject))
          color1 = Color.Gold;
        int x = (int) Game1.arialSpriteFont.MeasureString(worldObject.ObjectId 
            + " (" + worldObject.Location.X.ToString() + " " + worldObject.Location.Y.ToString() 
            + ")").X;
        SpriteBatch spriteBatch1 = spriteBatch;
        SpriteFont arialSpriteFont = Game1.arialSpriteFont;
        string[] strArray = new string[6]
        {
          worldObject.ObjectId,
          " (",
          null,
          null,
          null,
          null
        };
        Vector2 location1 = worldObject.Location;
        strArray[2] = location1.X.ToString();
        strArray[3] = " ";
        location1 = worldObject.Location;
        strArray[4] = location1.Y.ToString();
        strArray[5] = ")";
        string text = string.Concat(strArray);
        Vector2 location2 = new Vector2((float) (1270 - x), (float) y1);
        Color color2 = color1;
        Recorder.RDrawString(spriteBatch1, arialSpriteFont, text, location2, color2);
        y1 += 14;
      }
      foreach (INPC npc in this.npcsInTarget)
      {
        Texture2D box4 = EditorGUI.GenerateBox(new Vector2((float) npc.CurrentDrawSprite.Width, 
            (float) npc.CurrentDrawSprite.height), Color.LimeGreen * 0.4f);
        Recorder.RDraw(spriteBatch, box4, new Vector2(this.backgroundPosition.X + npc.Location.X, 
            this.backgroundPosition.Y + npc.Location.Y), Color.White);
        foreach (SubSprite subSprite in npc.CurrentDrawSprite.subSprites)
        {
          Texture2D box5 = EditorGUI.GenerateBox(new Vector2((float) subSprite.width, 
              (float) subSprite.height), Color.GreenYellow * 0.4f);
          Vector2 location = new Vector2(this.backgroundPosition.X + npc.Location.X 
              + subSprite.offset.X, this.backgroundPosition.Y + npc.Location.Y + subSprite.offset.Y);
          Recorder.RDraw(spriteBatch, box5, location, Color.White);
        }
        foreach (Rectangle rectangle in npc.Hitbox)
        {
          if (rectangle.Width > 0 && rectangle.Height > 0)
          {
            Texture2D box6 = EditorGUI.GenerateBox(new Vector2((float) rectangle.Width, 
                (float) rectangle.Height), Color.Red * 0.5f);
            Recorder.RDraw(spriteBatch, box6, new Vector2(
                this.backgroundPosition.X + npc.Location.X + (float) rectangle.X, 
                this.backgroundPosition.Y + npc.Location.Y + (float) rectangle.Y),
                Color.White);
          }
        }
        Recorder.RDraw(spriteBatch, EditorGUI.GenerateBox(new Vector2(100f, 1f), Color.Aqua),
            new Vector2(npc.Location.X + game.backgroundPosition.X, game.backgroundPosition.Y 
            + (float) npc.FeetY), Color.White);
      }
      Recorder.RDraw(spriteBatch, Game1.redline, new Vector2(Game1.dodoScreenLocation.X, 
          game.backgroundPosition.Y + (float) Game1.player.CurrentFeetY), Color.White);
      if (Game1.player.currentMovementType == Player.DodoMovement.Bike)
      {
        Recorder.RDraw(spriteBatch, EditorGUI.GenerateBox(new Vector2(170f, 1f), Color.Purple), 
            new Vector2((float) ((double) game.backgroundPosition.X 
            + (double) Game1.player.location.X - 23.0), (float) (
            (double) game.backgroundPosition.Y + (double) Game1.player.location.Y + 75.0)), 
            Color.White);
        Recorder.RDraw(spriteBatch, EditorGUI.GenerateBox(new Vector2(170f, 1f), Color.Purple),
            new Vector2((float) ((double) game.backgroundPosition.X 
            + (double) Game1.player.location.X - 23.0), (float) (
            (double) game.backgroundPosition.Y + (double) Game1.player.location.Y + 75.0 + 16.0)), 
            Color.White);
        Recorder.RDraw(spriteBatch, EditorGUI.GenerateBox(new Vector2(1f, 16f), Color.Purple), 
            new Vector2((float) ((double) game.backgroundPosition.X 
            + (double) Game1.player.location.X - 23.0 + 170.0), (float) (
            (double) game.backgroundPosition.Y + (double) Game1.player.location.Y + 75.0)), 
            Color.White);
        Recorder.RDraw(spriteBatch, EditorGUI.GenerateBox(new Vector2(1f, 16f), Color.Purple), 
            new Vector2((float) ((double) game.backgroundPosition.X 
            + (double) Game1.player.location.X - 23.0), (float) (
            (double) game.backgroundPosition.Y + (double) Game1.player.location.Y + 75.0)), 
            Color.White);
      }
      Recorder.RDrawString(spriteBatch, Game1.arialSpriteFont, "Selected:", new Vector2(1200f, 10f),
          Color.White);

      if (!this.presetMenuOpen)
      {
        if (this.selectedPreset == null)
          this.selectedPreset = Game1.presetList.First<Preset>();
        Recorder.RDrawString(spriteBatch, Game1.arialSpriteFont, this.selectedPreset.name, 
            new Vector2(950f, 24f), Color.DodgerBlue);
      }
      else
      {
        this.categoryList = new List<string>();
        foreach (Preset preset in Game1.presetList)
        {
          if (!this.categoryList.Contains(preset.category))
            this.categoryList.Add(preset.category);
        }
        if (this.selectedPresetCategory == null)
          this.selectedPresetCategory = this.categoryList.First<string>();
        int y2 = 24;
        foreach (string category in this.categoryList)
        {
          Color color = category == this.selectedPresetCategory 
                        ? Color.DodgerBlue 
                        : Color.White;
          Recorder.RDrawString(spriteBatch, Game1.arialSpriteFont, category, 
              new Vector2(900f, (float) y2), color);
          y2 += 14;
        }
        int y3 = 24;
        int num = 0;
        if (this.selectedPresetIndex < 0)
          this.selectedPresetIndex = 0;
        foreach (Preset preset in Game1.presetList)
        {
          if (preset.category == this.selectedPresetCategory)
          {
            if (num == this.selectedPresetIndex)
              this.selectedPreset = preset;
            Color color = num == this.selectedPresetIndex ? Color.DodgerBlue : Color.White;
            Recorder.RDrawString(spriteBatch, Game1.arialSpriteFont, preset.name, new Vector2(950f, 
                (float) y3), color);
            y3 += 14;
            ++num;
          }
        }
      }
      foreach (Tuple<Vector2, Vector2> interactPoint in this.interactPoints)
        Recorder.RDraw(spriteBatch, Game1.debugCursor, new Vector2(interactPoint.Item1.X - 5f,
            interactPoint.Item1.Y - 5f), Color.White);
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

    public void Input(
      bool left,
      bool right,
      bool up,
      bool down,
      bool action1,
      bool hold,
      UserInputStatus.InputState alt,
      Game1 game)
    {
      if (this.interactPoints.Count != 1)
        return;
      if (alt == UserInputStatus.InputState.Held & action1)
      {
        if (this.selectedPreset.buildOrUpgradeItems != null)
        {
          int totalMilliseconds = (int) DateTime.UtcNow.Subtract(
              new DateTime(2017, 9, 1)).TotalMilliseconds;

          Vector2 location = GUIManager.editorHUD.interactPoints.First<Tuple<Vector2, Vector2>>().Item2;

          BuildPoint buildPoint1 = new BuildPoint("edt-bp" + totalMilliseconds.ToString(), 
              Game1.buildPointSprite, location, epicenter: new Vector2?(
                  new Vector2(location.X + 20f, location.Y + 50f)));

          buildPoint1.ExtraReach = new Vector2() { Y = -8f };
          buildPoint1.ExtraFloorHeight = 20;
          buildPoint1.Interactions[3] = (IDodoInteraction) new Build(
              this.selectedPreset.buildOrUpgradeItems, this.selectedPreset);
          BuildPoint buildPoint2 = buildPoint1;
          Game1.world.objects.Add((IWorldObject) buildPoint2);
        }
        else
          Debug.WriteLine("[!] Cannot create BP from a Preset that doesn't have build items.");
      }
      else
      {
        if (!action1)
          return;

        IWorldObject worldObject = this.selectedPreset.MakeWOs(new List<Tuple<Vector2, string>>()
        {
          new Tuple<Vector2, string>(this.interactPoints[0].Item2,
          "edt" + ((int) DateTime.UtcNow.Subtract(new DateTime(2017, 9, 1))
          .TotalMilliseconds).ToString() + "-" + Game1.presetList[this.selectedPresetIndex].name)
        }).First<IWorldObject>();

        Game1.world.objects.Add(worldObject);
        game.woModifiedInGameEditor.Add(worldObject);
      }
    }

    public void Close() => this.ReadyToRemove = true;

    public void Open() => this.ReadyToRemove = false;
  }
}
