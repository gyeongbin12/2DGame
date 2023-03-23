using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IAttack
{
    protected int health;
    public int attack;

    virtual public void Use()
    {
        
    }
}
