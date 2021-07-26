using TMPro;
using UnityEngine;

public class SelectGun : MonoBehaviour
{
    public GameObject gunPrefab;
    public Inventory inventory;
    //public KillCounter killCounter;

    public TextMeshProUGUI accuracyText,damageText,ammoText;

    public int cost;

    private Gun1 gun;

    void Awake()
    {
        gun = gunPrefab.GetComponent<Gun1>();
    }

    public void BuyGun()
    {
        //if (killCounter.totalMoney >= cost)
        //{
            //killCounter.totalMoney -= cost;

            inventory.AddToInventory(gunPrefab);
        //}
    }

    public void ShowStats()
    {
        accuracyText.text = gun.normalSpreadFactor.ToString();
        gun.CalculateAvgDamage();
        damageText.text = gun.avgDamage.ToString();
        ammoText.text = gun.maxMagazineSize + "/" + gun.totalBullets;
    }
}
