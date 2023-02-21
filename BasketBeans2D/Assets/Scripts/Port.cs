using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Port : MonoBehaviour
{
    public bool toRemove = false;
    public PickUp inHand;
    [SerializeField]private int toLoad;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (toRemove == false)
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
        else
        {
            StartCoroutine(DestroyPortal());
        }
    }

    IEnumerator DestroyPortal()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
