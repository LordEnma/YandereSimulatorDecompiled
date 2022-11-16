// Decompiled with JetBrains decompiler
// Type: ConsoleLogScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ConsoleLogScript : MonoBehaviour
{
  public DebugEnablerScript debug;
  private string myLog = "Debug Console Output:";
  private bool doShow;
  private bool Long;
  public int kChars = 700;
  private int enters;
  private int id;
  public string[] code;

  private void Start() => this.kChars = 2100;

  private void OnEnable() => Application.logMessageReceived += new Application.LogCallback(this.Log);

  private void OnDisable() => Application.logMessageReceived -= new Application.LogCallback(this.Log);

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.KeypadEnter))
    {
      ++this.enters;
      if (this.enters == 10)
      {
        this.doShow = true;
        this.Long = false;
      }
      else if (this.enters == 11)
      {
        this.doShow = true;
        this.Long = true;
      }
      else if (this.enters == 12)
      {
        this.doShow = false;
        this.enters = 9;
      }
    }
    if (this.id >= this.code.Length || !Input.GetKeyDown(this.code[this.id]))
      return;
    ++this.id;
    if (this.id != this.code.Length || !((Object) this.debug.gameObject != (Object) null))
      return;
    this.debug.EnableDebug();
  }

  public void Log(string logString, string stackTrace, LogType type)
  {
    this.myLog = this.myLog + "\n" + logString;
    if (this.myLog.Length <= this.kChars)
      return;
    this.myLog = this.myLog.Substring(this.myLog.Length - this.kChars);
  }

  private void OnGUI()
  {
    if (!this.doShow)
      return;
    if (this.Long)
    {
      GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float) Screen.width / 1280f, (float) Screen.height / 720f, 1f));
      GUI.TextArea(new Rect(0.0f, 0.0f, 426.6624f, (float) Screen.height), this.myLog);
    }
    else
    {
      GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float) Screen.width / 1280f, (float) Screen.height / 720f, 1f));
      GUI.TextArea(new Rect(0.0f, 479.9952f, 426.6624f, 239.9976f), this.myLog);
    }
  }
}
