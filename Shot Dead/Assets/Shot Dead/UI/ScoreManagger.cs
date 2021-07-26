using UnityEngine;

public class ScoreManagger : MonoBehaviour
{
    public KillCounter killCounter;
    public GameCompletionState gameCompletionState;

    public int maxPossibleScore;
    public int totalScore;

    void Start()
    {
        
    }

    void Update()
    {
        totalScore = 10 * killCounter.killCount + 50 * killCounter.livesRescued + 20 * killCounter.headShotKills;
        gameCompletionState.score = totalScore;
    }
}
