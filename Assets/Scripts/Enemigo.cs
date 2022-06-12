using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    // Start is called before the first frame update
    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
        if (vida <= 0)
        {
            Muerte();
        }
    }
    private void Muerte()
    {
        Destroy(gameObject);
    }
}
