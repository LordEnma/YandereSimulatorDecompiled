// Decompiled with JetBrains decompiler
// Type: DebugConsole
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class DebugConsole : MonoBehaviour
{
  private List<DebugMessage> logs = new List<DebugMessage>();
  private Texture2D BackgroundTex;

  private void OnEnable() => Application.logMessageReceived += new Application.LogCallback(this.captureLog);

  private void OnDisable() => Application.logMessageReceived += new Application.LogCallback(this.captureLog);

  private void Start()
  {
    this.BackgroundTex = Texture2D.blackTexture;
    Texture2D backgroundTex = this.BackgroundTex;
    for (int x = 0; x < backgroundTex.width; ++x)
    {
      for (int y = 0; y < backgroundTex.height; ++y)
      {
        Color pixel = backgroundTex.GetPixel(x, y) with
        {
          a = 0.5f
        };
        backgroundTex.SetPixel(x, y, pixel);
      }
    }
    backgroundTex.Apply();
    this.BackgroundTex = backgroundTex;
  }

  private void captureLog(string condition, string stackTrace, LogType type)
  {
    this.logs.Add(new DebugMessage()
    {
      messageType = type,
      content = condition
    });
    if (this.logs.Count <= 30)
      return;
    this.logs.RemoveAt(0);
  }

  private void OnGUI()
  {
    GUI.Label(new Rect(10f, 0.0f, (float) Screen.width / 3f, (float) (15 * this.logs.Count)), string.Empty, new GUIStyle()
    {
      normal = {
        background = this.BackgroundTex
      }
    });
    for (int index = 0; index < this.logs.Count; ++index)
    {
      GUIStyle style = new GUIStyle();
      switch (this.logs[index].messageType)
      {
        case LogType.Error:
          style.normal.textColor = Color.red;
          break;
        case LogType.Warning:
          style.normal.textColor = Color.yellow;
          break;
        case LogType.Exception:
          style.normal.textColor = Color.red;
          break;
        default:
          style.normal.textColor = Color.white;
          break;
      }
      GUI.Label(new Rect(10f, (float) (15 * index), (float) Screen.width / 3f, 25f), this.logs[index].content, style);
    }
  }
}
