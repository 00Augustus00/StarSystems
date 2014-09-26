using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StarSystems.Utils
{
    class MoveKrallPlanets
    {
        public static void MoveToChippo()
        {
            Debug.Log("Moving Hercules, Titan, and Hypatos to Krall.");
            foreach (var OriginalPlanet in StarSystem.KrallPlanets)
            {
                foreach (var PlanetCB in StarSystem.CBDict.Values)
                {
                    if (PlanetCB.name == OriginalPlanet)
                    {
                        PlanetCB.orbitDriver.referenceBody = StarSystem.CBDict["Krall"];
                        StarSystem.CBDict["Sun"].orbitingBodies.Remove(PlanetCB);
                        StarSystem.CBDict["Krall"].orbitingBodies.Add(PlanetCB);
                        PlanetCB.orbitDriver.UpdateOrbit();

                        break;
                    }
                }
            }
            StarSystem.CBDict["Krall"].CBUpdate();
            StarSystem.CBDict["Sun"].CBUpdate();

            StarSystem.Initialized = true;

            Debug.Log("Hercules, Titan, and Hypatos moved to Krall.");
        }

        public static void MoveToSun()
        {
            Debug.Log("Moving Hercules, Titan, and Hypatos to Sun....");
            //Add all standard planets to Kerbol
            foreach (var OriginalPlanet in StarSystem.ChippoPlanets)
            {
                foreach (var PlanetCB in StarSystem.CBDict.Values)
                {
                    if (PlanetCB.name == OriginalPlanet)
                    {
                        PlanetCB.orbitDriver.referenceBody = StarSystem.CBDict["Sun"];
                        StarSystem.CBDict["Krall"].orbitingBodies.Remove(PlanetCB);
                        StarSystem.CBDict["Sun"].orbitingBodies.Add(PlanetCB);
                        PlanetCB.orbitDriver.UpdateOrbit();

                        break;
                    }
                }
            }
            StarSystem.CBDict["Chippo"].CBUpdate();
            StarSystem.CBDict["Sun"].CBUpdate();

            StarSystem.Initialized = false;

            Debug.Log("Urania moved to Sun");
        }
    }
