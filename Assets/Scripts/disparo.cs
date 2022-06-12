using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    private Rigidbody2D MyRb;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MyRb.velocity = new Vector2(+Speed, 0);
        Destroy(gameObject, 7f);
    }
    //Time.deltaTime-> La velocidad se va a manejar a corde a la velocidad del mundo real y no al del procesador
}
