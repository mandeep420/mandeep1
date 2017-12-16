using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour {
  

    public GameObject BulletPrefab;
     float fireDelay = 0.99f;
    float cooldown = 0;
    float kShootDuration = 0.25f;
    float mTime;

    Animator mAnimator;
    bool mShooting;
    AudioSource Shooting;

    void Start()
    {
        mAnimator = GetComponentInParent<Animator>();
        Shooting = GetComponent<AudioSource>();
    }




    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (Input.GetButton("Fire") && cooldown <= 0)
        {
          
            mShooting = true;
            mTime = 0.0f;
             mAnimator.SetBool("isShooting", true);
            Debug.Log("Shoot");
           
            Shooting.Play();
          
            cooldown = fireDelay;

      
            Instantiate(BulletPrefab, transform.position, transform.rotation);
            
      }

        if (mShooting)
        {
            mTime += Time.deltaTime;
            if (mTime > kShootDuration)
            {
                mShooting = false;
            }
        }


        UpdateAnimator();

    }
    private void UpdateAnimator()
    {
        mAnimator.SetBool("isShooting", mShooting);
    }

}



