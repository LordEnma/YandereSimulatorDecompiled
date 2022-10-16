// Decompiled with JetBrains decompiler
// Type: GraphUpdaterScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
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
