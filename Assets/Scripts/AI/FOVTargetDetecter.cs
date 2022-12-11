using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FOVTargetDetecter : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _angle;
    [SerializeField] private float _height;
    [SerializeField] private Color _meshColor;
    [SerializeField] private int _maxTargetsDetect = 3;
    [SerializeField] private float _maxDistanceForDetect = 1;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private LayerMask _obstaclesLayer;

    private Mesh _fovMesh;
    private Collider[] _targetColliders;
    private List<GameObject> _targetsDetected = new();
    private int _targetAroundCount;

    private Vector3 _up => Vector3.up * _height;
    private Vector3 _down => Vector3.down * (_height / 2);

    private void Start ()
    {
        _targetColliders = new Collider[_maxTargetsDetect];
    }

    private Mesh CreateWedgeMesh()
    {
        Mesh mesh = new Mesh();

        int segments = 10;
        int numTriangles = (segments * 4) + 2 + 2;
        int numVertices = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCenter = _down;
        Vector3 bottomLeft = GetBottom(-_angle / 2);
        Vector3 bottomRight = GetBottom(_angle / 2);

        Vector3 topCenter = bottomCenter + _up;
        Vector3 topLeft = bottomLeft + _up;
        Vector3 topRight = bottomRight + _up;

        int vertice = 0;

        vertices[vertice++] = bottomCenter;
        vertices[vertice++] = bottomLeft;
        vertices[vertice++] = topLeft;

        vertices[vertice++] = topLeft;
        vertices[vertice++] = topCenter;
        vertices[vertice++] = bottomCenter;

        vertices[vertice++] = bottomCenter;
        vertices[vertice++] = topCenter;
        vertices[vertice++] = topRight;

        vertices[vertice++] = topRight;
        vertices[vertice++] = bottomRight;
        vertices[vertice++] = bottomCenter;

        float currentAngle = -_angle / 2;
        float deltaAngle = _angle / segments;

        for (int i = 0; i < segments; i++)
        {
            bottomLeft = GetBottom(currentAngle);
            bottomRight = GetBottom(currentAngle + deltaAngle);

            topLeft = bottomLeft + _up;
            topRight = bottomRight + _up;

            vertices[vertice++] = bottomLeft;
            vertices[vertice++] = bottomRight;
            vertices[vertice++] = topRight;

            vertices[vertice++] = topRight;
            vertices[vertice++] = topLeft;
            vertices[vertice++] = bottomLeft;

            vertices[vertice++] = topCenter;
            vertices[vertice++] = topLeft;
            vertices[vertice++] = topRight;

            vertices[vertice++] = bottomCenter;
            vertices[vertice++] = bottomLeft;
            vertices[vertice++] = bottomRight;

            currentAngle += deltaAngle;
        }

        

        for (int i = 0; i < numVertices; i++)
        {
            triangles[i] = i;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

    private Vector3 GetBottom(float angle)
    {
        return Quaternion.Euler(0, angle, 0) * Vector3.forward * _distance + _down;
    }

    public List<GameObject> ScanView()
    {
        UpdateTargetsAroundCount();
        _targetsDetected.Clear();
        for (int i = 0; i < _targetAroundCount; i++)
        {
            if (IsInSight(_targetColliders[i].transform))
            {
                _targetsDetected.Add(_targetColliders[i].gameObject);
            }
        }

        return _targetsDetected;
    }

    private void UpdateTargetsAroundCount()
    {
        _targetAroundCount = Physics.OverlapSphereNonAlloc(transform.position,
            _distance, _targetColliders, _targetLayer, QueryTriggerInteraction.Collide);
    }

    private bool IsInSight(Transform other)
    {
        Vector3 origin = transform.position;
        Vector3 targetPosition = other.position;
        Vector3 direction = targetPosition - origin;

        bool targetInSight = true;

        if (direction.y > _height / 2 || direction.y < -_height / 2)
        {
            targetInSight = false;
        }

        float deltaAngle = Vector3.Angle(new Vector3(direction.x, 0, direction.z),
            transform.forward);
        if (deltaAngle > _angle / 2)
        {
            targetInSight = false;
        }

        if (!targetInSight && direction.magnitude < _maxDistanceForDetect)
        {
            targetInSight = true;
        }

        if (Physics.Raycast(transform.position, direction.normalized,
            out RaycastHit hit, _distance, _obstaclesLayer))
        {
            if ((transform.position - hit.point).magnitude < direction.magnitude)
            {
                targetInSight = false;
            }
        }
        return targetInSight;
    }

    private void OnValidate()
    {
        _fovMesh = CreateWedgeMesh();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _meshColor;
        Gizmos.DrawMesh(_fovMesh, transform.position, transform.rotation);

        Gizmos.DrawWireSphere(transform.position, _distance);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _maxDistanceForDetect);

    }
}
