using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float seedInstantiationHeightOffset;
    [SerializeField] private float shootStrength    ;
    [SerializeField] private NavMeshSurface navMeshSurface;    
//    [SerializeField] private AudioClip throwAudio;
    [SerializeField] private GameObject [] seedPrefab;
    [SerializeField] private int [] SeedsStartingAmount;
    [SerializeField] private Text [] SeedsStartingAmountTexts;
 //   AudioSource audioSource;
    [SerializeField] private AudioClip seedHitGroundAudio;
    private int currentSeedIndex;
    private int [] ActualSeedsAmount;

    private void Start()
    {
        ActualSeedsAmount = SeedsStartingAmount;
        SetUpButtonCount();
        StartCoroutine(nameof(PlaySounds));
        //    audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shootStrength += Time.deltaTime;
        }

        var eventSystem = EventSystem.current;
        if (eventSystem.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonUp(0))
        {
            if (ActualSeedsAmount [currentSeedIndex] > 0)
            {
                if (shootStrength > 0.1f)
                {
                    Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 100))
                    {
                        if (Physics.Raycast(ray, out hit, 100))
                        {
                            var pos = new Vector3(hit.point.x, hit.point.y + seedInstantiationHeightOffset, hit.point.z);

                            Seed seed = Instantiate(seedPrefab[currentSeedIndex], pos, Quaternion.identity).GetComponent<Seed>();
                            seed.shoot(shootStrength);
                            navMeshSurface.BuildNavMesh();
                            shootStrength = 0;
                        }

                        ActualSeedsAmount[currentSeedIndex]--;
                        UpdateButtonCount();
                        shootStrength = 0;
                    }
                
                }
            }
        }
        
    }

    private void UpdateButtonCount()
    {
        SeedsStartingAmountTexts[currentSeedIndex].text = ActualSeedsAmount[currentSeedIndex].ToString();
    }
    
    private void SetUpButtonCount()
    {
        for (int i = 0; i < SeedsStartingAmountTexts.Length; i++)
        {
            SeedsStartingAmountTexts[i].text = SeedsStartingAmount[i].ToString();
        }
    }

    public void SwitchSeedByIndex(int index)
    {
        currentSeedIndex = index;
    }
    
    private IEnumerator PlaySounds()
    {
        SoundManager.Instance.Play("Head");
        yield return new WaitForSeconds(SoundManager.Instance.GetClip("Head").length);
        SoundManager.Instance.Play("Body");

    }
  
}
