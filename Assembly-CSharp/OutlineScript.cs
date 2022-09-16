// Decompiled with JetBrains decompiler
// Type: OutlineScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using HighlightingSystem;
using UnityEngine;

public class OutlineScript : MonoBehaviour
{
  public YandereScript Yandere;
  public Highlighter h;
  public Color color = new Color(1f, 1f, 1f, 1f);

  public void Awake()
  {
    this.h = this.GetComponent<Highlighter>();
    if (!((Object) this.h == (Object) null))
      return;
    this.h = this.gameObject.AddComponent<Highlighter>();
  }

  private void Update() => this.h.ConstantOnImmediate(this.color);
}
