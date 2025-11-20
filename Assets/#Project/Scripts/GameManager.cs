// Versionning : MAJOR BREAKING OLD VERSION. MAJOR CHANGE (new feture etc.).BUG MANAGING (format : 1.0.0)

using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // singleton
    public Vector3 objectPosition;
    public int score;

    private BinaryFormatter bf = new();
    private string savingPath;


    [Serializable]
    private class SaveData 
    {
        public Vector3 position;
        public int score;
    }


    private void Awake() // Awake = self initialisation -> internal 
    {
        savingPath = Application.persistentDataPath + "/save.dat";

        if (instance == null) // Is there already an instance of gameManager ?
        {
            DontDestroyOnLoad(gameObject); // Keeping the same object between scenes
            Load(); // Loading save 
            instance = this; // Instantiate the gameManager as one and only gameManager
        }
        else if (instance != this) // If so, destroy unnecessary gameManager
        {
            Destroy(gameObject);
        }
    }

    private void Start() // Start = codependencies etc. -> external
    {
        //DontDestroyOnLoad(gameObject);
    }

    // Save/Load

    public void Save()
    {
        //Create the file
        FileStream file = File.Create(savingPath);

        // Create data for the saving file
        SaveData saveData = new();
        saveData.position = objectPosition;
        saveData.score = score;

        // Serialization
        bf.Serialize(file, saveData);

        file.Close();
    }

    public void Load()
    {
        // If there is a saving file
        if (File.Exists(savingPath))
        {
            // Open & read the file
            FileStream file = File.OpenRead(savingPath);

            // Cast the result of deserialization of file into a SaveData object
            SaveData saveData = (SaveData)bf.Deserialize(file);

            file.Close();

            // Assigning the values to the SaveData object
            objectPosition = saveData.position;
            score = saveData.score;
        }
    }

    void OnApplicationQuit()
    {
        Save();
    }
}
