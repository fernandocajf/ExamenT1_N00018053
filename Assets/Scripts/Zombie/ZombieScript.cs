using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidbodyZombie;
    public Animator animatorZombie;
    public SpriteRenderer spriteZombie;

    private const int animatorZombieCaminar = 1;
    private const int animatorZombieAtacar = 2;
    private const int animatorZombieMorir = 3;

    private bool zombieAtacar = false;
    private bool chocarKunai = false;
    public float tiempodeVida = 1f;

    void Start()
    {
        rigidbodyZombie = GetComponent<Rigidbody2D>();
        animatorZombie = GetComponent<Animator>();
        spriteZombie = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (zombieAtacar)
        {
            animatorZombie.SetInteger("Estado", animatorZombieAtacar);
            rigidbodyZombie.velocity = new Vector2(0, rigidbodyZombie.velocity.y);
        }
        else
        {
            rigidbodyZombie.velocity = new Vector2(-5, rigidbodyZombie.velocity.y);
            animatorZombie.SetInteger("Estado", animatorZombieCaminar);
 
            if (chocarKunai)
            {
                animatorZombie.SetInteger("Estado", animatorZombieMorir);
                Destroy(gameObject, tiempodeVida);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {
            zombieAtacar = true;
        }
        if (collision.gameObject.tag.Equals("Kunai"))
        {
            chocarKunai = true;
        }

    }
}
