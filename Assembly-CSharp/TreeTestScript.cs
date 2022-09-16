// Decompiled with JetBrains decompiler
// Type: TreeTestScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TreeTestScript : MonoBehaviour
{
  public QualityManagerScript QualityManager;
  public GameObject[] Petals;
  public GameObject[] Trees;
  public int Command;
  public int PetalID;
  public int TreeID;
  public int Ys;

  private void Update()
  {
    if (!Input.GetKeyDown("y"))
      return;
    ++this.Ys;
    if (this.Ys <= 8)
      return;
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
    else
    {
      if (this.Command != 2)
        return;
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
