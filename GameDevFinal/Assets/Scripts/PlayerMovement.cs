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
    public GameObject projectilePrefab;
    public GameObject cameraObj;
    public GameObject deadScreen;
    public bool dead;
    public int zombieDead = 0;
    public Camera camera;
    public Rigidbody rb;
    public float jumpHeight = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!dead)
        {
            forwardInput = Input.GetAxis("Vertical");
            HorizontalInput = Input.GetAxis("Horizontal");
            rb.AddForce(Vector3.forward * forwardInput * Time.deltaTime * speed);
            rb.AddForce(Vector3.right * HorizontalInput * Time.deltaTime * speed);
            //transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
            //transform.Translate(Vector3.right * HorizontalInput * Time.deltaTime * speed);
            //transform.Rotate(Vector3.up * mouseX * Time.deltaTime * turnSpeed);
            //cameraObj.transform.Rotate(Vector3.up * mouseY * Time.deltaTime * turnSpeedY);

            yRotation += Mathf.Clamp(-mouseY * turnSpeedY, -maxY, maxY);
            xRotation += mouseX * turnSpeed;
            cameraObj.transform.rotation = Quaternion.Euler(yRotation, xRotation, 0f);
            transform.rotation = Quaternion.Euler(0f, xRotation, 0f);


            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
        }
    }
}
