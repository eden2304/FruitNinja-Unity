using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private GameManager gm;
    public GameObject slicedFruit;
    public GameObject fruitJuice;
    private float rotationForce = 200;
    private Rigidbody rb;
    public int scorePoints;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce); // rotating the fruits in the air
    }

    private void CreateSlicedFruit()
    {
        GameObject slices = Instantiate(slicedFruit, transform.position, transform.rotation); // create the sliced peaces of the fruit
        GameObject juice = Instantiate(fruitJuice, new Vector3(transform.position.x, transform.position.y, 0), fruitJuice.transform.rotation); // create the fruit juice, need to be in 2D

        Rigidbody[] slicesRb = slices.transform.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody sliceRb in slicesRb) {
            sliceRb.AddExplosionForce(130f, transform.position, 10);
            sliceRb.velocity = rb.velocity * 1.2f; // give the slices the velocity of the whole fruit before the slicing times 1.2
        }

        Destroy(slices, 5);
        Destroy(juice, 5);
    }

    private void OnTriggerEnter(Collider other) // when the fruit collide with the blade
    {
        if(other.tag == "Player")
        {
            gm.UpdateScore(scorePoints);
            Destroy(gameObject);
            CreateSlicedFruit();
        }

        if(other.tag == "BottomArea")
        {
            gm.UpdateLives();
        }
    }
}
