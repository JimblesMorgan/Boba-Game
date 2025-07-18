using UnityEngine;

public class DetectMouse : MonoBehaviour
{
    public Camera myCamera;
    public GameObject parentobject;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            Ray myRay = myCamera.ScreenPointToRay(mousePosition);

            RaycastHit raycastHit;

            bool weHitSomething = Physics.Raycast(myRay, out raycastHit);

            if (weHitSomething)
            {
                parentobject = transform.parent.gameObject;
                Debug.Log("pickup");
            }
        }
  
    }
}
