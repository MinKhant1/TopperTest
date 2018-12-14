using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLocal : MonoBehaviour {

	public Transform goal;
 public	float speed = 0.5f;
	float accuracy = 1.0f;
    private bool Detected = false;
    private Animator anim;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 lookAtGoal = new Vector3(goal.position.x, 
										this.transform.position.y, 
										goal.position.z);
		this.transform.LookAt(2*transform.position-lookAtGoal);
	//	if(Vector3.Distance(transform.position,lookAtGoal) > accuracy)

        if(Detected)
            this.transform.Translate(0, 0, speed * Time.deltaTime);

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Detected = true;
           
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.enabled = false;
            this.enabled = false;

        }
    }
}
