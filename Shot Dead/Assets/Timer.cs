using UnityEngine;

public class Timer : MonoBehaviour
{
    [HideInInspector]public float currentTime;
    [HideInInspector]public float currentBuyingTime;

    public float timeLimit;
    public float buyingTimeLimit;

    private bool startGameCountDown;

    void Start()
    {
        currentTime = timeLimit;
        currentBuyingTime = buyingTimeLimit;
    }

    void Update()
    {
        currentBuyingTime -= Time.deltaTime;

        if(currentBuyingTime <= 0f)
        {
            startGameCountDown = true;
        }
        
        if (startGameCountDown)
        {
            currentTime -= Time.deltaTime;
        }

        if(currentTime <= 0f)
        {
            currentTime = 0f;
        }
    }
}