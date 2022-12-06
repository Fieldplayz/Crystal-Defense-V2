using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower balista;
    [SerializeField] Tower turret;


    [SerializeField] bool isPlaceable;
    public bool IsPlaceable{ get { return isPlaceable;} }


    private void OnMouseOver()
    {
        int tower = PlayerPrefs.GetInt("Tower");

        if (Input.GetMouseButtonDown(0) && isPlaceable)
        {
            if(tower == 1)
            {
                bool isPlaced = balista.CreateTower(balista, transform.position);
                isPlaceable = !isPlaced;
                PlayerPrefs.SetInt("Tower", 0);
            }
            else if(tower == 2)
            {
                bool isPlaced = turret.CreateTower(turret, transform.position);
                isPlaceable = !isPlaced;
                PlayerPrefs.SetInt("Tower", 0);
            }
        }
        
    }

   
}
