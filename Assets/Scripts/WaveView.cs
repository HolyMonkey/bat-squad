using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class WaveView : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    public float Intense { get; private set; }

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void Play(float intense)
    {
        Intense = intense;

        var settings = _particleSystem.main;

        settings.startColor = new Color(1, 1, 1, intense);

        _particleSystem.Play();
    }
}
