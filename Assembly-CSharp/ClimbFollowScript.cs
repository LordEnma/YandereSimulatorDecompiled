// Decompiled with JetBrains decompiler
// Type: ClimbFollowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ClimbFollowScript : MonoBehaviour
{
  public Transform Yandere;

  private void Update() => this.transform.position = new Vector3(this.transform.position.x, this.Yandere.position.y, this.transform.position.z);
}
