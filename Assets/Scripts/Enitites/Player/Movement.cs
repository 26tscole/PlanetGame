using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private Collider col;
    [SerializeField] private float upwardThusterForce = 10f;
    [SerializeField] private float sideThrusterForce = 1f;
    public void Start()
    {
        try
        {
            rb = GetComponent<Rigidbody>();
            col = GetComponent<Collider>();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Rigidbody or Collider component not found: " + e.Message);
        }
    }

    public void upwardThruster(float force)
    {
        rb.AddForce(transform.up * force);
    }

    public void forwardTilt(float force)
    { 
        rb.AddForceAtPosition(transform.forward * force, new Vector3(rb.position.x, col.bounds.size.y, rb.position.z));
    }

    public void backwardsTilt(float force)
    {
        rb.AddForceAtPosition(transform.forward * -force, new Vector3(rb.position.x, col.bounds.size.y, rb.position.z));
    }

   void Update()
    {
        // Triggers continuously while holding the key down
        if (Input.GetKey(KeyCode.Space)) upwardThruster(upwardThusterForce);
        if (Input.GetKey(KeyCode.W)) forwardTilt(sideThrusterForce);
        if (Input.GetKey(KeyCode.S)) backwardsTilt(sideThrusterForce);
        
    }
}