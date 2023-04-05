using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Player : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;


    [SerializeField] float health = 100;
    private float maxHealth;

    [SerializeField] Material flashMaterial;
    [SerializeField] Slider healhtSlider;

    private Vector2 direction;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private Material originalMaterial;
    private SpriteRenderer spriteRenderer;

    private WaitForSeconds wait = new WaitForSeconds(0.125f);

    static public Action<Monster> function;

    private void Start()
    {
        maxHealth = health;

        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        originalMaterial = spriteRenderer.material;

        function = Damage;
    }

    public void Damage(Monster monster)
    {
        StartCoroutine(Flash());

        health -= monster.attack;
        
        healhtSlider.value = health / maxHealth;
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
    