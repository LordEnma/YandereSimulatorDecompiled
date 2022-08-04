// Decompiled with JetBrains decompiler
// Type: AnswerSheetScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class AnswerSheetScript : MonoBehaviour
{
  public SchemesScript Schemes;
  public DoorGapScript DoorGap;
  public PromptScript Prompt;
  public ClockScript Clock;
  public Mesh OriginalMesh;
  public MeshFilter MyMesh;
  public int Phase = 1;

  private void Start()
  {
    this.OriginalMesh = this.MyMesh.mesh;
    if (DateGlobals.Weekday == DayOfWeek.Friday)
      return;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    if (this.Phase == 1)
    {
      SchemeGlobals.SetSchemeStage(5, 5);
      this.Schemes.UpdateInstructions();
      this.Prompt.Yandere.Inventory.AnswerSheet = true;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.DoorGap.Prompt.enabled = true;
      this.MyMesh.mesh = (Mesh) null;
      ++this.Phase;
    }
    else
    {
      SchemeGlobals.SetSchemeStage(5, 8);
      this.Schemes.UpdateInstructions();
      this.Prompt.Yandere.Inventory.AnswerSheet = false;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.MyMesh.mesh = this.OriginalMesh;
      ++this.Phase;
    }
  }
}
