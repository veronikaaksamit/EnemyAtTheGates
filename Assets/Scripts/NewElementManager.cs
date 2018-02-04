using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Assets.Scripts
{
    public class NewElementManager : MonoBehaviour
    {
        public Player MyPlayer;
        public UnityEvent CheckButtons;
        public GameObject[] Elements;

        private String SelectedButtonTag = "";


        void Start ()
        {
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

                                if (hit.collider.gameObject.tag == "House" && !IsBarrier() )
                                {
                                    if (CanUseThatElement())
                                    {
                                        GameObject house = hit.collider.gameObject;
                                        Vector3 position = house.transform.position;
                                        Destroy(hit.collider.gameObject);
                                        created = Instantiate(element, position, Quaternion.identity);
                                        UseThatElement();
                                    }
                                }

                                if (hit.collider.gameObject.tag == "Floor" && IsBarrier())
                                {
                                    created = InstantiateElement(element, hit);
                                }

                                GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
                                

                                if (created != null && closestObject != null)
                                {
                                    if (closestObject.GetComponent<Collider>().bounds.Intersects(created.GetComponent<Collider>().bounds))
                                    {
                                        //Debug.Log("Bounds intersecting " + closestObject.tag );
                                    }
                                }
                            }
                        }

                    }

                }
            }
        }

        public void SetSelectedButtonTag(String newItemTag)
        {
            SelectedButtonTag = newItemTag;
        }

        private GameObject InstantiateElement(GameObject element, RaycastHit hit)
        {
            GameObject created = null;
            if (CanUseThatElement())
            {
                created = Instantiate(element, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                
                UseThatElement();
                if (CheckButtons != null)
                {
                    CheckButtons.Invoke();
                }

            }
            return created;
        }

        private bool IsBarrier()
        {
            switch (SelectedButtonTag)
            {
                case "BarbedWire":
                case "Mine":
                case "TankBarrier":
                case "Barrier": return true;
                case "Soldier":
                case "Sniper":
                case "MachineGun":
                case "AntiAircraftW": return false;
                    default: Debug.Log(SelectedButtonTag + " is not stated in IsBarrier");
                        break;
            }
            return false;
        }

        private bool CanUseThatElement()
        {
            bool canUse = MyPlayer.CanUseThatElement(SelectedButtonTag);
            if (!canUse)
            {
                Debug.Log("Can not use "+ SelectedButtonTag);
            }
            return canUse;
        }

        private void UseThatElement()
        {
            MyPlayer.UseThatElement(SelectedButtonTag);
        }
        

        private GameObject GetElementToInstantiate()
        {
            GameObject result = null;
            for (int i = 0; i < Elements.Length; i++)
            {
                if (Elements[i].tag == SelectedButtonTag)
                {
                    result = Elements[i];
                }

                if (Elements[i].tag == "House")
                {
                    SpriteRenderer[] sprites = Elements[i].GetComponentsInChildren<SpriteRenderer>();
                    for (int j = 0; j < sprites.Length; j++)
                    {
                        if (sprites[j].tag!= "Untagged" && sprites[j].tag == SelectedButtonTag)
                        {
                            return Elements[i];
                        }
                    }
                }
            }
            if (result == null)
            {
                Debug.Log("Problem with tag"+ SelectedButtonTag);
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
                //Debug.Log("closest object is " + closestCollider.gameObject.tag + " pos "+ closestCollider.gameObject.transform.position);
                return closestCollider.gameObject;
            }
            return null;
        }
    }
}
