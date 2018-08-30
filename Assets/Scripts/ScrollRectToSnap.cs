using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectToSnap : MonoBehaviour {

    //public Variables
    public RectTransform panel; //Holds scroll panel
    public Button[] bttn;
    public RectTransform center; //Center to compare the distance for each button

    //Private variables
    private float[] distance; //stores each buttons distance to the center.
    private bool dragging = false; //will be true as panel is dragged.
    private int bttnDistance; //Stores distance between the buttons.
    private int minButtonNum; //To hold the number of buttom with smallest distance to center.

    void Start()
    {
        int bttnLength = bttn.Length;
        distance = new float[bttnLength];

        //Get distance between buttons
        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
    }

    void Update()
    {
        //for each button, calculate it's distance compared to the center game object.
        for (int i = 0; i < bttn.Length; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - bttn[i].transform.position.x);
        }

        float minDistance = Mathf.Min(distance); //Min distance to center.

        //Find and store the array number of the button with the smallest distance to the center.
        for (int a = 0; a < bttn.Length; a++)
        {
            if (minDistance == distance[a])
            {
                minButtonNum = a;
            }
        }

        if (!dragging)
        {
            LerpToBttn(minButtonNum * -bttnDistance);
        }


    }

    void LerpToBttn(int position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 10f);
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }
}
