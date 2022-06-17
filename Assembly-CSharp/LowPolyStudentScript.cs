// Decompiled with JetBrains decompiler
// Type: LowPolyStudentScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LowPolyStudentScript : MonoBehaviour
{
  public StudentScript Student;
  public Renderer TeacherMesh;
  public Renderer MyMesh;

  private void Start()
  {
    if (!((Object) this.Student.StudentManager == (Object) null) && !this.Student.Cosmetic.Kidnapped)
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
        if (!((Object) this.Student.EightiesTeacherAttacher != (Object) null) || !this.Student.EightiesTeacherAttacher.activeInHierarchy || this.Student.StudentID == 90)
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
