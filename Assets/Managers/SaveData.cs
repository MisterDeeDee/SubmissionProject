using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveData 
{
    public static string path;


    public static void SaveGameData()
    {
        //String that contains our file path
        path = Application.persistentDataPath + "/savedata.json";

        //Create or save data
        Data dataToSave = new Data();
        dataToSave.record = GameManager.GameManagerObject.recordScore;

        string saveFile = JsonUtility.ToJson(dataToSave);

        //If file doesnt exit -> create one
        if(!File.Exists(path))
        {
            File.Create(path);
        }

        StreamWriter writer = new StreamWriter(path);
        writer.Write(saveFile);
        writer.Close();

    } 

    public static void LoadData()
    {
        path = Application.persistentDataPath + "/savedata.json";
        Debug.Log("Save data:" + path);
        if(File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            string file = reader.ReadToEnd();
            Data dataToLoad = JsonUtility.FromJson<Data>(file);
            if (dataToLoad != null)
            {
                GameManager.GameManagerObject.recordScore = dataToLoad.record;
            }
            reader.Close();
        }
        else
        {
            Debug.Log("No file to be loaded");
        }
    }

}

public class Data
{
    public int record;
}
