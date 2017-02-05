using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGeneratorMonoBehaviour : MonoBehaviour {

    public GameObject[] fruitPrefabs;

	// Use this for initialization
	void Start () {
        StartCoroutine(GenerateFruit());
	}

    private IEnumerator GenerateFruit()
    {
        while(true)
        {
            GameObject go = Instantiate(fruitPrefabs[Random.Range(0, fruitPrefabs.Length)]);
            Rigidbody rigidBody = go.GetComponent<Rigidbody>();

            rigidBody.velocity = new Vector3(0f, 5f, .5f);
            rigidBody.angularVelocity = new Vector3(Random.Range(-4,4), 0f, Random.Range(-4,4));
            rigidBody.useGravity = true;

            Vector3 position = transform.position;
            position.x += Random.Range(-1f, 1f);
            rigidBody.transform.position = position;

            yield return new WaitForSeconds(1);
        }
        
    }
}
