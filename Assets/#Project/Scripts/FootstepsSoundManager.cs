using StarterAssets;
using UnityEngine;


public class FootstepsSoundManager : MonoBehaviour
{
    public bool play = false;
    public float delay = 1f;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ThirdPersonController controller;

    private float timer = 0;


    void Update()
    {
        if (controller.isMoving)
        {
            play = true;
        }
        else
        {
            play = false;
        }

        
        if (play)
        {
            timer += Time.deltaTime;

            if (timer >= delay)
            {
                timer = 0;
                audioSource.Play();
            }

        }
        else
        {
            timer = 0;
        }
    }
}
