using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager; // This is a reference to the GameManager script
    public int pointValue; // This is an int that will be used to store the point value of the target
    public ParticleSystem explosionParticle; // This is a ParticleSystem that will be used to store the explosion particle

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Add force to the target to make it fly up
        targetRb.AddForce(GetRandomForce(), ForceMode.Impulse);

        // Add torque to the target to make it spin
        targetRb.AddTorque(GetRandomTorque(), GetRandomTorque(), GetRandomTorque(), ForceMode.Impulse);

        // Set the position of the target to a random position
        transform.position = GetRandomSpawnPosition();
    }

    private void OnMouseDown() 
    {
        Destroy(gameObject); // Destroy the target when it is clicked
        gameManager.UpdateScore(pointValue); // Call the UpdateScore method from the GameManager script
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); // Instantiate the explosion particle at the position of the target
    }

    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject); // Destroy the target when it enters the sensor
    }

    Vector3 GetRandomForce() // This is a method that returns a Vector3 that is used to set the force of the target
    {
        return Vector3.up * Random.Range(12, 16);
    }

    float GetRandomTorque() // This is a method that returns a float that is used to set the torque of the target
    {
        return Random.Range(-10, 10);
    }

    Vector3 GetRandomSpawnPosition() // This is a method that returns a Vector3 that is used to set the position of the target
    {
        return new Vector3(Random.Range(-4, 4), -6);
    }
}
