using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float MaxSpeed;

    private int desiredLane = 1;
    public float laneDistance = 4;

    public int level = 0;
    public int level1 = 0;
    public GameObject lvl1;
    public GameObject lvl2;
    public GameObject lvl3;

    public GameObject CompletedPanel;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerManager.isGameStarted)
            return;
        //increase speed
        if(forwardSpeed < MaxSpeed)
            forwardSpeed += 0.1f * Time.deltaTime;
        direction.z= forwardSpeed;

        if(SwipeManager.swipeRight)
        {
            desiredLane++;
            if(desiredLane ==3)
                desiredLane =2;
        }
        if(SwipeManager.swipeLeft)
        {
            desiredLane--;
            if(desiredLane ==-1)
                desiredLane =0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if (desiredLane ==2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        //transform.position = targetPosition;
        if(transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if(moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else 
            controller.Move(diff);


    }
    private void FixedUpdate()
    {
        if(!PlayerManager.isGameStarted)
            return;
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "obstacle")
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lvl1")
        {
            level = 1;
            lvl1.SetActive(false);
            lvl2.SetActive(true);
        }else if(other.gameObject.tag == "lvl2")
        {
            level1 = 1;
            lvl2.SetActive(false);
            lvl3.SetActive(true);
        }
        else if(other.gameObject.tag =="lvl3")
        {
            level1 = 1;
            lvl2.SetActive(false);
            lvl3.SetActive(false);
            CompletedPanel.SetActive(true);
            gameObject.SetActive(false);
        }
       

    }


}
