using System;
using UnityEngine;

// Token: 0x02000429 RID: 1065
public class SkullScript : MonoBehaviour
{
	// Token: 0x06001CA5 RID: 7333 RVA: 0x0015348C File Offset: 0x0015168C
	private void Start()
	{
		this.OriginalPosition = this.RitualKnife.transform.position;
		this.OriginalRotation = this.RitualKnife.transform.eulerAngles;
		this.MissionMode = MissionModeGlobals.MissionMode;
		this.MyAudio = base.GetComponent<AudioSource>();
		if (!GameGlobals.Debug)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x06001CA6 RID: 7334 RVA: 0x00153504 File Offset: 0x00151704
	private void Update()
	{
		if (this.Yandere.Armed)
		{
			if (this.Yandere.EquippedWeapon.WeaponID == 8)
			{
				this.Prompt.enabled = true;
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				this.VoidGoddess.Follow = false;
				this.Yandere.EquippedWeapon.Drop();
				this.Yandere.EquippedWeapon = null;
				this.Yandere.Unequip();
				this.Yandere.DropTimer[this.Yandere.Equipped] = 0f;
				this.RitualKnife.transform.position = this.OriginalPosition;
				this.RitualKnife.transform.eulerAngles = this.OriginalRotation;
				this.RitualKnife.GetComponent<Rigidbody>().useGravity = false;
				if (!this.MissionMode)
				{
					if (this.RitualKnife.GetComponent<WeaponScript>().Heated && !this.RitualKnife.GetComponent<WeaponScript>().Flaming)
					{
						this.MyAudio.clip = this.FlameDemonVoice;
						this.MyAudio.Play();
						this.FlameTimer = 10f;
						this.RitualKnife.GetComponent<WeaponScript>().Prompt.Hide();
						this.RitualKnife.GetComponent<WeaponScript>().Prompt.enabled = false;
					}
					else if (this.RitualKnife.GetComponent<WeaponScript>().Blood.enabled)
					{
						this.DebugMenu.SetActive(false);
						this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
						this.Yandere.CanMove = false;
						UnityEngine.Object.Instantiate<GameObject>(this.DarkAura, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
						this.Timer += Time.deltaTime;
						this.Clock.StopTime = true;
						if (this.StudentManager.Students[21] == null || this.StudentManager.Students[26] == null || this.StudentManager.Students[31] == null || this.StudentManager.Students[36] == null || this.StudentManager.Students[41] == null || this.StudentManager.Students[46] == null || this.StudentManager.Students[51] == null || this.StudentManager.Students[56] == null || this.StudentManager.Students[61] == null || this.StudentManager.Students[66] == null || this.StudentManager.Students[71] == null)
						{
							this.EmptyDemon.SetActive(false);
						}
						else if (!this.StudentManager.Students[21].Alive || !this.StudentManager.Students[26].Alive || !this.StudentManager.Students[31].Alive || !this.StudentManager.Students[36].Alive || !this.StudentManager.Students[41].Alive || !this.StudentManager.Students[46].Alive || !this.StudentManager.Students[51].Alive || !this.StudentManager.Students[56].Alive || !this.StudentManager.Students[61].Alive || !this.StudentManager.Students[66].Alive || !this.StudentManager.Students[71].Alive)
						{
							this.EmptyDemon.SetActive(false);
						}
						if (this.StudentManager.EmptyDemon)
						{
							this.EmptyDemon.SetActive(false);
						}
					}
				}
			}
		}
		if (this.FlameTimer > 0f)
		{
			this.FlameTimer = Mathf.MoveTowards(this.FlameTimer, 0f, Time.deltaTime);
			if (this.FlameTimer == 0f)
			{
				this.RitualKnife.GetComponent<WeaponScript>().FireEffect.gameObject.SetActive(true);
				this.RitualKnife.GetComponent<WeaponScript>().Prompt.enabled = true;
				this.RitualKnife.GetComponent<WeaponScript>().FireEffect.Play();
				this.RitualKnife.GetComponent<WeaponScript>().FireAudio.Play();
				this.RitualKnife.GetComponent<WeaponScript>().Flaming = true;
				this.Prompt.enabled = true;
				this.Prompt.Yandere.Police.Invalid = true;
				if (this.Prompt.Yandere.StudentManager.Students[10] != null)
				{
					this.Prompt.Yandere.StudentManager.Students[10].Strength = 0;
				}
				this.MyAudio.clip = this.FlameActivation;
				this.MyAudio.Play();
			}
		}
		if (this.Timer > 0f)
		{
			if (this.Yandere.transform.position.y < 1000f)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 4f)
				{
					this.Darkness.enabled = true;
					this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
					if (this.Darkness.color.a == 1f)
					{
						this.Yandere.transform.position = new Vector3(0f, 2000f, 0f);
						this.Yandere.Character.SetActive(true);
						this.Yandere.SetAnimationLayers();
						this.HeartbeatCamera.SetActive(false);
						this.FPS.SetActive(false);
						this.HUD.SetActive(false);
						this.Hell.SetActive(true);
					}
				}
				else if (this.Timer > 1f)
				{
					this.Yandere.Character.SetActive(false);
				}
			}
			else
			{
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0f, Time.deltaTime * 0.5f);
				if (this.Jukebox.Volume == 0f)
				{
					this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
					if (this.Darkness.color.a == 0f)
					{
						this.Yandere.CanMove = true;
						this.Timer = 0f;
					}
				}
			}
		}
		if (this.Yandere.Egg)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x0400335C RID: 13148
	public StudentManagerScript StudentManager;

	// Token: 0x0400335D RID: 13149
	public VoidGoddessScript VoidGoddess;

	// Token: 0x0400335E RID: 13150
	public JukeboxScript Jukebox;

	// Token: 0x0400335F RID: 13151
	public YandereScript Yandere;

	// Token: 0x04003360 RID: 13152
	public PromptScript Prompt;

	// Token: 0x04003361 RID: 13153
	public ClockScript Clock;

	// Token: 0x04003362 RID: 13154
	public AudioSource MyAudio;

	// Token: 0x04003363 RID: 13155
	public AudioClip FlameDemonVoice;

	// Token: 0x04003364 RID: 13156
	public AudioClip FlameActivation;

	// Token: 0x04003365 RID: 13157
	public GameObject HeartbeatCamera;

	// Token: 0x04003366 RID: 13158
	public GameObject RitualKnife;

	// Token: 0x04003367 RID: 13159
	public GameObject EmptyDemon;

	// Token: 0x04003368 RID: 13160
	public GameObject DebugMenu;

	// Token: 0x04003369 RID: 13161
	public GameObject DarkAura;

	// Token: 0x0400336A RID: 13162
	public GameObject Hell;

	// Token: 0x0400336B RID: 13163
	public GameObject FPS;

	// Token: 0x0400336C RID: 13164
	public GameObject HUD;

	// Token: 0x0400336D RID: 13165
	public Vector3 OriginalPosition;

	// Token: 0x0400336E RID: 13166
	public Vector3 OriginalRotation;

	// Token: 0x0400336F RID: 13167
	public UISprite Darkness;

	// Token: 0x04003370 RID: 13168
	public float FlameTimer;

	// Token: 0x04003371 RID: 13169
	public float Timer;

	// Token: 0x04003372 RID: 13170
	public bool MissionMode;
}
