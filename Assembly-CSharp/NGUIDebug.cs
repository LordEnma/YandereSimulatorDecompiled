// Decompiled with JetBrains decompiler
// Type: NGUIDebug
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Internal/Debug")]
public class NGUIDebug : MonoBehaviour
{
  private static bool mRayDebug = false;
  private static List<string> mLines = new List<string>();
  private static NGUIDebug mInstance = (NGUIDebug) null;

  public static bool debugRaycast
  {
    get => NGUIDebug.mRayDebug;
    set
    {
      NGUIDebug.mRayDebug = value;
      if (!value || !Application.isPlaying)
        return;
      NGUIDebug.CreateInstance();
    }
  }

  public static void CreateInstance()
  {
    if (!((Object) NGUIDebug.mInstance == (Object) null))
      return;
    GameObject target = new GameObject("_NGUI Debug");
    NGUIDebug.mInstance = target.AddComponent<NGUIDebug>();
    Object.DontDestroyOnLoad((Object) target);
  }

  private static void LogString(string text)
  {
    if (Application.isPlaying)
    {
      if (NGUIDebug.mLines.Count > 20)
        NGUIDebug.mLines.RemoveAt(0);
      NGUIDebug.mLines.Add(text);
      NGUIDebug.CreateInstance();
    }
    else
      Debug.Log((object) text);
  }

  public static void Log(params object[] objs)
  {
    string text = "";
    for (int index = 0; index < objs.Length; ++index)
      text = index != 0 ? text + ", " + objs[index].ToString() : text + objs[index].ToString();
    NGUIDebug.LogString(text);
  }

  public static void Log(string s)
  {
    if (string.IsNullOrEmpty(s))
      return;
    string str = s;
    char[] chArray = new char[1]{ '\n' };
    foreach (string text in str.Split(chArray))
      NGUIDebug.LogString(text);
  }

  public static void Clear() => NGUIDebug.mLines.Clear();

  public static void DrawBounds(Bounds b)
  {
    Vector3 center = b.center;
    Vector3 vector3_1 = b.center - b.extents;
    Vector3 vector3_2 = b.center + b.extents;
    Debug.DrawLine(new Vector3(vector3_1.x, vector3_1.y, center.z), new Vector3(vector3_2.x, vector3_1.y, center.z), Color.red);
    Debug.DrawLine(new Vector3(vector3_1.x, vector3_1.y, center.z), new Vector3(vector3_1.x, vector3_2.y, center.z), Color.red);
    Debug.DrawLine(new Vector3(vector3_2.x, vector3_1.y, center.z), new Vector3(vector3_2.x, vector3_2.y, center.z), Color.red);
    Debug.DrawLine(new Vector3(vector3_1.x, vector3_2.y, center.z), new Vector3(vector3_2.x, vector3_2.y, center.z), Color.red);
  }

  private void OnGUI()
  {
    Rect position = new Rect(5f, 5f, 1000f, 22f);
    if (NGUIDebug.mRayDebug)
    {
      string text1 = "Scheme: " + UICamera.currentScheme.ToString();
      GUI.color = Color.black;
      GUI.Label(position, text1);
      --position.y;
      --position.x;
      GUI.color = Color.white;
      GUI.Label(position, text1);
      position.y += 18f;
      ++position.x;
      string text2 = "Hover: " + NGUITools.GetHierarchy(UICamera.hoveredObject).Replace("\"", "");
      GUI.color = Color.black;
      GUI.Label(position, text2);
      --position.y;
      --position.x;
      GUI.color = Color.white;
      GUI.Label(position, text2);
      position.y += 18f;
      ++position.x;
      string text3 = "Selection: " + NGUITools.GetHierarchy(UICamera.selectedObject).Replace("\"", "");
      GUI.color = Color.black;
      GUI.Label(position, text3);
      --position.y;
      --position.x;
      GUI.color = Color.white;
      GUI.Label(position, text3);
      position.y += 18f;
      ++position.x;
      string text4 = "Controller: " + NGUITools.GetHierarchy(UICamera.controllerNavigationObject).Replace("\"", "");
      GUI.color = Color.black;
      GUI.Label(position, text4);
      --position.y;
      --position.x;
      GUI.color = Color.white;
      GUI.Label(position, text4);
      position.y += 18f;
      ++position.x;
      string text5 = "Active events: " + UICamera.CountInputSources().ToString();
      if (UICamera.disableController)
        text5 += ", disabled controller";
      if (UICamera.ignoreControllerInput)
        text5 += ", ignore controller";
      if (UICamera.inputHasFocus)
        text5 += ", input focus";
      GUI.color = Color.black;
      GUI.Label(position, text5);
      --position.y;
      --position.x;
      GUI.color = Color.white;
      GUI.Label(position, text5);
      position.y += 18f;
      ++position.x;
    }
    int index = 0;
    for (int count = NGUIDebug.mLines.Count; index < count; ++index)
    {
      GUI.color = Color.black;
      GUI.Label(position, NGUIDebug.mLines[index]);
      --position.y;
      --position.x;
      GUI.color = Color.white;
      GUI.Label(position, NGUIDebug.mLines[index]);
      position.y += 18f;
      ++position.x;
    }
  }
}
