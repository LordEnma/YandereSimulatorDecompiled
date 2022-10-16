// Decompiled with JetBrains decompiler
// Type: LightSwitchScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LightSwitchScript : MonoBehaviour
{
  public ToiletEventScript ToiletEvent;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public Transform ElectrocutionSpot;
  public GameObject BathroomLight;
  public GameObject Electricity;
  public Rigidbody Panel;
  public Transform Wires;
  public AudioClip[] ReactionClips;
  public string[] ReactionTexts;
  public AudioClip[] Flick;
  public float SubtitleTimer;
  public float FlickerTimer;
  public int ReactionID;
  public bool Flicker;

  private void Start() => this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();

  private void Update()
  {
    if (this.Flicker)
    {
      this.FlickerTimer += Time.deltaTime;
      if ((double) this.FlickerTimer > 0.10000000149011612)
      {
        this.FlickerTimer = 0.0f;
        this.BathroomLight.SetActive(!this.BathroomLight.activeInHierarchy);
      }
    }
    if (!this.Panel.useGravity)
      this.Prompt.HideButton[3] = !this.Yandere.Armed || this.Yandere.EquippedWeapon.WeaponID != 6;
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      AudioSource component = this.GetComponent<AudioSource>();
      if (this.BathroomLight.activeInHierarchy)
      {
        this.Prompt.Label[0].text = "     Turn On";
        this.BathroomLight.SetActive(false);
        component.clip = this.Flick[1];
        component.Play();
        if (this.ToiletEvent.EventActive && (this.ToiletEvent.EventPhase == 2 || this.ToiletEvent.EventPhase == 3))
        {
          this.ReactionID = Random.Range(1, 4);
          AudioClipPlayer.Play(this.ReactionClips[this.ReactionID], this.ToiletEvent.EventStudent.transform.position, 5f, 10f, out this.ToiletEvent.VoiceClip);
          this.ToiletEvent.EventSubtitle.text = this.ReactionTexts[this.ReactionID];
          this.SubtitleTimer += Time.deltaTime;
        }
      }
      else
      {
        this.Prompt.Label[0].text = "     Turn Off";
        this.BathroomLight.SetActive(true);
        component.clip = this.Flick[0];
        component.Play();
      }
    }
    if ((double) this.SubtitleTimer > 0.0)
    {
      this.SubtitleTimer += Time.deltaTime;
      if ((double) this.SubtitleTimer > 3.0)
      {
        this.ToiletEvent.EventSubtitle.text = string.Empty;
        this.SubtitleTimer = 0.0f;
      }
    }
    if ((double) this.Prompt.Circle[3].fillAmount != 0.0)
      return;
    this.Prompt.HideButton[3] = true;
    this.Wires.localScale = new Vector3(this.Wires.localScale.x, this.Wires.localScale.y, 1f);
    this.Panel.useGravity = true;
    this.Panel.AddForce(0.0f, 0.0f, 10f);
  }
}
