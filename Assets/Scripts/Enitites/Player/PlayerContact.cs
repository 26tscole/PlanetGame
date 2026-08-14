using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerContact : MonoBehaviour
{
    public float playerHealth = 100f;
    public float damageMultiplier = 1f;
    private float objectDamage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            Debug.Log("Player has collided with a planet");
            objectDamage = collision.gameObject.GetComponent<Transform>().localScale.x * damageMultiplier;
            damagePlayer(objectDamage, "Planet");
        }
        else if (collision.gameObject.CompareTag("Moon"))
        {
            Debug.Log("Player has collided with a moon");
            objectDamage = collision.gameObject.GetComponent<Transform>().localScale.x * damageMultiplier;
            damagePlayer(objectDamage, "Moon");
        }
        else if (collision.gameObject.CompareTag("Sun"))
        {
            Debug.Log("Player has collided with the sun");
            Debug.Log("Heat Death");
            damagePlayer(playerHealth, "Sun");
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            // add a way to keep track of coins collected
            Debug.Log("Player has collided with a coin");
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

}
