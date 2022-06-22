// Decompiled with JetBrains decompiler
// Type: HallucinationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HallucinationScript : MonoBehaviour
{
  public SkinnedMeshRenderer YandereHairRenderer;
  public SkinnedMeshRenderer YandereRenderer;
  public SkinnedMeshRenderer RivalHairRenderer;
  public SkinnedMeshRenderer RivalRenderer;
  public Animation YandereAnimation;
  public Animation RivalAnimation;
  public YandereScript Yandere;
  public Material Black;
  public bool Hallucinate;
  public float Alpha;
  public float Timer;
  public int Weapon;
  public Renderer[] WeaponRenderers;
  public Renderer SawRenderer;
  public GameObject[] Weapons;
  public string[] WeaponName;
  public GameObject[] EightiesRivalHair;
  public GameObject[] RivalHair;
  public GameObject RyobaHair;
  public SkinnedMeshRenderer RyobaHairRenderer;
  public Mesh LongSleeveUniform;

  private void Start()
  {
    this.YandereHairRenderer.material = this.Black;
    this.RivalHairRenderer.material = this.Black;
    this.YandereRenderer.materials[0] = this.Black;
    this.YandereRenderer.materials[1] = this.Black;
    this.YandereRenderer.materials[2] = this.Black;
    this.RivalRenderer.materials[0] = this.Black;
    this.RivalRenderer.materials[1] = this.Black;
    this.RivalRenderer.materials[2] = this.Black;
    foreach (Renderer weaponRenderer in this.WeaponRenderers)
    {
      if ((Object) weaponRenderer != (Object) null)
        weaponRenderer.material = this.Black;
    }
    this.SawRenderer.material = this.Black;
    this.MakeTransparent();
    for (int index = 1; index < 11; ++index)
      this.EightiesRivalHair[index].SetActive(false);
    if (GameGlobals.Eighties)
    {
      if (DateGlobals.Week <= 0 || DateGlobals.Week >= 11)
        return;
      this.YandereHairRenderer.transform.parent.gameObject.SetActive(false);
      this.RivalHair[1].SetActive(false);
      this.EightiesRivalHair[DateGlobals.Week].SetActive(true);
      this.YandereHairRenderer = this.RyobaHairRenderer;
      this.RivalHairRenderer = this.EightiesRivalHair[DateGlobals.Week].transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
      this.YandereRenderer.sharedMesh = this.LongSleeveUniform;
      this.RivalRenderer.sharedMesh = this.LongSleeveUniform;
    }
    else
      this.RyobaHair.SetActive(false);
  }

  private void Update()
  {
    if ((double) this.Yandere.Sanity < 33.3333282470703)
    {
      if (!this.Yandere.Aiming && this.Yandere.CanMove)
        this.Timer += Time.deltaTime;
      if ((double) this.Timer > 6.0)
      {
        this.Weapon = Random.Range(1, 6);
        this.transform.position = this.Yandere.transform.position + this.Yandere.transform.forward;
        this.transform.eulerAngles = this.Yandere.transform.eulerAngles;
        this.YandereAnimation["f02_" + this.WeaponName[this.Weapon] + "LowSanityA_00"].time = 0.0f;
        this.RivalAnimation["f02_" + this.WeaponName[this.Weapon] + "LowSanityB_00"].time = 0.0f;
        this.YandereAnimation.Play("f02_" + this.WeaponName[this.Weapon] + "LowSanityA_00");
        this.RivalAnimation.Play("f02_" + this.WeaponName[this.Weapon] + "LowSanityB_00");
        if (this.Weapon == 1)
          this.YandereAnimation.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        else if (this.Weapon == 5)
          this.YandereAnimation.transform.localPosition = new Vector3(-0.25f, 0.0f, 0.0f);
        else
          this.YandereAnimation.transform.localPosition = new Vector3(-0.5f, 0.0f, 0.0f);
        foreach (GameObject weapon in this.Weapons)
        {
          if ((Object) weapon != (Object) null)
            weapon.SetActive(false);
        }
        this.Weapons[this.Weapon].SetActive(true);
        this.Hallucinate = true;
        this.Timer = 0.0f;
      }
    }
    if (!this.Hallucinate)
      return;
    this.Alpha = (double) this.YandereAnimation["f02_" + this.WeaponName[this.Weapon] + "LowSanityA_00"].time >= 3.0 ? Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 0.33333f) : Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.33333f);
    this.YandereHairRenderer.material.SetFloat("_Alpha", this.Alpha);
    this.RivalHairRenderer.material.SetFloat("_Alpha", this.Alpha);
    this.YandereRenderer.materials[0].SetFloat("_Alpha", this.Alpha);
    this.YandereRenderer.materials[1].SetFloat("_Alpha", this.Alpha);
    this.YandereRenderer.materials[2].SetFloat("_Alpha", this.Alpha);
    this.RivalRenderer.materials[0].SetFloat("_Alpha", this.Alpha);
    this.RivalRenderer.materials[1].SetFloat("_Alpha", this.Alpha);
    this.RivalRenderer.materials[2].SetFloat("_Alpha", this.Alpha);
    foreach (Renderer weaponRenderer in this.WeaponRenderers)
    {
      if ((Object) weaponRenderer != (Object) null)
        weaponRenderer.material.SetFloat("_Alpha", this.Alpha);
    }
    this.SawRenderer.material.SetFloat("_Alpha", this.Alpha);
    if ((double) this.YandereAnimation["f02_" + this.WeaponName[this.Weapon] + "LowSanityA_00"].time != (double) this.YandereAnimation["f02_" + this.WeaponName[this.Weapon] + "LowSanityA_00"].length && !this.Yandere.Aiming)
      return;
    this.MakeTransparent();
    this.Hallucinate = false;
  }

  private void MakeTransparent()
  {
    this.Alpha = 0.0f;
    this.YandereHairRenderer.material.SetFloat("_Alpha", this.Alpha);
    this.RivalHairRenderer.material.SetFloat("_Alpha", this.Alpha);
    this.YandereRenderer.materials[0].SetFloat("_Alpha", this.Alpha);
    this.YandereRenderer.materials[1].SetFloat("_Alpha", this.Alpha);
    this.YandereRenderer.materials[2].SetFloat("_Alpha", this.Alpha);
    this.RivalRenderer.materials[0].SetFloat("_Alpha", this.Alpha);
    this.RivalRenderer.materials[1].SetFloat("_Alpha", this.Alpha);
    this.RivalRenderer.materials[2].SetFloat("_Alpha", this.Alpha);
    foreach (Renderer weaponRenderer in this.WeaponRenderers)
    {
      if ((Object) weaponRenderer != (Object) null)
        weaponRenderer.material.SetFloat("_Alpha", this.Alpha);
    }
    this.SawRenderer.material.SetFloat("_Alpha", this.Alpha);
  }
}
