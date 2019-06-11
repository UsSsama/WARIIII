using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    public LayerMask layer;
    public float radius = 1f;
    public float damage = 1f;

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position , radius , layer); // transform.position "position of the circle", radius "of the circle" , layer "in the inspector"
        if (hits.Length > 0 )
        {
            print("Touch the GameObject"); // To print in Console   //we can touch the player 

            hits[0].GetComponent<HealthScript>().applyDamage(damage);
            gameObject.SetActive(false);
        }
    }







}
