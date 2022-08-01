// Decompiled with JetBrains decompiler
// Type: RetroAesthetics.CombineMeshes
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace RetroAesthetics
{
  [ExecuteInEditMode]
  public class CombineMeshes : MonoBehaviour
  {
    [InspectorButton("CombineButtonHandler")]
    public bool combineChildMeshes;

    private void CombineButtonHandler() => this.CombineChildMeshes();

    public virtual void CombineChildMeshes()
    {
      Vector3 position = this.transform.position;
      this.transform.position = Vector3.zero;
      MeshFilter[] componentsInChildren = this.GetComponentsInChildren<MeshFilter>();
      CombineInstance[] combine = new CombineInstance[componentsInChildren.Length];
      Material material = (Material) null;
      for (int index = 0; index < componentsInChildren.Length; ++index)
      {
        combine[index].mesh = componentsInChildren[index].sharedMesh;
        combine[index].transform = componentsInChildren[index].transform.localToWorldMatrix;
        Renderer component = componentsInChildren[index].gameObject.GetComponent<Renderer>();
        if ((Object) component != (Object) null)
          component.enabled = false;
        if ((Object) material == (Object) null && (Object) component.sharedMaterial != (Object) null)
          material = component.sharedMaterial;
      }
      MeshFilter meshFilter = this.GetComponent<MeshFilter>();
      if ((Object) meshFilter == (Object) null)
        meshFilter = this.gameObject.AddComponent<MeshFilter>();
      meshFilter.mesh = new Mesh();
      meshFilter.sharedMesh.CombineMeshes(combine, true, true);
      if ((Object) this.GetComponent<MeshRenderer>() == (Object) null)
        this.gameObject.AddComponent<MeshRenderer>().sharedMaterial = material;
      this.transform.position = position;
    }
  }
}
