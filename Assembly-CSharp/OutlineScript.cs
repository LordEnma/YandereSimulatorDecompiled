// Decompiled with JetBrains decompiler
// Type: OutlineScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
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
