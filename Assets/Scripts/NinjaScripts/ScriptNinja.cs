using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptNinja : MonoBehaviour
{

    public float velocidadNinja = 12f;
    public Vector2 direccionNinja;

    public Rigidbody2D rigidbodyNinja;
    public Animator animatorNinja;
    public SpriteRenderer spriteNinja;
    public Transform transformNinja;

    public GameObject Kunai;
    private Vector3 _firePoint;

    private const int animatorNinjaQuieto = 0;
    private const int animatorNinjaCorrer = 1;
    private const int animatorNinjaSaltar = 2;
    private const int animatorNinjaAtack = 3;
    private const int animatorNinjaMorir = 4;

    private bool chocarZombie = false;
    private bool muertoNinja = false;

    void Start()
    {
        rigidbodyNinja = GetComponent<Rigidbody2D>();
        animatorNinja = GetComponent<Animator>();
        spriteNinja = GetComponent<SpriteRenderer>();
        transformNinja = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if( muertoNinja != true) { 
            rigidbodyNinja.velocity = new Vector2(0, rigidbodyNinja.velocity.y);
            animatorNinja.SetInteger("Estado", animatorNinjaQuieto);
            if (Input.GetKeyDown(KeyCode.W))
            {
                animatorNinja.SetInteger("Estado", animatorNinjaAtack);
                disparar(_firePoint);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) && muertoNinja != true)
        {
            spriteNinja.flipX = false;
            animatorNinja.SetInteger("Estado", animatorNinjaCorrer);

            //rigidbodyNinja.velocity = new Vector2(10, rigidbodyNinja.velocity.y);
            direccionNinja = Vector2.right;
            Vector2 movimiento = direccionNinja.normalized * velocidadNinja * Time.deltaTime;
            transformNinja.Translate(movimiento);

            _firePoint = new Vector3(transformNinja.position.x + 1.64f, transformNinja.position.y - 0.049f, 0);

            if (Input.GetKeyDown(KeyCode.W))
            {
                animatorNinja.SetInteger("Estado", animatorNinjaAtack);
                disparar(_firePoint);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) && muertoNinja != true)
        {
            animatorNinja.SetInteger("Estado", animatorNinjaCorrer);
            spriteNinja.flipX = true;

            //rigidbodyNinja.velocity = new Vector2(-10, rigidbodyNinja.velocity.y);
            direccionNinja = Vector2.left;
            Vector2 movimiento = direccionNinja.normalized * velocidadNinja * Time.deltaTime;
            transformNinja.Translate(movimiento);

            _firePoint = new Vector3(transformNinja.position.x - 1.64f, transformNinja.position.y - 0.049f, 0);
            if (Input.GetKeyDown(KeyCode.W))
            {
                animatorNinja.SetInteger("Estado", animatorNinjaAtack);
                disparar(_firePoint);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && muertoNinja != true)
        {
            rigidbodyNinja.AddForce(new Vector2(0, 50), ForceMode2D.Impulse);

            animatorNinja.SetInteger("Estado", animatorNinjaSaltar);
        }

        if (chocarZombie)
        {
            animatorNinja.SetInteger("Estado", animatorNinjaMorir);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Zombie"))
        {
            Debug.Log("Fue atacado por un zombie, ha muerto");
            chocarZombie = true;
            muertoNinja = true;
        }
    }

    void disparar(Vector3 _firePoint)
    {
        if (Kunai != null && _firePoint != null && this.gameObject != null)
        {
            GameObject myKunai = Instantiate(Kunai, _firePoint, Quaternion.identity) as GameObject;

            Kunai kunaiComponent = myKunai.GetComponent<Kunai>();
            SpriteRenderer kunaiSr = myKunai.GetComponent<SpriteRenderer>();
            if (spriteNinja.flipX == true)
            {
                kunaiSr.flipX = true;
                kunaiComponent.direccion = Vector2.left;
            }
            if (spriteNinja.flipX == false)
            {
                kunaiSr.flipX = false;
                kunaiComponent.direccion = Vector2.right;
            }
        }
    }
}
