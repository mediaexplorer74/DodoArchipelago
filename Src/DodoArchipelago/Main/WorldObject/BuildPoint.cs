
// Type: DodoTheGame.WorldObject.BuildPoint

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DodoTheGame.Interactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DodoTheGame.WorldObject
{
  internal class BuildPoint : IWorldObject
  {
    public string[] bpIncompatibleTags = new string[0];
    public string[] otherBuildsSpecialIncompatibleTags = new string[0];
    public int requiredLevel;
    public static readonly string[] incompatibilityTagExceptions = new string[1]
    {
      "pipe26"
    };
    public bool isBpVisible;
    private BuildBox buildBox;

    public event EventHandler Built;

    public static event EventHandler BuildBoxOpened;

    public static event EventHandler BuildBoxClosed;

    public Sprite StandardSprite { get; set; }

    public string PresetMarker { get; set; }

    public List<Rectangle> Hitbox { get; set; }

    public Vector2 ExtraReach { get; set; } = Vector2.Zero;

    public Vector2 ExplicitEpicenter { get; set; } = Vector2.Zero;

    public int ExtraFloorHeight { get; set; }

    public IDodoInteraction[] Interactions { get; set; } = new IDodoInteraction[4];

    public bool Visible { get; set; } = true;

    public string ObjectId { get; set; }

    public string[] Tags { get; set; }

    public int SpriteBottomY
    {
      get => (int) this.Location.Y + this.CurrentDrawSprite.height + this.ExtraFloorHeight;
    }

    public Vector2 Location { get; set; }

    public Sprite CurrentDrawSprite => this.StandardSprite;

    public Vector2 Epicenter
    {
      get
      {
        return (double) this.ExplicitEpicenter.X > 0.0 && (double) this.ExplicitEpicenter.Y > 0.0 ? this.ExplicitEpicenter : new Vector2(this.Location.X + Convert.ToSingle(Math.Round((double) this.CurrentDrawSprite.Width / 2.0)), this.Location.Y + Convert.ToSingle(Math.Round((double) this.CurrentDrawSprite.height / 2.0)));
      }
    }

    public BuildPoint()
    {
    }

    public BuildPoint(
      string id,
      Sprite sprite,
      Vector2 location,
      List<Rectangle> hitbox = null,
      Vector2? epicenter = null)
    {
      this.ObjectId = id;
      this.StandardSprite = sprite;
      this.Location = location;
      if (!epicenter.HasValue)
        return;
      this.ExplicitEpicenter = epicenter.Value;
    }

    public bool IsAbove(int y) => y < this.SpriteBottomY;

    public bool TestPointCollision(Vector2 collisionPoint) => false;

    public bool TestHorizontalLineCollision(Vector2 lineStart, int lineLength) => false;

    public bool TestVerticalLineCollision(Vector2 lineStart, int lineLength) => false;

    public IDodoInteraction GetInteraction(Cardinal side) => this.Interactions[(int) side];

    public void Interact(Cardinal side, Game1 game, Player player)
    {
      this.Interactions[(int) side].Trigger(game, player, (IWorldObject) this);
    }

    public IWorldObject Build(World world, Player player)
    {
      DodoTheGame.Interactions.Build interaction = (DodoTheGame.Interactions.Build) this.Interactions[3];
      Vector2 location = new Vector2(this.Epicenter.X - interaction.buildPreset.epicenterOffset.X, this.Epicenter.Y - interaction.buildPreset.epicenterOffset.Y);
      IWorldObject worldObject = interaction.buildPreset.MakeWO(location, (string) null);
      world.objects.Add(worldObject);
      player.actionTime = 0;
      player.currentMovementType = Player.DodoMovement.Walk;
      player.inReachObject.Visible = true;
      player.buildSFXstarted = false;
      EventHandler built = this.Built;
      if (built != null)
        built((object) this, new EventArgs());
      world.objects.Remove((IWorldObject) this);
      return worldObject;
    }

    public bool HasVisibilityRequirements
    {
      get
      {
        if (Game1.world.Level < this.requiredLevel)
          return false;
        if (this.bpIncompatibleTags.Length == 0 || !Game1.world.objects.Any<IWorldObject>((Func<IWorldObject, bool>) (p => ((IEnumerable<string>) p.Tags).Intersect<string>(((IEnumerable<string>) this.bpIncompatibleTags).Except<string>((IEnumerable<string>) BuildPoint.incompatibilityTagExceptions)).Any<string>())))
          return true;
        this.isBpVisible = false;
        return false;
      }
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
      if (!this.Visible || (double) screenlocation.X < -100.0 || (double) screenlocation.X > 1380.0 || (double) screenlocation.Y < -100.0 || (double) screenlocation.Y > 820.0 || !this.HasVisibilityRequirements)
        return;
      DodoTheGame.Interactions.Build interaction = (DodoTheGame.Interactions.Build) this.Interactions[3];
      this.isBpVisible = true;
      List<Tuple<BuildBox.Requirement, bool>> requirements = new List<Tuple<BuildBox.Requirement, bool>>();
      if (((IEnumerable<string>) this.bpIncompatibleTags).Contains<string>("pipe26"))
        requirements.Add(new Tuple<BuildBox.Requirement, bool>(BuildBox.Requirement.water, !Game1.world.objects.Any<IWorldObject>((Func<IWorldObject, bool>) (p => ((IEnumerable<string>) p.Tags).Contains<string>("pipe26")))));
      if (this.otherBuildsSpecialIncompatibleTags.Length != 0)
      {
        if (Game1.world.objects.Any<IWorldObject>((Func<IWorldObject, bool>) (p => ((IEnumerable<string>) p.Tags).Intersect<string>((IEnumerable<string>) this.otherBuildsSpecialIncompatibleTags).Any<string>())))
          requirements.Add(new Tuple<BuildBox.Requirement, bool>(BuildBox.Requirement.otherBuilds, false));
        else
          requirements.Add(new Tuple<BuildBox.Requirement, bool>(BuildBox.Requirement.otherBuilds, true));
      }
      if (this.buildBox == null)
        this.buildBox = new BuildBox(BuildBox.BoxType.Build, interaction.buildPreset.displayName, interaction.intake, requirements);
      else
        this.buildBox.Requirements = requirements;
      if (inReachAndHasInteractions)
      {
        if (!this.buildBox.isOpen)
        {
          EventHandler buildBoxOpened = BuildPoint.BuildBoxOpened;
          if (buildBoxOpened != null)
            buildBoxOpened((object) this, EventArgs.Empty);
        }
        this.buildBox.Draw(spriteBatch, screenlocation, this.Epicenter, this.Location, Game1.player, gametime, true);
      }
      else if (this.buildBox.isOpen || this.buildBox.isClosing)
      {
        if (this.buildBox.isOpen)
        {
          EventHandler buildBoxClosed = BuildPoint.BuildBoxClosed;
          if (buildBoxClosed != null)
            buildBoxClosed((object) this, EventArgs.Empty);
        }
        this.buildBox.Draw(spriteBatch, screenlocation, this.Epicenter, this.Location, Game1.player, gametime, false);
      }
      this.CurrentDrawSprite.Draw(spriteBatch, screenlocation, gametime, effect, colorn, DayCycle.NightFactor);
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
      if (!this.Visible || (double) screenlocation.X < -100.0 || (double) screenlocation.X > 1380.0 || (double) screenlocation.Y < -100.0 || (double) screenlocation.Y > 820.0 || !this.HasVisibilityRequirements)
        return;
      this.CurrentDrawSprite.DrawShadow(spriteBatch, screenlocation, gametime, effect, colorn, DayCycle.NightFactor);
    }
  }
}
