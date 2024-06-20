// Decompiled with JetBrains decompiler
// Type: DodoTheGame.TerrainBehaviorMap
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using SharpRaven.Data;
using System;


namespace DodoTheGame
{
  internal class TerrainBehaviorMap
  {
    private TerrainBackground ts;

    public TerrainBehaviorMap(TerrainBackground texture) => this.ts = texture;

    internal void StartBackgroundCaching() => this.ts.StartCaching();

    internal void LockBackgroundCaching() => this.ts.LockCache();

    internal void FillBackgroundCaching(int playerlevel) => this.ts.FillCache(playerlevel);

    internal void UnlockBackgroundCaching() => this.ts.UnlockCache();

    internal void StopBackgroundCaching() => this.ts.StopCaching();

    public float TestColorRatio(Rectangle hitbox, Color color)
    {
      int num1 = 0;
      int num2 = 0;
      Vector2 location = new Vector2((float) hitbox.X, (float) hitbox.Y);
      this.ts.StartCaching();
      do
      {
        ++num1;
        Color? pixelAt = this.ts.GetPixelAt(location, 0);
        Color color1 = color;
        if ((pixelAt.HasValue ? (pixelAt.HasValue ? (pixelAt.GetValueOrDefault() == color1 ? 1 : 0) : 1) : 0) != 0)
          ++num2;
        ++location.X;
        if ((double) location.X - (double) hitbox.X > (double) hitbox.Width)
        {
          location.X = (float) hitbox.X;
          ++location.Y;
        }
      }
      while ((double) location.Y - (double) hitbox.Y <= (double) hitbox.Height);
      this.ts.StopCaching();
      return Convert.ToSingle(num2) / Convert.ToSingle(num1);
    }

    public float TestHalfColorRatio(Rectangle hitbox, Color color)
    {
      int num1 = 0;
      int num2 = 0;
      Vector2 location = new Vector2((float) hitbox.X, (float) hitbox.Y);
      this.ts.StartCaching();
      do
      {
        ++num1;
        Color? pixelAt = this.ts.GetPixelAt(location, 0);
        Color color1 = color;
        if ((pixelAt.HasValue ? (pixelAt.HasValue ? (pixelAt.GetValueOrDefault() == color1 ? 1 : 0) : 1) : 0) != 0)
          ++num2;
        location.X += 3f;
        if ((double) location.X - (double) hitbox.X > (double) hitbox.Width)
        {
          location.X = (float) hitbox.X;
          location.Y += 2f;
        }
      }
      while ((double) location.Y - (double) hitbox.Y <= (double) hitbox.Height);
      this.ts.StopCaching();
      return Convert.ToSingle(num2) / Convert.ToSingle(num1);
    }

    public TerrainBehavior GetLocationInfo(Vector2 location)
    {
      try
      {
        Color? pixelAt = this.ts.GetPixelAt(location, 0);
        if (!pixelAt.HasValue)
          return new TerrainBehavior(false, Player.DodoMovement.Walk, TerrainType.Rock);
        Color? nullable = pixelAt;
        Color color1 = new Color((int) byte.MaxValue, 0, 0);
        bool collision;
        if ((nullable.HasValue ? (nullable.HasValue ? (nullable.GetValueOrDefault() == color1 ? 1 : 0) : 1) : 0) == 0)
        {
          nullable = pixelAt;
          Color color2 = new Color(170, 0, (int) byte.MaxValue);
          if ((nullable.HasValue ? (nullable.HasValue ? (nullable.GetValueOrDefault() == color2 ? 1 : 0) : 1) : 0) == 0)
          {
            collision = false;
            goto label_6;
          }
        }
        collision = true;
label_6:
        nullable = pixelAt;
        Color color3 = new Color(0, 0, (int) byte.MaxValue);
        Player.DodoMovement movementType;
        TerrainType terrainType;
        if ((nullable.HasValue ? (nullable.HasValue ? (nullable.GetValueOrDefault() == color3 ? 1 : 0) : 1) : 0) == 0)
        {
          nullable = pixelAt;
          Color color4 = new Color(170, 0, (int) byte.MaxValue);
          if ((nullable.HasValue ? (nullable.HasValue ? (nullable.GetValueOrDefault() == color4 ? 1 : 0) : 1) : 0) == 0)
          {
            movementType = Player.DodoMovement.Walk;
            nullable = pixelAt;
            Color color5 = new Color(104, 104, 104);
            if ((nullable.HasValue ? (nullable.HasValue ? (nullable.GetValueOrDefault() == color5 ? 1 : 0) : 1) : 0) != 0)
            {
              terrainType = TerrainType.Rock;
              goto label_16;
            }
            else
            {
              nullable = pixelAt;
              Color color6 = new Color((int) byte.MaxValue, (int) byte.MaxValue, 0);
              if ((nullable.HasValue ? (nullable.HasValue ? (nullable.GetValueOrDefault() == color6 ? 1 : 0) : 1) : 0) != 0)
              {
                terrainType = TerrainType.Sand;
                goto label_16;
              }
              else
              {
                nullable = pixelAt;
                Color color7 = new Color(0, 180, 0);
                if ((nullable.HasValue ? (nullable.HasValue ? (nullable.GetValueOrDefault() == color7 ? 1 : 0) : 1) : 0) != 0)
                {
                  terrainType = TerrainType.Leaves;
                  goto label_16;
                }
                else
                {
                  terrainType = TerrainType.Void;
                  Game1.Log("Terrain type for (" + location.X.ToString() + ";" + location.Y.ToString() + ") is invalid, or is the player in space?", BreadcrumbLevel.Warning);
                  goto label_16;
                }
              }
            }
          }
        }
        movementType = Player.DodoMovement.Swim;
        terrainType = TerrainType.Water;
label_16:
        return new TerrainBehavior(collision, movementType, terrainType);
      }
      catch
      {
        return new TerrainBehavior(false, Player.DodoMovement.Walk, TerrainType.Rock);
      }
    }
  }
}
