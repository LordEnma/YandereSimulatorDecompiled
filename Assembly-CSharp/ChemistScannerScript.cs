// Decompiled with JetBrains decompiler
// Type: ChemistScannerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ChemistScannerScript : MonoBehaviour
{
  public StudentScript Student;
  public Renderer MyRenderer;
  public Texture AlarmedEyes;
  public Texture DeadEyes;
  public Texture SadEyes;
  public Texture[] Textures;
  public float Timer;
  public int PreviousID;
  public int ID;

  private void Update()
  {
    if ((Object) this.Student.Ragdoll != (Object) null && this.Student.Ragdoll.enabled)
    {
      this.MyRenderer.materials[1].mainTexture = this.DeadEyes;
      this.enabled = false;
    }
    else if (this.Student.Dying)
    {
      if (!((Object) this.MyRenderer.materials[1].mainTexture != (Object) this.AlarmedEyes))
        return;
      this.MyRenderer.materials[1].mainTexture = this.AlarmedEyes;
    }
    else if (this.Student.Emetic || this.Student.Lethal || this.Student.Tranquil || this.Student.Headache)
    {
      if (!((Object) this.MyRenderer.materials[1].mainTexture != (Object) this.Textures[6]))
        return;
      this.MyRenderer.materials[1].mainTexture = this.Textures[6];
    }
    else if (this.Student.Grudge)
    {
      if (!((Object) this.MyRenderer.materials[1].mainTexture != (Object) this.Textures[1]))
        return;
      this.MyRenderer.materials[1].mainTexture = this.Textures[1];
    }
    else if (this.Student.LostTeacherTrust)
    {
      if (!((Object) this.MyRenderer.materials[1].mainTexture != (Object) this.SadEyes))
        return;
      this.MyRenderer.materials[1].mainTexture = this.SadEyes;
    }
    else if (this.Student.WitnessedMurder || this.Student.WitnessedCorpse)
    {
      if (!((Object) this.MyRenderer.materials[1].mainTexture != (Object) this.AlarmedEyes))
        return;
      this.MyRenderer.materials[1].mainTexture = this.AlarmedEyes;
    }
    else
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 2.0)
        return;
      while (this.ID == this.PreviousID)
        this.ID = Random.Range(0, this.Textures.Length);
      this.MyRenderer.materials[1].mainTexture = this.Textures[this.ID];
      this.PreviousID = this.ID;
      this.Timer = 0.0f;
    }
  }
}
