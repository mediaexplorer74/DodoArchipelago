// Decompiled with JetBrains decompiler
// Type: DodoTheGame.TerrainBehavior
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe


namespace DodoTheGame
{
  internal class TerrainBehavior
  {
    public bool collision;
    public Player.DodoMovement movementType;
    public TerrainType terrainType;

    public TerrainBehavior(
      bool collision,
      Player.DodoMovement movementType,
      TerrainType terrainType)
    {
      this.collision = collision;
      this.movementType = movementType;
      this.terrainType = terrainType;
    }

    public TerrainBehavior()
    {
    }
  }
}
