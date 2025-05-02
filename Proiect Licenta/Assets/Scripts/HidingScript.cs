using UnityEngine;


public class HidingInteract : MonoBehaviour
{
    public enum HidingStyle { Interact, Trigger }
    public HidingStyle hidingStyle = HidingStyle.Interact;

    public Camera virtualCamera;
    public Animator animator;
    public Transform hidingPosition;
    public Transform unhidePosition;
    public GameObject player; // Reference to player GameObject
    public float interactDistance = 2f; // How close player needs to be to interact

    private bool isHiding = false;
    private bool playerInRange = false; // For Trigger style

    private void Update()
    {
        if (hidingStyle == HidingStyle.Interact)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                if (playerInRange || isHiding)
                {
                    ToggleHiding();
                }
            }
        }
    }

    private void ToggleHiding()
    {
        isHiding = !isHiding;

        animator.SetBool("IsHiding", isHiding);

        if (isHiding)
        {
            player.transform.position = hidingPosition.position;
            virtualCamera.gameObject.SetActive(true); // Turn on the hiding camera
        }
        else
        {
            player.transform.position = unhidePosition.position;
            virtualCamera.gameObject.SetActive(false); // Turn off hiding camera
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hidingStyle == HidingStyle.Trigger && other.CompareTag("Player"))
        {
            playerInRange = true;
            ToggleHiding();
        }
        else if (hidingStyle == HidingStyle.Interact && other.CompareTag("Player"))
        {
            playerInRange = true; // Only set true, don't toggle yet
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (unhidePosition != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(unhidePosition.position, 0.2f);
        }
    }
}
