using UnityEngine;
using UnityEngine.Audio;

public class MixerEffectsControler : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Transform target;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float hearingDistance = 15f;

    #region local variables
    float distance;
    float freq;
    #endregion

    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);

        // If we want a linear curve :
        // freq = Mathf.Lerp(22000, 10, distance / hearingDistance);

        // For curved interpolations :
        float freq = animationCurve.Evaluate(distance / hearingDistance);

        mixer.SetFloat("LowpassCutoff", freq);
    }
}
