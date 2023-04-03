using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    static public void Flip(Vector2 direction, SpriteRenderer spriteRenderer, bool condition)
    {
        if (direction.x > 0)
        {
            spriteRenderer.flipX = condition;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = !condition;
        }
    }
}
