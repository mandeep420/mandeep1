using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaniG : MonoBehaviour {
    public Transform mTarget;
    public float mFollowSpeed;
    public float mFollowRange;


    [SerializeField]
    GameObject mexpllsionPrefab;


    bool startSceneTimer = false;
    float timer = .5f;
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

            if (direction.x > 0)
            {
                mySprite.flipX = false;
            }
            else if (direction.x < 0)
            {
                mySprite.flipX = true;
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
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")

        {
            // player1.Animator.SetBool("shoot",true);
           // Instantiate(mexpllsionPrefab, transform.position, Quaternion.identity);
            Debug.Log("ChangeScene");
            SceneManager.LoadScene("Main Menu");
          
        }
    }
}
