using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TerrainScript : MonoBehaviour
{
    public int leftBorderX = -50;
    public int offsetY = 5;
    public int MapLength;
    private SpriteShapeController spriteCtrl;
    private int[] eegData;

    // Start is called before the first frame update
    void Start()
    {
        SlotData slotData = SaveManager.slotDataScene;
        Debug.Log(slotData.mapData.ToArray().ToString());
        int length = MapLength;
        eegData = slotData.mapData.ToArray();
        Debug.Log(slotData.title);
        if (eegData[0] == 0)
        {
           // createTestData();
        }
        spriteCtrl = this.GetComponent<SpriteShapeController>();
        CreateShape();
    }

    void createTestData()
    {
        Debug.Log("Test Data inserted");

        for(int i = 0; i < eegData.Length; i++)
        {
            eegData[i] = 0;
        }
    }

    void CreateShape()
    {
        spriteCtrl.spline.Clear();
        spriteCtrl.spline.InsertPointAt(0, new Vector3(leftBorderX, offsetY-25, 0)); //bottom left corner
        spriteCtrl.spline.SetTangentMode(0, ShapeTangentMode.Continuous);
        spriteCtrl.spline.SetLeftTangent(0, new Vector3(-0.3f, 0, 0));
        spriteCtrl.spline.SetRightTangent(0, new Vector3(0.3f, 0, 0));
        for (int i = 0; i < eegData.Length; i++)
        {  
            spriteCtrl.spline.InsertPointAt(i, new Vector3(leftBorderX + i, offsetY + eegData[i], 0));
            spriteCtrl.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            spriteCtrl.spline.SetLeftTangent(i, new Vector3(-0.3f, 0, 0));
            spriteCtrl.spline.SetRightTangent(i, new Vector3(0.3f, 0, 0));
        }
        spriteCtrl.spline.InsertPointAt(eegData.Length, new Vector3(leftBorderX+eegData.Length, -25, 0)); //bottom right corner
        spriteCtrl.spline.SetTangentMode(eegData.Length, ShapeTangentMode.Continuous);
        spriteCtrl.spline.SetLeftTangent(eegData.Length, new Vector3(-0.3f, 0, 0));
        spriteCtrl.spline.SetRightTangent(eegData.Length, new Vector3(0.3f, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}