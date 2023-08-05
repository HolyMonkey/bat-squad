using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class HighlithingByWave : MonoBehaviour
{
    [SerializeField] private float _baseHighlighting = 0f;

    private Color _baseColor;
    private Material _material;

    private float _highlighting = 0;
    private float _fadeRate = 1f;
    private float _highlightByCollision = 0.1f;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
        _baseColor = _material.color;
    }

    private void Update()
    {
        UpdateHighlighting();

        _highlighting -= Time.deltaTime * _fadeRate;
        _highlighting = Mathf.Clamp(_highlighting, _baseHighlighting, 1);
    }

    private void UpdateHighlighting()
    {
        _material.color = Color.Lerp(Color.black, _baseColor, _highlighting);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.TryGetComponent(out WaveView wave))
        {
            _highlighting += _highlightByCollision * wave.Intense;
            _highlighting = Mathf.Clamp(_highlighting, _baseHighlighting, 1);
        }
    }
}
