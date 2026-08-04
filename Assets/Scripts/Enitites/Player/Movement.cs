using UnityEngine;

public class Movement : MonoBehaviour
{

    public Transform playerShip;

    public Rigidbody rb;

    public float turnSpeed = 60f;
    public float boostSpeed = 45f;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }


    void FixedUpdate()
    {
        turn();
        thrust();
    }

    void turn()
    {
        // y axis movement
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        // x axis movement
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        // z axis movement
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Rotate");
        playerShip.Rotate(pitch, yaw, roll);
    }

    void thrust()
    {
        playerShip.position += playerShip.forward * boostSpeed * Time.deltaTime * Input.GetAxis("Throttle");
    }

}
