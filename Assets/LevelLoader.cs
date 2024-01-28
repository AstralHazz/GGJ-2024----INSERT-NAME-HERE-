using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    public bool collided = false;
    private void OnTriggerEnter(Collider other)
    {
        if (collided == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            collided = true;
            Debug.Log("Trigger Works!");
        }
    }
}
