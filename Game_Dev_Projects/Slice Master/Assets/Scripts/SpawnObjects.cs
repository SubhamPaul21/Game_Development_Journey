using System.Collections;
using System.Threading;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private int thresholdTimeToIncreaseSpeed = 5;
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private float spawnInterval, objectMinX, objectMaxX, objectY;
    [SerializeField] private Mesh[] objectMeshes;

    private bool speedChanged = false;

    //Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private void FixedUpdate()
    {
        int currentScore = ShowScore.Instance.Score;
        if (currentScore > 0 && currentScore % thresholdTimeToIncreaseSpeed == 0 && !speedChanged)
        {
            thresholdTimeToIncreaseSpeed += thresholdTimeToIncreaseSpeed;
            spawnInterval -= Random.Range(0.2f,0.3f);

            if (gameObject.name == "Grenade Spawner" && spawnInterval < 2.5f)
            {
                spawnInterval -= 0.1f;
            }
            else if (gameObject.name == "Fruit Spawner" && spawnInterval < 0.5f)
            {
                spawnInterval -= 0.1f;
            }

            speedChanged = true;
        }
        else if (currentScore > 0 && currentScore % thresholdTimeToIncreaseSpeed != 0)
        {
            speedChanged = false;
        }
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            Vector2 objectPos = new Vector2(Random.Range(objectMinX, objectMaxX), objectY);
            GameObject newObject = Instantiate(prefabToSpawn) as GameObject;
            newObject.GetComponent<Rigidbody2D>().AddTorque(objectPos.magnitude / Random.Range(1.5f,3f), ForceMode2D.Impulse);
            newObject.transform.position = objectPos;

            if (prefabToSpawn.name == "Fruit")
            {
                Mesh objectMesh = objectMeshes[Random.Range(0, objectMeshes.Length)];
                newObject.GetComponentInChildren<MeshFilter>().mesh = objectMesh;
            }
        }
    }
}
