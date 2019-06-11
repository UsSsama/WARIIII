using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class HealthScript : MonoBehaviour
{

    public float health = 100f;
    private float x_Death = -90f;   // die effect cause we don't have died animation
    private float death_smooth = 0.9f;
    private float rotate_Time = 0.23f;
    private bool playerDied;
    public bool isPlayer;
    [SerializeField]    //if we want it to show in the panel it will make it visible
    private Image health_UI;  // private we don't want it to be access by other classes
    [HideInInspector] // oposite to [SerializeField]
    public bool shieldActivated;
    private CharacterSoundFX soundFX;

    void Awake()
    {
        soundFX = GetComponentInChildren<CharacterSoundFX>();    // because player sound is a child of warior and Enemy
        
    }


    void Update()
    {
        if (playerDied)
        {
            rotateAfterDeaath();
        }
    }


    public void applyDamage(float damage)
    {

        if (shieldActivated)
        {
            return;
        }


        health -= damage;

        if(health_UI != null)
        {
            health_UI.fillAmount = health / 100f;    // we divide over 100 cause the range of health is between 0 and 1  
        }


        if (health <= 0)
        {
            soundFX.Die();
           
            GetComponent<Animator>().enabled = false;
            print("He Died"); // Print in Console
            StartCoroutine(AllowRotate());
            if (isPlayer)
            {
                GetComponent<Playermove>().enabled = false;
                GetComponent<PlayerAttackInput>().enabled = false;
                // when he died camera will follow him cause it's a chiled of warior so i set it to null
                // when player die it should make the camera stop following the player (error) and the enemy stop attacking (working)
                Camera.main.transform.SetParent(null);
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyController>().enabled = false;
                SceneManager.LoadScene("GameOver"); 
            }
            else
            {
                GetComponent<EnemyController>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;    // we must write using UnityEngine.AI;
                SceneManager.LoadScene("YouWin");
            }

        }
    }

    void rotateAfterDeaath()
    {
        transform.eulerAngles = new Vector3(
            Mathf.Lerp(transform.eulerAngles.x, x_Death, Time.deltaTime * death_smooth),
                                            transform.eulerAngles.y, transform.eulerAngles.z);       // values for  x , y and z 
    }
    
    IEnumerator  AllowRotate()
    {
        playerDied = true;
        yield return new WaitForSeconds(rotate_Time);
        playerDied = false;
    }



}
