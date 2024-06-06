using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ChangeVolume(float startVolume, float finalVolume)
    {
        StartCoroutine(ChangingingVolume(startVolume, finalVolume));
    }

    public void Play()
    {
        _audioSource.Play();
        ChangeVolume(_audioSource.volume, 1);
    }

    public void Stop()
    {
        StopAllCoroutines();
        ChangeVolume(_audioSource.volume, 0);
    }

    private IEnumerator ChangingingVolume(float startVolume, float finalVolume)
    {
        while (_audioSource.volume != finalVolume)
        {
            float changingValue = GetVolumeMotion(startVolume, finalVolume);

            if (finalVolume >= _audioSource.volume)
                _audioSource.volume += changingValue;
            else
                _audioSource.volume -= changingValue;

            if (0 == _audioSource.volume)
                _audioSource.Stop();

            yield return new WaitForEndOfFrame();
        }
    }

    private float GetVolumeMotion(float startVolume, float finalVolume)
    {
        float maxDelta = 0.001f;
        return Mathf.MoveTowards(startVolume, finalVolume, maxDelta);
    }
}
