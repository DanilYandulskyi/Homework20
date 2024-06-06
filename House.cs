using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Robber robber))
            _signaling.Play();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Robber robber))
            _signaling.Stop();
    }
}
