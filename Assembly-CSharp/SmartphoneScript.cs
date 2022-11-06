// Decompiled with JetBrains decompiler
// Type: SmartphoneScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SmartphoneScript : MonoBehaviour
{
  public Transform PhoneCrushingSpot;
  public GameObject EmptyGameObject;
  public Texture SmashedTexture;
  public GameObject PhoneSmash;
  public Renderer MyRenderer;
  public PromptScript Prompt;
  public MeshFilter MyMesh;
  public Mesh SmashedMesh;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    if (this.Prompt.Yandere.Dragging || this.Prompt.Yandere.Carrying)
      this.Prompt.Yandere.EmptyHands();
    this.Prompt.Yandere.CrushingPhone = true;
    this.Prompt.Yandere.PhoneToCrush = this;
    this.Prompt.Yandere.CanMove = false;
    this.PhoneCrushingSpot = Object.Instantiate<GameObject>(this.EmptyGameObject, this.transform.position, Quaternion.identity).transform;
    this.PhoneCrushingSpot.position = new Vector3(this.PhoneCrushingSpot.position.x, this.Prompt.Yandere.transform.position.y, this.PhoneCrushingSpot.position.z);
    this.PhoneCrushingSpot.LookAt(this.Prompt.Yandere.transform.position);
    this.PhoneCrushingSpot.Translate(Vector3.forward * 0.5f);
  }
}
