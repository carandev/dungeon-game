using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 2;
    public int turnSpeed = 40;
    public int jumpSpeed = 5;
    private Animator animator;
    void Start()
    {
       animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
      float movementHorizontal = Input.GetAxis("Horizontal");
      float movementVertical = Input.GetAxis("Vertical");
      float mouseX = Input.GetAxis("Mouse X");
      float jump = Input.GetAxis("Jump");

      if (movementHorizontal != 0 || movementVertical != 0){
        animator.SetBool("isWalking", true);
      } else {
        animator.SetBool("isWalking", false);
      }

      if (jump != 0) {
          animator.SetBool("isJumping", true);
      } else {
          animator.SetBool("isJumping", false);
      }
        
      transform.Translate(Vector3.forward * speed * Time.deltaTime * movementVertical);    
      transform.Translate(Vector3.right * speed * Time.deltaTime * movementHorizontal);
      transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime * jump);

      transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * movementHorizontal);
    }
}
