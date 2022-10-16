﻿// Decompiled with JetBrains decompiler
// Type: PhotographyClubScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PhotographyClubScript : MonoBehaviour
{
  public GameObject CrimeScene;
  public GameObject InvestigationPhotos;
  public GameObject ArtsyPhotos;
  public GameObject StraightTables;
  public GameObject CrookedTables;

  private void Start()
  {
    this.InvestigationPhotos.SetActive(false);
    this.ArtsyPhotos.SetActive(true);
    if ((double) SchoolGlobals.SchoolAtmosphere <= 0.800000011920929)
    {
      if (!GameGlobals.Eighties)
      {
        this.InvestigationPhotos.SetActive(true);
        this.ArtsyPhotos.SetActive(false);
      }
      this.CrimeScene.SetActive(true);
      this.StraightTables.SetActive(true);
      this.CrookedTables.SetActive(false);
    }
    else
    {
      this.CrimeScene.SetActive(false);
      this.StraightTables.SetActive(false);
      this.CrookedTables.SetActive(true);
    }
  }
}
