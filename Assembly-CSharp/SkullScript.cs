using System;
using UnityEngine;

// Token: 0x02000432 RID: 1074
public class SkullScript : MonoBehaviour
{
	// Token: 0x06001CE8 RID: 7400 RVA: 0x00157FB0 File Offset: 0x001561B0
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

	// Token: 0x06001CE9 RID: 7401 RVA: 0x00158028 File Offset: 0x00156228
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

	// Token: 0x0400340E RID: 13326
	public StudentManagerScript StudentManager;

	// Token: 0x0400340F RID: 13327
	public VoidGoddessScript VoidGoddess;

	// Token: 0x04003410 RID: 13328
	public JukeboxScript Jukebox;

	// Token: 0x04003411 RID: 13329
	public YandereScript Yandere;

	// Token: 0x04003412 RID: 13330
	public PromptScript Prompt;

	// Token: 0x04003413 RID: 13331
	public ClockScript Clock;

	// Token: 0x04003414 RID: 13332
	public AudioSource MyAudio;

	// Token: 0x04003415 RID: 13333
	public AudioClip FlameDemonVoice;

	// Token: 0x04003416 RID: 13334
	public AudioClip FlameActivation;

	// Token: 0x04003417 RID: 13335
	public GameObject HeartbeatCamera;

	// Token: 0x04003418 RID: 13336
	public GameObject RitualKnife;

	// Token: 0x04003419 RID: 13337
	public GameObject EmptyDemon;

	// Token: 0x0400341A RID: 13338
	public GameObject DebugMenu;

	// Token: 0x0400341B RID: 13339
	public GameObject DarkAura;

	// Token: 0x0400341C RID: 13340
	public GameObject Hell;

	// Token: 0x0400341D RID: 13341
	public GameObject FPS;

	// Token: 0x0400341E RID: 13342
	public GameObject HUD;

	// Token: 0x0400341F RID: 13343
	public Vector3 OriginalPosition;

	// Token: 0x04003420 RID: 13344
	public Vector3 OriginalRotation;

	// Token: 0x04003421 RID: 13345
	public UISprite Darkness;

	// Token: 0x04003422 RID: 13346
	public float FlameTimer;

	// Token: 0x04003423 RID: 13347
	public float Timer;

	// Token: 0x04003424 RID: 13348
	public bool MissionMode;
}
