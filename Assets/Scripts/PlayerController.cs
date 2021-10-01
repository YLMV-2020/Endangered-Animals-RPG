using UnityEngine;


public class PlayerController: MonoBehaviour
{
    public static PlayerController sharedInstance;

    [SerializeField] Camera cameraPlayer;
    [SerializeField] FirstPersonController player;
    [SerializeField] Animator animator;

    Vector3 inputAxis;

    private void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {

    }

    void Update()
    {
        //inputAxis = player.inputAxis;

        //animator.SetFloat("velocityX", inputAxis.x);
        //animator.SetFloat("velocityY", inputAxis.z);
    }

    private void FixedUpdate()
    {
        
    }

    //void OnGUI()
    //{
    //    Debug.Log("gui evento");
    //    GUI.Label(new Rect(new Vector2(20, 20), new Vector2(2,2)), "Game Over");
    //}

}
