using UnityEngine;

public class Boss3Death : MonoBehaviour
{
    [SerializeField] private ParticleSystem _death;
    [SerializeField] private GameObject _diamond;

 

    private void Death()
    {
        
        _death.Play();
        _death.transform.SetParent(null);
        Instantiate(_diamond, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
