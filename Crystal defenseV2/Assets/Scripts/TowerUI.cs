using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    [SerializeField] GameObject turret1;
    [SerializeField] GameObject turret2;
    [SerializeField] int upgradeCost = 150;
    
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }

    public void UpgradeTower()
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank.CurrentBalance >= upgradeCost) 
        {
            Instantiate(turret2, turret1.transform.position, Quaternion.identity);
            bank.Withdraw(upgradeCost);
            turret1.SetActive(false);
            
        }
        else
        {
            return;
        }
    }

    public void RemoveTower()
    {
        Destroy(turret1);
    }
}
