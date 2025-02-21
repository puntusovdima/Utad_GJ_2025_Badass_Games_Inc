using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class ComputerSceneTransition : MonoBehaviour
{
    ComputerSceneTransition instance;
    Camera cam;
    PlayerMovement playerMovement;
    [Tooltip("Probably the same as the location of camera on start")]
    [SerializeField] Vector3 zoomOutTargetPosition;
    [Header("Zoom Parameters")]
    [SerializeField] float zoomSpeed;
    [SerializeField] int fadeInStart;
    [SerializeField] Transform zoomTarget;
    [Header("Animation Parameters")]
    [SerializeField] Animator fadeInAnim;
    bool zoom;
    Vector3 targetPosition;
    float targetCameraSize;


    private void Awake()
    {
        cam = Camera.main;
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (instance == null) instance = this;
        //ZoomIn(0);
        ZoomOut();
    }
    private void Update()
    {
        if (zoom) { 
            transform.position = Vector3.Lerp(transform.position, targetPosition, zoomSpeed);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetCameraSize, zoomSpeed);

            if (Vector3.Distance(transform.position, targetPosition) <= 0.5f) { 
                zoom = false;
                playerMovement.canMove = true;
            }
        }
        else transform.parent = playerMovement.transform;
    }


    public async void ZoomIn(int transitionSceneIndex)
    {
        transform.parent = null;
        zoom = true;
        targetPosition = zoomTarget.position - transform.forward;
        targetCameraSize = 1.8f;
        await Task.Delay(fadeInStart);
        fadeInAnim.SetTrigger("FadeIn");
        await Task.Delay(3000);
        TransitionToNextScene(transitionSceneIndex);
    }
    public void ZoomOut()
    {
        transform.parent = null;
        playerMovement.canMove = false;
        cam.orthographicSize = 1.8f;
        transform.position = zoomTarget.position - transform.forward;
        targetPosition = zoomOutTargetPosition;
        targetCameraSize = 5f;
        fadeInAnim.SetTrigger("FadeOut");
        zoom = true;
    }


    private void TransitionToNextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
