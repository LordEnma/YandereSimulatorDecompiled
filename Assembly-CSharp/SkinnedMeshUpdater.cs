// Decompiled with JetBrains decompiler
// Type: SkinnedMeshUpdater
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class SkinnedMeshUpdater : MonoBehaviour
{
  public SkinnedMeshRenderer MyRenderer;
  public GameObject TransformEffect;
  public GameObject[] Characters;
  public PromptScript Prompt;
  public GameObject BreastR;
  public GameObject BreastL;
  public GameObject FumiGlasses;
  public GameObject NinaGlasses;
  private SkinnedMeshRenderer TempRenderer;
  public Texture[] Bodies;
  public Texture[] Faces;
  public float Timer;
  public int ID;

  public void Start() => this.GlassesCheck();

  public void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      UnityEngine.Object.Instantiate<GameObject>(this.TransformEffect, this.Prompt.Yandere.Hips.position, Quaternion.identity);
      this.Prompt.Yandere.CharacterAnimation.Play(this.Prompt.Yandere.IdleAnim);
      this.Prompt.Yandere.CanMove = false;
      this.Prompt.Yandere.Egg = true;
      this.BreastR.name = "RightBreast";
      this.BreastL.name = "LeftBreast";
      this.Timer = 1f;
      ++this.ID;
      if (this.ID == this.Characters.Length)
        this.ID = 1;
      this.Prompt.Yandere.Hairstyle = 120 + this.ID;
      this.Prompt.Yandere.UpdateHair();
      this.GlassesCheck();
      this.UpdateSkin();
    }
    if ((double) this.Timer <= 0.0)
      return;
    this.Timer = Mathf.MoveTowards(this.Timer, 0.0f, Time.deltaTime);
    if ((double) this.Timer != 0.0)
      return;
    this.Prompt.Yandere.CanMove = true;
  }

  public void UpdateSkin()
  {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Characters[this.ID], Vector3.zero, Quaternion.identity);
    this.TempRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
    this.UpdateMeshRenderer(this.TempRenderer);
    UnityEngine.Object.Destroy((UnityEngine.Object) gameObject);
    this.MyRenderer.materials[0].mainTexture = this.Bodies[this.ID];
    this.MyRenderer.materials[1].mainTexture = this.Bodies[this.ID];
    this.MyRenderer.materials[2].mainTexture = this.Faces[this.ID];
  }

  private void UpdateMeshRenderer(SkinnedMeshRenderer newMeshRenderer)
  {
    SkinnedMeshRenderer renderer = this.Prompt.Yandere.MyRenderer;
    renderer.sharedMesh = newMeshRenderer.sharedMesh;
    Transform[] componentsInChildren = this.Prompt.Yandere.transform.GetComponentsInChildren<Transform>(true);
    Transform[] transformArray = new Transform[newMeshRenderer.bones.Length];
    for (int boneOrder = 0; boneOrder < newMeshRenderer.bones.Length; boneOrder++)
      transformArray[boneOrder] = Array.Find<Transform>(componentsInChildren, (Predicate<Transform>) (c => c.name == newMeshRenderer.bones[boneOrder].name));
    renderer.bones = transformArray;
  }

  private void GlassesCheck()
  {
    this.FumiGlasses.SetActive(false);
    this.NinaGlasses.SetActive(false);
    if (this.ID == 7)
    {
      this.FumiGlasses.SetActive(true);
    }
    else
    {
      if (this.ID != 8)
        return;
      this.NinaGlasses.SetActive(true);
    }
  }
}
