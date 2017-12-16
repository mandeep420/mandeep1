using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeExpirePrefab : MonoBehaviour {


    [SerializeField]
    GameObject mexpllsionPrefab;

    [SerializeField]
    float mExpirationTime;
    float mTimer;

    void Update()
    {
        mTimer += Time.deltaTime;
        if (mTimer >= mExpirationTime)
        {
            Instantiate(mexpllsionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
           
        }
    }
}
