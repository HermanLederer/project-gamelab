﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour
{
    public float radius;

    public Transform holdingPosition;

    public float HoldingTime = 4f;
    public float livingTime = 8f;
    public float holdedObjectSpeed = 5f;

    public LayerMask dragonLayer;

    private float timeHolding;
    private bool holding;
    private Animator holdingAnimator;
    private float lifeTime;

    private GameObject holdedObject;

    // Start is called before the first frame update
    void Awake()
    {
        holdingAnimator = holdingPosition.GetComponent<Animator>();
        lifeTime = livingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }
        else
        {
            if(holdedObject != null)
            {
                holdedObject.GetComponent<Rigidbody>().useGravity = true;
            }
            Destroy(gameObject);
        }

        if (holding)
        {
            holdedObject.transform.position = Vector3.MoveTowards(holdedObject.transform.position, holdingPosition.position, holdedObjectSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (dragonLayer == (dragonLayer.value | 1 << other.gameObject.layer))
        {
            SetHoldedObject(other.gameObject);
        }
    }

    private void SetHoldedObject(GameObject other)
    {
        holdedObject = other;

        GameItemBehaviour dragon = holdedObject.GetComponent<GameItemBehaviour>();

        dragon.BecomeBall();
        dragon.SetNextDragonTime(livingTime + 1);

        Rigidbody rb = other.GetComponent<Rigidbody>();

        if(rb != null)
        {
            rb.useGravity = false;
            holding = true;
        }
    }
}