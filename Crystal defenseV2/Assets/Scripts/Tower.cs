using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] GameObject panel;
    [SerializeField] bool isUpgraded = false;

    bool isClicked = false;
    public int Cost { get { return cost; } }

    public bool CreateTower(Tower tower, Vector3 position)
    {
        

        Bank bank = FindObjectOfType<Bank>();

        if(bank == null)
        {
            return false;
        }

        if(bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }

    private void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0) && !isUpgraded)
        {
            if (!isClicked)
            {
              panel.SetActive(true);
                isClicked = true;
            }
            else
            {
                panel.SetActive(false);
                isClicked = false;
            }
        }
    }

    
}
