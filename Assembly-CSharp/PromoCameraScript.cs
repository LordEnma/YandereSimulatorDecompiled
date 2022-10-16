// Decompiled with JetBrains decompiler
// Type: PromoCameraScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PromoCameraScript : MonoBehaviour
{
  public PortraitChanScript PromoCharacter;
  public Vector3[] StartPositions;
  public Vector3[] StartRotations;
  public Renderer PromoBlack;
  public Renderer Noose;
  public Renderer Rope;
  public Camera MyCamera;
  public Transform Drills;
  public float Timer;
  public int ID;

  private void Start()
  {
    this.transform.eulerAngles = this.StartRotations[this.ID];
    this.transform.position = this.StartPositions[this.ID];
    this.PromoCharacter.gameObject.SetActive(false);
    this.PromoBlack.material.color = new Color(this.PromoBlack.material.color.r, this.PromoBlack.material.color.g, this.PromoBlack.material.color.b, 0.0f);
    this.Noose.material.color = new Color(this.Noose.material.color.r, this.Noose.material.color.g, this.Noose.material.color.b, 0.0f);
    this.Rope.material.color = new Color(this.Rope.material.color.r, this.Rope.material.color.g, this.Rope.material.color.b, 0.0f);
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space) && this.ID < 3)
    {
      ++this.ID;
      this.UpdatePosition();
    }
    if (this.ID == 0)
      this.transform.Translate(Vector3.back * (Time.deltaTime * 0.01f));
    else if (this.ID == 1)
      this.transform.Translate(Vector3.back * (Time.deltaTime * 0.01f));
    else if (this.ID == 2)
    {
      this.transform.Translate(Vector3.forward * (Time.deltaTime * 0.01f));
      this.PromoCharacter.gameObject.SetActive(true);
    }
    else if (this.ID == 1 || this.ID == 3)
      this.transform.Translate(Vector3.back * (Time.deltaTime * 0.1f));
    this.Timer += Time.deltaTime;
    if ((double) this.Timer > 20.0)
    {
      this.Noose.material.color = new Color(this.Noose.material.color.r, this.Noose.material.color.g, this.Noose.material.color.b, this.Noose.material.color.a + Time.deltaTime * 0.2f);
      this.Rope.material.color = new Color(this.Rope.material.color.r, this.Rope.material.color.g, this.Rope.material.color.b, this.Rope.material.color.a + Time.deltaTime * 0.2f);
    }
    else if ((double) this.Timer > 15.0)
      this.PromoBlack.material.color = new Color(this.PromoBlack.material.color.r, this.PromoBlack.material.color.g, this.PromoBlack.material.color.b, this.PromoBlack.material.color.a + Time.deltaTime * 0.2f);
    if ((double) this.Timer > 10.0)
    {
      this.Drills.LookAt(this.Drills.position - Vector3.right);
      if (this.ID != 2)
        return;
      this.ID = 3;
      this.UpdatePosition();
    }
    else
    {
      if ((double) this.Timer <= 5.0)
        return;
      this.PromoCharacter.EyeShrink += Time.deltaTime * 0.1f;
      if (this.ID != 1)
        return;
      this.ID = 2;
      this.UpdatePosition();
    }
  }

  private void UpdatePosition()
  {
    this.transform.position = this.StartPositions[this.ID];
    this.transform.eulerAngles = this.StartRotations[this.ID];
    if (this.ID == 2)
    {
      this.MyCamera.farClipPlane = 3f;
      this.Timer = 5f;
    }
    if (this.ID != 3)
      return;
    this.MyCamera.farClipPlane = 5f;
    this.Timer = 10f;
  }
}
