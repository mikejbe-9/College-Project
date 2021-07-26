using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompletionState : MonoBehaviour
{
    public string gameCompletionStateText;
    public int score, totalKills, headShotKills, livesRescued;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        score = 5 * totalKills + 10 * headShotKills + 50 * livesRescued;
    }
}
