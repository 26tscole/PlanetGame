using UnityEngine;
using System.Collections.Generic;

public class SolarSystemBehavior : MonoBehaviour
{
    [SerializeField] private Dictionary<GameObject, float[]> planets = new Dictionary<GameObject, float[]>();
    [SerializeField] private GameObject sun;
    [SerializeField] private GameObject player;
    [SerializeField] private float solarSystemScale = 30f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        planets = findPlanets();
        setSunScale();
        alignPlanets();
        setPlayerPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // universally returns planets in solar system and sets their rotation speed, distance from the sun, and size
    private Dictionary<GameObject, float[]> findPlanets()
    {
        if (!(planets == null || planets.Count == 0))
        {
            return planets;
        }
        // this is so the planets dont touch the sun no matter what size the sun is
        float distanceFromLastPlanet = 50f + sun.GetComponent<SphereCollider>().bounds.extents.magnitude;
        float planetScale;
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject planet = transform.GetChild(i).gameObject;
            if (planet.name == "Sun")
            {
                sun = planet;
            }
            else
            {
                float rotationSpeed = Random.Range(10f,30f); 
                planetScale = solarSystemScale * Random.Range(0.2f, 1.5f);
                // this is so the planets dont touch each other no matter what size they are
                distanceFromLastPlanet += Random.Range(50f, 60f) + (2 * planetScale);
                planets[planet] = new float[] { planetScale, distanceFromLastPlanet, rotationSpeed }; 
                Debug.Log("Planet " + i + " is " + planet.name);
            }

        }
        return planets;
    }

    private void alignPlanets()
    {  
        foreach (KeyValuePair<GameObject, float[]> planet in planets)
        {
            GameObject planetObject = planet.Key;
            float[] planetProperties = planet.Value;
            float planetScale = planetProperties[0];
            float distanceFromSun = planetProperties[1];
            float rotationSpeed = planetProperties[2];

            planetObject.transform.localScale = new Vector3(planetScale, planetScale, planetScale);
            planetObject.transform.position = new Vector3(distanceFromSun, 0, 0);

            addOrbitToPlanet(planetObject, sun, rotationSpeed);
        }
        
    }

    private void setSunScale()
    {
        float sunScale = solarSystemScale * Random.Range(1.5f, 3f);
        sun.transform.localScale = new Vector3(sunScale, sunScale, sunScale);
    }

    private void addOrbitToPlanet(GameObject planet, GameObject primaryBody,  float rotationSpeed)
    {
        Orbit orbit = planet.AddComponent<Orbit>();
        orbit.primaryBody = primaryBody;
        orbit.rotationSpeed = rotationSpeed;
    }

    private void setPlayerPosition()
    {
        float sunRadius = sun.GetComponent<SphereCollider>().bounds.extents.magnitude;
        player.transform.position = new Vector3(sunRadius + 10f, 0, 0);
    }

}
