using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer renderer;
    public float speed = 6f;
    public float jumpForce = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        renderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Debug.Log(rigid.velocity.y);
    }

    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(xInput * speed, rigid.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(xInput));



        if(xInput < 0)
        {
            renderer.flipX = true;
        }

        if(xInput > 0)
        {
            renderer.flipX = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded() == true)
        {
            rigid.AddForce(new Vector2(0, jumpForce));
        }

        if(rigid.velocity.y == 0)
        {
            anim.SetBool("grounded", true);
        }
        else
        {
            anim.SetBool("grounded", false);
        }

        anim.SetFloat("isJumping", rigid.velocity.y);

    }

    bool isGrounded()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position, Vector2.down, 0.1f);

        foreach(RaycastHit2D h in hits)
        {
            if(h.transform.CompareTag("Ground") == true)
            {
                return true;
            }
        }
        return false;
    }
}
