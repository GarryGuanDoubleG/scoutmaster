using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float Speed = 0f;
    public float Movex = 0f;
    public float Movey = 0f;

    private Rigidbody2D rigid2d;

    private void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update ()
    {
        Movex = Input.GetAxis("Horizontal");
        Movey = Input.GetAxis("Vertical");
        //Debug.Log("Speed: " + Speed + " \n Movex: " + Movex + " \n Movey: " + Movey + "\n");

        rigid2d.velocity = new Vector2(Movex * Speed, Movey * Speed);
    }
}
