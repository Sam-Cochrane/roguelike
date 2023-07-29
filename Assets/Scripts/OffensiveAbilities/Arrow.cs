using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : BaseAttack
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
        if (level > maxLevel)
        {
            level = maxLevel;
            //castTime = castTime * 0.8f;
        }
        //AudioSource.PlayClipAtPoint(soundEffect, transform.position, volume);

        Debug.Log("Attack activated");

        switch (level)
        {
            case 1:

                Debug.Log("Arrow Lv1");

                GameObject bulletLv1 = Instantiate(projectile, spawn.position, spawn.rotation);
                Rigidbody2D rbLv1 = bulletLv1.GetComponent<Rigidbody2D>();
                rbLv1.AddForce(spawn.transform.up * 5.0f, ForceMode2D.Impulse);

                break;

            case 2:

                for(int i = 0; i < 2; i++)
                {
                    GameObject bulletLv3_1 = Instantiate(projectile, spawn.position, spawn.rotation);
                    bulletLv3_1.GetComponent<ArrowProjectile>().attack = bulletLv3_1.GetComponent<ArrowProjectile>().attack * 1.2f;
                    Rigidbody2D rbLv3_1 = bulletLv3_1.GetComponent<Rigidbody2D>();
                    rbLv3_1.AddForce(spawn.transform.up * (5.0f - i), ForceMode2D.Impulse);
                }


                break;

            case 3:

                GameObject alteredProjectile = projectile;
                alteredProjectile.transform.localScale.Set(2.0f, 2.0f, 2.0f);

                for (int i = 0; i < 2; i++)
                {
                    GameObject bulletLv3_1 = Instantiate(alteredProjectile, spawn.position, spawn.rotation);
                    bulletLv3_1.GetComponent<ArrowProjectile>().attack = bulletLv3_1.GetComponent<ArrowProjectile>().attack * 1.2f;
                    Rigidbody2D rbLv3_1 = bulletLv3_1.GetComponent<Rigidbody2D>();
                    rbLv3_1.AddForce(spawn.transform.up * (5.0f - i), ForceMode2D.Impulse);
                }

                break;

            case 4:

                GameObject alteredProjectileLv2 = projectile;
                alteredProjectileLv2.transform.localScale.Set(2.0f, 2.0f, 2.0f);

                for (int i = 0; i < 3; i++)
                {

                    GameObject bulletLv4_1 = Instantiate(alteredProjectileLv2, spawn.position, spawn.rotation);
                    bulletLv4_1.GetComponent<ArrowProjectile>().attack = bulletLv4_1.GetComponent<ArrowProjectile>().attack * 1.2f;
                    Rigidbody2D rbLv4_1 = bulletLv4_1.GetComponent<Rigidbody2D>();
                    rbLv4_1.AddForce(spawn.transform.up * (5.0f - i), ForceMode2D.Impulse);
                }


                break;

            case 5:

                GameObject alteredProjectileLv3 = projectile;
                alteredProjectileLv3.transform.localScale.Set(2.0f, 2.0f, 2.0f);

                for (int i = 0; i < 4; i++)
                {
                    GameObject bulletLv5_1 = Instantiate(alteredProjectileLv3, spawn.position, spawn.rotation);
                    bulletLv5_1.GetComponent<ArrowProjectile>().attack = bulletLv5_1.GetComponent<ArrowProjectile>().attack * 1.2f;
                    Rigidbody2D rbLv5_1 = bulletLv5_1.GetComponent<Rigidbody2D>();
                    rbLv5_1.AddForce(spawn.transform.up * (5.0f - i), ForceMode2D.Impulse);
                }

                break;

            default:

                GameObject alteredProjectileLv = projectile;
                alteredProjectileLv.transform.localScale.Set(2.0f, 2.0f, 2.0f);

                for (int i = 0; i < 4; i++)
                {
                    GameObject bulletLv5_1 = Instantiate(alteredProjectileLv, spawn.position, spawn.rotation);
                    bulletLv5_1.GetComponent<ArrowProjectile>().attack = bulletLv5_1.GetComponent<ArrowProjectile>().attack * 1.2f;
                    Rigidbody2D rbLv5_1 = bulletLv5_1.GetComponent<Rigidbody2D>();
                    rbLv5_1.AddForce(spawn.transform.up * (5.0f - i), ForceMode2D.Impulse);
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
