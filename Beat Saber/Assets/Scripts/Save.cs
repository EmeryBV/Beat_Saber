
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
class SaveData
{
    public List<int> scores;

}
public class Save : MonoBehaviour
{
    private void Awake()
    {
        load();
    }

    void save()
    {
        if (File.Exists(Application.persistentDataPath 
                        + "/MySaveData.dat"))
            File.Delete(Application.persistentDataPath 
                        + "/MySaveData.dat");

        BinaryFormatter bf = new BinaryFormatter(); 
        FileStream file = File.Create(Application.persistentDataPath 
                                      + "/MySaveData.dat"); 
        SaveData data = new SaveData();
        data.scores = gameData.scores;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
        foreach( int i in data.scores )
            Debug.Log( i );

    }
    
    void load()
    {
        if (File.Exists(Application.persistentDataPath 
                        + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
                File.Open(Application.persistentDataPath 
                          + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            gameData.scores = data.scores;
            Debug.Log("Game data loaded!");
            foreach( int i in gameData.scores )
                Debug.Log( i );
        }
        else
            Debug.LogError("There is no save data!");
    }
    
    
    private void OnApplicationQuit()
    {
        save();
    }
}
