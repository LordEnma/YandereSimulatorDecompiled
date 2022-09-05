// Decompiled with JetBrains decompiler
// Type: PathfindingTestScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PathfindingTestScript : MonoBehaviour
{
  private byte[] bytes;

  private void Update()
  {
    if (Input.GetKeyDown("left"))
      this.bytes = AstarPath.active.astarData.SerializeGraphs();
    if (!Input.GetKeyDown("right"))
      return;
    AstarPath.active.astarData.DeserializeGraphs(this.bytes);
    AstarPath.active.Scan();
  }
}
