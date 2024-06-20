// Decompiled with JetBrains decompiler
// Type: DodoTheGame.SubSprite
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace DodoTheGame
{
  internal class SubSprite
  {
    public bool animated;
    public bool loopAnimation = true;
    public bool backwardAnimation;
    public int height;
    public int width;
    private double currentElapsedMilliseconds;
    public bool autoUpdate = true;
    public float opacity = 1f;
    public bool disappearAtNight = true;
    public bool mirror;
    public bool aboveMainSprite;
    public bool renderOnCommonShadowBatch = true;
    public Vector2 offset;
    public Vector2 offsetOnReverse;

    public int CurrentFrame { get; set; }

    private int AltasLines => this.FullTexture.Height / this.height;

    public int MillisecondsPerFrame { get; set; }

    public int FrameCountPerAtlasLine
    {
      get => this.FullTexture != null && this.animated ? this.FullTexture.Width / this.width : 0;
    }

    public int TotalFrameCount
    {
      get
      {
        return this.FullTexture != null && this.animated ? this.FullTexture.Width / this.width * this.AltasLines : 0;
      }
    }

    public Texture2D FullTexture { get; set; }

    public void Draw(
      SpriteBatch spriteBatch,
      Vector2 location,
      GameTime gametime,
      SpriteEffects effect = SpriteEffects.None,
      double nightFactor = 1.0)
    {
      if (this.FullTexture == null)
        throw new Exception("null subSprite");
      float num = this.opacity;
      if (this.disappearAtNight)
        num = this.opacity * (float) (((double) Convert.ToSingle(nightFactor) + 0.60000002384185791) / 1.6000000238418579);
      if (this.animated)
      {
        Rectangle rectangle = new Rectangle(this.width * (this.CurrentFrame % this.FrameCountPerAtlasLine), this.height * (this.CurrentFrame / this.FrameCountPerAtlasLine), this.width, this.height);
        Rectangle destinationRectangle = effect == SpriteEffects.FlipHorizontally || this.mirror ? new Rectangle((int) ((double) location.X + (double) this.offsetOnReverse.X), (int) ((double) location.Y + (double) this.offsetOnReverse.Y), this.width, this.height) : new Rectangle((int) ((double) location.X + (double) this.offset.X), (int) ((double) location.Y + (double) this.offset.Y), this.width, this.height);
        Recorder.RDraw(spriteBatch, this.FullTexture, destinationRectangle, new Rectangle?(rectangle), Color.White * num, 0.0f, Vector2.Zero, effect, 0.0f);
      }
      else if (effect == SpriteEffects.FlipHorizontally || this.mirror)
        Recorder.RDraw(spriteBatch, this.FullTexture, new Vector2(location.X + this.offsetOnReverse.X, location.Y + this.offsetOnReverse.Y), new Rectangle?(), Color.White * num, 0.0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.FlipHorizontally, 0.0f);
      else
        Recorder.RDraw(spriteBatch, this.FullTexture, new Vector2(location.X + this.offset.X, location.Y + this.offset.Y), Color.White * num);
    }

    public SubSprite()
    {
    }

    public SubSprite(
      Texture2D texture,
      Vector2 offst,
      Vector2? offstOnReverse = null,
      float opacity = 1f,
      bool mirror = false)
    {
      this.FullTexture = texture;
      this.height = this.FullTexture.Height;
      this.width = this.FullTexture.Width;
      this.offset = offst;
      this.mirror = mirror;
      this.offsetOnReverse = offstOnReverse.HasValue ? offstOnReverse.Value : offst;
      this.opacity = opacity;
    }
  }
}
