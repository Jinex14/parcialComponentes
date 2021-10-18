using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma : MonoBehaviour
{
    private float alt;
    private int aux = 0;
    private Vector2 originalPos;
    private void Awake()
    {
        alt = Random.Range(-4.01f, 4.45f);
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(10.32f, alt);
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(aux == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position,new Vector2(-10.42f,alt),7*Time.deltaTime);
            if(transform.position.x <= -10.42f)
            {
                StartCoroutine(volver());
            }
        }

        if(aux == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPos, 7 * Time.deltaTime);
            if (transform.position.x >= 10.32f)
            {
                StartCoroutine(reset());
            }
        }
    }

    private IEnumerator volver()
    {
        aux = 1;
        var waitRandom = (int)Random.Range(3,8);
        yield return new WaitForSeconds(waitRandom);
        aux = 2;
    }

    private IEnumerator reset()
    {
        aux = 3;
        yield return new WaitForSeconds(1);
        alt = Random.Range(-4.01f, 4.45f);
        transform.position = new Vector2(10.32f, alt);
        originalPos = transform.position;
        aux = 0;
    }
}
