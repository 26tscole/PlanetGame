using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [Header("Grappling Hook Settings")]
    public GameObject grapplingObject; 
    private GameObject grappledObject;
    private Vector3 grapplePoint;
    [SerializeField]private LineRenderer lineRenderer;
    [SerializeField] private float stiffness = 100f;
    [SerializeField] private float damping = 10f;
    private bool isGrappling = false;

    void Start()
    {
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            grabObjectToGrapple();

            if (grappledObject != null)
            {
                isGrappling = true;
                lineRenderer.SetPosition(0, grapplingObject.transform.position);
                lineRenderer.SetPosition(1, grappledObject.transform.position);
                grapplePoint = grappledObject.transform.position;

            }
        }

        if (Input.GetMouseButton(1))
        {
            isGrappling = false;
            grappledObject = null;
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        }

        if (isGrappling && grappledObject != null)
        {
            grapplePoint = grappledObject.transform.position;
            lineRenderer.SetPosition(0, grapplingObject.transform.position);
            lineRenderer.SetPosition(1, grappledObject.transform.position);
            springForce(grapplePoint);
        }
        
    }

    private void springForce(Vector3 targetPoint)
    {
        Vector3 displacement = targetPoint - transform.position;
        Vector3 springForce = stiffness * displacement;
        Vector3 dampingForce = -damping * GetComponent<Rigidbody>().linearVelocity;
        Vector3 totalForce = springForce + dampingForce;
        GetComponent<Rigidbody>().AddForce(totalForce);
    }

    private void grabObjectToGrapple()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            grappledObject = hit.collider.gameObject;
        }
    }
}
