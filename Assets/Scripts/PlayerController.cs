using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed = 5;
    Animator animator;
    SpriteRenderer sp;
    Rigidbody2D rigidbody2d;
    bool canWalk = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!canWalk)
        {
            animator.SetFloat("Speed", 0);
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");

        if (Mathf.Approximately(horizontal, 0.0f))
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            return;
        }

        sp.flipX = horizontal < 0 ? true : false;

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        float dmove = speed * horizontal * Time.deltaTime;
        rigidbody2d.position = new Vector2(rigidbody2d.position.x+dmove, rigidbody2d.position.y);
    }

    public void SetPlayCanWalk(bool b)
    {
        canWalk = b;
    }
}
