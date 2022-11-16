// Decompiled with JetBrains decompiler
// Type: GrassMaskGenerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof (Camera))]
public class GrassMaskGenerator : MonoBehaviour
{
  [SerializeField]
  private float aspectWidth;
  [SerializeField]
  private float aspectHeight;
  [SerializeField]
  private float mapScale;
  [SerializeField]
  private int mapUpscale;
  private Camera camera;
  private RenderTexture targetTexture;

  public void Start() => Object.Destroy((Object) this.gameObject);

  private void Update()
  {
    if ((Object) this.camera == (Object) null)
      this.camera = this.GetComponent<Camera>();
    this.aspectWidth = Mathf.Clamp(this.aspectWidth, 1f, (float) int.MaxValue);
    this.aspectHeight = Mathf.Clamp(this.aspectHeight, 1f, (float) int.MaxValue);
    this.mapUpscale = Mathf.Clamp(this.mapUpscale, 1, 1000);
    if ((Object) this.targetTexture == (Object) null || (double) this.targetTexture.width != (double) this.aspectWidth * (double) this.mapUpscale || (double) this.targetTexture.height != (double) this.aspectHeight * (double) this.mapUpscale)
    {
      if ((Object) this.targetTexture != (Object) null)
        this.targetTexture.Release();
      this.targetTexture = new RenderTexture(Mathf.RoundToInt(this.aspectWidth) * this.mapUpscale, Mathf.RoundToInt(this.aspectHeight) * this.mapUpscale, 1);
    }
    this.camera.enabled = false;
    this.camera.farClipPlane = 0.1f;
    this.camera.orthographic = true;
    this.camera.orthographicSize = this.mapScale;
    this.camera.targetTexture = this.targetTexture;
  }

  [ContextMenu("Generate and save the grass occlusion map")]
  public void GenerateMap()
  {
    this.GetComponent<Camera>().Render();
    if ((Object) this.targetTexture == (Object) null || (double) this.targetTexture.width != (double) this.aspectWidth * (double) this.mapUpscale || (double) this.targetTexture.height != (double) this.aspectHeight * (double) this.mapUpscale)
    {
      if ((Object) this.targetTexture != (Object) null)
        this.targetTexture.Release();
      this.targetTexture = new RenderTexture(Mathf.RoundToInt(this.aspectWidth) * this.mapUpscale, Mathf.RoundToInt(this.aspectHeight) * this.mapUpscale, 1);
    }
    RenderTexture active = RenderTexture.active;
    RenderTexture.active = this.targetTexture;
    Texture2D texture2D = new Texture2D(this.targetTexture.width, this.targetTexture.height);
    texture2D.ReadPixels(new Rect(0.0f, 0.0f, (float) this.targetTexture.width, (float) this.targetTexture.height), 0, 0);
    RenderTexture.active = active;
    List<Vector3> vector3List = new List<Vector3>();
    List<int> intList = new List<int>();
    int num = 0;
    for (int x = 0; x < texture2D.width; ++x)
    {
      for (int index = 0; index < texture2D.height; ++index)
      {
        if ((double) texture2D.GetPixel(x, index).a == 0.0)
        {
          Vector3 vector3 = new Vector3((float) x, 0.0f, (float) index) / 3f;
          vector3List.Add(new Vector3(0.0f, 0.0f, 0.0f) + vector3);
          vector3List.Add(new Vector3(0.0f, 0.0f, 1f) + vector3);
          vector3List.Add(new Vector3(1f, 0.0f, 1f) + vector3);
          vector3List.Add(new Vector3(1f, 0.0f, 0.0f) + vector3);
          intList.Add(num);
          intList.Add(num + 1);
          intList.Add(num + 2);
          intList.Add(num);
          intList.Add(num + 2);
          intList.Add(num + 3);
          num += 4;
        }
      }
    }
    Mesh mesh = new Mesh();
    mesh.subMeshCount = 1;
    mesh.SetVertices(vector3List);
    mesh.SetIndices(intList.ToArray(), MeshTopology.Triangles, 0);
    mesh.RecalculateNormals();
    new GameObject("GrassMesh")
    {
      transform = {
        position = this.transform.position
      }
    }.AddComponent<MeshRenderer>().gameObject.AddComponent<MeshFilter>().mesh = mesh;
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.yellow;
    Matrix4x4 matrix = Gizmos.matrix;
    Gizmos.matrix = Matrix4x4.TRS(this.transform.position, this.transform.rotation, Vector3.one);
    Gizmos.DrawWireCube(new Vector3(0.0f, 0.0f, (float) (((double) this.camera.farClipPlane + (double) this.camera.nearClipPlane) * 0.5)), new Vector3(this.camera.orthographicSize * 2f * this.camera.aspect, this.camera.orthographicSize * 2f, this.camera.farClipPlane - this.camera.nearClipPlane));
  }
}
