// Decompiled with JetBrains decompiler
// Type: Rotator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Rotator : MonoBehaviour
{
  public float speed = 15f;

  private void Update() => this.transform.Rotate(0.0f, this.speed * Time.deltaTime, 0.0f);
}
