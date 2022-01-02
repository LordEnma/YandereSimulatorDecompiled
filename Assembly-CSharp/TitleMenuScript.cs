using System;
using UnityEngine;

// Token: 0x02000472 RID: 1138
public class TitleMenuScript : MonoBehaviour
{
	// Token: 0x06001EA9 RID: 7849 RVA: 0x001AE620 File Offset: 0x001AC820
	private void Start()
	{
		RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.25f, 1f);
		Time.timeScale = 1f;
	}

	// Token: 0x06001EAA RID: 7850 RVA: 0x001AE64C File Offset: 0x001AC84C
	private void Update()
	{
		if (this.Phase == 0)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f)
			{
				this.Timer = 0f;
				this.Phase++;
				return;
			}
		}
		else
		{
			this.Timer += Time.deltaTime;
			if (base.transform.position.z > -18f)
			{
				this.LateTimer = Mathf.Lerp(this.LateTimer, this.Timer, Time.deltaTime);
				this.RotationY = Mathf.Lerp(this.RotationY, -22.5f, Time.deltaTime * this.LateTimer);
			}
			this.RotationZ = Mathf.Lerp(this.RotationZ, 22.5f, Time.deltaTime * this.Timer);
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0.33333f, 101.45f, -16.5f), Time.deltaTime * this.Timer);
			base.transform.eulerAngles = new Vector3(0f, this.RotationY, this.RotationZ);
			if (!this.Turning)
			{
				if (base.transform.position.z > -17f)
				{
					this.LoveSickYandere.CrossFade("f02_edgyTurn_00");
					this.VictimHead.parent = this.RightHand;
					this.Turning = true;
				}
			}
			else if (this.LoveSickYandere["f02_edgyTurn_00"].time >= this.LoveSickYandere["f02_edgyTurn_00"].length)
			{
				this.LoveSickYandere.CrossFade("f02_edgyOverShoulder_00");
			}
			if (Input.GetKeyDown(KeyCode.Minus))
			{
				Time.timeScale -= 1f;
			}
			if (Input.GetKeyDown(KeyCode.Equals))
			{
				Time.timeScale += 1f;
			}
		}
	}

	// Token: 0x04003F60 RID: 16224
	public ColorCorrectionCurves ColorCorrection;

	// Token: 0x04003F61 RID: 16225
	public InputManagerScript InputManager;

	// Token: 0x04003F62 RID: 16226
	public TitleSaveFilesScript SaveFiles;

	// Token: 0x04003F63 RID: 16227
	public SelectiveGrayscale Grayscale;

	// Token: 0x04003F64 RID: 16228
	public TitleSponsorScript Sponsors;

	// Token: 0x04003F65 RID: 16229
	public TitleExtrasScript Extras;

	// Token: 0x04003F66 RID: 16230
	public PromptBarScript PromptBar;

	// Token: 0x04003F67 RID: 16231
	public SSAOEffect SSAO;

	// Token: 0x04003F68 RID: 16232
	public JsonScript JSON;

	// Token: 0x04003F69 RID: 16233
	public UISprite[] MediumSprites;

	// Token: 0x04003F6A RID: 16234
	public UISprite[] LightSprites;

	// Token: 0x04003F6B RID: 16235
	public UISprite[] DarkSprites;

	// Token: 0x04003F6C RID: 16236
	public UILabel TitleLabel;

	// Token: 0x04003F6D RID: 16237
	public UILabel SimulatorLabel;

	// Token: 0x04003F6E RID: 16238
	public UILabel[] ColoredLabels;

	// Token: 0x04003F6F RID: 16239
	public Color MediumColor;

	// Token: 0x04003F70 RID: 16240
	public Color LightColor;

	// Token: 0x04003F71 RID: 16241
	public Color DarkColor;

	// Token: 0x04003F72 RID: 16242
	public Transform VictimHead;

	// Token: 0x04003F73 RID: 16243
	public Transform RightHand;

	// Token: 0x04003F74 RID: 16244
	public Transform TwintailL;

	// Token: 0x04003F75 RID: 16245
	public Transform TwintailR;

	// Token: 0x04003F76 RID: 16246
	public Animation LoveSickYandere;

	// Token: 0x04003F77 RID: 16247
	public GameObject BloodProjector;

	// Token: 0x04003F78 RID: 16248
	public GameObject LoveSickLogo;

	// Token: 0x04003F79 RID: 16249
	public GameObject BloodCamera;

	// Token: 0x04003F7A RID: 16250
	public GameObject Yandere;

	// Token: 0x04003F7B RID: 16251
	public GameObject Knife;

	// Token: 0x04003F7C RID: 16252
	public GameObject Logo;

	// Token: 0x04003F7D RID: 16253
	public GameObject Sun;

	// Token: 0x04003F7E RID: 16254
	public AudioSource LoveSickMusic;

	// Token: 0x04003F7F RID: 16255
	public AudioSource CuteMusic;

	// Token: 0x04003F80 RID: 16256
	public AudioSource DarkMusic;

	// Token: 0x04003F81 RID: 16257
	public Renderer[] YandereEye;

	// Token: 0x04003F82 RID: 16258
	public Material CuteSkybox;

	// Token: 0x04003F83 RID: 16259
	public Material DarkSkybox;

	// Token: 0x04003F84 RID: 16260
	public Transform Highlight;

	// Token: 0x04003F85 RID: 16261
	public Transform[] Spine;

	// Token: 0x04003F86 RID: 16262
	public Transform[] Arm;

	// Token: 0x04003F87 RID: 16263
	public UISprite Darkness;

	// Token: 0x04003F88 RID: 16264
	public Vector3 PermaPositionL;

	// Token: 0x04003F89 RID: 16265
	public Vector3 PermaPositionR;

	// Token: 0x04003F8A RID: 16266
	public bool NeverChange;

	// Token: 0x04003F8B RID: 16267
	public bool LoveSick;

	// Token: 0x04003F8C RID: 16268
	public bool FadeOut;

	// Token: 0x04003F8D RID: 16269
	public bool Turning;

	// Token: 0x04003F8E RID: 16270
	public bool Fading = true;

	// Token: 0x04003F8F RID: 16271
	public int SelectionCount = 8;

	// Token: 0x04003F90 RID: 16272
	public int Selected;

	// Token: 0x04003F91 RID: 16273
	public float InputTimer;

	// Token: 0x04003F92 RID: 16274
	public float FadeSpeed = 1f;

	// Token: 0x04003F93 RID: 16275
	public float LateTimer;

	// Token: 0x04003F94 RID: 16276
	public float RotationY;

	// Token: 0x04003F95 RID: 16277
	public float RotationZ;

	// Token: 0x04003F96 RID: 16278
	public float Volume;

	// Token: 0x04003F97 RID: 16279
	public float Timer;

	// Token: 0x04003F98 RID: 16280
	public int Phase;
}
