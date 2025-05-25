using System;
using System.IO;
using UnityEngine;

namespace ZENGAME.Core
{
    public static class SaveSystem
    {
        private const string saveName = "ZENGAME_data";

        public static void SaveData(SaveData saveData)
        {
            var saveFilePath = Path.Combine(Application.persistentDataPath, $"{saveName}.json");
            
            string json = JsonUtility.ToJson(saveData, true);
            File.WriteAllText(saveFilePath, json);
        }

        public static SaveData LoadData()
        {
            var saveFilePath = Path.Combine(Application.persistentDataPath, $"{saveName}.json");
            
            if (File.Exists(saveFilePath))
            {
                try
                {
                    string json = File.ReadAllText(saveFilePath);
                    SaveData loadedData = JsonUtility.FromJson<SaveData>(json);
                    return loadedData;
                }
                catch (Exception e)
                {
                    return InitSaveData();
                }
            }
            else
            {
                return InitSaveData();
            }
        }
        
        private static SaveData InitSaveData()
        {
            var saveData = new SaveData();
            SaveData(saveData);
                        
            return saveData;
        }
    }
    
    [Serializable]
    public class SaveData
    {
        public float bestScore = 0;
    }
}