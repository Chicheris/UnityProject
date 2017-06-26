using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    public  GameObject bullet;
   public float timeleft = 3f;
    bool a=false;
    float time2 = 1f;
    float pos=0;
    // Use this for initialization
    void Start () {
       
    }
	void Update()
    {
       pos++;
        Shoot();

    }
    void Shoot()
    {
        timeleft -= Time.deltaTime;
        if (timeleft < 0)
        {
        a = true;
            timeleft = 3f;
            if (a)
            {
                while (time2 > 0) {
                    time2 -= Time.deltaTime;
                GameObject bullet3 = Instantiate(bullet, transform.position, transform.rotation);
                    bullet3.GetComponent<Rigidbody2D>().AddForce(new Vector2(pos,0f));
                a = false;
               
                    
                Shoot();
            }
            }
        }
    }

}
