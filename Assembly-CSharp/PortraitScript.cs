// Decompiled with JetBrains decompiler
// Type: PortraitScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PortraitScript : MonoBehaviour
{
  public GameObject[] StudentObject;
  public Renderer Renderer1;
  public Renderer Renderer2;
  public Renderer Renderer3;
  public Texture[] HairSet1;
  public Texture[] HairSet2;
  public Texture[] HairSet3;
  public int Selected;
  public int CurrentHair;

  private void Start()
  {
    this.StudentObject[1].SetActive(false);
    this.StudentObject[2].SetActive(false);
    this.Selected = 1;
    this.UpdateHair();
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      this.StudentObject[0].SetActive(true);
      this.StudentObject[1].SetActive(false);
      this.StudentObject[2].SetActive(false);
      this.Selected = 1;
    }
    else if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      this.StudentObject[0].SetActive(false);
      this.StudentObject[1].SetActive(true);
      this.StudentObject[2].SetActive(false);
      this.Selected = 2;
    }
    else if (Input.GetKeyDown(KeyCode.Alpha3))
    {
      this.StudentObject[0].SetActive(false);
      this.StudentObject[1].SetActive(false);
      this.StudentObject[2].SetActive(true);
      this.Selected = 3;
    }
    if (!Input.GetKeyDown(KeyCode.Space))
      return;
    ++this.CurrentHair;
    if (this.CurrentHair > this.HairSet1.Length - 1)
      this.CurrentHair = 0;
    this.UpdateHair();
  }

  private void UpdateHair()
  {
    Texture texture = this.HairSet2[this.CurrentHair];
    this.Renderer1.materials[0].mainTexture = texture;
    this.Renderer1.materials[3].mainTexture = texture;
    this.Renderer2.materials[2].mainTexture = texture;
    this.Renderer2.materials[3].mainTexture = texture;
    this.Renderer3.materials[0].mainTexture = texture;
    this.Renderer3.materials[1].mainTexture = texture;
  }
}
