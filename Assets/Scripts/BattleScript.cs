using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{

    public Animator animator;
    public bool attacked;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deathf();
        reSpawn();
    }

    public void clickAttack()
    {
        animator.SetTrigger("attack");

        if (GameManager.instance.enemy != null)
        {
            GameManager.instance.enemy.GetComponent<Enemy>().isAttacked = true;
            GameManager.instance.enemy.GetComponent<Enemy>().hp -= GameManager.instance.dmg;
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
