using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class gunShooting : MonoBehaviour
{
    public gun currentGun;
    public GameObject bulletImpactPrefab;
    public GameObject bullet;
    public GameObject gunHolder;
    public Camera camera;
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGun = new gun(50, 1500, 1f);
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Quaternion shootingAngle = new Quaternion(camera.transform.rotation.x, transform.rotation.y, transform.rotation.z, 0f);
            //Ray ray = Camera.main.ScreenPointToRay(new Vector3(0.5f, 0.5f, 0f));
            Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, currentGun.distance, ~0); //LayerMask.GetMask("Zombie")
            Debug.DrawLine(camera.transform.position, camera.transform.forward * currentGun.distance, Color.red, 0.2f);
            Debug.Log(hit.collider.name);
            if (currentGun.currentAmmo > 0)
            {
                isZombie zombie = hit.collider.GetComponentInParent<isZombie>();
                if (zombie != null)
                {
                    zombie.health -= currentGun.damage;
                    Debug.Log("Zombie Hit");
                    //Instantiate()
                }

                if (zombie == null)
                {
                    Debug.Log(hit.collider.name);
                }
            }
            currentGun.currentAmmo--;
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
