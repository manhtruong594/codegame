using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickGameObject : MonoBehaviour
{

    public UnityEvent OnClick = new UnityEvent();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rayDir = Camera.main.transform.position - mousePos;

            RaycastHit2D hit = Physics2D.Raycast(mousePos, rayDir);

            //Debug.DrawRay(mousePos, rayDir);
            
            if(hit.collider.gameObject == this.gameObject && Vector3.Distance((Vector2)mousePos, (Vector2)hit.collider. transform.position) <= 0.4f)
            {
                Debug.Log(hit.collider.name);
            }
        }
    }

    
}