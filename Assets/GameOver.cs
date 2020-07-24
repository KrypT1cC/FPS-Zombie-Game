using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string name;
    public PlayerHealth script;

    // Start is called before the first frame update
    void Start()
    {
        script = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(script.currentHealth <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(name);
        }
    }
}
