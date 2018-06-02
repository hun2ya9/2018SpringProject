using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public Transform cube;
    public string name = "";

    public int score = 0;

    void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 125, 25), "Save"))
        {
            SaveStuff();
        }

        if (GUI.Button(new Rect(100, 140, 125, 25), "Load"))
        {
            LoadStuff();
        }

        if (GUI.Button(new Rect(100, 180, 125, 25), "Increase score"))
        {
            score++;
        }

        if (GUI.Button(new Rect(100, 220, 125, 25), "Decrease score"))
        {
            score--;
        }

        if (GUI.Button(new Rect(100, 260, 125, 25), "Wipe Save"))
        {
            DeleteSaveData();
        }

        name = GUI.TextField(new Rect(300, 200, 125, 25), name, 25);

        GUI.Label(new Rect(300, 100, 125, 25), "Score " + score);
    }

    void SaveStuff()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetString("Name", name);
        PlayerPrefs.SetFloat("CubePosX", cube.position.x);
        PlayerPrefs.SetFloat("CubePosY", cube.position.y);
        PlayerPrefs.SetFloat("CubePosZ", cube.position.z);
    }

    void LoadStuff()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        name = PlayerPrefs.GetString("Name", "");
        cube.position = new Vector3(PlayerPrefs.GetFloat("CubePosX"), PlayerPrefs.GetFloat("CubePosY"), PlayerPrefs.GetFloat("CubePosZ"));
    }

    void DeleteSaveData()
    {
        PlayerPrefs.DeleteAll();
    }
}
