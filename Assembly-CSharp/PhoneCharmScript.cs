// Decompiled with JetBrains decompiler
// Type: PhoneCharmScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PhoneCharmScript : MonoBehaviour
{
  private void Update() => this.transform.eulerAngles = new Vector3(90f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
}
