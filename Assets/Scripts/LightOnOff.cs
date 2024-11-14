using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class LightOnOff : MonoBehaviour
{
    [SerializeField] private GameObject textToDisplay;
    private bool playerInZone;

    // Change from a single GameObject to an array of GameObjects for multiple lights
    [SerializeField] private GameObject[] lightObjects;

    private void Start()
    {
        playerInZone = false;
        textToDisplay.SetActive(false);
    }

    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.F))
        {
            ToggleLights(); // Toggle all lights in the array
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().Play("Switch");
        }
    }

    private void ToggleLights()
    {
        foreach (GameObject lightObject in lightObjects)
        {
            if (lightObject != null)
            {
                lightObject.SetActive(!lightObject.activeSelf);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textToDisplay.SetActive(true);
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            textToDisplay.SetActive(false);
        }
    }
}

