using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransformAroundCollider : MonoBehaviour
{
    [SerializeField] private Vector3 _planeNormal;
    [SerializeField] private Vector3 _planePoint;
    [SerializeField] private Collider _collider;
    [SerializeField] private Transform _transformToMove;

    private Plane _plane;

    private void Awake()
    {
        _plane = new Plane(_planeNormal, _planePoint);
    }

    // Update is called once per frame
    void Update()
    {
        Camera mainCamera = GlobalGameManager.Instance.MainCamera;
        Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (_plane.Raycast(mouseRay, out var enter))
        {
            Vector3 pointOnPlane = mouseRay.GetPoint(enter);
            Vector3 pointOnCollider = _collider.ClosestPoint(pointOnPlane);
            _transformToMove.position = pointOnCollider;

            //Vector3 pointToLookAt = _colliderToLookAt.ClosestPoint(pointOnCollider);
            _transformToMove.LookAt(pointOnPlane);
        }
    }
}
