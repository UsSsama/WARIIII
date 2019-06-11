using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator Anime;

    // Awake is called before the first frame update
    void Awake()
    {
        Anime = GetComponent<Animator>();   
    }

    public void Walk (bool walk)
    {
        Anime.SetBool(AnimationTags.WALK_PARAMETER, walk);          // the same name of parameter at Animator in Unity  look at the Tags class
    }

    public void Defend(bool defend)
    {
        Anime.SetBool(AnimationTags.DEFEND_PARAMETER, defend);      // the same name of parameter at Animator in Unity  look at the Tags class
    }

    public void Attack1 ()
    {
        Anime.SetTrigger(AnimationTags.ATTACK1_TRIGGER);             // the same name of parameter at Animator in Unity  look at the Tags class 
    }

    public void Attack2()
    {
        Anime.SetTrigger(AnimationTags.ATTACK2_TRIGGER);             // the same name of parameter at Animator in Unity  look at the Tags class
    }

    public void FreezeAnimation()
    {
        Anime.speed = 0f;
    }

    public void UNFreezeAnimation()
    {
        Anime.speed = 1f;
    }











}
