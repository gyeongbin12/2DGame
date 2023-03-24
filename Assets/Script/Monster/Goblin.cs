using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Monster
{
    protected override void Start()
    {
        health = 100;
        attack = 5;

        base.Start();
    }

    public void Update()
    {
        direction = transform.position - player.position;

        if (direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
    }
}
