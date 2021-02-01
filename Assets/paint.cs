using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class paint : MonoBehaviour
{
    private Color[] colors = { Color.green, Color.red, Color.white, Color.blue, Color.yellow, Color.black };
    private GameObject circle;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.GetComponent<Image>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        ClickTarget();
    }

    public void ChangeColor()
    {
        this.gameObject.GetComponent<Image>().color = colors[i];
        if (i <=4)
        {
            i++;
        }
        else
        {
            i = 0;
        }
        
    }
    private void ClickTarget()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())//If we click the left mouse button
        {
            //Makes a raycast from the mouse position into the game world
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, 256);

            if (hit.collider != null) //If we hit something
            {
                Debug.Log(hit.collider.name);
                hit.collider.GetComponent<SpriteRenderer>().color = this.gameObject.GetComponent<Image>().color;
            }

        }
    }
}
