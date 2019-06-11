using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;         // Nav mesh Agent is in IT 


public enum EnemyState
{
    CHASE,
    ATTACK
}


public class EnemyController : MonoBehaviour
{
    private CharacterAnimation enemyAnime;
    private NavMeshAgent navAgent;
    private Transform playerTarget;
    public float moveSpeed = 3.5f;
    public float attackDistance = 1f; // how close can we get to our player before we start to attack
    public float chasePlayerAfterAttackDistance = 1f; // when the player decides starts to run the enemy gonna follow him
    private float waitBeforeAttackTime = 3f;
    private float attackTimer;

    private EnemyState enemyState;

    public GameObject attackPoint;

    private CharacterSoundFX soundFX;



    // Start is called before the first frame update
    void Awake()
    {
        enemyAnime = GetComponent<CharacterAnimation>();
        navAgent = GetComponent<NavMeshAgent>();
        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    void Start()
    {
        enemyState = EnemyState.CHASE;
        attackTimer = waitBeforeAttackTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (enemyState==EnemyState.CHASE)
        {
            chasePlayer();
        }
        if (enemyState == EnemyState.ATTACK)
        {
            attackPlayer();
        }
    }

    void chasePlayer()
    {
        navAgent.SetDestination(playerTarget.position);  // where is the nav of player target go this is the distination
        navAgent.speed = moveSpeed; // the speed that we are going to use

        if (navAgent.velocity.sqrMagnitude == 0)
        {
            enemyAnime.Walk(false);
        }else
        {
            enemyAnime.Walk(true);
        }
        if (Vector3.Distance(transform.position , playerTarget.position)<= attackDistance)
        {
            enemyState = EnemyState.ATTACK;
        }

    }
    void attackPlayer()
    {
        navAgent.velocity = Vector3.zero;   // make it stop immeditely 
        navAgent.isStopped = true; // stop navAgent
        enemyAnime.Walk(false);
        attackTimer += Time.deltaTime;
        if (attackTimer > waitBeforeAttackTime)
        {
            if (Random.Range(0 , 2) > 0)
            {
                enemyAnime.Attack1();
                soundFX.Attack_1();
            }else
            {
                enemyAnime.Attack2();
                soundFX.Attack_2();
            }
            attackTimer = 0f;  // To attack again and again       "if it doesn't exsist he will attack every second"   
        }
        if (Vector3.Distance(transform.position , playerTarget.position) > attackDistance + chasePlayerAfterAttackDistance) // to move after the player when player moves
        {
            navAgent.isStopped = false;
            enemyState = EnemyState.CHASE;
        }
    }

    void ActivateAttackPoint()
    {
        attackPoint.SetActive(true);
    }
    void DeactivateAttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }


}









