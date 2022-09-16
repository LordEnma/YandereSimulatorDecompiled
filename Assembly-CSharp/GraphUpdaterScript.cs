// Decompiled with JetBrains decompiler
// Type: GraphUpdaterScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GraphUpdaterScript : MonoBehaviour
{
  public AstarPath Graph;
  public int Frames;

  private void Update()
  {
    if (this.Frames > 0)
    {
      this.Graph.Scan();
      Object.Destroy((Object) this);
    }
    ++this.Frames;
  }
}
