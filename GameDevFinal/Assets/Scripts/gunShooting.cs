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
        currentGun = new gun(50, 18, 1f, 3, 6);
    }

    //Update is called once per frame
    void Update()
    {
        Debug.Log(currentGun.currentTotalAmmo, camera);
        Debug.Log(currentGun.currentAmmo, bullet);
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentGun.currentTotalAmmo > currentGun.bulletPerMag)
            {
                if (currentGun.currentAmmo == currentGun.bulletPerMag) 
                {
                    currentGun.currentAmmo = currentGun.bulletPerMag;
                }
                if (currentGun.currentAmmo < currentGun.bulletPerMag)
                {
                    currentGun.currentAmmo = currentGun.bulletPerMag;
                    currentGun.currentTotalAmmo -= currentGun.bulletPerMag;
                }
            }
            else
            {
                currentGun.currentAmmo = currentGun.currentTotalAmmo;
            }
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Vector3 shootingPos = new Vector3(camera.transform.position.x, camera.transform.position.y - 0.4f, camera.transform.position.z);
            
            Physics.Raycast(shootingPos, camera.transform.forward, out hit, currentGun.distance, ~0); //LayerMask.GetMask("Zombie")
            Debug.DrawLine(shootingPos, camera.transform.forward * currentGun.distance, Color.red, 0.2f);
            
            if (currentGun.currentAmmo > 0)
            {
                Debug.Log(hit.collider.name);
                isZombie zombie = hit.collider.GetComponentInParent<isZombie>();
                if (zombie != null)
                {
                    zombie.health -= currentGun.damage;
                    Debug.Log("Zombie Hit");
                    //Instantiate()
                }

                if (zombie == null)
                {
                    //Debug.Log(hit.collider.name);
                }
                currentGun.currentAmmo--;
                currentGun.currentTotalAmmo--;
            }
            
        }
    }
}
public class gun {
    public int distance;
    public int maxAmmo;
    public float damage;
    public int currentAmmo;
    public int currentTotalAmmo;
    public int magNumber;
    public int bulletPerMag;
    public gun(int distance, int maxAmmo, float damage, int magNumber, int bulletPerMag)
    {
        this.distance = distance;
        this.maxAmmo = maxAmmo;
        this.damage = damage;
        this.currentAmmo = bulletPerMag;
        this.currentTotalAmmo = maxAmmo;
        this.magNumber = magNumber;
        this.bulletPerMag = bulletPerMag;
    } 
}
