using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// [RequireComponent(typeof(GameObject))]
public class CameraFollow : MonoBehaviour
{
	public GameObject tesla;
    public float xSmooth = 8f; // How smoothly the camera catches up with it's target movement in the x axis.
    public Vector2 maxXAndY; // The maximum x and y coordinates the camera can have.
    public Vector2 minXAndY; // The minimum x and y coordinates the camera can have.
    public float xMargin = 1f; // Distance in the x axis the player can move before the camera follows.

    private void Start()
    {
    }

    private bool CheckXMargin()
    {
        // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
        return (transform.position.x - tesla.transform.position.x) < xMargin;
    }

    public void Update()
    {
        float targetX = tesla.transform.position.x;
        /*if (CheckXMargin())
        {
            targetX = Mathf.Lerp(transform.position.x, tesla.transform.position.x, xSmooth * Time.deltaTime);
        }*/

        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);

    }

}

