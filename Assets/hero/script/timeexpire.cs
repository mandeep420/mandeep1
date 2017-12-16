using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeexpire : MonoBehaviour {

    
    [SerializeField]
    float mExpirationTime;
    float mTimer;

    void Update()
    {
        mTimer += Time.deltaTime;
        if (mTimer >= mExpirationTime)
        {
            Destroy(gameObject);
        }
    }
}
