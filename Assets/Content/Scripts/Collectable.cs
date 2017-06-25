using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    protected virtual void OnRabitHit(HeroRabit rabit)
    {
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            DestroyMethod();
        }
    }
    void DestroyMethod()
    {
        Destroy(this.gameObject);
    }
}