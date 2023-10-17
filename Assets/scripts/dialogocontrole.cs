using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogocontrole : MonoBehaviour
{

    public GameObject painelDialogo;

    public Text falaNPC;

    public GameObject resposta;

    private bool falaAtiva = false;


    FalaNPC falas;
    // Start is called before the first frame update
    void Start()
    {
        painelDialogo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && falaAtiva)
        {
            if(falas.respostas.Length > 0)
            {
                MostrarRespostas();
            }
            else
            {
                falaAtiva = false;
                painelDialogo.SetActive(false);
                falaNPC.gameObject.SetActive(false);
                FindObjectOfType<player>().velocidade = 6;
            }
        }
    }

    void MostrarRespostas()
    {
        falaNPC.gameObject.SetActive(false);
        falaAtiva = false;

        for (int i = 0; i < falas.respostas.Length; i++)
        {
            GameObject tempResposta = Instantiate(resposta, painelDialogo.transform) as GameObject;
            tempResposta.GetComponent<Text>().text = falas.respostas[i].resposta;
            tempResposta.GetComponent<botaoResposta>().Setup(falas.respostas[i]);
        }
    }

    public void ProximaFala(FalaNPC fala)
    {
        falas = fala;
        LimparRespostas();
        falaAtiva = true;
        painelDialogo.SetActive(true);
        falaNPC.gameObject.SetActive(true);

        falaNPC.text = falas.falanpc;
    }

    void LimparRespostas()
    {
        botaoResposta[] buttons = FindObjectsOfType<botaoResposta>();
        foreach(botaoResposta button in buttons)
        {
            Destroy(button.gameObject);
        }

    }
}
