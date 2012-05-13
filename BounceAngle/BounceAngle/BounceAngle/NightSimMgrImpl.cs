﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    class NightSimMgrImpl : NightSimMgr
    {
        private const int SPAWN_DELAY = 1000;
        private float spawnCounter;

        public void init()
        {
            spawnCounter = 0;
        }

        public void resetMode()
        {
            // 1. add all the survivors to the proper start locations from the DaySimMgr
        }

        public void update(GameTime gameTime)
        {
            // 1. handle spawning zombies
            // 2. handle end game state when all the suvivors are gone from the survivor manager
            //     - flip back into the day mode

            spawnCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (spawnCounter > SPAWN_DELAY)
            {
                NightGameEngineImp.getGameEngine().getZombieManager().addZombie(new ZombieDataImp(NightGameEngineImp.getGameEngine().getZombieManager().getZombieTextures()[0]));
                spawnCounter = 0;
            }


            if (0 == NightGameEngineImp.getGameEngine().getSurvivorManager().getAllSurvivors().Count)
            {
                NightGameEngineImp.getGameEngine().stop();
                DayGameEngineImp.getGameEngine().start();
            }
        }
    }
}