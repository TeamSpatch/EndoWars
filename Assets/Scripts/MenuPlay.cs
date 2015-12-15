using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuPlay : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown) {
            SceneManager.LoadScene("arena");
        }
    }
}
