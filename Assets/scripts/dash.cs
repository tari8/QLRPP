using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{

    private const int velocParticulas = 7;

    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    private float velocidadeDash;


    private bool usaDash;
    private float contTempoDash;

    [SerializeField]
    private float intervUso;

    private float contInter;

    private bool podeUsar;

    [SerializeField]
    private float duracaoDash;

    private direcao direcaoDash;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private ParticleSystem particulas;
    private ParticleSystem.MainModule moduloParticula;
    private ParticleSystemRenderer particRenderer;

    // Start is called before the first frame update
    void Start()
    {
        this.usaDash = false;
        this.contTempoDash = 0;
        this.contInter = 0;
        this.podeUsar = true;
        this.particulas.Stop();
        this.moduloParticula = this.particulas.main;
        this.particRenderer = this.particulas.GetComponent<ParticleSystemRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.usaDash)
        {
            this.contTempoDash += Time.deltaTime;
            if(this.contTempoDash >= this.duracaoDash)
            {
                this.contTempoDash = 0;
                this.usaDash = false;
                this.anim.SetBool("dash", false);
                this.particulas.Stop();
            }
            else
            {
                if (this.direcaoDash == direcao.direita)
                {
                    this.moduloParticula.startSpeed = velocParticulas;
                    this.particRenderer.flip = Vector3.zero;
                    this.rigid.velocity = new Vector2(this.velocidadeDash, 0);
                }
                else 
                {
                    this.moduloParticula.startSpeed = -velocParticulas;
                    this.particRenderer.flip = Vector3.right;
                    this.rigid.velocity = new Vector2(-this.velocidadeDash, 0);
                }
                
            }
        }

        else
        {
            if(!this.podeUsar)
            {
                this.contInter += Time.deltaTime;

                if(contInter >= this.intervUso)
                {
                    this.contInter = 0;
                    this.podeUsar = true;
                }
            }
        }
            
    }

    public bool DashUsado
    {
        get
        {
            return this.usaDash;
        }
    }

    public void AplicarDash(direcao direcao)
    {
        if(this.podeUsar)
        {
            this.direcaoDash = direcao;
            this.usaDash = true;
            this.podeUsar = false;
            this.anim.SetBool("dash", true);
            this.particulas.Play();
        }
       
    }
}
