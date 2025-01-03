using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;

    private void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
    }

    private void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawLine(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            var interactable = hitInfo.collider.GetComponent<IInteract>();
            if (interactable != null && gameObject.GetComponent<InputManager>().onFoot.Interact.triggered)
            {
                interactable.Interact();
            }
        }
    }
}
