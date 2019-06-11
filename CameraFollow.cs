using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform Target;
    [SerializeField] // to make offset appear in the pannel even the class is private
    private Vector3 offsetPosition;


    // Start is called before the first frame update
    void Awake()
    {
        Target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform; 
    }

    // Update is called once per frame

    void LateUpdate()
    {
        
        FollowPlayer();
    }


    void FollowPlayer()
    {
        transform.position = Target.TransformPoint(offsetPosition);
        transform.rotation = Target.rotation;
    }







}
