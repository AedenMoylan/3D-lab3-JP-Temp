using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	int randFire;

	void Start ()
	{
		randFire = Random.Range(1, 5);
		InvokeRepeating ("Fire", delay, randFire);
	}

	void Fire ()
	{		
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		GetComponent<AudioSource>().Play();
	}

}
