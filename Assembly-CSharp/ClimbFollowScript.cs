// Decompiled with JetBrains decompiler
// Type: ClimbFollowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ClimbFollowScript : MonoBehaviour
{
  public Transform Yandere;

  private void Update() => this.transform.position = new Vector3(this.transform.position.x, this.Yandere.position.y, this.transform.position.z);
}
