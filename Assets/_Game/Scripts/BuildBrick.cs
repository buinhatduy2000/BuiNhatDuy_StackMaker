using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBrick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UnBrick")
        {
            other.gameObject.tag = "Untagged";
            //CharacterMovement.Instance.PickBrich(other.gameObject);
            CharacterMovement.Instance.DropBrick();
            this.transform.SetParent(other.transform);
            this.transform.localPosition = Vector3.zero;
            Destroy(this);
        }

        if (other.tag == "WinPos")
        {
            CharacterMovement.Instance.rb.velocity = Vector3.zero;
        }
    }
}
