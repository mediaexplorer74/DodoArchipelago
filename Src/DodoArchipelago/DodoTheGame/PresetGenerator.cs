// Decompiled with JetBrains decompiler
// Type: DodoTheGame.PresetGenerator
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using DodoTheGame.Interactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpRaven.Data;
using System.Collections.Generic;


namespace DodoTheGame
{
  internal static class PresetGenerator
  {
    public static List<Preset> GeneratePresets()
    {
      List<Preset> presets = new List<Preset>();
      Game1.Log("Declaring sprite and presets...", BreadcrumbLevel.Info);
      Sprite sprite1 = new Sprite("board1", ContentLoadingWrapper.Load<Texture2D>("board/board1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("board/board1_shadow"), new Vector2(-4f, 128f), opacity: 0.4f)
      });
      Sprite sprite2 = new Sprite("board2", ContentLoadingWrapper.Load<Texture2D>("board/board2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("board/board2_shadow"), new Vector2(-5f, 140f), opacity: 0.4f)
      });
      Sprite sprite3 = new Sprite("board3", ContentLoadingWrapper.Load<Texture2D>("board/board3"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("board/board3_shadow"), new Vector2(5f, 299f), opacity: 0.4f)
      })
      {
        Width = 274,
        animated = true,
        MillisecondsPerFrame = 15,
        height = 337
      };
      List<Rectangle> hitbox1 = new List<Rectangle>();
      hitbox1.Add(new Rectangle(50, 305, 195, 40));
      Vector2 epicenterOffset1 = new Vector2(146f, 324f);
      IDodoInteraction[] interactions1 = new IDodoInteraction[4];
      Vector2? extraReach1 = new Vector2?();
      string[] tags1 = new string[1]{ "boardAnimation" };
      Preset upgradePreset1 = new Preset("Tableau de bord 3", "Board3", Preset.WOType.Static, sprite3, hitbox1, epicenterOffset1, interactions1, "Builds", extraReach1, tags: tags1);
      Sprite sprite4 = sprite2;
      List<Rectangle> hitbox2 = new List<Rectangle>();
      hitbox2.Add(new Rectangle(2, 150, 180, 30));
      Vector2 epicenterOffset2 = new Vector2(101f, 164f);
      IDodoInteraction[] interactions2 = new IDodoInteraction[4]
      {
        (IDodoInteraction) new Upgrade(upgradePreset1, new List<ItemStack>()
        {
          new ItemStack(1, 10),
          new ItemStack(4, 2),
          new ItemStack(0, 15),
          new ItemStack(2, 15),
          new ItemStack(6, 2),
          new ItemStack(10, 3)
        }, 0),
        null,
        null,
        null
      };
      Vector2? extraReach2 = new Vector2?(new Vector2(50f, 30f));
      string[] tags2 = new string[2]
      {
        "level2",
        "boardAnimation"
      };
      string[] incompatibleTags1 = new string[1]{ "pipe23" };
      string[] otherBuildsSpecialIncompatibleTags1 = new string[1]
      {
        "level2builds"
      };
      Preset upgradePreset2 = new Preset("Tableau de bord 2", "Board2", Preset.WOType.Upgradable, sprite4, hitbox2, epicenterOffset2, interactions2, "Builds", extraReach2, tags: tags2, incompatibleTags: incompatibleTags1, otherBuildsSpecialIncompatibleTags: otherBuildsSpecialIncompatibleTags1);
      List<Preset> presetList1 = presets;
      Sprite sprite5 = sprite1;
      List<Rectangle> hitbox3 = new List<Rectangle>();
      hitbox3.Add(new Rectangle(0, 115, 192, 40));
      Vector2 epicenterOffset3 = new Vector2(95f, 140f);
      IDodoInteraction[] interactions3 = new IDodoInteraction[4]
      {
        (IDodoInteraction) new Upgrade(upgradePreset2, new List<ItemStack>()
        {
          new ItemStack(2, 10),
          new ItemStack(0, 10),
          new ItemStack(3, 10),
          new ItemStack(10, 2)
        }, 0),
        null,
        null,
        null
      };
      Vector2? extraReach3 = new Vector2?(new Vector2(50f, 20f));
      string[] tags3 = new string[2]
      {
        "level1",
        "boardAnimation"
      };
      string[] otherBuildsSpecialIncompatibleTags2 = new string[1]
      {
        "level1builds"
      };
      Preset preset1 = new Preset("Tableau de bord", "Tableau de bord", Preset.WOType.Upgradable, sprite5, hitbox3, epicenterOffset3, interactions3, "Builds", extraReach3, tags: tags3, otherBuildsSpecialIncompatibleTags: otherBuildsSpecialIncompatibleTags2);
      presetList1.Add(preset1);
      Sprite sprite6 = new Sprite("house4", ContentLoadingWrapper.Load<Texture2D>("house/house4"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("house/house4_shadow"), new Vector2(0.0f, 212f), opacity: 0.4f)
      });
      List<Rectangle> hitbox4 = new List<Rectangle>();
      hitbox4.Add(new Rectangle(65, 216, 108, 34));
      Vector2 epicenterOffset4 = new Vector2(120f, 242f);
      IDodoInteraction[] interactions4 = new IDodoInteraction[4];
      Vector2? extraReach4 = new Vector2?();
      Preset upgradePreset3 = new Preset("Maison", "house4", Preset.WOType.Static, sprite6, hitbox4, epicenterOffset4, interactions4, "Builds", extraReach4, new List<ItemStack>()
      {
        new ItemStack(1, 5),
        new ItemStack(1, 5)
      });
      Sprite sprite7 = new Sprite("house3", ContentLoadingWrapper.Load<Texture2D>("house/house3"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("house/house3_shadow"), new Vector2(-4f, 165f), opacity: 0.4f)
      });
      List<Rectangle> hitbox5 = new List<Rectangle>();
      hitbox5.Add(new Rectangle(4, 156, 224, 40));
      Vector2 epicenterOffset5 = new Vector2(117f, 188f);
      IDodoInteraction[] interactions5 = new IDodoInteraction[4]
      {
        (IDodoInteraction) new Upgrade(upgradePreset3, new List<ItemStack>()
        {
          new ItemStack(0, 20),
          new ItemStack(1, 5),
          new ItemStack(2, 5),
          new ItemStack(16, 1)
        }, 3),
        null,
        null,
        null
      };
      Vector2? extraReach5 = new Vector2?(new Vector2(55f, 10f));
      Preset upgradePreset4 = new Preset("Maison", "house3", Preset.WOType.Upgradable, sprite7, hitbox5, epicenterOffset5, interactions5, "Builds", extraReach5);
      Sprite sprite8 = new Sprite("house2", ContentLoadingWrapper.Load<Texture2D>("house/house2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("house/house2_shadow"), new Vector2(-2f, 189f), opacity: 0.4f)
      });
      List<Rectangle> hitbox6 = new List<Rectangle>();
      hitbox6.Add(new Rectangle(17, 189, 103, 40));
      Vector2 epicenterOffset6 = new Vector2(68f, 215f);
      IDodoInteraction[] interactions6 = new IDodoInteraction[4]
      {
        (IDodoInteraction) new Upgrade(upgradePreset4, new List<ItemStack>()
        {
          new ItemStack(0, 15),
          new ItemStack(1, 5),
          new ItemStack(2, 5),
          new ItemStack(6, 2),
          new ItemStack(16, 1)
        }, 2),
        null,
        null,
        null
      };
      Vector2? extraReach6 = new Vector2?(new Vector2(30f, 15f));
      Preset upgradePreset5 = new Preset("Maison", "house2", Preset.WOType.Upgradable, sprite8, hitbox6, epicenterOffset6, interactions6, "Builds", extraReach6);
      Sprite sprite9 = new Sprite("house1", ContentLoadingWrapper.Load<Texture2D>("house/house1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("house/house1_shadow"), new Vector2(-8f, 95f), opacity: 0.4f)
      });
      List<Preset> presetList2 = presets;
      Sprite sprite10 = sprite9;
      List<Rectangle> hitbox7 = new List<Rectangle>();
      hitbox7.Add(new Rectangle(-5, 95, 130, 35));
      Vector2 epicenterOffset7 = new Vector2(64f, 114f);
      IDodoInteraction[] interactions7 = new IDodoInteraction[4]
      {
        (IDodoInteraction) new Upgrade(upgradePreset5, new List<ItemStack>()
        {
          new ItemStack(0, 10),
          new ItemStack(1, 5),
          new ItemStack(6, 1),
          new ItemStack(16, 1)
        }, 1),
        null,
        null,
        null
      };
      Vector2? extraReach7 = new Vector2?(new Vector2(30f, 15f));
      string[] tags4 = new string[1]{ "level2builds" };
      Preset preset2 = new Preset("Maison", "UpgradableHouse", Preset.WOType.Upgradable, sprite10, hitbox7, epicenterOffset7, interactions7, "Builds", extraReach7, tags: tags4);
      presetList2.Add(preset2);
      Sprite sprite11 = new Sprite("quechua2", ContentLoadingWrapper.Load<Texture2D>("quechua2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("quechua_shadow"), new Vector2(-10f, 185f), opacity: 0.4f)
      });
      List<Rectangle> hitbox8 = new List<Rectangle>();
      hitbox8.Add(new Rectangle(0, 200, 190, 30));
      Vector2 epicenterOffset8 = new Vector2(105f, 214f);
      IDodoInteraction[] interactions8 = new IDodoInteraction[4];
      Vector2? extraReach8 = new Vector2?();
      Preset upgradePreset6 = new Preset("Tente", "quechua2", Preset.WOType.Static, sprite11, hitbox8, epicenterOffset8, interactions8, "Builds", extraReach8, new List<ItemStack>()
      {
        new ItemStack(1, 5),
        new ItemStack(1, 5)
      });
      Sprite sprite12 = new Sprite("quechua", ContentLoadingWrapper.Load<Texture2D>("quechua"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("quechua_shadow"), new Vector2(-10f, 90f), opacity: 0.4f)
      });
      List<Rectangle> hitbox9 = new List<Rectangle>();
      hitbox9.Add(new Rectangle(0, 103, 206, 35));
      Vector2 epicenterOffset9 = new Vector2(103f, 124f);
      IDodoInteraction[] interactions9 = new IDodoInteraction[4]
      {
        (IDodoInteraction) new Upgrade(upgradePreset6, new List<ItemStack>()
        {
          new ItemStack(0, 10),
          new ItemStack(2, 10),
          new ItemStack(16, 1)
        }, 3),
        null,
        null,
        null
      };
      Vector2? extraReach9 = new Vector2?(new Vector2(60f, 15f));
      Preset upgradePreset7 = new Preset("Tente", "quechua", Preset.WOType.Upgradable, sprite12, hitbox9, epicenterOffset9, interactions9, "Builds", extraReach9);
      List<Preset> presetList3 = presets;
      Sprite sprite13 = sprite9;
      List<Rectangle> hitbox10 = new List<Rectangle>();
      hitbox10.Add(new Rectangle(-5, 95, 130, 35));
      Vector2 epicenterOffset10 = new Vector2(64f, 114f);
      IDodoInteraction[] interactions10 = new IDodoInteraction[4]
      {
        (IDodoInteraction) new Upgrade(upgradePreset7, new List<ItemStack>()
        {
          new ItemStack(0, 10),
          new ItemStack(2, 5),
          new ItemStack(16, 1)
        }, 2),
        null,
        null,
        null
      };
      Vector2? extraReach10 = new Vector2?(new Vector2(30f, 15f));
      Preset preset3 = new Preset("Maison", "UpgradableHouse2", Preset.WOType.Upgradable, sprite13, hitbox10, epicenterOffset10, interactions10, "Builds", extraReach10);
      presetList3.Add(preset3);
      Sprite sprite14 = new Sprite("maquette", ContentLoadingWrapper.Load<Texture2D>("maquette"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("maquette_shadow"), new Vector2(-26f, 65f), opacity: 0.4f)
      });
      List<Preset> presetList4 = presets;
      Sprite sprite15 = sprite14;
      List<Rectangle> hitbox11 = new List<Rectangle>();
      hitbox11.Add(new Rectangle(0, 70, 180, 65));
      Vector2 epicenterOffset11 = new Vector2(90f, 107f);
      IDodoInteraction[] interactions11 = new IDodoInteraction[4];
      Vector2? extraReach11 = new Vector2?();
      Preset preset4 = new Preset("Maquette", "Maquette", Preset.WOType.Static, sprite15, hitbox11, epicenterOffset11, interactions11, "Builds", extraReach11, new List<ItemStack>()
      {
        new ItemStack(3, 10),
        new ItemStack(0, 3),
        new ItemStack(1, 3),
        new ItemStack(9, 3)
      });
      presetList4.Add(preset4);
      Sprite sprite16 = new Sprite("autoharvest", ContentLoadingWrapper.Load<Texture2D>("autoharvest"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("autoharvest_shadow"), new Vector2(-9f, 170f), opacity: 0.4f)
      });
      List<Preset> presetList5 = presets;
      Sprite sprite17 = sprite16;
      List<Rectangle> hitbox12 = new List<Rectangle>();
      hitbox12.Add(new Rectangle(15, 176, 165, 54));
      Vector2 epicenterOffset12 = new Vector2(106f, 200f);
      IDodoInteraction[] interactions12 = new IDodoInteraction[4];
      Vector2? extraReach12 = new Vector2?();
      Preset preset5 = new Preset("Auto récolteur", "Auto-harvest", Preset.WOType.Static, sprite17, hitbox12, epicenterOffset12, interactions12, "Builds", extraReach12, new List<ItemStack>()
      {
        new ItemStack(3, 10),
        new ItemStack(0, 3),
        new ItemStack(1, 3),
        new ItemStack(9, 3)
      });
      presetList5.Add(preset5);
      Preset preset6 = new Preset("Tapis", "Tapis", Preset.WOType.Static, new Sprite("Tapis", ContentLoadingWrapper.Load<Texture2D>("void"))
      {
        groundSubsprite = new List<SubSprite>()
        {
          new SubSprite(ContentLoadingWrapper.Load<Texture2D>("tapis"), new Vector2(0.0f, 0.0f))
          {
            disappearAtNight = false
          }
        }
      }, new List<Rectangle>(), new Vector2(329f, 160f), new IDodoInteraction[4], "Builds", buildOrUpgradeItems: new List<ItemStack>()
      {
        new ItemStack(0, 25)
      });
      presets.Add(preset6);
      Sprite sprite18 = new Sprite("Canapés", ContentLoadingWrapper.Load<Texture2D>("canape"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("canape_shadow"), new Vector2(-3f, 97f), opacity: 0.4f)
      });
      List<Preset> presetList6 = presets;
      Sprite sprite19 = sprite18;
      List<Rectangle> hitbox13 = new List<Rectangle>();
      hitbox13.Add(new Rectangle(0, 86, 184, 90));
      hitbox13.Add(new Rectangle(295, 90, 137, 78));
      Vector2 epicenterOffset13 = new Vector2(219f, 140f);
      IDodoInteraction[] interactions13 = new IDodoInteraction[4];
      Vector2? extraReach13 = new Vector2?();
      Preset preset7 = new Preset("Canapé", "Canap", Preset.WOType.Static, sprite19, hitbox13, epicenterOffset13, interactions13, "Builds", extraReach13, new List<ItemStack>()
      {
        new ItemStack(9, 15)
      });
      presetList6.Add(preset7);
      Sprite sprite20 = new Sprite("Table", ContentLoadingWrapper.Load<Texture2D>("table"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("table_shadow"), new Vector2(10f, 168f), opacity: 0.4f)
      });
      List<Preset> presetList7 = presets;
      Sprite sprite21 = sprite20;
      List<Rectangle> hitbox14 = new List<Rectangle>();
      hitbox14.Add(new Rectangle(5, 173, 165, 40));
      Vector2 epicenterOffset14 = new Vector2(80f, 200f);
      IDodoInteraction[] interactions14 = new IDodoInteraction[4];
      Vector2? extraReach14 = new Vector2?();
      Preset preset8 = new Preset("Table", "Table", Preset.WOType.Static, sprite21, hitbox14, epicenterOffset14, interactions14, "Builds", extraReach14, new List<ItemStack>()
      {
        new ItemStack(9, 15)
      });
      presetList7.Add(preset8);
      Sprite sprite22 = new Sprite("Lampe", ContentLoadingWrapper.Load<Texture2D>("lampe"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("lampe_shadow"), new Vector2(-10f, 230f), opacity: 0.4f)
      });
      List<Preset> presetList8 = presets;
      Sprite sprite23 = sprite22;
      List<Rectangle> hitbox15 = new List<Rectangle>();
      hitbox15.Add(new Rectangle(15, 245, 68, 40));
      Vector2 epicenterOffset15 = new Vector2(40f, 270f);
      IDodoInteraction[] interactions15 = new IDodoInteraction[4];
      Vector2? extraReach15 = new Vector2?();
      Preset preset9 = new Preset("Lampe", "Lampe", Preset.WOType.Static, sprite23, hitbox15, epicenterOffset15, interactions15, "Builds", extraReach15, new List<ItemStack>()
      {
        new ItemStack(2, 2),
        new ItemStack(3, 4),
        new ItemStack(11, 4)
      });
      presetList8.Add(preset9);
      Sprite sprite24 = new Sprite("Sablier", ContentLoadingWrapper.Load<Texture2D>("sablier213"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("sablier_shadow"), new Vector2(9f, 222f), opacity: 0.4f)
      });
      sprite24.Width = 213;
      sprite24.animated = true;
      sprite24.MillisecondsPerFrame = 35;
      List<Preset> presetList9 = presets;
      Sprite sprite25 = sprite24;
      List<Rectangle> hitbox16 = new List<Rectangle>();
      hitbox16.Add(new Rectangle(34, 240, 139, 64));
      Vector2 epicenterOffset16 = new Vector2(108f, 272f);
      IDodoInteraction[] interactions16 = new IDodoInteraction[4];
      Vector2? extraReach16 = new Vector2?(new Vector2(80f, 70f));
      Preset preset10 = new Preset("Sablier", "Sablier", Preset.WOType.Hourglass, sprite25, hitbox16, epicenterOffset16, interactions16, "Builds", extraReach16, new List<ItemStack>()
      {
        new ItemStack(2, 2),
        new ItemStack(3, 4),
        new ItemStack(11, 4)
      });
      presetList9.Add(preset10);
      Sprite sprite26 = new Sprite("IRLClock", ContentLoadingWrapper.Load<Texture2D>("playtime_display"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("playtimedisplay_shadow"), new Vector2(-2f, 228f), opacity: 0.4f)
      });
      List<Preset> presetList10 = presets;
      Sprite sprite27 = sprite26;
      List<Rectangle> hitbox17 = new List<Rectangle>();
      hitbox17.Add(new Rectangle(44, 219, 32, 24));
      Vector2 epicenterOffset17 = new Vector2(61f, 242f);
      IDodoInteraction[] interactions17 = new IDodoInteraction[4];
      Vector2? extraReach17 = new Vector2?();
      Preset preset11 = new Preset("Horloge", "IRLClock", Preset.WOType.Static, sprite27, hitbox17, epicenterOffset17, interactions17, "Builds", extraReach17, new List<ItemStack>()
      {
        new ItemStack(2, 2),
        new ItemStack(3, 4),
        new ItemStack(11, 4)
      });
      presetList10.Add(preset11);
      Sprite sprite28 = new Sprite("feeder0", ContentLoadingWrapper.Load<Texture2D>("feeder0"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("feeder_shadow"), new Vector2(8f, 505f), opacity: 0.4f)
      });
      Sprite sprite29 = new Sprite("feeder1", ContentLoadingWrapper.Load<Texture2D>("feeder1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("feeder_shadow"), new Vector2(8f, 505f), opacity: 0.4f)
      });
      List<Preset> presetList11 = presets;
      Sprite sprite30 = sprite29;
      List<Rectangle> hitbox18 = new List<Rectangle>();
      hitbox18.Add(new Rectangle(44, 521, 217, 50));
      Vector2 epicenterOffset18 = new Vector2(141f, 549f);
      IDodoInteraction[] interactions18 = new IDodoInteraction[4];
      Vector2? extraReach18 = new Vector2?();
      Preset preset12 = new Preset("Réservoir", "Feeder", Preset.WOType.Static, sprite30, hitbox18, epicenterOffset18, interactions18, "Builds", extraReach18, new List<ItemStack>()
      {
        new ItemStack(3, 15),
        new ItemStack(1, 3),
        new ItemStack(0, 3),
        new ItemStack(4, 2),
        new ItemStack(12, 5),
        new ItemStack(6, 3)
      });
      presetList11.Add(preset12);
      Sprite sprite31 = new Sprite("Atelier niveau 3", ContentLoadingWrapper.Load<Texture2D>("atelier/atelier3"))
      {
        groundSubsprite = new List<SubSprite>()
        {
          new SubSprite(ContentLoadingWrapper.Load<Texture2D>("tapis_atelier"), new Vector2(0.0f, 0.0f))
          {
            disappearAtNight = false
          }
        }
      };
      List<Rectangle> hitbox19 = new List<Rectangle>();
      hitbox19.Add(new Rectangle(36, 236, 182, 35));
      Vector2 epicenterOffset19 = new Vector2(164f, 247f);
      IDodoInteraction[] interactions19 = new IDodoInteraction[4];
      Vector2? extraReach19 = new Vector2?();
      Preset upgradePreset8 = new Preset("Atelier 3", "atelier3", Preset.WOType.Static, sprite31, hitbox19, epicenterOffset19, interactions19, "Builds", extraReach19, new List<ItemStack>()
      {
        new ItemStack(1, 5),
        new ItemStack(1, 5)
      });
      Sprite sprite32 = new Sprite("Atelier niveau 2", ContentLoadingWrapper.Load<Texture2D>("atelier/atelier2"))
      {
        groundSubsprite = new List<SubSprite>()
        {
          new SubSprite(ContentLoadingWrapper.Load<Texture2D>("tapis_atelier"), new Vector2(0.0f, -70f))
          {
            disappearAtNight = false
          }
        }
      };
      List<Rectangle> hitbox20 = new List<Rectangle>();
      hitbox20.Add(new Rectangle(1, 172, 250, 40));
      Vector2 epicenterOffset20 = new Vector2(164f, 177f);
      IDodoInteraction[] interactions20 = new IDodoInteraction[4]
      {
        (IDodoInteraction) new Upgrade(upgradePreset8, new List<ItemStack>()
        {
          new ItemStack(0, 15),
          new ItemStack(1, 5),
          new ItemStack(2, 5),
          new ItemStack(6, 2)
        }, 3),
        null,
        (IDodoInteraction) new UnlockPlayerUnlockable(PlayerUnlockables.PlayerUnlockable.Bicycle, new List<ItemStack>()
        {
          new ItemStack(2, 10),
          new ItemStack(14, 1),
          new ItemStack(15, 1)
        }),
        null
      };
      Vector2? extraReach20 = new Vector2?(new Vector2(30f, 15f));
      string[] incompatibleTags2 = new string[1]{ "level1" };
      Preset upgradePreset9 = new Preset("Atelier 2", "atelier2", Preset.WOType.Upgradable, sprite32, hitbox20, epicenterOffset20, interactions20, "Builds", extraReach20, incompatibleTags: incompatibleTags2);
      Sprite sprite33 = new Sprite("Atelier niveau 1", ContentLoadingWrapper.Load<Texture2D>("atelier/atelier1"));
      sprite33.groundSubsprite = new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("tapis_atelier"), new Vector2(-30f, -160f))
        {
          disappearAtNight = false
        }
      };
      List<Preset> presetList12 = presets;
      Sprite sprite34 = sprite33;
      List<Rectangle> hitbox21 = new List<Rectangle>();
      hitbox21.Add(new Rectangle(1, 82, 184, 40));
      Vector2 epicenterOffset21 = new Vector2(134f, 87f);
      IDodoInteraction[] interactions21 = new IDodoInteraction[4]
      {
        (IDodoInteraction) new Upgrade(upgradePreset9, new List<ItemStack>()
        {
          new ItemStack(2, 10),
          new ItemStack(7, 5),
          new ItemStack(3, 5)
        }, 2),
        null,
        (IDodoInteraction) new UnlockPlayerUnlockable(PlayerUnlockables.PlayerUnlockable.Bike, new List<ItemStack>()
        {
          new ItemStack(0, 10),
          new ItemStack(2, 10)
        }),
        null
      };
      Vector2? extraReach21 = new Vector2?(new Vector2(100f, 30f));
      string[] tags5 = new string[1]{ "level2builds" };
      Preset preset13 = new Preset("Atelier", "Atelier", Preset.WOType.Upgradable, sprite34, hitbox21, epicenterOffset21, interactions21, "Builds", extraReach21, tags: tags5);
      presetList12.Add(preset13);
      Sprite sprite35 = new Sprite("paravent", ContentLoadingWrapper.Load<Texture2D>("paravent"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("paravent_shadow"), new Vector2(-12f, 135f), opacity: 0.4f)
      });
      List<Preset> presetList13 = presets;
      Sprite sprite36 = sprite35;
      List<Rectangle> hitbox22 = new List<Rectangle>();
      hitbox22.Add(new Rectangle(0, 160, 206, 41));
      Vector2 epicenterOffset22 = new Vector2(102f, 184f);
      IDodoInteraction[] interactions22 = new IDodoInteraction[4];
      Vector2? extraReach22 = new Vector2?();
      Preset preset14 = new Preset("Paravent", "Paravent", Preset.WOType.Static, sprite36, hitbox22, epicenterOffset22, interactions22, "Builds", extraReach22, new List<ItemStack>()
      {
        new ItemStack(2, 5),
        new ItemStack(0, 5)
      });
      presetList13.Add(preset14);
      Sprite sprite37 = new Sprite("fountain", ContentLoadingWrapper.Load<Texture2D>("fountain"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fountain_shadow"), new Vector2(-16f, 223f), opacity: 0.4f)
      });
      sprite37.Width = 313;
      sprite37.animated = true;
      sprite37.MillisecondsPerFrame = 65;
      List<Preset> presetList14 = presets;
      Sprite sprite38 = sprite37;
      List<Rectangle> hitbox23 = new List<Rectangle>();
      hitbox23.Add(new Rectangle(3, 240, 280, 65));
      Vector2 epicenterOffset23 = new Vector2(158f, 260f);
      IDodoInteraction[] interactions23 = new IDodoInteraction[4];
      Vector2? extraReach23 = new Vector2?();
      Preset preset15 = new Preset("Fontaine", "Fontaine", Preset.WOType.Static, sprite38, hitbox23, epicenterOffset23, interactions23, "Builds", extraReach23, new List<ItemStack>()
      {
        new ItemStack(3, 15),
        new ItemStack(2, 5),
        new ItemStack(5, 10)
      });
      presetList14.Add(preset15);
      Sprite sprite39 = new Sprite("chateaudesable", ContentLoadingWrapper.Load<Texture2D>("chateaudesable"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("chateaudesable_shadow"), new Vector2(-8f, 238f), opacity: 0.4f)
      });
      List<Preset> presetList15 = presets;
      Sprite sprite40 = sprite39;
      List<Rectangle> hitbox24 = new List<Rectangle>();
      hitbox24.Add(new Rectangle(0, 236, 222, 54));
      Vector2 epicenterOffset24 = new Vector2(115f, 263f);
      IDodoInteraction[] interactions24 = new IDodoInteraction[4];
      Vector2? extraReach24 = new Vector2?();
      Preset preset16 = new Preset("Chateau de sable", "Chateau de sable", Preset.WOType.Static, sprite40, hitbox24, epicenterOffset24, interactions24, "Builds", extraReach24, new List<ItemStack>()
      {
        new ItemStack(2, 5),
        new ItemStack(0, 5)
      });
      presetList15.Add(preset16);
      Sprite sprite41 = new Sprite("Shiba statue", ContentLoadingWrapper.Load<Texture2D>("shibastatue"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("shibastatue_shadow"), new Vector2(-9f, 150f), opacity: 0.4f)
      });
      List<Preset> presetList16 = presets;
      Sprite sprite42 = sprite41;
      List<Rectangle> hitbox25 = new List<Rectangle>();
      hitbox25.Add(new Rectangle(0, 147, 83, 35));
      Vector2 epicenterOffset25 = new Vector2(45f, 164f);
      IDodoInteraction[] interactions25 = new IDodoInteraction[4];
      Vector2? extraReach25 = new Vector2?();
      Preset preset17 = new Preset("Statue de shibananas", "Shiba statue", Preset.WOType.Static, sprite42, hitbox25, epicenterOffset25, interactions25, "Builds", extraReach25, new List<ItemStack>()
      {
        (ItemStack) null,
        (ItemStack) null
      });
      presetList16.Add(preset17);
      Sprite sprite43 = new Sprite("bamboopipe2", ContentLoadingWrapper.Load<Texture2D>("bamboopipe/bamboopipe2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bamboopipe/bamboopipe_shadow"), new Vector2(1f, 154f), opacity: 0.3f)
      });
      sprite43.Width = 650;
      sprite43.animated = true;
      sprite43.MillisecondsPerFrame = 70;
      List<Preset> presetList17 = presets;
      Sprite sprite44 = sprite43;
      List<Rectangle> hitbox26 = new List<Rectangle>();
      hitbox26.Add(new Rectangle(201, 155, 30, 30));
      hitbox26.Add(new Rectangle(440, 150, 30, 30));
      hitbox26.Add(new Rectangle(625, 150, 30, 30));
      Vector2 epicenterOffset26 = new Vector2(335f, 173f);
      IDodoInteraction[] interactions26 = new IDodoInteraction[4];
      Vector2? extraReach26 = new Vector2?();
      Preset preset18 = new Preset("Long tuyau", "Long tuyau", Preset.WOType.Static, sprite44, hitbox26, epicenterOffset26, interactions26, "Builds", extraReach26, new List<ItemStack>()
      {
        new ItemStack(2, 10)
      });
      presetList17.Add(preset18);
      Sprite sprite45 = new Sprite("diagonalpipe1", ContentLoadingWrapper.Load<Texture2D>("bamboopipe/diagonalpipe1"), new List<SubSprite>());
      sprite45.groundSubsprite = new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bamboopipe/diagonalpipe1_shadow"), new Vector2(1f, 147f), opacity: 0.3f)
      };
      sprite45.Width = 191;
      sprite45.animated = true;
      sprite45.MillisecondsPerFrame = 70;
      List<Preset> presetList18 = presets;
      Sprite sprite46 = sprite45;
      List<Rectangle> hitbox27 = new List<Rectangle>();
      hitbox27.Add(new Rectangle(176, 254, 30, 20));
      Vector2 epicenterOffset27 = new Vector2(86f, 201f);
      IDodoInteraction[] interactions27 = new IDodoInteraction[4];
      Vector2? extraReach27 = new Vector2?();
      Preset preset19 = new Preset("Tuyau", "diagonal pipe 1", Preset.WOType.Static, sprite46, hitbox27, epicenterOffset27, interactions27, "Builds", extraReach27, new List<ItemStack>()
      {
        new ItemStack(2, 5)
      });
      presetList18.Add(preset19);
      Sprite sprite47 = new Sprite("diagonalpipe1rev", ContentLoadingWrapper.Load<Texture2D>("bamboopipe/diagonalpipe1rev"), new List<SubSprite>());
      sprite47.groundSubsprite = new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bamboopipe/diagonalpipe1_rev_shadow"), new Vector2(1f, 147f), opacity: 0.3f)
      };
      sprite47.Width = 191;
      sprite47.animated = true;
      sprite47.MillisecondsPerFrame = 70;
      List<Preset> presetList19 = presets;
      Sprite sprite48 = sprite47;
      List<Rectangle> hitbox28 = new List<Rectangle>();
      hitbox28.Add(new Rectangle(-15, 254, 30, 20));
      Vector2 epicenterOffset28 = new Vector2(86f, 201f);
      IDodoInteraction[] interactions28 = new IDodoInteraction[4];
      Vector2? extraReach28 = new Vector2?();
      Preset preset20 = new Preset("Tuyau", "diagonal pipe 1 rev", Preset.WOType.Static, sprite48, hitbox28, epicenterOffset28, interactions28, "Builds", extraReach28, new List<ItemStack>()
      {
        new ItemStack(2, 5)
      });
      presetList19.Add(preset20);
      Sprite sprite49 = new Sprite("diagonalpipe2rev", ContentLoadingWrapper.Load<Texture2D>("bamboopipe/diagonalpipe2rev"), new List<SubSprite>());
      sprite49.groundSubsprite = new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bamboopipe/diagonalpipe2_rev_shadow"), new Vector2(1f, 147f), opacity: 0.3f)
      };
      sprite49.Width = 191;
      sprite49.animated = true;
      sprite49.MillisecondsPerFrame = 70;
      List<Preset> presetList20 = presets;
      Sprite sprite50 = sprite49;
      List<Rectangle> hitbox29 = new List<Rectangle>();
      hitbox29.Add(new Rectangle(-15, 254, 30, 20));
      Vector2 epicenterOffset29 = new Vector2(86f, 201f);
      IDodoInteraction[] interactions29 = new IDodoInteraction[4];
      Vector2? extraReach29 = new Vector2?();
      Preset preset21 = new Preset("Tuyau", "diagonal pipe 2 rev", Preset.WOType.Static, sprite50, hitbox29, epicenterOffset29, interactions29, "Builds", extraReach29, new List<ItemStack>()
      {
        new ItemStack(2, 5)
      });
      presetList20.Add(preset21);
      Sprite sprite51 = new Sprite("bamboodiag2+", ContentLoadingWrapper.Load<Texture2D>("bamboopipe/bamboodiag2+"), new List<SubSprite>());
      sprite51.groundSubsprite = new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bamboopipe/diagonalpipe2_+_shadow"), new Vector2(1f, 147f), opacity: 0.3f)
      };
      sprite51.Width = 212;
      sprite51.animated = true;
      sprite51.MillisecondsPerFrame = 70;
      List<Preset> presetList21 = presets;
      Sprite sprite52 = sprite51;
      List<Rectangle> hitbox30 = new List<Rectangle>();
      hitbox30.Add(new Rectangle(180, 288, 30, 20));
      Vector2 epicenterOffset30 = new Vector2(110f, 225f);
      IDodoInteraction[] interactions30 = new IDodoInteraction[4];
      Vector2? extraReach30 = new Vector2?();
      Preset preset22 = new Preset("Tuyau", "diagonal pipe 2 +", Preset.WOType.Static, sprite52, hitbox30, epicenterOffset30, interactions30, "Builds", extraReach30, new List<ItemStack>()
      {
        new ItemStack(2, 5)
      });
      presetList21.Add(preset22);
      Sprite sprite53 = new Sprite("bamboodiag2rev+", ContentLoadingWrapper.Load<Texture2D>("bamboopipe/bamboodiag2rev+"), new List<SubSprite>());
      sprite53.groundSubsprite = new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bamboopipe/diagonalpipe2_rev+_shadow"), new Vector2(1f, 147f), opacity: 0.3f)
      };
      sprite53.Width = 212;
      sprite53.animated = true;
      sprite53.MillisecondsPerFrame = 70;
      List<Preset> presetList22 = presets;
      Sprite sprite54 = sprite53;
      List<Rectangle> hitbox31 = new List<Rectangle>();
      hitbox31.Add(new Rectangle(-7, 288, 30, 20));
      Vector2 epicenterOffset31 = new Vector2(110f, 225f);
      IDodoInteraction[] interactions31 = new IDodoInteraction[4];
      Vector2? extraReach31 = new Vector2?();
      Preset preset23 = new Preset("Tuyau", "diagonal pipe 2 rev +", Preset.WOType.Static, sprite54, hitbox31, epicenterOffset31, interactions31, "Builds", extraReach31, new List<ItemStack>()
      {
        new ItemStack(2, 5)
      });
      presetList22.Add(preset23);
      Sprite sprite55 = new Sprite("diagonalpipe2", ContentLoadingWrapper.Load<Texture2D>("bamboopipe/diagonalpipe2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bamboopipe/diagonalpipe2_shadow"), new Vector2(1f, 147f), opacity: 0.3f)
      });
      sprite55.Width = 191;
      sprite55.animated = true;
      sprite55.MillisecondsPerFrame = 70;
      List<Preset> presetList23 = presets;
      Sprite sprite56 = sprite55;
      List<Rectangle> hitbox32 = new List<Rectangle>();
      hitbox32.Add(new Rectangle(168, 257, 30, 20));
      Vector2 epicenterOffset32 = new Vector2(92f, 212f);
      IDodoInteraction[] interactions32 = new IDodoInteraction[4];
      Vector2? extraReach32 = new Vector2?();
      Preset preset24 = new Preset("Tuyau", "diagonal pipe 2", Preset.WOType.Static, sprite56, hitbox32, epicenterOffset32, interactions32, "Builds", extraReach32, new List<ItemStack>()
      {
        new ItemStack(2, 5)
      });
      presetList23.Add(preset24);
      Sprite sprite57 = new Sprite("bamboodiag2rev+double", ContentLoadingWrapper.Load<Texture2D>("bamboopipe/bamboodiag2rev+double"), new List<SubSprite>());
      sprite57.groundSubsprite = new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bamboopipe/diagonalpipe2_rev+double_shadow"), new Vector2(1f, 147f), opacity: 0.3f)
      };
      sprite57.Width = 262;
      sprite57.animated = true;
      sprite57.MillisecondsPerFrame = 70;
      List<Preset> presetList24 = presets;
      Sprite sprite58 = sprite57;
      List<Rectangle> hitbox33 = new List<Rectangle>();
      hitbox33.Add(new Rectangle(-7, 288, 30, 20));
      Vector2 epicenterOffset33 = new Vector2(110f, 225f);
      IDodoInteraction[] interactions33 = new IDodoInteraction[4];
      Vector2? extraReach33 = new Vector2?();
      Preset preset25 = new Preset("Tuyau", "diagonal pipe 2 rev + double", Preset.WOType.Static, sprite58, hitbox33, epicenterOffset33, interactions33, "Builds", extraReach33, new List<ItemStack>()
      {
        new ItemStack(2, 5)
      });
      presetList24.Add(preset25);
      Sprite sprite59 = new Sprite("volcano roc", ContentLoadingWrapper.Load<Texture2D>("volcanoroc"), new List<SubSprite>());
      List<Preset> presetList25 = presets;
      Sprite sprite60 = sprite59;
      List<Rectangle> hitbox34 = new List<Rectangle>();
      hitbox34.Add(new Rectangle(0, 57, 60, 20));
      Vector2 epicenterOffset34 = new Vector2(31f, 68f);
      IDodoInteraction[] interactions34 = new IDodoInteraction[4];
      Vector2? extraReach34 = new Vector2?(new Vector2(35f, 0.0f));
      Preset preset26 = new Preset("Roche volcanique", "volcano roc", Preset.WOType.Static, sprite60, hitbox34, epicenterOffset34, interactions34, "Rocks", extraReach34);
      presetList25.Add(preset26);
      Sprite sprite61 = new Sprite("reverse volcano roc", ContentLoadingWrapper.Load<Texture2D>("volcanorocreverse"), new List<SubSprite>());
      List<Preset> presetList26 = presets;
      Sprite sprite62 = sprite61;
      List<Rectangle> hitbox35 = new List<Rectangle>();
      hitbox35.Add(new Rectangle(0, 57, 60, 20));
      Vector2 epicenterOffset35 = new Vector2(31f, 68f);
      IDodoInteraction[] interactions35 = new IDodoInteraction[4];
      Vector2? extraReach35 = new Vector2?(new Vector2(35f, 0.0f));
      Preset preset27 = new Preset("Roche volcanique", "reverse volcano roc", Preset.WOType.Static, sprite62, hitbox35, epicenterOffset35, interactions35, "Rocks", extraReach35);
      presetList26.Add(preset27);
      presets.Add(new Preset("Nuage", "watercloud", Preset.WOType.Static, new Sprite("watercloud", ContentLoadingWrapper.Load<Texture2D>("watercloud"), new List<SubSprite>())
      {
        Width = 100,
        animated = true,
        MillisecondsPerFrame = 50
      }, new List<Rectangle>(), new Vector2(50f, 20f), new IDodoInteraction[4], "Other", new Vector2?(new Vector2(0.0f, 0.0f))));
      presets.Add(new Preset("Nuage", "watercloud2", Preset.WOType.Static, new Sprite("watercloud2", ContentLoadingWrapper.Load<Texture2D>("watercloud2"), new List<SubSprite>())
      {
        Width = 100,
        animated = true,
        MillisecondsPerFrame = 60
      }, new List<Rectangle>(), new Vector2(50f, 20f), new IDodoInteraction[4], "Other", new Vector2?(new Vector2(0.0f, 0.0f))));
      Sprite sprite63 = new Sprite("roc", ContentLoadingWrapper.Load<Texture2D>("roc"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("roc_shadow"), new Vector2(-4f, 106f), opacity: 0.4f)
      });
      Sprite sprite64 = new Sprite("roc_cut", ContentLoadingWrapper.Load<Texture2D>("roc_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("roc_shadow"), new Vector2(-4f, 106f), opacity: 0.4f)
      });
      presets.Add(new Preset("Rocher", "Roc", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite63,
        sprite64
      }, new List<Rectangle>()
      {
        new Rectangle(-10, 90, 125, 40)
      }, new Vector2(62f, 107f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(3, 2)
        })
      }, "Rocks", new Vector2?(new Vector2(35f, 0.0f)), 5));
      Sprite sprite65 = new Sprite("unsettlingroc", ContentLoadingWrapper.Load<Texture2D>("unsettlingroc"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("unsettlingroc_shadow"), new Vector2(0.0f, 70f), opacity: 0.4f)
      });
      List<Preset> presetList27 = presets;
      Sprite sprite66 = sprite65;
      List<Rectangle> hitbox36 = new List<Rectangle>();
      hitbox36.Add(new Rectangle(5, 60, 50, 30));
      Vector2 epicenterOffset36 = new Vector2(63f, 150f);
      IDodoInteraction[] interactions36 = new IDodoInteraction[4];
      Vector2? extraReach36 = new Vector2?(new Vector2(0.0f, 0.0f));
      Preset preset28 = new Preset("unsettlingroc", "unsettlingroc", Preset.WOType.Static, sprite66, hitbox36, epicenterOffset36, interactions36, "Rocks", extraReach36);
      presetList27.Add(preset28);
      Sprite sprite67 = new Sprite("ronces", ContentLoadingWrapper.Load<Texture2D>("ronces"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("ronces_shadow"), new Vector2(1f, 8f), opacity: 0.4f)
      });
      List<Preset> presetList28 = presets;
      Sprite sprite68 = sprite67;
      List<Rectangle> hitbox37 = new List<Rectangle>();
      hitbox37.Add(new Rectangle(5, 0, 75, 80));
      Vector2 epicenterOffset37 = new Vector2(63f, 150f);
      IDodoInteraction[] interactions37 = new IDodoInteraction[4];
      Vector2? extraReach37 = new Vector2?(new Vector2(0.0f, 0.0f));
      Preset preset29 = new Preset("ronces", "ronces", Preset.WOType.Static, sprite68, hitbox37, epicenterOffset37, interactions37, "Plants", extraReach37);
      presetList28.Add(preset29);
      Sprite sprite69 = new Sprite("flatronce", ContentLoadingWrapper.Load<Texture2D>("flatronce"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("flatronce_shadow"), new Vector2(0.0f, 51f), opacity: 0.4f)
      });
      List<Preset> presetList29 = presets;
      Sprite sprite70 = sprite69;
      List<Rectangle> hitbox38 = new List<Rectangle>();
      hitbox38.Add(new Rectangle(0, 51, 60, 10));
      Vector2 epicenterOffset38 = new Vector2(29f, 54f);
      IDodoInteraction[] interactions38 = new IDodoInteraction[4];
      Vector2? extraReach38 = new Vector2?(new Vector2(0.0f, 0.0f));
      Preset preset30 = new Preset("flatronce", "flatronce", Preset.WOType.Static, sprite70, hitbox38, epicenterOffset38, interactions38, "Plants", extraReach38);
      presetList29.Add(preset30);
      Sprite sprite71 = new Sprite("turningronce", ContentLoadingWrapper.Load<Texture2D>("turningronce"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("turningronce_shadow"), new Vector2(1f, 35f), opacity: 0.4f)
      });
      List<Preset> presetList30 = presets;
      Sprite sprite72 = sprite71;
      List<Rectangle> hitbox39 = new List<Rectangle>();
      hitbox39.Add(new Rectangle(0, 31, 15, 29));
      hitbox39.Add(new Rectangle(15, 52, 60, 8));
      hitbox39.Add(new Rectangle(65, 60, 10, 34));
      hitbox39.Add(new Rectangle(75, 86, 28, 8));
      Vector2 epicenterOffset39 = new Vector2(50f, 35f);
      IDodoInteraction[] interactions39 = new IDodoInteraction[4];
      Vector2? extraReach39 = new Vector2?(new Vector2(0.0f, 0.0f));
      Preset preset31 = new Preset("turningronce", "turningronce", Preset.WOType.Static, sprite72, hitbox39, epicenterOffset39, interactions39, "Plants", extraReach39);
      presetList30.Add(preset31);
      Sprite sprite73 = new Sprite("quartz roc", ContentLoadingWrapper.Load<Texture2D>("quartzroc"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("roc_shadow"), new Vector2(-4f, 106f), opacity: 0.4f)
      });
      presets.Add(new Preset("Rocher avec quartz", "Quartz Roc", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite73,
        sprite64
      }, new List<Rectangle>()
      {
        new Rectangle(-10, 90, 125, 40)
      }, new Vector2(62f, 107f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[2]
        {
          new ItemStack(3, 1),
          new ItemStack(7, 1)
        })
      }, "Rocks", new Vector2?(new Vector2(35f, 0.0f)), 5));
      Sprite sprite74 = new Sprite("bquartz", ContentLoadingWrapper.Load<Texture2D>("bigquartz"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bigquartz_shadow"), new Vector2(3f, 109f), opacity: 0.4f)
      });
      Sprite sprite75 = new Sprite("bquartz", ContentLoadingWrapper.Load<Texture2D>("bigquartz_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bigquartz_shadow"), new Vector2(3f, 109f), opacity: 0.4f)
      });
      presets.Add(new Preset("bquartz", "Big Quartz", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite74,
        sprite75
      }, new List<Rectangle>()
      {
        new Rectangle(6, 120, 170, 16)
      }, new Vector2(100f, 128f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[2]
        {
          new ItemStack(0, 3),
          new ItemStack(7, 3)
        })
      }, "Rocks", new Vector2?(new Vector2(35f, 0.0f)), 5));
      Sprite sprite76 = new Sprite("roc", ContentLoadingWrapper.Load<Texture2D>("rocb"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("rocb_shadow"), new Vector2(-4f, 106f), opacity: 0.4f)
      });
      Sprite sprite77 = new Sprite("rocb_cutted", ContentLoadingWrapper.Load<Texture2D>("rocb_cutted"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("rocb_shadow"), new Vector2(-4f, 106f), opacity: 0.4f)
      });
      presets.Add(new Preset("Rocher", "Roc b", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite76,
        sprite77
      }, new List<Rectangle>()
      {
        new Rectangle(-10, 110, 125, 40)
      }, new Vector2(62f, 117f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(3, 1)
        })
      }, "Rocks", new Vector2?(new Vector2(35f, 0.0f)), 5));
      Sprite sprite78 = new Sprite("upsroc", ContentLoadingWrapper.Load<Texture2D>("roc"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("roc_shadow"), new Vector2(-4f, 106f), new Vector2?(new Vector2(-4f, 106f)), 0.65f)
      });
      sprite78.verticalMirroring = true;
      List<Preset> presetList31 = presets;
      Sprite sprite79 = sprite78;
      List<Rectangle> hitbox40 = new List<Rectangle>();
      hitbox40.Add(new Rectangle(-10, 90, 122, 40));
      Vector2 epicenterOffset40 = new Vector2(62f, 107f);
      IDodoInteraction[] interactions40 = new IDodoInteraction[4];
      Vector2? extraReach40 = new Vector2?(new Vector2(35f, 0.0f));
      Preset preset32 = new Preset("Rocher", "UpsideDownRoc", Preset.WOType.Static, sprite79, hitbox40, epicenterOffset40, interactions40, "Rocks", extraReach40);
      presetList31.Add(preset32);
      Sprite sprite80 = new Sprite("pillar1", ContentLoadingWrapper.Load<Texture2D>("pillar/pillar1"));
      Sprite sprite81 = new Sprite("pillarcut", ContentLoadingWrapper.Load<Texture2D>("pillar/pillarcut"));
      presets.Add(new Preset("Pillier", "pillar1", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite80,
        sprite81
      }, new List<Rectangle>()
      {
        new Rectangle(0, 270, 64, 30)
      }, new Vector2(33f, 282f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(3, 1)
        })
      }, "Rocks", new Vector2?(new Vector2(35f, 0.0f)), 2));
      Sprite sprite82 = new Sprite("pillar2", ContentLoadingWrapper.Load<Texture2D>("pillar/pillar2"));
      presets.Add(new Preset("Pillier", "pillar2", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite82,
        sprite81
      }, new List<Rectangle>()
      {
        new Rectangle(0, 270, 64, 30)
      }, new Vector2(33f, 282f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(3, 1)
        })
      }, "Rocks", new Vector2?(new Vector2(35f, 0.0f)), 3));
      Sprite sprite83 = new Sprite("pillar3", ContentLoadingWrapper.Load<Texture2D>("pillar/pillar3"));
      presets.Add(new Preset("Pillier", "pillar3", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite83,
        sprite81
      }, new List<Rectangle>()
      {
        new Rectangle(0, 270, 64, 30)
      }, new Vector2(33f, 282f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(3, 2)
        })
      }, "Rocks", new Vector2?(new Vector2(35f, 0.0f)), 4));
      Sprite sprite84 = new Sprite("pillar4", ContentLoadingWrapper.Load<Texture2D>("pillar/pillar4"));
      presets.Add(new Preset("Pillier", "pillar4", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite84,
        sprite81
      }, new List<Rectangle>()
      {
        new Rectangle(0, 270, 64, 30)
      }, new Vector2(33f, 282f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(3, 2)
        })
      }, "Rocks", new Vector2?(new Vector2(35f, 0.0f)), 5));
      Sprite sprite85 = new Sprite("pillar5", ContentLoadingWrapper.Load<Texture2D>("pillar/pillar5"));
      presets.Add(new Preset("Pillier", "pillar5", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite85,
        sprite81
      }, new List<Rectangle>()
      {
        new Rectangle(0, 270, 64, 30)
      }, new Vector2(33f, 282f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(3, 3)
        })
      }, "Rocks", new Vector2?(new Vector2(35f, 0.0f)), 6));
      Sprite sprite86 = new Sprite("pillar6", ContentLoadingWrapper.Load<Texture2D>("pillar/pillar6"));
      presets.Add(new Preset("Pillier", "pillar6", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite86,
        sprite81
      }, new List<Rectangle>()
      {
        new Rectangle(0, 270, 64, 30)
      }, new Vector2(33f, 282f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(3, 4)
        })
      }, "Rocks", new Vector2?(new Vector2(35f, 0.0f)), 8));
      Sprite sprite87 = new Sprite("big volcano roc", ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc_shadow"), new Vector2(-16f, 100f), opacity: 0.4f)
      });
      Sprite sprite88 = new Sprite("big volcano roc cut", ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc_shadow"), new Vector2(-16f, 100f), opacity: 0.4f)
      });
      presets.Add(new Preset("Roche volcanique", "Big volcano roc", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite87,
        sprite88
      }, new List<Rectangle>()
      {
        new Rectangle(8, 130, 200, 100)
      }, new Vector2(110f, 145f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(9, 3)
        })
      }, "Rocks", new Vector2?(new Vector2(100f, 65f)), 5));
      Sprite sprite89 = new Sprite("big volcano roc2", ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc2_shadow"), new Vector2(-16f, 238f), opacity: 0.4f)
      });
      Sprite sprite90 = new Sprite("big volcano roc2 cut", ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc2_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc2_shadow"), new Vector2(-16f, 238f), opacity: 0.4f)
      });
      presets.Add(new Preset("Roche volcanique", "Big volcano roc2", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite89,
        sprite90
      }, new List<Rectangle>()
      {
        new Rectangle(0, 270, 200, 80)
      }, new Vector2(110f, 300f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(9, 3)
        })
      }, "Rocks", new Vector2?(new Vector2(100f, 50f)), 5));
      Sprite sprite91 = new Sprite("BigVolcanoRocNew1", ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc1new"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc1new_shadow"), new Vector2(-8f, 162f), opacity: 0.4f)
      });
      Sprite sprite92 = new Sprite("BigVolcanoRocNew1 cut", ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc1new_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc1new_shadow"), new Vector2(-8f, 162f), opacity: 0.4f)
      });
      presets.Add(new Preset("BigVolcanoRocNew1", "BigVolcanoRocNew1", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite91,
        sprite92
      }, new List<Rectangle>()
      {
        new Rectangle(5, 177, 161, 30)
      }, new Vector2(88f, 190f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(9, 2)
        })
      }, "Rocks", new Vector2?(new Vector2(80f, 40f)), 4));
      Sprite sprite93 = new Sprite("BigVolcanoRocNew2", ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc2new"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc2new_shadow"), new Vector2(-6f, 206f), opacity: 0.4f)
      });
      Sprite sprite94 = new Sprite("BigVolcanoRocNew2 cut", ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc2new_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bigvolcanoroc2new_shadow"), new Vector2(-6f, 206f), opacity: 0.4f)
      });
      presets.Add(new Preset("BigVolcanoRocNew2", "BigVolcanoRocNew2", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite93,
        sprite94
      }, new List<Rectangle>()
      {
        new Rectangle(0, 210, 175, 35)
      }, new Vector2(93f, 193f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(9, 2)
        })
      }, "Rocks", new Vector2?(new Vector2(80f, 40f)), 4));
      Sprite sprite95 = new Sprite("bamboo_shroom", ContentLoadingWrapper.Load<Texture2D>("shrooms/bamboo_shroom"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("shrooms/bamboo_shroom_shadow"), new Vector2(4f, 174f), opacity: 0.4f)
      });
      Sprite sprite96 = new Sprite("bamboo_shroom_cut", ContentLoadingWrapper.Load<Texture2D>("shrooms/bamboo_shroom_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("shrooms/bamboo_shroom_shadow"), new Vector2(4f, 174f), opacity: 0.4f)
      });
      presets.Add(new Preset("Bamboo shroom", "Bamboo shroom", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite95,
        sprite96
      }, new List<Rectangle>()
      {
        new Rectangle(7, 182, 75, 15)
      }, new Vector2(47f, 192f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(12, 2)
        })
      }, "Shrooms", new Vector2?(new Vector2(30f, 15f)), 2));
      Sprite sprite97 = new Sprite("roc_shroom", ContentLoadingWrapper.Load<Texture2D>("shrooms/roc_shroom"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("shrooms/roc_shroom_shadow"), new Vector2(1f, 116f), opacity: 0.4f)
      });
      Sprite sprite98 = new Sprite("roc_shroom_cut", ContentLoadingWrapper.Load<Texture2D>("shrooms/roc_shroom_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("shrooms/roc_shroom_shadow"), new Vector2(1f, 116f), opacity: 0.4f)
      });
      presets.Add(new Preset("roc shroom", "roc shroom", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite97,
        sprite98
      }, new List<Rectangle>()
      {
        new Rectangle(2, 122, 112, 15)
      }, new Vector2(55f, 131f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(12, 2)
        })
      }, "Shrooms", new Vector2?(new Vector2(30f, 15f)), 2));
      Sprite sprite99 = new Sprite("doodshroom0", ContentLoadingWrapper.Load<Texture2D>("shrooms/dood_shroom0"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("shrooms/dood_shroom_shadow0"), new Vector2(14f, 100f), opacity: 0.4f)
      });
      Sprite sprite100 = new Sprite("doodshroom1", ContentLoadingWrapper.Load<Texture2D>("shrooms/dood_shroom1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("shrooms/dood_shroom_shadow0"), new Vector2(15f, 97f), opacity: 0.4f)
      });
      Sprite sprite101 = new Sprite("doodshroom2", ContentLoadingWrapper.Load<Texture2D>("shrooms/dood_shroom2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("shrooms/dood_shroom_shadow"), new Vector2(0.0f, 90f), opacity: 0.4f)
      });
      Sprite sprite102 = new Sprite("doodshroom3", ContentLoadingWrapper.Load<Texture2D>("shrooms/dood_shroom3"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("shrooms/dood_shroom_shadow"), new Vector2(1f, 89f), opacity: 0.4f)
      });
      presets.Add(new Preset("Dood shroom", "Dood shroom", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite102,
        sprite101,
        sprite100,
        sprite99
      }, new List<Rectangle>()
      {
        new Rectangle(5, 94, 67, 18)
      }, new Vector2(32f, 103f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(12, 1)
        })
      }, "Shrooms", new Vector2?(new Vector2(0.0f, 0.0f)), 5, 3));
      Sprite sprite103 = new Sprite("tiny_shroom", ContentLoadingWrapper.Load<Texture2D>("shrooms/tiny_shroom"));
      presets.Add(new Preset("Tiny shroom", "Tiny shroom", Preset.WOType.Static, sprite103, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Shrooms"));
      Sprite sprite104 = new Sprite("palm_shroom", ContentLoadingWrapper.Load<Texture2D>("shrooms/palm_shroom"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("shrooms/palm_shroom_shadow"), new Vector2(3f, 224f), opacity: 0.4f)
      });
      Sprite sprite105 = new Sprite("palm_shroom_cut", ContentLoadingWrapper.Load<Texture2D>("shrooms/palm_shroom_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("shrooms/palm_shroom_cut_shadow"), new Vector2(70f, 241f), opacity: 0.4f)
      });
      presets.Add(new Preset("palm shroom", "palm shroom", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite104,
        sprite105
      }, new List<Rectangle>()
      {
        new Rectangle(81, 241, 24, 13)
      }, new Vector2(97f, 248f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(12, 3)
        })
      }, "Shrooms", new Vector2?(new Vector2(10f, 5f)), 3));
      Sprite sprite106 = new Sprite("shroom", ContentLoadingWrapper.Load<Texture2D>("shrooms/shroom"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("shrooms/shroom_shadow"), new Vector2(4f, 106f), opacity: 0.4f)
      });
      Sprite sprite107 = new Sprite("shroom_cut", ContentLoadingWrapper.Load<Texture2D>("shrooms/shroom_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("shrooms/small_shroom_shadow"), new Vector2(43f, 116f), opacity: 0.4f)
      });
      presets.Add(new Preset("regular shroom", "regular shroom", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite106,
        sprite107
      }, new List<Rectangle>()
      {
        new Rectangle(4, 114, 102, 10)
      }, new Vector2(61f, 123f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(12, 2)
        })
      }, "Shrooms", new Vector2?(new Vector2(10f, 5f)), 2));
      Sprite sprite108 = new Sprite("small_shroom", ContentLoadingWrapper.Load<Texture2D>("shrooms/small_shroom"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("shrooms/small_shroom_shadow"), new Vector2(0.0f, 63f), opacity: 0.4f)
      });
      List<Preset> presetList32 = presets;
      Sprite sprite109 = sprite108;
      List<Rectangle> hitbox41 = new List<Rectangle>();
      hitbox41.Add(new Rectangle(2, 66, 26, 10));
      Vector2 epicenterOffset41 = new Vector2(14f, 71f);
      IDodoInteraction[] interactions41 = new IDodoInteraction[4];
      Vector2? extraReach41 = new Vector2?(new Vector2(0.0f, 0.0f));
      Preset preset33 = new Preset("small shroom", "small shroom", Preset.WOType.Static, sprite109, hitbox41, epicenterOffset41, interactions41, "Shrooms", extraReach41);
      presetList32.Add(preset33);
      Sprite sprite110 = new Sprite("pin1", ContentLoadingWrapper.Load<Texture2D>("pin1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("pin1_shadow"), new Vector2(-7f, 384f), opacity: 0.4f)
      });
      Sprite sprite111 = new Sprite("pin1_cut1", ContentLoadingWrapper.Load<Texture2D>("pin1_cut1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("pin1_cut1_shadow"), new Vector2(47f, 378f), opacity: 0.4f)
      });
      Sprite sprite112 = new Sprite("pin1_cut2", ContentLoadingWrapper.Load<Texture2D>("pin1_cut2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("pin1_cut2_shadow"), new Vector2(63f, 391f), opacity: 0.4f)
      });
      presets.Add(new Preset("pin1", "pin1", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite110,
        sprite112,
        sprite111
      }, new List<Rectangle>()
      {
        new Rectangle(85, 384, 40, 32)
      }, new Vector2(108f, 405f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(1, 4)
        })
      }, "Trees", new Vector2?(new Vector2(35f, 0.0f)), 2));
      Sprite sprite113 = new Sprite("pin2", ContentLoadingWrapper.Load<Texture2D>("pin2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("pin2_shadow"), new Vector2(-6f, 377f), opacity: 0.4f)
      });
      Sprite sprite114 = new Sprite("pin2_cut1", ContentLoadingWrapper.Load<Texture2D>("pin2_cut1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("pin2_cut1_shadow"), new Vector2(66f, 395f), opacity: 0.4f)
      });
      Sprite sprite115 = new Sprite("pin2_cut2", ContentLoadingWrapper.Load<Texture2D>("pin2_cut2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("pin2_cut2_shadow"), new Vector2(62f, 391f), opacity: 0.4f)
      });
      presets.Add(new Preset("pin2", "pin2", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite113,
        sprite115,
        sprite114
      }, new List<Rectangle>()
      {
        new Rectangle(96, 400, 56, 26)
      }, new Vector2(120f, 414f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(1, 4)
        })
      }, "Trees", new Vector2?(new Vector2(35f, 0.0f)), 2));
      Sprite sprite116 = new Sprite("binpush", ContentLoadingWrapper.Load<Texture2D>("pinbush"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("pinbush_shadow"), new Vector2(4f, 67f), opacity: 0.4f)
      });
      List<Preset> presetList33 = presets;
      Sprite sprite117 = sprite116;
      List<Rectangle> hitbox42 = new List<Rectangle>();
      hitbox42.Add(new Rectangle(8, 70, 129, 19));
      Vector2 epicenterOffset42 = new Vector2(84f, 85f);
      IDodoInteraction[] interactions42 = new IDodoInteraction[4];
      Vector2? extraReach42 = new Vector2?(new Vector2(0.0f, 0.0f));
      Preset preset34 = new Preset("Pin bush", "pinbush", Preset.WOType.Static, sprite117, hitbox42, epicenterOffset42, interactions42, "Plants", extraReach42);
      presetList33.Add(preset34);
      Sprite sprite118 = new Sprite("cocotier1/standard", ContentLoadingWrapper.Load<Texture2D>("cocotier1/standard"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier1/shadow"), new Vector2(10f, 225f), opacity: 0.4f)
      });
      Sprite sprite119 = new Sprite("cocotier1/growing", ContentLoadingWrapper.Load<Texture2D>("cocotier1/growing"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier1/shadow_cut"), new Vector2(119f, 241f), opacity: 0.4f)
      });
      Sprite sprite120 = new Sprite("cocotier1/cut", ContentLoadingWrapper.Load<Texture2D>("cocotier1/cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier1/shadow_cut"), new Vector2(119f, 241f), opacity: 0.4f)
      });
      presets.Add(new Preset("Cocotier", "Cocotier1", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite118,
        sprite119,
        sprite120
      }, new List<Rectangle>()
      {
        new Rectangle(120, 225, 27, 28)
      }, new Vector2(139f, 244f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[2]
        {
          new ItemStack(1, 2),
          new ItemStack(0, 1)
        })
      }, "Trees", new Vector2?(new Vector2(35f, 0.0f)), 2));
      Sprite sprite121 = new Sprite("mircocotier1/standard", ContentLoadingWrapper.Load<Texture2D>("cocotier1/standard"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier1/shadow"), new Vector2(-7f, 225f), new Vector2?(new Vector2(-7f, 225f)), 0.4f)
      })
      {
        horizontalMirroring = true
      };
      Sprite sprite122 = new Sprite("mircocotier1/growing", ContentLoadingWrapper.Load<Texture2D>("cocotier1/growing"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier1/shadow_cut"), new Vector2(-7f, 225f), new Vector2?(new Vector2(-5f, 240f)), 0.4f)
      })
      {
        horizontalMirroring = true
      };
      Sprite sprite123 = new Sprite("mircocotier1/cut", ContentLoadingWrapper.Load<Texture2D>("cocotier1/cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier1/shadow_cut"), new Vector2(-7f, 225f), new Vector2?(new Vector2(-5f, 240f)), 0.4f)
      })
      {
        horizontalMirroring = true
      };
      presets.Add(new Preset("Cocotier", "Cocotier1Mirrored", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite121,
        sprite122,
        sprite123
      }, new List<Rectangle>()
      {
        new Rectangle(-2, 225, 27, 28)
      }, new Vector2(13f, 244f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[2]
        {
          new ItemStack(1, 2),
          new ItemStack(0, 1)
        })
      }, "Trees", new Vector2?(new Vector2(35f, 0.0f)), 2));
      Sprite sprite124 = new Sprite("cocotier2/standard", ContentLoadingWrapper.Load<Texture2D>("cocotier2/standard"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier2/shadow"), new Vector2(10f, 225f), opacity: 0.4f)
      });
      Sprite sprite125 = new Sprite("cocotier2/growing", ContentLoadingWrapper.Load<Texture2D>("cocotier2/growing"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier2/shadow_cut"), new Vector2(38f, 231f), opacity: 0.4f)
      });
      Sprite sprite126 = new Sprite("cocotier2/cut", ContentLoadingWrapper.Load<Texture2D>("cocotier2/cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier2/shadow_cut"), new Vector2(38f, 231f), opacity: 0.4f)
      });
      presets.Add(new Preset("Cocotier", "Cocotier2", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite124,
        sprite125,
        sprite126
      }, new List<Rectangle>()
      {
        new Rectangle(39, 215, 28, 28)
      }, new Vector2(56f, 229f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[2]
        {
          new ItemStack(1, 2),
          new ItemStack(0, 1)
        })
      }, "Trees", new Vector2?(new Vector2(35f, 0.0f)), 2));
      Sprite sprite127 = new Sprite("cocotier3/standard", ContentLoadingWrapper.Load<Texture2D>("cocotier3/standard"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier3/shadow"), new Vector2(-8f, 251f), opacity: 0.4f)
      });
      Sprite sprite128 = new Sprite("cocotier3/growing", ContentLoadingWrapper.Load<Texture2D>("cocotier3/growing"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier3/shadow_cut"), new Vector2(-3f, (float) byte.MaxValue), opacity: 0.4f)
      });
      Sprite sprite129 = new Sprite("cocotier3/cut", ContentLoadingWrapper.Load<Texture2D>("cocotier3/cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier3/shadow_cut"), new Vector2(-3f, (float) byte.MaxValue), opacity: 0.4f)
      });
      presets.Add(new Preset("Cocotier", "Cocotier3", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite127,
        sprite128,
        sprite129
      }, new List<Rectangle>()
      {
        new Rectangle(-1, 240, 28, 28)
      }, new Vector2(13f, 256f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[2]
        {
          new ItemStack(1, 2),
          new ItemStack(0, 1)
        })
      }, "Trees", growtime: 2));
      presets.Add(new Preset("Cocotier", "Cocotier3Mirrored", Preset.WOType.Growable, new List<Sprite>()
      {
        new Sprite("mircocotier3/standard", ContentLoadingWrapper.Load<Texture2D>("cocotier3/standard"), new List<SubSprite>()
        {
          new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier3/shadow"), new Vector2(45f, 251f), new Vector2?(new Vector2(45f, 251f)), 0.4f)
        })
        {
          horizontalMirroring = true
        },
        new Sprite("mircocotier3/growing", ContentLoadingWrapper.Load<Texture2D>("cocotier3/growing"), new List<SubSprite>()
        {
          new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier3/shadow_cut"), new Vector2(45f, 251f), new Vector2?(new Vector2(118f, 257f)), 0.4f)
        })
        {
          horizontalMirroring = true
        },
        new Sprite("mircocotier3/cut", ContentLoadingWrapper.Load<Texture2D>("cocotier3/cut"), new List<SubSprite>()
        {
          new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier3/shadow_cut"), new Vector2(45f, 251f), new Vector2?(new Vector2(118f, 257f)), 0.4f)
        })
        {
          horizontalMirroring = true
        }
      }, new List<Rectangle>()
      {
        new Rectangle(121, 240, 28, 28)
      }, new Vector2(133f, 256f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[2]
        {
          new ItemStack(1, 2),
          new ItemStack(0, 1)
        })
      }, "Trees", growtime: 2));
      Sprite sprite130 = new Sprite("bamboo", ContentLoadingWrapper.Load<Texture2D>("bamboo"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bamboo_shadow"), new Vector2(7f, 152f), opacity: 0.4f)
      });
      Sprite sprite131 = new Sprite("bamboo_cut", ContentLoadingWrapper.Load<Texture2D>("bamboo_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bamboo_shadow"), new Vector2(7f, 152f), opacity: 0.3f)
      });
      Sprite sprite132 = new Sprite("bamboo2", ContentLoadingWrapper.Load<Texture2D>("bamboo2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bamboo_shadow"), new Vector2(1f, 150f), opacity: 0.4f)
      });
      Sprite sprite133 = new Sprite("bamboo2_cut", ContentLoadingWrapper.Load<Texture2D>("bamboo2_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bamboo_shadow"), new Vector2(1f, 150f), opacity: 0.3f)
      });
      presets.Add(new Preset("Bamboo", "Bamboo", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite130,
        sprite131
      }, new List<Rectangle>()
      {
        new Rectangle(12, 138, 56, 24)
      }, new Vector2(41f, 150f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(2, 2)
        })
      }, "Plants", new Vector2?(new Vector2(40f, 10f)), 2));
      presets.Add(new Preset("Bamboo 2", "Bamboo 2", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite132,
        sprite133
      }, new List<Rectangle>()
      {
        new Rectangle(2, 138, 56, 24)
      }, new Vector2(41f, 150f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(2, 2)
        })
      }, "Plants", new Vector2?(new Vector2(40f, 10f)), 2));
      Sprite sprite134 = new Sprite("longbush", ContentLoadingWrapper.Load<Texture2D>("longbush"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("longbush_shadow"), new Vector2(5f, 140f), opacity: 0.4f)
      });
      List<Preset> presetList34 = presets;
      Sprite sprite135 = sprite134;
      List<Rectangle> hitbox43 = new List<Rectangle>();
      hitbox43.Add(new Rectangle(5, 132, 112, 30));
      Vector2 epicenterOffset43 = new Vector2(63f, 150f);
      IDodoInteraction[] interactions43 = new IDodoInteraction[4];
      Vector2? extraReach43 = new Vector2?(new Vector2(0.0f, 0.0f));
      Preset preset35 = new Preset("Longbush", "longbush", Preset.WOType.Static, sprite135, hitbox43, epicenterOffset43, interactions43, "Plants", extraReach43);
      presetList34.Add(preset35);
      Sprite sprite136 = new Sprite("double_leaf", ContentLoadingWrapper.Load<Texture2D>("double_leaf"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("double_leaf_shadow"), new Vector2(5f, 170f), opacity: 0.4f)
      });
      List<Preset> presetList35 = presets;
      Sprite sprite137 = sprite136;
      List<Rectangle> hitbox44 = new List<Rectangle>();
      hitbox44.Add(new Rectangle(2, 164, 83, 20));
      Vector2 epicenterOffset44 = new Vector2(76f, 182f);
      IDodoInteraction[] interactions44 = new IDodoInteraction[4];
      Vector2? extraReach44 = new Vector2?(new Vector2(0.0f, 0.0f));
      Preset preset36 = new Preset("double_leaf", "double_leaf", Preset.WOType.Static, sprite137, hitbox44, epicenterOffset44, interactions44, "Plants", extraReach44);
      presetList35.Add(preset36);
      Sprite sprite138 = new Sprite("moonplant", ContentLoadingWrapper.Load<Texture2D>("moonplant"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("moonplant_shadow"), new Vector2(16f, 132f), opacity: 0.4f)
      });
      Sprite sprite139 = new Sprite("moonplant_cut", ContentLoadingWrapper.Load<Texture2D>("moonplant_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("moonplant_shadow"), new Vector2(16f, 132f), opacity: 0.3f)
      });
      presets.Add(new Preset("moonplant", "moonplant", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite138,
        sprite139
      }, new List<Rectangle>()
      {
        new Rectangle(12, 138, 80, 24)
      }, new Vector2(60f, 150f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(14, 1)
        })
      }, "Plants", new Vector2?(new Vector2(40f, 10f)), 10));
      Sprite sprite140 = new Sprite("earthplant", ContentLoadingWrapper.Load<Texture2D>("earthplant"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("earthplant_shadow"), new Vector2(9f, 99f), opacity: 0.4f)
      });
      Sprite sprite141 = new Sprite("earthplant_cut", ContentLoadingWrapper.Load<Texture2D>("earthplant_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("earthplant_shadow"), new Vector2(9f, 99f), opacity: 0.3f)
      });
      presets.Add(new Preset("earthplant", "earthplant", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite140,
        sprite141
      }, new List<Rectangle>()
      {
        new Rectangle(10, 95, 80, 15)
      }, new Vector2(53f, 109f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(15, 1)
        })
      }, "Plants", new Vector2?(new Vector2(40f, 10f)), 10));
      Sprite sprite142 = new Sprite("cascade", ContentLoadingWrapper.Load<Texture2D>("cascade"));
      sprite142.Width = 219;
      sprite142.animated = true;
      sprite142.MillisecondsPerFrame = 70;
      List<Preset> presetList36 = presets;
      Sprite sprite143 = sprite142;
      List<Rectangle> hitbox45 = new List<Rectangle>();
      hitbox45.Add(new Rectangle(1, 77, 218, 90));
      Vector2 epicenterOffset45 = new Vector2(109f, 112f);
      IDodoInteraction[] interactions45 = new IDodoInteraction[4];
      Vector2? extraReach45 = new Vector2?(new Vector2(40f, 10f));
      Preset preset37 = new Preset("Cascade", "Cascade", Preset.WOType.Static, sprite143, hitbox45, epicenterOffset45, interactions45, "Other", extraReach45);
      presetList36.Add(preset37);
      presets.Add(new Preset("cgrass", "cgrass", Preset.WOType.Static, new Sprite("cgrass", ContentLoadingWrapper.Load<Texture2D>("cgrass")), (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Plants"));
      Sprite sprite144 = new Sprite("grass1N", ContentLoadingWrapper.Load<Texture2D>("grass1N"));
      presets.Add(new Preset("Herbe", "Grass1N", Preset.WOType.Static, sprite144, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      Sprite sprite145 = new Sprite("spikevolcan", ContentLoadingWrapper.Load<Texture2D>("spikevolcan"));
      presets.Add(new Preset("Volcano spike", "Volcano spike", Preset.WOType.Static, sprite145, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      Sprite sprite146 = new Sprite("greententacle1", ContentLoadingWrapper.Load<Texture2D>("greententacle1"));
      presets.Add(new Preset("Tentacule", "greententacle1", Preset.WOType.Static, sprite146, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      Sprite sprite147 = new Sprite("greententacle2", ContentLoadingWrapper.Load<Texture2D>("greententacle2"));
      presets.Add(new Preset("Tentacule", "greententacle2", Preset.WOType.Static, sprite147, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      Sprite sprite148 = new Sprite("greententacle3", ContentLoadingWrapper.Load<Texture2D>("greententacle3"));
      presets.Add(new Preset("Tentacule", "greententacle3", Preset.WOType.Static, sprite148, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      Sprite sprite149 = new Sprite("greententacle4", ContentLoadingWrapper.Load<Texture2D>("greententacle4"));
      presets.Add(new Preset("Tentacule", "greententacle4", Preset.WOType.Static, sprite149, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      Sprite sprite150 = new Sprite("greententacle5", ContentLoadingWrapper.Load<Texture2D>("greententacle5"));
      presets.Add(new Preset("Tentacule", "greententacle5", Preset.WOType.Static, sprite150, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      Sprite sprite151 = new Sprite("greententacle6", ContentLoadingWrapper.Load<Texture2D>("greententacle6"));
      presets.Add(new Preset("Tentacule", "greententacle6", Preset.WOType.Static, sprite151, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      Sprite sprite152 = new Sprite("greententacle7", ContentLoadingWrapper.Load<Texture2D>("greententacle7"));
      presets.Add(new Preset("Tentacule", "greententacle7", Preset.WOType.Static, sprite152, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("Tentacule", "mirrorgreententacle1", Preset.WOType.Static, new Sprite("mirrorgreententacle1", ContentLoadingWrapper.Load<Texture2D>("greententacle1"))
      {
        horizontalMirroring = true
      }, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("Tentacule", "mirrorgreententacle2", Preset.WOType.Static, new Sprite("mirrorgreententacle2", ContentLoadingWrapper.Load<Texture2D>("greententacle2"))
      {
        horizontalMirroring = true
      }, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("Tentacule", "mirrorgreententacle3", Preset.WOType.Static, new Sprite("mirrorgreententacle3", ContentLoadingWrapper.Load<Texture2D>("greententacle3"))
      {
        horizontalMirroring = true
      }, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("Tentacule", "mirrorgreententacle4", Preset.WOType.Static, new Sprite("mirrorgreententacle4", ContentLoadingWrapper.Load<Texture2D>("greententacle4"))
      {
        horizontalMirroring = true
      }, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("Tentacule", "mirrorgreententacle5", Preset.WOType.Static, new Sprite("mirrorgreententacle5", ContentLoadingWrapper.Load<Texture2D>("greententacle5"))
      {
        horizontalMirroring = true
      }, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("Tentacule", "mirrorgreententacle6", Preset.WOType.Static, new Sprite("mirrorgreententacle6", ContentLoadingWrapper.Load<Texture2D>("greententacle6"))
      {
        horizontalMirroring = true
      }, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("Tentacule", "mirrorgreententacle7", Preset.WOType.Static, new Sprite("mirrorgreententacle7", ContentLoadingWrapper.Load<Texture2D>("greententacle7"))
      {
        horizontalMirroring = true
      }, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      Sprite sprite153 = new Sprite("platebande1", ContentLoadingWrapper.Load<Texture2D>("platebande1"));
      presets.Add(new Preset("Platebande", "platebande1", Preset.WOType.Static, sprite153, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      Sprite sprite154 = new Sprite("platebande2", ContentLoadingWrapper.Load<Texture2D>("platebande2"));
      presets.Add(new Preset("Platebande", "platebande2", Preset.WOType.Static, sprite154, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("Platebande", "mirrorplatebande1", Preset.WOType.Static, new Sprite("mirrorplatebande1", ContentLoadingWrapper.Load<Texture2D>("platebande1"))
      {
        horizontalMirroring = true
      }, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("Platebande", "mirrorplatebande2", Preset.WOType.Static, new Sprite("mirrorplatebande2", ContentLoadingWrapper.Load<Texture2D>("platebande2"))
      {
        horizontalMirroring = true
      }, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("Patch", "patch1", Preset.WOType.Static, new Sprite("patch1", ContentLoadingWrapper.Load<Texture2D>("void"), new List<SubSprite>())
      {
        groundSubsprite = new List<SubSprite>()
        {
          new SubSprite(ContentLoadingWrapper.Load<Texture2D>("patch1"), new Vector2(0.0f, 0.0f))
          {
            disappearAtNight = false
          }
        }
      }, (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      Sprite sprite155 = new Sprite("treebush", ContentLoadingWrapper.Load<Texture2D>("treebush"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("treebushshadow"), new Vector2(5f, 72f), opacity: 0.4f)
      });
      presets.Add(new Preset("Buisson", "Treebush", Preset.WOType.Static, sprite155, (List<Rectangle>) null, new Vector2(48f, 68f), new IDodoInteraction[4], "Plants"));
      Sprite sprite156 = new Sprite("jungleplant1", ContentLoadingWrapper.Load<Texture2D>("jungleplant1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("jungleplant1_shadow"), new Vector2(6f, 50f), opacity: 0.4f)
      });
      Sprite sprite157 = new Sprite("jungleplant1_cutted", ContentLoadingWrapper.Load<Texture2D>("jungleplant1_cutted"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("jungleplant1_cutted_shadow"), new Vector2(31f, 64f), opacity: 0.4f)
      });
      presets.Add(new Preset("Jungle plant 1", "Jungle plant 1", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite156,
        sprite157
      }, new List<Rectangle>(), new Vector2(65f, 53f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(0, 3)
        })
      }, "Trees", new Vector2?(new Vector2(0.0f, 0.0f))));
      Sprite sprite158 = new Sprite("jungleplant1", ContentLoadingWrapper.Load<Texture2D>("jungleplant1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("jungleplant1_shadow"), new Vector2(6f, 50f), opacity: 0.4f)
      }, true);
      Sprite sprite159 = new Sprite("jungleplant1_cutted", ContentLoadingWrapper.Load<Texture2D>("jungleplant1_cutted"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("jungleplant1_cutted_shadow"), new Vector2(31f, 64f), opacity: 0.4f)
      }, true);
      presets.Add(new Preset("Jungle plant 1", "Jungle plant 1 Mirrored", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite158,
        sprite159
      }, new List<Rectangle>(), new Vector2(65f, 53f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(0, 3)
        })
      }, "Trees", new Vector2?(new Vector2(0.0f, 0.0f))));
      Sprite sprite160 = new Sprite("jungleplant2", ContentLoadingWrapper.Load<Texture2D>("jungleplant2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("jungleplant2_shadow"), new Vector2(25f, 60f), opacity: 0.4f)
      });
      Sprite sprite161 = new Sprite("jungleplant2_cutted", ContentLoadingWrapper.Load<Texture2D>("jungleplant2_cutted"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("jungleplant2_cutted_shadow"), new Vector2(47f, 68f), opacity: 0.4f)
      });
      presets.Add(new Preset("Jungle plant 2", "Jungle plant 2", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite160,
        sprite161
      }, new List<Rectangle>(), new Vector2(63f, 75f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(0, 3)
        })
      }, "Trees", new Vector2?(new Vector2(0.0f, 0.0f))));
      Sprite sprite162 = new Sprite("jungleplant5", ContentLoadingWrapper.Load<Texture2D>("jungleplant5"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("jungleplant5_shadow"), new Vector2(3f, 130f), opacity: 0.4f)
      });
      Sprite sprite163 = new Sprite("jungleplant5_cut", ContentLoadingWrapper.Load<Texture2D>("jungleplant5_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("jungleplant5_shadow"), new Vector2(3f, 130f), opacity: 0.4f)
      });
      presets.Add(new Preset("Jungle plant 5", "Jungle plant 5", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite162,
        sprite163
      }, new List<Rectangle>()
      {
        new Rectangle(5, 125, 75, 25)
      }, new Vector2(54f, 138f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(0, 3)
        })
      }, "Trees", new Vector2?(new Vector2(0.0f, 0.0f))));
      Sprite sprite164 = new Sprite("jungleplant4", ContentLoadingWrapper.Load<Texture2D>("jungleplant4"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("jungleplant4_shadow"), new Vector2(20f, 63f), opacity: 0.4f)
      });
      List<Preset> presetList37 = presets;
      Sprite sprite165 = sprite164;
      List<Rectangle> hitbox46 = new List<Rectangle>();
      hitbox46.Add(new Rectangle(15, 53, 40, 20));
      Vector2 epicenterOffset46 = new Vector2(38f, 52f);
      IDodoInteraction[] interactions46 = new IDodoInteraction[4];
      Vector2? extraReach46 = new Vector2?(new Vector2(0.0f, 0.0f));
      Preset preset38 = new Preset("Fleur", "Fleur", Preset.WOType.Static, sprite165, hitbox46, epicenterOffset46, interactions46, "Plants", extraReach46);
      presetList37.Add(preset38);
      Sprite sprite166 = new Sprite("cocotier1_wvine", ContentLoadingWrapper.Load<Texture2D>("cocotier1_wvine"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier1_wvine_shadow"), new Vector2(0.0f, 225f), opacity: 0.4f)
      });
      Preset preset39 = new Preset("Cocotier", "Cocotier avec liane", Preset.WOType.LinkingGrowable, new List<Sprite>()
      {
        new Sprite("cocotier1_wvine_unlinked", ContentLoadingWrapper.Load<Texture2D>("cocotier1_wvine_unlinked"), new List<SubSprite>()
        {
          new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier1/shadow"), new Vector2(65f, 225f), opacity: 0.4f)
        }),
        new Sprite("cocotier1_wvine_growing", ContentLoadingWrapper.Load<Texture2D>("cocotier1_wvine_growing"), new List<SubSprite>()
        {
          new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier1_wvine_cutted_shadow"), new Vector2(160f, 235f), opacity: 0.4f)
        }),
        new Sprite("cocotier1_wvine_cutted", ContentLoadingWrapper.Load<Texture2D>("cocotier1_wvine_cutted"), new List<SubSprite>()
        {
          new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier1_wvine_cutted_shadow"), new Vector2(160f, 235f), opacity: 0.4f)
        })
      }, new List<Rectangle>()
      {
        new Rectangle(170, 230, 35, 28)
      }, new Vector2(202f, 244f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[2]
        {
          new ItemStack(1, 3),
          new ItemStack(0, 1)
        })
      }, "Trees", new Vector2?(new Vector2(35f, 0.0f)), 2)
      {
        linkingSprite = sprite166,
        linkOffset = new Vector2(-207f, 0.0f),
        linkToPreset = "Cocotier avec liane Mirrored"
      };
      presets.Add(preset39);
      Sprite sprite167 = new Sprite("cocotier1_wvine", ContentLoadingWrapper.Load<Texture2D>("cocotier1_wvine"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier1_wvine_shadow"), new Vector2(0.0f, 225f), opacity: 0.4f, mirror: true)
      }, true);
      Sprite sprite168 = new Sprite("cocotier1_wvine_growing", ContentLoadingWrapper.Load<Texture2D>("cocotier1_wvine_growing"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier1_wvine_cutted_shadow"), new Vector2(-6f, 235f), opacity: 0.4f, mirror: true)
      }, true);
      Sprite sprite169 = new Sprite("cocotier1_wvine_cutted", ContentLoadingWrapper.Load<Texture2D>("cocotier1_wvine_cutted"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier1_wvine_cutted_shadow"), new Vector2(-6f, 235f), opacity: 0.4f, mirror: true)
      }, true);
      Preset preset40 = new Preset("Cocotier", "Cocotier avec liane Mirrored", Preset.WOType.LinkingGrowable, new List<Sprite>()
      {
        new Sprite("cocotier1_wvine_unlinked", ContentLoadingWrapper.Load<Texture2D>("cocotier1_wvine_unlinked"), new List<SubSprite>()
        {
          new SubSprite(ContentLoadingWrapper.Load<Texture2D>("cocotier1/shadow"), new Vector2(-6f, 225f), opacity: 0.4f, mirror: true)
        }, true),
        sprite168,
        sprite169
      }, new List<Rectangle>()
      {
        new Rectangle(3, 230, 35, 28)
      }, new Vector2(17f, 244f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[2]
        {
          new ItemStack(1, 3),
          new ItemStack(0, 1)
        })
      }, "Trees", new Vector2?(new Vector2(35f, 0.0f)), 2)
      {
        linkingSprite = sprite167,
        linkOffset = new Vector2(207f, 0.0f),
        linkToPreset = "Cocotier avec liane"
      };
      presets.Add(preset40);
      presets.Add(new Preset("groundvine", "groundvine1", Preset.WOType.Static, new Sprite("groundvine1", ContentLoadingWrapper.Load<Texture2D>("groundvine1")), (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("groundvine", "groundvine2", Preset.WOType.Static, new Sprite("groundvine2", ContentLoadingWrapper.Load<Texture2D>("groundvine2")), (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("groundvine", "groundvine3", Preset.WOType.Static, new Sprite("groundvine3", ContentLoadingWrapper.Load<Texture2D>("groundvine3")), (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("groundvine", "groundvine4", Preset.WOType.Static, new Sprite("groundvine4", ContentLoadingWrapper.Load<Texture2D>("groundvine4")), (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("groundvine", "groundvine5", Preset.WOType.Static, new Sprite("groundvine5", ContentLoadingWrapper.Load<Texture2D>("groundvine5")), (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("groundvine", "groundvine6", Preset.WOType.Static, new Sprite("groundvine6", ContentLoadingWrapper.Load<Texture2D>("groundvine6")), (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      Sprite sprite170 = new Sprite("tree2", ContentLoadingWrapper.Load<Texture2D>("tree2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("tree2_shadow"), new Vector2(-2f, (float) sbyte.MaxValue), opacity: 0.4f)
      });
      Sprite sprite171 = new Sprite("tree2_cut", ContentLoadingWrapper.Load<Texture2D>("tree2_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("tree2_cut_shadow"), new Vector2(-2f, (float) sbyte.MaxValue), opacity: 0.4f)
      });
      presets.Add(new Preset("Arbre", "Tree2", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite170,
        sprite171
      }, new List<Rectangle>()
      {
        new Rectangle(10, 122, 40, 23)
      }, new Vector2(33f, 138f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[2]
        {
          new ItemStack(1, 2),
          new ItemStack(0, 1)
        })
      }, "Trees", new Vector2?(new Vector2(0.0f, 0.0f)), 3));
      Sprite sprite172 = new Sprite("tree1", ContentLoadingWrapper.Load<Texture2D>("tree1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("tree1_shadow"), new Vector2(13f, 180f), opacity: 0.4f)
      });
      Sprite sprite173 = new Sprite("tree1_cut", ContentLoadingWrapper.Load<Texture2D>("tree1_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("tree1_cut_shadow"), new Vector2(97f, 190f), opacity: 0.4f)
      });
      presets.Add(new Preset("Arbre", "Tree1", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite172,
        sprite173
      }, new List<Rectangle>()
      {
        new Rectangle(105, 186, 40, 20)
      }, new Vector2(130f, 200f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(1, 3)
        })
      }, "Trees", new Vector2?(new Vector2(0.0f, 0.0f)), 3));
      Sprite sprite174 = new Sprite("jungleplant3", ContentLoadingWrapper.Load<Texture2D>("jungleplant3"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("jungleplant3_shadow"), new Vector2(9f, 49f), opacity: 0.4f)
      });
      List<Preset> presetList38 = presets;
      Sprite sprite175 = sprite174;
      List<Rectangle> hitbox47 = new List<Rectangle>();
      hitbox47.Add(new Rectangle(10, 48, 67, 11));
      Vector2 epicenterOffset47 = new Vector2(48f, 58f);
      IDodoInteraction[] interactions47 = new IDodoInteraction[4];
      Vector2? extraReach47 = new Vector2?(new Vector2(0.0f, 0.0f));
      Preset preset41 = new Preset("Buisson", "savana bush", Preset.WOType.Static, sprite175, hitbox47, epicenterOffset47, interactions47, "Plants", extraReach47);
      presetList38.Add(preset41);
      Sprite sprite176 = new Sprite("roc_wmousse", ContentLoadingWrapper.Load<Texture2D>("roc_wmousse"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("roc_shadow"), new Vector2(-4f, 106f), opacity: 0.65f)
      });
      presets.Add(new Preset("Rocher moussu", "Roc avec mousse", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite176,
        sprite64
      }, new List<Rectangle>()
      {
        new Rectangle(-10, 90, 125, 40)
      }, new Vector2(62f, 107f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(3, 1)
        })
      }, "Rocks", new Vector2?(new Vector2(35f, 0.0f)), 6));
      presets.Add(new Preset("Herbe", "tuft1", Preset.WOType.Static, new Sprite("tuft1", ContentLoadingWrapper.Load<Texture2D>("tuft/tuft1")), (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("Herbe", "tuft2", Preset.WOType.Static, new Sprite("tuft2", ContentLoadingWrapper.Load<Texture2D>("tuft/tuft2")), (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("Herbe", "tuft3", Preset.WOType.Static, new Sprite("tuft3", ContentLoadingWrapper.Load<Texture2D>("tuft/tuft3")), (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("Herbe", "tuft4", Preset.WOType.Static, new Sprite("tuft4", ContentLoadingWrapper.Load<Texture2D>("tuft/tuft4")), (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      presets.Add(new Preset("Herbe", "tuft5", Preset.WOType.Static, new Sprite("tuft5", ContentLoadingWrapper.Load<Texture2D>("tuft/tuft5")), (List<Rectangle>) null, new Vector2(0.0f, 0.0f), new IDodoInteraction[4], "Decor"));
      Sprite sprite177 = new Sprite("eggplant1", ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant1_shadow"), new Vector2(0.0f, 130f), opacity: 0.4f)
      });
      Sprite sprite178 = new Sprite("eggplant2", ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant2_shadow"), new Vector2(0.0f, 130f), opacity: 0.4f)
      });
      Sprite sprite179 = new Sprite("eggplant3", ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant3"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant3_shadow"), new Vector2(0.0f, 130f), opacity: 0.4f)
      });
      Sprite sprite180 = new Sprite("eggplant4", ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant4"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant4_shadow"), new Vector2(0.0f, 130f), opacity: 0.4f)
      });
      Sprite sprite181 = new Sprite("eggplant5", ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant5"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant5_shadow"), new Vector2(0.0f, 130f), opacity: 0.4f)
      });
      Sprite sprite182 = new Sprite("eggplant6", ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant6"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant6_shadow"), new Vector2(0.0f, 130f), opacity: 0.4f)
      });
      Sprite sprite183 = new Sprite("eggplant7", ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant7"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant7_shadow"), new Vector2(0.0f, 130f), opacity: 0.4f)
      });
      Sprite sprite184 = new Sprite("eggplant8", ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant8"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant8_shadow"), new Vector2(0.0f, 130f), opacity: 0.4f)
      });
      Sprite sprite185 = new Sprite("eggplant9", ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant9"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant9_shadow"), new Vector2(0.0f, 130f), opacity: 0.4f)
      });
      Sprite sprite186 = new Sprite("eggplant10", ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant10"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant10_shadow"), new Vector2(0.0f, 130f), opacity: 0.4f)
      });
      Sprite sprite187 = new Sprite("eggplant11", ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant11"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant11_shadow"), new Vector2(0.0f, 130f), opacity: 0.4f)
      });
      Sprite sprite188 = new Sprite("eggplant12", ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant12"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("eggplant/eggplant12_shadow"), new Vector2(0.0f, 130f), opacity: 0.4f)
      });
      presets.Add(new Preset("Aubergine", "Eggplant", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite188,
        sprite187,
        sprite186,
        sprite185,
        sprite184,
        sprite183,
        sprite182,
        sprite181,
        sprite180,
        sprite179,
        sprite178,
        sprite177
      }, new List<Rectangle>()
      {
        new Rectangle(30, 120, 100, 30)
      }, new Vector2(87f, 141f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(4, 1)
        })
      }, "Plants", new Vector2?(new Vector2(0.0f, 0.0f)), 0, 11));
      Sprite sprite189 = new Sprite("corail", ContentLoadingWrapper.Load<Texture2D>("coral76"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("coral_shadow"), new Vector2(4f, 36f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 76,
        MillisecondsPerFrame = 120,
        autoUpdate = true
      };
      Sprite sprite190 = new Sprite("void", ContentLoadingWrapper.Load<Texture2D>("void"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("coral_shadow"), new Vector2(4f, 36f), opacity: 0.3f)
      });
      Sprite sprite191 = new Sprite("corail_cut", ContentLoadingWrapper.Load<Texture2D>("coral_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("coral_shadow"), new Vector2(4f, 36f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 76,
        MillisecondsPerFrame = 120,
        autoUpdate = true
      };
      presets.Add(new Preset("Corail", "Corail", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite189,
        sprite191
      }, new List<Rectangle>()
      {
        new Rectangle(5, 30, 62, 30)
      }, new Vector2(35f, 47f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(5, 1)
        })
      }, "Other", new Vector2?(new Vector2(30f, 20f)), 2));
      Sprite sprite192 = new Sprite("bottle", ContentLoadingWrapper.Load<Texture2D>("bottle"), new List<SubSprite>())
      {
        animated = true,
        Width = 39,
        MillisecondsPerFrame = 220,
        autoUpdate = true
      };
      Sprite sprite193 = new Sprite("bottle", ContentLoadingWrapper.Load<Texture2D>("bottle_empty"), new List<SubSprite>())
      {
        animated = false
      };
      presets.Add(new Preset("Plastic bottle", "plastic bottle", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite192,
        sprite193
      }, new List<Rectangle>()
      {
        new Rectangle(5, 15, 25, 10)
      }, new Vector2(15f, 20f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(13, 1)
        })
      }, "Other", new Vector2?(new Vector2(30f, 20f)), 50, 1));
      Sprite sprite194 = new Sprite("trash", ContentLoadingWrapper.Load<Texture2D>("trash"), new List<SubSprite>())
      {
        animated = true,
        Width = 54,
        MillisecondsPerFrame = 220,
        autoUpdate = true
      };
      presets.Add(new Preset("Trash", "Trash", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite194,
        sprite193
      }, new List<Rectangle>()
      {
        new Rectangle(5, 35, 40, 15)
      }, new Vector2(15f, 20f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(13, 1)
        })
      }, "Other", new Vector2?(new Vector2(30f, 20f)), 50, 1));
      Sprite sprite195 = new Sprite("plasticbag", ContentLoadingWrapper.Load<Texture2D>("plasticbag"), new List<SubSprite>())
      {
        animated = true,
        Width = 71,
        MillisecondsPerFrame = 220,
        autoUpdate = true
      };
      presets.Add(new Preset("Plastic bag", "Plastic bag", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite195,
        sprite193
      }, new List<Rectangle>()
      {
        new Rectangle(5, 15, 60, 10)
      }, new Vector2(15f, 20f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(13, 1)
        })
      }, "Other", new Vector2?(new Vector2(30f, 20f)), 50, 1));
      Sprite sprite196 = new Sprite("egg1", ContentLoadingWrapper.Load<Texture2D>("egg1"), new List<SubSprite>());
      Sprite sprite197 = new Sprite("egg2", ContentLoadingWrapper.Load<Texture2D>("egg2"), new List<SubSprite>());
      Sprite sprite198 = new Sprite("egg3", ContentLoadingWrapper.Load<Texture2D>("egg3"), new List<SubSprite>());
      Sprite sprite199 = new Sprite("egg4", ContentLoadingWrapper.Load<Texture2D>("egg4"), new List<SubSprite>());
      Sprite sprite200 = new Sprite("egg5", ContentLoadingWrapper.Load<Texture2D>("egg5"), new List<SubSprite>());
      Sprite sprite201 = new Sprite("egg1", ContentLoadingWrapper.Load<Texture2D>("egg6"), new List<SubSprite>());
      presets.Add(new Preset("egg1", "egg1", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite196,
        sprite193
      }, new List<List<Rectangle>>()
      {
        new List<Rectangle>() { new Rectangle(0, 0, 0, 0) },
        new List<Rectangle>() { new Rectangle(12, 22, 20, 10) }
      }, new Vector2(23f, 24f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(16, 1)
        })
      }, "Other", new Vector2?(new Vector2(0.0f, 0.0f)), regrowOverTime: false));
      presets.Add(new Preset("egg2", "egg2", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite197,
        sprite193
      }, new List<Rectangle>()
      {
        new Rectangle(12, 22, 20, 10)
      }, new Vector2(23f, 24f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(16, 1)
        })
      }, "Other", new Vector2?(new Vector2(0.0f, 0.0f)), regrowOverTime: false));
      presets.Add(new Preset("egg3", "egg3", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite198,
        sprite193
      }, new List<Rectangle>()
      {
        new Rectangle(12, 22, 20, 10)
      }, new Vector2(23f, 24f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(16, 1)
        })
      }, "Other", new Vector2?(new Vector2(0.0f, 0.0f)), 0, regrowOverTime: false));
      presets.Add(new Preset("egg4", "egg4", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite199,
        sprite193
      }, new List<Rectangle>()
      {
        new Rectangle(12, 22, 20, 10)
      }, new Vector2(23f, 24f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(16, 1)
        })
      }, "Other", new Vector2?(new Vector2(0.0f, 0.0f)), 0, regrowOverTime: false));
      presets.Add(new Preset("egg5", "egg5", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite200,
        sprite193
      }, new List<Rectangle>()
      {
        new Rectangle(12, 22, 20, 10)
      }, new Vector2(23f, 24f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(16, 1)
        })
      }, "Other", new Vector2?(new Vector2(0.0f, 0.0f)), 0, regrowOverTime: false));
      presets.Add(new Preset("egg6", "egg6", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite201,
        sprite193
      }, new List<Rectangle>()
      {
        new Rectangle(12, 22, 20, 10)
      }, new Vector2(23f, 24f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(16, 1)
        })
      }, "Other", new Vector2?(new Vector2(0.0f, 0.0f)), 0, regrowOverTime: false));
      Sprite sprite202 = new Sprite("aquaroc", ContentLoadingWrapper.Load<Texture2D>("aquaroc"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("roc_shadow"), new Vector2(-5f, 115f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 114,
        MillisecondsPerFrame = 80,
        autoUpdate = true
      };
      Sprite sprite203 = new Sprite("aquaroc_cut", ContentLoadingWrapper.Load<Texture2D>("aquaroc_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("roc_shadow"), new Vector2(-5f, 115f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 114,
        MillisecondsPerFrame = 80,
        autoUpdate = true
      };
      presets.Add(new Preset("Rocher", "Aquaroc", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite202,
        sprite203
      }, new List<Rectangle>()
      {
        new Rectangle(0, 106, 113, 27)
      }, new Vector2(57f, 123f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(3, 1)
        })
      }, "Rocks", new Vector2?(new Vector2(30f, 20f)), 3));
      Sprite sprite204 = new Sprite("aquapillar", ContentLoadingWrapper.Load<Texture2D>("aquapillar"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("aquapillar_shadow"), new Vector2(5f, (float) byte.MaxValue), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 102,
        MillisecondsPerFrame = 80
      };
      Sprite sprite205 = new Sprite("aquapillar_cut", ContentLoadingWrapper.Load<Texture2D>("aquapillar_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("aquapillar_shadow"), new Vector2(5f, (float) byte.MaxValue), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 102,
        MillisecondsPerFrame = 80
      };
      presets.Add(new Preset("Pillier", "Aquapillar", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite204,
        sprite205
      }, new List<Rectangle>()
      {
        new Rectangle(3, 238, 90, 40)
      }, new Vector2(59f, 276f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[2]
        {
          new ItemStack(3, 1),
          new ItemStack(7, 4)
        })
      }, "Rocks", new Vector2?(new Vector2(30f, 20f)), 3));
      Sprite sprite206 = new Sprite("gros corail", ContentLoadingWrapper.Load<Texture2D>("bigcoral"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bigcoral_shadow"), new Vector2(0.0f, 0.0f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 227,
        MillisecondsPerFrame = 80
      };
      Sprite sprite207 = new Sprite("gros corail cut", ContentLoadingWrapper.Load<Texture2D>("bigcoral_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("bigcoral_shadow"), new Vector2(0.0f, 0.0f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 227,
        MillisecondsPerFrame = 80
      };
      presets.Add(new Preset("Corail", "gros corail", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite206,
        sprite207
      }, new List<Rectangle>()
      {
        new Rectangle(0, 120, 216, 40)
      }, new Vector2(88f, 143f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(5, 3)
        })
      }, "Other", new Vector2?(new Vector2(30f, 20f)), 5));
      Sprite sprite208 = new Sprite("seashell1", ContentLoadingWrapper.Load<Texture2D>("seashell1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("seashell1_shadow"), new Vector2(0.0f, 5f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 102,
        MillisecondsPerFrame = 80
      };
      Sprite sprite209 = new Sprite("seashell1 cut", ContentLoadingWrapper.Load<Texture2D>("seashell1_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("seashell1_shadow"), new Vector2(0.0f, 5f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 102,
        MillisecondsPerFrame = 80
      };
      presets.Add(new Preset("Coquillage", "seashell1", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite208,
        sprite209
      }, new List<Rectangle>()
      {
        new Rectangle(16, 92, 68, 27)
      }, new Vector2(50f, 111f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(11, 2)
        })
      }, "Other", new Vector2?(new Vector2(30f, 20f)), 3));
      Sprite sprite210 = new Sprite("seashell2", ContentLoadingWrapper.Load<Texture2D>("seashell2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("seashell2_shadow"), new Vector2(0.0f, 5f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 97,
        MillisecondsPerFrame = 80
      };
      Sprite sprite211 = new Sprite("seashell2 cut", ContentLoadingWrapper.Load<Texture2D>("seashell2_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("seashell2_shadow"), new Vector2(0.0f, 5f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 97,
        MillisecondsPerFrame = 80
      };
      presets.Add(new Preset("Coquillage", "seashell2", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite210,
        sprite211
      }, new List<Rectangle>()
      {
        new Rectangle(16, 103, 68, 10)
      }, new Vector2(50f, 111f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(11, 2)
        })
      }, "Other", new Vector2?(new Vector2(30f, 20f)), 3));
      Sprite sprite212 = new Sprite("coconutbush1", ContentLoadingWrapper.Load<Texture2D>("DCbush1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("DCbush_shadow"), new Vector2(2f, 35f), opacity: 0.4f)
      });
      Sprite sprite213 = new Sprite("coconutbush2", ContentLoadingWrapper.Load<Texture2D>("DCbush2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("DCbush_shadow"), new Vector2(2f, 35f), opacity: 0.4f)
      });
      Sprite sprite214 = new Sprite("coconutbush3", ContentLoadingWrapper.Load<Texture2D>("DCbush3"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("DCbush_shadow"), new Vector2(2f, 35f), opacity: 0.4f)
      });
      Sprite sprite215 = new Sprite("coconutbush4", ContentLoadingWrapper.Load<Texture2D>("DCbush4"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("DCbush_shadow"), new Vector2(2f, 35f), opacity: 0.4f)
      });
      presets.Add(new Preset("Buisson coco", "Double coconut bush", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite215,
        sprite214,
        sprite213,
        sprite212
      }, new List<Rectangle>()
      {
        new Rectangle(25, 40, 45, 30)
      }, new Vector2(48f, 48f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(6, 1)
        })
      }, "Plants", new Vector2?(new Vector2(0.0f, 0.0f)), growstate: 2));
      Sprite sprite216 = new Sprite("volcan", ContentLoadingWrapper.Load<Texture2D>("volcan2_675"))
      {
        animated = true,
        Width = 675,
        MillisecondsPerFrame = 120
      };
      List<Preset> presetList39 = presets;
      Sprite sprite217 = sprite216;
      List<Rectangle> hitbox48 = new List<Rectangle>();
      hitbox48.Add(new Rectangle(0, 713, 668, 95));
      Vector2 epicenterOffset48 = new Vector2(0.0f, 0.0f);
      IDodoInteraction[] interactions48 = new IDodoInteraction[4];
      Vector2? extraReach48 = new Vector2?();
      Preset preset42 = new Preset("Volcan", "volcan", Preset.WOType.Static, sprite217, hitbox48, epicenterOffset48, interactions48, "Other", extraReach48, extraFloorHeight: -100);
      presetList39.Add(preset42);
      Sprite sprite218 = new Sprite("fleur1", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur1"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur1_shadow"), new Vector2(1f, 209f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 145,
        MillisecondsPerFrame = 90
      };
      Sprite sprite219 = new Sprite("fleur1_cut", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur1_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur1_shadow"), new Vector2(1f, 209f), opacity: 0.4f)
      });
      presets.Add(new Preset("Fleur", "fleur geante 1", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite218,
        sprite219
      }, new List<Rectangle>()
      {
        new Rectangle(0, 210, 80, 20)
      }, new Vector2(12f, 225f), new IDodoInteraction[4]
      {
        (IDodoInteraction) new TakeNotes(new ItemStack[1]
        {
          new ItemStack(81, 1)
        }),
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(8, 1)
        })
      }, "Plants", new Vector2?(new Vector2(30f, 20f)), 0, 1));
      Sprite sprite220 = new Sprite("fleur2", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur2"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur2_shadow"), new Vector2(-20f, 194f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 88,
        MillisecondsPerFrame = 90
      };
      Sprite sprite221 = new Sprite("fleur2_cut", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur2_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur2_shadow"), new Vector2(-20f, 194f), opacity: 0.4f)
      });
      presets.Add(new Preset("Fleur", "fleur geante 2", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite220,
        sprite221
      }, new List<Rectangle>()
      {
        new Rectangle(0, 200, 66, 20)
      }, new Vector2(82f, 184f), new IDodoInteraction[4]
      {
        (IDodoInteraction) new TakeNotes(new ItemStack[1]
        {
          new ItemStack(82, 1)
        }),
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(8, 1)
        })
      }, "Plants", new Vector2?(new Vector2(30f, 20f)), 0, 1));
      Sprite sprite222 = new Sprite("fleur3", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur3"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur3_shadow"), new Vector2(-2f, 193f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 109,
        MillisecondsPerFrame = 90
      };
      Sprite sprite223 = new Sprite("fleur3_cut", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur3_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur3_shadow"), new Vector2(-2f, 193f), opacity: 0.4f)
      });
      presets.Add(new Preset("Fleur", "fleur geante 3", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite222,
        sprite223
      }, new List<Rectangle>()
      {
        new Rectangle(2, 206, 63, 20)
      }, new Vector2(28f, 190f), new IDodoInteraction[4]
      {
        (IDodoInteraction) new TakeNotes(new ItemStack[1]
        {
          new ItemStack(83, 1)
        }),
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(8, 1)
        })
      }, "Plants", new Vector2?(new Vector2(30f, 20f)), 0, 1));
      Sprite sprite224 = new Sprite("fleur4", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur4"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur4_shadow"), new Vector2(-4f, 224f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 108,
        height = 249,
        MillisecondsPerFrame = 90
      };
      Sprite sprite225 = new Sprite("fleur4_cut", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur4_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur4_shadow"), new Vector2(-4f, 224f), opacity: 0.4f)
      });
      presets.Add(new Preset("Fleur", "fleur geante 4", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite224,
        sprite225
      }, new List<Rectangle>()
      {
        new Rectangle(23, 235, 65, 20)
      }, new Vector2(45f, 216f), new IDodoInteraction[4]
      {
        (IDodoInteraction) new TakeNotes(new ItemStack[1]
        {
          new ItemStack(84, 1)
        }),
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(8, 1)
        })
      }, "Plants", new Vector2?(new Vector2(30f, 20f)), 0, 1));
      Sprite sprite226 = new Sprite("fleur5", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur5"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur5_shadow"), new Vector2(0.0f, 178f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 102,
        MillisecondsPerFrame = 90
      };
      Sprite sprite227 = new Sprite("fleur5_cut", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur5_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur5_shadow"), new Vector2(0.0f, 178f), opacity: 0.4f)
      });
      presets.Add(new Preset("Fleur", "fleur geante 5", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite226,
        sprite227
      }, new List<Rectangle>()
      {
        new Rectangle(0, 187, 64, 20)
      }, new Vector2(27f, 167f), new IDodoInteraction[4]
      {
        (IDodoInteraction) new TakeNotes(new ItemStack[1]
        {
          new ItemStack(85, 1)
        }),
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(8, 1)
        })
      }, "Plants", new Vector2?(new Vector2(30f, 20f)), 0, 1));
      Sprite sprite228 = new Sprite("fleur6", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur6"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur6_shadow"), new Vector2(-4f, 254f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 114,
        MillisecondsPerFrame = 90
      };
      Sprite sprite229 = new Sprite("fleur6_cut", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur6_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur6_shadow"), new Vector2(-4f, 254f), opacity: 0.4f)
      });
      presets.Add(new Preset("Fleur", "fleur geante 6", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite228,
        sprite229
      }, new List<Rectangle>()
      {
        new Rectangle(5, 261, 36, 20)
      }, new Vector2(18f, 242f), new IDodoInteraction[4]
      {
        (IDodoInteraction) new TakeNotes(new ItemStack[1]
        {
          new ItemStack(86, 1)
        }),
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(8, 1)
        })
      }, "Plants", new Vector2?(new Vector2(30f, 20f)), 0, 1));
      Sprite sprite230 = new Sprite("fleur7", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur7"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur7_shadow"), new Vector2(-5f, 214f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 145,
        MillisecondsPerFrame = 90
      };
      Sprite sprite231 = new Sprite("fleur7_cut", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur7_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur7_shadow"), new Vector2(-5f, 214f), opacity: 0.4f)
      });
      presets.Add(new Preset("Fleur", "fleur geante 7", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite230,
        sprite231
      }, new List<Rectangle>()
      {
        new Rectangle(0, 230, 64, 20)
      }, new Vector2(14f, 206f), new IDodoInteraction[4]
      {
        (IDodoInteraction) new TakeNotes(new ItemStack[1]
        {
          new ItemStack(87, 1)
        }),
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(8, 1)
        })
      }, "Plants", new Vector2?(new Vector2(30f, 20f)), 0, 1));
      Sprite sprite232 = new Sprite("fleur8", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur8"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur8_shadow"), new Vector2(46f, 200f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 228,
        height = 251,
        MillisecondsPerFrame = 90
      };
      Sprite sprite233 = new Sprite("fleur8_cut", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur8_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur8_shadow"), new Vector2(46f, 200f), opacity: 0.4f)
      });
      presets.Add(new Preset("Fleur", "fleur geante 8", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite232,
        sprite233
      }, new List<Rectangle>()
      {
        new Rectangle(80, 210, 83, 50)
      }, new Vector2(117f, 230f), new IDodoInteraction[4]
      {
        (IDodoInteraction) new TakeNotes(new ItemStack[1]
        {
          new ItemStack(88, 1)
        }),
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(8, 1)
        })
      }, "Plants", new Vector2?(new Vector2(30f, 20f)), 0, 1));
      Sprite sprite234 = new Sprite("fleur9", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur9"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur9_shadow"), new Vector2(-8f, 20f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 80,
        MillisecondsPerFrame = 110
      };
      Sprite sprite235 = new Sprite("fleur9_cut", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur9_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur9_shadow"), new Vector2(-8f, 20f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 80,
        MillisecondsPerFrame = 110
      };
      presets.Add(new Preset("Fleur", "fleur geante 9", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite234,
        sprite235
      }, new List<Rectangle>()
      {
        new Rectangle(0, 180, 80, 35)
      }, new Vector2(40f, 169f), new IDodoInteraction[4]
      {
        (IDodoInteraction) new TakeNotes(new ItemStack[1]
        {
          new ItemStack(89, 1)
        }),
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(8, 1)
        })
      }, "Plants", new Vector2?(new Vector2(30f, 20f)), 0, 1));
      Sprite sprite236 = new Sprite("fleur10", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur10"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur10_shadow"), new Vector2(0.0f, 171f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 158,
        height = 198,
        MillisecondsPerFrame = 105
      };
      Sprite sprite237 = new Sprite("fleur10_cut", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur10_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur10_shadow"), new Vector2(0.0f, 171f), opacity: 0.4f)
      });
      presets.Add(new Preset("Fleur", "fleur geante 10", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite236,
        sprite237
      }, new List<Rectangle>()
      {
        new Rectangle(50, 181, 96, 17)
      }, new Vector2(100f, 175f), new IDodoInteraction[4]
      {
        (IDodoInteraction) new TakeNotes(new ItemStack[1]
        {
          new ItemStack(90, 1)
        }),
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(8, 3)
        })
      }, "Plants", new Vector2?(new Vector2(50f, 20f)), 2, 1));
      Sprite sprite238 = new Sprite("fleur11", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur11"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur11_shadow"), new Vector2(0.0f, 220f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 118,
        MillisecondsPerFrame = 90
      };
      Sprite sprite239 = new Sprite("fleur11_cut", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur11_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur11_shadow"), new Vector2(0.0f, 210f), opacity: 0.4f)
      });
      presets.Add(new Preset("Fleur", "fleur geante 11", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite238,
        sprite239
      }, new List<Rectangle>()
      {
        new Rectangle(46, 222, 20, 20)
      }, new Vector2(55f, 230f), new IDodoInteraction[4]
      {
        (IDodoInteraction) new TakeNotes(new ItemStack[1]
        {
          new ItemStack(91, 1)
        }),
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(8, 1)
        })
      }, "Plants", new Vector2?(new Vector2(30f, 20f)), 0, 1));
      Sprite sprite240 = new Sprite("fleur12", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur12"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur12_shadow"), new Vector2(-3f, 219f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 258,
        height = 235,
        MillisecondsPerFrame = 150
      };
      Sprite sprite241 = new Sprite("fleur12_cut", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur12_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur12_shadow"), new Vector2(-3f, 219f), opacity: 0.4f)
      });
      presets.Add(new Preset("Fleur", "fleur geante 12", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite240,
        sprite241
      }, new List<Rectangle>()
      {
        new Rectangle(0, 221, 70, 14),
        new Rectangle(156, 221, 90, 14)
      }, new Vector2(118f, 233f), new IDodoInteraction[4]
      {
        (IDodoInteraction) new TakeNotes(new ItemStack[1]
        {
          new ItemStack(92, 1)
        }),
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(8, 5)
        })
      }, "Plants", new Vector2?(new Vector2(30f, 20f)), 3, 1));
      Sprite sprite242 = new Sprite("fleur13", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur13"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur13_shadow"), new Vector2(15f, 170f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 148,
        height = 192,
        MillisecondsPerFrame = 100
      };
      Sprite sprite243 = new Sprite("fleur13_cut", ContentLoadingWrapper.Load<Texture2D>("fleur/fleur13_cut"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("fleur/fleur13_shadow"), new Vector2(15f, 170f), opacity: 0.4f)
      });
      presets.Add(new Preset("Fleur", "fleur geante 13", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite242,
        sprite243
      }, new List<Rectangle>()
      {
        new Rectangle(0, 160, 150, 40)
      }, new Vector2(90f, 190f), new IDodoInteraction[4]
      {
        (IDodoInteraction) new TakeNotes(new ItemStack[1]
        {
          new ItemStack(93, 1)
        }),
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[1]
        {
          new ItemStack(8, 1)
        })
      }, "Plants", new Vector2?(new Vector2(50f, 50f)), 3, 1));
      presets.Add(new Preset("water falling", "water falling", Preset.WOType.Static, new Sprite("waterfalling", ContentLoadingWrapper.Load<Texture2D>("bamboopipe/waterfalling"), new List<SubSprite>())
      {
        Width = 15,
        animated = true,
        MillisecondsPerFrame = 70
      }, new List<Rectangle>(), new Vector2(5f, 160f), new IDodoInteraction[4], "Other", buildOrUpgradeItems: new List<ItemStack>()));
      Sprite sprite244 = new Sprite("devcat", ContentLoadingWrapper.Load<Texture2D>("devcat82"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("devcat82_shadow"), new Vector2(0.0f, 105f), opacity: 0.4f)
      })
      {
        animated = true,
        Width = 93,
        MillisecondsPerFrame = 120
      };
      Sprite sprite245 = new Sprite("cutteddevcat", ContentLoadingWrapper.Load<Texture2D>("cutteddevcat"), new List<SubSprite>()
      {
        new SubSprite(ContentLoadingWrapper.Load<Texture2D>("devcat82_shadow"), new Vector2(0.0f, 105f), opacity: 0.3f)
      });
      presets.Add(new Preset("Devcat", "Devcat", Preset.WOType.Growable, new List<Sprite>()
      {
        sprite244,
        sprite245
      }, new List<Rectangle>()
      {
        new Rectangle(8, 102, 87, 20)
      }, new Vector2(57f, 113f), new IDodoInteraction[4]
      {
        null,
        null,
        null,
        (IDodoInteraction) new Harvest(new ItemStack[18]
        {
          new ItemStack(0, 99),
          new ItemStack(1, 99),
          new ItemStack(2, 99),
          new ItemStack(3, 99),
          new ItemStack(4, 99),
          new ItemStack(5, 99),
          new ItemStack(6, 99),
          new ItemStack(7, 99),
          new ItemStack(8, 99),
          new ItemStack(9, 99),
          new ItemStack(10, 999),
          new ItemStack(11, 99),
          new ItemStack(12, 99),
          new ItemStack(13, 99),
          new ItemStack(14, 99),
          new ItemStack(15, 99),
          new ItemStack(16, 99),
          new ItemStack(17, 99)
        })
      }, "Other", new Vector2?(new Vector2(30f, 20f))));
      return presets;
    }
  }
}
