﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BounceAngle
{
    class MapManagerIMP : MapManager
    {


        private static int buildingCounter = 0;

        List<BuildingIMP> buildings;
        Vector2 offset;
        Texture2D backgroundTile;
        Texture2D[] roadTiles;
        private int safehouseId;

        public MapManagerIMP()
        {
            buildings = new List<BuildingIMP>();
            offset = Vector2.Zero;
            safehouseId = -1;
        }

        public void addBuilding(BuildingIMP building)
        {
            buildings.Add(building);
            if (building.getBuildingData().isSafehouse())
            {
                safehouseId = building.getBuildingData().getID();
            }
        }

        public void LoadMap(ContentManager Content)
        {
            backgroundTile = Content.Load<Texture2D>("Images//tile");
            roadTiles = new Texture2D[3];
            roadTiles[0] = Content.Load<Texture2D>("Images//roadTile");
            roadTiles[1] = Content.Load<Texture2D>("Images//intersectionTile");
            roadTiles[2] = Content.Load<Texture2D>("Images//roadTileNS");
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(975, 275), false, Content.Load<Texture2D>("Images//factory0"), 0, 2, 0, "ACME Industrial", 0, 6, false, new Vector2(1.1f, 0.5f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(-980, 200), false, Content.Load<Texture2D>("Images//hospital0"), 2, 1, 0, "Special H Hospital", 0, 8, false, new Vector2(0.5f, 1.1f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(360, 340), false, Content.Load<Texture2D>("Images//mainStreet0"), 5, 0, 0, "Main Street Strip Mall", 0, 4, false, new Vector2(0.5f, 1.1f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(75, 600), false, Content.Load<Texture2D>("Images//apartments0"), 2, 2, 0, "Mega Block Apartments", 0, 10, false, new Vector2(0.5f, 1.1f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(-400, 800), false, Content.Load<Texture2D>("Images//church0"), 0, 0, 0, "Church of the Flying Spagetti Monster", 0, 2, false, new Vector2(0.5f, 1.1f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(-300, 600), false, Content.Load<Texture2D>("Images//groceryStore0"), 2, 0, 0, "Grey Matter Grocery Store", 0, 3, false, new Vector2(0.5f, -0.1f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(725, 600), false, Content.Load<Texture2D>("Images//warehouse0"), 3, 0, 0, "Warehouse 52", 0, 4, false, new Vector2(-0.1f, 0.5f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(-600, 600), false, Content.Load<Texture2D>("Images//arena0"), 10, 1, 0, "Air Canada Center", 0, 7, false, new Vector2(0.5f, -0.1f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(-275, 0), false, Content.Load<Texture2D>("Images//apartments3"), 0, 1, 0, "Dirty End Motel", 0, 5, false, new Vector2(0.5f, 1.1f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(-610, 330), false, Content.Load<Texture2D>("Images//apartments1"), 7, 2, 0, "Dark Night Co-op", 0, 4, false, new Vector2(-0.1f, 0.5f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(725, 275), true, Content.Load<Texture2D>("Images//office0"), 0, 0, 0, "Safe House", 0, 2, false, new Vector2(0.5f, 1))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(75, 350), false, Content.Load<Texture2D>("Images//lawsociety0"), 10, 0, 0, "Creaky Court House", 0, 7, false, new Vector2(0.5f, 1.1f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(-350, 600), false, Content.Load<Texture2D>("Images//warehouse1"), 0, 0, 0, "Silent Storage", 0, 2, false, new Vector2(0.5f, -0.1f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(1400, 600), false, Content.Load<Texture2D>("Images//warehouse1"), 0, 0, 0, "El Cheapo's Discount Lingerie", 0, 2, false, new Vector2(0.5f, -0.1f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(1200, 600), false, Content.Load<Texture2D>("Images//warehouse1"), 0, 0, 0, "El Cheapo's Discount Swimware", 1, 2, false, new Vector2(0.5f, -0.1f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(-1225, 600), false, Content.Load<Texture2D>("Images//stadium0"), 4, 2, 0, "Black & Blue Stadium", 0, 4, false, new Vector2(0.5f, -0.1f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(1150, 800), false, Content.Load<Texture2D>("Images//church1"), 0, 1, 0, "Redeption Church", 0, 1, false, new Vector2(0.5f, 1.1f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(450, 0), false, Content.Load<Texture2D>("Images//hotel0"), 2, 2, 0, "Carlin Hotel", 0, 3, false, new Vector2(1.1f, 0.5f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(60,-100), false, Content.Load<Texture2D>("Images//apartments2"), 5, 0, 0, "FunTimes Rental Suits", 0, 4, false, new Vector2(-0.1f, 0.5f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(60, 1025), false, Content.Load<Texture2D>("Images//factory1"), 0, 0, 0, "Rusty Rivet Mill", 0, 5, false, new Vector2(-0.1f, 0.5f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(1400, 1025), false, Content.Load<Texture2D>("Images//fare1"), 0, 3, 0, "Hell on Wheels Farground", 1, 5, false, new Vector2(-0.1f, 0.5f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(1400, 50), false, Content.Load<Texture2D>("Images//library1"), 1, 0, 0, "Bibliotheque Library", 0, 5, false, new Vector2(-0.1f, 0.5f))));
            addBuilding(new BuildingIMP(new BuildingDataIMP(buildingCounter++, new Vector2(1600, 300), false, Content.Load<Texture2D>("Images//school0"), 0, 1, 0, "Humger School of Lithography", 1, 5, false, new Vector2(0.5f, 1.1f))));
            
            
            //addRoads();
            
        }

        public List<Building> getAllBuildings()
        {
            List<Building> aList = new List<Building>();
            foreach (BuildingIMP building in buildings) {
                aList.Add(building);
            }
            return aList;
        }

        public Building getBuildingByID(int id)
        {

            foreach (BuildingIMP building in buildings)
            {
                if (building.getBuildingData().getID() == id)
                {
                    return building;
                }
            }
            return null;
        }

        public void setScreenWorldOffset(Vector2 _offset)
        {
            offset = _offset;
        }

        public Vector2 getScreenWorldOffset()
        {
            return offset;
        }

        public int getScreenCollision(Vector2 coord)
        {
            return getWorldCollision(coord - getScreenWorldOffset());
        }

        public int getWorldCollision(Vector2 coord)
        {
            for (int i = 0; i < buildings.Count; i++)
            {
                Vector2 location = buildings[i].getBuildingData().getLocation();
                Rectangle hitRect = new Rectangle((int)location.X, (int)location.Y, buildings[i].getBuildingData().getTexture().Width, buildings[i].getBuildingData().getTexture().Height);

                if (hitRect.Contains(new Point((int)coord.X, (int)coord.Y)))
                {
                    //Console.WriteLine("hit"+i);

                    return i;

                }
            }
            return -1;
        }

        public int getSafehouseBuildingId()
        {
            return safehouseId;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = -1; i * 60 < 1340; i++)
            {
                for (int j = -1; j * 60 < 780; j++)
                {
                    spriteBatch.Draw(backgroundTile, new Vector2(i * 60 + (offset.X % 60), j * 60 + (offset.Y % 60)), Color.White);
                }
            }
            drawRoads(spriteBatch);
            foreach (BuildingIMP building in buildings)
            {
                building.Draw(spriteBatch, offset);
            }
        }

        private void drawRoads(SpriteBatch spriteBatch)
        {
            for (int i = -24; i < 38; i++)
            {
                if (i % 11 == 0)
                {

                    for (int j = -14; j < 16; j++)
                    {
                        if (j == 0 || (j == 7 && i > -11 && i < 22))
                        {
                            for (int k = -10; k < 20; k++)
                            {
                                if (!(k % 11 == 0))
                                    spriteBatch.Draw(roadTiles[0], new Vector2(60 * k + offset.X, 540 + 60 * j + (offset.Y)), Color.White);
                            }
                            spriteBatch.Draw(roadTiles[1], new Vector2(60 * i + offset.X, 540 + 60 * j + (offset.Y)), Color.White);

                        }
                        else
                            spriteBatch.Draw(roadTiles[2], new Vector2(60 * i + offset.X, 540 + 60 * j + (offset.Y)), Color.White);
                    }
                    spriteBatch.Draw(roadTiles[1], new Vector2(60 * i + offset.X, 540 + (offset.Y)), Color.White);
                }
                else
                {
                    spriteBatch.Draw(roadTiles[0], new Vector2(60 * i + offset.X, 540 + (offset.Y)), Color.White);
                }
            }
        }

    }
}
