using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Switch : MonoBehaviour
{
    
    Transform origin_t;
    void Start()
    {
        origin_t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(origin_t.position,new Vector2(20f,20f),0f);
        for(int i = 0;i < hit.Length ; i++){
            if(hit[i].tag == "player"){
                Debug.Log("we switch");
            }
        }
    }

    void OnDrawGizmos(){
        if(origin_t != null){
            Gizmos.DrawWireCube(origin_t.position,new Vector2(20f,20f));
        }
    }
}
