using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public bool canControl = true;

	public float speed = 2f;
	public float maxVelocityChange = 8f;
	public float jumpHeight = 10f;
	public float gravity = 10f;

	public LayerMask groundmask;
	internal Rigidbody rb;
	private bool grounded = false;
	public float speedMultiplier = 1f;
	internal bool canmoveH = true;
	private bool flipped = false;
	private Animator anim;
	public bool haxisisinuse = false;

	void Awake() {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;
	}

	void Update () {

		sGrounded ();
		Vector3 targetVelocity = new Vector3 (Input.GetAxis ("Horizontal")* speed, 0, 0);

		//applying velocity
		if (canControl){
			Vector3 velocity = rb.velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp (velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0f;
			velocityChange.z = 0f;
			if (targetVelocity != Vector3.zero && canmoveH) {
				//RaycastHit hit;
				//Debug.DrawRay (transform.position, targetVelocity.normalized);
				//if (Physics.SphereCast (transform.position, 1.5f, targetVelocity.normalized, out hit, Mathf.Infinity, ~groundmask)) {
				//	Debug.Log (hit.distance);
				//	if (hit.distance > 1)
						rb.AddForce (velocityChange, ForceMode.VelocityChange);
				//}

				if (targetVelocity.x < 0 && !flipped) {
					transform.localScale = new Vector3 (-1,1,1);
					flipped = true;
				} else if (targetVelocity.x > 0 && flipped) {
					transform.localScale = new Vector3 (1,1,1);
					flipped = false;
				}
			}
		}


		anim.SetFloat("hSpeed", Mathf.Abs(rb.velocity.x));
	}

	void FixedUpdate(){
		if (Input.GetButtonDown ("Jump") && grounded && rb.velocity.y < 0.1f) {
			rb.AddForce (Vector3.up * jumpHeight);
			grounded = false;

			anim.SetBool ("Grounded", false);
		}		


		if (Input.GetAxisRaw ("Vertical") < 0) {
			if (haxisisinuse != true)
				haxisisinuse = true;
		}
		if (Input.GetAxisRaw ("Vertical") == 0) {
			if (haxisisinuse == true)
				haxisisinuse = false;
		}

		//apply gravity
		rb.AddForce(new Vector3(0f, -gravity * rb.mass, 0));
	}

	void sGrounded(){
		RaycastHit hit;
		Debug.DrawRay (transform.position + (Vector3.down * 1.5f), Vector3.down);

		if (Physics.Raycast (transform.position + (Vector3.down * 1.5f), Vector3.down, out hit, Mathf.Infinity, ~groundmask)) {
			if (!grounded && hit.distance < 0.4f && Mathf.Abs(rb.velocity.y) < 0.1f ) {
				speedMultiplier = 1f;
				grounded = true;
				anim.SetBool ("Grounded", true);
			}

			if (hit.transform.GetComponent<JumpthroughPlatform> ()) {
				if (Input.GetKeyDown(KeyCode.S) && grounded) {
					hit.transform.GetComponent<JumpthroughPlatform> ().DisablePlat();
				}
			}
		}
	}
}
