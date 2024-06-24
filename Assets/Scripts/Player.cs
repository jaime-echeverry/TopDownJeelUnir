using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float inputH;
    private float inputV;
    private bool isMoving;
    private Vector3 destinyPoint;
    private Vector3 interactionPoint;
    private Vector3 lastInput;
    private Collider2D colliderAhead;
    private Animator anim;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float interactionRadius;

    private  bool interacting;

    public bool Interacting { get => interacting; set => interacting = value; }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadingInputs();

        //Moves only if player is in a block and only if there is input
        MovementAndAnimations();
    }

    private void MovementAndAnimations()
    {
        if (!interacting && !isMoving && (inputH != 0 || inputV != 0))
        {
            anim.SetBool("Walking", true);
            anim.SetFloat("InputH", inputH);
            anim.SetFloat("InputV", inputV);

            lastInput = new Vector3(inputH, inputV, 0);
            destinyPoint = transform.position + lastInput;
            interactionPoint = destinyPoint;

            colliderAhead = LaunchCheck();
           
            bool isDoor = (colliderAhead != null && colliderAhead.CompareTag("Door")) ? true : false;
            Debug.Log(isDoor);
            if (colliderAhead == false || isDoor)
            {
                StartCoroutine(Move());
            }
        }
        else if (inputH == 0 && inputV == 0)
        {
            anim.SetBool("Walking", false);
        }
    }

    private void ReadingInputs()
    {
        if (inputV == 0)
        {
            inputH = Input.GetAxisRaw("Horizontal");

        }
        if (inputH == 0)
        {
            inputV = Input.GetAxisRaw("Vertical");

        }
        if (Input.GetKeyDown(KeyCode.E)) {
            LauchInteraction();
        }
    }

    private void LauchInteraction() {
        colliderAhead = LaunchCheck();
        if (colliderAhead != null) {
            if (colliderAhead.TryGetComponent(out Interactuable interactuable)) { 
               interactuable.Interact();
            }
        }
    }

    IEnumerator Move() {
        isMoving = true;
        while (transform.position != destinyPoint)
        {
            transform.position =  Vector3.MoveTowards(transform.position, destinyPoint, movementSpeed * Time.deltaTime);
            yield return null;
        }
        interactionPoint = transform.position + lastInput;
        isMoving = false;   
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(interactionPoint, interactionRadius);
    }

    public Collider2D  LaunchCheck() {
        return Physics2D.OverlapCircle(interactionPoint, interactionRadius);
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }

}
