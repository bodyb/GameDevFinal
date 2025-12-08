using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class grenadeExplode : MonoBehaviour
{
    public float speed = 10f;
    public bool Grounded = false;

    public GameObject explosionEffect; 

    void Start()
    {

    }

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
            Instantiate(explosionEffect, transform.position, Quaternion.identity);

            gameObject.AddComponent<SphereCollider>();
            gameObject.GetComponent<SphereCollider>().radius = Mathf.Lerp(0.1649289f, 10, 20);
            gameObject.GetComponent<SphereCollider>().isTrigger = true;
            Destroy(gameObject, 0.2f);
        }

        if (other.GetComponentInParent<isZombie>() != null)
        {
            Destroy(other.gameObject);
        }
    }
}
