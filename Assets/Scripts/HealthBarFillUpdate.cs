using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFillUpdate : MonoBehaviour
{

    private Image m_healthBar;
    private IEnemyUnit m_unit;
    private float m_unitStartHealth;

	// Use this for initialization
	void Start ()
	{
	    m_healthBar = GetComponent<Image>();
	    m_unit = GetComponentInParent<IEnemyUnit>();
	    m_unitStartHealth = m_unit.GetHealth();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    m_healthBar.fillAmount = m_unit.GetHealth() / m_unitStartHealth;
	}
}
