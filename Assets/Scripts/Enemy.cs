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

    public bool startedAttack;

    public double killReward;


    private void Awake()
    {
    }
    private void Start()
    {
        isDead = false;
        isAttacked = false;
        startedAttack = false;
    }

    private void Update()
    {
        
        death();
    }
    public void attack()
    {
        animator.SetTrigger("attack");
        if(damage>GameManager.instance.armor)
        GameManager.instance.hp -= (damage-GameManager.instance.armor);
        
    }

    public void death()
    {
        if(hp <= 0)
        {
            isDead = true;
            animator.SetBool("isDead",true);
            EnemySpawner.instance.enemySpawned = false;
            StartCoroutine(deathCrtn());
        }
    }

    public IEnumerator attackCrtn()
    {
        while (!isDead)
        {
            attack();
            startedAttack = true;
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator deathCrtn()
    {
        
        yield return new WaitForSeconds(5);
        EnemySpawner.instance.enemyDefeated = true;
        GameManager.instance.coinCount += killReward;
        Destroy(gameObject);

    }
}
