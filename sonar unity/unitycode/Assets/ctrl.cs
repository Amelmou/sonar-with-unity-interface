using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrl : MonoBehaviour
{
	public serialcom serialHnd;
	private float distance;
	private int pos;

	public GameObject RangePrefab;
	public int MAX_ANGLE = 180;


	private float angleRad;
    // Start is called before the first frame update
    void Start()
    {
      for (int i = 0; i < MAX_ANGLE; i++)  {
      	angleRad = i * Mathf.PI / 180;
      	GameObject go = Instantiate(RangePrefab, new Vector3((20 * Mathf.Sin(angleRad)), 0, (20 * Mathf.Cos(angleRad))), Quaternion.identity);
      	go.name = "Cyl" + i; 
      }
    }

    // Update is called once per frame
    void Update()
    {
       distance = serialHnd.RangeRead / 2;
       pos = serialHnd.PositionRead;

       angleRad = pos * Mathf.PI / 180;
       RangePrefab = GameObject.Find("Cyl" + pos);
       RangePrefab.transform.position = new Vector3((20 * Mathf.Sin(angleRad)), 0, (20 * Mathf.Cos(angleRad)));  
    }
}
