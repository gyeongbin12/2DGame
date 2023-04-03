using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Weapon weapon;
    [SerializeField] SpriteRenderer spriteRenderer;

    void Start()
    {
        weapon = new Weapon();

        spriteRenderer.sprite = Resources.Load<Sprite>("VioletFire");
        weapon.SetWeapon(new VioletFire());
    }

    public void ChangeFire()
    {
        spriteRenderer.sprite = Resources.Load<Sprite>("VioletFire");
        weapon.SetWeapon(new VioletFire());
    }

    public void ChangeCore()
    {
        spriteRenderer.sprite = Resources.Load<Sprite>("SpiritCore");
        weapon.SetWeapon(new SpiritCore());
    }

    public void Attack()
    {
        weapon.Attack();
    }
}
