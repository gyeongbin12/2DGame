using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Weapon weapon;

    [SerializeField] GameObject weaponObject;

    private IWeapon[] iWeapon = new IWeapon[2] { new SpiritCore(), new VioletFire() };

    void Start()
    {
        weapon = new Weapon();

    }

    public void SelectWeapon(int count)
    {
        weapon.SetWeapon(iWeapon[count]);

        switch (count)
        {
            case 0:
                weaponObject.GetComponent<SpriteRenderer>().sprite = weapon.WeaponShape("SpiritCore");
                break;
            case 1:
                weaponObject.GetComponent<SpriteRenderer>().sprite = weapon.WeaponShape("VioletFire");
                break;
        }

    }

    private void Update()
    {
        weapon.Attack(weaponObject);
    }
}
