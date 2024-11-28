
// Type: DodoTheGame.TerrainBackground

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace DodoTheGame
{
  public class TerrainBackground
  {
    public List<TerrainBackgroundPart> partList;
    private bool isCaching;
    private bool isCachingLocked;
    private Dictionary<TerrainBackgroundPart, Color[]> dataCache;

    public TerrainBackground() => this.partList = new List<TerrainBackgroundPart>();

    public void StartCaching()
    {
      if (!this.isCachingLocked)
        this.dataCache = new Dictionary<TerrainBackgroundPart, Color[]>();
      this.isCaching = true;
    }

    public void LockCache() => this.isCachingLocked = true;

    public void UnlockCache() => this.isCachingLocked = false;

    public void FillCache(int playerLevel)
    {
      foreach (TerrainBackgroundPart part in this.partList)
      {
        Color[] data = part.GetData(playerLevel);
        this.dataCache.Add(part, data);
      }
    }

    public void StopCaching()
    {
      if (this.isCachingLocked)
        return;
      this.isCaching = false;
      this.dataCache = (Dictionary<TerrainBackgroundPart, Color[]>) null;
    }

    public TerrainBackgroundPart GetPartAt(Vector2 location, int playerLevel)
    {
      foreach (TerrainBackgroundPart part in this.partList)
      {
        Vector2 virtualOrigin = part.virtualOrigin;
        Vector2 vector2 = new Vector2(part.virtualOrigin.X + (float) part.GetCurrentTexture(playerLevel).Width, part.virtualOrigin.Y + (float) part.GetCurrentTexture(playerLevel).Height);
        if ((double) location.X >= (double) virtualOrigin.X && (double) location.X < (double) vector2.X && (double) location.Y >= (double) virtualOrigin.Y && (double) location.Y < (double) vector2.Y)
          return part;
      }
      return (TerrainBackgroundPart) null;
    }

    public Color? GetPixelAt(Vector2 location, int playerLevel)
    {
      foreach (TerrainBackgroundPart part in this.partList)
      {
        Vector2 virtualOrigin = part.virtualOrigin;
        Vector2 vector2_1 = new Vector2(part.virtualOrigin.X + (float) part.GetCurrentTexture(playerLevel).Width, part.virtualOrigin.Y + (float) part.GetCurrentTexture(playerLevel).Height);
        if ((double) location.X >= (double) virtualOrigin.X && (double) location.X < (double) vector2_1.X && (double) location.Y >= (double) virtualOrigin.Y && (double) location.Y < (double) vector2_1.Y)
        {
          Vector2 vector2_2 = new Vector2(location.X - part.virtualOrigin.X, location.Y - part.virtualOrigin.Y);
          int index = (int) vector2_2.Y * part.GetCurrentTexture(playerLevel).Width + (int) vector2_2.X;
          Color[] data;
          if (this.isCaching)
          {
            if (this.dataCache.ContainsKey(part))
            {
              data = this.dataCache[part];
            }
            else
            {
              data = part.GetData(playerLevel);
              this.dataCache.Add(part, data);
            }
          }
          else
            data = part.GetData(playerLevel);
          return new Color?(data[index]);
        }
      }
      return new Color?();
    }

    [Obsolete("Unmaintained. Use DrawInRange instead.")]
    public void DrawAll(SpriteBatch spriteBatch, Vector2 backgroundPosition, int playerLevel)
    {
      foreach (TerrainBackgroundPart part in this.partList)
      {
        Recorder.RDraw(spriteBatch, part.GetCurrentTexture(playerLevel), new Vector2(part.virtualOrigin.X + backgroundPosition.X, part.virtualOrigin.Y + backgroundPosition.Y), Color.White);
        System.Diagnostics.Debug.WriteLine("Drew " + part.GetCurrentTexture(playerLevel).Name + " at " + (part.virtualOrigin.X + backgroundPosition.X).ToString() + " " + (part.virtualOrigin.Y + backgroundPosition.Y).ToString());
      }
    }

    public int DrawInRange(
      SpriteBatch spriteBatch,
      Vector2 dodoLocation,
      Vector2 backgroundPosition,
      int playerLevel)
    {
      int num = 0;
      foreach (TerrainBackgroundPart part in this.partList)
      {
        if ((double) Math.Abs(part.virtualOrigin.X - dodoLocation.X) < 4000.0 && (double) Math.Abs(part.virtualOrigin.Y - dodoLocation.Y) < 4000.0)
        {
          Recorder.RDraw(spriteBatch, part.GetCurrentTexture(playerLevel), new Vector2(part.virtualOrigin.X + backgroundPosition.X, part.virtualOrigin.Y + backgroundPosition.Y), Color.White);
          ++num;
        }
      }
      return num;
    }
  }
}
