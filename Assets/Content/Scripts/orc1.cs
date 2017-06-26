using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orc1 : MonoBehaviour {
    public float amounttomovex;
    public float speed;
    public float speed2;
    private float currentposx;
    private float currentposy;
    private int facing;

    void Start()
    {
        speed2 = speed;
        currentposx = gameObject.transform.position.x;
        facing = 0;
    }

    void Update()
    {
        Animator animator = GetComponent<Animator>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (facing == 1 && gameObject.transform.position.x < currentposx - amounttomovex)
        {
            sr.flipX = true;
            animator.SetBool("run", true);
            facing = 0;
        }

        if (facing == 0 && gameObject.transform.position.x > currentposx)
        {
            sr.flipX = false;
            animator.SetBool("run", true);
            facing = 1;
        }

        if (facing == 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (facing == 1)
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
     {
         Animator animator = GetComponent<Animator>();
        HeroRabit rabit= collider.GetComponent<HeroRabit>();
        if (collider.gameObject.tag == "Player")
         {
            speed = 0;
             animator.SetBool("run", false);
             animator.SetBool("attack",true);
          
           
        }    

     }
     void OnTriggerExit2D(Collider2D other)
     {
      
        if (other.gameObject.tag == "Player") { 
         Animator animator = GetComponent<Animator>();
         animator.SetBool("attack",false);
         animator.SetBool("run", true);
         speed = speed2;
         }
     }
    
   
}
