// Decompiled with JetBrains decompiler
// Type: GraphUpdaterScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
