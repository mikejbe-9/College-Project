using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public bool hasReachedExit;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasReachedExit = true;
        }
    }
}
