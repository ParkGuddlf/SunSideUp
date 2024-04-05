using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SortBody_ver2 : MonoBehaviour
{
    const float splineOffset = 0.5f;

    [SerializeField]
    public SpriteShapeController shapeController;
    [SerializeField]
    public Transform[] points;

    private void Awake()
    {
        UpdateVertices();
    }

    private void Update()
    {
        UpdateVertices();
    }


    void UpdateVertices()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Vector2 _vertex = points[i].localPosition;

            Vector2 _towardsCenter = (Vector2.zero - _vertex).normalized;

            float _colliderRadius = points[i].GetComponent<CircleCollider2D>().radius;

            try
            {
                shapeController.spline.SetPosition(i, (_vertex - _towardsCenter * _colliderRadius));
            }
            catch
            {
                shapeController.spline.SetPosition(i, (_vertex - _towardsCenter * (_colliderRadius + splineOffset)));
            }

            Vector2 _lt = shapeController.spline.GetLeftTangent(i);

            Vector2 _newRt = Vector2.Perpendicular(_towardsCenter) * _lt.magnitude;
            Vector2 _newLt = Vector2.zero - (_newRt);

            shapeController.spline.SetRightTangent(i, _newRt);
            shapeController.spline.SetLeftTangent(i, _newLt);

        }
    }
}
