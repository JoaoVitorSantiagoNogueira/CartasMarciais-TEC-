using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseControl : MonoBehaviour
{
    // Start is called before the first frame update
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
