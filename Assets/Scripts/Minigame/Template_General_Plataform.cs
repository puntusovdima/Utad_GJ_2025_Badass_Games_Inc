using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Template_General_Platafor : MonoBehaviour
{
    Transform origin_t;
    Vector2 neg_off;
    Vector2 pos_off;
    float speed;
    
    //starting x_axis
    int x_axis;
    void Start()
    {
        origin_t = GetComponent<Transform>();
        Transform[] tra = GetComponentsInChildren<Transform>();
        if(tra[0].position.x < tra[1].position.x){
            neg_off = tra[0].position;
            pos_off = tra[1].position;
        } else {
            pos_off = tra[0].position;
            neg_off = tra[1].position;
        }
        
        float r  = Random.Range(-1f,1f);
        if(r < 0){
            x_axis = -1;
        } else {
            x_axis = 1;
        }

        speed = Random.Range(4f,0.25f);
    }

    void Update()
    {
        origin_t.position = new Vector2(origin_t.position.x + (speed * x_axis * Time.deltaTime),origin_t.position.y);

        if(origin_t.position.x < neg_off.x || origin_t.position.x > pos_off.x){
            x_axis *= -1;
        }
    }
}
