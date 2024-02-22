using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstMod : MonoBehaviour
{
    public Weapon weapon;
    public bool isBursting;

    public void Burst()
    {
        isBursting = !isBursting;

        if(isBursting )
        {
            weapon.bulletsPerShot = 3;
            weapon.isAutomatic = false;
        }
        if(!isBursting )
        {
            weapon.bulletsPerShot = 1;
            weapon.isAutomatic = true;
        }
    }
}
