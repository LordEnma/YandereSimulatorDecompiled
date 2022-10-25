// Decompiled with JetBrains decompiler
// Type: StringScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class StringScript : MonoBehaviour
{
  public Transform Origin;
  public Transform Target;
  public Transform String;
  public int ArrayID;

  private void Start()
  {
    if (this.ArrayID != -1)
      return;
    this.Target.position = this.Origin.position;
  }

  private void Update()
  {
    this.String.position = this.Origin.position;
    this.String.LookAt(this.Target);
    this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
  }
}
