using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefeat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy"))
        {
           Debug.Log("Jugador dañado"); 
        }    
    }
}
