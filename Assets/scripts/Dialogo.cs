using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour
{

    public FalaNPC[] falas = new FalaNPC[2];

    public bool dialogconcluido = false;

    dialogocontrole dialcont;
    // Start is called before the first frame update
    void Start()
    {
        dialcont = FindObjectOfType<dialogocontrole>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<player>().velocidade = 0;

            if(!dialogconcluido)
            {
                dialcont.ProximaFala(falas[0]);
            }
            else
            {
                dialcont.ProximaFala(falas[1]);
            }

            dialogconcluido = true;
        }
    }
}
