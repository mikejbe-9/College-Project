using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinalScreenManager : MonoBehaviour
{
    public GameCompletionState gameCompletionState;
    public TextMeshProUGUI gameResultText, scoreText, totalKillsText, livesRescuedText;

    void Start()
    {
        gameCompletionState = GameObject.FindGameObjectWithTag("ResultCarrier").GetComponent<GameCompletionState>();
    }

    void Update()
    {
        gameResultText.text = gameCompletionState.gameCompletionStateText;
        livesRescuedText.text = gameCompletionState.livesRescued.ToString();
        scoreText.text = gameCompletionState.score.ToString();
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
