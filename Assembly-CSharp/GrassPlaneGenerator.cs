// Decompiled with JetBrains decompiler
// Type: GrassPlaneGenerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GrassPlaneGenerator : MonoBehaviour
{
  public float Width = 10f;
  public float Height = 10f;
  public bool Intersect;
  public float IntersectHeight = 1f;
  public bool OffsetCorrection;
  public LayerMask IntersectLayers;
  [Range(0.1f, 10f)]
  public float quadSize = 0.1f;

  private void OnDrawGizmosSelected()
  {
    this.quadSize = Mathf.Clamp(this.quadSize, 0.1f, 10f);
    Vector3 position = this.transform.position;
    Vector3 size1 = new Vector3(this.Width, 0.0f, this.Height);
    Vector3 size2 = new Vector3(this.quadSize, 0.0f, this.quadSize);
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireCube(position, size1);
    if (this.Intersect)
    {
      Gizmos.color = new Color(0.5f, 0.5f, 1f, 0.5f);
      Gizmos.DrawCube(position + Vector3.up * this.IntersectHeight / 2f, size1 + Vector3.up * this.IntersectHeight);
    }
    Gizmos.color = Color.cyan;
    for (float x = 0.0f; (double) x < (double) this.Width + 0.090000003576278687 - (double) this.quadSize; x += this.quadSize)
    {
      for (float z = 0.0f; (double) z < (double) this.Height + 0.090000003576278687 - (double) this.quadSize; z += this.quadSize)
        Gizmos.DrawWireCube(position - size1 / 2f + size2 / 2f + new Vector3(x, 0.0f, z), size2);
    }
  }

  public void Bake()
  {
    List<Vector3> vector3List = new List<Vector3>();
    List<int> intList = new List<int>();
    Vector3 position = this.transform.position;
    Vector3 vector3_1 = new Vector3(this.Width, 0.0f, this.Height);
    Vector3 vector3_2 = new Vector3(this.quadSize, 0.0f, this.quadSize);
    int num1 = (int) ((double) this.Width / (double) this.quadSize);
    int num2 = (int) ((double) this.Height / (double) this.quadSize);
    float num3 = (float) num1 * this.quadSize;
    float num4 = (float) num2 * this.quadSize;
    float num5 = this.Width - num3;
    float num6 = this.Height - num4;
    Vector3 vector3_3 = new Vector3(this.Width / num3, 1f, this.Height / num4);
    Texture2D texture2D = (Texture2D) null;
    if (this.Intersect)
    {
      RenderTexture active = RenderTexture.active;
      Camera camera = new GameObject("Temporary Camera").AddComponent<Camera>();
      camera.transform.rotation = Quaternion.Euler(90f, 0.0f, 0.0f);
      camera.transform.position = position + Vector3.up * this.IntersectHeight;
      camera.orthographic = true;
      camera.aspect = this.Width / this.Height;
      camera.orthographicSize = this.Height / 2f;
      camera.nearClipPlane = 0.01f;
      camera.farClipPlane = this.IntersectHeight + 0.01f;
      camera.clearFlags = CameraClearFlags.Color;
      camera.backgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      camera.cullingMask = (int) this.IntersectLayers;
      RenderTexture renderTexture = new RenderTexture((int) this.Width * 100, (int) this.Height * 100, 1);
      camera.targetTexture = renderTexture;
      camera.forceIntoRenderTexture = true;
      RenderTexture.active = renderTexture;
      camera.Render();
      texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);
      texture2D.ReadPixels(new Rect(0.0f, 0.0f, (float) renderTexture.width, (float) renderTexture.height), 0, 0);
      texture2D.filterMode = FilterMode.Trilinear;
      texture2D.Apply();
      RenderTexture.active = active;
      Object.DestroyImmediate((Object) camera.gameObject);
    }
    int num7 = 0;
    for (float num8 = 0.0f; (double) num8 < (double) this.Width + 0.090000003576278687 - (double) this.quadSize; num8 += this.quadSize)
    {
      for (float num9 = 0.0f; (double) num9 < (double) this.Height + 0.090000003576278687 - (double) this.quadSize; num9 += this.quadSize)
      {
        if (this.Intersect)
        {
          float num10 = this.OffsetCorrection ? this.quadSize : 0.0f;
          float num11 = 0.0f;
          for (int index1 = -1; index1 < 2; ++index1)
          {
            for (int index2 = -1; index2 < 2; ++index2)
              num11 += texture2D.GetPixel((int) (((double) num8 + (double) num10) * 100.0 + (double) index1), (int) (((double) num9 + (double) num10) * 100.0 + (double) index2)).a;
          }
          if ((double) num11 != 0.0)
            continue;
        }
        Vector3 vector3_4 = new Vector3(num8 - this.Width / 2f, 0.0f, num9 - this.Height / 2f);
        vector3List.Add(new Vector3(0.0f, 0.0f, 0.0f) + vector3_4);
        vector3List.Add(new Vector3(0.0f, 0.0f, this.quadSize) + vector3_4);
        vector3List.Add(new Vector3(this.quadSize, 0.0f, this.quadSize) + vector3_4);
        vector3List.Add(new Vector3(this.quadSize, 0.0f, 0.0f) + vector3_4);
        intList.Add(num7);
        intList.Add(num7 + 1);
        intList.Add(num7 + 2);
        intList.Add(num7);
        intList.Add(num7 + 2);
        intList.Add(num7 + 3);
        num7 += 4;
      }
    }
    for (int index = 0; index < vector3List.Count; ++index)
    {
      Vector3 vector3_5 = vector3List[index];
      vector3_5.x *= vector3_3.x;
      vector3_5.z *= vector3_3.z;
      vector3_5.x += (float) ((double) num5 * (double) vector3_3.x / 2.0);
      vector3_5.z += (float) ((double) num6 * (double) vector3_3.z / 2.0);
      vector3List[index] = vector3_5;
    }
    Mesh mesh = new Mesh();
    mesh.indexFormat = IndexFormat.UInt32;
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
}
