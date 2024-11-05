using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private float unitsPerMovement = 5f;
    [SerializeField]
    private float transitionSpeed = 20f;
    [SerializeField]
    private float transitionRotationSpeed = 350f;

    private Vector3 restorePosition = Vector3.zero;
    private Vector3 lastDirection = Vector3.zero;
    private bool positiveLastDirection = false;

    private Vector3 targetGridPosition;
    private Vector3 targetRotation;

<<<<<<< HEAD
    // public GameObject camera;
    // private bool cameraCanMove = true;
    
    public InputActionReference moveAction;
=======
    public GameObject camera;
    private bool cameraCanMove = true;
>>>>>>> 14ef7b77da0816b766a77a083d8c3eacd2c536da

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
<<<<<<< HEAD
            // cameraCanMove = false;
=======
            cameraCanMove = false;
>>>>>>> 14ef7b77da0816b766a77a083d8c3eacd2c536da
            // transitionSpeed *= 2;
            targetGridPosition = restorePosition;
        }
    }

    private void OnCollisionExit(Collision other)
    {
<<<<<<< HEAD
        // cameraCanMove = true;
        // transitionSpeed /= 2;
=======
        cameraCanMove = true;
        // transitionSpeed /= 2;
    }

    private void OnCollisionStay(Collision other)
    {
        // if (other.gameObject.tag == "Wall")
        // {          
        //     MovePlayer(lastDirection, !positiveLastDirection);
        // }
>>>>>>> 14ef7b77da0816b766a77a083d8c3eacd2c536da
    }
    
    

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        // targetGridPosition = Vector3Int.RoundToInt(transform.position);
        targetGridPosition = transform.position;
=======
        targetGridPosition = Vector3Int.RoundToInt(transform.position);
>>>>>>> 14ef7b77da0816b766a77a083d8c3eacd2c536da
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log($"Camera can move:{cameraCanMove}");
        //TODO: USE VARIABLES LIKE FORWARD,BACKWARD, RIGHT, LEFT AND CHANGE THEM AS WE ROTATE
        //TODO: CAMBIAR AL NEW INPUT SYSTEM
        if ( Input.GetKeyDown(KeyCode.A) )
        {
            RotateLeft();
        }
        if ( Input.GetKeyDown(KeyCode.D) )
        {
            RotateRight();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (IsAtRest())
            {
                lastDirection = transform.forward * unitsPerMovement;
                positiveLastDirection = true;    
            }
            MovePlayer(lastDirection, positiveLastDirection);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (IsAtRest())
            {
                lastDirection = transform.forward * unitsPerMovement;
                positiveLastDirection = false;
            }
            MovePlayer(lastDirection, positiveLastDirection);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (IsAtRest())
            {
                lastDirection = transform.right * unitsPerMovement;
                positiveLastDirection = false;
            }
            MovePlayer(lastDirection, positiveLastDirection);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsAtRest())
            {
                lastDirection = transform.right * unitsPerMovement;
                positiveLastDirection = true;
            }

            MovePlayer(lastDirection, positiveLastDirection);
        }
        
        
        
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    
    private void MovePlayer()
    {
        Vector3 targetPosition = targetGridPosition;

        if (targetRotation.y > 270f && targetRotation.y < 361f)
        {
            targetRotation.y = 0f;
        }
        if ( targetRotation.y < 0f)
        {
            targetRotation.y = 270f;
        }

        Debug.Log($"TARGET POSITION:{targetPosition}");

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * transitionRotationSpeed);
        // camera.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * transitionRotationSpeed);
        // if (cameraCanMove)
        // {
        //     camera.transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
        // }

    }


    public void RotateLeft()
    {
        if ( IsAtRest())
        {
            targetRotation -= Vector3.up * 90f;
        }
    }
    public void RotateRight()
    {
        if (IsAtRest())
        {
            targetRotation += Vector3.up * 90f;
        }
    }

    public void MovePlayer(Vector3 direction, bool positive)
    {
        if (IsAtRest())
        {
            restorePosition = transform.position;
            targetGridPosition = (positive) ? targetGridPosition + direction : targetGridPosition - direction;    

        }
    }


    private bool IsAtRest()
    {
        return (Vector3.Distance(transform.position, targetGridPosition) < 0.05f && Vector3.Distance(transform.eulerAngles, targetRotation) < 0.05f);
    }


}
