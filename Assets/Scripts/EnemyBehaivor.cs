using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaivor : MonoBehaviour
{
    private float health = 100;
    private float cronometro;
    private float grado;

    private int rutina;

    public Slider sliderHealth;

    private Animator animator;

    private Quaternion angulo;

    public GameObject target;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            health -= 5;
        }
    }

    void Start()
    {
       animator = GetComponent<Animator>(); 
       target = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {

        sliderHealth.value = health;

        if (health <= 0){
            animator.SetBool("dead", true);
            Destroy(gameObject, 2);
        }else {
            Enemy_Behaivor();
        }
    }

    public void Enemy_Behaivor() {
        if (Vector3.Distance(transform.position, target.transform.position) > 10)
        {
            animator.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;

            if (cronometro >= 4){
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    animator.SetBool("walk", false);
                    break;

                case 1:
                    grado = Random.Range(80, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 1);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    animator.SetBool("walk", true);
                    break;
            }
        } else {
            if (Vector3.Distance(transform.position, target.transform.position) > 1.5){
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 10);

                animator.SetBool("walk", false);
                animator.SetBool("run", true);

                transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                animator.SetBool("attack", false);
            } else {
                animator.SetBool("walk", false);
                animator.SetBool("run", false);

                animator.SetBool("attack", true);
            }
        }
    }
}
