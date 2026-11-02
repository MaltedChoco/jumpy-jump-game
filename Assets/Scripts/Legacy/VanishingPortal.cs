using System.Collections;
using UnityEngine;

public class VanishingPortal : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip portalNoise;
    void Start()
    {
        // Start the routine to play and wait
        StartCoroutine(PlaySoundAndWait());
    }

    IEnumerator PlaySoundAndWait()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(portalNoise, 1.0f);
        yield return new WaitForSeconds(portalNoise.length);

        Vector3 initialScale = transform.localScale;
        float elapsed = 0f;

        while (elapsed < 1)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / 1;
            transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, t);
            yield return null;
        }

        transform.localScale = Vector3.zero;

        Destroy(this.gameObject);
    }

    void Update()
    {

    }
}
