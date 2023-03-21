using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WinPos")
        {
            CharacterMovement.Instance.rb.velocity = Vector3.zero;
        }
    }
}
