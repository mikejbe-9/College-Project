using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Script References")]
    //public PlayerMovement1 playerMovement;
    public PlayerInteraction playerInteraction;
    public PlayerHealth playerHealth;
    public WeaponSwitching weaponSwitching;
    //public CameraScript cam;
    public GameCompletionState gameCompletionState;
    public KillCounter killCounter;
    public Timer timer;
    public ExitTrigger exit;

    [Header("GameObjects and Transforms")]
    public GameObject victorySplashScreen;
    public TextMeshProUGUI gameResultText, subTitle;
    public Transform gunHolder;
    public Vector3[] npcPositions;

    public int resqueCount;

    private GameObject[] npcs;
    public List<Gun1> guns;
    private int index;

    public bool victory;
    public bool defeat;

    void Awake()
    {
        victorySplashScreen.SetActive(false);
        npcs = GameObject.FindGameObjectsWithTag("NPC");
        SetNPCPositions();
    }

    void Start()
    {
        for(int i = 0; i < gunHolder.childCount; i++)
        {
            guns.Add(gunHolder.GetChild(i).GetComponent<Gun1>());
        }
    }

    void Update()
    {
        if(killCounter.livesRescued >= 2 && exit.hasReachedExit)
        {
            victory = true;
            GameCompleted();
        }

        else if(timer.currentTime <= 0 || playerHealth.status == "DEAD")
        {
            defeat = true;
            GameCompleted();
        }
    }

    void SetNPCPositions()
    {
        index = GetIndexValue();
        foreach(GameObject npc in npcs)
        {
            npc.transform.localPosition = npcPositions[index];
            npcPositions[index] = npcPositions[0];
            npcPositions[0] = npc.transform.localPosition;
        }
    }

    int GetIndexValue()
    {
        int i = Random.Range(1, npcPositions.Length);
        return i;
    }

    void GameCompleted()
    {
        foreach(Gun1 gun in guns)
        {
            gun.enabled = false;
        }
        //playerMovement.enabled = false;
        playerInteraction.enabled = false;
        weaponSwitching.enabled = false;
        //cam.enabled = false;

        victorySplashScreen.SetActive(true);
        if (victory)
        {
            gameResultText.text = "VICTORY";
            subTitle.text = "LIVES WERE SAVED";
        }
        else if (defeat)
        {
            if (playerHealth.hasDied) 
            {
                victorySplashScreen.GetComponent<Animator>().SetBool("HasDied", true);
            }
            gameResultText.text = "DEFEAT";
            subTitle.text = "HUMANITY COULDN'T BE SAVED";
        }

        gameCompletionState.gameCompletionStateText = gameResultText.text;
        gameCompletionState.livesRescued = resqueCount;
        
        Invoke("LoadLastScene", 2f);
    }

    void LoadLastScene()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("FINAL MENU");
    }
}
