/****
 *Created by: Kameron Eaton
 *Date Created: Jan 24, 2022
 *
 *Last Edited by: NA
 *Last Edited: Jan 26, 2022
 *
 *Description: Spawn multiple cube prefabs into the scene.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    public GameObject cubePrefab; //new GameObject
    public float scalingFactor = 0.95f; //amount each cube will shrink each frame
    public int numberOfCubes = 0; //Total number of cubes

    [HideInInspector]
    public List<GameObject> gameObjectList; //list for all the cubes
    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instantiate the list
    }//end Start

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //add to number of cubes

        GameObject gObj = Instantiate<GameObject>(cubePrefab); //creates cube instance

        gObj.name = "Cube" + numberOfCubes; //name of cube instance

        Color randColor = new Color(Random.value, Random.value, Random.value); //generates random color
        gObj.GetComponent<Renderer>().material.color = randColor; //assigns random color to game object

        gObj.transform.position = Random.insideUnitSphere; //random location inside a sphere radius of 1 out from 0, 0, 0

        gameObjectList.Add(gObj); //add to list

        List<GameObject> removeList = new List<GameObject>();

        foreach(GameObject goTemp in gameObjectList){
            float scale = goTemp.transform.localScale.x; //records current scale
            scale *= scalingFactor; //scale multiplied by scale factor
            goTemp.transform.localScale = Vector3.one * scale; //transform scale

            if(scale <= 0.1f)
            {
                removeList.Add(goTemp);
            }//end if
        }//end foreach

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); //remove from game object list
            Destroy(goTemp);
        }//end foreach
        Debug.Log(removeList.Count); //debugs the remove list
    }//end Update
}//end RandomCubes
