// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.Meter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  public class Meter : MonoBehaviour
  {
    public SpriteRenderer fillBar;
    public float emptyPos;
    private float startPos;

    private void Awake() => this.startPos = this.fillBar.transform.localPosition.x;

    public void SetFill(float interpolater) => this.fillBar.transform.localPosition = new Vector3(Mathf.Round(Mathf.Lerp(this.emptyPos, this.startPos, interpolater) * 50f) / 50f, 0.0f, 0.0f);
  }
}
