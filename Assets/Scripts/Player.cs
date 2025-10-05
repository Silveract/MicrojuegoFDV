using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float thrustForce = 120f;
    public float rotationSpeed = 20f;

    public GameObject gun, bulletPrefab;
    private Rigidbody _rigidBody;

    public static int score = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Rotate") * rotationSpeed * Time.deltaTime;
        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;

        _rigidBody.AddForce(thrustForce * thrust * thrustDirection);

        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);

            Bullet ammoScript = bullet.GetComponent<Bullet>();

            ammoScript.targetVector = transform.right;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // En 6.2 solo funciona SceneManager si especifico UnityEngine.SceneManagement
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
