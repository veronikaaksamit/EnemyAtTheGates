using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusTargetManager : MonoBehaviour
{
    public IEnemyUnit FocusTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButton(0))
	    {
	        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	        RaycastHit hit;
	        if (Physics.Raycast(ray, out hit))
	        {
	            IEnemyUnit enemyUnit = hit.collider.gameObject.GetComponent<IEnemyUnit>();

	            if (enemyUnit == null)
	            {
	                return;
	            }

	            FocusTarget = enemyUnit;
	        }

        }
	}
}
