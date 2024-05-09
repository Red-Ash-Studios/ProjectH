using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform _camera;

    void Update()
    {
        transform.LookAt(_camera);
    }
}
