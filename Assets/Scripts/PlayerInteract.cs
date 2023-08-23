using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform _interactPoint;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            IInteractable interactable = GetInteractableObject();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (_interactPoint == null) return;

        Color a = Gizmos.color;
        a.a = 0.2f;
        Gizmos.color = a;

        float interactRange = 1f;
        Gizmos.DrawSphere(_interactPoint.position, interactRange);
    }

    public IInteractable GetInteractableObject()
    {
        List<IInteractable> interactables = new List<IInteractable>();
        float interactRange = 1f;
        Collider[] colliders = Physics.OverlapSphere(_interactPoint.position, interactRange);
        foreach (Collider item in colliders)
        {
            if (item.TryGetComponent(out IInteractable interactable))
            {
                if (interactable.IsEnable())
                    interactables.Add(interactable);
            }
        }

        // Find closest in list
        IInteractable closestInteractable = null;
        foreach (IInteractable item in interactables)
        {
            if (closestInteractable == null)
            {
                closestInteractable = item;
            }
            else
            {
                if (Vector3.Distance(transform.position, item.GetTransform().position) <
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
                {
                    closestInteractable = item;
                }
            }
        }

        return closestInteractable;
    }
}