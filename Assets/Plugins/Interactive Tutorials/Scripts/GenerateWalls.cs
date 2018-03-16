using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWalls : MonoBehaviour
{
    public int width;
    public int height;
    public int amount;

    public GameObject block;

    public GameObject leftLimit;
    public GameObject rightLimit;
    public float xOffset;

    public GameObject topLimit;
    public GameObject bottomLimit;
    public float zOffset;

    MeshRenderer renderer;
    float left, right, top, bottom;

    void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        left = leftLimit.transform.position.x;
        right = rightLimit.transform.position.x;
        top = topLimit.transform.position.z;
        bottom = bottomLimit.transform.position.z;
        for (int i = 0; i < amount; i++)
        {
            Instantiate(block, getRandomPosition(transform.position), transform.rotation);
        }
    }

    private Vector3 getRandomPosition(Vector3 vector3)
    {
        float x = Mathf.Floor(Random.value*width)/width * (right - left) + left + xOffset;
        float z = Mathf.Floor(Random.value * height)/height * (top - bottom) + bottom + zOffset;
        return new Vector3(x, vector3.y, z);
    }
}
