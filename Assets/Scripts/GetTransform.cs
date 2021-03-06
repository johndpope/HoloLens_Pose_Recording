﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class GetTransform : MonoBehaviour {


    public Text txt;
    public int count;
    public float Tx, Ty, Tz, Rx, Ry, Rz;
   // private string num;
    
    

 
    // Use this for initialization
    void Start () {
      
    }

    // Update is called once per frame
    void Update () {

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
        

     //   Debug.Log("Start Saving!");
       // string path = Application.persistentDataPath + "/HoloData" + "Holo.json";
        //   using (StreamWriter writer = new StreamWriter(path, true))
        //   {
        //        writer.WriteLine(jsonTransform.ToString());
        //   }
        File.WriteAllText(Application.persistentDataPath + "/HoloData" + String.Format("_{0:000}.json", count), jsonTransform.ToString());

        //    writer.Close();
       // Debug.Log("Saving Done!");
        var cameraRollFolder = Windows.Storage.KnownFolders.CameraRoll.Path;
     //   Debug.Log("Camera Folder Path: " + cameraRollFolder);
        var newpath = Path.Combine(cameraRollFolder, "HoloData" + String.Format("_{0:000}.json", count));
     //   Debug.Log("New File Path: " + newpath);
        File.Move(Application.persistentDataPath + "/HoloData" + String.Format("_{0:000}.json", count), newpath);
        
        File.Delete(Application.persistentDataPath + "/HoloData" + String.Format("_{0:000}.json", count));
        Debug.Log("Success!");
        txt.text = "Pose Number: " + count;
        //   num = File.ReadAllText(cameraRollFolder + "/Matrix.txt");
        //   Debug.Log("Reading file: "+ num);

    }
#endif
}
