﻿// Decompiled with JetBrains decompiler
// Type: HatredScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HatredScript : MonoBehaviour
{
  public DepthOfFieldScatter DepthOfField;
  public HomeDarknessScript HomeDarkness;
  public HomeCameraScript HomeCamera;
  public GrayscaleEffect Grayscale;
  public Bloom Bloom;
  public GameObject CrackPanel;
  public AudioSource Voiceover;
  public GameObject SenpaiPhoto;
  public GameObject RivalPhotos;
  public GameObject Character;
  public GameObject Panties;
  public GameObject Yandere;
  public GameObject Shrine;
  public Transform AntennaeR;
  public Transform AntennaeL;
  public Transform Corkboard;
  public UISprite CrackDarkness;
  public UISprite Darkness;
  public UITexture Crack;
  public UITexture Logo;
  public bool Begin;
  public float Timer;
  public int Phase;
  public Texture[] CrackTexture;

  private void Start() => this.Character.SetActive(false);
}