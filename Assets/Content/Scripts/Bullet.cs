using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
  HeroRabit rabit;
    float timeleft = 1f;
    private void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft < 0)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        
            if (collision.gameObject.tag == "Player")
        {
            rabit.StartPosition();

        }
    }
}
