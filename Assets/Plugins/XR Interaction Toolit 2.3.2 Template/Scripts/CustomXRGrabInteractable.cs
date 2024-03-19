using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[DisallowMultipleComponent]
public class CustomXRGrabInteractable : XRGrabInteractable
{
    private Collider[] childColliders;
    private XROrigin player;

    public bool ignoreCollision = true;

    public bool IgnoreCollision
    {
        get => ignoreCollision;
        set
        {
            SetIgnoreCollision(value); ignoreCollision = value;
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (ignoreCollision)
        {
            SetIgnoreCollision(true);
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (ignoreCollision)
        {
            SetIgnoreCollision(false);
        }
    }

    private void Start()
    {
        childColliders = this.gameObject.GetComponentsInChildren<Collider>();
        player = GameObject.FindObjectOfType<XROrigin>();
    }

    private void SetIgnoreCollision(bool ignore)
    {
        foreach (var colldier in childColliders)
        {
            Physics.IgnoreCollision(colldier, player.gameObject.GetComponent<Collider>(), ignore);
        }
    }
}