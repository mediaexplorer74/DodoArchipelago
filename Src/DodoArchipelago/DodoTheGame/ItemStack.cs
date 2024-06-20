// Decompiled with JetBrains decompiler
// Type: DodoTheGame.ItemStack
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe


namespace DodoTheGame
{
  internal class ItemStack
  {
    public int itemId;
    public int count;

    public ItemStack()
    {
    }

    public ItemStack(int itemId, int count)
    {
      this.itemId = itemId;
      this.count = count;
    }

    public ItemStack Copy() => new ItemStack(this.itemId, this.count);
  }
}
