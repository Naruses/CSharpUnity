using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Door _door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _door.Open();
    }
}
