using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField] Vector3 offset;
    [SerializeField] GameObject character;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();

        offset = transform.position - character.transform.position;
    }
    
    void LateUpdate()
    {
        transform.position = character.transform.position + offset;
    }
}
