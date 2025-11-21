using System;
using UnityEngine;

public class DeathBall : MonoBehaviour
{
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * (speed * Time.fixedDeltaTime));
    }
}
