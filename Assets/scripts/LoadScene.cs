using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject logic;
    public GameObject music;

    void Start()
    {
        if (logic == null)
        {

            logic = GameObject.FindGameObjectWithTag("Logic");
        }
        if (music == null)
        {
            music = GameObject.FindGameObjectWithTag("Music");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit the application
            Application.Quit();

            // This line ensures the exit command works in the Unity Editor (for testing purposes)
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }

        public void LoadToScene(int id)
    {

        SceneManager.LoadScene(id);
        DontDestroyOnLoad(logic);
        if (music != null)
        {
            DontDestroyOnLoad(music);
        }
    }
}
