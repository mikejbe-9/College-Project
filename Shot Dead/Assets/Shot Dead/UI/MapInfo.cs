using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    private TextMeshProUGUI mapNameText;

    void Start()
    {
        mapNameText = GetComponent<TextMeshProUGUI>();
        mapNameText.text = "MAP : " +SceneManager.GetActiveScene().name;
    }
}
