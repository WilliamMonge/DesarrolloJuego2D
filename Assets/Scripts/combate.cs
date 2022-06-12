using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combate : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañogolpe;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Golpea();
        }
    }

    public void Golpea()
    {
        animator.SetTrigger("golpea");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);
        foreach (Collider2D colicionador in objetos)
        {
            if (colicionador.CompareTag("Enemigo"))
            {
                colicionador.transform.GetComponent<Enemigo>().TomarDaño(dañogolpe);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
