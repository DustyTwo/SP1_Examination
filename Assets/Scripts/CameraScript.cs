using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    Vector2 targetOffset;
    [SerializeField]
    Transform playerTransform;
    
    public static CameraScript instance;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        
        ResetToPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        
        Vector3 targetPosition = new Vector3(playerTransform.position.x + targetOffset.x, playerTransform.position.y + targetOffset.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }

    public void ResetToPlayer()
    {
        transform.position = new Vector3(playerTransform.position.x + targetOffset.x, playerTransform.position.y + targetOffset.y, transform.position.z);
    }
}
