
// Type: DodoTheGame.Sprite

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DodoTheGame
{
  public class Sprite
  {
    public bool animated;
    public bool loopAnimation = true;
    public bool backwardAnimation;
    public string name;
    public int height;
    private int width;
    public Texture2D fullTexture;
    public bool horizontalMirroring;
    public bool verticalMirroring;
    private int currentElapsedMilliseconds;
    public bool autoUpdate = true;
    public List<SubSprite> groundSubsprite;
    public List<SubSprite> subSprites;

    public int CurrentFrame { get; set; }

    private int AltasLines => this.fullTexture.Height / this.height;

    public int MillisecondsPerFrame { get; set; }

    public int Width
    {
      get => this.width != 0 ? this.width : this.fullTexture.Width;
      set => this.width = value;
    }

    public int FrameCountPerAtlasLine
    {
        get
        {
            return this.fullTexture != null && this.animated ? this.fullTexture.Width / this.width : 0;
        }

       
    }

    public int TotalFrameCount
    {
      get
      {
        return this.fullTexture != null && this.animated 
                    ? this.fullTexture.Width / this.width * this.AltasLines 
                    : 0;
      }
    }

    public Sprite()
    {
    }

    public Sprite(string name, Texture2D texture, List<SubSprite> ssList = null, bool horizontalMirror = false)
    {
      this.subSprites = ssList ?? new List<SubSprite>();
      this.name = name;
      this.fullTexture = texture;

      if (this.fullTexture != null)
        this.height = this.fullTexture.Height;
      else
        this.height = 1;
      
      this.currentElapsedMilliseconds = 0;
      this.horizontalMirroring = horizontalMirror;
    }

        public void Draw
        (
          SpriteBatch spriteBatch,
          Vector2 location,
          GameTime gametime,
          SpriteEffects globaleffect = SpriteEffects.None,
          Color? colorn = null,
          double nightFactor = 1.0,
          double rotation = 0.0,
          bool inReachEffect = false
        )
        {
          SpriteEffects spriteEffects = globaleffect;

        if (this.horizontalMirroring)
            spriteEffects = globaleffect == SpriteEffects.FlipHorizontally
                        ? SpriteEffects.None
                        : SpriteEffects.FlipHorizontally;

        if (this.verticalMirroring)
            spriteEffects = globaleffect == SpriteEffects.FlipVertically
                        ? SpriteEffects.None
                        : SpriteEffects.FlipVertically;

        Color color = colorn ?? Color.White;

        foreach (SubSprite subSprite in this.subSprites)
        {
            if (subSprite.FullTexture == null)
                throw new Exception("null subSprite");

            if (!subSprite.aboveMainSprite && !subSprite.renderOnCommonShadowBatch)
            {
                if (subSprite.animated)
                    subSprite.CurrentFrame = this.CurrentFrame;
                subSprite.Draw(spriteBatch, new Vector2(location.X, location.Y), gametime,
                    spriteEffects, nightFactor);
            }
        }

        Texture2D texture = inReachEffect
                    ? Game1.TextureBrightnessEffect(this.fullTexture, 0.12f)
                    : this.fullTexture;

        if (this.animated)
        {
            if (this.autoUpdate)
                this.currentElapsedMilliseconds +=
                                (int)Math.Round(gametime.ElapsedGameTime.TotalMilliseconds)
                                * (int)Convert.ToInt16(Math.Round(DayCycle.timeSpeed, 0));
            if (this.currentElapsedMilliseconds >= this.MillisecondsPerFrame)
            {
                this.currentElapsedMilliseconds = 0;
                if (this.backwardAnimation)
                    --this.CurrentFrame;
                else
                    ++this.CurrentFrame;
                if (this.CurrentFrame < 0)
                    this.CurrentFrame = this.loopAnimation ? this.TotalFrameCount - 1 : 0;
                if (this.CurrentFrame > this.TotalFrameCount - 1)
                    this.CurrentFrame = this.loopAnimation ? 0 : this.TotalFrameCount - 1;
            }


            Rectangle rectangle = new Rectangle(this.Width *
                (this.CurrentFrame /* %1 */), this.height
                * (this.CurrentFrame /* /1 */), this.Width, this.height);

            // HACK 1
            if (this.FrameCountPerAtlasLine != 0)
            {
                rectangle = new Rectangle(this.Width *
                    (this.CurrentFrame % this.FrameCountPerAtlasLine), this.height
                    * (this.CurrentFrame / this.FrameCountPerAtlasLine), this.Width, this.height);
            }
            else
            {
                if (this.name != "volcan")
                    System.Diagnostics.Debug.WriteLine("[alert] Sprite " +
                        this.name + " (texture) damaged! FrameCountPerAtlasLine= ",
                        this.FrameCountPerAtlasLine);
                else
                { }
            }

            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y,
                this.Width, this.height);

                // HACK 2
                if (texture == null)
                {
                    texture = new Texture2D(Game1.graphics.GraphicsDevice, 100, 100);

                    System.Diagnostics.Debug.WriteLine("[alert] Sprite " +
                        this.name + " texture is null. Creating fake texture...");
                }
                else
                {
                    
                }

            Recorder.RDraw(spriteBatch, texture, destinationRectangle, new Rectangle?(rectangle), color,
                Convert.ToSingle(rotation), Vector2.Zero, spriteEffects, 0.0f);
        }
        else if (this.fullTexture == null)
        {
            System.Diagnostics.Debug.WriteLine("null Sprite.fullTexture: " + this.name);
        }
        else
        { 
            Recorder.RDraw(spriteBatch, texture, location, new Rectangle?(), color,
                Convert.ToSingle(rotation), new Vector2(0.0f, 0.0f), new Vector2(1f, 1f), spriteEffects, 0.0f);
        }



        foreach (SubSprite subSprite in this.subSprites)
        {
          if (subSprite.aboveMainSprite)
            subSprite.Draw(spriteBatch, location, gametime, spriteEffects, nightFactor);
        }
    }

    public void DrawShadow(
      SpriteBatch spriteBatch,
      Vector2 location,
      GameTime gametime,
      SpriteEffects globaleffect = SpriteEffects.None,
      Color? colorn = null,
      double nightFactor = 1.0,
      double rotation = 0.0)
    {
      SpriteEffects effect = globaleffect;
      if (this.horizontalMirroring)
        effect = globaleffect == SpriteEffects.FlipHorizontally ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
      if (this.verticalMirroring)
        effect = globaleffect == SpriteEffects.FlipVertically ? SpriteEffects.None : SpriteEffects.FlipVertically;
      foreach (SubSprite subSprite in this.subSprites.Where<SubSprite>(
          (Func<SubSprite, bool>) (p => p.renderOnCommonShadowBatch && !p.aboveMainSprite)))
      {
        if (subSprite.animated)
          subSprite.CurrentFrame = this.CurrentFrame;
        if (effect == SpriteEffects.FlipHorizontally || subSprite.mirror)
          subSprite.Draw(spriteBatch, new Vector2(location.X, location.Y), gametime, effect, nightFactor);
        else
          subSprite.Draw(spriteBatch, new Vector2(location.X, location.Y), gametime, effect, nightFactor);
      }
    }

    public void Update(GameTime gameTime)
    {
      if (this.autoUpdate)
        return;

      if 
      (
            this.name == "dodo/bicycle1" 
            || this.name == "dodo/bicycle2"
            || this.name == "dodo/bicycle3new" 
            || this.name == "loading_feather"
      )
        this.currentElapsedMilliseconds += (int) Math.Round(gameTime.ElapsedGameTime.TotalMilliseconds);
      else
        this.currentElapsedMilliseconds += (int) Math.Round(gameTime.ElapsedGameTime.TotalMilliseconds) 
                    * (int) Convert.ToInt16(Math.Round(DayCycle.timeSpeed, 0));
      
    }

    public void DrawSubsprite(
      Vector2 backgroundLocation,
      SpriteBatch spriteBatch,
      SubSprite sub,
      float nightFactor,
      Vector2 spriteLocation)
    {
      float num1 = sub.opacity;
      if (sub.disappearAtNight)
      {
        float num2 = Convert.ToSingle(nightFactor) + 0.18f;
        if ((double) num2 > 1.0)
          num2 = 1f;
        num1 = sub.opacity * num2;
      }
      Recorder.RDraw(spriteBatch, sub.FullTexture, sub.mirror
          ? new Vector2(backgroundLocation.X + spriteLocation.X + sub.offsetOnReverse.X, 
          backgroundLocation.Y + spriteLocation.Y + sub.offsetOnReverse.Y) 
          : new Vector2(backgroundLocation.X + spriteLocation.X + sub.offset.X,
          backgroundLocation.Y + spriteLocation.Y + sub.offset.Y), Color.White * num1);
    }

    public void ResetAnimation()
    {
      this.currentElapsedMilliseconds = 0;
      this.CurrentFrame = 0;
    }

    public Sprite Duplicate()
    {
      return new Sprite()
      {
        animated = this.animated,
        loopAnimation = this.loopAnimation,
        backwardAnimation = this.backwardAnimation,
        name = this.name,
        CurrentFrame = this.CurrentFrame,
        height = this.height,
        Width = this.width,
        fullTexture = this.fullTexture,
        horizontalMirroring = this.horizontalMirroring,
        verticalMirroring = this.verticalMirroring,
        autoUpdate = this.autoUpdate,
        MillisecondsPerFrame = this.MillisecondsPerFrame,
        groundSubsprite = this.groundSubsprite,
        subSprites = this.subSprites
      };
    }
  }
}
