using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    private int layerIndex;
    [SerializeField]private float distance;
    [SerializeField] private Transform ray;
    [SerializeField] private Transform hold;
    
    private GameObject pickedUpObject;

    private void Awake()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
    }


    void Update()
    {

        RaycastHit2D isHit = Physics2D.Raycast(ray.position, transform.right, distance);

        if (Input.GetKeyDown(KeyCode.Mouse0) && pickedUpObject == null)
        {
            
            pickedUpObject = isHit.collider.gameObject;
            pickedUpObject.GetComponent<Rigidbody2D>().isKinematic = true;
            pickedUpObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            pickedUpObject.GetComponent<Collider2D>().enabled = false;
            pickedUpObject.transform.position = hold.position;
            pickedUpObject.transform.SetParent(transform);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            pickedUpObject.GetComponent<Rigidbody2D>().isKinematic = false;
            pickedUpObject.transform.SetParent(null);
            pickedUpObject.GetComponent<Collider2D>().enabled = true;
            pickedUpObject = null;
        }

        Debug.DrawRay(ray.position, transform.right * distance);
    }
}


