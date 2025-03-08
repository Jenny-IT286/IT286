using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{   
    public float moveSpeed = 1f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput;
        float verticalInput;

        //This Style adds an immediate Stop, feels good
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) )
        {
            //Debug.Log("up was pressed.");
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        }
    }
}
