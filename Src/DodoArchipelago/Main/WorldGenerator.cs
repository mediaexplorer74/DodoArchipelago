
// Type: DodoTheGame.WorldGenerator

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DodoTheGame.Hitbox;
using DodoTheGame.NPC;
using DodoTheGame.WorldObject;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using XAct;

namespace DodoTheGame
{
  internal static class WorldGenerator
  {

    public static void NewWorldGen(World @world, List<Preset> presetList)
    {
        System.Diagnostics.Debug.WriteLine("[i] NewWorldGen - Generating buildpoints - start...");

        //// World definition START

        // ------------------------------------------------------------------------------------------------------------------------------------------
        // Tableau de bord

        Preset AAA = presetList.First(p => p.name == "Tableau de bord");

        List<IWorldObject> BBB = AAA.MakeWOs(
            new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2
            (
                Game1.rand.Next(-1000, 11000),
                Game1.rand.Next(-1000, 11000)
            ),
            "Tableau de bord"),
        });
        world.objects.AddRange(BBB);


        // ************************

            
        Vector2 location = new Vector2(400, 400);

        IWorldObject worldObject = AAA.MakeWO(location, "Tableau de bord");
        world.objects.Add(worldObject);
            
        // ************************

        // UpgradableHouse
        world.objects.AddRange(presetList.First(p => p.name == "UpgradableHouse")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(
                new Vector2(
                    Game1.rand.Next(-1000, 11000),
                    Game1.rand.Next(-1000, 11000)),  
                    "UpgradableHouse")
        }));

        // UpgradableHouse2
        world.objects.AddRange(presetList.First(p => p.name == "UpgradableHouse2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(
                    /*Game1.rand.Next(-1000, 11000)*/ Game1.dodoCenteredScreenLocation.X-50,
                    /*Game1.rand.Next(-1000, 11000)*/ Game1.dodoCenteredScreenLocation.X-50),
            "UpgradableHouse2")
        }));

        // Maquette
        world.objects.AddRange(presetList.First(p => p.name == "Maquette")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Maquette")
        }));

        // Auto-harvest
        world.objects.AddRange(presetList.First(p => p.name == "Auto-harvest")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Auto-harvest")
        }));

        // Tapis
        world.objects.AddRange(presetList.First(p => p.name == "Tapis")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tapis")
        }));

        // Canap
        world.objects.AddRange(presetList.First(p => p.name == "Canap")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Canap")
        }));

        // Table
        world.objects.AddRange(presetList.First(p => p.name == "Table")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Table")
        }));

        // Lampe
        world.objects.AddRange(presetList.First(p => p.name == "Lampe")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Lampe")
        }));

        // Sablier
        world.objects.AddRange(presetList.First(p => p.name == "Sablier")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Sablier")
        }));

        // IRLClock
        world.objects.AddRange(presetList.First(p => p.name == "IRLClock")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "IRLClock")
        }));

        // Feeder
        world.objects.AddRange(presetList.First(p => p.name == "Feeder")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Feeder")
        }));

        // Atelier
        world.objects.AddRange(presetList.First(p => p.name == "Atelier")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Atelier")
        }));

        // Paravent
        world.objects.AddRange(presetList.First(p => p.name == "Paravent")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Paravent")
        }));

        // Fontaine
        world.objects.AddRange(presetList.First(p => p.name == "Fontaine")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Fontaine")
        }));

        // Chateau de sable
        world.objects.AddRange(presetList.First(p => p.name == "Chateau de sable")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Chateau de sable")
        }));

        // Shiba statue
        world.objects.AddRange(presetList.First(p => p.name == "Shiba statue")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Shiba statue")
        }));

        // Long tuyau
        world.objects.AddRange(presetList.First(p => p.name == "Long tuyau")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Long tuyau")
        }));

        // diagonal pipe 1
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 1")
        }));

        // diagonal pipe 1 rev
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 1 rev")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 1 rev")
        }));

        // diagonal pipe 2 rev
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 rev")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 rev")
        }));

        // diagonal pipe 2 +
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 +")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 +")
        }));

        // diagonal pipe 2 rev +
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 rev +")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 rev +")
        }));

        // diagonal pipe 2
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2")
        }));

        // diagonal pipe 2 rev + double
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 rev + double")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 rev + double")
        }));

        // volcano roc
        world.objects.AddRange(presetList.First(p => p.name == "volcano roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "volcano roc")
        }));

        // reverse volcano roc
        world.objects.AddRange(presetList.First(p => p.name == "reverse volcano roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "reverse volcano roc")
        }));

        // watercloud
        world.objects.AddRange(presetList.First(p => p.name == "watercloud")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "watercloud")
        }));

        // watercloud2
        world.objects.AddRange(presetList.First(p => p.name == "watercloud2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "watercloud2")
        }));

        // Roc
        world.objects.AddRange(presetList.First(p => p.name == "Roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Roc")
        }));

        // unsettlingroc
        world.objects.AddRange(presetList.First(p => p.name == "unsettlingroc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "unsettlingroc")
        }));

        // ronces
        world.objects.AddRange(presetList.First(p => p.name == "ronces")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "ronces")
        }));

        // flatronce
        world.objects.AddRange(presetList.First(p => p.name == "flatronce")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "flatronce")
        }));

        // turningronce
        world.objects.AddRange(presetList.First(p => p.name == "turningronce")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "turningronce")
        }));

        // Quartz Roc
        world.objects.AddRange(presetList.First(p => p.name == "Quartz Roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Quartz Roc")
        }));

        // Big Quartz
        world.objects.AddRange(presetList.First(p => p.name == "Big Quartz")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Big Quartz")
        }));

        // Roc b
        world.objects.AddRange(presetList.First(p => p.name == "Roc b")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Roc b")
        }));

        // UpsideDownRoc
        world.objects.AddRange(presetList.First(p => p.name == "UpsideDownRoc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "UpsideDownRoc")
        }));

        // pillar1
        world.objects.AddRange(presetList.First(p => p.name == "pillar1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar1")
        }));

        // pillar2
        world.objects.AddRange(presetList.First(p => p.name == "pillar2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar2")
        }));

        // pillar3
        world.objects.AddRange(presetList.First(p => p.name == "pillar3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar3")
        }));

        // pillar4
        world.objects.AddRange(presetList.First(p => p.name == "pillar4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar4")
        }));

        // pillar5
        world.objects.AddRange(presetList.First(p => p.name == "pillar5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar5")
        }));

        // pillar6
        world.objects.AddRange(presetList.First(p => p.name == "pillar6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar6")
        }));

        // Big volcano roc
        world.objects.AddRange(presetList.First(p => p.name == "Big volcano roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Big volcano roc")
        }));

        // Big volcano roc2
        world.objects.AddRange(presetList.First(p => p.name == "Big volcano roc2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Big volcano roc2")
        }));

        // BigVolcanoRocNew1
        world.objects.AddRange(presetList.First(p => p.name == "BigVolcanoRocNew1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "BigVolcanoRocNew1")
        }));

        // BigVolcanoRocNew2
        world.objects.AddRange(presetList.First(p => p.name == "BigVolcanoRocNew2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "BigVolcanoRocNew2")
        }));

        // Bamboo shroom
        world.objects.AddRange(presetList.First(p => p.name == "Bamboo shroom")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Bamboo shroom")
        }));

        // roc shroom
        world.objects.AddRange(presetList.First(p => p.name == "roc shroom")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "roc shroom")
        }));

        // Dood shroom
        world.objects.AddRange(presetList.First(p => p.name == "Dood shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Dood shroom")
        }));

        // Tiny shroom
        world.objects.AddRange(presetList.First(p => p.name == "Tiny shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tiny shroom")
        }));

        // palm shroom
        world.objects.AddRange(presetList.First(p => p.name == "palm shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "palm shroom")
        }));

        // regular shroom
        world.objects.AddRange(presetList.First(p => p.name == "regular shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "regular shroom")
        }));

        // small shroom
        world.objects.AddRange(presetList.First(p => p.name == "small shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "small shroom")
        }));

        // pin1
        world.objects.AddRange(presetList.First(p => p.name == "pin1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pin1")
        }));

        // pin2
        world.objects.AddRange(presetList.First(p => p.name == "pin2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pin2")
        }));

        // pinbush
        world.objects.AddRange(presetList.First(p => p.name == "pinbush").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pinbush")
        }));

        // Cocotier1
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier1")
        }));

        // Cocotier1Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier1Mirrored").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier1Mirrored")
        }));

        // Cocotier2
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier2")
        }));

        // Cocotier3
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier3")
        }));

        // Cocotier3Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier3Mirrored")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier3Mirrored")
        }));

        // Bamboo
        world.objects.AddRange(presetList.First(p => p.name == "Bamboo").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Bamboo")
        }));

        // Bamboo 2
        world.objects.AddRange(presetList.First(p => p.name == "Bamboo 2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Bamboo 2")
        }));

        // longbush
        world.objects.AddRange(presetList.First(p => p.name == "longbush").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "longbush")
        }));

        // double_leaf
        world.objects.AddRange(presetList.First(p => p.name == "double_leaf").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "double_leaf")
        }));

        // moonplant
        world.objects.AddRange(presetList.First(p => p.name == "moonplant").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "moonplant")
        }));

        // earthplant
        world.objects.AddRange(presetList.First(p => p.name == "earthplant").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "earthplant")
        }));

        // Cascade
        world.objects.AddRange(presetList.First(p => p.name == "Cascade").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cascade")
        }));

        // cgrass
        world.objects.AddRange(presetList.First(p => p.name == "cgrass").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "cgrass")
        }));

        // Grass1N
        world.objects.AddRange(presetList.First(p => p.name == "Grass1N")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Grass1N")
        }));

        // Volcano spike
        world.objects.AddRange(presetList.First(p => p.name == "Volcano spike")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Volcano spike")
        }));

        // greententacle1
        world.objects.AddRange(presetList.First(p => p.name == "greententacle1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle1")
        }));

        // greententacle2
        world.objects.AddRange(presetList.First(p => p.name == "greententacle2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle2")
        }));

        // greententacle3
        world.objects.AddRange(presetList.First(p => p.name == "greententacle3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle3")
        }));

        // greententacle4
        world.objects.AddRange(presetList.First(p => p.name == "greententacle4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle4")
        }));

        // greententacle5
        world.objects.AddRange(presetList.First(p => p.name == "greententacle5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle5")
        }));

        // greententacle6
        world.objects.AddRange(presetList.First(p => p.name == "greententacle6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle6")
        }));

        // greententacle7
        world.objects.AddRange(presetList.First(p => p.name == "greententacle7")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle7")
        }));

        // mirrorgreententacle1
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle1")
        }));

        // mirrorgreententacle2
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle2")
        }));

        // mirrorgreententacle3
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle3")
        }));

        // mirrorgreententacle4
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle4")
        }));

        // mirrorgreententacle5
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle5")
        }));

        // mirrorgreententacle6
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle6")
        }));

        // mirrorgreententacle7
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle7")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle7")
        }));

        // platebande1
        world.objects.AddRange(presetList.First(p => p.name == "platebande1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "platebande1")
        }));

        // platebande2
        world.objects.AddRange(presetList.First(p => p.name == "platebande2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "platebande2")
        }));

        // mirrorplatebande1
        world.objects.AddRange(presetList.First(p => p.name == "mirrorplatebande1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorplatebande1")
        }));

        // mirrorplatebande2
        world.objects.AddRange(presetList.First(p => p.name == "mirrorplatebande2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorplatebande2")
        }));

        // patch1
        world.objects.AddRange(presetList.First(p => p.name == "patch1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "patch1")
        }));

        // Treebush
        world.objects.AddRange(presetList.First(p => p.name == "Treebush").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Treebush")
        }));

        // Jungle plant 1
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Jungle plant 1")
        }));

        // Jungle plant 1 Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 1 Mirrored")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), 
            "Jungle plant 1 Mirrored\"")
        }));

        // Jungle plant 2
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Jungle plant 2")
        }));

        // Jungle plant 5
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Jungle plant 5")
        }));

        // Fleur
        world.objects.AddRange(presetList.First(p => p.name == "Fleur").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Fleur")
        }));

        // Cocotier avec liane
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier avec liane")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier avec liane")
        }));

        // Cocotier avec liane Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier avec liane Mirrored")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), 
                                                                        "Cocotier avec liane Mirrored")
        }));

        // groundvine1
        world.objects.AddRange(presetList.First(p => p.name == "groundvine1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine1")
        }));

        // groundvine2
        world.objects.AddRange(presetList.First(p => p.name == "groundvine2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine2")
        }));

        // groundvine3
        world.objects.AddRange(presetList.First(p => p.name == "groundvine3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine3")
        }));

        // groundvine4
        world.objects.AddRange(presetList.First(p => p.name == "groundvine4").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine4")
        }));

        // groundvine5
        world.objects.AddRange(presetList.First(p => p.name == "groundvine5").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine5")
        }));

        // groundvine6
        world.objects.AddRange(presetList.First(p => p.name == "groundvine6").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine6")
        }));

        // Tree2
        world.objects.AddRange(presetList.First(p => p.name == "Tree2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tree2")
        }));

        // Tree1
        world.objects.AddRange(presetList.First(p => p.name == "Tree1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tree1")
        }));

        // savana bush
        world.objects.AddRange(presetList.First(p => p.name == "savana bush")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "savana bush")
        }));

        // Roc avec mousse
        world.objects.AddRange(presetList.First(p => p.name == "Roc avec mousse")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Roc avec mousse")
        }));

        // tuft1
        world.objects.AddRange(presetList.First(p => p.name == "tuft1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft1")
        }));

        // tuft2
        world.objects.AddRange(presetList.First(p => p.name == "tuft2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft2")
        }));

        // tuft3
        world.objects.AddRange(presetList.First(p => p.name == "tuft3").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft3")
        }));

        // tuft4
        world.objects.AddRange(presetList.First(p => p.name == "tuft4").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft4")
        }));

        // tuft5
        world.objects.AddRange(presetList.First(p => p.name == "tuft5").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft5")
        }));

        // Eggplant
        world.objects.AddRange(presetList.First(p => p.name == "Eggplant").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Eggplant")
        }));

        // Corail
        world.objects.AddRange(presetList.First(p => p.name == "Corail").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Corail")
        }));

        // plastic bottle
        world.objects.AddRange(presetList.First(p => p.name == "plastic bottle")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), 
                                                                                "plastic bottle")
        }));

        // spike volcan
        world.objects.AddRange(presetList.First(p => p.name == "Volcano spike")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
                                                                                "Volcano spike")
        }));

        // Trash
        world.objects.AddRange(presetList.First(p => p.name == "Trash")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Trash")
        }));

        // Plastic bag
        world.objects.AddRange(presetList.First(p => p.name == "Plastic bag")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Plastic bag")
        }));

        // egg1
        world.objects.AddRange(presetList.First(p => p.name == "egg1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg1")
        }));

        // egg2
        world.objects.AddRange(presetList.First(p => p.name == "egg2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg2")
        }));

        // egg3
        world.objects.AddRange(presetList.First(p => p.name == "egg3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg3")
        }));

        // egg4
        world.objects.AddRange(presetList.First(p => p.name == "egg4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg4")
        }));

        // egg5
        world.objects.AddRange(presetList.First(p => p.name == "egg5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg5")
        }));

        // egg6
        world.objects.AddRange(presetList.First(p => p.name == "egg6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg6")
        }));

        // Aquaroc
        world.objects.AddRange(presetList.First(p => p.name == "Aquaroc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Aquaroc")
        }));

        // Aquapillar
        world.objects.AddRange(presetList.First(p => p.name == "Aquapillar")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Aquapillar")
        }));

        // gros corail
        world.objects.AddRange(presetList.First(p => p.name == "gros corail")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "gros corail")
        }));

        // seashell1
        world.objects.AddRange(presetList.First(p => p.name == "seashell1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "seashell1")
        }));

        // seashell2
        world.objects.AddRange(presetList.First(p => p.name == "seashell2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "seashell2")
        }));

        // Double coconut bush
        world.objects.AddRange(presetList.First(p => p.name == "Double coconut bush")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
            "Double coconut bush")
        }));

        // volcan
        world.objects.AddRange(presetList.First(p => p.name == "volcan")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "volcan")
        }));

        // fleur geante 1
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 1")
        }));

        // fleur geante 2
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 2")
        }));

        // fleur geante 3
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 3")
        }));

        // fleur geante 4
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 4")
        }));

        // fleur geante 5
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 5")
        }));

        // fleur geante 6
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 6")
        }));

        // fleur geante 7
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 7")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 7")
        }));

        // fleur geante 8
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 8")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 8")
        }));

        // fleur geante 9
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 9")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 9")
        }));

        // fleur geante 10
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 10")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 10")
        }));

        // fleur geante 11
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 11")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 11")
        }));

        // fleur geante 12
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 12")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 12")
        }));

        // fleur geante 13
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 13")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 13")
        }));

        // water falling
        world.objects.AddRange(presetList.First(p => p.name == "water falling")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "water falling")
        }));

        // Devcat
        world.objects.AddRange(presetList.First(p => p.name == "Devcat")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Devcat")
        }));











        // ------------------------------------------------------------------------------------------------------------------------------------------
        // Tableau de bord

        AAA = presetList.First(p => p.name == "Tableau de bord");

        BBB = AAA.MakeWOs(
            new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2
            (
                Game1.rand.Next(-1000, 11000),
                Game1.rand.Next(-1000, 11000)
            ),
            "Tableau de bord"),
        });
        world.objects.AddRange(BBB);


        // ************************


        location = new Vector2(400, 400);

        worldObject = AAA.MakeWO(location, "Tableau de bord");
        world.objects.Add(worldObject);

        // ************************

        // UpgradableHouse
        world.objects.AddRange(presetList.First(p => p.name == "UpgradableHouse")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(
                new Vector2(
                    Game1.rand.Next(-1000, 11000),
                    Game1.rand.Next(-1000, 11000)),
                    "UpgradableHouse")
        }));

        // UpgradableHouse2
        world.objects.AddRange(presetList.First(p => p.name == "UpgradableHouse2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(
                    /*Game1.rand.Next(-1000, 11000)*/ Game1.dodoCenteredScreenLocation.X-50,
                    /*Game1.rand.Next(-1000, 11000)*/ Game1.dodoCenteredScreenLocation.X-50),
            "UpgradableHouse2")
        }));

        // Maquette
        world.objects.AddRange(presetList.First(p => p.name == "Maquette")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Maquette")
        }));

        // Auto-harvest
        world.objects.AddRange(presetList.First(p => p.name == "Auto-harvest")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Auto-harvest")
        }));

        // Tapis
        world.objects.AddRange(presetList.First(p => p.name == "Tapis")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tapis")
        }));

        // Canap
        world.objects.AddRange(presetList.First(p => p.name == "Canap")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Canap")
        }));

        // Table
        world.objects.AddRange(presetList.First(p => p.name == "Table")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Table")
        }));

        // Lampe
        world.objects.AddRange(presetList.First(p => p.name == "Lampe")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Lampe")
        }));

        // Sablier
        world.objects.AddRange(presetList.First(p => p.name == "Sablier")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Sablier")
        }));

        // IRLClock
        world.objects.AddRange(presetList.First(p => p.name == "IRLClock")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "IRLClock")
        }));

        // Feeder
        world.objects.AddRange(presetList.First(p => p.name == "Feeder")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Feeder")
        }));

        // Atelier
        world.objects.AddRange(presetList.First(p => p.name == "Atelier")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Atelier")
        }));

        // Paravent
        world.objects.AddRange(presetList.First(p => p.name == "Paravent")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Paravent")
        }));

        // Fontaine
        world.objects.AddRange(presetList.First(p => p.name == "Fontaine")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Fontaine")
        }));

        // Chateau de sable
        world.objects.AddRange(presetList.First(p => p.name == "Chateau de sable")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Chateau de sable")
        }));

        // Shiba statue
        world.objects.AddRange(presetList.First(p => p.name == "Shiba statue")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Shiba statue")
        }));

        // Long tuyau
        world.objects.AddRange(presetList.First(p => p.name == "Long tuyau")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Long tuyau")
        }));

        // diagonal pipe 1
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 1")
        }));

        // diagonal pipe 1 rev
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 1 rev")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 1 rev")
        }));

        // diagonal pipe 2 rev
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 rev")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 rev")
        }));

        // diagonal pipe 2 +
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 +")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 +")
        }));

        // diagonal pipe 2 rev +
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 rev +")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 rev +")
        }));

        // diagonal pipe 2
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2")
        }));

        // diagonal pipe 2 rev + double
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 rev + double")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 rev + double")
        }));

        // volcano roc
        world.objects.AddRange(presetList.First(p => p.name == "volcano roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "volcano roc")
        }));

        // reverse volcano roc
        world.objects.AddRange(presetList.First(p => p.name == "reverse volcano roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "reverse volcano roc")
        }));

        // watercloud
        world.objects.AddRange(presetList.First(p => p.name == "watercloud")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "watercloud")
        }));

        // watercloud2
        world.objects.AddRange(presetList.First(p => p.name == "watercloud2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "watercloud2")
        }));

        // Roc
        world.objects.AddRange(presetList.First(p => p.name == "Roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Roc")
        }));

        // unsettlingroc
        world.objects.AddRange(presetList.First(p => p.name == "unsettlingroc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "unsettlingroc")
        }));

        // ronces
        world.objects.AddRange(presetList.First(p => p.name == "ronces")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "ronces")
        }));

        // flatronce
        world.objects.AddRange(presetList.First(p => p.name == "flatronce")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "flatronce")
        }));

        // turningronce
        world.objects.AddRange(presetList.First(p => p.name == "turningronce")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "turningronce")
        }));

        // Quartz Roc
        world.objects.AddRange(presetList.First(p => p.name == "Quartz Roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Quartz Roc")
        }));

        // Big Quartz
        world.objects.AddRange(presetList.First(p => p.name == "Big Quartz")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Big Quartz")
        }));

        // Roc b
        world.objects.AddRange(presetList.First(p => p.name == "Roc b")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Roc b")
        }));

        // UpsideDownRoc
        world.objects.AddRange(presetList.First(p => p.name == "UpsideDownRoc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "UpsideDownRoc")
        }));

        // pillar1
        world.objects.AddRange(presetList.First(p => p.name == "pillar1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar1")
        }));

        // pillar2
        world.objects.AddRange(presetList.First(p => p.name == "pillar2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar2")
        }));

        // pillar3
        world.objects.AddRange(presetList.First(p => p.name == "pillar3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar3")
        }));

        // pillar4
        world.objects.AddRange(presetList.First(p => p.name == "pillar4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar4")
        }));

        // pillar5
        world.objects.AddRange(presetList.First(p => p.name == "pillar5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar5")
        }));

        // pillar6
        world.objects.AddRange(presetList.First(p => p.name == "pillar6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar6")
        }));

        // Big volcano roc
        world.objects.AddRange(presetList.First(p => p.name == "Big volcano roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Big volcano roc")
        }));

        // Big volcano roc2
        world.objects.AddRange(presetList.First(p => p.name == "Big volcano roc2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Big volcano roc2")
        }));

        // BigVolcanoRocNew1
        world.objects.AddRange(presetList.First(p => p.name == "BigVolcanoRocNew1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "BigVolcanoRocNew1")
        }));

        // BigVolcanoRocNew2
        world.objects.AddRange(presetList.First(p => p.name == "BigVolcanoRocNew2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "BigVolcanoRocNew2")
        }));

        // Bamboo shroom
        world.objects.AddRange(presetList.First(p => p.name == "Bamboo shroom")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Bamboo shroom")
        }));

        // roc shroom
        world.objects.AddRange(presetList.First(p => p.name == "roc shroom")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "roc shroom")
        }));

        // Dood shroom
        world.objects.AddRange(presetList.First(p => p.name == "Dood shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Dood shroom")
        }));

        // Tiny shroom
        world.objects.AddRange(presetList.First(p => p.name == "Tiny shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tiny shroom")
        }));

        // palm shroom
        world.objects.AddRange(presetList.First(p => p.name == "palm shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "palm shroom")
        }));

        // regular shroom
        world.objects.AddRange(presetList.First(p => p.name == "regular shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "regular shroom")
        }));

        // small shroom
        world.objects.AddRange(presetList.First(p => p.name == "small shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "small shroom")
        }));

        // pin1
        world.objects.AddRange(presetList.First(p => p.name == "pin1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pin1")
        }));

        // pin2
        world.objects.AddRange(presetList.First(p => p.name == "pin2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pin2")
        }));

        // pinbush
        world.objects.AddRange(presetList.First(p => p.name == "pinbush").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pinbush")
        }));

        // Cocotier1
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier1")
        }));

        // Cocotier1Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier1Mirrored").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier1Mirrored")
        }));

        // Cocotier2
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier2")
        }));

        // Cocotier3
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier3")
        }));

        // Cocotier3Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier3Mirrored")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier3Mirrored")
        }));

        // Bamboo
        world.objects.AddRange(presetList.First(p => p.name == "Bamboo").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Bamboo")
        }));

        // Bamboo 2
        world.objects.AddRange(presetList.First(p => p.name == "Bamboo 2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Bamboo 2")
        }));

        // longbush
        world.objects.AddRange(presetList.First(p => p.name == "longbush").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "longbush")
        }));

        // double_leaf
        world.objects.AddRange(presetList.First(p => p.name == "double_leaf").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "double_leaf")
        }));

        // moonplant
        world.objects.AddRange(presetList.First(p => p.name == "moonplant").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "moonplant")
        }));

        // earthplant
        world.objects.AddRange(presetList.First(p => p.name == "earthplant").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "earthplant")
        }));

        // Cascade
        world.objects.AddRange(presetList.First(p => p.name == "Cascade").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cascade")
        }));

        // cgrass
        world.objects.AddRange(presetList.First(p => p.name == "cgrass").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "cgrass")
        }));

        // Grass1N
        world.objects.AddRange(presetList.First(p => p.name == "Grass1N")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Grass1N")
        }));

        // Volcano spike
        world.objects.AddRange(presetList.First(p => p.name == "Volcano spike")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Volcano spike")
        }));

        // greententacle1
        world.objects.AddRange(presetList.First(p => p.name == "greententacle1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle1")
        }));

        // greententacle2
        world.objects.AddRange(presetList.First(p => p.name == "greententacle2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle2")
        }));

        // greententacle3
        world.objects.AddRange(presetList.First(p => p.name == "greententacle3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle3")
        }));

        // greententacle4
        world.objects.AddRange(presetList.First(p => p.name == "greententacle4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle4")
        }));

        // greententacle5
        world.objects.AddRange(presetList.First(p => p.name == "greententacle5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle5")
        }));

        // greententacle6
        world.objects.AddRange(presetList.First(p => p.name == "greententacle6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle6")
        }));

        // greententacle7
        world.objects.AddRange(presetList.First(p => p.name == "greententacle7")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle7")
        }));

        // mirrorgreententacle1
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle1")
        }));

        // mirrorgreententacle2
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle2")
        }));

        // mirrorgreententacle3
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle3")
        }));

        // mirrorgreententacle4
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle4")
        }));

        // mirrorgreententacle5
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle5")
        }));

        // mirrorgreententacle6
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle6")
        }));

        // mirrorgreententacle7
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle7")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle7")
        }));

        // platebande1
        world.objects.AddRange(presetList.First(p => p.name == "platebande1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "platebande1")
        }));

        // platebande2
        world.objects.AddRange(presetList.First(p => p.name == "platebande2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "platebande2")
        }));

        // mirrorplatebande1
        world.objects.AddRange(presetList.First(p => p.name == "mirrorplatebande1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorplatebande1")
        }));

        // mirrorplatebande2
        world.objects.AddRange(presetList.First(p => p.name == "mirrorplatebande2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorplatebande2")
        }));

        // patch1
        world.objects.AddRange(presetList.First(p => p.name == "patch1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "patch1")
        }));

        // Treebush
        world.objects.AddRange(presetList.First(p => p.name == "Treebush").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Treebush")
        }));

        // Jungle plant 1
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Jungle plant 1")
        }));

        // Jungle plant 1 Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 1 Mirrored")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
            "Jungle plant 1 Mirrored\"")
        }));

        // Jungle plant 2
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Jungle plant 2")
        }));

        // Jungle plant 5
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Jungle plant 5")
        }));

        // Fleur
        world.objects.AddRange(presetList.First(p => p.name == "Fleur").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Fleur")
        }));

        // Cocotier avec liane
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier avec liane")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier avec liane")
        }));

        // Cocotier avec liane Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier avec liane Mirrored")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
                                                                        "Cocotier avec liane Mirrored")
        }));

        // groundvine1
        world.objects.AddRange(presetList.First(p => p.name == "groundvine1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine1")
        }));

        // groundvine2
        world.objects.AddRange(presetList.First(p => p.name == "groundvine2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine2")
        }));

        // groundvine3
        world.objects.AddRange(presetList.First(p => p.name == "groundvine3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine3")
        }));

        // groundvine4
        world.objects.AddRange(presetList.First(p => p.name == "groundvine4").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine4")
        }));

        // groundvine5
        world.objects.AddRange(presetList.First(p => p.name == "groundvine5").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine5")
        }));

        // groundvine6
        world.objects.AddRange(presetList.First(p => p.name == "groundvine6").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine6")
        }));

        // Tree2
        world.objects.AddRange(presetList.First(p => p.name == "Tree2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tree2")
        }));

        // Tree1
        world.objects.AddRange(presetList.First(p => p.name == "Tree1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tree1")
        }));

        // savana bush
        world.objects.AddRange(presetList.First(p => p.name == "savana bush")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "savana bush")
        }));

        // Roc avec mousse
        world.objects.AddRange(presetList.First(p => p.name == "Roc avec mousse")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Roc avec mousse")
        }));

        // tuft1
        world.objects.AddRange(presetList.First(p => p.name == "tuft1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft1")
        }));

        // tuft2
        world.objects.AddRange(presetList.First(p => p.name == "tuft2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft2")
        }));

        // tuft3
        world.objects.AddRange(presetList.First(p => p.name == "tuft3").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft3")
        }));

        // tuft4
        world.objects.AddRange(presetList.First(p => p.name == "tuft4").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft4")
        }));

        // tuft5
        world.objects.AddRange(presetList.First(p => p.name == "tuft5").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft5")
        }));

        // Eggplant
        world.objects.AddRange(presetList.First(p => p.name == "Eggplant").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Eggplant")
        }));

        // Corail
        world.objects.AddRange(presetList.First(p => p.name == "Corail").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Corail")
        }));

        // plastic bottle
        world.objects.AddRange(presetList.First(p => p.name == "plastic bottle")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
                                                                                "plastic bottle")
        }));

        // spike volcan
        world.objects.AddRange(presetList.First(p => p.name == "Volcano spike")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
                                                                                "Volcano spike")
        }));

        // Trash
        world.objects.AddRange(presetList.First(p => p.name == "Trash")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Trash")
        }));

        // Plastic bag
        world.objects.AddRange(presetList.First(p => p.name == "Plastic bag")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Plastic bag")
        }));

        // egg1
        world.objects.AddRange(presetList.First(p => p.name == "egg1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg1")
        }));

        // egg2
        world.objects.AddRange(presetList.First(p => p.name == "egg2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg2")
        }));

        // egg3
        world.objects.AddRange(presetList.First(p => p.name == "egg3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg3")
        }));

        // egg4
        world.objects.AddRange(presetList.First(p => p.name == "egg4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg4")
        }));

        // egg5
        world.objects.AddRange(presetList.First(p => p.name == "egg5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg5")
        }));

        // egg6
        world.objects.AddRange(presetList.First(p => p.name == "egg6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg6")
        }));

        // Aquaroc
        world.objects.AddRange(presetList.First(p => p.name == "Aquaroc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Aquaroc")
        }));

        // Aquapillar
        world.objects.AddRange(presetList.First(p => p.name == "Aquapillar")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Aquapillar")
        }));

        // gros corail
        world.objects.AddRange(presetList.First(p => p.name == "gros corail")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "gros corail")
        }));

        // seashell1
        world.objects.AddRange(presetList.First(p => p.name == "seashell1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "seashell1")
        }));

        // seashell2
        world.objects.AddRange(presetList.First(p => p.name == "seashell2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "seashell2")
        }));

        // Double coconut bush
        world.objects.AddRange(presetList.First(p => p.name == "Double coconut bush")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
            "Double coconut bush")
        }));

        // volcan
        world.objects.AddRange(presetList.First(p => p.name == "volcan")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "volcan")
        }));

        // fleur geante 1
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 1")
        }));

        // fleur geante 2
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 2")
        }));

        // fleur geante 3
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 3")
        }));

        // fleur geante 4
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 4")
        }));

        // fleur geante 5
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 5")
        }));

        // fleur geante 6
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 6")
        }));

        // fleur geante 7
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 7")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 7")
        }));

        // fleur geante 8
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 8")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 8")
        }));

        // fleur geante 9
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 9")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 9")
        }));

        // fleur geante 10
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 10")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 10")
        }));

        // fleur geante 11
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 11")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 11")
        }));

        // fleur geante 12
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 12")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 12")
        }));

        // fleur geante 13
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 13")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 13")
        }));

        // water falling
        world.objects.AddRange(presetList.First(p => p.name == "water falling")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "water falling")
        }));

        // Devcat
        world.objects.AddRange(presetList.First(p => p.name == "Devcat")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Devcat")
        }));






        // ------------------------------------------------------------------------------------------------------------------------------------------
        // Tableau de bord

        AAA = presetList.First(p => p.name == "Tableau de bord");

        BBB = AAA.MakeWOs(
            new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2
            (
                Game1.rand.Next(-1000, 11000),
                Game1.rand.Next(-1000, 11000)
            ),
            "Tableau de bord"),
        });
        world.objects.AddRange(BBB);


        // ************************


        location = new Vector2(400, 400);

        worldObject = AAA.MakeWO(location, "Tableau de bord");
        world.objects.Add(worldObject);

        // ************************

        // UpgradableHouse
        world.objects.AddRange(presetList.First(p => p.name == "UpgradableHouse")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(
                new Vector2(
                    Game1.rand.Next(-1000, 11000),
                    Game1.rand.Next(-1000, 11000)),
                    "UpgradableHouse")
        }));

        // UpgradableHouse2
        world.objects.AddRange(presetList.First(p => p.name == "UpgradableHouse2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(
                    /*Game1.rand.Next(-1000, 11000)*/ Game1.dodoCenteredScreenLocation.X-50,
                    /*Game1.rand.Next(-1000, 11000)*/ Game1.dodoCenteredScreenLocation.X-50),
            "UpgradableHouse2")
        }));

        // Maquette
        world.objects.AddRange(presetList.First(p => p.name == "Maquette")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Maquette")
        }));

        // Auto-harvest
        world.objects.AddRange(presetList.First(p => p.name == "Auto-harvest")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Auto-harvest")
        }));

        // Tapis
        world.objects.AddRange(presetList.First(p => p.name == "Tapis")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tapis")
        }));

        // Canap
        world.objects.AddRange(presetList.First(p => p.name == "Canap")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Canap")
        }));

        // Table
        world.objects.AddRange(presetList.First(p => p.name == "Table")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Table")
        }));

        // Lampe
        world.objects.AddRange(presetList.First(p => p.name == "Lampe")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Lampe")
        }));

        // Sablier
        world.objects.AddRange(presetList.First(p => p.name == "Sablier")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Sablier")
        }));

        // IRLClock
        world.objects.AddRange(presetList.First(p => p.name == "IRLClock")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "IRLClock")
        }));

        // Feeder
        world.objects.AddRange(presetList.First(p => p.name == "Feeder")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Feeder")
        }));

        // Atelier
        world.objects.AddRange(presetList.First(p => p.name == "Atelier")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Atelier")
        }));

        // Paravent
        world.objects.AddRange(presetList.First(p => p.name == "Paravent")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Paravent")
        }));

        // Fontaine
        world.objects.AddRange(presetList.First(p => p.name == "Fontaine")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Fontaine")
        }));

        // Chateau de sable
        world.objects.AddRange(presetList.First(p => p.name == "Chateau de sable")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Chateau de sable")
        }));

        // Shiba statue
        world.objects.AddRange(presetList.First(p => p.name == "Shiba statue")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Shiba statue")
        }));

        // Long tuyau
        world.objects.AddRange(presetList.First(p => p.name == "Long tuyau")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Long tuyau")
        }));

        // diagonal pipe 1
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 1")
        }));

        // diagonal pipe 1 rev
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 1 rev")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 1 rev")
        }));

        // diagonal pipe 2 rev
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 rev")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 rev")
        }));

        // diagonal pipe 2 +
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 +")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 +")
        }));

        // diagonal pipe 2 rev +
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 rev +")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 rev +")
        }));

        // diagonal pipe 2
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2")
        }));

        // diagonal pipe 2 rev + double
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 rev + double")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 rev + double")
        }));

        // volcano roc
        world.objects.AddRange(presetList.First(p => p.name == "volcano roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "volcano roc")
        }));

        // reverse volcano roc
        world.objects.AddRange(presetList.First(p => p.name == "reverse volcano roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "reverse volcano roc")
        }));

        // watercloud
        world.objects.AddRange(presetList.First(p => p.name == "watercloud")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "watercloud")
        }));

        // watercloud2
        world.objects.AddRange(presetList.First(p => p.name == "watercloud2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "watercloud2")
        }));

        // Roc
        world.objects.AddRange(presetList.First(p => p.name == "Roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Roc")
        }));

        // unsettlingroc
        world.objects.AddRange(presetList.First(p => p.name == "unsettlingroc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "unsettlingroc")
        }));

        // ronces
        world.objects.AddRange(presetList.First(p => p.name == "ronces")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "ronces")
        }));

        // flatronce
        world.objects.AddRange(presetList.First(p => p.name == "flatronce")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "flatronce")
        }));

        // turningronce
        world.objects.AddRange(presetList.First(p => p.name == "turningronce")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "turningronce")
        }));

        // Quartz Roc
        world.objects.AddRange(presetList.First(p => p.name == "Quartz Roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Quartz Roc")
        }));

        // Big Quartz
        world.objects.AddRange(presetList.First(p => p.name == "Big Quartz")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Big Quartz")
        }));

        // Roc b
        world.objects.AddRange(presetList.First(p => p.name == "Roc b")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Roc b")
        }));

        // UpsideDownRoc
        world.objects.AddRange(presetList.First(p => p.name == "UpsideDownRoc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "UpsideDownRoc")
        }));

        // pillar1
        world.objects.AddRange(presetList.First(p => p.name == "pillar1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar1")
        }));

        // pillar2
        world.objects.AddRange(presetList.First(p => p.name == "pillar2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar2")
        }));

        // pillar3
        world.objects.AddRange(presetList.First(p => p.name == "pillar3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar3")
        }));

        // pillar4
        world.objects.AddRange(presetList.First(p => p.name == "pillar4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar4")
        }));

        // pillar5
        world.objects.AddRange(presetList.First(p => p.name == "pillar5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar5")
        }));

        // pillar6
        world.objects.AddRange(presetList.First(p => p.name == "pillar6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar6")
        }));

        // Big volcano roc
        world.objects.AddRange(presetList.First(p => p.name == "Big volcano roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Big volcano roc")
        }));

        // Big volcano roc2
        world.objects.AddRange(presetList.First(p => p.name == "Big volcano roc2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Big volcano roc2")
        }));

        // BigVolcanoRocNew1
        world.objects.AddRange(presetList.First(p => p.name == "BigVolcanoRocNew1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "BigVolcanoRocNew1")
        }));

        // BigVolcanoRocNew2
        world.objects.AddRange(presetList.First(p => p.name == "BigVolcanoRocNew2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "BigVolcanoRocNew2")
        }));

        // Bamboo shroom
        world.objects.AddRange(presetList.First(p => p.name == "Bamboo shroom")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Bamboo shroom")
        }));

        // roc shroom
        world.objects.AddRange(presetList.First(p => p.name == "roc shroom")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "roc shroom")
        }));

        // Dood shroom
        world.objects.AddRange(presetList.First(p => p.name == "Dood shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Dood shroom")
        }));

        // Tiny shroom
        world.objects.AddRange(presetList.First(p => p.name == "Tiny shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tiny shroom")
        }));

        // palm shroom
        world.objects.AddRange(presetList.First(p => p.name == "palm shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "palm shroom")
        }));

        // regular shroom
        world.objects.AddRange(presetList.First(p => p.name == "regular shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "regular shroom")
        }));

        // small shroom
        world.objects.AddRange(presetList.First(p => p.name == "small shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "small shroom")
        }));

        // pin1
        world.objects.AddRange(presetList.First(p => p.name == "pin1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pin1")
        }));

        // pin2
        world.objects.AddRange(presetList.First(p => p.name == "pin2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pin2")
        }));

        // pinbush
        world.objects.AddRange(presetList.First(p => p.name == "pinbush").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pinbush")
        }));

        // Cocotier1
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier1")
        }));

        // Cocotier1Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier1Mirrored").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier1Mirrored")
        }));

        // Cocotier2
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier2")
        }));

        // Cocotier3
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier3")
        }));

        // Cocotier3Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier3Mirrored")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier3Mirrored")
        }));

        // Bamboo
        world.objects.AddRange(presetList.First(p => p.name == "Bamboo").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Bamboo")
        }));

        // Bamboo 2
        world.objects.AddRange(presetList.First(p => p.name == "Bamboo 2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Bamboo 2")
        }));

        // longbush
        world.objects.AddRange(presetList.First(p => p.name == "longbush").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "longbush")
        }));

        // double_leaf
        world.objects.AddRange(presetList.First(p => p.name == "double_leaf").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "double_leaf")
        }));

        // moonplant
        world.objects.AddRange(presetList.First(p => p.name == "moonplant").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "moonplant")
        }));

        // earthplant
        world.objects.AddRange(presetList.First(p => p.name == "earthplant").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "earthplant")
        }));

        // Cascade
        world.objects.AddRange(presetList.First(p => p.name == "Cascade").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cascade")
        }));

        // cgrass
        world.objects.AddRange(presetList.First(p => p.name == "cgrass").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "cgrass")
        }));

        // Grass1N
        world.objects.AddRange(presetList.First(p => p.name == "Grass1N")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Grass1N")
        }));

        // Volcano spike
        world.objects.AddRange(presetList.First(p => p.name == "Volcano spike")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Volcano spike")
        }));

        // greententacle1
        world.objects.AddRange(presetList.First(p => p.name == "greententacle1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle1")
        }));

        // greententacle2
        world.objects.AddRange(presetList.First(p => p.name == "greententacle2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle2")
        }));

        // greententacle3
        world.objects.AddRange(presetList.First(p => p.name == "greententacle3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle3")
        }));

        // greententacle4
        world.objects.AddRange(presetList.First(p => p.name == "greententacle4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle4")
        }));

        // greententacle5
        world.objects.AddRange(presetList.First(p => p.name == "greententacle5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle5")
        }));

        // greententacle6
        world.objects.AddRange(presetList.First(p => p.name == "greententacle6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle6")
        }));

        // greententacle7
        world.objects.AddRange(presetList.First(p => p.name == "greententacle7")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle7")
        }));

        // mirrorgreententacle1
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle1")
        }));

        // mirrorgreententacle2
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle2")
        }));

        // mirrorgreententacle3
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle3")
        }));

        // mirrorgreententacle4
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle4")
        }));

        // mirrorgreententacle5
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle5")
        }));

        // mirrorgreententacle6
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle6")
        }));

        // mirrorgreententacle7
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle7")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle7")
        }));

        // platebande1
        world.objects.AddRange(presetList.First(p => p.name == "platebande1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "platebande1")
        }));

        // platebande2
        world.objects.AddRange(presetList.First(p => p.name == "platebande2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "platebande2")
        }));

        // mirrorplatebande1
        world.objects.AddRange(presetList.First(p => p.name == "mirrorplatebande1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorplatebande1")
        }));

        // mirrorplatebande2
        world.objects.AddRange(presetList.First(p => p.name == "mirrorplatebande2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorplatebande2")
        }));

        // patch1
        world.objects.AddRange(presetList.First(p => p.name == "patch1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "patch1")
        }));

        // Treebush
        world.objects.AddRange(presetList.First(p => p.name == "Treebush").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Treebush")
        }));

        // Jungle plant 1
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Jungle plant 1")
        }));

        // Jungle plant 1 Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 1 Mirrored")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
            "Jungle plant 1 Mirrored\"")
        }));

        // Jungle plant 2
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Jungle plant 2")
        }));

        // Jungle plant 5
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Jungle plant 5")
        }));

        // Fleur
        world.objects.AddRange(presetList.First(p => p.name == "Fleur").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Fleur")
        }));

        // Cocotier avec liane
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier avec liane")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier avec liane")
        }));

        // Cocotier avec liane Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier avec liane Mirrored")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
                                                                        "Cocotier avec liane Mirrored")
        }));

        // groundvine1
        world.objects.AddRange(presetList.First(p => p.name == "groundvine1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine1")
        }));

        // groundvine2
        world.objects.AddRange(presetList.First(p => p.name == "groundvine2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine2")
        }));

        // groundvine3
        world.objects.AddRange(presetList.First(p => p.name == "groundvine3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine3")
        }));

        // groundvine4
        world.objects.AddRange(presetList.First(p => p.name == "groundvine4").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine4")
        }));

        // groundvine5
        world.objects.AddRange(presetList.First(p => p.name == "groundvine5").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine5")
        }));

        // groundvine6
        world.objects.AddRange(presetList.First(p => p.name == "groundvine6").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine6")
        }));

        // Tree2
        world.objects.AddRange(presetList.First(p => p.name == "Tree2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tree2")
        }));

        // Tree1
        world.objects.AddRange(presetList.First(p => p.name == "Tree1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tree1")
        }));

        // savana bush
        world.objects.AddRange(presetList.First(p => p.name == "savana bush")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "savana bush")
        }));

        // Roc avec mousse
        world.objects.AddRange(presetList.First(p => p.name == "Roc avec mousse")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Roc avec mousse")
        }));

        // tuft1
        world.objects.AddRange(presetList.First(p => p.name == "tuft1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft1")
        }));

        // tuft2
        world.objects.AddRange(presetList.First(p => p.name == "tuft2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft2")
        }));

        // tuft3
        world.objects.AddRange(presetList.First(p => p.name == "tuft3").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft3")
        }));

        // tuft4
        world.objects.AddRange(presetList.First(p => p.name == "tuft4").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft4")
        }));

        // tuft5
        world.objects.AddRange(presetList.First(p => p.name == "tuft5").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft5")
        }));

        // Eggplant
        world.objects.AddRange(presetList.First(p => p.name == "Eggplant").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Eggplant")
        }));

        // Corail
        world.objects.AddRange(presetList.First(p => p.name == "Corail").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Corail")
        }));

        // plastic bottle
        world.objects.AddRange(presetList.First(p => p.name == "plastic bottle")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
                                                                                "plastic bottle")
        }));

        // spike volcan
        world.objects.AddRange(presetList.First(p => p.name == "Volcano spike")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
                                                                                "Volcano spike")
        }));

        // Trash
        world.objects.AddRange(presetList.First(p => p.name == "Trash")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Trash")
        }));

        // Plastic bag
        world.objects.AddRange(presetList.First(p => p.name == "Plastic bag")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Plastic bag")
        }));

        // egg1
        world.objects.AddRange(presetList.First(p => p.name == "egg1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg1")
        }));

        // egg2
        world.objects.AddRange(presetList.First(p => p.name == "egg2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg2")
        }));

        // egg3
        world.objects.AddRange(presetList.First(p => p.name == "egg3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg3")
        }));

        // egg4
        world.objects.AddRange(presetList.First(p => p.name == "egg4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg4")
        }));

        // egg5
        world.objects.AddRange(presetList.First(p => p.name == "egg5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg5")
        }));

        // egg6
        world.objects.AddRange(presetList.First(p => p.name == "egg6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg6")
        }));

        // Aquaroc
        world.objects.AddRange(presetList.First(p => p.name == "Aquaroc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Aquaroc")
        }));

        // Aquapillar
        world.objects.AddRange(presetList.First(p => p.name == "Aquapillar")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Aquapillar")
        }));

        // gros corail
        world.objects.AddRange(presetList.First(p => p.name == "gros corail")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "gros corail")
        }));

        // seashell1
        world.objects.AddRange(presetList.First(p => p.name == "seashell1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "seashell1")
        }));

        // seashell2
        world.objects.AddRange(presetList.First(p => p.name == "seashell2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "seashell2")
        }));

        // Double coconut bush
        world.objects.AddRange(presetList.First(p => p.name == "Double coconut bush")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
            "Double coconut bush")
        }));

        // volcan
        world.objects.AddRange(presetList.First(p => p.name == "volcan")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "volcan")
        }));

        // fleur geante 1
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 1")
        }));

        // fleur geante 2
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 2")
        }));

        // fleur geante 3
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 3")
        }));

        // fleur geante 4
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 4")
        }));

        // fleur geante 5
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 5")
        }));

        // fleur geante 6
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 6")
        }));

        // fleur geante 7
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 7")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 7")
        }));

        // fleur geante 8
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 8")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 8")
        }));

        // fleur geante 9
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 9")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 9")
        }));

        // fleur geante 10
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 10")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 10")
        }));

        // fleur geante 11
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 11")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 11")
        }));

        // fleur geante 12
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 12")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 12")
        }));

        // fleur geante 13
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 13")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 13")
        }));

        // water falling
        world.objects.AddRange(presetList.First(p => p.name == "water falling")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "water falling")
        }));

        // Devcat
        world.objects.AddRange(presetList.First(p => p.name == "Devcat")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Devcat")
        }));




        // ------------------------------------------------------------------------------------------------------------------------------------------
        // Tableau de bord

        AAA = presetList.First(p => p.name == "Tableau de bord");

        BBB = AAA.MakeWOs(
            new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2
            (
                Game1.rand.Next(-1000, 11000),
                Game1.rand.Next(-1000, 11000)
            ),
            "Tableau de bord"),
        });
        world.objects.AddRange(BBB);


        // ************************


         location = new Vector2(400, 400);

        worldObject = AAA.MakeWO(location, "Tableau de bord");
        world.objects.Add(worldObject);

        // ************************

        // UpgradableHouse
        world.objects.AddRange(presetList.First(p => p.name == "UpgradableHouse")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(
                new Vector2(
                    Game1.rand.Next(-1000, 11000),
                    Game1.rand.Next(-1000, 11000)),
                    "UpgradableHouse")
        }));

        // UpgradableHouse2
        world.objects.AddRange(presetList.First(p => p.name == "UpgradableHouse2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(
                    /*Game1.rand.Next(-1000, 11000)*/ Game1.dodoCenteredScreenLocation.X-50,
                    /*Game1.rand.Next(-1000, 11000)*/ Game1.dodoCenteredScreenLocation.X-50),
            "UpgradableHouse2")
        }));

        // Maquette
        world.objects.AddRange(presetList.First(p => p.name == "Maquette")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Maquette")
        }));

        // Auto-harvest
        world.objects.AddRange(presetList.First(p => p.name == "Auto-harvest")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Auto-harvest")
        }));

        // Tapis
        world.objects.AddRange(presetList.First(p => p.name == "Tapis")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tapis")
        }));

        // Canap
        world.objects.AddRange(presetList.First(p => p.name == "Canap")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Canap")
        }));

        // Table
        world.objects.AddRange(presetList.First(p => p.name == "Table")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Table")
        }));

        // Lampe
        world.objects.AddRange(presetList.First(p => p.name == "Lampe")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Lampe")
        }));

        // Sablier
        world.objects.AddRange(presetList.First(p => p.name == "Sablier")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Sablier")
        }));

        // IRLClock
        world.objects.AddRange(presetList.First(p => p.name == "IRLClock")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "IRLClock")
        }));

        // Feeder
        world.objects.AddRange(presetList.First(p => p.name == "Feeder")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Feeder")
        }));

        // Atelier
        world.objects.AddRange(presetList.First(p => p.name == "Atelier")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Atelier")
        }));

        // Paravent
        world.objects.AddRange(presetList.First(p => p.name == "Paravent")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Paravent")
        }));

        // Fontaine
        world.objects.AddRange(presetList.First(p => p.name == "Fontaine")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Fontaine")
        }));

        // Chateau de sable
        world.objects.AddRange(presetList.First(p => p.name == "Chateau de sable")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Chateau de sable")
        }));

        // Shiba statue
        world.objects.AddRange(presetList.First(p => p.name == "Shiba statue")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Shiba statue")
        }));

        // Long tuyau
        world.objects.AddRange(presetList.First(p => p.name == "Long tuyau")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Long tuyau")
        }));

        // diagonal pipe 1
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 1")
        }));

        // diagonal pipe 1 rev
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 1 rev")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 1 rev")
        }));

        // diagonal pipe 2 rev
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 rev")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 rev")
        }));

        // diagonal pipe 2 +
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 +")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 +")
        }));

        // diagonal pipe 2 rev +
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 rev +")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 rev +")
        }));

        // diagonal pipe 2
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2")
        }));

        // diagonal pipe 2 rev + double
        world.objects.AddRange(presetList.First(p => p.name == "diagonal pipe 2 rev + double")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "diagonal pipe 2 rev + double")
        }));

        // volcano roc
        world.objects.AddRange(presetList.First(p => p.name == "volcano roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "volcano roc")
        }));

        // reverse volcano roc
        world.objects.AddRange(presetList.First(p => p.name == "reverse volcano roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "reverse volcano roc")
        }));

        // watercloud
        world.objects.AddRange(presetList.First(p => p.name == "watercloud")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "watercloud")
        }));

        // watercloud2
        world.objects.AddRange(presetList.First(p => p.name == "watercloud2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "watercloud2")
        }));

        // Roc
        world.objects.AddRange(presetList.First(p => p.name == "Roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Roc")
        }));

        // unsettlingroc
        world.objects.AddRange(presetList.First(p => p.name == "unsettlingroc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "unsettlingroc")
        }));

        // ronces
        world.objects.AddRange(presetList.First(p => p.name == "ronces")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "ronces")
        }));

        // flatronce
        world.objects.AddRange(presetList.First(p => p.name == "flatronce")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "flatronce")
        }));

        // turningronce
        world.objects.AddRange(presetList.First(p => p.name == "turningronce")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "turningronce")
        }));

        // Quartz Roc
        world.objects.AddRange(presetList.First(p => p.name == "Quartz Roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Quartz Roc")
        }));

        // Big Quartz
        world.objects.AddRange(presetList.First(p => p.name == "Big Quartz")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Big Quartz")
        }));

        // Roc b
        world.objects.AddRange(presetList.First(p => p.name == "Roc b")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Roc b")
        }));

        // UpsideDownRoc
        world.objects.AddRange(presetList.First(p => p.name == "UpsideDownRoc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "UpsideDownRoc")
        }));

        // pillar1
        world.objects.AddRange(presetList.First(p => p.name == "pillar1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar1")
        }));

        // pillar2
        world.objects.AddRange(presetList.First(p => p.name == "pillar2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar2")
        }));

        // pillar3
        world.objects.AddRange(presetList.First(p => p.name == "pillar3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar3")
        }));

        // pillar4
        world.objects.AddRange(presetList.First(p => p.name == "pillar4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar4")
        }));

        // pillar5
        world.objects.AddRange(presetList.First(p => p.name == "pillar5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar5")
        }));

        // pillar6
        world.objects.AddRange(presetList.First(p => p.name == "pillar6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pillar6")
        }));

        // Big volcano roc
        world.objects.AddRange(presetList.First(p => p.name == "Big volcano roc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Big volcano roc")
        }));

        // Big volcano roc2
        world.objects.AddRange(presetList.First(p => p.name == "Big volcano roc2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Big volcano roc2")
        }));

        // BigVolcanoRocNew1
        world.objects.AddRange(presetList.First(p => p.name == "BigVolcanoRocNew1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "BigVolcanoRocNew1")
        }));

        // BigVolcanoRocNew2
        world.objects.AddRange(presetList.First(p => p.name == "BigVolcanoRocNew2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "BigVolcanoRocNew2")
        }));

        // Bamboo shroom
        world.objects.AddRange(presetList.First(p => p.name == "Bamboo shroom")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Bamboo shroom")
        }));

        // roc shroom
        world.objects.AddRange(presetList.First(p => p.name == "roc shroom")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "roc shroom")
        }));

        // Dood shroom
        world.objects.AddRange(presetList.First(p => p.name == "Dood shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Dood shroom")
        }));

        // Tiny shroom
        world.objects.AddRange(presetList.First(p => p.name == "Tiny shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tiny shroom")
        }));

        // palm shroom
        world.objects.AddRange(presetList.First(p => p.name == "palm shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "palm shroom")
        }));

        // regular shroom
        world.objects.AddRange(presetList.First(p => p.name == "regular shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "regular shroom")
        }));

        // small shroom
        world.objects.AddRange(presetList.First(p => p.name == "small shroom").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "small shroom")
        }));

        // pin1
        world.objects.AddRange(presetList.First(p => p.name == "pin1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pin1")
        }));

        // pin2
        world.objects.AddRange(presetList.First(p => p.name == "pin2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pin2")
        }));

        // pinbush
        world.objects.AddRange(presetList.First(p => p.name == "pinbush").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "pinbush")
        }));

        // Cocotier1
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier1")
        }));

        // Cocotier1Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier1Mirrored").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier1Mirrored")
        }));

        // Cocotier2
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier2")
        }));

        // Cocotier3
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier3")
        }));

        // Cocotier3Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier3Mirrored")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier3Mirrored")
        }));

        // Bamboo
        world.objects.AddRange(presetList.First(p => p.name == "Bamboo").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Bamboo")
        }));

        // Bamboo 2
        world.objects.AddRange(presetList.First(p => p.name == "Bamboo 2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Bamboo 2")
        }));

        // longbush
        world.objects.AddRange(presetList.First(p => p.name == "longbush").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "longbush")
        }));

        // double_leaf
        world.objects.AddRange(presetList.First(p => p.name == "double_leaf").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "double_leaf")
        }));

        // moonplant
        world.objects.AddRange(presetList.First(p => p.name == "moonplant").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "moonplant")
        }));

        // earthplant
        world.objects.AddRange(presetList.First(p => p.name == "earthplant").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "earthplant")
        }));

        // Cascade
        world.objects.AddRange(presetList.First(p => p.name == "Cascade").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cascade")
        }));

        // cgrass
        world.objects.AddRange(presetList.First(p => p.name == "cgrass").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "cgrass")
        }));

        // Grass1N
        world.objects.AddRange(presetList.First(p => p.name == "Grass1N")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Grass1N")
        }));

        // Volcano spike
        world.objects.AddRange(presetList.First(p => p.name == "Volcano spike")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Volcano spike")
        }));

        // greententacle1
        world.objects.AddRange(presetList.First(p => p.name == "greententacle1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle1")
        }));

        // greententacle2
        world.objects.AddRange(presetList.First(p => p.name == "greententacle2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle2")
        }));

        // greententacle3
        world.objects.AddRange(presetList.First(p => p.name == "greententacle3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle3")
        }));

        // greententacle4
        world.objects.AddRange(presetList.First(p => p.name == "greententacle4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle4")
        }));

        // greententacle5
        world.objects.AddRange(presetList.First(p => p.name == "greententacle5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle5")
        }));

        // greententacle6
        world.objects.AddRange(presetList.First(p => p.name == "greententacle6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle6")
        }));

        // greententacle7
        world.objects.AddRange(presetList.First(p => p.name == "greententacle7")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "greententacle7")
        }));

        // mirrorgreententacle1
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle1")
        }));

        // mirrorgreententacle2
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle2")
        }));

        // mirrorgreententacle3
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle3")
        }));

        // mirrorgreententacle4
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle4")
        }));

        // mirrorgreententacle5
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle5")
        }));

        // mirrorgreententacle6
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle6")
        }));

        // mirrorgreententacle7
        world.objects.AddRange(presetList.First(p => p.name == "mirrorgreententacle7")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorgreententacle7")
        }));

        // platebande1
        world.objects.AddRange(presetList.First(p => p.name == "platebande1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "platebande1")
        }));

        // platebande2
        world.objects.AddRange(presetList.First(p => p.name == "platebande2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "platebande2")
        }));

        // mirrorplatebande1
        world.objects.AddRange(presetList.First(p => p.name == "mirrorplatebande1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorplatebande1")
        }));

        // mirrorplatebande2
        world.objects.AddRange(presetList.First(p => p.name == "mirrorplatebande2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "mirrorplatebande2")
        }));

        // patch1
        world.objects.AddRange(presetList.First(p => p.name == "patch1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "patch1")
        }));

        // Treebush
        world.objects.AddRange(presetList.First(p => p.name == "Treebush").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Treebush")
        }));

        // Jungle plant 1
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Jungle plant 1")
        }));

        // Jungle plant 1 Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 1 Mirrored")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
            "Jungle plant 1 Mirrored\"")
        }));

        // Jungle plant 2
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Jungle plant 2")
        }));

        // Jungle plant 5
        world.objects.AddRange(presetList.First(p => p.name == "Jungle plant 5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Jungle plant 5")
        }));

        // Fleur
        world.objects.AddRange(presetList.First(p => p.name == "Fleur").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Fleur")
        }));

        // Cocotier avec liane
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier avec liane")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Cocotier avec liane")
        }));

        // Cocotier avec liane Mirrored
        world.objects.AddRange(presetList.First(p => p.name == "Cocotier avec liane Mirrored")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
                                                                        "Cocotier avec liane Mirrored")
        }));

        // groundvine1
        world.objects.AddRange(presetList.First(p => p.name == "groundvine1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine1")
        }));

        // groundvine2
        world.objects.AddRange(presetList.First(p => p.name == "groundvine2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine2")
        }));

        // groundvine3
        world.objects.AddRange(presetList.First(p => p.name == "groundvine3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine3")
        }));

        // groundvine4
        world.objects.AddRange(presetList.First(p => p.name == "groundvine4").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine4")
        }));

        // groundvine5
        world.objects.AddRange(presetList.First(p => p.name == "groundvine5").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine5")
        }));

        // groundvine6
        world.objects.AddRange(presetList.First(p => p.name == "groundvine6").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "groundvine6")
        }));

        // Tree2
        world.objects.AddRange(presetList.First(p => p.name == "Tree2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tree2")
        }));

        // Tree1
        world.objects.AddRange(presetList.First(p => p.name == "Tree1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Tree1")
        }));

        // savana bush
        world.objects.AddRange(presetList.First(p => p.name == "savana bush")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "savana bush")
        }));

        // Roc avec mousse
        world.objects.AddRange(presetList.First(p => p.name == "Roc avec mousse")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Roc avec mousse")
        }));

        // tuft1
        world.objects.AddRange(presetList.First(p => p.name == "tuft1").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft1")
        }));

        // tuft2
        world.objects.AddRange(presetList.First(p => p.name == "tuft2").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft2")
        }));

        // tuft3
        world.objects.AddRange(presetList.First(p => p.name == "tuft3").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft3")
        }));

        // tuft4
        world.objects.AddRange(presetList.First(p => p.name == "tuft4").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft4")
        }));

        // tuft5
        world.objects.AddRange(presetList.First(p => p.name == "tuft5").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "tuft5")
        }));

        // Eggplant
        world.objects.AddRange(presetList.First(p => p.name == "Eggplant").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Eggplant")
        }));

        // Corail
        world.objects.AddRange(presetList.First(p => p.name == "Corail").MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Corail")
        }));

        // plastic bottle
        world.objects.AddRange(presetList.First(p => p.name == "plastic bottle")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
                                                                                "plastic bottle")
        }));

        // spike volcan
        world.objects.AddRange(presetList.First(p => p.name == "Volcano spike")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
                                                                                "Volcano spike")
        }));

        // Trash
        world.objects.AddRange(presetList.First(p => p.name == "Trash")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Trash")
        }));

        // Plastic bag
        world.objects.AddRange(presetList.First(p => p.name == "Plastic bag")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Plastic bag")
        }));

        // egg1
        world.objects.AddRange(presetList.First(p => p.name == "egg1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg1")
        }));

        // egg2
        world.objects.AddRange(presetList.First(p => p.name == "egg2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg2")
        }));

        // egg3
        world.objects.AddRange(presetList.First(p => p.name == "egg3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg3")
        }));

        // egg4
        world.objects.AddRange(presetList.First(p => p.name == "egg4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg4")
        }));

        // egg5
        world.objects.AddRange(presetList.First(p => p.name == "egg5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg5")
        }));

        // egg6
        world.objects.AddRange(presetList.First(p => p.name == "egg6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "egg6")
        }));

        // Aquaroc
        world.objects.AddRange(presetList.First(p => p.name == "Aquaroc")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Aquaroc")
        }));

        // Aquapillar
        world.objects.AddRange(presetList.First(p => p.name == "Aquapillar")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Aquapillar")
        }));

        // gros corail
        world.objects.AddRange(presetList.First(p => p.name == "gros corail")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "gros corail")
        }));

        // seashell1
        world.objects.AddRange(presetList.First(p => p.name == "seashell1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "seashell1")
        }));

        // seashell2
        world.objects.AddRange(presetList.First(p => p.name == "seashell2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "seashell2")
        }));

        // Double coconut bush
        world.objects.AddRange(presetList.First(p => p.name == "Double coconut bush")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)),
            "Double coconut bush")
        }));

        // volcan
        world.objects.AddRange(presetList.First(p => p.name == "volcan")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
            Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "volcan")
        }));

        // fleur geante 1
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 1")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 1")
        }));

        // fleur geante 2
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 2")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 2")
        }));

        // fleur geante 3
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 3")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 3")
        }));

        // fleur geante 4
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 4")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 4")
        }));

        // fleur geante 5
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 5")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 5")
        }));

        // fleur geante 6
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 6")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 6")
        }));

        // fleur geante 7
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 7")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 7")
        }));

        // fleur geante 8
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 8")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 8")
        }));

        // fleur geante 9
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 9")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 9")
        }));

        // fleur geante 10
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 10")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 10")
        }));

        // fleur geante 11
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 11")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 11")
        }));

        // fleur geante 12
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 12")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 12")
        }));

        // fleur geante 13
        world.objects.AddRange(presetList.First(p => p.name == "fleur geante 13")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "fleur geante 13")
        }));

        // water falling
        world.objects.AddRange(presetList.First(p => p.name == "water falling")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
                Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "water falling")
        }));

        // Devcat
        world.objects.AddRange(presetList.First(p => p.name == "Devcat")
            .MakeWOs(new List<Tuple<Vector2, string>>()
        {
Tuple.Create(new Vector2(Game1.rand.Next(-1000, 11000),Game1.rand.Next(-1000, 11000)), "Devcat")
        }));




        System.Diagnostics.Debug.WriteLine("[i] NewWorldGen - Generating buildpoints - end");

        //// World definition END

    }

  }
}

