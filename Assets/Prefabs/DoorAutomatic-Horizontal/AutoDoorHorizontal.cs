using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoorHorizontal : MonoBehaviour
{
    [Header("Door")]
    public GameObject door1;
    public GameObject door2;
    public float speed = 5f;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip openSound;
    public AudioClip closeSound;

    //private fields
    public bool openSaysMe;
    public float openPos1;
    public float closedPos1;
    private float openPos2;
    private float closedPos2;
    private bool playOpenOnce = false;
    private bool playCloseOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.Stop();
        closedPos1 = door1.transform.localPosition.z;
        openPos1 = closedPos1 - 1.30f;
        closedPos2 = door2.transform.localPosition.z;
        openPos2 = closedPos2 + 1.30f;
    }

    // Update is called once per frame
    void Update()
    {
        if (openSaysMe)
        {
            if (!playOpenOnce)
            {
                playOpenOnce = true;
                playCloseOnce = false;

                audioSource.Stop();
                audioSource.clip = openSound;
                audioSource.Play();
            }
            if (door1.transform.localPosition.z >= openPos1) // stops door
            {
                door1.transform.localPosition += new Vector3(0f, 0f, -(speed * Time.deltaTime)); // moves door
            }
            if (door2.transform.localPosition.z <= openPos2)
            {
                door2.transform.localPosition += new Vector3(0f, 0f, (speed * Time.deltaTime));
            }
        }
        else
        {
            if (!playCloseOnce)
            {
                playCloseOnce = true;
                playOpenOnce = false;

                audioSource.Stop();
                audioSource.clip = closeSound;
                audioSource.Play();
            }
            if (door1.transform.localPosition.z <= closedPos1) // stops door
            {
                door1.transform.localPosition += new Vector3(0f, 0f, (speed * Time.deltaTime)); // moves door
            }
            if (door2.transform.localPosition.z >= closedPos2)
            {
                door2.transform.localPosition += new Vector3(0f, 0f, -(speed * Time.deltaTime));
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        openSaysMe = true;
    }
    private void OnTriggerStay(Collider other)
    {
        openSaysMe = true;
    }
    private void OnTriggerExit(Collider other)
    {
        openSaysMe = false;
    }
}
