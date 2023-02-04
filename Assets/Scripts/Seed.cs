using UnityEngine;

public class Seed : MonoBehaviour
{
    Rigidbody m_Rigidbody;
  [SerializeField] private Animator _animator;
  [SerializeField] private Rigidbody rigidbody;
  [SerializeField] private float shootStrengthModifier;
  private bool growSoundPlayed;
  
  private void OnTriggerEnter(Collider other)
  {
      if (other.CompareTag("Floor"))
      {
          if (!growSoundPlayed)
          {
              SoundManager.Instance.Play("HitGround");
              growSoundPlayed = true;
          }
          _animator.SetTrigger("Breath");
          rigidbody.isKinematic = true; 

      }
      else
      {
          Destroy(this);
      }
  }
  
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void shoot(float strength) {
        m_Rigidbody.velocity = Vector3.right * strength * shootStrengthModifier;
    }

}
