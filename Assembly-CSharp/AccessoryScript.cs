// Decompiled with JetBrains decompiler
// Type: AccessoryScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AccessoryScript : MonoBehaviour
{
  public PromptScript Prompt;
  public Transform Target;
  public float X;
  public float Y;
  public float Z;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.Prompt.MyCollider.enabled = false;
    this.transform.parent = this.Target;
    this.transform.localPosition = new Vector3(this.X, this.Y, this.Z);
    this.transform.localEulerAngles = Vector3.zero;
    this.enabled = false;
  }
}
