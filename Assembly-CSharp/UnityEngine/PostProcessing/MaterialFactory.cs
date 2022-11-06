// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.MaterialFactory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace UnityEngine.PostProcessing
{
  public sealed class MaterialFactory : IDisposable
  {
    private Dictionary<string, Material> m_Materials;

    public MaterialFactory() => this.m_Materials = new Dictionary<string, Material>();

    public Material Get(string shaderName)
    {
      Material material1;
      if (!this.m_Materials.TryGetValue(shaderName, out material1))
      {
        Shader shader = Shader.Find(shaderName);
        Material material2 = !((UnityEngine.Object) shader == (UnityEngine.Object) null) ? new Material(shader) : throw new ArgumentException(string.Format("Shader not found ({0})", (object) shaderName));
        material2.name = string.Format("PostFX - {0}", (object) shaderName.Substring(shaderName.LastIndexOf("/") + 1));
        material2.hideFlags = HideFlags.DontSave;
        material1 = material2;
        this.m_Materials.Add(shaderName, material1);
      }
      return material1;
    }

    public void Dispose()
    {
      Dictionary<string, Material>.Enumerator enumerator = this.m_Materials.GetEnumerator();
      while (enumerator.MoveNext())
        GraphicsUtils.Destroy((UnityEngine.Object) enumerator.Current.Value);
      this.m_Materials.Clear();
    }
  }
}
