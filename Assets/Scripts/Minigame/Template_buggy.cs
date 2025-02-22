using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Template_buggy : MonoBehaviour
{
    Transform origin_t;
    Rigidbody2D origin_r;
    BoxCollider2D origin_c;
    GameObject dumb_ah;
    Collider2D player;
    int is_frozen = 0;
    float tot = 0f;
    float speed = 3f;

    float timer = 5f;
    float cur_timer = 5f;
    int cd = 0;

    float timer2 = 0.7f;
    float cur_timer2 = 0.7f;
    int cd2 = 0;
    int locka = 0;

    float timer3 = 0.2f;
    float cur_timer3 = 0.2f;

    float add = 0f;
    float add_t = 0f;

    //yall gonna kill me
    //4th timer
    float timer4 = 2f;
    float cur_timer4 = 2f;
    int cd4 = 0;

    //camera stuff
    Camera cam;
    int shake_lock;

    bool restart = false;
    public bool to_change = false;

    bool what;
    void Start()
    {
        //assigning variables
        origin_t = GetComponent<Transform>();
        origin_r = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        //origin_c = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        //we want it to rotate like actual crazy
        tot += speed;
        origin_r.MoveRotation(tot);
        if(tot >= 360f){
            tot = 0f;
        }

        Collider2D[] hit = Physics2D.OverlapCircleAll(origin_t.position,1.4f);
        what = GameObject.Find("Template_player").GetComponent<Template_Player_Movement>().propulse;
        Debug.Log(what);
        if(what == true){
            Debug.Log("a");
            hit[0] = GameObject.Find("Template_player").GetComponent<Collider2D>();
        }
        for(int i = 0;i<hit.Length;i++){
            if(hit[i].tag == "player"){
                cd = 1;
                player = hit[i];
                is_frozen = 1;
                Launch();
            }
        }
        if(cd == 1){
            cur_timer -= Time.deltaTime;
            if(cur_timer < 0){
                cur_timer = timer;
                cd = 0;
                is_frozen = 0;
                player.gameObject.GetComponent<Transform>().position = new Vector3(0.01f,-2.01f,0f);
            }
        }

        if(is_frozen == 1){
            player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            player.gameObject.GetComponent<Renderer>().enabled = false;
        } else {
            if(player != null){
                player.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
                player.gameObject.GetComponent<Renderer>().enabled = true;
                locka = 0;
                
                //here everything restarts in this death case
                to_change = false;
                if(restart == true){
                    to_change = true;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    restart = false;
                }
            }
        }


        //we will play the animation here
        if(is_frozen == 1){
            if(dumb_ah.GetComponent<Transform>().rotation.z * Mathf.Rad2Deg * 2 >= -60f){
                dumb_ah.GetComponent<Rigidbody2D>().MoveRotation(add);
                dumb_ah.GetComponent<Transform>().localScale = new Vector3((add_t * -1) +1,(add_t * -1) +1,dumb_ah.GetComponent<Transform>().localScale.z);
                //we have to make the movement exponential so
                add = (add - 0.2f) * 1.03f;
                add_t = add * 0.05f;
            } else {
                if(cd2 == 0){
                    cd2 = 1;
                    if(shake_lock == 0){
                        StartCoroutine(Camera_shake.ShakeCamera(cam, 0.2f, 0.3f));
                        shake_lock = 1;
                    }
                }
            }
            if(cd2 == 1){
                cur_timer2 -= Time.deltaTime;
                if(cur_timer2 <= 0){
                    cur_timer2 = timer2;
                    cd2 = 0;
                    dumb_ah.GetComponent<Rigidbody2D>().gravityScale = 1f;
                }
            }
            if(shake_lock == 2){
                cur_timer3 -= Time.deltaTime;
                if(cur_timer3 <= 0){
                    cur_timer3 = timer3;
                    shake_lock = 3;
                    StartCoroutine(Camera_shake.ShakeCamera(cam, 0.2f, 0.3f));
                }
            }

        }

        //after meeting the billion conditions lets check for the player
        Collider2D[] chase = Physics2D.OverlapCircleAll(origin_t.position,6f);
        for(int i=0;i<chase.Length;i++){
            if(chase[i].tag == "player"){
                if(cd4 == 0){
                    origin_r.AddForce(new Vector2(chase[i].gameObject.GetComponent<Transform>().position.x - origin_t.position.x,
                                                    chase[i].gameObject.GetComponent<Transform>().position.y - origin_t.position.y),
                                                    ForceMode2D.Impulse);
                    cd4 = 1;
                }
                
            }
        }

        if(cd4 == 1){
            cur_timer4 -= Time.deltaTime;
            if(cur_timer4 < 0){
                cur_timer4 = timer4;
                cd4 = 0;
            }
        }

    }
    void Launch()
    {
        //here we will write the code which will propulse the player to the screen
        //with a funny breaking animation
        
        dumb_ah = GameObject.Find("Sprite_to_screen");
        
        if(locka == 0){
            dumb_ah.GetComponent<Transform>().position = player.GetComponent<Transform>().position;
            dumb_ah.GetComponent<Rigidbody2D>().gravityScale = 0f;
            dumb_ah.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
            locka += 1;
            add = 0f;
            add_t = 0f;
            cur_timer2 = 1f;
            cd2 = 0;
            restart = true;

            if(shake_lock == 1){
                shake_lock = 2;
            }

            if(shake_lock == 3){
                shake_lock = 2;
            }

            //we have to refactor everything to normal
            dumb_ah.GetComponent<Transform>().localScale = new Vector3(1f,1f,dumb_ah.GetComponent<Transform>().localScale.z);
            dumb_ah.GetComponent<Rigidbody2D>().MoveRotation(0f);
        }
        dumb_ah.GetComponent<Renderer>().enabled = true;
    }
    void OnDrawGizmos(){
        if(origin_t != null){
            Gizmos.DrawSphere(origin_t.position,6f);
        }
    }
}
