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
    if (selectedToMove && hasCard)
        {
            Vector3  dif =  Camera.main.ScreenToWorldPoint(Input.mousePosition+cameraDistance*Vector3.forward)-selectedMousePosition ;
            GetCard(0).transform.position = dif + basePosition;
        }  
  }

    public void OnDestroy()
    {

    }

  public override void release ()
    {
      if (selectedToMove)
      {
          selectedToMove = false; 
          this.selectedMousePosition = Vector3.zero;
        if (hasCard)
        {
          int layerMask = LayerMask.GetMask("PlayerA");
          Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
          RaycastHit hit;
              if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
              {
                  cardZone cz = (cardZone) hit.transform.gameObject.GetComponent<cardZone>();
                  if (cz != null)
                  {
                    if (moveCardFrom(0,cz))
                    {
                      return;
                    }
                  }
              }
            GetCard(0).transform.position = basePosition;
        }
          
        }
    }

  public override void click ()
    {
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

    public void move (Vector3 v)
    {
      transform.position = v;
      if (hasCard)
      {
        basePosition = GetCard(0).transform.position = v + Vector3.up*0.3f;
      }
    }

    public override void RemoveCard(int i)
    {
      base.RemoveCard(i);
      Debug.Log(hasCard);
      if (!hasCard)
        {
          Destroy(this.gameObject);
          EventController.instance.removeHand();
        }
    }

}
