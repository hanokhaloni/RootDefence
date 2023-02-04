using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject seedPrefab;
    [SerializeField] private float seedInstantiationHeightOffset;
    [SerializeField] private float shootStrength    ;
    [SerializeField] private NavMeshSurface navMeshSurface;    
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shootStrength += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (shootStrength > 0.1f)
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    var pos = new Vector3(hit.point.x, hit.point.y + seedInstantiationHeightOffset, hit.point.z);

                    Seed seed = Instantiate(seedPrefab, pos, Quaternion.identity).GetComponent<Seed>();
                    seed.shoot(shootStrength);

                    shootStrength = 0;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        navMeshSurface.BuildNavMesh();
    }
}
