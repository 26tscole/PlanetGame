using UnityEngine;

public class CoinSpawning : MonoBehaviour
{
    [Header("Coin Settings")]
    public GameObject coin;
    public float coinRotationSpeed = 50f;
    public int coinAmount = 1;
    public float coinValue = 1f;
    public float[] coinModifiers = { 0f };

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createCoins()
    {
        for( int i = 0; i<coinAmount; i++)
        {
            
        }
    }

}
