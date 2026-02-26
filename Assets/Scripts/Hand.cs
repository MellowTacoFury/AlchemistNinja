using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private bool slicing;
    private Collider handCollider;
    public float minHandVelocity = 0.01f;
    public float smackForce = 5f;
    public Vector3 direction { get; private set; }//direction the hand is swiping in

    void Awake()
    {
        handCollider = GetComponent<Collider>();
    }
    void Update()
    {
        if(GameObject.Find("Managers").GetComponent<GameManager>().GameDone == false)
        {
            #if UNITY_STANDALONE
            if(Input.GetMouseButtonDown(0))//press
            {
                StartMouseSlice();
            }
            else if(Input.GetMouseButtonUp(0))//release
            {
                StopSlice();
            }
            else if(slicing)//still slicing
            {
                ContinueMouseSlice();
            }
            #endif
            #if UNITY_ANDROID
            if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                StartFingerSlice();
            }
            else if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                ContinueFingerSlice();
            }
            else if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)//release
            {
                StopSlice();
            }
            #endif
        }
        
        
    }
    void OnEnable()//just in case, make sure its set
    {
        StopSlice();
    }

    void OnDisable()
    {
        StopSlice();
    }

    void StartMouseSlice()
    {
        //screen to world point expects x, y, distance from cam
        Vector3 newHandPos = 
        Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        
        transform.position = newHandPos;

        slicing = true;
        handCollider.enabled = true;
        if(GameObject.Find("Managers").GetComponent<GameManager>().GamePaused == false)
            GetComponent<AudioSource>().Play();
        
    }
    void StopSlice()
    {
        slicing = false;
        handCollider.enabled = false;
    }

    void ContinueMouseSlice()
    {
        Vector3 newHandPos = 
        Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        direction = newHandPos - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        
        handCollider.enabled = velocity > minHandVelocity;
       
        transform.position = newHandPos;
    }


    void StartFingerSlice()
    {
        Touch touch = Input.GetTouch(0);

        Vector3 pos = touch.position;
        //screen to world point expects x, y, distance from cam
        Vector3 newHandPos = 
        Camera.main.ScreenToWorldPoint(
            new Vector3(pos.x, pos.y, 10));
        
        transform.position = newHandPos;

        slicing = true;
        handCollider.enabled = true;
        if(GameObject.Find("Managers").GetComponent<GameManager>().GamePaused == false)
            GetComponent<AudioSource>().Play();
    }

    void ContinueFingerSlice()
    {
        Touch touch = Input.GetTouch(0);

        Vector3 pos = touch.position;
        //screen to world point expects x, y, distance from cam
        Vector3 newHandPos = 
        Camera.main.ScreenToWorldPoint(
            new Vector3(pos.x, pos.y, 10));

            
        direction = newHandPos - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        
        handCollider.enabled = velocity > minHandVelocity;
       
        transform.position = newHandPos;
    }



}
