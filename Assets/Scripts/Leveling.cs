using Unity.VisualScripting;
using UnityEngine;

public class Leveling : MonoBehaviour
{
    [SerializeField] private AudioSource endSoundEffect;

    private bool isLevelCompleted;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("End") && !isLevelCompleted)
        {
            endSoundEffect.Play();
            isLevelCompleted = true;
        }
    }
}
