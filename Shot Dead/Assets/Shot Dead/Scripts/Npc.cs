using UnityEngine.UI;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public Text instructionText;

    public bool resqued;
    public bool inRange;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            instructionText.enabled = true;
            inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            instructionText.enabled = false;
            inRange = false;
        }
    }
}
