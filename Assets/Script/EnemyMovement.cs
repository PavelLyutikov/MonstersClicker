using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    public float waitTime;  
    public float startWaitTime;
    bool wait = true;

    Vector3 destinationPoint;

    int xPosition;
    int zPosition;

    Animator myAnimator;

    void Start()
    {
        myAnimator = GetComponent<Animator>();

        if (DifficultyIncrease.time >= 80)
        {
            speed = 10;
            waitTime = 0;
        }
        else if (DifficultyIncrease.time >= 70)
        {
            speed = 9;
            waitTime = 0;
        }
        else if (DifficultyIncrease.time >= 60)
        {
            speed = 8;
            waitTime = 0;
        }
        else if (DifficultyIncrease.time >= 50)
        {
            speed = 7;
            waitTime = 1;
        }
        else if (DifficultyIncrease.time >= 40)
        {
            speed = 6;
            waitTime = 1;
        }
        else if (DifficultyIncrease.time >= 30)
        {
            speed = 5;
            waitTime = 1;
        }
        else if (DifficultyIncrease.time >= 20)
        {
            speed = 4;
            waitTime = 2;
        }
        else if (DifficultyIncrease.time >= 10)
        {
            speed = 3;
            waitTime = 2;
        }
    }

    void Update()
    {

        if (wait)
        {
            waitTime -= Time.deltaTime;

            IdleAnimation();

            if (waitTime <= 0)
            {
                wait = false;

                xPosition = Random.Range(-14, 14);
                zPosition = Random.Range(-14, 14);

                destinationPoint = new Vector3(xPosition, 0.5f, zPosition);
            }
        }
        else
        {
            LookAtRandomPoint(transform, destinationPoint, 10);
            transform.position = Vector3.MoveTowards(transform.position, destinationPoint, speed * Time.deltaTime);

            if (speed <= 5)
            {
                WalkAnimation();
            }
            else
            {
                RunAnimation();
            }
            

            if (Vector3.Distance(transform.position, destinationPoint) < 0.5f)
            {
                wait = true;
                if (DifficultyIncrease.time >= 60)
                {
                    waitTime = 0;
                }
                else if (DifficultyIncrease.time >= 30)
                {
                    waitTime = 1;
                }
                else if (DifficultyIncrease.time <= 29)
                {
                    waitTime = 2;
                }
            }
        }
    }

    void LookAtRandomPoint(Transform transform, Vector3 point, float speed)
    {
        var direction = (point - transform.position).normalized;
        direction.y = 0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), speed);
    }

    public void IdleAnimation()
    {
        myAnimator.SetBool("Idle", true);
        myAnimator.SetBool("Run", false);
        myAnimator.SetBool("Walk", false);
        myAnimator.SetBool("Die", false);
        myAnimator.SetBool("Damage", false);
    }

    public void DieAnimation()
    {
        myAnimator.SetBool("Idle", false);
        myAnimator.SetBool("Run", false);
        myAnimator.SetBool("Walk", false);
        myAnimator.SetBool("Die", true);
        myAnimator.SetBool("Damage", false);
    }

    public void DamageAnimation()
    {
        myAnimator.SetBool("Idle", false);
        myAnimator.SetBool("Run", false);
        myAnimator.SetBool("Walk", false);
        myAnimator.SetBool("Die", false);
        myAnimator.SetBool("Damage", true);
    }

    public void WalkAnimation()
    {
        myAnimator.SetBool("Idle", false);
        myAnimator.SetBool("Run", false);
        myAnimator.SetBool("Walk", true);
        myAnimator.SetBool("Die", false);
        myAnimator.SetBool("Damage", false);
    }

    public void RunAnimation()
    {
        myAnimator.SetBool("Idle", false);
        myAnimator.SetBool("Run", true);
        myAnimator.SetBool("Walk", false);
        myAnimator.SetBool("Die", false);
        myAnimator.SetBool("Damage", false);
    }
}
