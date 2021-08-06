using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableResultDisplay : MonoBehaviour
{
    public GameObject gameResult;

    public void EnableResultTextGO()
    {
        gameResult.SetActive(true);
    }
}
