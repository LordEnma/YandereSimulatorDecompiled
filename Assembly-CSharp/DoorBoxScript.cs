// Decompiled with JetBrains decompiler
// Type: DoorBoxScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DoorBoxScript : MonoBehaviour
{
  public UILabel Label;
  public bool Show;

  private void Update() => this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.Lerp(this.transform.localPosition.y, this.Show ? -530f : -630f, Time.deltaTime * 10f), this.transform.localPosition.z);
}
