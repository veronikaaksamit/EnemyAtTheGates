using System;
using System.Collections;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class UtilityCostUpdater : MonoBehaviour {

        public Player MyPlayer;

        private Text[] texts;

        // Use this for initialization
        void Start()
        {
            texts = GetComponentsInChildren<Text>(true);
        }
        

        public void UpdateTexts(String tag)
        {
            if (tag == null)
            {
                Debug.Log("called with tag null");
            }
            //Debug.Log("number of texts in UCUpdater "+ texts.Length);
            GameResources[] resources = MyPlayer.GetValueOfUtility(tag);
            
            if (resources != null)
            {
                for (int i = 0; i < texts.Length; i++)
                {
                    switch (texts[i].tag)
                    {
                        case "ManPower":
                            texts[i].text = resources[0].Count.ToString();
                            break;
                        case "Munition":
                            texts[i].text = resources[2].Count.ToString();
                            break;
                        case "Weapons":
                            texts[i].text = resources[1].Count.ToString();
                            break;
                        case "Text":
                            if (!MyPlayer.CanUseThatElement(tag))
                            {
                                ShowNotEnoughFor2Sec(texts[i]);
                            }
                            break;
                        case "Untagged": break;
                        default:
                            Debug.Log(texts[i].tag + "   is not between cases");
                            break;
                    }
                }
            }
            else
            {
                Debug.Log("Problem with utilities with tag (in UCostUpadter)"+ tag);
            }


        }

        public IEnumerator ShowNotEnoughFor2Sec(Text t)
        {
            t.GetComponent<Text>().text = "Not enough resources";
            yield return new WaitForSeconds(3);
            t.GetComponent<Text>().text = "";
        }
    }
}

