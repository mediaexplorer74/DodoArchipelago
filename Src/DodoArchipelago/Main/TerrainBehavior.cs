
// Type: DodoTheGame.TerrainBehavior

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


namespace DodoTheGame
{
  public class TerrainBehavior
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
