using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
   private Rigidbody rb;
    public bool isFlat = true;
    public Transform y1;
    public Transform y2;

    public float speed;
    public float StartHealth=100f;
    public float DashSpeed = 30f;
    public float DashTime;
    public float StartDashTime = 0.3f;
    public bool Dashing;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        DashTime = StartDashTime;
    }
    

    private void Update()
    {
        Debug.Log("x velocity=" + rb.velocity.x);
        Debug.Log("z velocity=" + rb.velocity.z);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dashing = true;
            DashTime = StartDashTime;

        }

        if(Dashing)
        {
            if (DashTime > 0)
            {
                speed = 20f;
                DashTime -= Time.deltaTime;
            }
            else 
            {
                speed = 10f;
                Dashing = false;
                
            }
        }

        
       
    }

    private void FixedUpdate()
    {
        //Move();
       MovePc();
        
      
    }


    private void Move()
    {
        float phonex= Input.acceleration.x;
        float phoney = Input.acceleration.y;


       
        Vector3 direction = new Vector3(-phonex, 0, -phoney);

        rb.transform.Translate(-direction * Time.deltaTime * speed);
        
    }

    private void MovePc()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(-h, 0, -v);

        rb.transform.Translate(-direction * Time.deltaTime * speed);

        //  rb.transform.rotation = Quaternion.Euler(v * 10, transform.rotation.y, -h * 10);
        rb.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(v * 10, transform.rotation.y, -h * 10), 0.5f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
    }

  void Dash()
    {
           
        }
    }








