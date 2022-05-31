using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaivor : MonoBehaviour
{
    public float alertRange;
    public LayerMask playerLayer;
    public float speed;
    public Transform player;
    private Animator animator;
    bool isAlert;

    void Start()
    {
       animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        isAlert = Physics.CheckSphere(transform.position, alertRange, playerLayer);

        if (isAlert)
        {
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            animator.SetBool("walk", true);
        } else {
            animator.SetBool("walk", false);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alertRange);
    }
}
