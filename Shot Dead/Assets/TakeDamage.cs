using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public enum CollisionType {head, torso, arms, legs}
    public CollisionType damageType;

    //public Health health;

    public void Hit(float damageVal)
    {
        //health.healthPoints -= damageVal;
    }
}
