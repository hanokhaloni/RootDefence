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


    AudioSource audioSource;
    [SerializeField] private AudioClip throwAudio;
    [SerializeField] private AudioClip seedHitGroundAudio;

    

    private void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
    }

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
                ThrowSound();
                
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    var pos = new Vector3(hit.point.x, hit.point.y + seedInstantiationHeightOffset, hit.point.z);

                    Seed seed = Instantiate(seedPrefab, pos, Quaternion.identity).GetComponent<Seed>();
                    seed.shoot(shootStrength);
                    navMeshSurface.BuildNavMesh();

                    SeedHitGroundSound();

                    shootStrength = 0;
                }
            }
        }
    }

    private void ThrowSound()
    {
        
        audioSource.PlayOneShot(throwAudio);
    }

    private void SeedHitGroundSound()
    {
        audioSource.PlayOneShot(seedHitGroundAudio);
    }
}
