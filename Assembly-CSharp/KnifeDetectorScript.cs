// Decompiled with JetBrains decompiler
// Type: KnifeDetectorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class KnifeDetectorScript : MonoBehaviour
{
  public BlowtorchScript[] Blowtorches;
  public Transform HeatingSpot;
  public Transform Torches;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public float Timer;

  private void Start() => this.Disable();

  private void Update()
  {
    if ((Object) this.Blowtorches[1].transform.parent != (Object) this.Torches || (Object) this.Blowtorches[2].transform.parent != (Object) this.Torches || (Object) this.Blowtorches[3].transform.parent != (Object) this.Torches)
    {
      this.Prompt.Hide();
      this.Prompt.enabled = true;
      this.enabled = false;
    }
    if (this.Yandere.Armed)
    {
      if (this.Yandere.EquippedWeapon.WeaponID == 8)
      {
        this.Prompt.MyCollider.enabled = true;
        this.Prompt.enabled = true;
        if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
        {
          this.Prompt.Circle[0].fillAmount = 1f;
          if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
          {
            this.Yandere.CharacterAnimation.CrossFade("f02_heating_00");
            this.Yandere.CanMove = false;
            this.Timer = 5f;
            this.Blowtorches[1].enabled = true;
            this.Blowtorches[2].enabled = true;
            this.Blowtorches[3].enabled = true;
            this.Blowtorches[1].GetComponent<AudioSource>().Play();
            this.Blowtorches[2].GetComponent<AudioSource>().Play();
            this.Blowtorches[3].GetComponent<AudioSource>().Play();
          }
        }
      }
      else
        this.Disable();
    }
    else
      this.Disable();
    if ((double) this.Timer <= 0.0)
      return;
    this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.HeatingSpot.rotation, Time.deltaTime * 10f);
    this.Yandere.MoveTowardsTarget(this.HeatingSpot.position);
    WeaponScript equippedWeapon = this.Yandere.EquippedWeapon;
    Material material = equippedWeapon.MyRenderer.material;
    material.color = new Color(material.color.r, Mathf.MoveTowards(material.color.g, 0.5f, Time.deltaTime * 0.2f), Mathf.MoveTowards(material.color.b, 0.5f, Time.deltaTime * 0.2f), material.color.a);
    this.Timer = Mathf.MoveTowards(this.Timer, 0.0f, Time.deltaTime);
    if ((double) this.Timer != 0.0)
      return;
    equippedWeapon.Heated = true;
    this.enabled = false;
    this.Disable();
  }

  private void Disable()
  {
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.Prompt.MyCollider.enabled = false;
  }
}
