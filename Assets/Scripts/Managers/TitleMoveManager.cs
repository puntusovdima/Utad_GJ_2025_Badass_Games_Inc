using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMoveManager : MonoBehaviour
{
    private float currentTime = 0f;
    private float initY;
    [SerializeField] private float durationTime = 3f; 
    public bool animationComplete = false;
    
    public StateManager stateManager;

    void Start()
    {
        // stateManager = GetComponent<StateManager>();
        stateManager = GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();
        initY = transform.position.y;
    }

    private void Update()
    {
        if (!animationComplete)
            SmoothlyGoDown();
    }

    private void SmoothlyGoDown()
    {
        currentTime += Time.deltaTime;
        float interpolationEffect = Mathf.Lerp(1, 0, currentTime / durationTime);
        transform.position = new Vector2(transform.position.x, initY * interpolationEffect);
        if (interpolationEffect <= 0)
        {
             transform.position = new Vector2(transform.position.x, 0);
            animationComplete = true;
        }
    }
    
}
