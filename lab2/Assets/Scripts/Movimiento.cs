using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public RuntimeAnimatorController Run;
    public RuntimeAnimatorController Idle;
    public RuntimeAnimatorController Jump;
    public Sprite down;
    public float fltUpdatePositionX;
    public float fltAxisY;

    private bool Salto;
    private bool Move;

    void Start()
    {
        Salto = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Suelo")
            Salto = false;

    }
    void Update()
    {

        fltUpdatePositionX = Input.GetAxis("Horizontal") * Time.deltaTime * 6;
        fltAxisY = Input.GetAxis("Vertical");
        this.transform.position += new Vector3(fltUpdatePositionX, 0, 0);

        if (fltUpdatePositionX > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (fltUpdatePositionX < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (fltUpdatePositionX != 0 && Salto == false)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = Run;
        }

        else if(fltUpdatePositionX == 0 && Salto == false)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = Idle;
        }

        if ((Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.W))) && Salto == false)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
            Salto = true;
            this.GetComponent<Animator>().runtimeAnimatorController = Jump;
        }

       /* if (this.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0))
        {
            Salto = false;
        }*/
    }
}