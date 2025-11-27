using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Grids<T> : MonoBehaviour
{
    int row=25;//行
    int column=26;//列
    float Uwidth=3.4f;
    float Uheight=6.8f;
    T[,] gridArray;
    TextMesh[,] debugTextArray;
    public Grids(int row,int col,T type){
        this.row = row;
        this.column = col;

        gridArray = new T[col,row];
        debugTextArray = new TextMesh[col, row];
        for (int x = 0; x < col; x++)
        {
            for (int y = 0; y < row; y++)
            {
                /*Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, Mathf.Infinity);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, Mathf.Infinity);*/

                /*debugTextArray[x,y]= Utils.CreatWorldText(default(T).ToString(), null, GetWorldPosition(x + 0.5f, y + 0.5f) + new Vector2(0, 1), 10, Color.black);
                Utils.CreatWorldText(x + "," + y,null,GetWorldPosition(x+0.5f,y+0.5f)-new Vector2(0,1),10,Color.black);*/

                
                Utils.CreatWorldText(x + "," + y, null, GetWorldPosition(x, y), 10, Color.black);//打印坐标

            }
        }
/*        Debug.DrawLine(GetWorldPosition(0, row), GetWorldPosition(col, row), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(col, 0), GetWorldPosition(col, row), Color.white, 100f);*/

    }
    public Vector2 GetWorldPosition(float x, float y) {
        return new Vector2(x * Uwidth, y * Uheight); 
    }



    public void GetCurGridXY(out int x,out int y) {
        var pos=Utils.GetMouseWorldPosition();
        x = Mathf.FloorToInt(pos.x / Uwidth);
        y = Mathf.FloorToInt(pos.y / Uheight);
    }
    public void SetGridValue(T t) {

        int x,y;
        GetCurGridXY(out x,out y);
        if (x < column && y < row && x >= 0 && y >= 0)
        {
            gridArray[x, y] = t;
            debugTextArray[x, y].text = t.ToString();
            Debug.LogFormat("{0},{1}", x,y);
        }
        else {
            Debug.Log("XY超出给定格数范围,无法设置");
        }

    }


    
}
