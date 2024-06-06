using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        Vector2 offset = direction.normalized * (_speed * Time.deltaTime);
        _rigidbody.MovePosition(_rigidbody.position + offset);
    }
}
