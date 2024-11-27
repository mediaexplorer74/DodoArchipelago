
// Type: DodoTheGame.Inventory

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


namespace DodoTheGame
{
  public class Inventory
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
