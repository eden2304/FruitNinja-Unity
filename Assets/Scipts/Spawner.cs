using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameManager gm;
    public GameObject[] objects;
    public float left;
    public float right;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        StartCoroutine(SpawnRandomObject());
    }

    private IEnumerator SpawnRandomObject() // do a simple iteration
    {
        yield return new WaitForSeconds(1); // wait 1 sec before spwaning another object

        while (!gm.isOver)
        {
            CreateRandomObject();
            yield return new WaitForSeconds(RandomDelay());
        }
    }

    private void CreateRandomObject()
    {
        int index = Random.Range(0, objects.Length);

        GameObject o = Instantiate(objects[index], transform.position, objects[index].transform.rotation);
        o.GetComponent<Rigidbody>().AddForce(RandomDirection() * RandomForce(), ForceMode.Impulse); // the fruit needs to move up

        o.transform.rotation = Random.rotation;
    }

    private float RandomForce()
    {
        return Random.Range(14f, 16f);
    }

    private float RandomDelay()
    {
        return Random.Range(0.5f, 2.5f);
    }

    private Vector2 RandomDirection()
    {
        return new Vector2(Random.Range(left, right), 1).normalized;
    }
}
