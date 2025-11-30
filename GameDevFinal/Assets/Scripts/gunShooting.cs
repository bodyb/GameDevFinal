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
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            Physics.Raycast(ray, out hit, currentGun.distance, LayerMask.GetMask("Zombie"), QueryTriggerInteraction.Collide);
            Debug.DrawLine(ray.origin, hit.point, Color.red, 0.2f);

            if (hit.collider != null && currentGun.currentAmmo > 0)
            {
                isZombie zombie = hit.collider.GetComponentInParent<isZombie>();
                if (zombie != null)
                {
                    zombie.health -= currentGun.damage;
                    Debug.Log("Zombie Hit");
                }

                if (zombie == null)
                {
                    Debug.Log("Zombie collider does not have isZombie in its parents! " + hit.collider.name);
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
