using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Cinemachine;

public class ComputerSceneTransition : MonoBehaviour
{
    ComputerSceneTransition instance;
    Camera cam;
    public CinemachineVirtualCamera virtualCamera;
    PlayerMovement playerMovement;
    [Tooltip("Probably the same as the location of camera on start")]
    [SerializeField] Vector3 zoomOutTargetPosition;
    [Header("Zoom Parameters")]
    [SerializeField] float zoomSpeed;
    [SerializeField] int fadeInStart;
    [SerializeField] Transform zoomTarget;
    [Header("Animation Parameters")]
    [SerializeField] Animator fadeInAnim;
    public bool zoom;
    Vector3 targetPosition;
    float targetCameraSize;


    private void Awake()
    {
        cam = Camera.main;
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (instance == null) instance = this;

        if (StateManager.instance.miniGameCompleteCount > 0) ZoomOut();
    }
    private void Update()
    {
        if (zoom) { 
            //transform.position = Vector3.Lerp(transform.position, targetPosition, zoomSpeed);
            //cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetCameraSize, zoomSpeed);
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, targetCameraSize, zoomSpeed);

            if (Mathf.Abs(virtualCamera.m_Lens.OrthographicSize - targetCameraSize) <= 0.1f) { 
                zoom = false;
                playerMovement.canMove = true;
                GetComponent<CinemachineBrain>().enabled = true;
            }
        }
        //else transform.parent = playerMovement.transform;
    }


    public async void ZoomIn(int transitionSceneIndex)
    {
        playerMovement.canMove = false;
        zoom = true;
        targetCameraSize = 1.8f;
        await Task.Delay(fadeInStart);
        fadeInAnim.SetTrigger("FadeIn");
        await Task.Delay(5000);
        TransitionToNextScene(transitionSceneIndex);
    }
    public void ZoomOut()
    {
        playerMovement.transform.position = new Vector3(68f, -3.06f, 0);
        playerMovement.canMove = false;
        virtualCamera.m_Lens.OrthographicSize = 1.8f;
        targetCameraSize = 2.8f;
        fadeInAnim.SetTrigger("FadeOut");
        zoom = true;
    }


    private void TransitionToNextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
