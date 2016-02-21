using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Animator         Anime;
    public Rigidbody2D      PlayerRigidbody;
    public int              JumpForce;
    public bool             slide;

    //Verifica o chão
    public Transform GroundCheck;
    public bool             grounded;
    public LayerMask WhatIsGround;

    //Slide
    public float SlideTemp;
    public float TimeTemp;

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
            slide = false;
        }

        if(Input.GetButtonDown("Slide") && grounded)
        {
            slide = true;
            TimeTemp = 0;
        }

        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, WhatIsGround);

        if(slide == true)
        {
            TimeTemp += Time.deltaTime;
            if(TimeTemp >= SlideTemp)
            {
                slide = false;
            }
        }

        Anime.SetBool("jump", !grounded);
        Anime.SetBool("slide", slide);

    }
}
