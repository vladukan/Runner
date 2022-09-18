using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;
    private Vector3 _targetPos;
    private void Start()
    {
        _targetPos = transform.position;
    }
    private void Update()
    {
        if (transform.position != _targetPos)
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, _moveSpeed * Time.deltaTime);
    }
    public void TryMoveUp()
    {
        if (_targetPos.y < _maxHeight) SetNextPos(_stepSize);
    }

    public void TryMoveDown()
    {
        if (_targetPos.y > _minHeight) SetNextPos(-_stepSize);
    }

    private void SetNextPos(float stepSize)
    {
        _targetPos = new Vector2(_targetPos.x, _targetPos.y + stepSize);
    }

}
