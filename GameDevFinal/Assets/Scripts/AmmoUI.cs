using UnityEngine;
using TMPro;  

public class AmmoUI : MonoBehaviour
{
    public gunShooting gunScript;           
    public TextMeshProUGUI ammoText;       

    void Start()
    {
        UpdateAmmoText();
    }

    void Update()
    {
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        if (gunScript == null || gunScript.currentGun == null) return;

        int current = gunScript.currentGun.currentAmmo;
        int max = gunScript.currentGun.maxAmmo;

        ammoText.text = current + " / " + max;
    }
}
