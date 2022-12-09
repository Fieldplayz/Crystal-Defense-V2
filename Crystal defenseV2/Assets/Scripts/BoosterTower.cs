using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterTower : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ballista")
        {
            other.gameObject.tag = "BoostedBallista";
        }
        else if(other.gameObject.tag == "Turret")
        {
            other.gameObject.tag = "BoostedTurret";
        }
    }
}
