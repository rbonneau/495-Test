using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeColor : MonoBehaviour
{
    /*
        
        
        
    */
    public int selectedCube = -1;
    private int dayOfTheWeek;
	//total number of cubes
	private int maxCubes = 0;
	//indicator to reset to cube0
	private int endCube = 0;

	// Use this for initialization
	private void Start()
	{

    }

	// Update is called once per frame
	private void Update()
	{
		ColorData cols = new ColorData();

		for(int i = 0; i < 5; i++)
		{
			
			maxCubes = 0;
			foreach(GameObject randomObject in GameObject.FindObjectsOfType(typeof(GameObject)))
			{
				
				if(randomObject.name == "Cube" + i)
				{
					maxCubes++;

					randomObject.GetComponent<Renderer>().material.color = cols.GetAColorToUse(i);
				}

			}

		}

		if(Input.GetButtonDown("Jump"))
		{
			SetScaleOfCubes();
		}

    }

	private void SetScaleOfCubes()
	{
		GameObject gObject;

		if(selectedCube > -1)// && selectedCube < numberOfCubes)
		{
			gObject = GameObject.Find("Cube" + selectedCube);

			gObject.transform.localScale = new Vector3(1, 1, 1);
		}


		maxCubes = GetCubeCount();
		if(maxCubes > 4)
		{
			endCube = 4;
		}
		else if (maxCubes == 4)
		{
			endCube = 3;
		}

		if(selectedCube < endCube)
		{
		
			selectedCube++;
		}
		else
		{
			selectedCube = 0;
		}

		foreach(GameObject cube in GameObject.FindObjectsOfType(typeof(GameObject)))
		{
			if(cube.name == "Cube" + selectedCube)
			{
				cube.transform.localScale = new Vector3(1, 2, 1);
			}

		}
	
    }

	private int GetCubeCount()
	{
		int cubeCount = 0;

		for(int i = 0; i < 5; i++)
		{
			foreach(GameObject gObject in GameObject.FindObjectsOfType(typeof(GameObject)))
			{

				if(gObject.name == "Cube" + i)
				{
					cubeCount++;
				}

			}
		}

		return cubeCount;

	}

	public float YOfCube(int cubeNumber)
    {
        GameObject gObject = GameObject.Find("Cube" + selectedCube);

        return gObject.transform.localScale.y;
    }

}

public class ColorData
{
    public Color GetAColorToUse(int indexOfTheColorToGet)
	{
        List<Color> colorList = new List<Color>();
        colorList.Add(new Color(1, 0, 0));
        colorList.Add(new Color(.7f, .7f, 0));
        colorList.Add(new Color(0, 1, 0));
        colorList.Add(new Color(0, .3f, 1));
        colorList.Add(new Color(0, 1, 1));

        return colorList[indexOfTheColorToGet];
    }


}

public class CubeData
{
    // When we find a cube, we should put its data in here for tidier access
}
