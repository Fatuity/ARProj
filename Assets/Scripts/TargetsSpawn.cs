﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TargetsSpawn : MonoBehaviour
{
    public Text text;

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject[] targets;

    private int previousTargetIndex = 0;
    private int currentTargetIndex = 0;

    private bool isFirst = true;

    public GameObject arCamera;

    Vector3 cameraPos;
    float x, y;
    
    void Start()
    {
        targets = new GameObject[3];
        targets[0] = target1;
        targets[1] = target2;
        targets[2] = target3;
    }

    public void targetRandomizer()
    {
        if(!isFirst)
        {
            previousTargetIndex = currentTargetIndex;
            targets[previousTargetIndex].SetActive(false);
        }
        currentTargetIndex = Random.Range(0, 3);
        targets[currentTargetIndex].SetActive(true);
    }
    
    public void locateTarget()
    {
        targetRandomizer();
        cameraPos = arCamera.transform.position;
        x = Random.Range(cameraPos.x - 0.5f, cameraPos.x + 0.5f);
        y = Random.Range(cameraPos.y - 0.5f, cameraPos.y + 0.5f);
        targets[currentTargetIndex].transform.position = new Vector3(x, y, cameraPos.z + 2.5f);
    }

    public void initializeTarget()
    {
        locateTarget();
        //currentTarget.SetActive(true);
        text.text = targets[currentTargetIndex].transform.position.ToString();
        isFirst = false;
    }
}