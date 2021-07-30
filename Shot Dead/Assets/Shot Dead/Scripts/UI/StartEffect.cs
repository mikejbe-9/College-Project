using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEffect : MonoBehaviour
{
    public ShakeEffect shake;

    public void StartShakeEffect()
    {
        shake.ScreenShake(.2f);
    }
}
