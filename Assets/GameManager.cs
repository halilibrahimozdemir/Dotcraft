using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
using System;
public class GameManager : MonoBehaviour
{
    [Serializable]
    public class SavedObject
    {
        public Vector2 circlePos;
        public Color color;
    }
    [Serializable]
    public class SavedObjects
    {
        public List<SavedObject> savedObjects;
    }

    private void Awake()
    {
      
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
     
    }
   
    public void Save()
    {
        int i = 0;
        GameObject go = GameObject.Find("GridHolder");
        SavedObjects circles = new SavedObjects();
        circles.savedObjects = new List<SavedObject>();

        foreach (Transform child in go.transform)
        {

            SavedObject savedObject = new SavedObject();

            float x = child.position.x;
            float y = child.position.y;
            Vector2 vec = new Vector2(x, y);
            Color color = child.gameObject.GetComponent<SpriteRenderer>().color;

            savedObject.circlePos = vec;
            savedObject.color = color;

            circles.savedObjects.Add(savedObject);

            i = i + 1;
         
        }
        string json = JsonUtility.ToJson(circles);

        File.WriteAllText(Application.dataPath + "/save.txt", json);
        
    }//endsave


}//endfile

   
   

