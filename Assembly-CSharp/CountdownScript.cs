// Decompiled with JetBrains decompiler
// Type: CountdownScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CountdownScript : MonoBehaviour
{
  public UISprite Sprite;
  public float Speed = 0.05f;
  public bool MaskedPhoto;

  private void Update() => this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0.0f, Time.deltaTime * this.Speed);
}
