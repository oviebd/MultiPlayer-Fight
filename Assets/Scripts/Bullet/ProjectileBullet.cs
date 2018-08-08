using UnityEngine;

public class ProjectileBullet : MonoBehaviour
{

    [HideInInspector] GameObject targetedObj;

    [HideInInspector] public int playerNum; //Which player shoot the bullet

    [SerializeField] private float _movingSpeed = 10f;
    [SerializeField] private GameObject _hitParticle;
    [SerializeField] private float _destroyTime = 5.0f;
    [SerializeField] private GameObject trail ;

    private bool _isCollided =false;
    private bool _isMoving;
    private Rigidbody _rb;

    public float nearestDistanceForTargetLose = 5.0f;
    public int damage = 20;

    //For Range
    [SerializeField] private float _maxRange = 1.0f;
    private Vector3 _spawnPosition;


    void Start()
    {
        trail.SetActive(false);
        Destroy(gameObject, _destroyTime);
       
        // _isMoving = false;
        _rb = GetComponent<Rigidbody>();
        Invoke("InstantiateTrail", 0.0f);
        _spawnPosition = transform.position;
    }

    void InstantiateTrail()
    {
        trail.SetActive(true);
    }

    public void SetTarget(GameObject target)
    {
        targetedObj = target;
        _isMoving = true;
      //  Debug.Log("Target Set");
    }

    void Update()
    {
        if (_isMoving)
        {
            Checkrange();

            if (targetedObj != null)
                MoveTowardsATarget();
            else
                MoveForward();
        }
    }

    void Checkrange()
    {
        float distance = (Vector3.Distance(transform.position, _spawnPosition));
       // Debug.Log("Travelled Distance : " + distance);
        if (distance >= _maxRange)
        {
            //Debug.Log("Futush ");
            Destroy(gameObject);
            _isMoving = false;
        }
    }

    void MoveTowardsATarget()
    {
        Vector3 targetPos = new Vector3(targetedObj.transform.position.x, targetedObj.transform.position.y + 1, targetedObj.transform.position.z);

        float tempDistance = Vector3.Distance(transform.position, targetPos);

        if (tempDistance <= nearestDistanceForTargetLose)
        {
            targetedObj = null;
            return;
        }

        var targetRotation = Quaternion.LookRotation(targetPos - transform.position);
        _rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, 200f));

        _rb.velocity = transform.forward * _movingSpeed;
    }


    void MoveForward()
    {
        Vector3 p = new Vector3(0, 0, 1);
        _rb.velocity = transform.forward * _movingSpeed;
    }


    private void OnTriggerEnter(Collider other)
    {
        
        _isMoving = false;

        if (_isCollided == false)
            _isCollided = true;
        else
            return;

        if (other.GetComponent<PlayerWeaponManager>() != null)
        {
            //Check Is it the owner of the player
            if (other.GetComponent<PlayerWeaponManager>().playerNum == playerNum)
            {
             
                _isMoving = true;
                _isCollided = false;
                return;
            }
        }

        if (other.GetComponentInParent<ShieldManager>() != null)
        {
            //Debug.Log("Hit Schild Manager Hit player Num" + other.GetComponentInParent<SchildManager>().playerNum);
            //Check is it schild first then check is it the same player schild
            if (other.GetComponentInParent<ShieldManager>().playerNum == playerNum){
              
                _isMoving = true;
                _isCollided = false;
                return;
            }
        }
       

        Damageable damagable = other.GetComponent<Damageable>();
        if(damagable != null){

            damagable.particleEffect = _hitParticle;
            damagable.hitObj = gameObject;
            damagable.Damage(damage);
       
           // Debug.Log("Damageable Found ");
        }
        else
        {
           Destroy(gameObject);
        }

    }
}
