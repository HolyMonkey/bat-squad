using UnityEngine;

public class ThrowAction : MonoBehaviour
{
    [SerializeField] private SightView _view;
    [SerializeField] private Bolt _boltPrefab;
    [SerializeField] private Transform _throwingPivot;
 
    private Vector3? _mouseStartPosition;
    private float _forceMax = 3;

    private void OnEnable()
    {
        _mouseStartPosition = null;
        _view.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _view.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _mouseStartPosition = Input.mousePosition;

        if (_mouseStartPosition.HasValue)
        {
            Vector3 direction = _mouseStartPosition.Value - Input.mousePosition;

            direction.z = direction.y;
            direction.y = 0;

            direction *= -1;

            float force = Mathf.Clamp(direction.magnitude / 100, 0, _forceMax);

            _view.Render(direction.normalized, force);

            if (Input.GetMouseButtonUp(0))
            {
                Bolt bolt = Instantiate(_boltPrefab, _throwingPivot.position, _throwingPivot.rotation);
                bolt.Throw(transform.TransformDirection(direction.normalized), force);

                _view.Render(Vector3.zero, 0);
                _mouseStartPosition = null;
            }
        }
    }
}
