using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] private GameObject _bladeTrailPrefab;
    [SerializeField] private float trailDestroyTime = 0.3f;

    private GameObject _currentBladeTrail;
    private bool _isCutting = false;
    private Camera cam;
    private Vector2 _previousPosition;
    private Touch _touch;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        ProcessUserInput();
    }

    void ProcessUserInput()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0) && _isCutting)
        {
            ProcessCut();
        }
#elif UNITY_ANDROID && !UNITY_EDITOR
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Began)
            {
                StartCutting();
            }

            else if (_touch.phase == TouchPhase.Ended  && _isCutting)
            {
                ProcessCut();
            }
        }
#endif
    }

    void ProcessCut()
    {
        _isCutting = false;
#if UNITY_EDITOR
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
#elif UNITY_ANDROID && !UNITY_EDITOR
        Vector2 newPosition = cam.ScreenToWorldPoint(_touch.position);
#endif
        _currentBladeTrail = Instantiate(_bladeTrailPrefab, _previousPosition, Quaternion.identity) as GameObject;
        _currentBladeTrail.GetComponent<LineRenderer>().SetPosition(0, _previousPosition);
        _currentBladeTrail.GetComponent<LineRenderer>().SetPosition(1, newPosition);

        Vector2[] colliderPoints = new Vector2[2];
        colliderPoints[0] = new Vector2(0f, 0f);
        colliderPoints[1] = newPosition - _previousPosition;

        _currentBladeTrail.GetComponent<EdgeCollider2D>().points = colliderPoints;
        Destroy(_currentBladeTrail, trailDestroyTime);
    }

    void StartCutting()
    {
#if UNITY_EDITOR
        _previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
#elif UNITY_ANDROID && !UNITY_EDITOR
        _previousPosition = cam.ScreenToWorldPoint(_touch.position);
#endif
        _isCutting = true;
    }
}
