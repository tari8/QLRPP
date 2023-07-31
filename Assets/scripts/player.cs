using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [Header("Mover")] 
    public float velocidade;
    private Rigidbody2D rigid;
    private Animator anim;

    [Header("Pulo")]
    public float forcapulo;
    private bool pulando;
    private bool puloduplo;

    [Header("Dash")]
    [SerializeField]
    private dash dash;

    [Header("No chão")]
    public Transform posicPe;
    public LayerMask ground;
    private bool noChao;

    private direcao dir;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        this.dir = direcao.direita;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.dash.DashUsado == false)
        {
            Mover();
            Pulo();
            Dash();
        }
    }

    void Mover()
    {
            float movimento = Input.GetAxis("Horizontal");

            rigid.velocity = new Vector2(movimento * velocidade, rigid.velocity.y);

            if (movimento == 0 && pulando == false)
            {
                anim.SetBool("run", false);
            }

            if (movimento > 0)
            {
                if (pulando == false)
                {
                    anim.SetBool("run", true);
                }
                
                transform.eulerAngles = new Vector3(0, 0, 0);
            this.dir = direcao.direita;
            }

            if (movimento < 0)
            {
                if (pulando == false)
                {
                    anim.SetBool("run", true);
                }
                
                transform.eulerAngles = new Vector3(0, 180, 0);
            this.dir = direcao.esquerda;
            }
     
    }
        void Pulo()
        {
                if (Input.GetButtonDown("Jump"))
                {
                    if (pulando == false)
                    {
                        anim.SetBool("jump", true);
                        rigid.AddForce(new Vector2(0, forcapulo), ForceMode2D.Impulse);
                        pulando = true;
                        puloduplo = true;
                    }
                    else if (puloduplo == true)
                    {
                        anim.SetBool("doublejump", true);
                        rigid.AddForce(new Vector2(0, forcapulo), ForceMode2D.Impulse);
                        puloduplo = false;
                        pulando = false;
                    }
                }
       

        }

        void OnCollisionEnter2D(Collision2D colidir)
        {
            if (colidir.gameObject.layer == 6)
            {
                anim.SetBool("jump", false);
                anim.SetBool("doublejump", false);
                pulando = false;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Espinhos"))
            {
                anim.SetTrigger("death");
                ReiniciarFase();
            }
        }

        void ReiniciarFase()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Dash()
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                this.dash.AplicarDash(this.dir);
            }
        }

       


    
}
