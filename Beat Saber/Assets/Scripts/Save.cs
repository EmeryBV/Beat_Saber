
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
public class Save
{
    public static void save()
    {
        if (File.Exists(Application.persistentDataPath 
                        + "/MySaveData.dat"))
            File.Delete(Application.persistentDataPath 
                        + "/MySaveData.dat");

        BinaryFormatter bf = new BinaryFormatter(); 
        FileStream file = File.Create(Application.persistentDataPath 
                                      + "/MySaveData.dat"); 
        Debug.Log(Application.persistentDataPath 
                  + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.scores = gameData.scores;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
        foreach( int i in gameData.scores )
            Debug.Log( "Score save = " + i );

    }
    
    public static void load()
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
            Debug.Log(data.scores);
            gameData.scores = data.scores;
            // Debug.Log( gameData.score );
            
            Debug.Log("taille "+gameData.scores.Count);
            Debug.Log( gameData.score );
            for (int i = 0; i < gameData.scores.Count; i++)
            {
                Debug.Log( gameData.scores[i] );
            }
                
        }
        else
            Debug.LogError("There is no save data!");
    }
    
}
