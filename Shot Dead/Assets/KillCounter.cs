using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public GameCompletionState gameCompletionState;

    public int totalMoney;
    public int killCount = 0;
    public int headShotKills = 0;
    public int livesRescued = 0;

    void Update()
    {
        gameCompletionState.totalKills = killCount;
        gameCompletionState.headShotKills = headShotKills;
        gameCompletionState.livesRescued = livesRescued;
    }

}
