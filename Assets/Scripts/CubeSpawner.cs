﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private MoveCube cubePrefab;
    [SerializeField]
    private MoveDirection moveDirection;
    private Color _actualColor;
    private int _countColor;
    private float _colorCoefficient = 0.01f;

    public void SpawnCube()
    {   
        var cube = Instantiate(cubePrefab) ;
        if (MoveCube.LastCube != null && MoveCube.LastCube.gameObject != GameObject.Find("Start"))
        {            
            float x = moveDirection == MoveDirection.x ? transform.position.x : MoveCube.LastCube.transform.position.x;
            float z = moveDirection == MoveDirection.z ? transform.position.z : MoveCube.LastCube.transform.position.z;

            cube.transform.position = new Vector3(x,
                MoveCube.LastCube.transform.position.y + cubePrefab.transform.localScale.y,
                z);
        }
        else
        {
            cube.transform.position = transform.position;
        }

        cube.MoveDirection = moveDirection;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, cubePrefab.transform.localScale);
    }
   
}
