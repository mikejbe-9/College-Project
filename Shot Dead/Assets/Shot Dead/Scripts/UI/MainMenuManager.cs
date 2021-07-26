using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip pointerEnterClip;
    public AudioClip buttonClickClip;
    public AudioClip startButtonClip;

    public void Awake()
    {
        Time.timeScale = 1;
    }

    public void PlayPointerEnterSound()
    {
        audioSource.clip = pointerEnterClip;
        audioSource.Play();
    }

    public void ButtonClickSound()
    {
        audioSource.clip = buttonClickClip;
        audioSource.Play();
    }

    public void StartButtonSound()
    {
        audioSource.clip = startButtonClip;
        audioSource.Play();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
