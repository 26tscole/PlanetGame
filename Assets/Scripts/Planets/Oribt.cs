using UnityEngine;

public class Orbit : MonoBehaviour
{
    public GameObject primaryBody; // Reference to the object being orbited
    public float rotationSpeed = 20f;
    private Matrix4x4 rotationMatrix;
    private Quaternion rotationQuaternion;
    private Vector3 currentPosition;
    private Vector3 primaryBodyPosition;
    private Vector3 offset;
    private float angle = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        primaryBodyPosition = primaryBody.transform.position;
        currentPosition = transform.position;
        offset = currentPosition - primaryBodyPosition;
        rotationQuaternion = Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        angle += rotationSpeed * Time.deltaTime;
        rotationQuaternion = Quaternion.Euler(0, angle, 0);
        primaryBodyPosition = primaryBody.transform.position;
        rotationMatrix = Matrix4x4.Rotate(rotationQuaternion);
        currentPosition = rotationMatrix.MultiplyPoint3x4(offset);
        currentPosition += primaryBodyPosition;
        transform.position = currentPosition;
    }
}