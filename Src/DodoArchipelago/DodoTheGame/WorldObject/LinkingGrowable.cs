// Decompiled with JetBrains decompiler
// Type: DodoTheGame.WorldObject.LinkingGrowable
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using DodoTheGame.Interactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DodoTheGame.WorldObject
{
  internal class LinkingGrowable : IWorldObject
  {
    public List<Sprite> growSprites;
    public Sprite linkedSprite;
    public int mainGrowState;
    public int growTime;
    public int growTimePassed;
    public string linkToPreset;
    public Vector2 linkOffset;
    private bool isLinked;

    public event EventHandler Harvested;

    public Sprite StandardSprite { get; set; }

    public string PresetMarker { get; set; }

    public List<Rectangle> Hitbox { get; set; }

    public Vector2 ExtraReach { get; set; } = Vector2.Zero;

    public Vector2 ExplicitEpicenter { get; set; } = Vector2.Zero;

    public int ExtraFloorHeight { get; set; }

    public IDodoInteraction[] Interactions { get; set; } = new IDodoInteraction[4];

    public string ObjectId { get; set; }

    public bool Visible { get; set; } = true;

    public string[] Tags { get; set; }

    public int SpriteBottomY
    {
      get => (int) this.Location.Y + this.CurrentDrawSprite.height + this.ExtraFloorHeight;
    }

    public Vector2 Location { get; set; }

    public Sprite CurrentDrawSprite
    {
      get => !this.isLinked ? this.growSprites[this.mainGrowState] : this.linkedSprite;
    }

    public Vector2 Epicenter
    {
      get
      {
        return (double) this.ExplicitEpicenter.X > 0.0 && (double) this.ExplicitEpicenter.Y > 0.0 ? this.ExplicitEpicenter : new Vector2(this.Location.X + Convert.ToSingle(Math.Round((double) this.CurrentDrawSprite.Width / 2.0)), this.Location.Y + Convert.ToSingle(Math.Round((double) this.CurrentDrawSprite.height / 2.0)));
      }
    }

    private bool ComputeLinking(World world)
    {
      return this.mainGrowState == 0 && world.objects.Any<IWorldObject>((Func<IWorldObject, bool>) (p => p.PresetMarker == this.linkToPreset && (!(p is Growable) && !(p is LinkingGrowable) || p is Growable && ((Growable) p).mainGrowState == 0 || p is LinkingGrowable && ((LinkingGrowable) p).mainGrowState == 0) && (double) p.Location.X == (double) this.Location.X + (double) this.linkOffset.X && (double) p.Location.Y == (double) this.Location.Y + (double) this.linkOffset.Y));
    }

    public LinkingGrowable()
    {
    }

    public LinkingGrowable(
      string id,
      List<Sprite> sprites,
      Vector2 location,
      List<Rectangle> hitbox = null,
      Vector2? epicenter = null)
    {
      this.ObjectId = id;
      this.growSprites = sprites;
      this.Location = location;
      this.Hitbox = hitbox;
      if (!epicenter.HasValue)
        return;
      this.ExplicitEpicenter = epicenter.Value;
    }

    public bool IsAbove(int y) => y < this.SpriteBottomY;

    public bool TestPointCollision(Vector2 collisionPoint)
    {
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
      this.isLinked = this.ComputeLinking(Game1.world);
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
