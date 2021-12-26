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
        if (Input.GetMouseButtonUp(0))
            releaseDrag(Vector3.zero);
        if (selectedToMove)
        {
            Vector3  dif =  Camera.main.ScreenToWorldPoint(Input.mousePosition+cameraDistance*Vector3.forward)-selectedMousePosition ;
            transform.position = dif + basePosition;
        }              
    }

    public void startDrag(Vector3 selectedMousePosition)
    {
        if (selectedToMove == false)
        {
        basePosition = transform.position;
        cameraDistance = Camera.main.transform.position.y - basePosition.y;
        selectedToMove = true; 
        this.selectedMousePosition = Camera.main.ScreenToWorldPoint(selectedMousePosition+cameraDistance*Vector3.forward);
        }
    }

    public void releaseDrag(Vector3 selectedMousePosition)
    {
        // if not in a place where you can change zones
        if (selectedToMove == true)
        {
            selectedToMove = false; 
            this.selectedMousePosition = Vector3.zero;
            transform.position = basePosition;
        }
    }
}
