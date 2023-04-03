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

    public override void Use()
    {
        animator.SetBool("Attack", true);
        SoundManager.instance.Sound(SoundManager.SoundType.Attack);
        // memoryPool.DeactivatePoolItem(gameObject);
    }

    public void Update()
    {
        direction = transform.position - player.position;

        Util.Flip(direction, spriteRenderer, true);

        transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
    }
}
