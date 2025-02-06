using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sandstorm")]
    [Space]
    [SerializeField] private AudioSource _sandstormAudioSource;
    [SerializeField] private AudioClip _sandstormBackground;

    [Header("Player")]
    [Header("Footsteps")]
    [SerializeField] private AudioClip[] _footStapsSounds;
    [SerializeField] private float stepDelay = 0.5f;

    private int _stepCount = -1;
    private float _lastStepTime = 0f;

    [Header("Jump")]
    [SerializeField] private AudioClip[] _jumpSounds;

    private void Start()
    {
        _sandstormAudioSource = GetComponent<AudioSource>();
        BackgroundSound(_sandstormBackground);
    }

    private void BackgroundSound(AudioClip clip)
    {
        _sandstormAudioSource.clip = clip;
        _sandstormAudioSource.Play();
    }

    public void FootStapsSound(AudioSource footStapsAudioSource)
    {
        if (Time.time - _lastStepTime < stepDelay) return;

        int randomIndex = Random.Range(0, _footStapsSounds.Length);
        float randomVolume = Random.Range(0.1f, 0.5f);

        footStapsAudioSource.panStereo = _stepCount;
        footStapsAudioSource.PlayOneShot(_footStapsSounds[randomIndex], randomVolume);

        if (_stepCount >= 1) _stepCount = -1;
        else _stepCount = 1;

        _lastStepTime = Time.time;
    }
    public void JumpSound(AudioSource playerAudioSource)
    {
        int randomIndex = Random.Range(0, _footStapsSounds.Length);
        float randomVolume = Random.Range(0.1f, 0.5f);

        playerAudioSource.PlayOneShot(_footStapsSounds[randomIndex], randomVolume);
    }
}
