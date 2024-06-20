// Decompiled with JetBrains decompiler
// Type: DodoTheGame.NPC.PinkDodo
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace DodoTheGame.NPC
{
  internal class PinkDodo : INPC
  {
    public bool facingLeft;
    private bool inMovement;
    private List<Point> path;
    private double movementElapsedTime;
    private const double timeBetweenPoints = 170.0;
    private int currentPathRequest;
    private Point hitboxOffset = new Point(42, 94);

    public Vector2 Location { get; set; }

    public List<Rectangle> Hitbox
    {
      get
      {
        return new List<Rectangle>()
        {
          new Rectangle(12, 91, 61, 30)
        };
      }
    }

    public int FeetY => Convert.ToInt32(this.Location.Y + 108f);

    public Sprite CurrentDrawSprite { get; private set; }

    public Sprite IdleSprite { get; set; }

    public Sprite RunSprite { get; set; }

    public Sprite SleepSprite { get; set; }

    internal void PathCallback(object sender, EventArgs e)
    {
    }

    public PinkDodo()
    {
      Game1.pathfinder.Pathfound += new EventHandler(this.PathCallback);
      this.Location = new Vector2(8800f, 8000f);
    }

    public void Update(GameTime gameTime, World world)
    {
      if (this.currentPathRequest == 0)
      {
        int num1 = this.inMovement ? 1 : 0;
      }
      if (!this.inMovement)
        return;
      this.movementElapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
      int int32 = Convert.ToInt32(Math.Floor(this.movementElapsedTime / 170.0));
      int index = int32 + 1;
      if (index >= this.path.Count)
      {
        this.inMovement = false;
      }
      else
      {
        Point point1 = this.path[index] - this.path[int32];
        double num2 = this.movementElapsedTime % 170.0 / 170.0;
        Point point2 = this.path[int32] + new Point(Convert.ToInt32(Math.Round((double) point1.X * num2)), Convert.ToInt32(Math.Round((double) point1.Y * num2)));
        this.Location = new Vector2((float) point2.X, (float) point2.Y);
      }
    }

    public void Draw(SpriteBatch sb, GameTime gameTime, Vector2 screenLocation)
    {
      this.CurrentDrawSprite = this.IdleSprite;
      this.CurrentDrawSprite.Draw(sb, screenLocation + this.Location, gameTime, this.facingLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None, nightFactor: DayCycle.NightFactor);
    }
  }
}
