// Decompiled with JetBrains decompiler
// Type: BlendShapeRemover
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BlendShapeRemover : MonoBehaviour
{
  public SkinnedMeshRenderer SelectedMesh;

  private void Awake()
  {
    if (SystemInfo.supportsComputeShaders)
      return;
    this.SelectedMesh.sharedMesh.ClearBlendShapes();
  }
}
