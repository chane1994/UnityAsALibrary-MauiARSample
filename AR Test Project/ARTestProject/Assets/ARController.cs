using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{

    public GameObject placedObject;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;
    public ARSession arSession;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ARSession.state == ARSessionState.Ready || ARSession.state == ARSessionState.SessionTracking)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    TryPlaceObject(Input.GetTouch(0).position);
                }
            }

        }
    }

    public void TryPlaceObject(Vector2 pos)
    {
        List<ARRaycastHit> objs = new List<ARRaycastHit>();
        if (raycastManager.Raycast(pos,objs, UnityEngine.XR.ARSubsystems.TrackableType.AllTypes))
        {
            if(objs.Count > 0)
            {
                var o = objs[0];
                Instantiate<GameObject>(placedObject, o.pose.position, o.pose.rotation);
            }      
            

        }
    }
}
