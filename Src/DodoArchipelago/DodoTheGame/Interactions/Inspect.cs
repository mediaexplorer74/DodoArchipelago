// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Interactions.Inspect
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

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
      Console.WriteLine("Interacted!");
    }
  }
}
