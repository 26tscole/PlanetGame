using UnityEngine;

public class CoinSpawning : MonoBehaviour
{
    public SolarSystemBehavior solarSystemBehavior;
    [Header("Coin Settings")]
    public GameObject coinObject;
    Vector3 position;
    public string coinType = "";
    public float coinRotationSpeedMax = 50f;
    public float coinRotationSpeedMin = 10f;
    public float coinMaxSize = 30f;
    public float coinMinSize = 10f;
    public int coinAmount = 1;
    public float coinValue = 1f;
    public float[] coinModifiers = { 0f };

    private float sunMagnitude;
    private float solarSystemMagnitude;

    private void OnEnable()
    {
        solarSystemBehavior.Finished += StartSpawning;
    }

    private void OnDisable()
    {
        solarSystemBehavior.Finished -= StartSpawning;
    }

    void StartSpawning()
    {
        sunMagnitude = solarSystemBehavior.sunMagnitude;
        solarSystemMagnitude = solarSystemBehavior.solarSystemMagnitude;
        Debug.Log("solarSystemMagnitude: " + solarSystemMagnitude);
        createCoins();
    }

    private void createCoins()
    {

        for( int i = 0; i<coinAmount; i++)
        {
            float xPosition = Random.Range(sunMagnitude, solarSystemMagnitude);
            position = new Vector3(xPosition,0,0);
            Instantiate(coinObject, position, Quaternion.identity);
            Coin coinScript = coinObject.GetComponent<Coin>();
            float rotationSpeed = Random.Range(coinRotationSpeedMin, coinRotationSpeedMax);
            rotationSpeed *= Random.value < 0.5f ? -1 : 1;
            float coinSize = Random.Range(coinMinSize, coinMaxSize);
            coinScript.rotationSpeed = rotationSpeed;
            coinScript.coinValue = coinValue;
            coinScript.coinModifiers = coinModifiers;
            coinScript.coinSize = coinSize;
            if (coinType == "")
            {
                coinType = "Coin";
            }
            coinScript.coinName = coinType + "_" + i;
        }
    }

}
