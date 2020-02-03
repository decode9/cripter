using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerController;
    public PlayerInput jugador;
    public int velocidad;
    private Animator animator;

    private SpriteRenderer sprite;
    public bool activePlayer;

void Start()
    {
        playerController = this;
        velocidad = 5;
        activePlayer = true;
        jugador = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    

    // Update is called once per frame
    void Update()
    {
        if(activePlayer) {
            Vector3 oldposition = transform.position;
            Vector3 position = oldposition + (new Vector3(jugador.horizontal, jugador.vertical, 0) * velocidad * Time.deltaTime);
            transform.position = position;

            animator.SetFloat("X", jugador.horizontal);
            animator.SetFloat("Y", jugador.vertical);
            animator.SetBool("Run", (jugador.horizontal != 0 || jugador.vertical != 0));

            sprite.flipX = (jugador.horizontal < 0|| jugador.vertical < 0);

            if(jugador.Pause) {
                activePlayer = false;
                Insta.insta.PauseGame();
                TimerManager.timepo.initate();
            }
        }
    }
}
