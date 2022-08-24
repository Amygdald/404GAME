using UnityEditor;
using UnityEngine;
//扩展InspectorEditorTest类在Inspector面板的显示内容
[CustomEditor(typeof(Move))]
public class InspectorEditor : Editor
{
    //重写OnInspectorGUI类(刷新Inspector面板)
    public override void OnInspectorGUI()
    {
        //继承基类方法
        base.OnInspectorGUI();
        //获取要执行方法的类
        Move targetScript = (Move)target;
        //绘制Button
        if (GUILayout.Button("SetEndPos"))
        {
            //执行方法
            targetScript.SetEndPos();
        }
    }
}

