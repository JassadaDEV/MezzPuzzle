using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_CTRL : MonoBehaviour
{
    public float speed = 4.0f;
    public float rotSpeed = 80f;
    public float rot = 0f;
    public float gravity = 8.0f;

    public float mouseSensitive = 100.0f;
    public Transform playerBody;
    float xRotation = 0f;
    Vector3 moveDir = Vector3.zero;

    public Inventory inventory;
    public Text goal;
    public Text lose;

    public int HP = 3;
    public GameObject[] HP_Player;

    CharacterController controller;
    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        {
            Camera.main.transform.LookAt(this.transform.position);
            Camera.main.transform.position = this.transform.position - this.transform.forward * 5f + this.transform.up * 3f;
            Camera.main.transform.parent = this.transform;
        }

        //Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("condition", 1);
            moveDir = new Vector3(0, 0, 1);
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDir = new Vector3(0, 0, -1);
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
            anim.SetInteger("condition", 2);
        }
        else
        {
            anim.SetInteger("condition", 0);
            moveDir = Vector3.zero;
        }

        rot = Input.GetAxis("Mouse X") * mouseSensitive * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, -180f, 180f);

        playerBody.Rotate(Vector3.up * rot);

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);

        // USE ITEM

        if (Input.GetKeyDown(KeyCode.E)&& HP <= 2)
        {
            IInventoryItem item = inventory.ItemTop();
            if (item != null)
            {
                print("Using:" + item);
                inventory.UseItem(item);
                inventory.RemoveItem(item);
            }
        }

            if (HP == 2)
            {
                HP_Player[0].SetActive(false);
            }
            if (HP == 1)
            {
                HP_Player[1].SetActive(false);
            }
            if (HP == 0)
            {
                HP_Player[2].SetActive(false);
                anim.SetInteger("condition", 4);

                lose.text = "You Dead";

                this.GetComponent<Player_CTRL>().enabled = false;
            }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            HP -= 1;
        }
        else if(other.gameObject.tag == "Goal")
        {
            goal.text = "Victory";
            this.GetComponent<Player_CTRL>().enabled = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if(item != null)
        {
            inventory.AddItem(item);
            item.OnPickup();
        }
    }
}
