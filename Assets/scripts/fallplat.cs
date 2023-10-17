using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallplat : MonoBehaviour
{

    private float fallDelay = 1f;
    private float destroyDelay = 2f;

    [SerializeField]
    private Rigidbody2D rigid;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(fall());
        }
    }
    private IEnumerator fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rigid.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
