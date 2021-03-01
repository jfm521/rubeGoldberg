using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    public Transform followTransform;
    public Transform followTransform1;
    public Transform followTransform2;
    public BoxCollider2D worldbounds;

    public float ball1y;
    public float ball2y;
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    float camX;
    float camY;

    float camRatio;
    float camSize;

    Camera mainCam;

    Vector3 smoothPos;

    public float smoothRate;

    // Start is called before the first frame update
    void Start()
    {
        //xMin = worldbounds.bounds.min.x;
        //xMax = worldbounds.bounds.max.x;
        //yMin = worldbounds.bounds.min.y;
        //yMax = worldbounds.bounds.max.y;

        xMin = -100;
        xMax = 100;
        yMin = -100;
        yMax = 100;

        mainCam = gameObject.GetComponent<Camera>();

        camSize = mainCam.orthographicSize;
        camRatio = (xMax + camSize) / 8.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (followTransform2.position.y <= ball2y)
        {
            camY = Mathf.Clamp(followTransform2.position.y, yMin + camSize, yMax - camSize);
            camX = Mathf.Clamp(followTransform2.position.x, xMin + camSize, xMax - camSize);
        }
        else if (followTransform1.position.y <= ball1y)
        {
            camY = Mathf.Clamp(followTransform1.position.y, yMin + camSize, yMax - camSize);
            camX = Mathf.Clamp(followTransform1.position.x, xMin + camSize, xMax - camSize);
        }
        else
        {
            camY = Mathf.Clamp(followTransform.position.y, yMin + camSize, yMax - camSize);
            camX = Mathf.Clamp(followTransform.position.x, xMin + camSize, xMax - camSize);
        }


        smoothPos = Vector3.Lerp(gameObject.transform.position, new Vector3(camX, camY, gameObject.transform.position.z), smoothRate);

        gameObject.transform.position = smoothPos;

    }
}
