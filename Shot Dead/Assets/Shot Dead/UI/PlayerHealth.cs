using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public CharacterManager characterManager;
    public float maxHealthPoints = 100;
    public float currentHealthPoints;

    [HideInInspector] public string status;

    public bool hasDied;

    void Start()
    {
        currentHealthPoints = maxHealthPoints;
    }

    void Update()
    {
        if(characterManager._health > 0)
        {
            status = "ALIVE";
        }
        else
        {
            status = "DEAD";
            OnDeath();
        }
        if(characterManager._health > maxHealthPoints)
        {
            characterManager._health = maxHealthPoints;
        }
    }

    void OnDeath()
    {
        if (!hasDied)
        {
            hasDied = true;
        }
    }
}
