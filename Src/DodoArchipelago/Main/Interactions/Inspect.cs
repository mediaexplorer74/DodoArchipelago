
// Type: DodoTheGame.Interactions.Inspect

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DodoTheGame.WorldObject;
using System;


namespace DodoTheGame.Interactions
{
  internal class Inspect : IDodoInteraction
  {
    public bool ComputeShowState(IWorldObject parentWo, Player player) => true;

    public string ShowName { get; } = "Inspecter";

    public void Trigger(Game1 game, Player player, IWorldObject parentWo)
    {
      System.Diagnostics.Debug.WriteLine("Interacted!");
    }
  }
}
