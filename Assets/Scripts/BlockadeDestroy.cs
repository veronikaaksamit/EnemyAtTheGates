using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlockadeDestroy : MonoBehaviour
{
    void Start()
    { }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyDestroyBlockade component = other.gameObject.GetComponent<EnemyDestroyBlockade>();
            if (component != null && component.BlockadeTag == tag)
            {
                //TODO zastaveni jednotky
                Invoke("DestroyBlockade", component.TimeToDestroy);
            }
        }
    }

    void DestroyBlockade()
    {
        //TODO rozpohobyhovani jednotky
        Destroy(gameObject);
    }
}
