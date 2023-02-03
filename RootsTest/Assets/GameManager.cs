using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject seedPrefab;
    [SerializeField] private float seedInstantiationHeightOffset;


    private void Start()
    {
        Enemy[] en = GetComponents<Enemy>();
        foreach (var e in en)
        {
            e.SetAgentTarget(transform);
        }
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.name);
                Debug.Log("hit");
                var pos = new Vector3(hit.point.x, hit.point.y + seedInstantiationHeightOffset, hit.point.z);
                Instantiate(seedPrefab, pos, Quaternion.identity);
            }
        }
    
    }
}
