using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // public float turnSmoothTime = 0.2f;
    //float turnSmoothVelocity;

    //Player Setting
    [HideInInspector]  public int playerNum;
    private string _veryticalInput;
    private string _horizontallInput;

    //Move 
    Vector2 inputData = new Vector2();
    public float walkSpeed = 2;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    private float _horizontalValue;
    private float _verticalValue;
    private float _maxValueForMoveInput=0.7f;
    private bool _isRotate;

    private Rigidbody _rb;
    Animator _anim;
    private string _speed_anim = "Speed";


    //Dash
    [SerializeField] private float dashSpeed = 2.0f;
    [SerializeField] private float _dash_Duration = 0.25f;
    [SerializeField] private float _dashCoolDownTime = 3.0f;
    [SerializeField] private GameObject _dashTrail;
    string _dashInput;
    
    private bool _dashing = false;
    private float _prevDashTime;
    private Vector3 dash_Direction;
   

   


    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();

    }


    private void Start()
    {
        _veryticalInput = "Vertical" + playerNum;
        _horizontallInput = "Horizontal" + playerNum;

       
        _dashInput = "Dash" + playerNum;
        _prevDashTime = Time.time;
        _dashing = false;
    }


    void Update()
    {
        _rb.angularVelocity = Vector3.zero;
        _rb.velocity = Vector3.zero;
      
        _horizontalValue = Input.GetAxis(_horizontallInput);
        _verticalValue = Input.GetAxis(_veryticalInput);
        Debug.Log("Vertical Value " + _verticalValue);
        inputData = new Vector2(_horizontalValue,_verticalValue);

       
        if (Input.GetButtonDown(_dashInput) && _dashing == false)
        {
            if (Time.time - _prevDashTime >= _dashCoolDownTime)
            {
                _dashing = true;
                _prevDashTime = Time.time;
                Invoke("StopDashing",_dash_Duration);
            }
        }

       
    }

    void StopDashing()
    {
        _dashing = false;
        _prevDashTime = Time.time;
        _rb.velocity = Vector3.zero;   
    }

    void FixedUpdate()
    {
        MovePlayer();

        if (_dashing == true)
           Dash();
    }

     void MovePlayer()
     {
         Vector2 inputDir = inputData.normalized;
         if (inputDir != Vector2.zero)
         {
             float targetRotation = (Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg) ;
             // subtract 90 because samurai plane007's rotation is not zero.
             transform.eulerAngles = Vector3.up * (Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg);
             //  transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
         }

         currentSpeed = Mathf.SmoothDamp(currentSpeed, walkSpeed * inputDir.magnitude, ref speedSmoothVelocity, speedSmoothTime);

       

        if ( (_horizontalValue <=- _maxValueForMoveInput || _horizontalValue >= _maxValueForMoveInput) ||
            (_verticalValue <= -_maxValueForMoveInput || _verticalValue >= _maxValueForMoveInput)
           )
        {
            transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
            float animationSpeed = 8.0f * inputDir.magnitude;
          //  _anim.SetFloat(_speed_anim, animationSpeed, speedSmoothTime, Time.deltaTime);
        }
       
     

        //  float animationSpeed = (running ? 3.0f : 6.5f) * inputDir.magnitude;
      
     }



    void Dash()
    {

        dash_Direction = new Vector3(inputData.x, 0f, inputData.y).normalized;
        if (dash_Direction == Vector3.zero)
            dash_Direction = transform.forward;
        _dashTrail.SetActive(true);

        //  transform.Translate(dash_Direction  * dashSpeed * Time.deltaTime, Space.World);
        _rb.velocity = dash_Direction * dashSpeed;
    }
}
