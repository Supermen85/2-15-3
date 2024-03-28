using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _waypointsParent;
    [SerializeField] private float _speed = 5f;
    
    private int _waypointIndex;
    private Transform[] _waypoints;

    private void Start()
    {
        _waypoints = new Transform[_waypointsParent.childCount];

        for (int i = 0; i < _waypointsParent.childCount; i++)
            _waypoints[i] = _waypointsParent.GetChild(i);
    }

    private void Update()
    {
        Transform waypoint = _waypoints[_waypointIndex];

        transform.position = Vector3.MoveTowards(transform.position, waypoint.position, _speed * Time.deltaTime);

        if (transform.position == waypoint.position)
            ChangeWaypoint();
    }

    private void ChangeWaypoint()
    {
        _waypointIndex++;

        if (_waypointIndex == _waypoints.Length)
            _waypointIndex = 0;

        Vector3 position = _waypoints[_waypointIndex].transform.position;

        transform.forward = position - transform.position;
    }
}