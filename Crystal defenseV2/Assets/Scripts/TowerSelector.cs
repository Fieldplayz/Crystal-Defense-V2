using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    
    public void Start()
    {
        PlayerPrefs.SetInt("Tower", 0); 
    }

    public void Ballista()
    {
        PlayerPrefs.SetInt("Tower", 1);
    }

    public void Turret()
    {
        PlayerPrefs.SetInt("Tower", 2);
    }

}
