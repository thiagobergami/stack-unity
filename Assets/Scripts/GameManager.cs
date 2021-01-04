using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnCubeSpawnerd = delegate { };

    private CubeSpawner[] spawners;
    private int spawnersIndex;
    private CubeSpawner currentSpawner;
    private MoveCube cube;
    Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
        spawners = FindObjectsOfType<CubeSpawner>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            if(MoveCube.CurrentCube != null)
                MoveCube.CurrentCube.Stop();


            spawnersIndex = spawnersIndex == 0 ? 1 : 0;
            currentSpawner = spawners[spawnersIndex];

            currentSpawner.SpawnCube();
            OnCubeSpawnerd();
            _mainCamera.transform.position = new Vector3(_mainCamera.transform.position.x, _mainCamera.transform.position.y + MoveCube.CurrentCube.transform.localScale.y, _mainCamera.transform.position.z);
        }
    }
}
