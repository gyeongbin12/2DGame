using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster
{
    void Start()
    {
        health = 50;
        attack = 1;
    }

    override public void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
