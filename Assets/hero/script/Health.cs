using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
   
	{

    bool startSceneTimer = false;
    float timer = .5f;
    [SerializeField]
    GameObject mexpllsionPrefab;
    public Image HealthBar;
    public float Healthy = 1;


    void Update()
    {

        HealthBar.fillAmount = Healthy;
        if (Healthy <= 0f)
        {
            Debug.Log("Hit");



            Destroy(gameObject);
            Debug.Log("ChangeScene");
            SceneManager.LoadScene("GameOver");
        }
    }



    void TakeDamage(int damage)
    {
        Debug.Log("Taking Damage: " + damage);
    }

    void OnCollisionStay2D(Collision2D obj)
    {
        if (obj.gameObject.layer == LayerMask.NameToLayer("enemy") )
        {

            Instantiate(mexpllsionPrefab, transform.position, Quaternion.identity);
            Healthy -= .007f;

            
        }

    }
}
