using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEW_3p : MonoBehaviour
{   
    Transform plat_t;
    float timer = 1f;
    float timer2 = 0.5f;

    float timer3 = 5f;
    float cur_timer = 1f;
    float cur_timer2 = 0.5f;
    float cur_timer3 = 5f;
    int cd = 0;
    int cd2 = 0;

    int is_shown = 1;
    int uses = 3;

    void Start()
    {
        plat_t = GetComponent<Transform>();
    }

    void Update()
    {
        //READ ME

        //hey sam here
        //this code is messy as it gets
        //tons of timers and to be honest it wasnt too necessary
        //Mario if youre reading this i have a switch case for the progression of the plataform at the end
        //work with that if you can (if you do end up animating this)


        Collider2D[] hit = Physics2D.OverlapBoxAll(plat_t.position, new Vector2(4.1f,1f),0f);
        for(int i=0;i<hit.Length;i++){
            if(hit[i].tag == "player" && hit[i].GetComponent<Rigidbody2D>().velocity.y <= 0 && cd == 0 && is_shown == 1){
                cd = 1;
                cd2 = 1;
            }
        }

        //timers
        if(cd == 1){
            cur_timer -= Time.deltaTime;
            if(cur_timer <= 0){
                cur_timer = timer;
                cd = 0;
            }
        };

        if(cd2 == 1){
            cur_timer2 -= Time.deltaTime;
            if(cur_timer2 <= 0){
                cur_timer2 = timer2;
                cd2 = 0;
                uses -= 1;
            }
        }

        if(uses <= 0){
            is_shown = 0;
            uses = 3;
        }

        if(is_shown == 0){
            cur_timer3 -= Time.deltaTime;
            if(cur_timer3 < 0){
                cur_timer3 = timer3;
                is_shown = 1;
            }
        }

        if(is_shown == 0){
            GetComponent<Renderer>().enabled = false;
            GetComponent<BoxCollider2D>().size = new Vector2(0f,0f);
        } else {
            GetComponent<Renderer>().enabled = true;
            GetComponent<BoxCollider2D>().size = new Vector2(1f,1f);
        }

        /* :)
        switch(uses)
        {
            case 3:

            break;
            case 2:

            break;
            case 1:

            break;
        }
        */
    }

    void OnDrawGizmos()
    {
        if(plat_t != null){
            Gizmos.DrawWireCube(plat_t.position,new Vector3(4.1f,1f,0f));
        }
    }
}
