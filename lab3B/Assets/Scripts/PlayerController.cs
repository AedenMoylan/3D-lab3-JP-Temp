using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

[System.Serializable]
public class Boundary 
{
	// used for boundary detection
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	private float movementX;
	private float movementY;
	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject powerUP;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;
	public int HP;
	int count = 0;
	public Renderer rend;
	bool isPlayerVisible;
	public bool isLifeLost;
	int timerCount;
	public int playerLives;
	public bool isPlayerPoweredUp;

	void Start()
    {
		isPlayerPoweredUp = false;
		timerCount = 0;
		isPlayerVisible = true;
		isLifeLost = false;
		rb = GetComponent<Rigidbody>();
		rend = GetComponent<Renderer>();

		rend.enabled = isPlayerVisible;
	}
	
	void Update()
	{
		if (isLifeLost == true)
		{
			flashPlayer();
		}
		// temporary. used to powerup player when space is pressed
		if (Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			isPlayerPoweredUp = true;
		}
	}

	// sets rotation, velocity, and stops player from going out of bounds
	void FixedUpdate()
	{
		Vector3 movement = new Vector3(movementX, 0.0f, 0.0f);// movementY);
		rb.velocity = movement * speed;
		rb.position = new Vector3(
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax));
		rb.rotation = Quaternion.Euler(0.0f, .0f, rb.velocity.x * -tilt);
	}

	void OnMove(InputValue movementValue)
	{
		Vector2 movementVector = movementValue.Get<Vector2>();

		movementX = movementVector.x;

		
	}
    
	// instanciates and fires the bullet. If player has a powerup, player shoots 2 bullets at the same to make a stronger bullet
    void OnFire(InputValue movementValue)
    {
		nextFire = Time.time + fireRate;
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		GetComponent<AudioSource>().Play();
		if(isPlayerPoweredUp == true)
        {
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play();
		}
	}

	public void reduceHP()
    {
		HP--;
    }

	public int getHP()
    {
		return HP;
    }

	public void returnHPToBase()
    {
		HP = 2;
    }
	// renders the player on and off to simulate flashing. also sets isLifeLost to false at the ens which ends invincibility
	public void flashPlayer()
    {
		count++;
		timerCount++;

		if (count >= 25 && isPlayerVisible == true)
		{
			isPlayerVisible = false;
			rend.enabled = isPlayerVisible;
			count = 0;
		}
		if (count >= 25 && isPlayerVisible == false)
		{
			isPlayerVisible = true;
			rend.enabled = isPlayerVisible;
			count = 0;
		}
		if (timerCount >= 400)
        {
			isLifeLost = false;
			timerCount = 0;
        }
	}

	public int getLives()
    {
		return playerLives;
    }
}
