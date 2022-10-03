// Decompiled with JetBrains decompiler
// Type: TreeTestScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
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
  public int Us;
  public int Ys;

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
    if (!Input.GetKeyDown("u"))
      return;
    ++this.Us;
    if (this.Us <= 9)
      return;
    this.StudentManager.LookAtTest();
  }
}
