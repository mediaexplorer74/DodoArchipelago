// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Interactions.IDodoInteraction
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using DodoTheGame.WorldObject;


namespace DodoTheGame.Interactions
{
  internal interface IDodoInteraction
  {
    bool ComputeShowState(IWorldObject parentWo, Player player);

    void Trigger(Game1 game, Player player, IWorldObject parentWo);

    string ShowName { get; }
  }
}
