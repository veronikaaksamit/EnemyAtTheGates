using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.Experimental.UIElements.Button;

public class NewElementManager : MonoBehaviour
{

    public GameObject[] Elements;
    public int selectedButtonIndex = 10;

	void Start () {
		
	}

    public void SetSelectedButtonIndex(int selectedButton)
    {
        selectedButtonIndex = selectedButton;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out  hit))
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    if (Elements.Length > 0)
                    {
                        GameObject element = GetElementToInstantiate();
                        GameObject created = null;
                        if (element != null)
                        {
                            GameObject closestObject = GetClosestObject(hit);

                            if (hit.collider.gameObject.tag == "House" && selectedButtonIndex > 2)
                            {
                                GameObject house = hit.collider.gameObject;
                                Vector3 position = house.transform.position;
                                created = Instantiate(element, position, Quaternion.identity);
                            }

                            if (hit.collider.gameObject.tag == "Floor" && selectedButtonIndex < 3)
                            {
                                created = Instantiate(element, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                            }

                            GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
                            selectedButtonIndex = 10;

                            if (created != null)
                            {
                                
                                if (closestObject.GetComponent<Collider>().bounds.Intersects(created.GetComponent<Collider>().bounds))
                                {
                                    Debug.Log("Bounds intersecting " + closestObject.tag );
                                }
                            }
                        }
                    }

                }

            }
        }
    }


    private GameObject GetElementToInstantiate()
    {
        GameObject result = null;
        if (Elements.Length > selectedButtonIndex)
        {
            result = Elements[selectedButtonIndex];
        }
        return result;
    }

    private GameObject GetClosestObject(RaycastHit hit)
    {
        Collider closestCollider = null;
        
        Collider[] colliders = Physics.OverlapBox(hit.point, new Vector3(0.5f, 0.5f, 0.5f));
            
        foreach (var c in colliders)
        {
            if (c.gameObject.tag != "Floor")
            {
                if (closestCollider == null)
                {
                    closestCollider = c;
                }

                if (Vector3.Distance(hit.point, c.gameObject.transform.position) <=
                    Vector3.Distance(hit.point, closestCollider.transform.position))
                {
                    closestCollider = c;
                }
            }

        }
        if (closestCollider != null)
        {
            Debug.Log("closest object is " + closestCollider.gameObject.tag + " pos "+ closestCollider.gameObject.transform.position);
        }
        return closestCollider.gameObject;
    }
}
