using UnityEngine;

public class PlaceMover : MonoBehaviour
{
    [SerializeField] private Transform[] _placespoints;

    [SerializeField] private float _moveSpeed = 5;

    private Transform _currentPlacepoint;

    private int _currentPlaceIndex = 0;

    private float _minDistanceToPlacepoint = 0.1f;

    private void Start()
    {
        if (_placespoints.Length > 0)
        {
            _currentPlacepoint = _placespoints[_currentPlaceIndex];
        }
    }

    private void Update()
    {
        MoveToPlace();
    }

    private void MoveToPlace()
    {
        if (_placespoints.Length > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentPlacepoint.position, _moveSpeed * Time.deltaTime);

            if (transform.position.IsEnoughClose(_currentPlacepoint.position, _minDistanceToPlacepoint))
                ChooseNextPlace();
        }
    }

    private void ChooseNextPlace()
    {
        _currentPlaceIndex++;

        if (_currentPlaceIndex == _placespoints.Length)
            _currentPlaceIndex = 0;

        Transform nextPlace = _placespoints[_currentPlaceIndex].transform;

        transform.forward = nextPlace.position - transform.position;
        _currentPlacepoint = nextPlace;
    }
}