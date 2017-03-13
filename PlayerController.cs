using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public float minSwipeDistX;
    public float minSwipeDistY;
    private float swipeDistX;
    private float swipeDistY;
    float SignValueX;
    float SignValueY;
    private Vector2 startPos;
    private Vector2 endPos;

    void Start()
    {
        if (minSwipeDistX == 0)
        {
            minSwipeDistX = 50;
        }
        if (minSwipeDistY == 0)
        {
            minSwipeDistY = 50;
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.touches[0];

            switch (touch.phase)
            {

                case TouchPhase.Began:

                    startPos = touch.position;

                    break;

                case TouchPhase.Ended:


                    endPos = new Vector2(touch.position.x, touch.position.y);

                    swipeDistX = (new Vector3(endPos.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                    print("X" + swipeDistX.ToString());
                    if (swipeDistX > minSwipeDistX)
                    {

                        SignValueX = Mathf.Sign(endPos.x - startPos.x);

                        if (SignValueX > 0)
                        {

                        }
                        else if (SignValueX < 0)
                        {

                        }
                    }

                    swipeDistY = (new Vector3(0, endPos.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                    if (swipeDistY > minSwipeDistY)
                    {

                        SignValueY = Mathf.Sign(endPos.y - startPos.y);

                        if (SignValueY > 0)
                        {
                            anim.SetTrigger("jump");
                        }
                        else if (SignValueY < 0)
                        {
                            anim.SetTrigger("slide");
                        }
                    }
                    break;
            }

        }
    }

    void OnTriggerEnter(Collider col)
    {
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Base Layer.Run") ||
            (state.IsName("Base Layer.Vaut") && col.CompareTag("Higher")) ||
            (state.IsName("Base Layer.Slide") && col.CompareTag("Lower")))
        {
            anim.SetBool("dead", true);
            StartCoroutine("ToResult");
        }

    }


    IEnumerator ToResult()
    {
        yield return new WaitForSeconds(2);
        Application.LoadLevel("Result");
    }

    void LateUpdate()
    {
        //this.GetComponent<Rigidbody>().velocity.x = Vector3.zero;
    }

}