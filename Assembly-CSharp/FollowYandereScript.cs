// Decompiled with JetBrains decompiler
// Type: FollowYandereScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FollowYandereScript : MonoBehaviour
{
  public Transform Yandere;

  private void Update() => this.transform.position = new Vector3(this.Yandere.position.x, this.transform.position.y, this.Yandere.position.z);
}
