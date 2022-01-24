using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : cardZone
{
  Vector3 selectedMousePosition, basePosition;
  bool selectedToMove = false;
  float cameraDistance;

  public virtual void Start()
  {
    cardCap = 1;
  }
  public virtual void Update ()
  {
    if (Input.GetMouseButtonUp(0) && selectedToMove)
        release();
    if (selectedToMove)
        {
            Vector3  dif =  Camera.main.ScreenToWorldPoint(Input.mousePosition+cameraDistance*Vector3.forward)-selectedMousePosition ;
            GetCard(0).transform.position = dif + basePosition;
        }  
  }
  public override void release ()
    {
      if (hasCard && selectedToMove)
      {
        int layerMask = LayerMask.GetMask("PlayerA");
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                cardZone cz = (cardZone) hit.transform.gameObject.GetComponent<cardZone>();
                if (cz != null)
                {
                  if (cz.hasSpace())
                  {
                   cz.AddCard(this.moveCardFrom(0));
                   selectedToMove = false; 
                   hasCard= false;
                   return;
                  }

                }
            }
        // if not in a place where you can change zones return to base position
        if (selectedToMove)
        {
            Debug.Log("release");
            selectedToMove = false; 
            this.selectedMousePosition = Vector3.zero;
            GetCard(0).transform.position = basePosition;
        }
      }
    }

  public override void click ()
    {
      Debug.Log(hasCard);
        if (!selectedToMove && hasCard)
        {
        Debug.Log("selected");
        basePosition = GetCard(0).transform.position;
        cameraDistance = Camera.main.transform.position.y - basePosition.y;
        selectedToMove = true; 
        this.selectedMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition+cameraDistance*Vector3.forward);
        }
    }

  public override void AddCard(card c)
  {
    c.transform.position = transform.position + Vector3.up*0.3f;
    base.AddCard(c);
  }

  public override void mouseOver ()
    {
        //adicionar caixa mostrar infomação
    }

}
