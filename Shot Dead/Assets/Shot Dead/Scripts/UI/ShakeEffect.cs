using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    public float shakeAmount;
    public float shakeTime = 0f;

    public AudioSource source;

    private Vector3 initialPos;
    private Quaternion initialRot;
    private bool isShaking;

   
    void Update()
    {
        if (shakeTime > 0f)
        {
            //transform.position = Random.insideUnitSphere * shakeAmount + initialPos;
            transform.rotation = new Quaternion(initialRot.x + Random.Range(-shakeAmount, shakeAmount) * 0.2f,
                                 initialRot.y + Random.Range(-shakeAmount, shakeAmount) * 0.2f,
                                 initialRot.z + Random.Range(-shakeAmount, shakeAmount) * 0.2f,
                                 initialRot.w + Random.Range(-shakeAmount, shakeAmount) * 0.2f);
            shakeTime -= Time.deltaTime;
        }
        else if (isShaking)
        {
            isShaking = false;
            shakeTime = 0f;
            transform.position = initialPos;
        }
    }

    public void ScreenShake(float time)
    {
        initialPos = transform.position;
        initialRot = transform.rotation;
        shakeTime = time;
        isShaking = true;
        source.Play();
    }
}
