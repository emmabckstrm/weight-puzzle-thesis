﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjectsDiscriminationPair : CreateObjects {

    GameObject weight;
    public GameObject prefab;
    float[] weights;
    int j;

    // Use this for initialization
    void Start () {
        weights = GlobalControl.Instance.GetWeightsPair();
        j = GlobalControl.Instance.GetDiscriminationsPerformed() * 2;
        prefab = GlobalControl.Instance.GetWeightPrefab();
    }
    private void OnEnable()
    {
        weights = GlobalControl.Instance.GetWeightsPair();
        j = GlobalControl.Instance.GetDiscriminationsPerformed() * 2;
        prefab = GlobalControl.Instance.GetWeightPrefab();
    }

    // Update is called once per frame
    void Update () {
		
	}

    // creates objects for weight discrimination in pairs
    public override void Create()
    {
        Debug.Log("create function pair");
        if (j >= weights.Length)
        {
            j = 0;
        }
        for (int i = 0; i < 2; i++)
        {
            Vector3 localPos = new Vector3(0, 0, i * 0.45f);
            Transform parent = GameObject.Find("Weight placement").transform;
            weight = Instantiate(prefab, parent.position, Quaternion.identity, parent);
            weight.transform.localPosition = localPos;
            weight.transform.rotation = Quaternion.Euler(0, 0f, 0);
            weight.GetComponent<Rigidbody>().mass = weights[j];
            weight.GetComponent<VRTK.InteractableObjectTrackMovement>().UpdateMovementLimitValue();
            j++;
        }
    }
}