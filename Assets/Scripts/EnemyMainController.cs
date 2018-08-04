using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;
using UnityEngine;

public class EnemyMainController : MonoBehaviour
{

    public GameObject Player;
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void OnEnable() 
    {
        EnemySmall.OnInstantiate += MoveDown;
    }
    private void OnDisable() 
    {
        EnemySmall.OnInstantiate -= MoveDown;
    }

    async void MoveDown(GameObject obj)
    {
        // Vector3 initPosition = obj.transform.position;
        float timer = .1f * Time.fixedDeltaTime;
        // Debug.Log("MEssage recieved!");
        int i = 0;
        Vector3 initPosition = obj.transform.position;
        while (i < 120)
        {
            Vector3 offset = obj.transform.position - initPosition;
            obj.transform.position = Vector3.Lerp(obj.transform.position, 
                new Vector3(obj.transform.position.x, Player.transform.position.y, Player.transform.position.z) + offset, timer);
            // Debug.Log(obj.transform.localPosition + ", " + obj.transform.position);
            await Task.Delay(TimeSpan.FromSeconds(0.01667f));
            i++;
        }
        
    }
}
