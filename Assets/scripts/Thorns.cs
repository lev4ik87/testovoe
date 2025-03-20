using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<SphereScore>(out SphereScore score))
        {
            score.RemoveScore();
            collision.gameObject.GetComponent<DestroySphere>().DestoySphere();
        }
    }
}
