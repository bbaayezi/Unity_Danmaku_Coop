using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour 
{
    [Header("子弹组Holder")]
    public GameObject BulletGroupHolder;
    [Header("子弹速度")]
    public float BulletSpeed;
    // public GameObject Enemy;
    public GameObject BulletPrefab;
    private List<GameObject> BulletGroup = new List<GameObject>();
    private SpriteRenderer[] Bullets;
    private GameObject BulletMgr;
    private Vector3 ScreenBorder;
    private int frameCount;
	// Use this for initialization
	void Start () 
    {
		ScreenBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 5));
        foreach(var bullet in BulletPrefab.GetComponentsInChildren<BulletMotionController>())
        {
            BulletGroup.Add(bullet.gameObject);
        }
        // BulletMgr = GameObject.FindGameObjectWithTag("BulletMgr");
        // Debug.Log(ScreenBorder);
    }
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        // create bullets
        if (!(transform.localPosition.y <= -6.5)) // if reaches lower border, destroy itselft
        {
            if (transform.localPosition.y <= -0.4f)
            {
                    
                SpawnBullet();
            }
        }
        

        // do bullet motion
        Bullets = BulletGroupHolder.GetComponentsInChildren<SpriteRenderer>() as SpriteRenderer[];
        // Bullets[0].gameObject.transform.position -= Vector3.up * 1f * Time.fixedDeltaTime;
        // Debug.Log(Bullets[0]);
        if (Bullets != null)
        {
            foreach(SpriteRenderer bullet in Bullets)
            {
                // Debug.Log(bullet);
                bullet.gameObject.transform.Translate(-Vector3.up * BulletSpeed * Time.fixedDeltaTime, Space.Self);
                // bullet.gameObject.transform.position -= Vector3.up * 1f * Time.fixedDeltaTime;
                if ((bullet.gameObject.transform.position.y) <= ScreenBorder.y
                || (bullet.gameObject.transform.position.y) >= 4.5
                || (bullet.gameObject.transform.position.x) <= -3
                || (bullet.gameObject.transform.position.x) >= 3)
                {
                    Destroy(bullet.gameObject);
                }
            }
        }
		
	}

    void SpawnBullet()
    {
        if (frameCount % 30 == 0) // every 70 frames spawn a bullet
        {
            {
                foreach(GameObject bullet in BulletGroup)
                {
                    if (BulletGroupHolder != null)
                    {
                        Instantiate(bullet, transform.position, bullet.transform.rotation, BulletGroupHolder.transform);
                    }
                }
            }
            
        }
        frameCount++;
    }
    // utils
}