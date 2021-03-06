using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame(PlayerData playerData)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = SaveDataPersistentPath();
        FileStream fs = new FileStream(path, FileMode.Create);
        var saveData = new SaveData(playerData);
        
        formatter.Serialize(fs, saveData);
        fs.Close();
    }

    public static SaveData LoadGame()
    {
        Debug.LogWarning("Bypassing save file for first release, without a way to reset progress Forest level got lost permanently once completed");
        /*string path = SaveDataPersistentPath();

        if (File.Exists(path)) // bypass loading, no way to reset so losing forest level once passed
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            SaveData saveData = formatter.Deserialize(fs) as SaveData;
            fs.Close();

            return saveData;
        }*/

        return new SaveData();
    }

    private static string SaveDataPersistentPath()
    {
        return Application.persistentDataPath + "/save.yes";
    }
}
