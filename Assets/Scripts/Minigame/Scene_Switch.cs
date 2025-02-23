using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_Switch : MonoBehaviour
{
    Template_Player_Movement _templatePlayerMovement;
    Transform origin_t;
    void Start()
    {
        _templatePlayerMovement = GameObject.FindGameObjectWithTag("player").GetComponent<Template_Player_Movement>();
        origin_t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(origin_t.position,new Vector2(20f,20f),0f);
        for(int i = 0;i < hit.Length ; i++){
            if(hit[i].tag == "player" || _templatePlayerMovement.deathCounter >= 3){
                //we switch scenes
                StateManager.instance.CompleteMiniGame();
                SceneManager.LoadScene(1);
            }
        }
    }

    void OnDrawGizmos(){
        if(origin_t != null){
            Gizmos.DrawWireCube(origin_t.position,new Vector2(20f,20f));
        }
    }
}
