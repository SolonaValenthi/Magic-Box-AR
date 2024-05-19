using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputRaycaster : MonoBehaviour
{
    Camera _mainCam;

    // Start is called before the first frame update
    void Start()
    {
        _mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            TouchRaycast();
        }
    }

    private void TouchRaycast()
    {
        if (!ExaminableManager.Instance.isExamining)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = _mainCam.ScreenPointToRay(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform.CompareTag("Gem"))
                {
                    hit.transform.GetComponent<Gem>().Pressed();
                }
            }
        }
    }
}
