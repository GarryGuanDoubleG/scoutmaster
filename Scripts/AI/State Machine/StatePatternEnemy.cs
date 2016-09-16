using UnityEngine;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour
{
    public Vector3 previousGood;
    public Rigidbody2D rigid2d;

    public float searchingTurnSpeed = 120f;
    public float searchingDuration = 4f;
    public float sightRange = 20f;
    public Transform[] wayPoints;
    public Transform eyes;
    public Vector3 offset = new Vector3(0, .5f, 0);
    public MeshRenderer meshRendererFlag;

    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public IEnemyState currentState;
    [HideInInspector] public AlertState alertState;
    [HideInInspector] public ChaseState chaseState;
    [HideInInspector] public PatrolState patrolState;

    [HideInInspector] public NavMeshAgent navMeshAgent;

    //called before start
    private void Awake()
    {
        previousGood = Vector3.zero;
        rigid2d = GetComponent<Rigidbody2D>();

        patrolState = new PatrolState(this);        
        alertState = new AlertState(this);
        chaseState = new ChaseState(this);

        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public void Get_State()
    {
        string state = "";

        if (currentState == patrolState)
            state = "Patrol";
        else if (currentState == alertState)
            state = "Alert";
        else
            state = "Chase";
        Debug.Log("Current state: " + state + "\n");

    }
    // Use this for initialization
    void Start ()
    {
        currentState = patrolState;
        rigid2d.velocity = new Vector2(2, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Get_State();
        currentState.UpdateState();
	}

}
