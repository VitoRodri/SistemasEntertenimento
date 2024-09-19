using UnityEngine;

public class ShakePanel : MonoBehaviour
{
    public float shakeMagnitude = 0.1f;
    public float shakeSpeed = 10f;
    public float rotationMagnitude = 5f;
    public float rotationSpeed = 5f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;
        float randomOffset = Random.Range(0f, 2f * Mathf.PI);
        StartCoroutine(ShakeCoroutine(randomOffset));
    }

    private System.Collections.IEnumerator ShakeCoroutine(float offset)
    {
        while (true)
        {
            float x = Mathf.Sin((Time.time + offset) * shakeSpeed) * shakeMagnitude;
            float y = Mathf.Cos((Time.time + offset) * shakeSpeed) * shakeMagnitude;
            float zRotation = Mathf.Sin((Time.time + offset) * rotationSpeed) * rotationMagnitude;

            transform.localPosition = originalPosition + new Vector3(x, y, 0f);
            transform.localRotation = originalRotation * Quaternion.Euler(0f, 0f, zRotation);

            yield return null;
        }
    }
}


