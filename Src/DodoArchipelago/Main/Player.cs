// Type: DodoTheGame.Player

using DodoTheGame.BackgroundEffects;
using DodoTheGame.Hitbox;
using DodoTheGame.Interactions;
using DodoTheGame.WorldObject;
using GameManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace DodoTheGame
{
  public class Player
  {
    private Controller Controller;
    public bool DolphinDuringThisSink;
    public Player.DodoMovement currentMovementType;
    public int facing;
    public Dictionary<PlayerUnlockables.PlayerUnlockable, bool> unlockedPlayerTools;
    public Vector2 location;
    private Vector2 locationInLastUpdate;
    public float walkMovementIdleTime;
    public int playTime;
    private double timeSinceLastPlayTimeUpdate;
    public int bgmThemeDay;
    public int bgmThemeCount;
    private int swimCountdownSize = 1000;
    private int swimCountdown = 1000;
    private int swimLag;
    private int swimAimX;
    private int swimAimY;
    private int swimMovementStepDone;
    private int swimCooldown;
    private int TimeSinceBicycling;
    private Vector2 walkMovementCheckpoint;
    private Vector2 safeSwimCheckpoint;
    public int timeSinceDrowning;
    public bool BuildingBicycleException;
    public Vector2 bikeVelocity = new Vector2(0.0f, 0.0f);
    public bool wasBikeInWaterLastUpdate;
    public double speed;
    private float bikeTimeInWater;
    public bool collisionAtPreviousRequest;

    public IWorldObject inReachObject;
    public Inventory inventory = new Inventory(); //!
    public IWorldObject buildingObject;
    
    public int actionTime;
    public double movementTransitionElapsedTime;
    public bool buildSFXstarted;
    private bool ignoreHitbox;
    private int updateCyclesBeforeLocationRounding;
    private double movementRequestTiming;
    private double movementUpdateTiming;
    private float timeSinceLastWalkEvent;
    private float timeSinceLastBikeEvent;

    public event EventHandler<PlayerCollisionEventArgs> CollisionWithObjectOrTerrain;
    public event EventHandler EnteredWater;
    public event EventHandler LeftWater;
    public event EventHandler Dolphin;
    public event EventHandler Walked;
    public event EventHandler StartedBuilding;
    public event EventHandler StartedHarvesting;
    public event EventHandler MovedBike;
    public event EventHandler StartedSwimmingPulse;
    public event EventHandler BikeAppearing;
    public event EventHandler BicycleAppearing;


    public bool allowSuperdodo
    {
        get
        {
            return true;//false; // True - for debug ?
        }
    }

    public Vector2 WindAction
    {
      get
      {
        return new Vector2(Convert.ToSingle(2.0 * Wind.GetSpeed)
            * Convert.ToSingle(Math.Cos(Convert.ToDouble(Wind.GetAngle - Math.PI / 2.0))), 
            Convert.ToSingle(2.0 * Wind.GetSpeed)
            * Convert.ToSingle(Math.Sin(Convert.ToDouble(Wind.GetAngle - Math.PI / 2.0))));
      }
    }

    public bool IsInSwimmingPulse
    {
        get
        {
            return this.swimCountdown < this.swimCountdownSize;
        }
    }

    public bool IsSwimmingLocked
    {
        get
        {
            return this.swimCooldown != 0;
        }
    }

    public int CurrentFeetY
    {
      get
      {
        switch (this.currentMovementType)
        {
          case Player.DodoMovement.Walk:
            return (int) this.location.Y + 98;
          case Player.DodoMovement.Swim:
            return (int) this.location.Y + 94;
          case Player.DodoMovement.Build:
            return Convert.ToInt32((float) (
                (double) this.buildingObject.Location.Y - 88.0 - 32.0 + 203.0));
          case Player.DodoMovement.Harvest:
            return Convert.ToInt32(new Vector2(
                this.buildingObject.ExplicitEpicenter.X - 130f, 
                this.buildingObject.ExplicitEpicenter.Y - 192f).Y + 197f);
          case Player.DodoMovement.Bike:
            return (int) this.location.Y + 97 + 16 - 15;
          case Player.DodoMovement.Bicycle:
            return (int) this.location.Y + 100;
          case Player.DodoMovement.Drown:
            return (int) this.location.Y + 88;
          case Player.DodoMovement.WalkToBike:
            return (int) this.location.Y + 113 - 15;
          case Player.DodoMovement.WalkToBicycle:
            return (int) this.location.Y + 100;
          case Player.DodoMovement.TakeNotes:
            return (int) this.location.Y + 98;
          default:
            throw new Exception("Player.CurrentFeetY doesn't know current movement type.");
        }
      }
    }

    public Vector2 PlayerEpicenter
    {
      get
      {
        switch (this.currentMovementType)
        {
          case Player.DodoMovement.Walk:
            return new Vector2((float) ((double) this.location.X + 50.0 + 15.0), 
                this.location.Y + 96f);
          case Player.DodoMovement.Swim:
            return new Vector2((float) ((double) this.location.X + 50.0 + 15.0),
                this.location.Y + 96f);
          case Player.DodoMovement.Bike:
            return new Vector2(this.location.X + 62f, this.location.Y + 83f);
          default:
            return new Vector2((float) ((double) this.location.X + 50.0 + 15.0), 
                this.location.Y + 96f);
        }
      }
    }

    public bool IsBikeInWater { get; private set; }

    public int SwimPulseCount { get; private set; }

    public float TimeBar { get; set; }

    public bool HasHeadOutsideWater
    {
      get => this.currentMovementType != Player.DodoMovement.Drown
                || this.timeSinceDrowning <= 720;
    }

    internal TerrainType StandingOnTerrainType { get; private set; }


    public Player()
    {
        // ...



        Controller = new Controller();
    }

    // CancelDrowning
    public void CancelDrowning()
    {
      if (this.currentMovementType == Player.DodoMovement.Drown)
      {
        this.timeSinceDrowning = 0;
        this.SwimPulseCount = 0;
        this.currentMovementType = Player.DodoMovement.Swim;
      }
      else
      {
        if (this.currentMovementType != Player.DodoMovement.Swim)
          return;
        this.timeSinceDrowning = 0;
        this.SwimPulseCount = 0;
      }
    }//CancelDrowning

    // StartHitboxIngoring
    public void StartHitboxIngoring() 
    { 
        this.ignoreHitbox = true;
    }//StartHitboxIngoring


    // CheckSurroundingCollision
    public Tuple<bool, Vector2> CheckSurroundingCollision
    (
      World world,
      Player.DodoMovement dodoMovement
    )
    {
      if (dodoMovement != Player.DodoMovement.Bike)
        return new Tuple<bool, Vector2>(false, new Vector2(0.0f, 0.0f));

      World world1 = world;
      Box box = new Box();
      box.Rectangle = new Microsoft.Xna.Framework.Rectangle(
          Convert.ToInt32(this.location.X - 23f), Convert.ToInt32(this.location.Y + 90f), 170, 10);

      string[] iwosPresetsToIgnore = new string[3]
      {
        "flatronce",
        "ronces",
        "turningronce"
      };

      Tuple<bool, object> tuple = world1.TestCollision((IHitbox) box, 
          iwosPresetsToIgnore: iwosPresetsToIgnore);

      if (tuple.Item1)
        return new Tuple<bool, Vector2>(true, new Vector2(0.0f, 0.0f));
      int num = tuple.Item1 ? 1 : 0;

      return new Tuple<bool, Vector2>(false, new Vector2(0.0f, 0.0f));
    }//CheckSur...


    // Move
    private void Move(World world, Vector2 movementVector)
    {
      if (this.currentMovementType == Player.DodoMovement.Bike)
      {
        World world1 = world;
        Box box1 = new Box();
        box1.Rectangle = new Microsoft.Xna.Framework.Rectangle(
            Convert.ToInt32((float) ((double) this.location.X + (double) movementVector.X - 23.0)),
            Convert.ToInt32((float) ((double) this.location.Y + (double) movementVector.Y + 90.0)), 
            170, 10);

        string[] iwosPresetsToIgnore1 = new string[3]
        {
          "flatronce",
          "ronces",
          "turningronce"
        };

        Tuple<bool, object> tuple1 = world1.TestCollision((IHitbox) box1, 
            iwosPresetsToIgnore: iwosPresetsToIgnore1);
        World world2 = world;
        Box box2 = new Box();
        box2.Rectangle = new Microsoft.Xna.Framework.Rectangle(Convert.ToInt32((float) (
            (double) this.location.X + (double) movementVector.X - 23.0)), 
            Convert.ToInt32(this.location.Y + 90f), 170, 10);

        string[] iwosPresetsToIgnore2 = new string[3]
        {
          "flatronce",
          "ronces",
          "turningronce"
        };
        Tuple<bool, object> tuple2 = world2.TestCollision((IHitbox) box2, 
            iwosPresetsToIgnore: iwosPresetsToIgnore2);
        World world3 = world;
        Box box3 = new Box();
        box3.Rectangle = new Microsoft.Xna.Framework.Rectangle(
            Convert.ToInt32(this.location.X - 23f), Convert.ToInt32(
                (float) ((double) this.location.Y + (double) movementVector.Y + 90.0)), 170, 10);

        string[] iwosPresetsToIgnore3 = new string[3]
        {
          "flatronce",
          "ronces",
          "turningronce"
        };
        Tuple<bool, object> tuple3 = world3.TestCollision((IHitbox) box3, 
            iwosPresetsToIgnore: iwosPresetsToIgnore3);
        if (!tuple1.Item1)
        {
          this.location.X += this.bikeVelocity.X + this.WindAction.X;
          this.location.Y += this.bikeVelocity.Y + this.WindAction.Y;
        }
        else if (!tuple2.Item1)
          this.location.X += this.bikeVelocity.X + this.WindAction.X;
        else if (!tuple3.Item1)
          this.location.Y += this.bikeVelocity.Y + this.WindAction.Y;
        if (tuple2.Item1)
          this.bikeVelocity.X = 0.0f;
        if (tuple3.Item1)
          this.bikeVelocity.Y = 0.0f;
        if (!this.collisionAtPreviousRequest && (tuple1.Item1 || tuple2.Item1 || tuple3.Item1))
        {
          EventHandler<PlayerCollisionEventArgs> withObjectOrTerrain = this.CollisionWithObjectOrTerrain;
          if (withObjectOrTerrain != null)
            withObjectOrTerrain((object) this, new PlayerCollisionEventArgs()
            {
              CollidedObject = tuple1.Item1 ? tuple1.Item2 
              : (tuple2.Item1 
              ? tuple2.Item2 : (tuple3.Item1 ? tuple3.Item2 
              : (object) null))
            });
        }
        this.collisionAtPreviousRequest = tuple1.Item1 || tuple2.Item1 || tuple3.Item1;
      }
      else if (this.currentMovementType == Player.DodoMovement.Swim)
      {
        Vector2 vector2 = new Vector2(this.location.X + movementVector.X, 
            this.location.Y + movementVector.Y);
        Tuple<bool, object> tuple4 = world.TestCollision((IHitbox) 
            new HorizontalLine()
        {
          StartingPoint = new Vector2(vector2.X + 37f, this.location.Y + 88f),
          Span = 43
        });
        Tuple<bool, object> tuple5 = world.TestCollision((IHitbox) new HorizontalLine()
        {
          StartingPoint = new Vector2(this.location.X + 37f, vector2.Y + 88f),
          Span = 43
        });
        if (!tuple4.Item1 && !tuple5.Item1)
          this.location = vector2;
        else if (!tuple4.Item1 && tuple5.Item1)
        {
          this.location = new Vector2(vector2.X, this.location.Y);
        }
        else
        {
          if (!tuple4.Item1 || tuple5.Item1)
            return;
          this.location = new Vector2(this.location.X, vector2.Y);
        }
      }
      else
      {
        if (this.currentMovementType != Player.DodoMovement.Walk)
          return;
        Vector2 location = new Vector2(this.location.X + 42f + movementVector.X, 
            this.location.Y + 94f + movementVector.Y);
        Vector2 vector2_1 = new Vector2(this.location.X + 42f + movementVector.X, 
            this.location.Y + 94f);
        Vector2 vector2_2 = new Vector2(this.location.X + 42f, 
            this.location.Y + 94f + movementVector.Y);

        this.StandingOnTerrainType = world.behaviorMap.GetLocationInfo(location).terrainType;
        if ((double) this.timeSinceLastWalkEvent > 430.0)
        {
          this.timeSinceLastWalkEvent -= 430f;
          if ((double) this.timeSinceLastWalkEvent >= 430.0)
            this.timeSinceLastWalkEvent = 0.0f;
          EventHandler walked = this.Walked;
          if (walked != null)
            walked((object) this, EventArgs.Empty);
        }
        Tuple<bool, object> tuple6 = world.TestCollision((IHitbox) new HorizontalLine()
        {
          StartingPoint = location,
          Span = 32
        });
        Tuple<bool, object> tuple7 = world.TestCollision((IHitbox) new HorizontalLine()
        {
          StartingPoint = vector2_1,
          Span = 32
        });
        Tuple<bool, object> tuple8 = world.TestCollision((IHitbox) new HorizontalLine()
        {
          StartingPoint = vector2_2,
          Span = 32
        });
        if (!tuple6.Item1 && this.ignoreHitbox)
        {
          this.ignoreHitbox = false;
          this.location.X += movementVector.X;
          this.location.Y += movementVector.Y;
        }
        else if (!tuple6.Item1 || this.ignoreHitbox)
        {
          this.location.X += movementVector.X;
          this.location.Y += movementVector.Y;
        }
        else if (!tuple7.Item1)
          this.location.X += movementVector.X;
        else if (!tuple8.Item1)
          this.location.Y += movementVector.Y;
        this.speed = Math.Sqrt(Math.Pow((double) movementVector.X, 2.0)
            + Math.Pow((double) movementVector.X, 2.0));

        if (!this.collisionAtPreviousRequest && (tuple6.Item1 || tuple8.Item1 || tuple7.Item1))
        {
          EventHandler<PlayerCollisionEventArgs> 
                        withObjectOrTerrain = this.CollisionWithObjectOrTerrain;
          if (withObjectOrTerrain != null)
            withObjectOrTerrain((object) this, new PlayerCollisionEventArgs()
            {
              CollidedObject = tuple6.Item1 ? tuple6.Item2 : (tuple7.Item1 
              ? tuple7.Item2 : (tuple8.Item1 ? tuple8.Item2 : (object) null))
            });
        }
        this.collisionAtPreviousRequest = tuple6.Item1 || tuple8.Item1 || tuple7.Item1;
      }
    }//Move


    // RoundLocation
    private void RoundLocation()
    {
      this.location.X = Convert.ToSingle(Math.Round((double) this.location.X));
      this.location.Y = Convert.ToSingle(Math.Round((double) this.location.Y));
    }


    // Update
    public void Update(GameTime gameTime, World world, Game1 game, UserInputStatus state)
    {
      Controller.Update();

      //TODO : pause game ?
      //if(Controller.SpaceBar)
      //{
          //Game.Paused = true;
          // ...
      //}

           

      KeyboardState state1 = Microsoft.Xna.Framework.Input.Keyboard.GetState();

      // if DEBUG mode then Draw debug panel
      if (Game1.debugEnabled)
      {
                //TODO: return state1 def
        //  KeyboardState ks, Game1 game, GameTime gameTime
          DebugAssistant.KeyInput(state1, game, gameTime);
      }

      TimeSpan elapsedGameTime;
      if (this.currentMovementType == Player.DodoMovement.Walk)
      {
        double movementIdleTime = (double) this.walkMovementIdleTime;
        elapsedGameTime = gameTime.ElapsedGameTime;
        double single = (double) Convert.ToSingle(elapsedGameTime.TotalMilliseconds);
        this.walkMovementIdleTime = (float) (movementIdleTime + single);
      }
      else
        this.walkMovementIdleTime = 0.0f;
      double sinceLastWalkEvent = (double) this.timeSinceLastWalkEvent;
      elapsedGameTime = gameTime.ElapsedGameTime;
      double single1 = (double) Convert.ToSingle(elapsedGameTime.TotalMilliseconds);
      this.timeSinceLastWalkEvent = (float) (sinceLastWalkEvent + single1);
      double lastPlayTimeUpdate = this.timeSinceLastPlayTimeUpdate;
      elapsedGameTime = gameTime.ElapsedGameTime;
      double totalMilliseconds1 = elapsedGameTime.TotalMilliseconds;
      this.timeSinceLastPlayTimeUpdate = lastPlayTimeUpdate + totalMilliseconds1;

      if (this.timeSinceLastPlayTimeUpdate >= 1000.0)
      {
        this.timeSinceLastPlayTimeUpdate -= 1000.0;
        ++this.playTime;
      }

      if (state.bike == UserInputStatus.InputState.Pressed)
      {
        if (this.currentMovementType == Player.DodoMovement.Walk
                    && this.unlockedPlayerTools[PlayerUnlockables.PlayerUnlockable.Bike])
        {
          EventHandler bikeAppearing = this.BikeAppearing;
          if (bikeAppearing != null)
            bikeAppearing((object) this, EventArgs.Empty);
          this.currentMovementType = Player.DodoMovement.WalkToBike;
        }
        else if (this.currentMovementType == Player.DodoMovement.Bike)
        {
          GlobalEventManager.RegisterEvent(new GlobalEvent(GlobalEvent.Event.BikeDisappearing));
          this.currentMovementType = Player.DodoMovement.Walk;
          this.location.X = Convert.ToSingle(Math.Round((double) this.location.X));
          this.location.Y = Convert.ToSingle(Math.Round((double) this.location.Y));
        }
      }

      if ((state.bicycle == UserInputStatus.InputState.Pressed 
                || state.bicycle == UserInputStatus.InputState.Held)
                && this.unlockedPlayerTools[PlayerUnlockables.PlayerUnlockable.Bicycle] 
                && this.currentMovementType == Player.DodoMovement.Walk)
      {

        if (this.currentMovementType != Player.DodoMovement.Bicycle && (double) this.TimeBar > 3.0)
          this.currentMovementType = Player.DodoMovement.WalkToBicycle;
        else if ((double) this.TimeBar <= 3.0)
          GlobalEventManager.RegisterEvent(new GlobalEvent(GlobalEvent.Event.CantDoAction));
      }
      if (this.SwimPulseCount >= 3 && this.currentMovementType == Player.DodoMovement.Swim)
      {
        this.swimCountdown = this.swimCountdownSize;
        if (world.behaviorMap.GetLocationInfo(
            this.PlayerEpicenter).movementType == Player.DodoMovement.Walk)
        {
          this.swimCooldown = this.swimLag;
          this.swimMovementStepDone = 0;
          this.currentMovementType = Player.DodoMovement.Walk;
        }
        else
          this.currentMovementType = Player.DodoMovement.Drown;
      }

      if (this.IsInSwimmingPulse && this.currentMovementType == Player.DodoMovement.Swim)
      {
        int swimCountdown = this.swimCountdown;
        elapsedGameTime = gameTime.ElapsedGameTime;
        int totalMilliseconds2 = (int) elapsedGameTime.TotalMilliseconds;
        this.swimCountdown = swimCountdown - totalMilliseconds2;
        if (this.swimCountdown < 0)
        {
          this.swimCooldown = this.swimLag;
          this.swimCountdown = this.swimCountdownSize;
          this.swimMovementStepDone = 0;
          ++this.SwimPulseCount;
          if (this.SwimPulseCount == 2)
            this.safeSwimCheckpoint = new Vector2(this.location.X, this.location.Y);
          else if (this.SwimPulseCount < 2)
            this.safeSwimCheckpoint = Vector2.Zero;
        }
        if (world.behaviorMap.GetLocationInfo(
            this.PlayerEpicenter).movementType == Player.DodoMovement.Walk)
        {
          this.swimCooldown = this.swimLag;
          this.swimCountdown = this.swimCountdownSize;
          this.swimMovementStepDone = 0;
          this.currentMovementType = Player.DodoMovement.Walk;
        }
      }

      double movementUpdateTiming = this.movementUpdateTiming;
      elapsedGameTime = gameTime.ElapsedGameTime;
      double totalMilliseconds3 = elapsedGameTime.TotalMilliseconds;
      this.movementUpdateTiming = movementUpdateTiming + totalMilliseconds3;
      bool flag;

      if (this.movementUpdateTiming >= 17.0)
      {
        this.movementUpdateTiming -= 17.0;
        flag = true;
      }
      else if (this.movementUpdateTiming >= 100.0)
      {
        Debug.WriteLine("[!] movementUpdateTiming overflow");
        this.movementUpdateTiming = 0.0;
        flag = true;
      }
      else
        flag = false;

      if (flag)
      {
        if (this.currentMovementType == Player.DodoMovement.Bike)
        {

          double sinceLastBikeEvent = (double) this.timeSinceLastBikeEvent;
          elapsedGameTime = gameTime.ElapsedGameTime;
          double single2 = (double) Convert.ToSingle(elapsedGameTime.TotalMilliseconds);
          this.timeSinceLastBikeEvent = (float) (sinceLastBikeEvent + single2);
          float num1 = Math.Abs(this.bikeVelocity.X) + Math.Abs(this.bikeVelocity.Y) / 15f;

          if ((double) num1 > 1.0)
            num1 = 1f;

          int num2 = (int) Math.Round(300.0 - 220.0 * (double) num1);
          if ((double) num1 < 0.019999999552965164)
            num2 = 10000000;

          if ((double) this.timeSinceLastBikeEvent > (double) num2)
          {
            this.timeSinceLastBikeEvent = 0.0f;
            EventHandler movedBike = this.MovedBike;
            if (movedBike != null)
              movedBike((object) this, EventArgs.Empty);
          }
          this.bikeVelocity.X *= 0.98f;
          this.bikeVelocity.Y *= 0.98f;
          this.speed = Math.Sqrt(Math.Pow((double) this.bikeVelocity.X, 2.0) 
              + Math.Pow((double) this.bikeVelocity.Y, 2.0));

          if (this.speed > 15.0)
          {
            this.bikeVelocity.X = 15f * this.bikeVelocity.X / Convert.ToSingle(this.speed);
            this.bikeVelocity.Y = 15f * this.bikeVelocity.Y / Convert.ToSingle(this.speed);
          }
          if ((double) this.bikeVelocity.X < 0.0)
            this.facing = 0;
          if ((double) this.bikeVelocity.X > 0.0)
            this.facing = 1;
          this.Move(world, this.bikeVelocity + this.WindAction);

          Microsoft.Xna.Framework.Rectangle hitbox = 
                        new Microsoft.Xna.Framework.Rectangle(
                            Convert.ToInt32(Math.Round((double) this.location.X - 23.0)), 
                            Convert.ToInt32(Math.Round((double) this.location.Y + 75.0)), 170, 16);

          if ((double) world.behaviorMap.TestHalfColorRatio(hitbox, new Color(0, 0,
              (int) byte.MaxValue)) > 0.89999997615814209)
          {
            if ((double) this.bikeTimeInWater < 1.0)
            {
              Debug.WriteLine("[i] Bike checkpoint");
              this.walkMovementCheckpoint = new Vector2(this.location.X, this.location.Y);
            }
            double bikeTimeInWater = (double) this.bikeTimeInWater;
            elapsedGameTime = gameTime.ElapsedGameTime;
            double single3 = (double) Convert.ToSingle(elapsedGameTime.TotalMilliseconds);
            this.bikeTimeInWater = (float) (bikeTimeInWater + single3);
            float num3 = (float) (0.949999988079071 - (double) this.bikeTimeInWater / 5000.0);
            if ((double) num3 < 0.0)
              num3 = 0.0f;
            this.bikeVelocity.X *= num3;
            this.bikeVelocity.Y *= num3;
            this.IsBikeInWater = true;
          }
          else
          {
            this.IsBikeInWater = false;
            this.bikeTimeInWater = 0.0f;
          }
          if (this.IsBikeInWater && Math.Sqrt(Math.Pow((double) this.bikeVelocity.X, 2.0) 
              + Math.Pow((double) this.bikeVelocity.Y, 2.0)) < 3.4000000953674316)
          {
            if (world.behaviorMap.GetLocationInfo(this.PlayerEpicenter).movementType 
                            == Player.DodoMovement.Walk)
            {
              this.currentMovementType = Player.DodoMovement.Walk;
            }
            else
            {
              EventHandler enteredWater = this.EnteredWater;
              if (enteredWater != null)
                enteredWater((object) this, EventArgs.Empty);
              this.currentMovementType = Player.DodoMovement.Swim;
            }
          }
          if (this.updateCyclesBeforeLocationRounding <= 0)
          {
            this.RoundLocation();
            this.updateCyclesBeforeLocationRounding = 3;
          }
          else
            --this.updateCyclesBeforeLocationRounding;
        }
        else if (this.IsInSwimmingPulse && this.currentMovementType == Player.DodoMovement.Swim)
        {
          Vector2 movementVector = Vector2.Zero;

          // TODO: add touchpanel combination ?
          int num = !state1.IsKeyDown(Keys.LeftControl) || !this.allowSuperdodo ? 1 : 10;
          
          if (this.swimMovementStepDone > 20 && this.swimMovementStepDone < 60)
          {
            ++this.swimMovementStepDone;

            movementVector = new Vector2((float) (num * this.swimAimX) *
                (float) ((0.89999997615814209 + (double) this.SwimPulseCount * 0.10000000149011612)
                * 0.070000000298023224 * (double) (40 - (this.swimMovementStepDone - 20)) + 1.0), 
                (float) (int) Math.Round((double) (num * this.swimAimY) * 
                ((0.89999997615814209 + (double) this.SwimPulseCount * 0.10000000149011612) 
                * 0.070000000298023224 * (double) (40 - (this.swimMovementStepDone - 20)) + 1.0)));
          }
          else
            ++this.swimMovementStepDone;
          if (movementVector != Vector2.Zero)
            this.Move(world, movementVector);
        }
        else
        {
          this.IsBikeInWater = false;
          this.bikeVelocity = Vector2.Zero;
        }
      }

      if (this.currentMovementType != Player.DodoMovement.Bike)
        this.RoundLocation();

      if (this.swimCooldown > 0)
      {
        int swimCooldown = this.swimCooldown;
        elapsedGameTime = gameTime.ElapsedGameTime;
        int totalMilliseconds4 = (int) elapsedGameTime.TotalMilliseconds;
        this.swimCooldown = swimCooldown - totalMilliseconds4;
      }

      if (this.swimCooldown < 0)
        this.swimCooldown = 0;

      if (state1.IsKeyDown(Keys.LeftControl) && this.allowSuperdodo && this.swimCooldown > 20)
        this.swimCooldown = 0;

      if (this.currentMovementType != Player.DodoMovement.Swim)
      {
        this.swimCooldown = this.swimLag;
        this.swimCountdown = this.swimCountdownSize;
        this.swimMovementStepDone = 0;
      }

      if (this.currentMovementType != Player.DodoMovement.Bicycle
                && this.currentMovementType != Player.DodoMovement.WalkToBicycle)
      {
        if ((double) this.TimeBar < 100.0)
          this.TimeBar += 0.01f;
        else
          this.TimeBar = 100f;
      }

      if (this.currentMovementType == Player.DodoMovement.Walk
                && world.behaviorMap.GetLocationInfo(this.PlayerEpicenter).movementType
                == Player.DodoMovement.Swim && 
                (!state1.IsKeyDown(Keys.LeftControl) || 
                !this.allowSuperdodo))
      {
        EventHandler enteredWater = this.EnteredWater;

        if (enteredWater != null)
          enteredWater((object) this, EventArgs.Empty);

        this.walkMovementCheckpoint = new Vector2(this.locationInLastUpdate.X, 
            this.locationInLastUpdate.Y);

        Debug.WriteLine("[i] Walk checkpoint");
        this.SwimPulseCount = 0;
        this.currentMovementType = Player.DodoMovement.Swim;
      }

      if (this.currentMovementType == Player.DodoMovement.Build)
      {
        Debug.WriteLine("[i] Build checkpoint");
        int actionTime = this.actionTime;
        elapsedGameTime = gameTime.ElapsedGameTime;
        int num = (int) Math.Round(elapsedGameTime.TotalMilliseconds);
        this.actionTime = actionTime + num;
        if (this.actionTime > 2250)
        {
          this.buildSFXstarted = false;
          IWorldObject worldObject;

          if (this.buildingObject is BuildPoint buildingObject2)
          {
            worldObject = buildingObject2.Build(world, this);
          }
          else
          {
            worldObject = this.buildingObject is Upgradable buildingObject1
                ? buildingObject1.Upgrade(world, this)
                : throw new Exception("Player.buildingObject was null or set to an unknown IWO type");
          }

          Vector2 lineStart = new Vector2((float) ((double) this.location.X + 32.0 + 10.0), 
              this.location.Y + 94f);

          if (this.safeSwimCheckpoint != Vector2.Zero)
          {
            this.location = this.safeSwimCheckpoint;
            this.safeSwimCheckpoint = Vector2.Zero;
          }

          if (worldObject.TestHorizontalLineCollision(lineStart, 32))
          {
            Vector2 zero = Vector2.Zero;
            while (worldObject.TestHorizontalLineCollision(lineStart, 32))
            {
              ++zero.Y;
              ++lineStart.Y;
            }
            this.location += zero;
            Debug.WriteLine("[i] Player teleported (" + zero.X.ToString() + "; " 
                + zero.Y.ToString() + ") to prevent it from being inside a hitbox");
          }
          else
            Debug.WriteLine("[i] Build hitbox not detected");
        }
        else if (this.actionTime > 210 && !this.buildSFXstarted)
        {
          this.buildSFXstarted = true;
          EventHandler startedBuilding = this.StartedBuilding;
          if (startedBuilding != null)
            startedBuilding((object) this, EventArgs.Empty);
        }
        else
          this.inReachObject.Visible = false;
      }
      else if (this.currentMovementType == Player.DodoMovement.WalkToBike)
      {
        Debug.WriteLine("[i] WalkToBike checkpoint");
        double transitionElapsedTime = this.movementTransitionElapsedTime;
        elapsedGameTime = gameTime.ElapsedGameTime;
        double totalMilliseconds5 = elapsedGameTime.TotalMilliseconds;
        this.movementTransitionElapsedTime = transitionElapsedTime + totalMilliseconds5;
        if (this.movementTransitionElapsedTime > 1530.0)
        {
          game.dodoBikeSprite.ResetAnimation();
          game.dodoBikeInWaterSprite.ResetAnimation();
          game.dodoBikeBSprite.ResetAnimation();
          game.dodoBikeInWaterBSprite.ResetAnimation();
          this.currentMovementType = Player.DodoMovement.Bike;
          this.movementTransitionElapsedTime = 0.0;
          game.dodoWalkToBikeSprite.ResetAnimation();
        }
      }
      else if (this.currentMovementType == Player.DodoMovement.WalkToBicycle)
      {
         //TODO
        if (/*state1.IsKeyDown(Keys.M) ||*/ this.BuildingBicycleException)
        {
          if (game.dodoWalkToBicycleSprite.CurrentFrame == game.dodoWalkToBicycleSprite.TotalFrameCount - 1)
          {
            double transitionElapsedTime = this.movementTransitionElapsedTime;
            elapsedGameTime = gameTime.ElapsedGameTime;
            double totalMilliseconds6 = elapsedGameTime.TotalMilliseconds;
            this.movementTransitionElapsedTime = transitionElapsedTime + totalMilliseconds6;
          }
          else
            this.movementTransitionElapsedTime = 0.0;
          game.dodoWalkToBicycleSprite.backwardAnimation = false;
        }
        else if (game.dodoWalkToBicycleSprite.CurrentFrame > 0)
          game.dodoWalkToBicycleSprite.backwardAnimation = true;
        else if (this.movementTransitionElapsedTime < (double) game.dodoWalkToBicycleSprite.MillisecondsPerFrame)
        {
          double transitionElapsedTime = this.movementTransitionElapsedTime;
          elapsedGameTime = gameTime.ElapsedGameTime;
          double totalMilliseconds7 = elapsedGameTime.TotalMilliseconds;
          this.movementTransitionElapsedTime = transitionElapsedTime + totalMilliseconds7;
        }
        else
        {
          this.currentMovementType = Player.DodoMovement.Walk;
          this.movementTransitionElapsedTime = 0.0;
        }
        if (game.dodoWalkToBicycleSprite.CurrentFrame == game.dodoWalkToBicycleSprite.TotalFrameCount - 1 
                    && this.movementTransitionElapsedTime > (double) game.dodoWalkToBicycleSprite.MillisecondsPerFrame)
        {
          if (this.BuildingBicycleException)
            this.BuildingBicycleException = false;
          this.currentMovementType = Player.DodoMovement.Bicycle;
          this.movementTransitionElapsedTime = 0.0;
          game.dodoWalkToBicycleSprite.ResetAnimation();
        }
      }
      else if (this.currentMovementType == Player.DodoMovement.Harvest)
      {
        int actionTime = this.actionTime;
        elapsedGameTime = gameTime.ElapsedGameTime;
        int num = (int) Math.Round(elapsedGameTime.TotalMilliseconds);
        this.actionTime = actionTime + num;

        if (this.actionTime > 1555)
        {
          this.buildSFXstarted = false;
          this.actionTime = 0;
          this.currentMovementType = world.behaviorMap.GetLocationInfo(this.PlayerEpicenter).movementType != Player.DodoMovement.Walk
                        ? Player.DodoMovement.Swim : Player.DodoMovement.Walk;

          ((Harvest) ((IEnumerable<IDodoInteraction>) this.inReachObject.Interactions)
                        .First<IDodoInteraction>((Func<IDodoInteraction, bool>)
                        (p => p != null && p.GetType() == typeof (Harvest)))).RegisterSuccess(this, this.inReachObject, gameTime);
          this.inReachObject.Visible = true;
          if (this.safeSwimCheckpoint != Vector2.Zero)
          {
            this.location = this.safeSwimCheckpoint;
            this.safeSwimCheckpoint = Vector2.Zero;
          }
        }
        else if (this.actionTime > 210 && !this.buildSFXstarted)
        {
          this.buildSFXstarted = true;
          EventHandler startedHarvesting = this.StartedHarvesting;
          if (startedHarvesting != null)
            startedHarvesting((object) this, EventArgs.Empty);
        }
        else
          this.inReachObject.Visible = false;
      }
      else if (this.currentMovementType == Player.DodoMovement.Bicycle)
      {
        int actionTime = this.actionTime;
        elapsedGameTime = gameTime.ElapsedGameTime;
        int num = (int) Math.Round(elapsedGameTime.TotalMilliseconds);
        this.actionTime = actionTime + num;
        if (/*state1.IsKeyDown(Keys.M) && */(double) this.TimeBar > 0.0)
        {
          this.TimeBar -= 0.1f;
          GlobalEventManager.RegisterEvent(new GlobalEvent(GlobalEvent.Event.DodoBicycling));
        }
        else
        {
          if ((double) this.TimeBar < 0.0)
            this.TimeBar = 0.0f;
          this.actionTime = 0;
          this.currentMovementType = Player.DodoMovement.Walk;
          game.dodoBicycle1Sprite.ResetAnimation();
          game.dodoBicycle2Sprite.ResetAnimation();
          game.dodoBicycle3Sprite.ResetAnimation();
        }
      }
      else if (this.currentMovementType == Player.DodoMovement.Drown)
      {
        if (!this.DolphinDuringThisSink & this.timeSinceDrowning > 1500)
        {
          EventHandler dolphin = this.Dolphin;
          if (dolphin != null)
            dolphin((object) this, EventArgs.Empty);
          System.Diagnostics.Debug.WriteLine("Dolphin alert");
          this.DolphinDuringThisSink = true;
        }
        else if (this.timeSinceDrowning >= 2520)
        {
          this.DolphinDuringThisSink = false;
          this.location = new Vector2(this.walkMovementCheckpoint.X, this.walkMovementCheckpoint.Y);
          this.currentMovementType = Player.DodoMovement.Walk;
          this.SwimPulseCount = 0;
        }
      }
      else if (this.currentMovementType == Player.DodoMovement.Walk)
      {
        this.SwimPulseCount = 0;
        this.safeSwimCheckpoint = Vector2.Zero;
      }
      else if (this.currentMovementType == Player.DodoMovement.TakeNotes)
      {
        int actionTime = this.actionTime;
        elapsedGameTime = gameTime.ElapsedGameTime;
        int num = (int) Math.Round(elapsedGameTime.TotalMilliseconds);
        this.actionTime = actionTime + num;
        if (this.actionTime > 1800)
        {
          this.buildSFXstarted = false;
          this.actionTime = 0;
          this.currentMovementType = world.behaviorMap
                        .GetLocationInfo(this.PlayerEpicenter).movementType != Player.DodoMovement.Walk 
                        ? Player.DodoMovement.Swim 
                        : Player.DodoMovement.Walk;

          ((TakeNotes) ((IEnumerable<IDodoInteraction>) this.inReachObject.Interactions).
                        First<IDodoInteraction>((Func<IDodoInteraction, bool>)
                        (p => p != null && p.GetType() == typeof (TakeNotes))))
                        .RegisterSuccess(this, this.inReachObject, gameTime);

          this.inReachObject.Visible = true;
          if (this.safeSwimCheckpoint != Vector2.Zero)
          {
            this.location = this.safeSwimCheckpoint;
            this.safeSwimCheckpoint = Vector2.Zero;
          }
        }
      }

      if (this.currentMovementType == Player.DodoMovement.Drown || this.timeSinceDrowning > 0)
      {
        int timeSinceDrowning = this.timeSinceDrowning;
        elapsedGameTime = gameTime.ElapsedGameTime;
        int int32 = Convert.ToInt32(Math.Round(elapsedGameTime.TotalMilliseconds));
        this.timeSinceDrowning = timeSinceDrowning + int32;
        if (this.timeSinceDrowning > 2700)
          this.timeSinceDrowning = 0;
      }
      Tuple<bool, object> tuple = new Tuple<bool, object>(true, (object) null);

      while (tuple.Item1)
      {
        switch (this.currentMovementType)
        {
          case Player.DodoMovement.Walk:
            tuple = world.TestCollision((IHitbox) new HorizontalLine()
            {
              StartingPoint = new Vector2(this.location.X + 42f, this.location.Y + 94f),
              Span = 32
            });
            break;
          case Player.DodoMovement.Swim:
            tuple = world.TestCollision((IHitbox) new HorizontalLine()
            {
              StartingPoint = new Vector2(this.location.X + 37f, this.location.Y + 88f),
              Span = 43
            });
            break;
          case Player.DodoMovement.Bike:
            World world1 = world;
            Box box = new Box();
            box.Rectangle = new Microsoft.Xna.Framework.Rectangle(Convert.ToInt32(this.location.X - 23f), Convert.ToInt32(this.location.Y + 90f), 170, 10);
            string[] iwosPresetsToIgnore = new string[3]
            {
              "flatronce",
              "ronces",
              "turningronce"
            };
            tuple = world1.TestCollision((IHitbox) box, iwosPresetsToIgnore: iwosPresetsToIgnore);
            break;
          default:
            tuple = new Tuple<bool, object>(false, (object) null);
            break;
        }
        if (tuple.Item1)
          this.location.Y += 2f;
      }
      if (this.currentMovementType != Player.DodoMovement.Build 
                && this.currentMovementType != Player.DodoMovement.Harvest)
      {
        foreach (IWorldObject parentWo in world.objects)
        {
          int num = this.facing == 0 ? 44 : 86;
          this.inReachObject = (IWorldObject) null;
          if ((double) Math.Abs(parentWo.Epicenter.X - 
              (this.location.X + (float) num)) < 50.0 + (double) parentWo.ExtraReach.X
              && (double) Math.Abs(parentWo.Epicenter.Y - (this.location.Y + 83f)) 
              < 37.0 + (double) parentWo.ExtraReach.Y 
              && (!(parentWo is BuildPoint) || (parentWo as BuildPoint).isBpVisible) 
              && (parentWo.Interactions[0] != null 
              && parentWo.Interactions[0].ComputeShowState(parentWo, this) 
              || parentWo.Interactions[1] != null 
              && parentWo.Interactions[1].ComputeShowState(parentWo, this) 
              || parentWo.Interactions[2] != null 
              && parentWo.Interactions[2].ComputeShowState(parentWo, this) 
              || parentWo.Interactions[3] != null 
              && parentWo.Interactions[3].ComputeShowState(parentWo, this) 
              || parentWo is Hourglass))
          {
            this.inReachObject = parentWo;
            break;
          }
        }
      }
      float num4 = 1000f;
      foreach (Wave wave in Game1.waves.Where<IBackgroundEffect>(
          (Func<IBackgroundEffect, bool>) (p => p.GetType() == typeof (Wave)))
          .Cast<Wave>().ToList<Wave>())
      {
        if ((double) Vector2.Distance(wave.startingPoint, this.location) < (double) num4)
          num4 = Vector2.Distance(wave.startingPoint, this.location);
      }
      float factor = 920.0 - (double) num4 <= 0.0 
                ? 0.0f 
                : (float) (0.20000000298023224 * ((920.0 - (double) num4) / 920.0));

      if ((double) factor > 0.20000000298023224)
        factor = 0.2f;

      Sound.UpdateBGE(0, factor);
      
      Vector2 vector2 = this.location - new Vector2(6700f, 5171f);
      
      Sound.UpdateBGE(2, (double) vector2.Length() >= 1000.0 
          ? 0.0f 
          : (float) (0.699999988079071 * ((1000.0 - (double) vector2.Length()) / 1000.0)));
      
      vector2 = this.location - new Vector2(14760f, 4710f);
      
      Sound.UpdateBGE(1, (double) vector2.Length() >= 1000.0 
          ? 0.0f 
          : (float) (0.699999988079071 * ((1000.0 - (double) vector2.Length()) / 1000.0)));
      
      this.wasBikeInWaterLastUpdate = this.IsBikeInWater;
      this.locationInLastUpdate = new Vector2(this.location.X, this.location.Y);
    }//Update


    // HandleMovementRequest
    public void HandleMovementRequest
    (
      GameTime gameTime,
      float left,
      float right,
      float up,
      float down,
      World world
    )
    {
      this.movementRequestTiming += gameTime.ElapsedGameTime.TotalMilliseconds;
      if (this.movementRequestTiming >= 100.0)
      {
        //Debug.WriteLine("[!!!] movementRequestTiming overflow");
        this.movementRequestTiming = 0.0;
      }
      else
      {
        if (this.movementRequestTiming < 17.0)
          return;
        this.movementRequestTiming -= 17.0;
        this.walkMovementIdleTime = 0.0f;
        switch (this.currentMovementType)
        {
          case Player.DodoMovement.Walk:
            int x1;
            int y1;

            if ( this.allowSuperdodo &&
              Microsoft.Xna.Framework.Input.Keyboard.GetState().IsKeyDown(Keys.LeftControl) )
            {
              x1 = (int) Math.Round(18.0 * (double) right) - (int) Math.Round(/*18.0*/7 * (double) left);
              y1 = (int) Math.Round(18.0 * (double) down) - (int) Math.Round(/*18.0*/7 * (double) up);
            }
            else
            {
              x1 = (int) Math.Round(3.75 * (double) right) - (int) Math.Round(3.75 * (double) left);
              y1 = (int) Math.Round(2.5 * (double) down) - (int) Math.Round(2.5 * (double) up);
            }

            if ((double) left > 0.0)
              this.facing = 0;

            if ((double) right > 0.0)
              this.facing = 1;

            if (x1 == 0 && y1 == 0)
              break;

            this.Move(world, new Vector2((float) x1, (float) y1));
            break;

          case Player.DodoMovement.Swim:
            if (this.IsSwimmingLocked || this.IsInSwimmingPulse 
                            || (double) left <= 0.40000000596046448 
                            && (double) right <= 0.40000000596046448
                            && (double) up <= 0.40000000596046448 
                            && (double) down <= 0.40000000596046448)
              break;
            if (this.SwimPulseCount <= 2)
            {
              EventHandler startedSwimmingPulse = this.StartedSwimmingPulse;
              if (startedSwimmingPulse != null)
                startedSwimmingPulse((object) this, EventArgs.Empty);
            }
            if ((double) left > 0.0)
              this.facing = 0;
            if ((double) right > 0.0)
              this.facing = 1;
            this.swimAimX = 0;
            this.swimAimY = 0;
            this.swimAimX += Convert.ToInt32(Math.Round((double) right * 3.0));
            this.swimAimX -= Convert.ToInt32(Math.Round((double) left * 3.0));
            this.swimAimY += Convert.ToInt32(Math.Round((double) down * 3.0));
            this.swimAimY -= Convert.ToInt32(Math.Round((double) up * 3.0));
            if (this.swimAimX == 0 && this.swimAimY == 0)
              break;
            this.swimCountdown = this.swimCountdownSize - 1;
            break;

          case Player.DodoMovement.Bike:
            float num1 = 0.0f;
            float num2 = 0.0f;
            float x2 = num1 + right - left;
            float y2 = num2 + down - up;
            double num3 = Math.Atan2((double) y2, (double) x2) + Math.PI / 2.0;

            if (num3 < 0.0)
              num3 += 2.0 * Math.PI;

            double num4 = Math.Abs(Math.Atan2(
                Math.Sin(num3 - Wind.GetAngle), Math.Cos(num3 - Wind.GetAngle)));
            if (num4 > 10.0 * Math.PI / 17.0)
              break;

            this.bikeVelocity.X += Convert.ToSingle((double) x2 
                * (10.0 * Math.PI / 17.0 - num4) / 1.74);
            this.bikeVelocity.Y += Convert.ToSingle((double) y2
                * (10.0 * Math.PI / 17.0 - num4) / 1.74);
            break;
        }
      }//else
    }//HandleMovementRequest

 
    // DodoMovement enumerator
    public enum DodoMovement
    {
      Walk,
      Swim,
      Build,
      Harvest,
      Bike,
      Bicycle,
      Drown,
      WalkToBike,
      WalkToBicycle,
      TakeNotes,
    }

  }//Player class end

}//namespace end
