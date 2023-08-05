using UnityEngine;

public class SightView : MonoBehaviour
{
    [SerializeField] private LineRenderer _sightRenderer;

    public void Render(Vector3 direction, float force)
    {
        _sightRenderer.SetPositions(new Vector3[]
        {
            Vector3.zero + new Vector3(0, 2, 0),
            direction * force + new Vector3(0, 2, 0)
        });
    }
}
