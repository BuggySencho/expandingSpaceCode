using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomkommerMovement : MonoBehaviour {


	// deze ken je wel, met de GroundDetection

		public float speed = 5f;
		public bool MovingRight = true;
		public Transform GroundDetction;
		public float Distance;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D GroundInfo = Physics2D.Raycast(GroundDetction.position, Vector2.down, Distance);
        if (GroundInfo.collider == false)
        {
            if (MovingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                MovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                MovingRight = true;
            }
		}
	}
}
