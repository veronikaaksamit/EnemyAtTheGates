using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // remember to set these when firing
    public float damage = -1;
    public IPlayerUnit firedFrom;
    public float accuracy = 1.0f;

    void OnCollisionEnter(Collision collision)
    {
        IEnemyUnit hitUnit = collision.gameObject.GetComponent<IEnemyUnit>();

        if (hitUnit == null)
        {
            Destroy(gameObject);
            return;
        }

        hitUnit.TakeDamage(damage, firedFrom);
        Destroy(gameObject);
    }

}
