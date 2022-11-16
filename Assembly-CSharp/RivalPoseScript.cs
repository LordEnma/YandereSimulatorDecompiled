// Decompiled with JetBrains decompiler
// Type: RivalPoseScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RivalPoseScript : MonoBehaviour
{
  public GameObject Character;
  public SkinnedMeshRenderer MyRenderer;
  public Texture[] FemaleUniformTextures;
  public Mesh[] FemaleUniforms;
  public Texture[] TestTextures;
  public Texture HairTexture;
  public string[] AnimNames;
  public int ID = -1;

  private void Start()
  {
    int femaleUniform = StudentGlobals.FemaleUniform;
    this.MyRenderer.sharedMesh = this.FemaleUniforms[femaleUniform];
    switch (femaleUniform)
    {
      case 1:
        this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
        this.MyRenderer.materials[1].mainTexture = this.HairTexture;
        this.MyRenderer.materials[2].mainTexture = this.HairTexture;
        this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
        break;
      case 2:
        this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
        this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[femaleUniform];
        this.MyRenderer.materials[2].mainTexture = this.HairTexture;
        this.MyRenderer.materials[3].mainTexture = this.HairTexture;
        break;
      case 3:
        this.MyRenderer.materials[0].mainTexture = this.HairTexture;
        this.MyRenderer.materials[1].mainTexture = this.HairTexture;
        this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[femaleUniform];
        this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
        break;
      case 4:
        this.MyRenderer.materials[0].mainTexture = this.HairTexture;
        this.MyRenderer.materials[1].mainTexture = this.HairTexture;
        this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[femaleUniform];
        this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
        break;
      case 5:
        this.MyRenderer.materials[0].mainTexture = this.HairTexture;
        this.MyRenderer.materials[1].mainTexture = this.HairTexture;
        this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[femaleUniform];
        this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
        break;
      case 6:
        this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
        this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[femaleUniform];
        this.MyRenderer.materials[2].mainTexture = this.HairTexture;
        this.MyRenderer.materials[3].mainTexture = this.HairTexture;
        break;
    }
  }
}
