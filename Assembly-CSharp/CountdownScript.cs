// Decompiled with JetBrains decompiler
// Type: CountdownScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CountdownScript : MonoBehaviour
{
  public UISprite Sprite;
  public float Speed = 0.05f;
  public bool MaskedPhoto;

  private void Update() => this.Sprite.fillAmount = Mathf.MoveTowards(this.Sprite.fillAmount, 0.0f, Time.deltaTime * this.Speed);
}
