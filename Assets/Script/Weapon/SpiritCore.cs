using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritCore : IWeapon
{
    public void Attack(GameObject obj)
    {
        obj.transform.RotateAround(obj.transform.parent.position, Vector3.forward, 100f * Time.deltaTime);
    }
}
