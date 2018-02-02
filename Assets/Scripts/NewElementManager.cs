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
                        if (element != null)
                        {
                            if (hit.collider.gameObject.tag == "House" && selectedButtonIndex > 2)
                            {
                                GameObject house = hit.collider.gameObject;
                                Vector3 position = house.transform.position;
                                //Instantiate(element, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                                Instantiate(element, position, Quaternion.identity);
                            }
                            else
                            {
                                if (selectedButtonIndex < 3)
                                {
                                    Instantiate(element, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
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
            GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
            selectedButtonIndex = 10;
        }
        return result;
    }
}
