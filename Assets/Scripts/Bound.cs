using UnityEngine;

public class Bound : MonoBehaviour
{
    [SerializeField] private Transform vector_right;
    [SerializeField] private Transform vector_left;
    [SerializeField] private Transform vector_back;
    [SerializeField] private Transform vector_forward;
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, vector_left.position.x, vector_right.position.x);
        pos.z = Mathf.Clamp(pos.z, vector_back.position.z, vector_forward.position.z);
        transform.position = pos;
    }
}