using UnityEngine;
using System.Collections.Generic;

public class SolarSystemBehavior : MonoBehaviour
{
    [SerializeField] private Dictionary<GameObject, float[]>planetSystems = new Dictionary<GameObject, float[]>();
    [SerializeField] private GameObject sun;
    [SerializeField] private GameObject player;
    [SerializeField] private float solarSystemScale = 30f;
    public event System.Action Finished;
    public float solarSystemMagnitude;
    public float sunMagnitude;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        findPlanetSystems();
        alignPlanets();
        setPlayerPosition();
        Finished?.Invoke();
    }

    // universally returns planets in solar system and sets their rotation speed, distance from the sun, and size
    private void findPlanetSystems()
    {
        // just in case there are no planets
        if (!(planetSystems == null || planetSystems.Count == 0))
        {
            Debug.Log("There are no planet systems in this solar system");
            return;
        }

        // this is so the planets dont touch the sun no matter what size the sun is
        float sunScale = solarSystemScale * Random.Range(1.5f, 3f);
        float distanceFromLastPlanet = 2f * sunScale;
        float planetScale;

        foreach (Transform planet in transform)
        {
            if (planet.name == "Sun")
            {
                sun = planet.gameObject;
                sun.transform.localScale = new Vector3(sunScale, sunScale, sunScale);
                sun.tag = "Sun";
                sunMagnitude = sun.transform.localScale.magnitude;
            }
            else
            {
                float rotationSpeed = Random.Range(10f,50f); 
                planetScale = solarSystemScale * Random.Range(0.2f, 1.5f);
                distanceFromLastPlanet += Random.Range(50f, 90f) + (2 * planetScale);
                
                planetSystems[planet.gameObject] = new float[] { planetScale, distanceFromLastPlanet, rotationSpeed }; 
                Debug.Log("Planet is " + planet.name + " with scale " + planetScale + ", distance from sun " + distanceFromLastPlanet + ", and rotation speed " + rotationSpeed);
            }
        }
        solarSystemMagnitude = sunScale + distanceFromLastPlanet;
    }

    private void alignPlanets()
    {  
        foreach (KeyValuePair<GameObject, float[]> systems in planetSystems)
        {
            GameObject systemObject = systems.Key;
            GameObject planet = systemObject.transform.GetChild(0).gameObject;
            GameObject moon = systemObject.transform.GetChild(1).gameObject;

            float[] planetProperties = systems.Value;
            planet.tag = "Planet";
            float planetScale = planetProperties[0];
            float distanceFromSun = planetProperties[1];
            float rotationSpeed = planetProperties[2];

            planet.transform.localScale = new Vector3(planetScale, planetScale, planetScale);
            planet.transform.position = new Vector3(distanceFromSun, 0, 0);
            addOrbitToObject(planet, sun, rotationSpeed);

            applyMoonsStats(moon, planet, rotationSpeed, planetScale);
            
        }
    }

    private void applyMoonsStats(GameObject Moons, GameObject Planet, float rotationSpeed, float planetScale)
    {
        float moonScale = planetScale * Random.Range(0.1f, 0.5f);
        float moonDistance = planetScale * Random.Range(1.5f, 2f);
        float moonRotationSpeed = rotationSpeed * Random.Range(1.5f, 3f);

        foreach (Transform moon in Moons.transform)
        {
            moon.transform.localScale = new Vector3(moonScale, moonScale, moonScale);
            moon.transform.position = new Vector3(moonDistance, 0, 0);
            moon.tag = "Moon";
            addOrbitToObject(moon.gameObject, Planet, moonRotationSpeed);
            moonDistance /= 2f;
        }
    }

    private void addOrbitToObject(GameObject planet, GameObject primaryBody,  float rotationSpeed)
    {
        int orbitDirection = Random.value < 0.5f ? -1 : 1;
        rotationSpeed *= orbitDirection;
        Orbit orbit = planet.AddComponent<Orbit>();
        orbit.primaryBody = primaryBody;
        orbit.rotationSpeed = rotationSpeed;
    }

    private void setPlayerPosition()
    {
        float sunRadius = solarSystemScale + sun.transform.localScale.magnitude;
        player.transform.position = new Vector3(0, sunRadius, 0);
        player.transform.LookAt(sun.transform.position);
    }

}
