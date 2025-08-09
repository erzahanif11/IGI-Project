using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    void Update()
    {
        Vector3 origin = transform.position + Vector3.up * 1f;
        Vector3 direction = Vector3.forward;
        Vector3 direction2 = transform.right;
        float directionLength = 3f;
        float direction2Length = 1f;

        Debug.DrawRay(origin, direction * directionLength, Color.red);
        Debug.DrawRay(origin, direction2 * direction2Length, Color.blue);

        RaycastHit hit;
        if (Physics.Raycast(origin, direction, out hit, directionLength) || Physics.Raycast(origin, direction, out hit, direction2Length))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null && Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact(transform);
            }
        }
    }
}
