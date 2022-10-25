// Decompiled with JetBrains decompiler
// Type: DrillScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DrillScript : MonoBehaviour
{
  private void LateUpdate() => this.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
}
