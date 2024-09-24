using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueborly : MonoBehaviour
{
    public GameObject laser1;
    //public GameObject laser2;

    public float rotateSpeed;
    public float moveSpeed;

    Rigidbody rb;
    public Transform player;

    public float attackDuration = 3f;
    public float attackInterval = 6f; // Tiempo mínimo entre ataques
    public float attackRange = 10f;

    private float lastAttackTime;
    private float currentAttackTime;

    //[SerializeField] PorlyRagdoll pr;

    [SerializeField] Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        laser1.SetActive(false);
        //laser2.SetActive(false);
        //pr = GetComponent<PorlyRagdoll>();
        lastAttackTime = -attackInterval; // Configura el último tiempo de ataque para permitir el primer ataque

        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        /*if (pr.canAttack)
        {
            if (Time.time > lastAttackTime + attackInterval)
            {
                if (Vector3.Distance(transform.position, player.position) < attackRange)
                {
                    // Comienza un nuevo ataque
                    if (currentAttackTime <= attackDuration)
                    {
                        laser1.SetActive(true);
                        //laser2.SetActive(true);
                        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, rotateSpeed * Time.deltaTime, 0f));
                        currentAttackTime += Time.deltaTime;

                        animator.SetBool("Attack", true);
                    }
                    // Finaliza el ataque y se inicia el temporizador para el próximo ataque
                    else
                    {
                        laser1.SetActive(false);
                        //laser2.SetActive(false);
                        lastAttackTime = Time.time;
                        currentAttackTime = 0f;
                        animator.SetBool("Attack", false);
                        transform.LookAt(player);
                    }
                }
                // El enemigo no está en rango de ataque
                else
                {
                    laser1.SetActive(false);
                    //laser2.SetActive(false);
                    currentAttackTime = 0f; // Reinicia el temporizador de ataque

                    Vector3 direction = (player.position - transform.position).normalized;
                    rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
                    transform.LookAt(player);
                    animator.SetBool("Attack", false);
                }
            }

        }

        if (pr.vida <= 0)
        {
            laser1.SetActive(false);
        }*/
    }
}
