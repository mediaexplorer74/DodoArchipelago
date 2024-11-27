
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

namespace DodoTheGame
{
  internal static class WorldGenerator
  {
    public static void GenerateWorld(World @world, List<Preset> presetList)
    {
            // ISSUE: unable to decompile the method.

             world = new World()
            {
                name = "mainWorld",//(string)objArray[21],
                Level = 1, //(int)objArray[22],
                objects = new List<IWorldObject>() 
                { 
                    Capacity = 1000,
                    //Preset = presetList
                },
                NPCs = default,
            };
        }
  }
}
