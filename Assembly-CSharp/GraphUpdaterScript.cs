// Decompiled with JetBrains decompiler
// Type: GraphUpdaterScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
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
