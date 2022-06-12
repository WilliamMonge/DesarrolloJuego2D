using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class disparoenemigo : MonoBehaviour
{
    public float bulletSpeed;
    public float spawnTime; //tiempoentre que sale una bala
    public GameObject spawner; //obeto de donde sale las balas
    public GameObject bulletPrefab; //Objeto de la bala
    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter > spawnTime)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, spawner.transform, true);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, bullet.GetComponent<Rigidbody2D>().velocity.y);
            counter = 0;
        }
    }
}
