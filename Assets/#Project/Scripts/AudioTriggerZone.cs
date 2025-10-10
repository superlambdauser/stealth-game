using UnityEngine;
using UnityEngine.Audio;

public class AudioTriggerZone : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot attackingSnapshot;
    [SerializeField] private AudioMixerSnapshot BGMSnapshot;

    [SerializeField] private float transitionTime = 2f;


    void OnTriggerEnter(Collider other)
    {
        attackingSnapshot.TransitionTo(transitionTime);
    }

    void OnTriggerExit(Collider other)
    {
        BGMSnapshot.TransitionTo(transitionTime);
    }
}
