using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    Vector2 targetOffset;
    [SerializeField]
    Transform playerTransform;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(playerTransform.position.x + targetOffset.x, playerTransform.position.y + targetOffset.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        
        Vector3 targetPosition = new Vector3(playerTransform.position.x + targetOffset.x, playerTransform.position.y + targetOffset.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
