// Decompiled with JetBrains decompiler
// Type: CountdownScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CountdownScript : MonoBehaviour
{
  public UISprite Sprite;
  public float Speed = 0.05f;
  public bool MaskedPhoto;

  private void Update() => this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0.0f, Time.deltaTime * this.Speed);
}
