using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealthPoints = 100;
    public float currentHealthPoints;

    [Header("Sounds")]
    public AudioSource source;
    public AudioClip[] deathClips;

    [HideInInspector] public string status;

    public bool hasDied;

    void Start()
    {
        currentHealthPoints = maxHealthPoints;
    }

    void Update()
    {
        if(currentHealthPoints > 0)
        {
            status = "ALIVE";
        }
        else
        {
            status = "DEAD";
            OnDeath();
        }
        if(currentHealthPoints > maxHealthPoints)
        {
            currentHealthPoints = maxHealthPoints;
        }
    }

    void OnDeath()
    {
        int i = Random.Range(0, deathClips.Length);
        if (!hasDied)
        {
            source.PlayOneShot(deathClips[i]);
            hasDied = true;
        }
    }
}
