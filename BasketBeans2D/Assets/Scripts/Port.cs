using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Port : MonoBehaviour
{
    public PickUp inHand;
    [SerializeField]private int toLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Objects"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(toLoad);
        }
    }
}
