using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveByJson(string SaveFileName, object data)
    {
        var json = JsonUtility.ToJson(data); //��dataתΪjson
        var path = Path.Combine(Application.persistentDataPath, SaveFileName); //��Ҫд����ļ�·��������ļ��Ѿ����ڣ��ͻ�ֱ�Ӹ���
        //Application��һ�����ñ������ݵķ��������Ը��ݲ�ͬƽ̨��windows/��׿�ȣ��Զ�����ļ���ʽ
        
        try
        {
            File.WriteAllText(path, json); //��json�ļ�д��һ���ı��ļ���
            Debug.Log($"Successfully saved data to {path}.");
        }
        catch(System.Exception ex)
        {
            Debug.Log($"Failed to save data to {path}.");
        }
    }
    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine (Application.persistentDataPath, saveFileName);
       
        try
        {
            var json = File.ReadAllText(saveFileName);
            var data = JsonUtility.FromJson<T>(json);

            return data;
        }
        catch (System.Exception ex)
        {
            Debug.Log($"Failed to load data from {path}.");
            return default;
        }
    }
    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        
        try
        {
            File.Delete(path);
        }
        catch (System.Exception ex)
        {
            Debug.Log($"Failed to delete data from {path}.");
        }
    }
}
