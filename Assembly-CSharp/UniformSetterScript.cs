// Decompiled with JetBrains decompiler
// Type: UniformSetterScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class UniformSetterScript : MonoBehaviour
{
  public Texture[] FemaleUniformTextures;
  public Texture[] MaleUniformTextures;
  public SkinnedMeshRenderer MyRenderer;
  public Mesh[] FemaleUniforms;
  public Mesh[] MaleUniforms;
  public Texture SenpaiFace;
  public Texture SenpaiSkin;
  public Texture RyobaFace;
  public Texture AyanoFace;
  public Texture OsanaFace;
  public int FaceID;
  public int SkinID;
  public int UniformID;
  public int StudentID;
  public bool AttachHair;
  public bool Male;
  public Transform Head;
  public GameObject[] Hair;
  public int HairID;
  public int ForceUniform;

  public void Start()
  {
    if ((Object) this.MyRenderer == (Object) null)
      this.MyRenderer = this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>();
    if (this.Male)
      this.SetMaleUniform();
    else
      this.SetFemaleUniform();
    if (!this.AttachHair)
      return;
    GameObject gameObject = Object.Instantiate<GameObject>(this.Hair[this.HairID], this.transform.position, this.transform.rotation);
    this.Head = this.transform.Find("Character/PelvisRoot/Hips/Spine/Spine1/Spine2/Spine3/Neck/Head").transform;
    gameObject.transform.parent = this.Head;
  }

  public void SetMaleUniform()
  {
    int index = StudentGlobals.MaleUniform;
    if (this.ForceUniform > 0)
      index = this.ForceUniform;
    this.MyRenderer.sharedMesh = this.MaleUniforms[index];
    switch (index)
    {
      case 1:
        this.SkinID = 0;
        this.UniformID = 1;
        this.FaceID = 2;
        break;
      case 2:
      case 3:
        this.UniformID = 0;
        this.FaceID = 1;
        this.SkinID = 2;
        break;
      case 4:
      case 5:
      case 6:
        this.FaceID = 0;
        this.SkinID = 1;
        this.UniformID = 2;
        break;
    }
    this.MyRenderer.materials[this.FaceID].mainTexture = this.SenpaiFace;
    this.MyRenderer.materials[this.SkinID].mainTexture = this.SenpaiSkin;
    this.MyRenderer.materials[this.UniformID].mainTexture = this.MaleUniformTextures[index];
  }

  public void SetFemaleUniform()
  {
    int index = StudentGlobals.FemaleUniform;
    if (this.ForceUniform > 0)
      index = this.ForceUniform;
    this.MyRenderer.sharedMesh = this.FemaleUniforms[index];
    this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[index];
    this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[index];
    if (this.StudentID == 0)
      this.MyRenderer.materials[2].mainTexture = this.RyobaFace;
    else if (this.StudentID == 1)
      this.MyRenderer.materials[2].mainTexture = this.AyanoFace;
    else
      this.MyRenderer.materials[2].mainTexture = this.OsanaFace;
  }
}
