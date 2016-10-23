using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float maxSpeed =3f;
	public float speed = 50f;
	private Rigidbody2D rigidBody;
	private Animator animator;
	public float jumpPower = 1000f;
	public bool grounded;
	public bool canDoubleJump;

	public int currentHealth;
	public int maxHealth = 100;

	// Use this for initialization
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		animator = gameObject.GetComponent<Animator> ();
		currentHealth = maxHealth;
	}

	// Update is called once per frame
	void Update () {

		animator.SetBool ("Grounded", grounded);
		animator.SetFloat ("Speed", Mathf.Abs (rigidBody.velocity.x));
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale = new Vector3 (-0.2000587f, 0.2068035f, 1);
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale = new Vector3 (0.2000587f, 0.2068035f, 1);
		}

		if (Input.GetButtonDown ("Jump")) {
			if (grounded) {
				rigidBody.AddForce (Vector2.up * jumpPower);
				canDoubleJump = true;
			} else {
				if (canDoubleJump) {
					canDoubleJump = false;
					rigidBody.velocity = new Vector2 (rigidBody.velocity.x, 0);
					rigidBody.AddForce (Vector2.up * jumpPower);
				}
			}
		}

		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
		if (currentHealth <= 0) {
			Die ();
		}
	}

	void FixedUpdate(){

		Vector3 easyVelocity = rigidBody.velocity;
		easyVelocity.y = rigidBody.velocity.y;
		easyVelocity.z = 0.0f;
		easyVelocity.x *= 0.75f;
		float a = Input.GetAxis ("Horizontal");

		if (grounded) 
		{
			rigidBody.velocity = easyVelocity;		
		}
		rigidBody.AddForce ((Vector2.right * speed) * a);

		if (rigidBody.velocity.x > maxSpeed) 
		{
			rigidBody.velocity = new Vector2 (maxSpeed, rigidBody.velocity.y);
		}
		if (rigidBody.velocity.x < -maxSpeed) 
		{
			rigidBody.velocity = new Vector2 (-maxSpeed, rigidBody.velocity.y);
		}
	}

	void Die()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}


