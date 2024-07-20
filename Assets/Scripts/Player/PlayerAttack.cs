using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackDelay = 1f; //надо переделать так, чтобы это значение бралось от активного оружия
    public bool isAttacking = false;
    public CameraCursor cameraCursor;
    private Animator animator;

    void Start()
    {
        cameraCursor = GetComponent<CameraCursor>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking)
        {
            Attack();
        }

        else
        {
            animator.SetBool("isAttacking",false);
        }

    }

    void Attack()
    {
        //Debug.Log("Игрок атакует");
        isAttacking = true;
        animator.SetBool("isAttacking",true);
        cameraCursor.enabled = false;
        StartCoroutine(ResetAttack());
    }

    public IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        cameraCursor.enabled = true;
        isAttacking = false;
    }
}
