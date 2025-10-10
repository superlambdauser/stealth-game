using UnityEngine;
public class HitSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource ;
    void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
    }
}
