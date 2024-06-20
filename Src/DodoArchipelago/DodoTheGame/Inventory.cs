// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Inventory
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe


namespace DodoTheGame
{
  internal class Inventory
  {
    public ItemStack[] inventory;
    public ItemStack[] flowerinventory;

    public Inventory()
    {
      this.inventory = new ItemStack[24];
      this.flowerinventory = new ItemStack[13];
    }

    public bool AddItem(ItemStack item, bool simulation = false)
    {
      bool flag = false;
      if (item.itemId < 80)
      {
        for (int index = 0; index < this.inventory.Length; ++index)
        {
          if (this.inventory[index] != null && this.inventory[index].itemId == item.itemId)
          {
            if (!simulation)
              this.inventory[index].count += item.Copy().count;
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          for (int index = 0; index < this.inventory.Length; ++index)
          {
            if (this.inventory[index] == null)
            {
              if (!simulation)
                this.inventory[index] = item.Copy();
              flag = true;
              break;
            }
          }
        }
      }
      else
      {
        this.flowerinventory[item.itemId - 81] = item.Copy();
        flag = true;
      }
      return flag;
    }
  }
}
