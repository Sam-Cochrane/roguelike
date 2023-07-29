using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : BaseAttack
{
    public GameObject projectile;

    public override Type abilityStart()
    {
        castTime = baseCastTime;
        level = baseLevel;

        return null;
    }
    // Start is called before the first frame update
    public override Type abilityUpdate()
    {
        Debug.Log("Activating");

        timeUntilNextCast -= Time.deltaTime;
        if (timeUntilNextCast <= 0)
        {
            Attack();
            timeUntilNextCast = castTime;
        }

        return null;
    }

    public void Attack()
    {
        //if (level > maxLevel)
        //{
        //    level = maxLevel;
        //    //castTime = castTime * 0.8f;
        //}
        //AudioSource.PlayClipAtPoint(soundEffect, transform.position, volume);

        Debug.Log("Attack activated");

        switch (level)
        {
            case 1:

                Debug.Log("Arrow Lv1");

                Instantiate(projectile, spawn.position, Quaternion.Euler(0, 0, 0));

                break;

            case 2:

                for (int i = 0; i < 2; i++)
                {
                    GameObject bulletLv2 = Instantiate(projectile, spawn.position, Quaternion.Euler(0, 0, 0));
                    bulletLv2.GetComponent<TorchProjectile>().killTime = 1.2f;
                }


                break;

            case 3:

                for (int i = 0; i < 3; i++)
                {
                    GameObject bulletLv3 = Instantiate(projectile, spawn.position, Quaternion.Euler(0, 0, 0));
                    bulletLv3.GetComponent<TorchProjectile>().killTime = 1.4f;
                }

                break;

            case 4:

                for (int i = 0; i < 4; i++)
                {
                    GameObject bulletLv4 = Instantiate(projectile, spawn.position, Quaternion.Euler(0, 0, 0));
                    bulletLv4.GetComponent<TorchProjectile>().killTime = 1.6f;
                }


                break;

            case 5:

                for (int i = 0; i < 5; i++)
                {
                    GameObject bulletLv5 = Instantiate(projectile, spawn.position, Quaternion.Euler(0, 0, 0));
                    bulletLv5.GetComponent<TorchProjectile>().killTime = 1.8f;
                }

                break;

            default:

                for (int i = 0; i < 5; i++)
                {
                    GameObject bullet = Instantiate(projectile, spawn.position, Quaternion.Euler(0, 0, 0));
                    bullet.GetComponent<TorchProjectile>().killTime = bullet.GetComponent<TorchProjectile>().killTime * 1.2f;
                    bullet.GetComponent<TorchProjectile>().attack = bullet.GetComponent<TorchProjectile>().attack * 1.2f;
                }

                break;
        }
    }


    public override Type levelUp()
    {
        if (level < maxLevel)
        {
            Debug.Log("Level Up Achieved");
            level = level + 1;
            Debug.Log("Level = " + level);
            castTime = castTime * 0.8f;
        }

        return null;
    }
}
