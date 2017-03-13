using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public  float score = 0;
    public static float getscore;

	public static float setScore() {
        return getscore;	
	}
	
	void Update () {
        this.GetComponent<Text>().text = score.ToString("f0");
        getscore = score;
	}
}
