using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public void showObject(){
        gameObject.SetActive(true);
    }

    public void hideObject(){
        gameObject.SetActive(false);
    }
}
