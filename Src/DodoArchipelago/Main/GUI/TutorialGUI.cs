
// Type: DodoTheGame.GUI.TutorialGUI

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace DodoTheGame.GUI
{
  internal class TutorialGUI : IGUI
  {
    public Sprite animatedBackground;

    private bool closing;

    //Experimental 
    private int RetourButtonTimer;
    private float timer;
    public Texture2D retour;
    public Texture2D retour_selected;

    //public Texture2D mainbackground;
    //public Texture2D tutorialbackground;

    public event EventHandler Opened;

    public event EventHandler Closed;

    public int Layer => 200; //?
    public bool LockGameInput => true;
    public bool IsObstructing => false; //?
    public bool ReadyToRemove { get; private set; }
   

    // Draw
    public void Draw(SpriteBatch spriteBatch, Game1 game, GameTime gameTime)
    {
      this.animatedBackground.backwardAnimation = this.closing;
      
      this.animatedBackground.Draw(spriteBatch, new Vector2(265f, 120f), gameTime);

      //!
      //Recorder.RDraw(spriteBatch, this.mainbackground, new Vector2(0.0f, 0.0f), Color.White);

      //!
      //Recorder.RDraw(spriteBatch, this.tutorialbackground, new Vector2(0.0f,(float)(-1.0 * 0 + 600.0)), Color.White * 1f);

      if (this.closing && this.animatedBackground.CurrentFrame == 0)
        this.ReadyToRemove = true;

      if (this.closing)
        return;

      int currentFrame = this.animatedBackground.CurrentFrame;
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
            //if (this.animatedBackground.CurrentFrame >= 0)
            //{
            if ( !(action1 | left | up | down | right) )
            {
                  //if (this.animatedBackground.CurrentFrame != this.animatedBackground.TotalFrameCount - 1)
                    return;
            }
            //}

        //this.Close();
        GUIManager.ClearThenSet((IGUI)GUIManager.mainmenu);
     }

    public void Close()
    {
            this.closing = true;
            
            EventHandler closed = this.Closed;

            if (closed != null)
                closed((object)this, EventArgs.Empty);

            this.ReadyToRemove = true;
        }

    public void Open()
    {
      this.animatedBackground.ResetAnimation();
          
        EventHandler opened = this.Opened;
        if (opened != null)
            opened((object)this, EventArgs.Empty);

        this.ReadyToRemove = false;

        this.closing = false; // ?
    }
  }
}
