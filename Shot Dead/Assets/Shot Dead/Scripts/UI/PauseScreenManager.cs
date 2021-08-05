using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
public class PauseScreenManager : MonoBehaviour
{
    public GameObject player;
    public GameObject pauseScreen;
    public TextMeshProUGUI status, healthStatus;
    public TextMeshProUGUI playerHealthLabel;
    private PlayerHealth playerHealth;
    //private CameraScript cam;
    private bool isActive;
    void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;
            PauseScreenStatus();
        }
        if(playerHealth.status == "ALIVE")
        {
            status.color = new Color32(21, 166, 6, 255);
            status.text = playerHealth.status;
            healthStatus.text = playerHealth.currentHealthPoints.ToString();
        }
        else
        {
            status.color = new Color32(255, 0, 0, 255);
            status.text = playerHealth.status;
            healthStatus.text = "0";
        }
    }
    private void PauseScreenStatus()
    {
        if (isActive)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }
    public void Resume()
    {
        isActive = false;
        pauseScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        //cam.enabled = true;
        Time.timeScale = 1;
    }
    public void Pause()
    {
        isActive = true;
        pauseScreen.SetActive(true);
        //cam.enabled = false;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;

        healthStatus.color = playerHealthLabel.color;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
