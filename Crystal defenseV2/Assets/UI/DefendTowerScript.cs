using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefendTowerScript : MonoBehaviour
{
    public Slider timerSlider;

    public float timerAmount;

    [HideInInspector]
    public bool resetTimer;

    [HideInInspector]
    public bool timerFull;

    [HideInInspector]
    public bool destroyEnemies;

    [HideInInspector]
    public bool enemiesInRange;




    void Start()
    {
        timerSlider.maxValue = timerAmount;
        timerSlider.value = timerSlider.maxValue;
    }

    void Update()
    {
        float time = timerSlider.value += Time.deltaTime;
        timerSlider.value = time;

        if (timerSlider.value >= timerAmount)
        {
            timerFull = true;
        }

        if (timerSlider.value < timerAmount)
            timerFull = false;

        if (resetTimer == true)
        {
            timerSlider.value = 0;
            resetTimer = false;
        }

        Debug.Log(enemiesInRange);

            
    }

    public void DefendTower()
    {
        if (timerFull && enemiesInRange)
        {
            destroyEnemies = true;
            resetTimer = true;

        }





        //Damage Etc. doen aan enemies die in een bepaalde radius staan.
    }

    private void OnTriggerStay(Collider other)
    {
       
        if (destroyEnemies && timerFull && other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);

            destroyEnemies = false;
            enemiesInRange = false;

        }

        if (other.gameObject.CompareTag("Enemy"))
        {       
            enemiesInRange = true;
        }
    }


}
