using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{

    public Animator animator;
    public bool attacked;
    private Enemy enemy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.enemy != null)
        {
            enemy = GameManager.instance.enemy;
        }
        deathf();
        reSpawn();
    }

    public void clickAttack()
    {
        animator.SetTrigger("attack");

        if (GameManager.instance.enemy != null)
        {

            enemy.attack();

            enemy.isAttacked = true;
            if(GameManager.instance.dmg > enemy.armor)
            enemy.hp -= (GameManager.instance.dmg - enemy.armor); 
        }
        
    }

    public void deathf()
    {
        if(GameManager.instance.hp <= 0)
        {
            animator.SetBool("isDead",true);
            GameManager.instance.isDead = true;
        }
    }

    public void reSpawn()
    {
        if (GameManager.instance.isDead)
        {
            StartCoroutine(respawnCounter());
            Destroy(GameManager.instance.enemy);
        }
    }

    IEnumerator respawnCounter()
    {
        yield return new WaitForSeconds(1.5f);
        animator.SetTrigger("respawn");
        animator.SetBool("isDead", false);
        GameManager.instance.isDead = false;
        GameManager.instance.hp = 100;
        GameManager.instance.coinCount = 0;
    }
}
