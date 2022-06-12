using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    // Start is called before the first frame update
    public void TomarDaño(float daño)
    {
        vida -= daño;
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
