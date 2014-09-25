using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StarSystems.Utils
{
    class MoveSentarPlanets
    {
        public static void MoveToKerbol()
        {
            Debug.Log("Moving Sentar planets to Dolas...");
            foreach (var OriginalPlanet in StarSystem.SentarPlanets)
            {
                foreach (var PlanetCB in StarSystem.CBDict.Values)
                {
                    if (PlanetCB.name == OriginalPlanet)
                    {
                        PlanetCB.orbitDriver.referenceBody = StarSystem.CBDict["Dolas"];
                        StarSystem.CBDict["Sun"].orbitingBodies.Remove(PlanetCB);
                        StarSystem.CBDict["Dolas"].orbitingBodies.Add(PlanetCB);
                        PlanetCB.orbitDriver.UpdateOrbit();

                        break;
                    }
                }
            }
            StarSystem.CBDict["Dolas"].CBUpdate();
            StarSystem.CBDict["Sun"].CBUpdate();

            StarSystem.Initialized = true;

            Debug.Log("Sentar planets moved to Dolas.");
        }

        public static void MoveToSun()
        {
            Debug.Log("Moving Sentar planets to Sun...");
            //Add all standard planets to Kerbol
            foreach (var OriginalPlanet in StarSystem.StandardPlanets)
            {
                foreach (var PlanetCB in StarSystem.CBDict.Values)
                {
                    if (PlanetCB.name == OriginalPlanet)
                    {
                        PlanetCB.orbitDriver.referenceBody = StarSystem.CBDict["Sun"];
                        StarSystem.CBDict["Dolas"].orbitingBodies.Remove(PlanetCB);
                        StarSystem.CBDict["Sun"].orbitingBodies.Add(PlanetCB);
                        PlanetCB.orbitDriver.UpdateOrbit();

                        break;
                    }
                }
            }
            StarSystem.CBDict["Kerbol"].CBUpdate();
            StarSystem.CBDict["Sun"].CBUpdate();

            StarSystem.Initialized = false;

            Debug.Log("Standard planets moved to Sun");
        }
    }
