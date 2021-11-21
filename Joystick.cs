using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : Singleton<Joystick>
{
    [SerializeField]
    Transform Root, Pad;
    [SerializeField]
    float MaxR = 1;
    
    [SerializeField]
    bool isTouching = false;
    Vector2 Origin = new Vector2(0, 0);
    Vector3 touchPosition;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Gett();
        //ListenTouch2();
        ReleaseTouch();
    }

    void Gett()
    {
        for (int i = 0; i < Input.touchCount ; i++)
        {
            touchPosition = Input.touches[i].position;
            ListenTouch();
        }
    }


    void ListenTouch()
    {

        if (touchPosition.x > Screen.width / 2 && isTouching == false)
            return;
        if (touchPosition.y > Screen.height / 2 && isTouching == false)
            return;

        if (!isTouching)
        {
            isTouching = true;
            Origin = touchPosition;
            Root.position = Origin;
            Pad.position = Origin;
            Root.gameObject.SetActive(true);
            return;
        }

        // set max space that the pad can move
        Vector2 currentTouch = (Vector2)touchPosition - Origin;
        if (currentTouch == Vector2.zero)
            return;
        if (currentTouch.magnitude <= MaxR)
        {
            Pad.position = touchPosition;
            return;
        }
        float currentAngle = Mathf.Atan2(currentTouch.y, currentTouch.x);
        float X = Origin.x + MaxR * Mathf.Cos(currentAngle);
        float Y = Origin.y + MaxR * Mathf.Sin(currentAngle);
        Pad.position = new Vector2(X, Y);

    }


    void ListenTouch2()
    {
        if (!Input.GetMouseButton(0))
            return;

        if (Input.mousePosition.x > Screen.width / 2 && isTouching == false)
            return;
        if (Input.mousePosition.y > Screen.height / 2 && isTouching == false)
            return;

        if (!isTouching)
        {
            isTouching = true;
            Origin = Input.mousePosition;
            Root.position = Origin;
            Pad.position = Origin;
            Root.gameObject.SetActive(true);
            return;
        }

        // set max space that the pad can move
        Vector2 currentTouch = (Vector2)Input.mousePosition - Origin;
        if (currentTouch == Vector2.zero)
            return;
        if (currentTouch.magnitude <= MaxR)
        {
            Pad.position = Input.mousePosition;
            return;
        }
        float currentAngle = Mathf.Atan2(currentTouch.y, currentTouch.x);
        float X = Origin.x + MaxR * Mathf.Cos(currentAngle);
        float Y = Origin.y + MaxR * Mathf.Sin(currentAngle);
        Pad.position = new Vector2(X, Y);
    }


    // hide joystick when player release touch
    void ReleaseTouch()
    {
        if (!isTouching)
            return;
        if (Input.GetMouseButtonUp(0))
        {
            isTouching = false;
            Root.gameObject.SetActive(false);
        }

    }

    // get direction of JoyVector
    public Vector2 GetJoyVector()
    {
        if (!isTouching)
            return Vector2.zero;
        Vector2 tmp = (Vector2)Input.mousePosition - Origin;
        return tmp.normalized;

    }


    public Vector2 GetJoyVectorRaw()
    {
        Vector2 Jv = this.GetJoyVector();
        if (Mathf.Abs(Jv.x) > Mathf.Abs(Jv.y))   // JoyStick is Horizontal
        {
            if (Jv.x > 0)                          // turn right
                return new Vector2(1, 0);
            if (Jv.x < 0)                          // turn left
                return new Vector2(-1, 0);
        }
        else if (Mathf.Abs(Jv.x) < Mathf.Abs(Jv.y))   // JoyStick is Vertical
        {
            if (Jv.y > 0)                            // turn up
                return new Vector2(0, 1);
            if (Jv.y < 0)                            // turn down
                return new Vector2(0, -1);
        }
        return Vector2.zero;
    }

}
