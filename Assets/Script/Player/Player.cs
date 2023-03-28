using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] int health = 100;

    private Vector2 direction;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    private Animator animator;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Damamge(Monster monster)
    {
        health -= monster.attack;
    }

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (rigidbody2D.velocity == Vector2.zero)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }
        
        if(direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = direction.normalized
            * speed * Time.fixedDeltaTime;
    }
    
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        IAttack obj = collision.GetComponent<IAttack>();

        var monster = collision.GetComponent<Monster>();

        if (obj != null)
        {
            Damamge(monster);
        }

        Debug.Log("���ݹ��� ���� ü�� : " + health);
    }
}
    