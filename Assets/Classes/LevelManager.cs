using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public static int currentLevel;
    public int levels;

    void Awake() {
        currentLevel = Application.loadedLevel;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            if (currentLevel < levels) 
            {
                currentLevel++;
                Application.LoadLevel(currentLevel);
            }
        }
        else if (Input.GetKeyDown(KeyCode.F11))
        {
            if (currentLevel > 1)
            {
                currentLevel--;
                Application.LoadLevel(currentLevel);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            if (currentLevel < levels)
            {
                Debug.Log("Level Up");
                currentLevel++;
                Application.LoadLevel(currentLevel);
            }
        }
    }
}
