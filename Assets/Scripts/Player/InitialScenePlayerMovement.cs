using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector2 = System.Numerics.Vector2;

public class InitialScenePlayerMovement : MonoBehaviour
{
    private float currentTime = 0f;
    public float moveToTitleDuration = 3f;
    public float moveToLibraryDuration = 3f;
    public float moveToTitleDelay = 0.7f;
    public float moveToLibraryDelay = 3.7f;
    public Vector2 startPosition;
    public Vector2 targetPosition;
    private bool isLast = false;
    
    public GameObject titlePositionObject;
    public TitleMoveManager titleMoveManager;
    private bool titlePoistionReached = false;
    

    private void Start()
    {
        startPosition = new Vector2(transform.position.x, transform.position.y);
        titlePositionObject = GameObject.Find("TitlePlayerPosition");
        targetPosition = new Vector2(titlePositionObject.transform.position.x, titlePositionObject.transform.position.y);
        // InvokeRepeating("UpdateScene", 0f, 0.05f);
    }

    private void Update()
    {
        if (!titleMoveManager.animationComplete)
            return;
        if (!titlePoistionReached)
            StartCoroutine(SmoothlyMoveWithDelay(targetPosition, moveToTitleDelay, moveToTitleDuration));
        else if (titlePoistionReached)
        {
            isLast = true;
            StartCoroutine(SmoothlyMoveWithDelay(targetPosition, moveToLibraryDelay, moveToLibraryDuration));
        }
        RotateCharacter();
            
    }

    private void RotateCharacter()
    {
        if (targetPosition.X - transform.position.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0, 0f);
        }
        else if (targetPosition.X - transform.position.x < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    private IEnumerator SmoothlyMoveWithDelay(Vector2 targetPosition, float delay, float duration)
    {
        yield return new WaitForSeconds(delay);
        currentTime += Time.deltaTime;
        float interpolation = Mathf.Lerp(0f, 1f, currentTime / duration);
        Vector2 move  = Vector2.Lerp(startPosition, targetPosition, interpolation);
        transform.position = new Vector3(move.X, move.Y, 0);
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), targetPosition) <= 0.1f)
        {
            if (isLast)
            {
                SceneManager.LoadScene("LibraryScene");
            }
            this.targetPosition = startPosition;
            startPosition = targetPosition;
            StopAllCoroutines();
            currentTime = 0f;
            titlePoistionReached = true;
            //  Load the library scene if second call
        }
        
    }
}
