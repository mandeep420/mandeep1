using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public Transform mTarget;
    public float mFollowSpeed;
    public float mFollowRange;

    float mArriveThreshold = 0.05f;
    SpriteRenderer mySprite;

    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (mTarget != null)
        {
            Vector2 direction = mTarget.transform.position - transform.position;
            direction.y = 0;

            if (direction.x > 0 )
            {
                mySprite.flipX = true;
            }
            else if (direction.x < 0)
            {
                mySprite.flipX = false;
            }

            if (direction.magnitude <= mFollowRange)
            {
                if (direction.magnitude > mArriveThreshold)
                {
                    transform.Translate(direction.normalized * mFollowSpeed * Time.deltaTime, Space.World);
                }
                else
                {
                    transform.position = new Vector2(mTarget.transform.position.x, transform.position.y);
                }
            }
        }
    }

    public void SetTarget(Transform target)
    {
        mTarget = target;
    }
}