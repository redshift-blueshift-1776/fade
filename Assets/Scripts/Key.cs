using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class Key : MonoBehaviour
{
    [SerializeField] private DoorUnlock doorUnlockScript;

    private Vector3 originalPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = transform.position;

        StartCoroutine(idle());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.CompareTag("Player"))
        {
            doorUnlockScript.unlockDoor();
            gameObject.SetActive(false);
            StopAllCoroutines();
        }
    }
    
    private const float verticalDisplacementAmplitude = 1f;
    private const float verticalDisplacementPeriod = 2.0f;
    private const float rotationPeriod = 0.25f;  //make sure this is less than secondsBetweenRotate
    private const float secondsBetweenRotate = 2.0f;
    private IEnumerator idle()
    {
        float positionTime = 0;
        float rotateTime = 0;
        float pulseTime = 0;
        while (true)
        {
            transform.position = originalPosition + new Vector3(
                0,
                verticalDisplacementAmplitude * Mathf.Sin(2 * Mathf.PI / verticalDisplacementPeriod * positionTime),
                0
            );

            if (rotateTime >= secondsBetweenRotate)
            {
                StartCoroutine(rotate());
                rotateTime = 0;
            }

            positionTime += Time.deltaTime;
            rotateTime += Time.deltaTime;
            pulseTime += Time.deltaTime;
            yield return null;
        }
    }
    
    private IEnumerator rotate()
    {
        float t = 0;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, 180f, 0) * startRotation;

        while (t < rotationPeriod)
        {
            t += Time.deltaTime;
            float normalizedT = Mathf.Clamp01(t / rotationPeriod);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, normalizedT);
            yield return null;
        }
        yield return null;
    }
}
