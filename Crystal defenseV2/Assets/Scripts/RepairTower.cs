using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairTower : MonoBehaviour
{
    [SerializeField] int damageMin = 10;
    [SerializeField] int damageMax = 20;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] ParticleSystem smokeParticles;


    int RandomRepair;
    int damage = 0;
    bool needRepair = false;
    bool damageDone = true;

    public bool NeedRepair { get { return needRepair; } }

    private void Start()
    {
        RandomRepair = UnityEngine.Random.Range(damageMin, damageMax);
        Debug.Log(RandomRepair);
        damage = 0;
    }

    private void Update()
    {
      
        if(projectileParticles.particleCount == 2)
        {
            CheckForRepair(damage);
        }
        
    }

    public void CheckForRepair(int damages)
    {
        if(damages >= damageMin)
        {

            if(damages == RandomRepair)
            {
                Damaged();
            }
        }
    }

    public void AddDamage()
    {
        if(damage > 0 && damageDone)
        {
            damage = 0;
            damageDone = false;
        }
        damage = damage + 1;
        Debug.Log(damage);
    }

    public void Damaged()
    {
        projectileParticles.gameObject.SetActive(false);
        smokeParticles.Play();
    }
}
