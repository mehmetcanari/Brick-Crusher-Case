using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltSystem : MonoBehaviour
{
    public float _speed;
    public Vector3 _direction;
    public List<GameObject> _onBelt;

    private void Update()
    {
        MoveObjects();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7) //Brick layer
        {
            _onBelt.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            _onBelt.Remove(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Debug.Log("DESTROY");
        }
    }

    private void MoveObjects()
    {
        if (_onBelt.Count > 0)
        {
            foreach (var _brick in _onBelt)
            {
                _brick.GetComponent<Rigidbody>().velocity = _speed * _direction * Time.deltaTime;
            }
        }
    }
}
