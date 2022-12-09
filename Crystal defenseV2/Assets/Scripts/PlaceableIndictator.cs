using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableIndictator : MonoBehaviour
{
    [SerializeField] GameObject canPlaceBallista;
    [SerializeField] GameObject cannotPlaceBallista;

    [SerializeField] GameObject canPlaceTurret;
    [SerializeField] GameObject cannotPlaceTurret;

    [SerializeField] GameObject canPlaceBooster;
    [SerializeField] GameObject cannotPlaceBooster;

    bool isPlaceable;

    int currentBalance;
    int cost;

    private void Awake()
    {
        isPlaceable = GetComponent<Waypoint>().IsPlaceable;
        currentBalance = FindObjectOfType<Bank>().CurrentBalance;
        
    }

    private void OnMouseOver()
    {
        int tower = PlayerPrefs.GetInt("Tower");
        isPlaceable = GetComponent<Waypoint>().IsPlaceable;
        currentBalance = FindObjectOfType<Bank>().CurrentBalance;

        if (isPlaceable)
        {
            if(tower == 1)
            {
                if (currentBalance < 75)
                {
                    cannotPlaceBallista.SetActive(true);
                    canPlaceBallista.SetActive(false);
                }
                else
                {
                    cannotPlaceBallista.SetActive(false);
                    canPlaceBallista.SetActive(true);
                }
            }
            else if(tower == 2)
            {
                if (currentBalance < 200)
                {
                    cannotPlaceTurret.SetActive(true);
                    canPlaceTurret.SetActive(false);
                }
                else
                {
                    cannotPlaceTurret.SetActive(false);
                    canPlaceTurret.SetActive(true);
                }
            }

            else if(tower == 3)
            {
                if(currentBalance < 200)
                {
                    cannotPlaceBooster.SetActive(true);
                    canPlaceBooster.SetActive(false);
                }
                else
                {
                    cannotPlaceBooster.SetActive(false);
                    canPlaceBooster.SetActive(true);
                }
            }
            
        }
       
    }

    private void OnMouseExit()
    {
        cannotPlaceBallista.SetActive(false);
        canPlaceBallista.SetActive(false);

        cannotPlaceTurret.SetActive(false);
        canPlaceTurret.SetActive(false);

        canPlaceBooster.SetActive(false);
        cannotPlaceBooster.SetActive(false);
    }
}
