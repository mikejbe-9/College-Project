using UnityEngine;

public class Aid : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public int regeneratePoints = 60;

    public void RegenerateHealth()
    {
        playerHealth.currentHealthPoints += 60;
        Destroy(gameObject);
    }
}
