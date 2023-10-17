using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botaoResposta : MonoBehaviour
{
    Resposta respostaData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProxFala()
    {
        FindObjectOfType<dialogocontrole>().ProximaFala(respostaData.proxfala);
    }

    public void Setup(Resposta resp)
    {
        respostaData = resp;
    }
}
