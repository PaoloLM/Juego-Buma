using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private Animator animator;
    public float fuerzaSalto;
    int cantsalto;
    private Rigidbody2D rigidbody2D;
    public GameManager gameManager;
    public bool desactivar = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cantsalto < 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Saltando", true);
                rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
                cantsalto++;
                AudioManager.obj.playJump();
            }
        }   
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Suelo") {
            cantsalto = 0;
            animator.SetBool("Saltando", false);
        }

        if(collisionInfo.gameObject.tag == "Obtaculo") {
            gameManager.gameOver = true;
            AudioManager.obj.playEnemyHit();

        }

    }
}