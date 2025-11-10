using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour
{
    public float HorizontalInput;
    public float forwardInput;
    public float speed = 10.0f;
    public float turnSpeed = 10.0f;
    public float xBound = 10.0f;
    public float mouseX = 0;
    public float mouseY = 0;
    public float turnSpeedY = 1.0f;
    public float yRotation = 0;
    public float xRotation = 0;
    public float maxY = 60;
    public GameObject cameraObj;
    public Rigidbody rb;
    public float jumpHeight = 10;
    public bool isGround = false;
    public float groundDistance = 1.001f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        HorizontalInput = Input.GetAxis("Horizontal");

        if (isGround)
        {
            rb.AddForce(transform.forward * forwardInput * speed);
            rb.AddForce(transform.right * HorizontalInput * speed);
        }
        if (!isGround)
        {
            rb.AddForce(transform.forward * forwardInput * speed * inAirSpeed);
            rb.AddForce(transform.right * HorizontalInput * speed);
        }
        //transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        //transform.Translate(Vector3.right * HorizontalInput * Time.deltaTime * speed);
        //transform.Rotate(Vector3.up * mouseX * Time.deltaTime * turnSpeed);
        //cameraObj.transform.Rotate(Vector3.up * mouseY * Time.deltaTime * turnSpeedY);

        yRotation += Mathf.Clamp(-mouseY * turnSpeedY, -maxY, maxY);
        xRotation += mouseX * turnSpeed;
        cameraObj.transform.rotation = Quaternion.Euler(yRotation, xRotation + 90, 0f);
        transform.rotation = Quaternion.Euler(0f, xRotation + 90, 0f);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(transform.up * jumpHeight);
            isGround = false;
            
        }



        /*
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundDistance))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                Debug.Log("hit ground");
                isGround = true;
            }
        }*/
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}
