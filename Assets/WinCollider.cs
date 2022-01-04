using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCollider : MonoBehaviour
{
    public int SceneToLoad;
    void OnTriggerEnter(Collider other)
    {
        if ("Player".Equals(other.tag))
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}