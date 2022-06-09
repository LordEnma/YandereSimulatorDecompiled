// Decompiled with JetBrains decompiler
// Type: DumpScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DumpScript : MonoBehaviour
{
  public SkinnedMeshRenderer MyRenderer;
  public IncineratorScript Incinerator;
  public float Timer;

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= 5.0)
      return;
    ++this.Incinerator.Corpses;
    Object.Destroy((Object) this.gameObject);
  }
}
