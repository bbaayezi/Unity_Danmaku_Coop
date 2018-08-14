using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour 
{

    public GameObject BulletGroupHolder;
    private SpriteRenderer[] bullets;
    private Vector3 screenBorder;
    public float bulletSpeed;
	// Use this for initialization
	void Start () 
    {
		screenBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 5));
        // Debug.Log(screenBorder);
        // Debug.Log(bullets);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        
        bullets = BulletGroupHolder.GetComponentsInChildren<SpriteRenderer>() as SpriteRenderer[];
        // bullets[0].gameObject.transform.position -= Vector3.up * 1f * Time.fixedDeltaTime;
        // Debug.Log(bullets[0]);
        if (bullets != null)
        {
            foreach(SpriteRenderer bullet in bullets)
            {
                // Debug.Log(bullet);
                bullet.gameObject.transform.Translate(-Vector3.up * bulletSpeed * Time.fixedDeltaTime, Space.Self);
                // bullet.gameObject.transform.position -= Vector3.up * 1f * Time.fixedDeltaTime;
                if ((bullet.gameObject.transform.position.y) <= screenBorder.y)
                {
                    Destroy(bullet.gameObject);
                }
            }
        }
		
	}
}
