using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorModel;
    public GameObject colorObject;

    public float openSpeed;

   private bool shouldOpen;


    // Update is called once per frame
    void Update()
    {
        if (shouldOpen && doorModel.position.z != 1f)
        {
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 1f), openSpeed * Time.deltaTime);

            if (doorModel.position.z == 1f)
            {
                colorObject.SetActive(false);
            }
        }
        if (!shouldOpen && doorModel.position.z != 0f)
        {
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 0f), openSpeed * Time.deltaTime);

            if (doorModel.position.z == 0f)
            {
                colorObject.SetActive(true);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shouldOpen = true;
            colorObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shouldOpen = false;
            colorObject.SetActive(true);
        }
    }
}
