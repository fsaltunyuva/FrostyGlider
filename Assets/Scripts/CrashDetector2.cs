using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector2 : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
     if (other.tag == "Ground" && !hasCrashed) 
     {
         hasCrashed = true;
         FindObjectOfType<PlayerController>().DisableControls();
         crashEffect.Play();
         GetComponent<AudioSource>().PlayOneShot(crashSFX);
         Invoke("ReloadScene", delay);
               
     }  

    }
       void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
