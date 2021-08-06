using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject scoreCard;
    public GameObject gunHolder;
    public GameObject buyMenu;
    public Image img;
    public Gradient healthGradient;

    [Header("Script References")]
    public Gun1 gun;
    public CharacterManager characterManager;
    public PlayerHealth playerHealth;
    public Timer timer;

    [Header("Texts")]
    public TextMeshProUGUI bulletCountText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameTimeText;
    public TextMeshProUGUI buyTimeText;

    private float timel;
    private bool isOpen;
    private bool isCurrentlyOpen;

    void Start()
    {
        img.color = new Color(255, 255, 255, 0);
    }

    void Update()
    {
        if (timer != null)
        {
            gameTimeText.text = timer.currentTime.ToString("0");
            buyTimeText.text = "TIME : " + timer.currentBuyingTime.ToString("0");
        }

        if (timer.currentBuyingTime > 0f)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                isOpen = !isOpen;
                BuyMenuState(isOpen);
            }
        }
        else if (timer.currentBuyingTime <= 0f && isCurrentlyOpen)
        {
            BuyMenuState(false);
            isCurrentlyOpen = false;
        }

        if (gun != null)
        {
            bulletCountText.text = gun.magazineSize + "/" + gun.totalBullets;
            img.color = new Color(255, 255, 255, 255);
            img.sprite = gun.icon;
        }
        healthText.color = healthGradient.Evaluate(characterManager._health / 100);
        healthText.text = characterManager._health.ToString("0");

        //scoreCard.SetActive(Input.GetKey(KeyCode.Tab));

        //if (Input.GetKey(KeyCode.Tab))
        //{
        //    scoreCard.SetActive(true);
        //}
        //if (Input.GetKeyUp(KeyCode.Tab))
        //{
        //    scoreCard.SetActive(false);
        //}
    }

    public void GetActiveGun(GameObject gunPrefab)
    {
        gun = gunPrefab.GetComponent<Gun1>();
    }

    public void BuyMenuState(bool switchOn)
    {
        if (switchOn)
        {
            Cursor.lockState = CursorLockMode.None;
            isCurrentlyOpen = true;
            buyMenu.SetActive(true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            buyMenu.SetActive(false);
        }
    }
}
