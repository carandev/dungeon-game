using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private int speed = 5;
    private int turnSpeed = 100;
    private int jumpSpeed = 5;
    private float maxHealth = 200;
    private float health = 200;
    public Image healthImage;
    private Animator animator;
    public GameOverScreen gameOverScreen;
    public GameObject player;

    void Start()
    {
       animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy"))
        {
            health -= 1;
        }
    }

    void Update()
    {
      float movementHorizontal = Input.GetAxis("Horizontal");
      float movementVertical = Input.GetAxis("Vertical");
      float mouseX = Input.GetAxis("Mouse X");
      float fire = Input.GetAxis("Fire1");
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

      if (fire != 0)
      {
          animator.SetBool("isAttacking", true);
      } else {
          animator.SetBool("isAttacking", false);
      }

      if (health < 0){
        animator.SetBool("isDead", true);
        Destroy(player, 4);
        gameOverScreen.Setup();
      }
        
      transform.Translate(Vector3.forward * speed * Time.deltaTime * movementVertical);    
      transform.Translate(Vector3.right * speed * Time.deltaTime * movementHorizontal);
      transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime * jump);

      transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * movementHorizontal);

      healthImage.fillAmount = health / maxHealth;
    }

    public void LoadScene(){
        SceneManager.LoadScene("MainScene");
    }

}
