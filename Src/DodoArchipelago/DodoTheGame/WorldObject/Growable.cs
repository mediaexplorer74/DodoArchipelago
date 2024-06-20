// Decompiled with JetBrains decompiler
// Type: DodoTheGame.WorldObject.Growable
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using DodoTheGame.Interactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace DodoTheGame.WorldObject
{
  internal class Growable : IWorldObject
  {
    public List<Sprite> growSprites;
    public int mainGrowState;
    public int growTime;
    public bool regrowOverTime = true;
    public int growTimePassed;

    public event EventHandler Harvested;

    public Sprite StandardSprite { get; set; }

    public string PresetMarker { get; set; }

    public List<Rectangle> Hitbox { get; set; }

    public List<List<Rectangle>> growHitboxes { get; set; }

    public Vector2 ExtraReach { get; set; } = Vector2.Zero;

    public Vector2 ExplicitEpicenter { get; set; } = Vector2.Zero;

    public int ExtraFloorHeight { get; set; }

    public IDodoInteraction[] Interactions { get; set; } = new IDodoInteraction[4];

    public string[] Tags { get; set; }

    public string ObjectId { get; set; }

    public bool Visible { get; set; } = true;

    public int SpriteBottomY
    {
      get => (int) this.Location.Y + this.CurrentDrawSprite.height + this.ExtraFloorHeight;
    }

    public Vector2 Location { get; set; }

    public Sprite CurrentDrawSprite => this.growSprites[this.mainGrowState];

    public Vector2 Epicenter
    {
      get
      {
        return (double) this.ExplicitEpicenter.X > 0.0 && (double) this.ExplicitEpicenter.Y > 0.0 ? this.ExplicitEpicenter : new Vector2(this.Location.X + Convert.ToSingle(Math.Round((double) this.CurrentDrawSprite.Width / 2.0)), this.Location.Y + Convert.ToSingle(Math.Round((double) this.CurrentDrawSprite.height / 2.0)));
      }
    }

    public Growable()
    {
    }

    public Growable(
      string id,
      List<Sprite> sprites,
      Vector2 location,
      List<Rectangle> hitbox = null,
      Vector2? epicenter = null,
      bool regrowOverTime = true)
    {
      this.ObjectId = id;
      this.growSprites = sprites;
      this.Location = location;
      this.Hitbox = hitbox;
      this.regrowOverTime = regrowOverTime;
      if (!epicenter.HasValue)
        return;
      this.ExplicitEpicenter = epicenter.Value;
    }

    public bool IsAbove(int y) => y < this.SpriteBottomY;

    public bool TestPointCollision(Vector2 collisionPoint)
    {
      if (this.growHitboxes != null)
        this.Hitbox = this.growHitboxes[this.mainGrowState];
      if (this.Hitbox == null || this.Hitbox.Count <= 0)
        return false;
      foreach (Rectangle rectangle in this.Hitbox)
      {
        Vector2 vector2 = new Vector2(this.Location.X + (float) rectangle.X, this.Location.Y + (float) rectangle.Y);
        if ((double) collisionPoint.X > (double) vector2.X && (double) collisionPoint.X < (double) vector2.X + (double) rectangle.Width && (double) collisionPoint.Y > (double) vector2.Y && (double) collisionPoint.Y < (double) vector2.Y + (double) rectangle.Height)
          return true;
      }
      return false;
    }

    public bool TestHorizontalLineCollision(Vector2 lineStart, int lineLength)
    {
      if (this.growHitboxes != null)
        this.Hitbox = this.growHitboxes[this.mainGrowState];
      if (this.Hitbox == null || this.Hitbox.Count <= 0)
        return false;
      foreach (Rectangle rectangle in this.Hitbox)
      {
        Vector2 vector2_1 = new Vector2(this.Location.X + (float) rectangle.X, this.Location.Y + (float) rectangle.Y);
        for (int index = 0; index < lineLength; ++index)
        {
          Vector2 vector2_2 = new Vector2(lineStart.X + (float) index, lineStart.Y);
          if ((double) vector2_2.X > (double) vector2_1.X && (double) vector2_2.X < (double) vector2_1.X + (double) rectangle.Width && (double) vector2_2.Y > (double) vector2_1.Y && (double) vector2_2.Y < (double) vector2_1.Y + (double) rectangle.Height)
            return true;
        }
      }
      return false;
    }

    public bool TestVerticalLineCollision(Vector2 lineStart, int lineLength)
    {
      if (this.growHitboxes != null)
        this.Hitbox = this.growHitboxes[this.mainGrowState];
      if (this.Hitbox == null || this.Hitbox.Count <= 0)
        return false;
      foreach (Rectangle rectangle in this.Hitbox)
      {
        Vector2 vector2_1 = new Vector2(this.Location.X + (float) rectangle.X, this.Location.Y + (float) rectangle.Y);
        for (int index = 0; index < lineLength; ++index)
        {
          Vector2 vector2_2 = new Vector2(lineStart.X, lineStart.Y + (float) index);
          if ((double) vector2_2.X > (double) vector2_1.X && (double) vector2_2.X < (double) vector2_1.X + (double) rectangle.Width && (double) vector2_2.Y > (double) vector2_1.Y && (double) vector2_2.Y < (double) vector2_1.Y + (double) rectangle.Height)
            return true;
        }
      }
      return false;
    }

    public IDodoInteraction GetInteraction(Cardinal side) => this.Interactions[(int) side];

    public void Interact(Cardinal side, Game1 game, Player player)
    {
      this.Interactions[(int) side].Trigger(game, player, (IWorldObject) this);
    }

    public void TriggerHarvest()
    {
      EventHandler harvested = this.Harvested;
      if (harvested == null)
        return;
      harvested((object) this, new EventArgs());
    }

    public void Draw(
      SpriteBatch spriteBatch,
      Vector2 screenlocation,
      GameTime gametime,
      Game1 game,
      SpriteEffects effect = SpriteEffects.None,
      Color? colorn = null,
      bool inReach = false,
      bool inReachAndHasInteractions = false)
    {
      if (!this.Visible)
        return;
      this.CurrentDrawSprite.Draw(spriteBatch, screenlocation, gametime, effect, colorn, DayCycle.NightFactor, inReachEffect: inReachAndHasInteractions);
    }

    public void DrawShadow(
      SpriteBatch spriteBatch,
      Vector2 screenlocation,
      GameTime gametime,
      Game1 game,
      SpriteEffects effect = SpriteEffects.None,
      Color? colorn = null,
      bool inReach = false,
      bool inReachAndHasInteractions = false)
    {
      if (!this.Visible)
        return;
      this.CurrentDrawSprite.DrawShadow(spriteBatch, screenlocation, gametime, effect, colorn, DayCycle.NightFactor);
    }
  }
}
