using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public double hp;
    public double damage;
    public double armor;

    public Animator animator;

    public bool isAttacked;

    public bool isDead;


    private void Awake()
    {
    }
    private void Start()
    {
        isDead = false;
        isAttacked = false;
    }

    private void Update()
    {
        
        death();
    }
    public void attack()
    {
        animator.SetTrigger("attack");
        GameManager.instance.hp -= (damage-GameManager.instance.armor);
        
    }

    public void death()
    {
        if(hp <= 0)
        {
            isDead = true;
            animator.SetBool("isDead",true);
            StartCoroutine(deathCrtn());
        }
    }

    public IEnumerator attackCrtn()
    {
        while (!isDead)
        {
            attack();
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator deathCrtn()
    {
        yield return new WaitForSeconds(1);
        EnemySpawner.instance.enemyDefeated = true;

        Destroy(gameObject);
        }    
}
