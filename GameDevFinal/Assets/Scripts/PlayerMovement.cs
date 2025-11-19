using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovemnt : MonoBehaviour
{
    public float HorizontalInput;
    public float forwardInput;
    public float speed = 10.0f;
    public float turnSpeed = 3.0f;
    public float xBound = 10.0f;
    public float mouseX = 0;
    public float mouseY = 0;
    public float turnSpeedY = 1.0f;
    public float yRotation = 0;
    public float xRotation = 0;
    public float maxY = 60;
    public GameObject cameraObj;
    public Rigidbody rb;
    public GameObject feet;
    public GameObject gunHolder;
    public float jumpHeight = 10;
    public bool isGround = true;
    public bool sprinting = false;
    public float groundDistance = 1.001f;
    public float inAirSpeed = 2.5f;
    public float offset = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * turnSpeedY * Time.deltaTime;
        forwardInput = Input.GetAxis("Vertical");
        HorizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            sprinting = true;
            speed = 15.0f;
        } else
        {
            sprinting = false;
            speed = 10.0f;
        }

        if (isGround)
        {
            transform.Translate(Vector3.forward * forwardInput * speed * Time.deltaTime);
            transform.Translate(Vector3.right * HorizontalInput * speed * Time.deltaTime);
        }
        if (!isGround)
        {
            transform.Translate(Vector3.forward * forwardInput * inAirSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * HorizontalInput * inAirSpeed * Time.deltaTime);
        }
        //transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        //transform.Translate(Vector3.right * HorizontalInput * Time.deltaTime * speed);
        //transform.Rotate(Vector3.up * mouseX * Time.deltaTime * turnSpeed);
        //cameraObj.transform.Rotate(Vector3.up * mouseY * Time.deltaTime * turnSpeedY);

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -maxY, maxY);
        xRotation += mouseX;
        cameraObj.transform.rotation = Quaternion.Euler(yRotation, xRotation + 90, 0f);
        gunHolder.transform.rotation = Quaternion.Euler(yRotation, xRotation + 90, 0f);
        transform.rotation = Quaternion.Euler(0f, xRotation + 90, 0f);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(transform.up * jumpHeight);
            isGround = false;
        }

        RaycastHit hit;
        Physics.Raycast(feet.transform.position, Vector3.down, out hit, 0.01f);
        if (hit.collider.CompareTag("Ground"))
        {
            isGround = true;
        }
        
    }

    private void LateUpdate()
    {
        cameraObj.transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
    }
}
