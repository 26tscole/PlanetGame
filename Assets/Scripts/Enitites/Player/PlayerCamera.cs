using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public Transform playerTransform;
    private Vector3 lastPlayerPosition;

    void Start()
    {
        lastPlayerPosition = playerTransform.position;
        transform.position = new Vector3(lastPlayerPosition.x, lastPlayerPosition.y + 20f, lastPlayerPosition.z - 30f);
    }

    void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, lastPlayerPosition.y + 20f, playerTransform.position.z - 30f);
        lastPlayerPosition = playerTransform.position;
    }
}
