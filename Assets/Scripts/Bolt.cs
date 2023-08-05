using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class Bolt : MonoBehaviour
{
    [SerializeField] private AudioClip _throw;
    [SerializeField] private AudioClip _fall;
    [SerializeField] private WaveView _wavePrefab;

    private AudioSource _audioSource;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void Throw(Vector3 direction, float force)
    {
        _rigidBody.AddForce(direction * force * 700);
        _audioSource.PlayOneShot(_throw);
    }

    public void OnCollisionEnter(Collision collision)
    {
        WaveView wave = Instantiate(_wavePrefab, transform.position, Quaternion.Euler(-90, 0, 0));

        float intense = collision.impulse.magnitude / 30;

        wave.Play(intense);
        _audioSource.PlayOneShot(_fall, intense);

        Destroy(gameObject, 2f);
        Destroy(wave.gameObject, 5f);
    }
}
