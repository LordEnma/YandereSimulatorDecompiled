// Decompiled with JetBrains decompiler
// Type: DumpScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
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
