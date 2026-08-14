using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerContact : MonoBehaviour
{
    public float playerHealth = 100f;
    public float damageMultiplier = .5f;
    public float coinsToWin = 10f;
    private float objectDamage;
    private float playerWealth= 0f;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.CompareTag("Planet"))
        {
            Debug.Log("Player has collided with a planet");
            objectDamage = collidedObject.GetComponent<Transform>().localScale.x * damageMultiplier;
            damagePlayer(objectDamage, "Planet");
        }
        else if (collidedObject.CompareTag("Moon"))
        {
            Debug.Log("Player has collided with a moon");
            objectDamage = collidedObject.GetComponent<Transform>().localScale.x * damageMultiplier;
            damagePlayer(objectDamage, "Moon");
        }
        else if (collidedObject.CompareTag("Sun"))
        {
            Debug.Log("Player has collided with the sun");
            Debug.Log("Heat Death");
            damagePlayer(playerHealth, "Sun");
        }
        else if (collidedObject.CompareTag("Coin"))
        {
            // add a way to keep track of coins collected
            Coin coin = collidedObject.GetComponent<Coin>();
            Debug.Log("Player has collided with a coin");
            coinCollection(coin.coinValue); 
        }
    }

    private void damagePlayer(float damage, string damageType)
    {
        playerHealth -= damage;
        Debug.Log("Player took " + damage + " damage from " + damageType + ". Remaining health: " + playerHealth);
        if (playerHealth <= 0)
        {
            Debug.Log("Player has died");
            SceneManager.LoadScene(0);
        }
    }

    private void coinCollection(float coinValue)
    {
        playerWealth += coinValue;
        Debug.Log("Player has collected a coin worth " + coinValue + ". Total wealth: " + playerWealth);
        if (playerWealth >= coinsToWin) 
        {
            Debug.Log("Player has won the game!");
            SceneManager.LoadScene(0);
        }
    }

}
