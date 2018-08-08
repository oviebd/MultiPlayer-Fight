using UnityEngine;

public class ProjectileBasedWeapon : MonoBehaviour
{

    [SerializeField] public Transform _gunPos;
    [SerializeField] GameObject _bulletPrefab;

    private int _playerNum;

    private float _prevBulletSpawnTime;
    private string _fireBtn;

    private PlayerWeaponManager _playerWeaponManager;
    private FieldOfViewHelper _fieldOfViewHelper;

    public float viewRadious;
    [Range(0, 360)] public float viewAngle;

    // CoolDown
    [SerializeField] private int _bulletNumberinChamber=5; 
    private int _remainingBulletInChamber;
    [SerializeField] float _bulletCoolDownTime = 0.5f;

    void Start()
    {
        _playerWeaponManager = gameObject.GetComponent<PlayerWeaponManager>();
        _fieldOfViewHelper = gameObject.GetComponent<FieldOfViewHelper>();

        _playerNum = _playerWeaponManager.playerNum;
        _remainingBulletInChamber = _bulletNumberinChamber;
        //  Debug.Log("Player Num  in fire : "  + _playerNum);
        _prevBulletSpawnTime = Time.time;
        _fireBtn = "P" + _playerNum + "Attack1";

    }


    void Update()
    {
        CheckBulletInput();
       
    }

    void CheckBulletInput()
    {
        if (Input.GetButtonDown(_fireBtn))
        {
            if (_remainingBulletInChamber > 0)
                SpawnBulletAndCheckBulletDestination();
            else
            {
                if (Time.time - _prevBulletSpawnTime >= _bulletCoolDownTime)
                {
                    _remainingBulletInChamber = _bulletNumberinChamber;
                    SpawnBulletAndCheckBulletDestination();
                }
            }
        }
    }

    void SpawnBulletAndCheckBulletDestination()
    {
        _prevBulletSpawnTime = Time.time;
        _remainingBulletInChamber--;

        Transform hitObjTransform = _fieldOfViewHelper.GetNearestObj(viewRadious, viewAngle);
        if (hitObjTransform != null)
            InstantiateBullet(hitObjTransform.gameObject);
        else
            InstantiateBullet(null);
        
    }


    void InstantiateBullet(GameObject hitObj)
    {
       
        GameObject bullet_obj = Instantiate(_bulletPrefab);
        // Set it's position and rotation based on the gun positon.
        bullet_obj.transform.position = _gunPos.position;
        bullet_obj.transform.rotation = _gunPos.rotation;

        ProjectileBullet bullet = bullet_obj.GetComponent<ProjectileBullet>();

        bullet.SetTarget(hitObj);
        bullet.playerNum = _playerNum;

       // Debug.Log("Target obj " + bullet_obj.name);
        //Debug.Log("player Num " + bullet.playerNum);

    }
}
