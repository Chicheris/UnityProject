using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroRabit : MonoBehaviour
{
    bool isGrounded = false;
    bool JumpActive = false;
    float JumpTime = 0f;
    public float MaxJumpTime = 2f;
    public float JumpSpeed = 2f;
    public float timeleft = 1f;
    public float speed = 1;
    float speed2;
    Rigidbody2D myBody = null;

    Vector3 startingPosition;

    Transform heroParent = null;
    void Start()
    {
        startingPosition = transform.position;
        speed2 = speed;
        myBody = this.GetComponent<Rigidbody2D>();
        LevelController.current.setStartPosition(transform.position);

        this.heroParent = this.transform.parent;
    }

    void Update()
    {
    }
    void FixedUpdate()
    {

        float value = Input.GetAxis("Horizontal");
        Animator animator = GetComponent<Animator>();

        if (Mathf.Abs(value) > 0)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }

        if (this.isGrounded)
        {
            animator.SetBool("jump", false);
        }
        else
        {
            animator.SetBool("jump", true);
        }


        if (Mathf.Abs(value) > 0)
        {
            Vector2 vel = myBody.velocity;
            vel.x = value * speed;
            myBody.velocity = vel;
        }


        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (value < 0)
        {
            sr.flipX = true;
        }
        else if (value > 0)
        {
            sr.flipX = false;
        }


        Vector3 from = transform.position + Vector3.up * 0.3f;
        Vector3 to = transform.position + Vector3.down * 0.1f;
        int layer_id = 1 << LayerMask.NameToLayer("Ground");

        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        if (hit)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        Debug.DrawLine(from, to, Color.red);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            this.JumpActive = true;
        }
        if (this.JumpActive)
        {

            if (Input.GetButton("Jump"))
            {
                this.JumpTime += Time.deltaTime;
                if (this.JumpTime < this.MaxJumpTime)
                {
                    Vector2 vel = myBody.velocity;
                    vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
                    myBody.velocity = vel;
                }
            }
            else
            {
                this.JumpActive = false;
                this.JumpTime = 0;




            }
        }
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Menu");
    }
}


    /*  void OnTriggerEnter2D(Collider2D collider)
      {
          if (collider.gameObject.tag == "orc")
          {
              Animator animator = GetComponent<Animator>();
              speed = 0;
              animator.SetBool("die", true);

              timeleft -= Time.deltaTime;

              if (timeleft == 0)
              {

                  HeroRabit rabit = collider.GetComponent<HeroRabit>();
                  LevelController.current.onRabitDeath(rabit);
                  Debug.LogError("FCUK");
              }


          }
      }
      void OnTriggerExit2D(Collider2D other)
      {

          if (other.gameObject.tag == "orc")
          {

              Animator animator = GetComponent<Animator>();
              animator.SetBool("die", false);
              speed = speed2;
          }
      }
  */

    private void OnTriggerStay2D(Collider2D collision)
    {
        Animator animator = GetComponent<Animator>();
        speed = 0;
        animator.SetBool("die", true);

        timeleft -= Time.deltaTime;

        if (timeleft < 0)
        {
            animator.SetBool("die", false);
            StartPosition();
            speed = speed2;
        }
    }
  public   void StartPosition()
    {
        transform.position = startingPosition;

    }
}