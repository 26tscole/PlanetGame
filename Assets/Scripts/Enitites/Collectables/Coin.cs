using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public string coinName = "Coin";
    public float rotationSpeed = 1f;
    public float spinSpeed = 1f;
    public float coinValue = 1f;
    public float[] coinModifiers = { 0f };
    public float coinSize = 30f;

    void Start()
    {
        transform.name = coinName;
        transform.localScale = new Vector3(coinSize, coinSize, coinSize);
        Orbit orbit = transform.AddComponent<Orbit>();
        orbit.primaryBody = GameObject.FindGameObjectWithTag("Sun");
        orbit.rotationSpeed = rotationSpeed;
        spinSpeed = Random.Range(10f, 50f);

    }

    void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has collected " + coinName + " worth " + coinValue + " with modifiers: " + string.Join(", ", coinModifiers));
            Destroy(gameObject);
        }
    }
}
