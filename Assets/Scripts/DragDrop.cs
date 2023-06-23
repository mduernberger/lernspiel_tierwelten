using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{


    public string targetTag = "Erdteil";
    public string zugehoerigerName = "ZugehoerigerName";
    public float snapDistance = 0.5f;
    public Button checkButton;

    private bool isDragging = false;
    private GameObject draggedObject;
    private Vector3 initialPosition;
    private bool richtigesHeimatland = false;
    private bool isPlaced;



    private void Start()
    {
        isPlaced = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Tier"))
            {
                isDragging = true;
                draggedObject = hit.collider.gameObject;
                initialPosition = draggedObject.transform.position;
                richtigesHeimatland = false;
                isPlaced = false;

                StaticVariable.statischRichtigFalsch = richtigesHeimatland;

            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging && draggedObject != null)
            {
                if (CheckTriggerCollision(out GameObject triggeredObject))
                {
                    SnapToPosition(triggeredObject.transform.position);
                    isPlaced = true;

                    if (triggeredObject.name == zugehoerigerName)
                    {

                        richtigesHeimatland = true;
                        

                        StaticVariable.statischRichtigFalsch = richtigesHeimatland;


                        Debug.Log("Richtig!");
                    }
                    else
                    {
                        Debug.Log("Falsch");
                    }
                }

                isDragging = false;
                draggedObject = null;
            }
        }

        if (isDragging && draggedObject != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = initialPosition.z; // Behält die ursprüngliche Z-Koordinate bei
            draggedObject.transform.position = mousePosition;
        }

        if (isPlaced)
        {
            checkButton.interactable = true;
        }
        else
        {
            checkButton.interactable = false;
        }
    }

    private bool CheckTriggerCollision(out GameObject triggeredObject)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(draggedObject.transform.position, draggedObject.GetComponent<SpriteRenderer>().bounds.size, 0f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(targetTag))
            {
                triggeredObject = collider.gameObject;
                return true;
            }
        }

        triggeredObject = null;
        return false;
    }

    private void SnapToPosition(Vector3 targetPosition)
    {
        float distance = Vector3.Distance(draggedObject.transform.position, targetPosition);
        if (distance <= snapDistance)
        {
            draggedObject.transform.position = targetPosition;
        }
    }

    
}













