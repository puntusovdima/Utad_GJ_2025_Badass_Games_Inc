using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Template_Player_Movement : MonoBehaviour
{
    //this script must be placed within the player to work
    Transform player_t;
    Rigidbody2D player_r;
    BoxCollider2D player_c;
    Transform player_ground;
    Transform player_axis;
    [SerializeField] TextMeshProUGUI text;

    //camera
    Camera cam;
    float cam_y_offset = 0.5f;

    float player_move_x;
    float x_speed = 7f;
    float y_intensity = 10f;

    float jump_tim = 0.5f;
    float jump_tim_t = 0.5f;
    public int is_jumping = 0;


    float time = 20f;
    float timer = 1f;
    float cur_timer = 1f;
    public bool propulse = false;
    int no = 0;
    void Start()
    {
        //obtaining variables
        //local
        player_t = GetComponent<Transform>();
        player_r = GetComponent<Rigidbody2D>();
        player_c = GetComponent<BoxCollider2D>();

        //external
        player_ground = player_t.Find("TP_ground");
        player_axis = player_t.Find("TP_axis");
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        VerticalMove();
        Hand();
        Cam();
        Time_pas();
    }

    void HorizontalMove()
    {
        player_move_x = Input.GetAxis("Horizontal");
        if(player_move_x != 0){
            //is moving?
            player_r.velocity = new Vector2(player_move_x * x_speed,
                                            player_r.velocity.y);
        }
        return;
    }

    void VerticalMove()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(player_ground.position,new Vector2(0.9f,0.25f),0f);
        for(int i=0;i<hit.Length;i++){
            //in here lets sort out all the collisions
            if(hit[i].tag == "jumpable" && is_jumping == 0 && player_r.velocity.y < 1){
                is_jumping = 1;
                player_r.velocity = new Vector2(0f,0f);
                Jump();
            }
            if(hit[i].tag == "jumpable+" && is_jumping == 0 && player_r.velocity.y < 1){
                is_jumping = 1;
                player_r.velocity = new Vector2(0f,0f);
                y_intensity = 20f;
                Jump();
                y_intensity = 10f;
            }
        }

        if(is_jumping == 1){
            jump_tim_t -= Time.deltaTime;
            if(jump_tim_t < 0){
                is_jumping = 0;
                jump_tim_t = jump_tim;
            }
        }
    }

    void Jump(){
        player_r.AddForce(new Vector2(0,1f).normalized * y_intensity,ForceMode2D.Impulse);
    }

    void Cam()
    {
        //fixed camera in one axis
        cam.transform.position = new Vector3(cam.transform.position.x,
                                             player_t.position.y + cam_y_offset,
                                             cam.transform.position.z);
    }

    void Hand()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(player_ground.position,1f);
        for(int i=0;i<hit.Length;i++){
            if(hit[i].tag == "clock"){
                hit[i].gameObject.GetComponent<Renderer>().enabled = false;
                hit[i].gameObject.GetComponent<BoxCollider2D>().enabled = false;
                time += 7f;
            }
        }
    }

    void Time_pas(){
        //will reduce by one second
        cur_timer -= Time.deltaTime;
        if(cur_timer <= 0){
            cur_timer = timer;
            time -= 1;
            text.SetText(time.ToString());
        }
        propulse = false;
        if(time <= 0 && no == 0){
            propulse = true;
            no = 1;
        }
    }

    void OnDrawGizmos(){
        if(player_ground != null){
            Gizmos.DrawWireCube(player_ground.position,new Vector3(0.9f,0.25f,0f));
        }
        if(player_axis != null){
            Gizmos.DrawSphere(player_axis.position,0.2f);
        }
    }
}
