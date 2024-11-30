// Type: DodoTheGame.GUI.LoadGUI

using DodoTheGame.Cutscene;
using DodoTheGame.Localization;
using DodoTheGame.Saving;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
//using Windows.UI.Xaml.Shapes;


namespace DodoTheGame.GUI
{
  internal class LoadGUI : IGUI
  {
    public SaveInfo saveInfo1;
    public SaveInfo saveInfo2;
    public SaveInfo saveInfo3;
    public Texture2D mainbackground;
    public Texture2D bande1;
    public Texture2D bande2;
    public Texture2D bande3;
    public Texture2D img1;
    public Texture2D img2;
    public Texture2D img3;
    public Texture2D empty;
    public Texture2D error;
    public Texture2D marker1;
    public Texture2D marker2;
    public Texture2D marker3;
    public Texture2D background;
    public Texture2D slot;
    public Texture2D selectedslot;
    public Texture2D emptybin;
    public Texture2D selectedbin;
    public SpriteFont font26;
    public SpriteFont font22;
    public SpriteFont font16;
    private int selectedButton = 1;
    private float timer;

    public bool ReadyToRemove { get; private set; }

    public LoadGUI()
    {
      this.saveInfo1 = SaveHandler.GetSlotInfo(1, Game1.graphics.GraphicsDevice);
      this.saveInfo2 = SaveHandler.GetSlotInfo(2, Game1.graphics.GraphicsDevice);
      this.saveInfo3 = SaveHandler.GetSlotInfo(3, Game1.graphics.GraphicsDevice);
      this.GenerateThumbnails(Game1.graphics.GraphicsDevice);
    }

    public bool LockGameInput => true;

    public bool IsObstructing => false;

    public int Layer => 100;

    public void GenerateThumbnails(GraphicsDevice graphics)
    {

        if (this.saveInfo1 != null)
            this.img1 = this.saveInfo1.isValid
                        ? LoadGUI.GenerateThumbnail(this.saveInfo1.screenshot, graphics)
                        : this.error;
        else
            this.img1 = this.empty;


        if (this.saveInfo2 != null)
            this.img2 = this.saveInfo2.isValid
                        ? LoadGUI.GenerateThumbnail(this.saveInfo2.screenshot, graphics)
                        : this.error;
        else
            this.img2 = this.empty;

       if (this.saveInfo3 != null)
        this.img3 = this.saveInfo3.isValid
                    ? LoadGUI.GenerateThumbnail(this.saveInfo3.screenshot, graphics)
                    : this.error;
      else
        this.img3 = this.empty;
    }

    private static Texture2D GenerateThumbnail(Texture2D input, GraphicsDevice graphics)
    {
        Texture2D thumbnail = new Texture2D(graphics, 100, 100);
        if (input != null)
        {
            Texture2D texture2D = input;
            Microsoft.Xna.Framework.Rectangle rectangle = 
                new Microsoft.Xna.Framework.Rectangle(
                    340, 199, texture2D.Width - 680, texture2D.Height - 398);

            thumbnail = new Texture2D(graphics, rectangle.Width, rectangle.Height);
            Color[] data = new Color[rectangle.Width * rectangle.Height];
            texture2D.GetData<Color>(0, 
                new Microsoft.Xna.Framework.Rectangle?(rectangle), data, 0, data.Length);
            thumbnail.SetData<Color>(data);
        }
        else
        {
            Color[] data = new Color[100 * 100];
            thumbnail.SetData<Color>(data);
        }

      return thumbnail;
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
      if (up && this.selectedButton != 1 && this.selectedButton != 4)
        --this.selectedButton;

      if (down && this.selectedButton != 3 && this.selectedButton != 6)
        ++this.selectedButton;

      if (left && this.selectedButton != 1 && this.selectedButton != 2 && this.selectedButton != 3)
        this.selectedButton -= 3;

      if (right && this.selectedButton != 4 && this.selectedButton != 5 && this.selectedButton != 6)
        this.selectedButton += 3;

      bool flag = false;

      if (action1 && this.selectedButton == 1)
      {
        GUIManager.Clear();
        flag = !SaveHandler.IsSlotRegistered(1);
        SaveHandler.LoadGame(1, Game1.commonSprites, game);
      }
      else if (action1 && this.selectedButton == 2)
      {
        GUIManager.Clear();
        flag = !SaveHandler.IsSlotRegistered(2);
        SaveHandler.LoadGame(2, Game1.commonSprites, game);
      }
      else if (action1 && this.selectedButton == 3)
      {
        GUIManager.Clear();
        flag = !SaveHandler.IsSlotRegistered(3);
        SaveHandler.LoadGame(3, Game1.commonSprites, game);
      }
      else if (action1 && this.selectedButton == 4)
      {
        SaveHandler.EraseSlot(1);
        this.img1 = this.empty;
      }
      else if (action1 && this.selectedButton == 5)
      {
        SaveHandler.EraseSlot(2);
        this.img2 = this.empty;
      }
      else if (action1 && this.selectedButton == 6)
      {
        SaveHandler.EraseSlot(3);
        this.img3 = this.empty;
      }
      if (!flag)
        return;

      CutsceneManager.StartCutscene((ICutscene) new StoryIntroCutscene(),
          (GameTime) null, Game1.player, Game1.world);
    }

    public void Draw(SpriteBatch spriteBatch, Game1 game, GameTime gameTime)
    {
      this.timer += Convert.ToSingle(gameTime.ElapsedGameTime.Milliseconds) / 5f;
      Texture2D texture1;
      Texture2D texture2;
      Texture2D texture3;
      Texture2D texture4;
      Texture2D texture5;
      Texture2D texture6;

      switch (this.selectedButton)
      {
        case 1:
          texture1 = this.selectedslot;
          texture2 = this.slot;
          texture3 = this.slot;
          texture4 = this.emptybin;
          texture5 = this.emptybin;
          texture6 = this.emptybin;
          break;
        case 2:
          texture1 = this.slot;
          texture2 = this.selectedslot;
          texture3 = this.slot;
          texture4 = this.emptybin;
          texture5 = this.emptybin;
          texture6 = this.emptybin;
          break;
        case 3:
          texture1 = this.slot;
          texture2 = this.slot;
          texture3 = this.selectedslot;
          texture4 = this.emptybin;
          texture5 = this.emptybin;
          texture6 = this.emptybin;
          break;
        case 4:
          texture1 = this.slot;
          texture2 = this.slot;
          texture3 = this.slot;
          texture4 = this.selectedbin;
          texture5 = this.emptybin;
          texture6 = this.emptybin;
          break;
        case 5:
          texture1 = this.slot;
          texture2 = this.slot;
          texture3 = this.slot;
          texture4 = this.emptybin;
          texture5 = this.selectedbin;
          texture6 = this.emptybin;
          break;
        case 6:
          texture1 = this.slot;
          texture2 = this.slot;
          texture3 = this.slot;
          texture4 = this.emptybin;
          texture5 = this.emptybin;
          texture6 = this.selectedbin;
          break;
        default:
          texture1 = this.slot;
          texture2 = this.slot;
          texture3 = this.slot;
          texture4 = this.emptybin;
          texture5 = this.emptybin;
          texture6 = this.emptybin;
          break;
      }

      int int32 = Convert.ToInt32(
          Math.Round((double) Game1.renderSize.X / 2.0 - (double) (texture1.Width / 2), 0));

      Recorder.RDraw(spriteBatch, this.mainbackground, new Vector2(0.0f, 0.0f), Color.White);

      Recorder.RDraw(spriteBatch, this.bande1, 
          new Vector2((float) ((double) GUIManager.GUITimer 
          / 5.0 % ((double) Game1.renderSize.X + 500.0) 
          - 300.0),  0.0f), Color.White * 1f);

      Recorder.RDraw(spriteBatch, this.bande2, 
          new Vector2((float) (((double) GUIManager.GUITimer 
          / 5.0 + 450.0)%((double) Game1.renderSize.X + 500.0)
          - 300.0), 0.0f), Color.White * 1f);

      Recorder.RDraw(spriteBatch, this.bande3,
          new Vector2((float) (((double) GUIManager.GUITimer 
          / 5.0 + 900.0)%((double) Game1.renderSize.X + 500.0) - 300.0), 0.0f), Color.White * 1f);

      Recorder.RDraw(spriteBatch, this.bande2, 
          new Vector2((float) (((double) GUIManager.GUITimer 
          / 5.0 + 1350.0)%((double) Game1.renderSize.X 
          + 500.0) - 300.0), 0.0f), Color.White * 1f);

      Recorder.RDraw(spriteBatch, this.img1, 
          new Microsoft.Xna.Framework.Rectangle(int32 + 3, 155, 234, 125),
          Color.White);

      Recorder.RDraw(spriteBatch, this.img2, 
          new Microsoft.Xna.Framework.Rectangle(int32 + 3, 315, 234, 125),
          Color.White);

      Recorder.RDraw(spriteBatch, this.img3, 
          new Microsoft.Xna.Framework.Rectangle(int32 + 3, 475, 234, 125),
          Color.White);

      Recorder.RDraw(spriteBatch, texture1, new Vector2((float) int32, 152f), Color.White);
      Recorder.RDraw(spriteBatch, texture2, new Vector2((float) int32, 312f), Color.White);
      Recorder.RDraw(spriteBatch, texture3, new Vector2((float) int32, 472f), Color.White);
      Recorder.RDraw(spriteBatch, texture4, new Vector2((float) (int32 + texture1.Width + 10), 240f), 
          Color.White);
      Recorder.RDraw(spriteBatch, texture5, new Vector2((float) (int32 + texture1.Width + 10), 400f),
          Color.White);
      Recorder.RDraw(spriteBatch, texture6, new Vector2((float) (int32 + texture1.Width + 10), 560f),
          Color.White);
      Recorder.RDraw(spriteBatch, this.marker1, new Vector2((float) (int32 + 240), 158f), Color.White);

      if (this.saveInfo1 != null)
        if (this.saveInfo1.isValid)
      {
        Recorder.RDrawString(spriteBatch, this.font16, LoadGUI.FormatPlaytime(this.saveInfo1.playTime),
            new Vector2((float) (int32 + 246), 229f), Color.White);
        Recorder.RDrawString(spriteBatch, this.font22, LoadGUI.FormatDatetime(this.saveInfo1.saveTime),
            new Vector2((float) (int32 + 246), 249f), Color.White);
      }
      Recorder.RDraw(spriteBatch, this.marker2, new Vector2((float) (int32 + 240), 318f), Color.White);

            if (this.saveInfo2 != null)
                if (this.saveInfo2.isValid)
      {
        Recorder.RDrawString(spriteBatch, this.font16, LoadGUI.FormatPlaytime(this.saveInfo2.playTime),
            new Vector2((float) (int32 + 246), 389f), Color.White);
        Recorder.RDrawString(spriteBatch, this.font22, LoadGUI.FormatDatetime(this.saveInfo2.saveTime),
            new Vector2((float) (int32 + 246), 409f), Color.White);
      }

      Recorder.RDraw(spriteBatch, this.marker3, new Vector2((float) (int32 + 240), 478f), Color.White);

        if (this.saveInfo3 != null)
            if (this.saveInfo3.isValid)
            {
                Recorder.RDrawString(spriteBatch, this.font16, LoadGUI.FormatPlaytime(this.saveInfo3.playTime),
          new Vector2((float)(int32 + 246), 549f), Color.White);
                Recorder.RDrawString(spriteBatch, this.font22, LoadGUI.FormatDatetime(this.saveInfo3.saveTime),
                    new Vector2((float)(int32 + 246), 569f), Color.White);
            }
    }

    private static string FormatDatetime(DateTime dt)
    {
      return dt.Day.ToString().PadLeft(2, '0') + "/" + dt.Month.ToString().PadLeft(2, '0') + "/"
                + dt.Year.ToString().Substring(2, 2) + " "
                + dt.Hour.ToString().PadLeft(2, '0') + "h" + dt.Minute.ToString().PadLeft(2, '0');
    }

    private static string FormatPlaytime(int pt)
    {
      TimeSpan timeSpan = TimeSpan.FromSeconds((double) pt);
      return timeSpan.TotalMinutes < 60.0
                ? string.Format(LocalizationManager.GetString("PlaytimeMinutes"),
          (object) timeSpan.Minutes) 
                : string.Format(LocalizationManager.GetString("PlaytimeMinutesHours"),
                (object) Math.Floor(timeSpan.TotalHours), (object) timeSpan.Minutes);
    }

    public void Close() => this.ReadyToRemove = true;

    public void Open() => this.ReadyToRemove = false;
  }
}
