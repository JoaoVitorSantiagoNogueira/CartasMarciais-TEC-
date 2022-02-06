using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseControl : MonoBehaviour
{
    // Start is called before the first frame update

    card currentlyShowed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = LayerMask.GetMask("PlayerA");
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {   
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                cardZone cu = (cardZone) hit.transform.gameObject.GetComponent<cardZone>();
                if (cu != null)
                {
                   cu.click();
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (currentlyShowed != null)
            {
                currentlyShowed.returnToPosition();
                currentlyShowed = null;
            }
            else
            {
                int cardLayerMask = LayerMask.GetMask("Card");
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, cardLayerMask))
                {
                  currentlyShowed = (card) hit.transform.gameObject.GetComponent<card>();
                    if (currentlyShowed != null)
                    {
                     currentlyShowed.zoomToPlayer();
                    }
                }
            }
        }


        if (Input.GetMouseButtonUp(0))
        {   
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                cardZone cu = (cardZone) hit.transform.gameObject.GetComponent<cardZone>();
                if (cu != null)
                {
                   cu.release();
                }
            }
        }
    }
}
