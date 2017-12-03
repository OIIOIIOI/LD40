using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        
    //public float smoothing = 5f;
    public float lUnityPlaneSize = 10.0f;
    public float bgScrollSpeed = 0.1f;


    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
        offset.y = 3.5f;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;

        Camera lCamera = Camera.main;
        float lSizeY = lCamera.orthographicSize * 2f;
        float lSizeX = lSizeY * lCamera.aspect;

        Vector3 diff = transform.position - targetCamPos;
        float offX = diff.x / lSizeX;
        float offY = diff.y / lSizeY;

        Transform plane = transform.Find("Plane");
        MeshRenderer mr = plane.gameObject.GetComponent<MeshRenderer>();
        mr.material.mainTextureOffset += new Vector2(offX, offY);

        //float bgScaleX = lCamera.pixelWidth / 800;
        //float bgScaleY = lCamera.pixelHeight / 800;
        //mr.material.mainTextureScale = new Vector2(1f / bgScaleX, 1f / bgScaleY);

        transform.position = targetCamPos;
    }

    void Update()
    {
        Transform plane = transform.Find("Plane");
        Camera lCamera = Camera.main;
        float lSizeY = lCamera.orthographicSize * 2f;
        float lSizeX = lSizeY * lCamera.aspect;
        plane.localScale = new Vector3(lSizeX / lUnityPlaneSize, 1, lSizeY / lUnityPlaneSize);
    }
}