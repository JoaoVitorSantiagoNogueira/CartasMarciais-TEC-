using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    Vector3 selectedMousePosition, basePosition;
    float cameraDistance;
    bool selectedToMove = false;

    // Start is called before the first frame update
    void Start()
    {
        basePosition = transform.position;
        cameraDistance = Camera.main.transform.position.y - basePosition.y;;
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedToMove)
        {
            Vector3  dif =  Camera.main.ScreenToWorldPoint(Input.mousePosition+cameraDistance*Vector3.forward)-selectedMousePosition ;
            transform.position = dif + basePosition;
        }              
    }

    public void startDrag(Vector3 selectedMousePosition)
    {
        selectedToMove = true; 
        this.selectedMousePosition = Camera.main.ScreenToWorldPoint(selectedMousePosition+cameraDistance*Vector3.forward);
    }
}
