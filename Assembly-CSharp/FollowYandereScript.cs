// Decompiled with JetBrains decompiler
// Type: FollowYandereScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FollowYandereScript : MonoBehaviour
{
  public Transform Yandere;

  private void Update() => this.transform.position = new Vector3(this.Yandere.position.x, this.transform.position.y, this.Yandere.position.z);
}
