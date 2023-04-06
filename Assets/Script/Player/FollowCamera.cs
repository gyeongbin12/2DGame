using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Vector3 offset;
    [SerializeField] GameObject character;

    [SerializeField] Vector2 minCameraBoundary;
    [SerializeField] Vector2 maxCameraBoundary;

    private void Start()
    {
        offset = transform.position - character.transform.position;
    }
    
    void FixedUpdate()
    {
      
            Vector3 targetPosition = new Vector3         
            (
                character.transform.position.x,
                character.transform.position.y,
                this.transform.position.z
            );

        targetPosition.x = Mathf.Clamp(targetPosition.x, minCameraBoundary.x, maxCameraBoundary.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minCameraBoundary.y, maxCameraBoundary.y);

        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
