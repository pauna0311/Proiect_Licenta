using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class DoorController : MonoBehaviour

{

    public GameObject door; // Reference to the door (drag the door object here in the inspector)

    public float openRot = 115; // angle when door is open

    public float closeRot = 0; // angle when door is closed

    public float speed = 2; // speed of opening/closing door

    public bool opening; // true or false if open



    public Transform player; // Reference to the player (drag the player object here in the Inspector)

    public float activationDistance = 3f; // Distance threshold for interaction





    // Update is called once per frame

    void Update()

    {

        // Calculate distance between player and door

        float distance = Vector3.Distance(player.position, transform.position);

        

        Vector3 currentRot = door.transform.localEulerAngles;

        if (opening)

        {

            if (currentRot.y < openRot)

            {

                door.transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, openRot, currentRot.z), speed * Time.deltaTime);

            }

        }

        else

        {

            if (currentRot.y > closeRot)

            {

                door.transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, closeRot, currentRot.z), speed * Time.deltaTime);

            }

        }



        // Check if player is close enough and presses the 'F' key

        if (distance <= activationDistance && Input.GetKeyDown(KeyCode.F))

        {

            ToggleDoor();

        }





    }



    public void ToggleDoor()

    {

        opening = !opening;

    }

}
