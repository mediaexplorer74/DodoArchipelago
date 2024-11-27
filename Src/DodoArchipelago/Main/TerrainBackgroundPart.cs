
// Type: DodoTheGame.TerrainBackgroundPart

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace DodoTheGame
{
  public class TerrainBackgroundPart
  {
    public Vector2 virtualOrigin;
    private Color[] dataCache;
    private int dataCachedAtLevel = -1;

    public Texture2D[] Textures { private get; set; }

    public TerrainBackgroundPart(Texture2D[] textures, Vector2 virtualOrigin)
    {
      this.Textures = textures;
      this.virtualOrigin = virtualOrigin;
    }

    public Color[] GetData(int level)
    {
      if (level != this.dataCachedAtLevel || this.dataCache == null)
      {
        Texture2D currentTexture = this.GetCurrentTexture(level);
        this.dataCache = new Color[currentTexture.Width * currentTexture.Height];
        currentTexture.GetData<Color>(this.dataCache);
        this.dataCachedAtLevel = level;
      }
      return this.dataCache;
    }

    public Texture2D GetCurrentTexture(int level)
    {
      if (this.Textures == null || this.Textures.Length == 0)
        throw new Exception("Missing texture in TerrainBackgroundPart");
      return this.Textures.Length == 1 ? this.Textures[0] : this.Textures[level];
    }
  }
}
