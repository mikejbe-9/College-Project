using TMPro;
using UnityEngine;

public class LevelName : MonoBehaviour
{
    public SceneLoader sceneLoader;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    void Update()
    {
        
    }

    public void GetLevelName()
    {
        sceneLoader.scene = GetComponentInChildren<TextMeshProUGUI>().text;
    }
}
