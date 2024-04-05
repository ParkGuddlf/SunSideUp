using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftBody : MonoBehaviour
{
    public Mesh mesh;
    public Vector3[] vertices;
    public int centerPoint;
    public int verticesCount;

    public List<GameObject> points;
    public GameObject toBeIstantied;
    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        verticesCount = vertices.Length;

        for (int i = 0; i < verticesCount; i++)
        {
            GameObject childObject = Instantiate(toBeIstantied, gameObject.transform.position + vertices[i], Quaternion.identity) as GameObject;
            childObject.transform.SetParent(transform);
            points.Add(childObject);
        }

        for (int i = 0; i < points.Count; i++)
        {
            //if (i != centerPoint)
            {
                if (i == points.Count - 1)
                    points[i].GetComponent<HingeJoint2D>().connectedBody = points[0].GetComponent<Rigidbody2D>();
                else
                    points[i].GetComponent<HingeJoint2D>().connectedBody = points[i + 1].GetComponent<Rigidbody2D>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = points[i].transform.localPosition;
        }
        mesh.vertices = vertices;
    }
}

