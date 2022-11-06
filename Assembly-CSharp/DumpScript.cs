// Decompiled with JetBrains decompiler
// Type: DumpScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
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
