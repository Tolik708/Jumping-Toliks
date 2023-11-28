using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("General")]
	public Camera cam;
	
	[Header("Input")]
    public float tiltSensetivity;
	
	[Header("Movement")]
	public float maxHeight; // World y position after that player won't be moving up and platforms will move down
	public float jumpHeight;
	
	#if UNITY_EDITOR
	[Header("Debug")]
	public float moveSpeed;
	#endif
	
	private GameState state = null;
	private Rigidbody2D rb = null;
	private float playerHalfWidth = 0;
	
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		playerHalfWidth = (float)sr.sprite.bounds.size.x / 2.0f * transform.lossyScale.x;
	}
	
    private void Update()
    {
		Movement();
		BorderTeleportationCheck();
		OtherUpdate();
    }
	
	private void OnCollisionEnter2D(Collision2D col)
	{
		rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
	}
	
	private void BorderTeleportationCheck()
	{
		float rightBorderDifference = rb.position.x - playerHalfWidth - cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
		if(rightBorderDifference > 0)
		{
			rb.position = new Vector2(cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x - playerHalfWidth + rightBorderDifference, rb.position.y);
			return;
		}
		
		float leftBorderDifference = rb.position.x + playerHalfWidth - cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
		if(leftBorderDifference < 0)
			rb.position = new Vector2(cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + playerHalfWidth + leftBorderDifference, rb.position.y);
	}
	
	private void Movement()
	{
		rb.velocity = new Vector2(Input.acceleration.x * tiltSensetivity, rb.velocity.y);
		#if UNITY_EDITOR
		rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);
		#endif
	}
	
	private void OtherUpdate()
	{
		gameObject.layer = rb.velocity.y > 0 ? 6 : 7;
	}
	
	// I make it here because I'd like to have all the movement in one file
	public void SetPlayersYPosition(float newYPosition) { transform.position = new Vector2(rb.position.x, newYPosition); }
	public float GetPlayerYVelocity() { return rb.velocity.y; }
	public void SetGameState(GameState newState) { state = newState; }
}
