using UnityEngine;

public class TestCameraMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Transform target;
    


    public Vector3 offset = new Vector3(0,10,10);
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*float horizontalInput;
        float verticalInput;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) )
        {
            //Debug.Log("up was pressed.");
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);W
        }*/

    }

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
