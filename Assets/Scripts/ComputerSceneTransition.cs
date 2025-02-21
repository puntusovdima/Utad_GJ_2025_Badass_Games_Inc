using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class ComputerSceneTransition : MonoBehaviour
{
    Camera cam;
    [SerializeField] int transitionSceneIndex;
    [Header("Zoom Parameters")]
    [SerializeField] float zoomSpeed;
    [SerializeField] int fadeInStart;
    [SerializeField] Transform zoomTarget;
    [Header("Animation Parameters")]
    [SerializeField] Animation fadeInAnim;
    bool zoomIn;
    Vector3 targetPosition;


    private void Awake()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if (zoomIn) { 
            transform.position = Vector3.Lerp(transform.position, zoomTarget.position, zoomSpeed);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 1.8f, zoomSpeed);
        }
    }


    public void ZoomIn()
    {
        zoomIn = true;
        targetPosition = zoomTarget.position - transform.forward;
        TransitionToNextScene(transitionSceneIndex);
    }
    public void ZoomOut()
    {
        cam.orthographicSize = 1.8f;
        //
    }


    private async void TransitionToNextScene(int sceneIndex)
    {
        await Task.Delay(fadeInStart);
        fadeInAnim.Play();
        await Task.Delay(3000);
        SceneManager.LoadScene(sceneIndex);
    }
}
