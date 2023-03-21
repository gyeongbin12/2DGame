using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    private Vector2 direction;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        
        if(direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}
    