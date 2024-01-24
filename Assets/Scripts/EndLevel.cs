using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 0.3f;
    private bool isLevelCompleted;

    private void Update()
    {
        if (isLevelCompleted)
        {
            transform.Rotate(0, 360 * speed * Time.deltaTime, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isLevelCompleted)
        {
            animator.SetTrigger("end");
            isLevelCompleted = true;
            Invoke("LoadNextLevel", 2f);
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
