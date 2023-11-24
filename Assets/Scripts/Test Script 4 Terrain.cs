using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TestScript4Terrain : MonoBehaviour
{

    private SpriteShapeController spriteCtrl;

    // Start is called before the first frame update
    void Start()
    {
        spriteCtrl = this.GetComponent<SpriteShapeController>();
        CreateShape();
    }

    void CreateShape()
    {
        spriteCtrl.spline.Clear();
        spriteCtrl.spline.InsertPointAt(0, new Vector3(-1, -25, 0)); //bottom left corner
        spriteCtrl.spline.SetTangentMode(0, ShapeTangentMode.Continuous);
        spriteCtrl.spline.SetLeftTangent(0, new Vector3(-0.3f, 0, 0));
        spriteCtrl.spline.SetRightTangent(0, new Vector3(0.3f, 0, 0));
        spriteCtrl.spline.InsertPointAt(1, new Vector3(-1, 0, 0)); //top left corner
        spriteCtrl.spline.SetTangentMode(1, ShapeTangentMode.Continuous);
        spriteCtrl.spline.SetLeftTangent(1, new Vector3(-0.3f, 0, 0));
        spriteCtrl.spline.SetRightTangent(1, new Vector3(0.3f, 0, 0));
        for (int i = 2; i < 102; i++)
        {  
            spriteCtrl.spline.InsertPointAt(i, new Vector3(i-2, Random.Range(-1f, 1f), 0));
            spriteCtrl.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            spriteCtrl.spline.SetLeftTangent(i, new Vector3(-0.3f, 0, 0));
            spriteCtrl.spline.SetRightTangent(i, new Vector3(0.3f, 0, 0));
        }

        spriteCtrl.spline.InsertPointAt(102, new Vector3(102, 0, 0)); //top right corner
        spriteCtrl.spline.SetTangentMode(102, ShapeTangentMode.Continuous);
        spriteCtrl.spline.SetLeftTangent(102, new Vector3(0.3f, 0, 0));
        spriteCtrl.spline.SetRightTangent(102, new Vector3(0.3f, 0, 0));
        spriteCtrl.spline.InsertPointAt(103, new Vector3(102, -25, 0)); //bottom right corner
        spriteCtrl.spline.SetTangentMode(103, ShapeTangentMode.Continuous);
        spriteCtrl.spline.SetLeftTangent(103, new Vector3(0.3f, 0, 0));
        spriteCtrl.spline.SetRightTangent(103, new Vector3(0.3f, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
