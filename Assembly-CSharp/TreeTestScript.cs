// Decompiled with JetBrains decompiler
// Type: TreeTestScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TreeTestScript : MonoBehaviour
{
  public QualityManagerScript QualityManager;
  public StudentManagerScript StudentManager;
  public GameObject[] Petals;
  public GameObject[] Trees;
  public int Command;
  public int PetalID;
  public int TreeID;
  public int Is;
  public int Us;
  public int Ys;
  public GameObject MinimapCamera;
  public CameraFilterPack_Color_BrightContrastSaturation Contrast;
  public CameraFilterPack_Color_GrayScale Gray;
  public CameraFilterPack_Color_RGB RGB;

  private void Update()
  {
    if (Input.GetKeyDown("y"))
    {
      ++this.Ys;
      if (this.Ys > 8)
      {
        if (this.Command == 0)
        {
          ++this.Command;
          foreach (GameObject gameObject in Object.FindObjectsOfType(typeof (GameObject)) as GameObject[])
          {
            if (gameObject.name == "BigTree" || gameObject.name == "SmallTree")
            {
              this.Trees[this.TreeID] = gameObject;
              ++this.TreeID;
            }
          }
        }
        else if (this.Command == 1)
        {
          OptionGlobals.ParticleCount = 1;
          this.QualityManager.UpdateParticles();
          ++this.Command;
          this.PetalID = 0;
          for (this.TreeID = 0; this.TreeID < this.Trees.Length; ++this.TreeID)
          {
            if ((Object) this.Trees[this.TreeID] != (Object) null)
              this.Trees[this.TreeID].SetActive(false);
          }
          for (; this.PetalID < this.Petals.Length; ++this.PetalID)
            this.Petals[this.PetalID].SetActive(false);
        }
        else if (this.Command == 2)
        {
          OptionGlobals.ParticleCount = 3;
          this.QualityManager.UpdateParticles();
          --this.Command;
          this.PetalID = 0;
          for (this.TreeID = 0; this.TreeID < this.Trees.Length; ++this.TreeID)
          {
            if ((Object) this.Trees[this.TreeID] != (Object) null)
              this.Trees[this.TreeID].SetActive(true);
          }
          for (; this.PetalID < this.Petals.Length; ++this.PetalID)
            this.Petals[this.PetalID].SetActive(true);
        }
      }
    }
    if (!Input.GetKeyDown("i"))
      return;
    ++this.Is;
    if (this.Is == 10)
      this.StudentManager.MiniMapTest();
    else if (this.Is == 11)
    {
      if ((Object) this.Gray == (Object) null)
      {
        this.Gray = this.MinimapCamera.AddComponent<CameraFilterPack_Color_GrayScale>();
        this.RGB = this.MinimapCamera.AddComponent<CameraFilterPack_Color_RGB>();
        this.Contrast = this.MinimapCamera.AddComponent<CameraFilterPack_Color_BrightContrastSaturation>();
        this.RGB.ColorRGB = new Color(1f, 0.75f, 1f, 1f);
        this.Contrast.Brightness = 2f;
        this.Contrast.Saturation = 1f;
        this.Contrast.Contrast = 0.5f;
      }
      else
      {
        this.Gray.enabled = true;
        this.RGB.enabled = true;
        this.Contrast.enabled = true;
      }
    }
    else
    {
      if (this.Is != 12)
        return;
      this.StudentManager.MiniMap.SetActive(false);
      this.Gray.enabled = false;
      this.RGB.enabled = false;
      this.Contrast.enabled = false;
      this.Is = 9;
    }
  }
}
