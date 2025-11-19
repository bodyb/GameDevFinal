using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class gunShooting : MonoBehaviour
{
    public gun currentGun;
    public GameObject bulletImpactPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGun = new gun(10, 10, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, currentGun.distance);
            //Debug.Log(hit);
            if (hit.rigidbody != null && currentGun.currentAmmo > 0)
            {
                hit.rigidbody.AddForce(ray.direction * 500);
                currentGun.currentAmmo--;
                Quaternion rotation = Quaternion.Euler(hit.normal);
                Instantiate(bulletImpactPrefab, hit.transform.position, rotation);
            }
        }
    }
}
public class gun {
    public int distance;
    public int maxAmmo;
    public float damage;
    public int currentAmmo;
    public gun(int distance, int maxAmmo, float damage)
    {
        this.distance = distance;
        this.maxAmmo = maxAmmo;
        this.damage = damage;
        this.currentAmmo = maxAmmo;
    } 
}
