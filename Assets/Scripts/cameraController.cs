using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [SerializeField] float smoothSpeed;
    private float eskiKonum;
    private float yeniKonum;
    void Start()
    {
        eskiKonum = transform.position.y;
    }

    void Update()
    {
        if (target.position.y > transform.position.y)
        {
            //transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);

            
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
            
            //eskiKonum = transform.position.y;
        }
        
    }
}
