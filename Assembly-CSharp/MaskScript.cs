// Decompiled with JetBrains decompiler
// Type: MaskScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MaskScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public ClubManagerScript ClubManager;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public PickUpScript PickUp;
  public Projector Blood;
  public Renderer MyRenderer;
  public MeshFilter MyFilter;
  public Texture[] Textures;
  public Mesh[] Meshes;
  public int ID;

  private void Start()
  {
    if (GameGlobals.MasksBanned)
    {
      this.gameObject.SetActive(false);
    }
    else
    {
      this.MyFilter.mesh = this.Meshes[this.ID];
      this.MyRenderer.material.mainTexture = this.Textures[this.ID];
    }
    this.enabled = false;
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    this.StudentManager.CanAnyoneSeeYandere();
    if (!this.StudentManager.YandereVisible && !this.Yandere.Chased && this.Yandere.Chasers == 0)
    {
      Rigidbody component = this.GetComponent<Rigidbody>();
      component.useGravity = false;
      component.isKinematic = true;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Prompt.MyCollider.enabled = false;
      this.transform.parent = this.Yandere.Head;
      this.transform.localPosition = new Vector3(0.0f, 0.033333f, 0.1f);
      this.transform.localEulerAngles = Vector3.zero;
      this.Yandere.Mask = this;
      this.ClubManager.UpdateMasks();
      this.StudentManager.UpdateStudents();
    }
    else
    {
      this.Yandere.NotificationManager.CustomText = "Not now. Too suspicious.";
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    }
  }

  public void Drop()
  {
    this.Prompt.MyCollider.isTrigger = false;
    this.Prompt.MyCollider.enabled = true;
    Rigidbody component = this.GetComponent<Rigidbody>();
    component.useGravity = true;
    component.isKinematic = false;
    this.Prompt.enabled = true;
    this.transform.parent = (Transform) null;
    this.Yandere.Mask = (MaskScript) null;
    this.ClubManager.UpdateMasks();
    this.StudentManager.UpdateStudents();
  }
}
