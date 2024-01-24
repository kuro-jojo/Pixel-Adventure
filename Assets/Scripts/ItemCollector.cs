using UnityEngine.UI;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private string itemTag = "Cherry";
    private int cherries;
    [SerializeField] private Text cherriesCounter;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(itemTag))
        {
            Destroy(collider.gameObject);
            cherriesCounter.text = "Cherries " + ++cherries;
        }
    }
}
