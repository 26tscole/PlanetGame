using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private Collider col;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

    }

    public void upwardThruster(float force)
    {
       if (rb != null)
       {
           rb.AddForce(transform.up * force);
       }
    }

    public void forwardTilt(float force)
    {
        if (rb != null)
        {
            rb.AddForce(transform.forward * force);
        }
    }

    public void backwardsTilt(float force)
    {
        if (rb != null)
        {
            rb.AddForce(-transform.forward * force);
        }
    }

   void Update()
    {
        // Triggers continuously while holding the key down
        if (Input.GetKey(KeyCode.Space)) upwardThruster(1f);
        if (Input.GetKey(KeyCode.W)) forwardTilt(1f);
        if (Input.GetKey(KeyCode.S)) backwardsTilt(1f);
        
    }
}