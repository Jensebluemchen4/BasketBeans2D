using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Port : MonoBehaviour
{
    public bool toRemove = false;
    [SerializeField]private int toLoad;
    private float destroySpeed = 0.1f;


    private void Awake()
    {
        if (toRemove == true)
        {
            StartCoroutine(DestroyPortal());
        }
    }


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
    }

    IEnumerator DestroyPortal()
    {
        while (transform.localScale.x > 0 && transform.localScale.y > 0)
        {
            transform.localScale -= new Vector3(destroySpeed * Time.deltaTime, destroySpeed * Time.deltaTime);
            yield return null;
        }
        gameObject.SetActive(false);
    }

}
