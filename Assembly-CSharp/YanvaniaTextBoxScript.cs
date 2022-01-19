using System;
using UnityEngine;

// Token: 0x020004DE RID: 1246
public class YanvaniaTextBoxScript : MonoBehaviour
{
	// Token: 0x06002091 RID: 8337 RVA: 0x001DDA74 File Offset: 0x001DBC74
	private void Start()
	{
		this.Portrait.transform.localScale = Vector3.zero;
		this.BloodWipe.transform.localScale = new Vector3(0f, this.BloodWipe.transform.localScale.y, this.BloodWipe.transform.localScale.z);
		this.SpeakerLabel.text = string.Empty;
		this.Border.color = new Color(this.Border.color.r, this.Border.color.g, this.Border.color.b, 0f);
		this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x06002092 RID: 8338 RVA: 0x001DDB80 File Offset: 0x001DBD80
	private void Update()
	{
		if (!this.Leave)
		{
			if (this.BloodWipe.transform.localScale.x == 0f)
			{
				this.BloodWipe.transform.localScale = new Vector3(this.BloodWipe.transform.localScale.x + Time.deltaTime, this.BloodWipe.transform.localScale.y, this.BloodWipe.transform.localScale.z);
			}
			if (this.BloodWipe.transform.localScale.x > 50f)
			{
				this.BloodWipe.color = new Color(this.BloodWipe.color.r, this.BloodWipe.color.g, this.BloodWipe.color.b, this.BloodWipe.color.a - Time.deltaTime);
				this.Border.color = new Color(this.Border.color.r, this.Border.color.g, this.Border.color.b, this.Border.color.a + Time.deltaTime);
				this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 0.5f);
			}
			else
			{
				this.BloodWipe.transform.localScale = new Vector3(this.BloodWipe.transform.localScale.x + this.BloodWipe.transform.localScale.x * 0.1f, this.BloodWipe.transform.localScale.y, this.BloodWipe.transform.localScale.z);
			}
			if (this.BloodWipe.color.a <= 0f)
			{
				if (!this.Display)
				{
					if (this.LineID < this.Lines.Length - 1)
					{
						if (this.NewLabel != null)
						{
							UnityEngine.Object.Destroy(this.NewLabel);
						}
						this.UpdatePortrait = true;
						this.Display = true;
						this.PortraitID = ((this.PortraitID == 1) ? 2 : 1);
						this.SpeakerLabel.text = string.Empty;
					}
				}
				else if (this.NewLabelScript != null)
				{
					AudioSource component = base.GetComponent<AudioSource>();
					if (!this.NewLabelScript.enabled)
					{
						this.NewLabelScript.enabled = true;
						component.clip = this.Voices[this.LineID];
						this.NewLineTimer = 0f;
						component.Play();
					}
					else
					{
						this.NewLineTimer += Time.deltaTime;
						if (this.NewLineTimer > component.clip.length + 0.5f || Input.GetButtonDown("A") || Input.GetKeyDown("z") || Input.GetKeyDown("x"))
						{
							this.Display = false;
						}
					}
				}
			}
			if (this.UpdatePortrait)
			{
				if (!this.Grow)
				{
					this.Portrait.transform.localScale = Vector3.MoveTowards(this.Portrait.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
					if (this.Portrait.transform.localScale.x == 0f)
					{
						this.Portrait.mainTexture = this.Portraits[this.PortraitID];
						this.Grow = true;
					}
				}
				else
				{
					this.Portrait.transform.localScale = Vector3.MoveTowards(this.Portrait.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
					if (this.Portrait.transform.localScale.x == 1f)
					{
						this.SpeakerLabel.text = this.SpeakerNames[this.PortraitID];
						this.UpdatePortrait = false;
						this.AnimTimer = 0f;
						this.Grow = false;
						this.LineID++;
						this.SpawnLabel();
					}
				}
			}
			this.AnimTimer += Time.deltaTime;
			if (this.LineID == 2)
			{
				this.NewTypewriter.charsPerSecond = 15;
				this.NewTypewriter.delayOnPeriod = 1.5f;
				if (this.AnimTimer < 0.5f)
				{
					this.NewTypewriter.delayOnComma = true;
				}
			}
			Animation component2 = this.Yanmont.Character.GetComponent<Animation>();
			if (this.LineID == 3)
			{
				this.NewTypewriter.delayOnComma = true;
				this.NewTypewriter.delayOnPeriod = 0.75f;
				if (this.AnimTimer < 1f)
				{
					component2.CrossFade("f02_yanvaniaCutsceneAction1_00");
				}
				if (component2["f02_yanvaniaCutsceneAction1_00"].time >= component2["f02_yanvaniaCutsceneAction1_00"].length)
				{
					component2.CrossFade("f02_yanvaniaDramaticIdle_00");
				}
			}
			Animation component3 = this.Dracula.Character.GetComponent<Animation>();
			if (this.LineID == 5)
			{
				this.NewTypewriter.charsPerSecond = 15;
				component2.CrossFade("f02_yanvaniaCutsceneAction2_00");
				if (component2["f02_yanvaniaCutsceneAction2_00"].time >= component2["f02_yanvaniaCutsceneAction2_00"].length)
				{
					component2.CrossFade("f02_yanvaniaDramaticIdle_00");
				}
				if (this.AnimTimer > 4f)
				{
					component3.CrossFade("DraculaDrink");
				}
				if (this.AnimTimer > 4.5f)
				{
					this.Glass.GetComponent<Renderer>().materials[0].color = new Color(1f, 1f, 1f, 0.5f);
				}
				if (this.AnimTimer > 5f && component3["DraculaDrink"].time >= component3["DraculaDrink"].length)
				{
					component3.CrossFade("DraculaIdle");
				}
			}
			if (this.LineID == 6)
			{
				component2.CrossFade("f02_yanvaniaDramaticIdle_00");
				if (this.AnimTimer < 1f)
				{
					this.NewTypewriter.delayOnPeriod = 2.25f;
				}
				if (this.AnimTimer > 1f && this.AnimTimer < 2f)
				{
					component3.CrossFade("DraculaToss");
				}
				if (this.Glass != null)
				{
					Rigidbody component4 = this.Glass.GetComponent<Rigidbody>();
					if (this.AnimTimer > 1.4f && !component4.useGravity)
					{
						component4.useGravity = true;
						this.Glass.transform.parent = null;
						component4.AddForce(-100f, 100f, -100f);
					}
				}
				if (this.AnimTimer > 2f + component3["DraculaToss"].length && this.AnimTimer < 6f)
				{
					component3.CrossFade("DraculaIdle");
				}
				if (this.AnimTimer > 4f)
				{
					this.NewTypewriter.delayOnPeriod = 1f;
					this.NewTypewriter.charsPerSecond = 15;
				}
				if (this.AnimTimer > 6f && this.AnimTimer < 9.5f)
				{
					this.Dracula.transform.position = Vector3.Lerp(this.Dracula.transform.position, new Vector3(-34.675f, 7.5f, 2.8f), Time.deltaTime * 10f);
					component3.CrossFade("succubus_a_idle_01");
				}
				if (this.AnimTimer > 9.5f)
				{
					this.NewLabelScript.text = string.Empty;
					this.SpeakerLabel.text = string.Empty;
					this.Dracula.SpawnTeleportEffect();
					this.Dracula.enabled = true;
					this.Jukebox.BossBattle();
					this.Leave = true;
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				if (this.NewLabel != null)
				{
					UnityEngine.Object.Destroy(this.NewLabel);
				}
				if (this.NewLabelScript != null)
				{
					this.NewLabelScript.text = string.Empty;
				}
				this.SpeakerLabel.text = string.Empty;
				this.Dracula.SpawnTeleportEffect();
				this.Dracula.enabled = true;
				this.Jukebox.BossBattle();
				UnityEngine.Object.Destroy(this.BloodWipe);
				UnityEngine.Object.Destroy(this.Glass);
				this.Leave = true;
				return;
			}
		}
		else
		{
			this.Portrait.transform.localScale = Vector3.MoveTowards(this.Portrait.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
			if (this.Portrait.transform.localScale.x == 0f)
			{
				this.Border.transform.position = new Vector3(this.Border.transform.position.x, this.Border.transform.position.y + Time.deltaTime, this.Border.transform.position.z);
				this.BG.transform.position = new Vector3(this.BG.transform.position.x, this.BG.transform.position.y + Time.deltaTime, this.BG.transform.position.z);
				if (!this.Yanmont.enabled)
				{
					this.Yanmont.YanvaniaCamera.TargetZoom = 0f;
					this.Yanmont.Character.transform.localScale = new Vector3(-1f, 1f, 1f);
					this.Yanmont.EnterCutscene = false;
					this.Yanmont.Cutscene = false;
					this.Yanmont.enabled = true;
				}
			}
		}
	}

	// Token: 0x06002093 RID: 8339 RVA: 0x001DE590 File Offset: 0x001DC790
	private void SpawnLabel()
	{
		this.NewLabel = UnityEngine.Object.Instantiate<GameObject>(this.Label, base.transform.position, Quaternion.identity);
		this.NewLabel.transform.parent = this.NewLabelSpawnPoint;
		this.NewLabel.transform.localEulerAngles = Vector3.zero;
		this.NewLabel.transform.localPosition = Vector3.zero;
		this.NewLabel.transform.localScale = new Vector3(1f, 1f, 1f);
		this.NewTypewriter = this.NewLabel.GetComponent<TypewriterEffect>();
		this.NewLabelScript = this.NewLabel.GetComponent<UILabel>();
		this.NewLabelScript.text = this.Lines[this.LineID];
		this.NewLabelScript.enabled = false;
	}

	// Token: 0x0400474E RID: 18254
	private TypewriterEffect NewTypewriter;

	// Token: 0x0400474F RID: 18255
	private UILabel NewLabelScript;

	// Token: 0x04004750 RID: 18256
	private GameObject NewLabel;

	// Token: 0x04004751 RID: 18257
	public YanvaniaJukeboxScript Jukebox;

	// Token: 0x04004752 RID: 18258
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004753 RID: 18259
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004754 RID: 18260
	public Transform NewLabelSpawnPoint;

	// Token: 0x04004755 RID: 18261
	public GameObject Glass;

	// Token: 0x04004756 RID: 18262
	public GameObject Label;

	// Token: 0x04004757 RID: 18263
	public UILabel SpeakerLabel;

	// Token: 0x04004758 RID: 18264
	public UITexture BloodWipe;

	// Token: 0x04004759 RID: 18265
	public UITexture Portrait;

	// Token: 0x0400475A RID: 18266
	public UITexture Border;

	// Token: 0x0400475B RID: 18267
	public UITexture BG;

	// Token: 0x0400475C RID: 18268
	public bool UpdatePortrait;

	// Token: 0x0400475D RID: 18269
	public bool Display;

	// Token: 0x0400475E RID: 18270
	public bool Leave;

	// Token: 0x0400475F RID: 18271
	public bool Grow;

	// Token: 0x04004760 RID: 18272
	public string[] SpeakerNames;

	// Token: 0x04004761 RID: 18273
	public Texture[] Portraits;

	// Token: 0x04004762 RID: 18274
	public AudioClip[] Voices;

	// Token: 0x04004763 RID: 18275
	public string[] Lines;

	// Token: 0x04004764 RID: 18276
	public int PortraitID = 1;

	// Token: 0x04004765 RID: 18277
	public int LineID;

	// Token: 0x04004766 RID: 18278
	public float NewLineTimer;

	// Token: 0x04004767 RID: 18279
	public float AnimTimer;

	// Token: 0x04004768 RID: 18280
	public float Timer;
}
