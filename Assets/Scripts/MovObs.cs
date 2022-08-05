using UnityEngine;

public class MovObs : MonoBehaviour
{
    private int contact = 1;
    private float fix = .5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Side"))
        {
            contact *= -1;
        }
    }
    void FixedUpdate()
    {
        if (ButtonManager.allow)
        {
            if (contact == 1)
            {
                transform.Translate(Vector3.right * fix);
            }
            if (contact == -1)
            {
                transform.Translate(Vector3.left * fix);
            }
        }
    }
}