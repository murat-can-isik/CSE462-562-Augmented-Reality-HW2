using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class CreateSphere : MonoBehaviour
{

    private GameObject s;
    private ArrayList myNodes;

    void Start()
    {
        myNodes = new ArrayList();
        FileInfo theSourceFile = new FileInfo("Assets/Resources/coordinates.txt");
        FileInfo theSourceFile2 = new FileInfo("Assets/Resources/coordinates2.txt");

        StreamReader reader = theSourceFile.OpenText();
        StreamReader reader2 = theSourceFile2.OpenText();
        string text;
        string text2;
        int redCount = 0;
        int blueCount = 0;
        do{
            text = reader.ReadLine();
            if(text != null){
                string[] strArr = text.Split(' ');
                float posx = float.Parse(strArr[0]);
                float posy = float.Parse(strArr[1]);
                float posz = float.Parse(strArr[2]);

                s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                s.transform.position = new Vector3 (posx, posy, posz);
                s.transform.localScale = new Vector3(0.3F,0.3F,0.3F); 
                var sphere = s.GetComponent<Renderer>();
                sphere.material.SetColor("_Color",Color.red);
                myNodes.Add(s);
                redCount += 1;
            }
        }while(text != null);

        do{
            text2 = reader2.ReadLine();
            if(text2 != null){
                string[] strArr = text2.Split(' ');
                float posx = float.Parse(strArr[0]);
                float posy = float.Parse(strArr[1]);
                float posz = float.Parse(strArr[2]);

                s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                s.transform.position = new Vector3 (posx, posy, posz);
                s.transform.localScale = new Vector3(0.3F,0.3F,0.3F); 
                var sphere = s.GetComponent<Renderer>();
                sphere.material.SetColor("_Color",Color.blue);
                myNodes.Add(s);
                blueCount += 1;
            }
        }while(text2 != null);
        print(redCount);
        print(blueCount);   
    }

    public void ransacOperation(){
        Debug.Log("Button pressed.");
    } 

    

}
