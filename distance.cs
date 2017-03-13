using UnityEngine;
using System.Collections;

public class distance : MonoBehaviour {

    public  Score score;

    public GameObject start;
    public GameObject plane7;
    void Update()
    {
        Vector3 Apos = start.transform.position;
        Vector3 Bpos = plane7.transform.position;
        float dis = Vector3.Distance(Apos, Bpos);
        Debug.Log("Distance : " + dis);
        score.GetComponent<Score>().score = dis;
    }
}

