using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplat : MonoBehaviour
{
    [SerializeField] private GameObject[] moveponts;
    private int movePontoAtual = 0;

    [SerializeField] private float veloc = 2f;
    private void Update()
    {
        if(Vector2.Distance(moveponts[movePontoAtual].transform.position, transform.position) < .1f)
        {
            movePontoAtual++;
            if(movePontoAtual >= moveponts.Length)
            {
                movePontoAtual = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, moveponts[movePontoAtual].transform.position, Time.deltaTime * veloc);
    }
}
