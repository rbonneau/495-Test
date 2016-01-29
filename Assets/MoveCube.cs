using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveCube : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            int currentCube = gameObject.GetComponent<CubeColor>().selectedCube;
            GameObject cube = GameObject.Find("Cube" + currentCube);

            cube.transform.Translate(new Vector3(0, 1, 0));
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            int currentCube = gameObject.GetComponent<CubeColor>().selectedCube;
            GameObject cube = GameObject.Find("Cube" + currentCube);

            cube.transform.Translate(new Vector3(0, -1, 0));
        }

    }
	//END private void Update()

}