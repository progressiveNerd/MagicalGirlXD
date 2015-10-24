using UnityEngine;
using System.Collections;
using System;

public class EnemyMovement : MonoBehaviour
{
    public enum FacingDirection { Front, Back, Left, Right };
    public float speed = 6f;
    public float runSpeed = 12f;
    public Transform player;

    PointOfInterest nextPoint;
    Rigidbody2D enemyRigidBody;
    Vector2 movement;
    public FacingDirection direction = FacingDirection.Front;
    Enemy manager;


    // Use this for initialization
    void Awake()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        manager = transform.parent.GetComponent<Enemy>();
    }

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    if (!manager.seen)
    //    {

    //        nextPoint = manager.points[manager.poiNext];
    //        float h = nextPoint.transform.position.x;
    //        float v = nextPoint.transform.position.z;
    //        if ((transform.position.x == nextPoint.transform.position.x))
    //        {
    //            manager.destinationReached = true;
    //            manager.Patrol();
    //        }

    //        Move(h - transform.position.x, v - transform.position.z);
    //    }
    //    else
    //    {
    //        Move(player.transform.position.x - transform.position.x, player.transform.position.z - transform.position.z);
    //    }
    //}


    //void Move(float h, float v)
    //{
    //    movement.Set(h, v);
    //    movement = movement.normalized * speed * Time.deltaTime;
    //    //        enemyRigidBody.MovePosition(transform.position + movement);
    //}
}
