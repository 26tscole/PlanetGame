using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    private Collider col;

    void Start()
    {
        col = playerTransform.GetComponent<Collider>();
        float playerHeight = col.bounds.size.y;
        transform.position = new Vector3(playerTransform.position.x, playerHeight + 5f, playerTransform.position.z - 30f);
    }

    void LateUpdate()
    {
        float playerHeight = col.bounds.size.y;
        transform.position = new Vector3(playerTransform.position.x, playerHeight + 5f, playerTransform.position.z - 30f);
    }
}
