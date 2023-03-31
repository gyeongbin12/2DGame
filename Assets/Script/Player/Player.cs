using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] int health = 100;
    [SerializeField] Material flashMaterial;

    private Vector2 direction;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private Material originalMaterial;
    private SpriteRenderer spriteRenderer;

    private WaitForSeconds wait = new WaitForSeconds(0.125f);

    static public Action<Monster> function;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        originalMaterial = spriteRenderer.material;

        function = Damage;
    }

    public void Damage(Monster monster)
    {
        health -= monster.attack;
        Debug.Log(health);
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
        Vector3 convertedPosition = Camera.main.WorldToViewportPoint(rigidbody2D.position);

        convertedPosition.x = Mathf.Clamp(convertedPosition.x, 0.035f, 0.965f);
        convertedPosition.y = Mathf.Clamp(convertedPosition.y, 0.075f, 0.9125f);

        rigidbody2D.position = Camera.main.ViewportToWorldPoint(convertedPosition);
        
        rigidbody2D.velocity = direction.normalized
            * speed * Time.fixedDeltaTime;
    }

    public IEnumerator Flash()
    {
        spriteRenderer.material = flashMaterial;

        yield return wait;

        spriteRenderer.material = originalMaterial;
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        IAttack obj = collision.GetComponent<IAttack>();

        if (obj != null)
        {
            StartCoroutine(Flash());
            obj.Use();
        }
    }
}
    