using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using SmartDLL;

public class file_manager : MonoBehaviour
{
    string path;
    string textFromFile;
    public GameObject popupPanel;
    public SmartFileExplorer fileExplorer = new SmartFileExplorer();


    // Start is called before the first frame update
  void Start()
    {
	
	
    }


    public void OpenExplorer(){
            string initialDir = @"C:\";
            bool restoreDir = true;
            string title = "Open a Text File";
            string defExt = "txt";
            string filter = "txt files (*.txt)|*.txt";

            fileExplorer.OpenExplorer(initialDir,restoreDir,title,defExt,filter);
            //path = EditorUtility.OpenFilePanel("Overwrite with txt","","txt");
            path = fileExplorer.fileName;
            popupPanel.SetActive(false);
    }
    string GetFile(){
        if(path != null){
               textFromFile= System.IO.File.ReadAllText(path);
                Debug.Log(textFromFile);
               
        }
         return textFromFile;
    }
    public void SendToCsvReader(){
         if(path != null){
               PlayerPrefs.SetString("granulometrie",GetFile());
        SceneManager.LoadScene("SampleScene");
        }else{
            popupPanel.SetActive(true);
        }
    }

}
