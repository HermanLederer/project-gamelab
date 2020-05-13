﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ExploderSpellProjectile : MonoBehaviour, IPooledObject
{
	//
	// Other components
	#region Other components
	new private Rigidbody rigidbody = null;
	#endregion

	//
	// Editor variables
	#region Editor variables
	[SerializeField] private float speed = 5f;
	public AudioClip fireballExplode = null;
	public AudioClip fireballExplodeDrum = null;
	public AudioClip fireballExplodeVoc = null;
	public LayerMask explosionLayer = 0;
	#endregion

	//
	// Private variables
	#region Private variables
	private bool isDead = false;
	#endregion

	//--------------------------
	// MonoBehaviourPunCallbacks events
	//--------------------------
	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	public void OnObjectSpawn()
	{
		isDead = false;
		rigidbody.velocity = Vector3.zero;
		rigidbody.AddForce(transform.forward * speed, ForceMode.VelocityChange);
		gameObject.GetComponentsInChildren<Light>()[0].enabled = true;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (isDead) return;

		isDead = true;
		AudioManager.instance.PlayIn3D(fireballExplode, 1, transform.position, 5, 70);
		AudioManager.instance.PlayDrum(fireballExplodeDrum);
		AudioManager.instance.PlayTribeVoc(fireballExplodeVoc);

		Collider[] colliders = Physics.OverlapSphere(transform.position, 9, explosionLayer);
		foreach (Collider other in colliders)
		{
			Rigidbody rb;
			if (other.TryGetComponent<Rigidbody>(out rb))
			{
				if (other.gameObject.GetInstanceID() == GetInstanceID()) continue;
				rb.AddExplosionForce(700, transform.position, 5, 0, ForceMode.Impulse);
			}
		}

		// TODO: Spawn fx
		gameObject.SetActive(false);
	}
}
