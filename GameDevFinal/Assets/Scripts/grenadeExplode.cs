using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class grenadeExplode : MonoBehaviour
{
    public float speed = 10f;
    public bool Grounded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Grounded)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Grounded = true;
            gameObject.AddComponent<SphereCollider>();
            gameObject.GetComponent<SphereCollider>().radius = Mathf.Lerp(0.1649289f, 10, 20);
            gameObject.GetComponent<SphereCollider>().isTrigger = true;
            Destroy(gameObject, 0.5f);
        }

        if (other.GetComponentInParent<isZombie>() != null)
        {
            Destroy(other.gameObject);
        }
    }
}
