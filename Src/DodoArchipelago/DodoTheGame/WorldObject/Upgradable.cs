// Decompiled with JetBrains decompiler
// Type: DodoTheGame.WorldObject.Upgradable
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
  internal class Upgradable : IWorldObject
  {
    public string[] otherBuildsSpecialIncompatibleTags = new string[0];
    public string[] incompatibleTagsToUpgrade = new string[0];
    private BuildBox upgradeBuildBox;
    private BuildBox unlockBuildBox;

    public event EventHandler Upgraded;

    public Sprite StandardSprite { get; set; }

    public string PresetMarker { get; set; }

    public List<Rectangle> Hitbox { get; set; }

    public Vector2 ExtraReach { get; set; } = Vector2.Zero;

    public Vector2 ExplicitEpicenter { get; set; } = Vector2.Zero;

    public int ExtraFloorHeight { get; set; }

    public IDodoInteraction[] Interactions { get; set; } = new IDodoInteraction[4];

    public bool Visible { get; set; } = true;

    public string ObjectId { get; set; }

    public int SpriteBottomY
    {
      get => (int) this.Location.Y + this.CurrentDrawSprite.height + this.ExtraFloorHeight;
    }

    public Vector2 Location { get; set; }

    public Sprite CurrentDrawSprite => this.StandardSprite;

    public string[] Tags { get; set; }

    public Vector2 Epicenter
    {
      get
      {
        return (double) this.ExplicitEpicenter.X > 0.0 && (double) this.ExplicitEpicenter.Y > 0.0 ? this.ExplicitEpicenter : new Vector2(this.Location.X + Convert.ToSingle(Math.Round((double) this.CurrentDrawSprite.Width / 2.0)), this.Location.Y + Convert.ToSingle(Math.Round((double) this.CurrentDrawSprite.height / 2.0)));
      }
    }

    public Upgradable()
    {
    }

    public Upgradable(
      string id,
      Sprite sprite,
      Vector2 location,
      List<Rectangle> hitbox = null,
      Vector2? epicenter = null)
    {
      this.ObjectId = id;
      this.StandardSprite = sprite;
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

    public void ResetOpenBuildboxes()
    {
      foreach (DodoTheGame.Interactions.Upgrade upgrade in ((IEnumerable<IDodoInteraction>) this.Interactions).Where<IDodoInteraction>((Func<IDodoInteraction, bool>) (p => p is DodoTheGame.Interactions.Upgrade)))
        upgrade.alreadyInteracted = false;
      foreach (UnlockPlayerUnlockable playerUnlockable in ((IEnumerable<IDodoInteraction>) this.Interactions).Where<IDodoInteraction>((Func<IDodoInteraction, bool>) (p => p is UnlockPlayerUnlockable)))
        playerUnlockable.alreadyInteracted = false;
    }

    public IWorldObject Upgrade(World world, Player player)
    {
      DodoTheGame.Interactions.Upgrade upgrade = (DodoTheGame.Interactions.Upgrade) ((IEnumerable<IDodoInteraction>) this.Interactions).First<IDodoInteraction>((Func<IDodoInteraction, bool>) (p => p is DodoTheGame.Interactions.Upgrade));
      Vector2 location = new Vector2(this.Epicenter.X - upgrade.upgradePreset.epicenterOffset.X, this.Epicenter.Y - upgrade.upgradePreset.epicenterOffset.Y);
      IWorldObject worldObject = upgrade.upgradePreset.MakeWO(location, (string) null);
      world.objects.Add(worldObject);
      player.actionTime = 0;
      player.currentMovementType = Player.DodoMovement.Walk;
      player.inReachObject.Visible = true;
      player.buildSFXstarted = false;
      EventHandler upgraded = this.Upgraded;
      if (upgraded != null)
        upgraded((object) this, new EventArgs());
      world.objects.Remove((IWorldObject) this);
      return worldObject;
    }

    public void Interact(Cardinal side, Game1 game, Player player)
    {
      this.Interactions[(int) side].Trigger(game, player, (IWorldObject) this);
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
      DodoTheGame.Interactions.Upgrade upgrade = (DodoTheGame.Interactions.Upgrade) ((IEnumerable<IDodoInteraction>) this.Interactions).First<IDodoInteraction>((Func<IDodoInteraction, bool>) (p => p is DodoTheGame.Interactions.Upgrade));
      List<Tuple<BuildBox.Requirement, bool>> requirements = new List<Tuple<BuildBox.Requirement, bool>>();
      if (upgrade.requiredLevelToUpgrade == 2)
        requirements.Add(new Tuple<BuildBox.Requirement, bool>(BuildBox.Requirement.board2, Game1.world.Level >= 2));
      else if (upgrade.requiredLevelToUpgrade == 3)
        requirements.Add(new Tuple<BuildBox.Requirement, bool>(BuildBox.Requirement.board3, Game1.world.Level >= 3));
      if (((IEnumerable<string>) this.incompatibleTagsToUpgrade).Contains<string>("pipe23"))
        requirements.Add(new Tuple<BuildBox.Requirement, bool>(BuildBox.Requirement.water, !Game1.world.objects.Any<IWorldObject>((Func<IWorldObject, bool>) (p => ((IEnumerable<string>) p.Tags).Contains<string>("pipe23")))));
      if (this.otherBuildsSpecialIncompatibleTags.Length != 0)
      {
        if (Game1.world.objects.Any<IWorldObject>((Func<IWorldObject, bool>) (p => ((IEnumerable<string>) p.Tags).Intersect<string>((IEnumerable<string>) this.otherBuildsSpecialIncompatibleTags).Any<string>())))
          requirements.Add(new Tuple<BuildBox.Requirement, bool>(BuildBox.Requirement.otherBuilds, false));
        else
          requirements.Add(new Tuple<BuildBox.Requirement, bool>(BuildBox.Requirement.otherBuilds, true));
      }
      if (this.upgradeBuildBox == null)
        this.upgradeBuildBox = new BuildBox(BuildBox.BoxType.Upgrade, upgrade.upgradePreset.displayName, upgrade.upgradeItems, requirements);
      else
        this.upgradeBuildBox.Requirements = requirements;
      if (inReachAndHasInteractions && upgrade.alreadyInteracted && (this.unlockBuildBox == null || !this.unlockBuildBox.isOpen && !this.unlockBuildBox.isClosing))
      {
        if (!this.upgradeBuildBox.isOpen)
          GlobalEventManager.RegisterEvent(new GlobalEvent(GlobalEvent.Event.BbOpening));
        this.upgradeBuildBox.Draw(spriteBatch, screenlocation, this.Epicenter, this.Location, Game1.player, gametime, true);
      }
      else if (this.upgradeBuildBox.isOpen || this.upgradeBuildBox.isClosing)
      {
        if (this.upgradeBuildBox.isOpen)
          GlobalEventManager.RegisterEvent(new GlobalEvent(GlobalEvent.Event.BbClosing));
        this.upgradeBuildBox.Draw(spriteBatch, screenlocation, this.Epicenter, this.Location, Game1.player, gametime, false);
      }
      if (!inReachAndHasInteractions)
        upgrade.alreadyInteracted = false;
      UnlockPlayerUnlockable playerUnlockable = (UnlockPlayerUnlockable) ((IEnumerable<IDodoInteraction>) this.Interactions).FirstOrDefault<IDodoInteraction>((Func<IDodoInteraction, bool>) (p => p is UnlockPlayerUnlockable));
      if (playerUnlockable == null)
        return;
      if (this.unlockBuildBox == null)
        this.unlockBuildBox = new BuildBox(BuildBox.BoxType.Unlock, PlayerUnlockables.DisplayName(playerUnlockable.unlockable, true), playerUnlockable.upgradeItems, new List<Tuple<BuildBox.Requirement, bool>>());
      if (inReachAndHasInteractions && playerUnlockable.alreadyInteracted && !this.upgradeBuildBox.isOpen && !this.upgradeBuildBox.isClosing)
      {
        if (!this.unlockBuildBox.isOpen)
          GlobalEventManager.RegisterEvent(new GlobalEvent(GlobalEvent.Event.BbOpening));
        this.unlockBuildBox.Draw(spriteBatch, screenlocation, this.Epicenter, this.Location, Game1.player, gametime, true);
      }
      else if ((this.unlockBuildBox.isOpen || this.unlockBuildBox.isClosing || !playerUnlockable.ComputeShowState((IWorldObject) this, Game1.player)) && (this.unlockBuildBox.isOpen || this.unlockBuildBox.isClosing))
      {
        if (this.unlockBuildBox.isOpen)
          GlobalEventManager.RegisterEvent(new GlobalEvent(GlobalEvent.Event.BbClosing));
        this.unlockBuildBox.Draw(spriteBatch, screenlocation, this.Epicenter, this.Location, Game1.player, gametime, false);
      }
      if (inReachAndHasInteractions)
        return;
      playerUnlockable.alreadyInteracted = false;
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
