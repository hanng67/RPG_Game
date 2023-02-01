using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Tilemap theMap;
    [SerializeField]
    private bool isFollowPlayer = true;

    private Transform target;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private float halfHeigh;
    private float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;

        halfHeigh = Camera.main.orthographicSize;
        halfWidth = halfHeigh * Camera.main.aspect;

        bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeigh, 0f);
        topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeigh, 0f);

        PlayerController.Instance.SetBound(theMap.localBounds.min, theMap.localBounds.max);
    }

    // LateUpdate is called once per frame after Update()
    void LateUpdate()
    {
        if(!isFollowPlayer) return;
        
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        // keep the camera inside the bound
        float boundX = Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x);
        float boundY = Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y);
        transform.position = new Vector3(boundX, boundY, transform.position.z);
    }
}
