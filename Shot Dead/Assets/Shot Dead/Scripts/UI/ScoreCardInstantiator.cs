using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCardInstantiator : MonoBehaviour
{
    public GameObject scoreCard;
    public GameObject scoreCardHolder;

    public float offset;

    public List<GameObject> scoreCards;
    public bool hasDone;
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject sc = Instantiate(scoreCard, scoreCardHolder.transform);
            scoreCards.Add(sc);
            if (i > 0)
            {
                Vector2 off = scoreCards[i].GetComponent<RectTransform>().anchoredPosition;
                off.y = scoreCards[i - 1].GetComponent<RectTransform>().anchoredPosition.y - offset;
                scoreCards[i].GetComponent<RectTransform>().anchoredPosition = off;
            }
            scoreCards[i].transform.rotation = Quaternion.identity;

        }
    }


    void Update()
    {
        if (hasDone)
        {
            
            hasDone = false;
        }
        hasDone = false;
    }
}
