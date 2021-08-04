using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] Gun1 gun = null;

    public void PickUpAmmo()
    {
        if (gun.totalBullets != gun.bulletCountAtStart)
        {
            gun.totalBullets = gun.bulletCountAtStart;
            Destroy(gameObject);
        }
    }
}
