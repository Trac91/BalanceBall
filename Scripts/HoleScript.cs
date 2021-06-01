using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BallControlScript.setIsDeadTrue();
    }
}
