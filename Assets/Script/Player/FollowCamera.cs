using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Vector3 offset;
    [SerializeField] GameObject character;

    private void Start()
    {
        offset = transform.position - character.transform.position;
    }
    
    void LateUpdate()
    {
        Vector3 targetPosition = character.transform.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
