using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Item : MonoBehaviour
{
    enum Axis
    {
        Y = 1,
        X = -1
    }

    [SerializeField] private Axis _axis= Axis.Y;  //set axis move
    [SerializeField] private Transform playerModel;
    private Vector3 mouseFirstPosition;
    private Vector3 mouseLastPosition;

    private bool isMove;
   

    private void OnMouseDown()
    {
        mouseFirstPosition = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        mouseLastPosition = Input.mousePosition;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        Vector2 directionMouse = (mouseLastPosition - mouseFirstPosition).normalized;
        switch (_axis) //checking and setting the axis for movement
        {
            case Axis.Y:
                directionMouse.x = 0;
                directionMouse.y=Mathf.Round(directionMouse.y);
                break;
            case Axis.X:
                directionMouse.y = 0;
                directionMouse.x=Mathf.Round(directionMouse.x);
                break;
        }
        Vector3 direction = new Vector3(directionMouse.x, 0, directionMouse.y);
        RaycastHit hit;
        if (Physics.Raycast(transform.parent.position, direction, out hit,Mathf.Infinity))
        {
            if (Vector3.Distance(transform.parent.position,hit.point)>GameManager.instanse.maxDistance) //Checking the distance to be able to move the object
            {
                isMove = true;
                while (isMove)
                {
                    transform.parent.Translate(direction * GameManager.instanse.speedObjects * Time.deltaTime);
                    yield return null;
                }
            }
            
        }
    }

    
    private void OnCollisionEnter(Collision other)
    {
        if (isMove && !other.transform.CompareTag("Ground"))
        {
            if (!other.transform.CompareTag("Finish"))
            {
                isMove = false;
                StopCoroutine(Move());
                EventManager.UseStep.Invoke();
            }
            
            if (other.transform.CompareTag("Finish") && playerModel!=null)
            {
                isMove = false;
                StopCoroutine(Move());
                playerModel.DOMove(other.transform.parent.position, 1.5f).OnComplete(() =>
                {
                    EventManager.Win.Invoke();
                    Destroy(gameObject);
                }); 
            }
            
            if (other.transform.CompareTag("Clock") && playerModel!=null)
            {
                isMove = false;
                StopCoroutine(Move());
                EventManager.GameOver.Invoke();
            }
            
            if (other.transform.CompareTag("MagicLight"))
            {
                if (playerModel!=null)
                {
                    isMove = false;
                    StopCoroutine(Move());
                    EventManager.GameOver.Invoke();
                }
                else
                {
                    Destroy(other.gameObject);
                    Destroy(transform.parent.gameObject);
                    EventManager.UseStep.Invoke();
                }
            }
            
        }
    }


   
}
