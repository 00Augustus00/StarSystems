using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StarSystems.Utils
{
    class MoveCorboPlanets
    {
        public static void MoveToCorbo()
        {
            Debug.Log("Moving Corbo system to Corbo...");
            foreach (var OriginalPlanet in StarSystem.CorboPlanets)
            {
                foreach (var PlanetCB in StarSystem.CBDict.Values)
                {
                    if (PlanetCB.name == OriginalPlanet)
                    {
                        PlanetCB.orbitDriver.referenceBody = StarSystem.CBDict["Corbo"];
                        StarSystem.CBDict["Sun"].orbitingBodies.Remove(PlanetCB);
                        StarSystem.CBDict["Corbo"].orbitingBodies.Add(PlanetCB);
                        PlanetCB.orbitDriver.UpdateOrbit();

                        break;
                    }
                }
            }
            StarSystem.CBDict["Corbo"].CBUpdate();
            StarSystem.CBDict["Sun"].CBUpdate();

            StarSystem.Initialized = true;

            Debug.Log("Corbo planets moved to Corbo.");
        }

        public static void MoveToSun()
        {
            Debug.Log("Moving Corbo planets to Sun...");
            //Add all standard planets to Kerbol
            foreach (var OriginalPlanet in StarSystem.CorboPlanets)
            {
                foreach (var PlanetCB in StarSystem.CBDict.Values)
                {
                    if (PlanetCB.name == OriginalPlanet)
                    {
                        PlanetCB.orbitDriver.referenceBody = StarSystem.CBDict["Sun"];
                        StarSystem.CBDict["Corbo"].orbitingBodies.Remove(PlanetCB);
                        StarSystem.CBDict["Sun"].orbitingBodies.Add(PlanetCB);
                        PlanetCB.orbitDriver.UpdateOrbit();

                        break;
                    }
                }
            }
            StarSystem.CBDict["Corbo"].CBUpdate();
            StarSystem.CBDict["Sun"].CBUpdate();

            StarSystem.Initialized = false;

            Debug.Log("Corbo planets moved to Sun");
        }
    }
