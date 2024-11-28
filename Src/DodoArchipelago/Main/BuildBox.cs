// Type: DodoTheGame.BuildBox


using DodoTheGame.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;


namespace DodoTheGame
{
  internal class BuildBox
  {
    public bool isOpen;
    public bool isClosing;
    public static Texture2D[] requirementIconList;
    public static Texture2D separator;

    public BuildBox.BoxType Type { get; set; }

    public string WOName { private get; set; }

    public List<ItemStack> Items { private get; set; }

    public List<Tuple<BuildBox.Requirement, bool>> Requirements { private get; set; }

    public BuildBox(
      BuildBox.BoxType type,
      string wOName,
      List<ItemStack> items,
      List<Tuple<BuildBox.Requirement, bool>> requirements)
    {
      this.Type = type;
      this.WOName = wOName;
      this.Items = items;
      this.Requirements = requirements;
    }

    public void Draw(
      SpriteBatch spriteBatch,
      Vector2 screenlocation,
      Vector2 woEpicenter,
      Vector2 woLocation,
      Player player,
      GameTime gameTime,
      bool open)
    {
      Debug.WriteLine("[!] BB drawn, " + (open ? nameof (open) : "closed"));
      Vector2 zero = Vector2.Zero;
      Sprite sprite;
      Vector2 location;
      if (this.Items.Count<ItemStack>((Func<ItemStack, bool>) (p => p != null)) <= 3 
                && this.Requirements.Count < 2)
      {
        sprite = this.Requirements.Count == 0 ? Game1.buildBoxSprite : Game1.buildBoxPlusSprite;
        location = new Vector2(screenlocation.X + 40f, screenlocation.Y - 175f);
      }
      else
      {
        sprite = this.Requirements.Count == 0 ? Game1.buildBox3Sprite : Game1.buildBox3PlusSprite;
        location = new Vector2(screenlocation.X + 40f, screenlocation.Y - 240f);
      }
      sprite.horizontalMirroring = false;
      if ((double) location.Y < 1.0)
      {
        if ((double) player.location.X + 60.0 <= (double) woEpicenter.X)
        {
          location.X += woEpicenter.X - woLocation.X;
          location.Y = 1f;
        }
        if ((double) player.location.X + 60.0 > (double) woEpicenter.X)
        {
          sprite.horizontalMirroring = true;
          location.X -= (float) (sprite.Width + 40);
          location.Y = 1f;
          zero.X = -17f;
        }
      }
      if ((double) location.X < 1.0)
        location.X = 1f;
      if (this.Items.Count<ItemStack>((Func<ItemStack, bool>) (p => p != null)) <= 3 
                && this.Requirements.Count < 2)
      {
        if ((double) location.X > 917.0)
          location.X = 917f;
      }
      else if ((double) location.X > 773.0)
        location.X = 773f;
      if (open)
      {
        this.isOpen = true;
        sprite.backwardAnimation = false;
        sprite.Draw(spriteBatch, location, gameTime, colorn: new Color?(Color.White * 1f));
        if (this.Requirements.Count > 0 && sprite.CurrentFrame > 2)
        {
          if (this.Items.Count<ItemStack>((Func<ItemStack, bool>) (p => p != null)) <= 3 
                        && this.Requirements.Count < 2)
            Recorder.RDraw(spriteBatch, BuildBox.separator, new Vector2(
                (float) ((double) location.X + (double) zero.X + 360.0), 
                (float) ((double) location.Y + (double) zero.Y + 26.0)), Color.White);
          else
            Recorder.RDraw(spriteBatch, BuildBox.separator, new Vector2(
                (float) ((double) location.X + (double) zero.X + 360.0), 
                (float) ((double) location.Y + (double) zero.Y + 58.0)), Color.White);
        }
        int num1 = 0;
        foreach (ItemStack itemStack in this.Items)
        {
          ItemStack itm = itemStack;
          if (num1 < 3)
          {
            Recorder.RDraw(spriteBatch, Game1.smallItemTextures[itm.itemId], 
                new Vector2((float) ((double) location.X - 40.0 - 5.0 + 73.0) + 
                (float) (109 * num1) + zero.X, (float) ((double) location.Y + 175.0 - 92.0) + zero.Y),
                Color.White);

            Recorder.RDrawString(spriteBatch, Game1.rouliMSpriteFont, 
                "x" + itm.count.ToString((IFormatProvider) CultureInfo.InvariantCulture), 
                new Vector2((float) ((double) location.X - 40.0 - 5.0 + 123.0) 
                + (float) (109 * num1) + zero.X, (float) ((double) location.Y + 175.0 - 67.0) + zero.Y),
                Color.Black);

            Recorder.RDraw(spriteBatch, ((IEnumerable<ItemStack>) player.inventory.inventory)
                .Any<ItemStack>((Func<ItemStack, bool>) (p => p != null
                && p.itemId == itm.itemId 
                && p.count >= itm.count)) ? Game1.itemsok : Game1.itemsnok, 
                new Vector2((float) ((double) location.X - 35.0 + 158.0 - 15.0) 
                + (float) (109 * num1) + zero.X, 
                (float) ((double) location.Y + 175.0 - 64.0) + zero.Y), Color.White);
          }
          else
          {
            Recorder.RDraw(spriteBatch, Game1.smallItemTextures[itm.itemId], 
                new Vector2((float) ((double) location.X - 40.0 - 5.0 + 73.0) 
                + (float) (109 * (num1 - 3)) + zero.X, (float) (
                (double) location.Y + 65.0 + 240.0 - 157.0) + zero.Y), Color.White);

            Recorder.RDrawString(spriteBatch, Game1.rouliMSpriteFont, "x" 
                + itm.count.ToString((IFormatProvider) CultureInfo.InvariantCulture), 
                new Vector2((float) ((double) location.X - 40.0 - 5.0 + 123.0)
                + (float) (109 * (num1 - 3)) + zero.X, (float) ((double) location.Y 
                + 240.0 - 132.0 + 65.0) + zero.Y), Color.Black);

            Recorder.RDraw(spriteBatch, ((IEnumerable<ItemStack>) player.inventory.inventory)
                .Any<ItemStack>((Func<ItemStack, bool>) (p => p != null 
                && p.itemId == itm.itemId && p.count >= itm.count)) 
                ? Game1.itemsok 
                : Game1.itemsnok, new Vector2((float) (
                (double) location.X - 35.0 + 158.0 - 15.0) + (float) (109 * (num1 - 3)) + zero.X, 
                (float) ((double) location.Y + 240.0 - 129.0 + 65.0) + zero.Y), Color.White);
          }
          ++num1;
        }
        if (this.Requirements.Count > 0)
        {
          int num2 = 0;
          foreach (Tuple<BuildBox.Requirement, bool> requirement in this.Requirements)
          {
            Recorder.RDraw(spriteBatch, BuildBox.requirementIconList[(int) requirement.Item1],
                new Vector2((float) ((double) location.X + (double) zero.X + 372.0), 
                location.Y + 15f + zero.Y + (float) (95 * num2)), Color.White);

            Recorder.RDraw(spriteBatch, requirement.Item2 ? Game1.itemsok : Game1.itemsnok,
                new Vector2((float) ((double) location.X + (double) zero.X + 372.0 + 95.0),
                (float) ((double) location.Y + 15.0 + 60.0) + zero.Y + (float) (95 * num2)),
                Color.White);
            ++num2;
          }
        }
        if (this.Type == BuildBox.BoxType.Upgrade || this.Type == BuildBox.BoxType.Unlock)
        {
          if (this.Items.Count <= 3)
            Recorder.RDrawString(spriteBatch, Game1.rouliMSpriteFont, 
                LocalizationManager.GetPresetDisplayName(this.WOName) ?? "", 
                new Vector2((float) ((double) location.X - 40.0 + 58.0 + 15.0) + zero.X,
                (float) ((double) location.Y + 175.0 - 172.0 + 15.0 - 7.0) + zero.Y), Color.Black);

          else
            Recorder.RDrawString(spriteBatch, Game1.rouliMSpriteFont, 
                LocalizationManager.GetPresetDisplayName(this.WOName) ?? "", 
                new Vector2((float) ((double) location.X - 40.0 + 58.0 + 15.0) + zero.X,
                (float) ((double) location.Y + 240.0 - 172.0 + 15.0 - 65.0 - 7.0) + zero.Y),
                Color.Black);
        }
        else
          Recorder.RDrawString(spriteBatch, Game1.rouliMSpriteFont, 
              LocalizationManager.GetPresetDisplayName(this.WOName) ?? "", 
              new Vector2((float) ((double) location.X - 40.0 + 58.0 + 15.0) + zero.X, 
              (float) ((double) location.Y + 175.0 - 172.0 + 15.0 - 7.0) + zero.Y), 
              Color.Black);
        if (this.Items.Count <= 3)
          Recorder.RDrawString(spriteBatch, Game1.rouliMSpriteFont, 
              LocalizationManager.GetString("BuildBoxRequired"), 
              new Vector2((float) ((double) location.X - 40.0 + 58.0 + 15.0) + zero.X, 
              (float) ((double) location.Y + 175.0 - 172.0 + 15.0 + 35.0 - 7.0) + zero.Y), 
              Color.Black);
        else
          Recorder.RDrawString(spriteBatch, Game1.rouliMSpriteFont, 
              LocalizationManager.GetString("BuildBoxRequired"), 
              new Vector2((float) ((double) location.X - 40.0 + 58.0 + 15.0) + zero.X, 
              (float) ((double) location.Y + 240.0 - 172.0 + 15.0 + 35.0 - 65.0 - 7.0) + zero.Y), 
              Color.Black);
      }
      else
      {
        this.isOpen = false;
        if (sprite.CurrentFrame != 0)
        {
          this.isClosing = true;
          sprite.backwardAnimation = true;
          sprite.Draw(spriteBatch, location, gameTime, colorn: new Color?(Color.White * 1f));
        }
        else
          this.isClosing = false;
      }
    }

    public enum BoxType
    {
      Build,
      Upgrade,
      Unlock,
    }

    public enum Requirement
    {
      board2,
      board3,
      water,
      otherBuilds,
      shiba,
    }
  }
}
