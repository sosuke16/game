using UnityEngine;
using System.Collections;

public class creatscript : MonoBehaviour {

    public GameObject Ground;
    public GameObject Ground2;

    int border = 124;

	void Update () {
        if(transform.position.z > border)
        {
            CreateMap();
        }	
	}

    void CreateMap()
    {
        if(Ground.transform.position.z < border)
        {
            border += 250;
            Vector3 temp = new Vector3(0, -0.5f, border);
            Ground.transform.position = temp;
        }else if(Ground2.transform.position.z < border)
        {
            border += 250;
            Vector3 temp = new Vector3(0, -0.5f, border);
            Ground2.transform.position = temp;
        }
    }
}
