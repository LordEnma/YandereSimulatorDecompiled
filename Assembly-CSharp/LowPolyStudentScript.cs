// Decompiled with JetBrains decompiler
// Type: LowPolyStudentScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LowPolyStudentScript : MonoBehaviour
{
  public StudentScript Student;
  public Renderer TeacherMesh;
  public Renderer MyMesh;

  private void Start()
  {
    if (!((Object) this.Student.StudentManager == (Object) null) && !this.Student.Cosmetic.Kidnapped && this.Student.StudentID != 1)
      return;
    this.enabled = false;
  }

  private void Update()
  {
    if ((Object) this.Student.StudentManager != (Object) null && (double) this.Student.StudentManager.LowDetailThreshold > 0.0)
    {
      if ((double) this.Student.Prompt.DistanceSqr > (double) this.Student.StudentManager.LowDetailThreshold)
      {
        if (this.MyMesh.enabled)
          return;
        this.Student.MyRenderer.enabled = false;
        this.MyMesh.enabled = true;
      }
      else
      {
        if (!this.MyMesh.enabled)
          return;
        this.Student.MyRenderer.enabled = true;
        this.MyMesh.enabled = false;
      }
    }
    else
    {
      if (!this.MyMesh.enabled)
        return;
      this.Student.MyRenderer.enabled = true;
      this.MyMesh.enabled = false;
    }
  }
}
