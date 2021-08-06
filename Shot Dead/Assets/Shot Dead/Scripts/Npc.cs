using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public TextMeshProUGUI instructionText;

    public bool resqued;
    public bool inRange;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPS Controller Rig")
        {
            instructionText.enabled = true;
            inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FPS Controller Rig")
        {
            instructionText.enabled = false;
            inRange = false;
        }
    }
}
