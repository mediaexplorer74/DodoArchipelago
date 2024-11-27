
// Type: DodoTheGame.GUI.InteractGUI

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace DodoTheGame.GUI
{
  internal class InteractGUI : IGUI
  {
    public Texture2D up;
    public Texture2D down;
    public Texture2D left;
    public Texture2D right;
    public Texture2D upsw;
    public Texture2D downsw;
    public Texture2D leftsw;
    public Texture2D rightsw;
    public Texture2D a;
    public Texture2D e;
    public Texture2D m;
    public Texture2D bag_icon;
    public Texture2D bike_icon;
    public Texture2D bicycle_icon;
    public Texture2D dir;
    public Texture2D dirup;
    public Texture2D dirupleft;
    public Texture2D dirleft;
    public Texture2D dirleftdown;
    public Texture2D dirdown;
    public Texture2D dirdownright;
    public Texture2D dirright;
    public Texture2D dirupright;

    private float compassFadeOut;
    private float compassOpacity;

    public bool LockGameInput => false;

    public bool IsObstructing => false;

    public int Layer => 80;

    public bool ReadyToRemove { get; private set; }

    public void Draw(SpriteBatch spriteBatch, Game1 game, GameTime gameTime)
    {
      bool flag = false;
      Vector2 vector2 = new Vector2(9000f, 7950f);
      if (((double) Game1.player.walkMovementIdleTime > 300.0 || Game1.world.Level == 0) 
                && Math.Sqrt(Math.Pow((double) Game1.player.location.X - (double) vector2.X, 2.0)
                + Math.Pow((double) Game1.player.location.Y - (double) vector2.Y, 2.0)) > 750.0)
      flag = true;

      if (flag || (double) this.compassOpacity > 0.0)
      {
        if (flag)
        {
          this.compassOpacity += 0.05f;
          this.compassOpacity = (double) this.compassOpacity > 1.0 ? 1f : this.compassOpacity;
        }
        else
        {
          this.compassOpacity -= 0.05f;
          this.compassOpacity = (double) this.compassOpacity < 0.0 ? 0.0f : this.compassOpacity;
        }

        double num = Math.Atan2((double) Game1.player.location.Y - (double) vector2.Y, 
            (double) Game1.player.location.X - (double) vector2.X) * 180.0 / Math.PI;
        
        Vector2 location = Vector2.Zero;
        
        if (num >= -135.0 && num <= -45.0)
        {
          float single = Convert.ToSingle(Math.Round(10.0 + 1190.0 * (Math.Abs(num + 45.0) / 90.0)));

          this.dir = (double) single <= 820.0
                        ? ((double) single >= 460.0 ? this.dirdown : this.dirleftdown) 
                        : this.dirdownright;
          float y = (double) single <= 880.0 
                        ? ((double) single >= 350.0 ? 640f : 555f) 
                        : 515f;
          location = new Vector2(single, y);
        }
        else if (num >= 45.0 && num < 135.0)
        {
          float single = Convert.ToSingle(Math.Round(10.0 + 1190.0 * ((num - 45.0) / 90.0)));

          this.dir = (double) single <= 820.0 
                        ? ((double) single >= 460.0 ? this.dirup : this.dirupleft) 
                        : this.dirupright;

          location = new Vector2(single, 10f);
        }
        else if (num > -45.0 && num < 45.0)
        {
          float single = Convert.ToSingle(Math.Round(10.0 + 630.0 * ((num * -1.0 + 45.0) / 90.0)));

          this.dir = (double) single <= 480.0 
                        ? ((double) single >= 240.0 ? this.dirleft 
                        : this.dirupleft) : this.dirleftdown;

          location = new Vector2(10f, (double) single < 555.0 ? single : 555f);
        }
        else if (num >= 135.0 && num <= 180.0 || num >= -180.0 && num < -135.0)
        {
          float single = Convert.ToSingle(Math.Round(10.0 + 630.0 * (num < 135.0 || num > 180.0
              ? (num + 180.0) / 90.0 + 0.5
              : (num - 135.0) / 90.0)));
         
          this.dir = (double) single <= 480.0 
                        ? ((double) single >= 240.0 ? this.dirright : this.dirupright) 
                        : this.dirdownright;

          location = new Vector2(1200f, (double) single > 515.0 ? 515f : single);
        }
        Recorder.RDraw(spriteBatch, this.dir, location, Color.White * this.compassOpacity);
      }

      float num1 = 0.4f;
      float num2 = 0.4f;
      float num3 = 0.4f;
      float num4 = 0.4f;
      float num5 = 1f;
      float num6 = 1f;
      float num7 = 1f;
      float num8 = 1f;
      float num9 = 1f;
      float num10 = 1f;
      string text1 = "";
      string text2 = "";
      string text3 = "";
      string text4 = "";

      Vector2 renderSize = Game1.renderSize;

      if (Game1.player.inReachObject != null)
      {
        if (Game1.player.inReachObject.Interactions[3] != null
                    && Game1.player.inReachObject.Interactions[3]
                    .ComputeShowState(Game1.player.inReachObject, Game1.player))
        {
          num1 = 1f;
          text1 = Game1.player.inReachObject.Interactions[3].ShowName;
        }
        if (Game1.player.inReachObject.Interactions[2] != null 
                    && Game1.player.inReachObject.Interactions[2]
                    .ComputeShowState(Game1.player.inReachObject, Game1.player))
        {
          num3 = 1f;
          text2 = Game1.player.inReachObject.Interactions[2].ShowName;
        }
        if (Game1.player.inReachObject.Interactions[0] != null
                    && Game1.player.inReachObject.Interactions[0]
                    .ComputeShowState(Game1.player.inReachObject, Game1.player))
        {
          num2 = 1f;
          text3 = Game1.player.inReachObject.Interactions[0].ShowName;
        }
        if (Game1.player.inReachObject.Interactions[1] != null
                    && Game1.player.inReachObject.Interactions[1]
                    .ComputeShowState(Game1.player.inReachObject, Game1.player))
        {
          num4 = 1f;
          text4 = Game1.player.inReachObject.Interactions[1].ShowName;
        }
      }

      if (game.userInput.inputMethod == 1 || game.userInput.inputMethod == 3)
      {
        Recorder.RDraw(spriteBatch, this.up, new Vector2((float) ((double) renderSize.X - 167.0 - 10.0), 
            (float) ((double) renderSize.Y - 92.0 - 10.0)), Color.White * num1);

        Recorder.RDraw(spriteBatch, this.left, 
            new Vector2((float) ((double) renderSize.X - 200.0 - 20.0), renderSize.Y - 70f), 
            Color.White * num2);

        Recorder.RDraw(spriteBatch, this.down, 
            new Vector2((float) ((double) renderSize.X - 167.0 - 10.0), renderSize.Y - 60f), 
            Color.White * num3);

        Recorder.RDraw(spriteBatch, this.right, 
            new Vector2(renderSize.X - 134f, renderSize.Y - 70f), Color.White * num4);

        Recorder.RDraw(spriteBatch, this.a, new Vector2(25f, renderSize.Y - 65f), Color.White * num5);

        Recorder.RDraw(spriteBatch, this.bag_icon, 
            new Vector2(75f, renderSize.Y - 70f), Color.White * num8);

        if (Game1.player.unlockedPlayerTools[PlayerUnlockables.PlayerUnlockable.Bike])
        {
          Recorder.RDraw(spriteBatch, this.e, new Vector2(130f, renderSize.Y - 65f),
              Color.White * num6);
          Recorder.RDraw(spriteBatch, this.bike_icon, new Vector2(180f, renderSize.Y - 70f), 
              Color.White * num9);
        }
        if (Game1.player.unlockedPlayerTools[PlayerUnlockables.PlayerUnlockable.Bicycle])
        {
          Recorder.RDraw(spriteBatch, this.m, new Vector2(245f, renderSize.Y - 65f), Color.White * num7);
          Recorder.RDraw(spriteBatch, this.bicycle_icon, new Vector2(295f, renderSize.Y - 70f), 
              Color.White * num10);
        }
      }
      else if (game.userInput.inputMethod == 2)
      {
        Recorder.RDraw(spriteBatch, this.upsw, new Vector2((float) ((double) renderSize.X - 167.0 - 10.0),
            (float) ((double) renderSize.Y - 92.0 - 10.0)), Color.White * num1);
        Recorder.RDraw(spriteBatch, this.leftsw, new Vector2((float) ((double) renderSize.X - 200.0 - 20.0), 
            renderSize.Y - 70f), 
            Color.White * num2);
        Recorder.RDraw(spriteBatch, this.downsw, new Vector2((float) ((double) renderSize.X - 167.0 - 10.0), 
            renderSize.Y - 60f),
            Color.White * num3);
        Recorder.RDraw(spriteBatch, this.rightsw, new Vector2(renderSize.X - 134f, renderSize.Y - 70f),
            Color.White * num4);
      }
      if (text3 != "")
        Recorder.RDrawString(spriteBatch, Game1.rouliMSpriteFont, text3, 
            new Vector2((float) ((double) renderSize.X - 205.0 - 
                               (double) Game1.rouliMSpriteFont.MeasureString(text3).X - 20.0), 
                            renderSize.Y - 67f), 
            Color.Black);
      if (text4 != "")
        Recorder.RDrawString(spriteBatch, Game1.rouliMSpriteFont, text4, 
            new Vector2(renderSize.X - 99f, renderSize.Y - 67f), Color.Black);
      if (text1 != "")
        Recorder.RDrawString(spriteBatch, Game1.rouliMSpriteFont, text1, 
            new Vector2((float) ((double) renderSize.X - 150.0 
            - (double) Game1.rouliMSpriteFont.MeasureString(text1).X / 2.0 - 10.0),
            (float) ((double) renderSize.Y - 115.0 - 10.0)),
            Color.Black);

      if (!(text2 != ""))
        return;
      Recorder.RDrawString(spriteBatch, Game1.rouliMSpriteFont, text2, 
          new Vector2((float) ((double) renderSize.X
          - 150.0 - (double) Game1.rouliMSpriteFont.MeasureString(text2).X / 2.0 - 10.0), 
            renderSize.Y - 33f), 
          Color.Black);
    }

    public void Input
    (
      bool left, bool right, bool up,  bool down,
      bool action1,
      bool hold,
      UserInputStatus.InputState alt,
      Game1 game
    )
    {
      if (action1 == true)
        System.Diagnostics.Debug.WriteLine("[InteractGUI] hold=" + hold.ToString()  + ", action1=" + action1);
    }

    public void Close()
    { 
        this.ReadyToRemove = true; 
    }

    public void Open() 
    { 
        this.ReadyToRemove = false; 
    }
  }
}
