using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject enemyPrefab;
    public LevelScript levelObject;
    public Text levelText;

    private int enemyNumber;
    private int level = 1;

    void Start()
    {
        createEnemy(level);  
        levelObject.showObject();
        Invoke("hideText", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        enemyNumber = FindObjectsOfType<EnemyBehaivor>().Length;

        if (enemyNumber == 0){
            level++;
            levelText.text = "Level " + level;
            levelObject.showObject();
            Invoke("hideText", 4f);
            createEnemy(level);
        } 
    }

    public void createEnemy(int level){
        for (int i = 0; i < level; i++){
            Instantiate(enemyPrefab, new Vector3(Random.Range(-26, 6), 3, Random.Range(-9, 25)), enemyPrefab.transform.rotation); 
        }
    }

    public void hideText(){
        levelObject.hideObject();
    }
}
