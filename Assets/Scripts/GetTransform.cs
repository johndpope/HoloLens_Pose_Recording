﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GetTransform : MonoBehaviour {



    public int count;
    public float Tx, Ty, Tz, Rx, Ry, Rz;
    
    

 
    // Use this for initialization
    void Start () {

      
    }

    // Update is called once per frame
    void Update () {
     /***   Transform trnfrm = Camera.main.transform;
        Tx = trnfrm.position.x;
        Ty = trnfrm.position.y;
        Tz = trnfrm.position.z;
        Rx = trnfrm.rotation.eulerAngles.x;
        Ry = trnfrm.rotation.eulerAngles.y;
        Rz = trnfrm.rotation.eulerAngles.z;
        string jsonTransform = JsonUtility.ToJson(this, true);

        string path = Application.persistentDataPath + "/HoloData" + "Holo.json";
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(jsonTransform.ToString());
        }
        ***/

        // File.WriteAllText(Application.dataPath + "Holo.json", jsonTransform.ToString());
    }
    
#if UNITY_UWP
    public void OnClick()
    {
        int count = GetComponent<ClickInput>().count;
        Transform trnfrm = Camera.main.transform;
        Tx = trnfrm.position.x;
        Ty = trnfrm.position.y;
        Tz = trnfrm.position.z;
        Rx = trnfrm.rotation.eulerAngles.x;
        Ry = trnfrm.rotation.eulerAngles.y;
        Rz = trnfrm.rotation.eulerAngles.z;
        string jsonTransform = JsonUtility.ToJson(this, true);
        

        Debug.Log("Start Saving!");
       // string path = Application.persistentDataPath + "/HoloData" + "Holo.json";
        //   using (StreamWriter writer = new StreamWriter(path, true))
        //   {
        //        writer.WriteLine(jsonTransform.ToString());
        //   }
        File.WriteAllText(Application.persistentDataPath + "/HoloData" + count.ToString()+ ".json", jsonTransform.ToString());

        //    writer.Close();
        Debug.Log("Saving Done!");
        var cameraRollFolder = Windows.Storage.KnownFolders.CameraRoll.Path;
     //   Debug.Log("Camera Folder Path: " + cameraRollFolder);
        var newpath = Path.Combine(cameraRollFolder, "HoloData" + count.ToString() + ".json");
     //   Debug.Log("New File Path: " + newpath);
        File.Move(Application.persistentDataPath + "/HoloData" + count.ToString() + ".json", newpath);
        Debug.Log("Success!");
        File.Delete(Application.persistentDataPath + "/HoloData" + count.ToString() + ".json");
    }
#endif
}