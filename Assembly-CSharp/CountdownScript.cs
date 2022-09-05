// Decompiled with JetBrains decompiler
// Type: CountdownScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CountdownScript : MonoBehaviour
{
  public UISprite Sprite;
  public float Speed = 0.05f;
  public bool MaskedPhoto;

  private void Update() => this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0.0f, Time.deltaTime * this.Speed);
}
