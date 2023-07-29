using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : BaseAttack
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

                GameObject bulletLv1 = Instantiate(projectile, spawn.position, Quaternion.Euler(0,0,0));
                bulletLv1.GetComponent<HammerProjectile>().level = level;

                break;

            case 2:

                for (int i = 0; i < 2; i++)
                {
                    GameObject bulletLv2 = Instantiate(projectile, spawn.position, Quaternion.Euler(0, 0, 0));
                    bulletLv2.GetComponent<HammerProjectile>().level = level;
                }


                break;

            case 3:

                for (int i = 0; i < 3; i++)
                {
                    GameObject bulletLv3 = Instantiate(projectile, spawn.position, Quaternion.Euler(0, 0, 0));
                    bulletLv3.GetComponent<HammerProjectile>().level = level;
                }

                break;

            case 4:

                for (int i = 0; i < 4; i++)
                {
                    GameObject bulletLv4 = Instantiate(projectile, spawn.position, Quaternion.Euler(0, 0, 0));
                    bulletLv4.GetComponent<HammerProjectile>().level = level;
                }


                break;

            case 5:

                for (int i = 0; i < 5; i++)
                {
                    GameObject bulletLv5 = Instantiate(projectile, spawn.position, Quaternion.Euler(0, 0, 0));
                    bulletLv5.GetComponent<HammerProjectile>().level = level;
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
