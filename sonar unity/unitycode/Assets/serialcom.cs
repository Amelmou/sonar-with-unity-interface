using System;
using System.IO.Ports;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serialcom : MonoBehaviour
{
	public string COMPORT = "COM3";
	public int COMSPEED = 9600;

	public float RangeRead;
	public int PositionRead;


	SerialPort stream;
    
    void Start()
    {
    	stream = new SerialPort(COMPORT,COMSPEED);
    	stream.Open();
    	stream.ReadTimeout = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
    	string value = "";
    	string[] vec2 = { "","" };
    	try{
    		value = stream.ReadLine();
    	}
    	catch{
    		value = "";
    	}
    	if (value != ""){
    		vec2 = value.Split(' ');
    		RangeRead = float.Parse(value);
    		Debug.Log(value);
    	}
    	if (vec2[0] != "" && vec2[1] != ""){
    		RangeRead = float.Parse(vec2[1]);
    		PositionRead = int.Parse(vec2[0]);
    	}
        
    }

    void OnApplicationQuit(){
    	stream.Close();
    }
}
