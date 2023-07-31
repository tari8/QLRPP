using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camforplayer : MonoBehaviour
{

    public Transform player;
    public float movesuave;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 seguindo = new Vector3(player.position.x, player.position.y + 1f, -1f);
        Vector3 posicaoSuave = Vector3.Lerp(transform.position, seguindo, movesuave);
        transform.position = posicaoSuave;
    }
}
