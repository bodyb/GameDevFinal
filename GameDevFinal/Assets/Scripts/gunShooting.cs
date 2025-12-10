using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class gunShooting : MonoBehaviour
{
    public gun currentGun;
    public GameObject bulletImpactPrefab;
    public GameObject grendaePrefab;
    public GameObject bullet;
    public GameObject gunHolder;
    public int grenadeAmmo = 5;
    public Camera camera;
    public TMP_Text ammoUI;
    public TMP_Text grenadeUI;
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGun = new gun(50, 150, 1f, 3, 30);
    }

    //Update is called once per frame
    void LateUpdate()
    {
        ammoUI.text = currentGun.currentAmmo.ToString() + "/" + currentGun.currentTotalAmmo.ToString();
        //Debug.Log(currentGun.currentTotalAmmo, camera);
        //Debug.Log(currentGun.currentAmmo, bullet);
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
                    //currentGun.currentTotalAmmo -= currentGun.bulletPerMag;
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
                isZombie zombie = hit.collider.GetComponentInParent<isZombie>();
                if (zombie != null)
                {
                    zombie.health -= currentGun.damage;
                    //Debug.Log("Zombie Hit");
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
        grenadeUI.text = grenadeAmmo.ToString() + " Grenades";
        if (Input.GetKeyDown(KeyCode.G) && grenadeAmmo > 0)
        {
            Instantiate(grendaePrefab, (camera.transform.position + camera.transform.forward), camera.transform.rotation);
            grenadeAmmo--;
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
