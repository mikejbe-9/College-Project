using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] gunSlots = new GameObject[3];
    public GameObject defaultGun;

    public WeaponSwitching weaponSwitching;
    public Timer timer;

    private bool gunBought;

    void Update()
    {
        if(timer.currentBuyingTime <= 0 && !gunBought)
        {
            gunSlots[0] = defaultGun;
            ConfirmBuy();
            weaponSwitching.SelectGun();
            gunBought = true;
        }
    }

    public void AddToInventory(GameObject gun)
    {
        if(gun.tag == "Pistol")
        {
            gunSlots[0] = gun;

            if (defaultGun != null)
            {
                Destroy(defaultGun);
            }
        }
        else if(gun.tag == "SMG")
        {
            gunSlots[1] = gun;
        }
        else
        {
            gunSlots[2] = gun;
        }
        gunBought = true;
    }

    public void ConfirmBuy()
    {
        foreach (GameObject gun in gunSlots)
        {
            if (gun != null)
            {
                Instantiate(gun, this.transform);
            }
        }
    }
}
