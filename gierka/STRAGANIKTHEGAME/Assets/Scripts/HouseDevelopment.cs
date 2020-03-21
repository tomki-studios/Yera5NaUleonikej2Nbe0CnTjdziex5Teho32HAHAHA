﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDevelopment : MonoBehaviour
{
    public int HouseLevel;
    public GameObject AdditionalBuilding;
    private bool BuildingCreated;
    public Transform HouseParent;
    public Rigidbody HouseRG;
    public bool OpenDevelopmentPanel;
    public PlayerMovement Player;
    public GameObject HDpanel;
    public bool canOpen;
    void Start()
    {
        HouseLevel = 1;
        BuildingCreated = false;
        OpenDevelopmentPanel = false;
        canOpen = false;
        HDpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (HouseLevel)
        {
            case 1:
                break;

            case 2:
                if (!BuildingCreated)
                {
                    CreateAdditionalBuilding(AdditionalBuilding, HouseRG.position.x + 4f, HouseRG.position.y, HouseRG.position.z, HouseParent);
                }
                break;
        }

        if (Input.GetKeyDown(KeyCode.Q) && canOpen)
        {
            Debug.Log("Q pressed");
            if(HDpanel.activeInHierarchy == true)
            {
                HDpanel.SetActive(false);
                Player.enabled = true;
            }
            else
            {
                HDpanel.SetActive(true);
                Player.enabled = false;
            }
        }
    }

    private void CreateAdditionalBuilding(GameObject Building, float PosX, float PosY, float PosZ, Transform Parent)
    {
        Instantiate(Building, new Vector3(PosX, PosY, PosZ) ,Quaternion.identity, Parent);
        BuildingCreated = true;
    }

    public void LevelUp()
    {
        HouseLevel += 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player"){
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            canOpen = false;
        }
    }
}
