// Decompiled with JetBrains decompiler
// Type: PhoneCharmScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PhoneCharmScript : MonoBehaviour
{
  private void Update() => this.transform.eulerAngles = new Vector3(90f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
}
