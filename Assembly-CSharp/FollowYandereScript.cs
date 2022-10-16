// Decompiled with JetBrains decompiler
// Type: FollowYandereScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FollowYandereScript : MonoBehaviour
{
  public Transform Yandere;

  private void Update() => this.transform.position = new Vector3(this.Yandere.position.x, this.transform.position.y, this.Yandere.position.z);
}
