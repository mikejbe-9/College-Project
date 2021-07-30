using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinalScreenManager : MonoBehaviour
{
    public GameCompletionState gameCompletionState;
    public TextMeshProUGUI gameResultLabel, scoreLabel, totalKillsLabel, livesRescuedLabel;

    void Start()
    {
        gameCompletionState = GameObject.FindGameObjectWithTag("ResultCarrier").GetComponent<GameCompletionState>();
    }

    void Update()
    {
        gameResultLabel.text = gameCompletionState.gameCompletionStateText;
        livesRescuedLabel.text = gameCompletionState.livesRescued.ToString();
        scoreLabel.text = gameCompletionState.score.ToString();
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
