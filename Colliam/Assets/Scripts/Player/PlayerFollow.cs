using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;       
    private Vector3 _offset;        

    void Start()
    {
        _offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        transform.position = player.position + _offset;
    }
}
