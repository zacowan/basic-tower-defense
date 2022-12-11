using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float PanSpeed = 50f;
    private const float PanScreenPadding = 10f;
    private const float ScrollSpeed = 5f;
    private const float MinY = 10f;
    private const float MaxY = 80f;
    private const float scrollFactor = 100f;

    // Update is called once per frame
    void Update()
    {
        bool mouseIsAtTop = Input.mousePosition.y >= Screen.height - PanScreenPadding;
        bool mouseIsAtLeft = Input.mousePosition.x <= PanScreenPadding;
        bool mouseIsAtBottom = Input.mousePosition.y <= PanScreenPadding;
        bool mouseIsAtRight = Input.mousePosition.x >= Screen.width - PanScreenPadding;

        // Camera movement
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * PanSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * PanSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * PanSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * PanSpeed * Time.deltaTime, Space.World);
        }

        // Camera zooming
        float scroll = Input.mouseScrollDelta.y;

        if (scroll != 0)
        {
            Vector3 position = transform.position;
            position.y -= scroll * scrollFactor * ScrollSpeed * Time.deltaTime;
            position.y = Mathf.Clamp(position.y, MinY, MaxY);
            transform.position = position;
        }
    }
}
