using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] float openAngle;
    [SerializeField] float closeAngle;
    [SerializeField] float rotationSpeed;

    private bool isOpen;

    void Update()
    {
        if (isOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(0, 0, openAngle);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(0, 0, closeAngle);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void ChangeState()
    {
        isOpen = !isOpen;
    }
}