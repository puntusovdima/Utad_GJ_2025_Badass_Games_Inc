using System.Collections;
using UnityEngine;

public class Camera_shake : MonoBehaviour
{
    public static IEnumerator ShakeCamera(Camera camera, float duration, float magnitude = 0.2f)
    {
        Vector3 originalPosition = camera.transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            
            camera.transform.localPosition = originalPosition + new Vector3(x, y, 0);
            
            elapsed += Time.deltaTime;
            yield return null;
        }

        camera.transform.localPosition = originalPosition;
    }
}
