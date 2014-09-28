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
            Debug.Log("Moving KU2 planets to Binny.");
            foreach (var OriginalPlanet in StarSystem.KrallPlanets)
            {
                foreach (var PlanetCB in StarSystem.CBDict.Values)
                {
                    if (PlanetCB.name == OriginalPlanet)
                    {
                        PlanetCB.orbitDriver.referenceBody = StarSystem.CBDict["Binny"];
                        StarSystem.CBDict["Sun"].orbitingBodies.Remove(PlanetCB);
                        StarSystem.CBDict["Krall"].orbitingBodies.Add(PlanetCB);
                        PlanetCB.orbitDriver.UpdateOrbit();

                        break;
                    }
                }
            }
            StarSystem.CBDict["Binny"].CBUpdate();
            StarSystem.CBDict["Sun"].CBUpdate();

            StarSystem.Initialized = true;

            Debug.Log("KU2 planets moved to Binny.");
        }

        public static void MoveToSun()
        {
            Debug.Log("Moving KU2 planets to Sun....");
            //Add all standard planets to Kerbol
            foreach (var OriginalPlanet in StarSystem.BinnyPlanets)
            {
                foreach (var PlanetCB in StarSystem.CBDict.Values)
                {
                    if (PlanetCB.name == OriginalPlanet)
                    {
                        PlanetCB.orbitDriver.referenceBody = StarSystem.CBDict["Sun"];
                        StarSystem.CBDict["Binny"].orbitingBodies.Remove(PlanetCB);
                        StarSystem.CBDict["Sun"].orbitingBodies.Add(PlanetCB);
                        PlanetCB.orbitDriver.UpdateOrbit();

                        break;
                    }
                }
            }
            StarSystem.CBDict["Binny"].CBUpdate();
            StarSystem.CBDict["Sun"].CBUpdate();

            StarSystem.Initialized = false;

            Debug.Log("KU2 planets moved to Sun");
        }
    }
