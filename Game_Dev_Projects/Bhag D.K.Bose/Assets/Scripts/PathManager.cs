using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] float _xThreshold = -7.7f;
    [SerializeField] List<Mesh> obstacleMeshes;

    private float _scrollSpeed = 2f;
    public float ScrollSpeed
    {
        get
        {
            return _scrollSpeed;
        }

        set
        {
            _scrollSpeed = value;
        }
    }
    
    void Update()
    {
        MoveTiles();
    }

    // Move tiles
    void MoveTiles()
    {
        //print("Moving");
        foreach (Transform tile in this.transform)
        {
            Vector3 tilePosition = tile.position;
            tilePosition.x += -_scrollSpeed * Time.deltaTime;
            tile.position = new Vector3(tilePosition.x, tile.position.y, tile.position.z);
            // Check if out of screen
            if (tile.position.x <= _xThreshold)
            {
                tile.position = new Vector3(7.5f, tile.position.y, tile.position.z);
                // check if the game object is obstacle
                if (tile.tag == "Obstacle")
                {
                    tile.gameObject.GetComponent<MeshFilter>().mesh = obstacleMeshes[Random.Range(0, obstacleMeshes.Count)];
                }
            }
        }
    }
}
