using UnityEngine;

public class WizardChest : MonoBehaviour
{
    [SerializeField] private GameObject _diamond;
    [SerializeField] private Boss _boss;
    [SerializeField] private AudioClip _open;
    [SerializeField] private AudioClip _diamondSpawn;

    private Animator _animator;
    private AudioSource _source => GetComponent<AudioSource>();


    private void Start()
    {
        _boss._bossDeathAction += ChestOpen;
        _animator = GetComponent<Animator>();
    }

    private void ChestOpen()
    {
        _animator.Play("Open");
        _source.PlayOneShot(_open);
    }

    private void DiamondSpawn() // Animation Call
    {
        _source.PlayOneShot(_diamondSpawn);
        Instantiate(_diamond,transform.position,Quaternion.identity);
    }

    private void OnDestroy()
    {
        _boss._bossDeathAction -= ChestOpen;
    }
}
