using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Robber : MonoBehaviour
{
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        Vector2 direction = Vector2.zero;
        Vector2 posibleXDriction = Vector2.right;

        if (Input.GetKey(KeyCode.RightArrow))
            direction += posibleXDriction;        
        if (Input.GetKey(KeyCode.LeftArrow))
            direction -= posibleXDriction;

        _mover.Move(direction);
    }
}