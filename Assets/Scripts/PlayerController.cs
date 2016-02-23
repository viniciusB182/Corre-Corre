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

    //Deslize
    public float SlideTemp;
    public float TimeTemp;

    //Colisor
    public Transform Colidder;

    //Audio
    public AudioSource Audio;
    public AudioClip SoundJump;
    public AudioClip SoundSlide;

    //Pontuacao
    public UnityEngine.UI.Text TxtPontos;
    public static int Pontuacao;

    // Use this for initialization
    void Start()
    {
        Pontuacao = 0;
        PlayerPrefs.SetInt("Pontuacao", Pontuacao);
    }

    // Update is called once per frame
    void Update()
    {
        TxtPontos.text = Pontuacao.ToString();

        if (Input.GetButtonDown("Jump") && grounded)
        {
            PlayerRigidbody.AddForce(new Vector2(0, JumpForce));

            Audio.PlayOneShot(SoundJump);
            Audio.volume = 1;

            if (slide)
            {
                Colidder.position = new Vector3(Colidder.position.x, Colidder.position.y + 0.325f);
                slide = false;
            }
        }

        if (Input.GetButtonDown("Slide") && grounded && !slide)
        {
            Audio.PlayOneShot(SoundSlide);
            Audio.volume = 0.5f;
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
        PlayerPrefs.SetInt("Pontuacao", Pontuacao);

        if (Pontuacao > PlayerPrefs.GetInt("Recorde"))
        {
            PlayerPrefs.SetInt("Recorde", Pontuacao);
        }

        Application.LoadLevel("GameOver");
    }
}
