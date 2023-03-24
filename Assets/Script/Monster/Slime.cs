using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster
{
    protected override void Start()
    {
        health = 50;
        attack = 1;

        base.Start();
    }

    public void Update()
    {
        direction = transform.position - player.position;

        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
    }
}
