// Decompiled with JetBrains decompiler
// Type: DumpScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
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
