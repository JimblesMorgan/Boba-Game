using UnityEngine;

public class PickupController : MonoBehaviour
{
    [SerializeField] private Transform holdPoint;

    private GameObject heldObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            if (heldObject == null)
            {
                PickUp(other.gameObject);
            }
        }
    }

    private void PickUp(GameObject item)
    {
        heldObject = item;
        item.transform.SetParent(holdPoint);                  // Parent to hand
        item.transform.localPosition = Vector3.zero;          // Reset position
        item.transform.localRotation = Quaternion.identity;   // Reset rotation

        // Optional: Disable physics so it doesn’t fall
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }

    public void Drop()
    {
        if (heldObject != null)
        {
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
            }

            heldObject.transform.SetParent(null); // Unparent
            heldObject = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (heldObject != null))
        {
            Drop();
        }
    }

}
