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

    public override void Use()
    {
        animator.SetBool("Attack", true);
        // memoryPool.DeactivatePoolItem(gameObject);
    }


    public void Update()
    {
        direction = transform.position - player.position;


        Util.Flip(direction, spriteRenderer, false);

        transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
    }
}
