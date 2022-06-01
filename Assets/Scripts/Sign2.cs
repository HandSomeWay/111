using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sign2 : MonoBehaviour
{
    public GameObject cube;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground") cube.gameObject.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground") cube.gameObject.SetActive(true);
    }
}
