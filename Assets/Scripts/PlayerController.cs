using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Vector2 _targetPos;

    public event Action<int> OnDamageEvent;

    public float speed;
    public GameObject effect;
    public GameObject soundEffect;

    public float moveDistance;
    private float _middlePosition;

    public enum Position {
        Bottom=0,
        Middle=1,
        Top=2
        
    };

    private Position _currentPos;

    private void Start() {
        _currentPos = Position.Middle;
        _middlePosition = transform.position.y;
    }

    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, _targetPos, speed * Time.deltaTime);
    }

    public Position GetCurrentPosition() {
        return _currentPos;
    }

    public void Move(Position newPos) {
        Instantiate(soundEffect, transform.position, Quaternion.identity);
        Instantiate(effect, transform.position, Quaternion.identity);
        _targetPos = new Vector2(transform.position.x, GetTargetPosition(newPos));
        _currentPos = newPos;
    }

    private float GetTargetPosition(Position pos) {
        switch (pos) {
            case Position.Bottom:
                return _middlePosition - moveDistance;
            case Position.Top:
                return _middlePosition + moveDistance;
            case Position.Middle:
                return _middlePosition;
            default:
                return 0.0f;
        }
    }

    public void TakeDamage(int dmg) {
        OnDamageEvent.Invoke(dmg);
    }

}