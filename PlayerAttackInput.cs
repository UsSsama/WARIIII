using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    private CharacterAnimation playerAnimation;
    public GameObject attackPoint;
    private PlayerShield shield;
    private CharacterSoundFX soundFX;


    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimation>();
        shield = GetComponent<PlayerShield>();
        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    // Update is called once per frame
    void Update()
    {
        // defend when press J
        if (Input.GetKeyDown(KeyCode.J))
        {
            playerAnimation.Defend(true);
            shield.ActiveShield(true);

        }
        // release when J unpressed
        if (Input.GetKeyUp(KeyCode.J))
        {
            playerAnimation.UNFreezeAnimation();
            playerAnimation.Defend(false);
            shield.ActiveShield(false);
        }

        // Attack when press K
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Random.Range(0, 2) > 0)
            {
                playerAnimation.Attack1();
                soundFX.Attack_1();
            }
            else
            {
                playerAnimation.Attack2();
                soundFX.Attack_2();
            }
        }
    }

    void ActivateAttackPoint ()
    {
        attackPoint.SetActive(true);
    }
    void DeactivateAttackPoint()
    {
        if(attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }








}
