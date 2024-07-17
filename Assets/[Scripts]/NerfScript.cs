using UnityEngine;

public class NerfScript : MonoBehaviour
{
    public GameObject DartPrefab;

    private Transform SpawnLocation;

    private GameObject SpawnDart()
    {
        #region ...
        //check if prefab is null
        if (DartPrefab == null)
        {
            Debug.Log("empty...");
            return null;
        }
        #endregion

        GameObject Dart = null;

        Debug.Log("LAUNCH THE PROJECTILE!");

        return Dart;
    }


    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SpawnLocation = GameObject.FindGameObjectWithTag("DartSpawn").transform;

    }

    private float lastShot;

    [Range(0, 1024), SerializeField] private float DartSpeed;

    private float DartDelay = 0.2f;

    #region Dart Physics Logic

    public void ShootDart()
    {
        if (DartPrefab == null)
        {
            return;
        }

        if (lastShot > Time.time)
        {
            return;
        }

        GameObject NerfDartPrefab = SpawnDart();

        lastShot = Time.time + DartDelay;

        ShootDartSound();

        //var bulletPrefab = Instantiate(DartPrefab, DartSpawnPosition.position, DartSpawnPosition.rotation);

        var bulletPrefab = NerfDartPrefab;

        var bulletRB = bulletPrefab.GetComponent<Rigidbody>();
        var direction = bulletPrefab.transform.TransformDirection(Vector3.forward);
        bulletRB.AddForce(direction * DartSpeed);
        Destroy(bulletPrefab, 5f);


    }

    private void ShootDartSound()
    {
        var random = Random.Range(0.8f, 1.2f);

        audioSource.pitch = random;

        audioSource.Play();
    }
    #endregion
}
