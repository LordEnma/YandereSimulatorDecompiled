// Decompiled with JetBrains decompiler
// Type: UniformSwapperScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class UniformSwapperScript : MonoBehaviour
{
  public Texture[] UniformTextures;
  public Mesh[] UniformMeshes;
  public Texture FaceTexture;
  public SkinnedMeshRenderer MyRenderer;
  public int UniformID;
  public int FaceID;
  public int SkinID;
  public Transform LookTarget;
  public Transform Head;

  private void Start()
  {
    int maleUniform = StudentGlobals.MaleUniform;
    this.MyRenderer.sharedMesh = this.UniformMeshes[maleUniform];
    Texture uniformTexture = this.UniformTextures[maleUniform];
    switch (maleUniform)
    {
      case 1:
        this.SkinID = 0;
        this.UniformID = 1;
        this.FaceID = 2;
        break;
      case 2:
        this.UniformID = 0;
        this.FaceID = 1;
        this.SkinID = 2;
        break;
      case 3:
        this.UniformID = 0;
        this.FaceID = 1;
        this.SkinID = 2;
        break;
      case 4:
        this.FaceID = 0;
        this.SkinID = 1;
        this.UniformID = 2;
        break;
      case 5:
        this.FaceID = 0;
        this.SkinID = 1;
        this.UniformID = 2;
        break;
      case 6:
        this.FaceID = 0;
        this.SkinID = 1;
        this.UniformID = 2;
        break;
    }
    this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
    this.MyRenderer.materials[this.SkinID].mainTexture = uniformTexture;
    this.MyRenderer.materials[this.UniformID].mainTexture = uniformTexture;
  }

  private void LateUpdate()
  {
    if (!((Object) this.LookTarget != (Object) null))
      return;
    this.Head.LookAt(this.LookTarget);
  }
}
