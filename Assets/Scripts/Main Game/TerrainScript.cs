using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TerrainScript : MonoBehaviour
{
    public int leftBorderX = -50;
    public int offsetY = 5;
    public int MapLength;
    public int stretchData = 20;
    private SpriteShapeController spriteCtrl;
    private int[] eegData;

    // Start is called before the first frame update
    void Start()
    {
        SlotData slotData = SaveManager.slotDataScene;
        Debug.Log(slotData.mapData.ToArray().ToString());
        int length = eegData.Length * stretchData;
        MapLength = length;
        eegData = slotData.mapData.ToArray();
        Debug.Log(slotData.title);
        spriteCtrl = this.GetComponent<SpriteShapeController>();
        CreateShape();
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
            spriteCtrl.spline.InsertPointAt(i * stretchData, new Vector3(leftBorderX + i, offsetY + eegData[i], 0));
            spriteCtrl.spline.SetTangentMode(i * stretchData, ShapeTangentMode.Continuous);
            spriteCtrl.spline.SetLeftTangent(i * stretchData, new Vector3(-0.3f, 0, 0));
            spriteCtrl.spline.SetRightTangent(i * stretchData, new Vector3(0.3f, 0, 0));
        }
        spriteCtrl.spline.InsertPointAt(eegData.Length * stretchData, new Vector3(leftBorderX+eegData.Length, -25, 0)); //bottom right corner
        spriteCtrl.spline.SetTangentMode(eegData.Length * stretchData, ShapeTangentMode.Continuous);
        spriteCtrl.spline.SetLeftTangent(eegData.Length * stretchData, new Vector3(-0.3f, 0, 0));
        spriteCtrl.spline.SetRightTangent(eegData.Length * stretchData, new Vector3(0.3f, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
