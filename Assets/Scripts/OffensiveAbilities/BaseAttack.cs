using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{
    public float IDNum;
    public float baseCastTime;
    public float castTime;
    public float baseLevel;
    public float level;
    public float maxLevel;
    public float timeUntilNextCast;
    public AudioClip soundEffect;
    public float volume;
    public Vector3 pos;
    public float rotate;
    public Sprite icon;
    public Quaternion rotation;
    public Transform spawn;

    public abstract Type abilityStart();
    public abstract Type abilityUpdate();
    public abstract Type levelUp();

}
