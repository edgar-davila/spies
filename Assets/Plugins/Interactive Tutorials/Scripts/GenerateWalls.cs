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
		int[][] matrix = generateMatrix(width,height,amount);
		for (int i=0;i<matrix.Length;i++)
        {
			for(int j=0;j<matrix[0].Length;j++) {
				if (matrix[i][j] == 1) {
					Instantiate(block, getPosition(transform.position,i,j), transform.rotation);
					//Instantiate(block, getRandomPosition(transform.position), transform.rotation);
				}
			}
        }
    }
		
	private Vector3 getPosition(Vector3 vector3, float xPos, float zPos)
	{
		float x = xPos/width * (right - left) + left + xOffset;
		float z = zPos/height * (top - bottom) + bottom + zOffset;
		return new Vector3(x, vector3.y, z);
	}

	private Vector3 getRandomPosition(Vector3 vector3)
	{
		float x = Mathf.Floor(Random.value * width)/width * (right - left) + left + xOffset;
		float z = Mathf.Floor(Random.value * height)/height * (top - bottom) + bottom + zOffset;
		return new Vector3(x, vector3.y, z);
	}

	private int[][] generateMatrix(int width, int height, int amount){
		int[][] matrix = new int[width][];
		for (int j = 0;j<width;j++) {
			matrix[j]=new int[height];
		}
		for (int i=0;i<amount;i++){
			Vector2 position =getRandomZero (matrix);
			matrix [(int)position.x] [(int)position.y] = 1;
		}

		return matrix;
	}

	private Vector2 getRandomZero(int[][] matrix){
		int x = 0, y = 0;
		do{
			x=Random.Range(0,matrix.Length-1);
			y=Random.Range(0,matrix[0].Length-1);
		}while (matrix[x][y]!=0);

		return new Vector2 (x, y);
	}
}
