using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifecylcle : MonoBehaviour
{
    private string trapTag = "Trap";
    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(trapTag))
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("death");
        // to disable the physic of the player when he dies
        rb.bodyType = RigidbodyType2D.Static;
        deathSoundEffect.Play();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
