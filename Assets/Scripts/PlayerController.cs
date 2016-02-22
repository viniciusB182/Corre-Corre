using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Animator Anime;
    public Rigidbody2D PlayerRigidbody;

    //Pulo
    public int JumpForce;
    public bool slide;

    //Verifica o chão
    public Transform GroundCheck;
    public bool grounded;
    public LayerMask WhatIsGround;

    //Delize
    public float SlideTemp;
    public float TimeTemp;

    //Colisor
    public Transform Colidder;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            PlayerRigidbody.AddForce(new Vector2(0, JumpForce));
            if (slide)
            {
                Colidder.position = new Vector3(Colidder.position.x, Colidder.position.y + 0.325f);
                slide = false;
            }
        }

        if (Input.GetButtonDown("Slide") && grounded && !slide)
        {
            Colidder.position = new Vector3(Colidder.position.x, Colidder.position.y - 0.325f);
            slide = true;
            TimeTemp = 0;
        }

        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, WhatIsGround);

        if (slide == true)
        {
            TimeTemp += Time.deltaTime;
            if (TimeTemp >= SlideTemp)
            {
                Colidder.position = new Vector3(Colidder.position.x, Colidder.position.y + 0.325f);
                slide = false;
            }
        }

        Anime.SetBool("jump", !grounded);
        Anime.SetBool("slide", slide);

    }

    void OnTriggerEnter2D()
    {
        Debug.Log("Bateu");
    }
}
