using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IAttack
{
    protected int health;
    protected int attack;

    public void Damamge(Monster monster)
    {
        monster.health -= monster.health;
    }

    virtual public void OnTriggerEnter2D(Collider2D collision)
    {
        IAttack obj = collision.GetComponent<IAttack>();

        Monster monster = collision.GetComponent<Monster>();

        if (obj != null)
        {
            Damamge(monster);
        }
    }

    public void Use()
    {
        
    }
}
