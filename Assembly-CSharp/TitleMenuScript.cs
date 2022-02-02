using System;
using UnityEngine;

// Token: 0x02000475 RID: 1141
public class TitleMenuScript : MonoBehaviour
{
	// Token: 0x06001EB7 RID: 7863 RVA: 0x001B0148 File Offset: 0x001AE348
	private void Start()
	{
		RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.25f, 1f);
		Time.timeScale = 1f;
	}

	// Token: 0x06001EB8 RID: 7864 RVA: 0x001B0174 File Offset: 0x001AE374
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

	// Token: 0x04003F83 RID: 16259
	public ColorCorrectionCurves ColorCorrection;

	// Token: 0x04003F84 RID: 16260
	public InputManagerScript InputManager;

	// Token: 0x04003F85 RID: 16261
	public TitleSaveFilesScript SaveFiles;

	// Token: 0x04003F86 RID: 16262
	public SelectiveGrayscale Grayscale;

	// Token: 0x04003F87 RID: 16263
	public TitleSponsorScript Sponsors;

	// Token: 0x04003F88 RID: 16264
	public TitleExtrasScript Extras;

	// Token: 0x04003F89 RID: 16265
	public PromptBarScript PromptBar;

	// Token: 0x04003F8A RID: 16266
	public SSAOEffect SSAO;

	// Token: 0x04003F8B RID: 16267
	public JsonScript JSON;

	// Token: 0x04003F8C RID: 16268
	public UISprite[] MediumSprites;

	// Token: 0x04003F8D RID: 16269
	public UISprite[] LightSprites;

	// Token: 0x04003F8E RID: 16270
	public UISprite[] DarkSprites;

	// Token: 0x04003F8F RID: 16271
	public UILabel TitleLabel;

	// Token: 0x04003F90 RID: 16272
	public UILabel SimulatorLabel;

	// Token: 0x04003F91 RID: 16273
	public UILabel[] ColoredLabels;

	// Token: 0x04003F92 RID: 16274
	public Color MediumColor;

	// Token: 0x04003F93 RID: 16275
	public Color LightColor;

	// Token: 0x04003F94 RID: 16276
	public Color DarkColor;

	// Token: 0x04003F95 RID: 16277
	public Transform VictimHead;

	// Token: 0x04003F96 RID: 16278
	public Transform RightHand;

	// Token: 0x04003F97 RID: 16279
	public Transform TwintailL;

	// Token: 0x04003F98 RID: 16280
	public Transform TwintailR;

	// Token: 0x04003F99 RID: 16281
	public Animation LoveSickYandere;

	// Token: 0x04003F9A RID: 16282
	public GameObject BloodProjector;

	// Token: 0x04003F9B RID: 16283
	public GameObject LoveSickLogo;

	// Token: 0x04003F9C RID: 16284
	public GameObject BloodCamera;

	// Token: 0x04003F9D RID: 16285
	public GameObject Yandere;

	// Token: 0x04003F9E RID: 16286
	public GameObject Knife;

	// Token: 0x04003F9F RID: 16287
	public GameObject Logo;

	// Token: 0x04003FA0 RID: 16288
	public GameObject Sun;

	// Token: 0x04003FA1 RID: 16289
	public AudioSource LoveSickMusic;

	// Token: 0x04003FA2 RID: 16290
	public AudioSource CuteMusic;

	// Token: 0x04003FA3 RID: 16291
	public AudioSource DarkMusic;

	// Token: 0x04003FA4 RID: 16292
	public Renderer[] YandereEye;

	// Token: 0x04003FA5 RID: 16293
	public Material CuteSkybox;

	// Token: 0x04003FA6 RID: 16294
	public Material DarkSkybox;

	// Token: 0x04003FA7 RID: 16295
	public Transform Highlight;

	// Token: 0x04003FA8 RID: 16296
	public Transform[] Spine;

	// Token: 0x04003FA9 RID: 16297
	public Transform[] Arm;

	// Token: 0x04003FAA RID: 16298
	public UISprite Darkness;

	// Token: 0x04003FAB RID: 16299
	public Vector3 PermaPositionL;

	// Token: 0x04003FAC RID: 16300
	public Vector3 PermaPositionR;

	// Token: 0x04003FAD RID: 16301
	public bool NeverChange;

	// Token: 0x04003FAE RID: 16302
	public bool LoveSick;

	// Token: 0x04003FAF RID: 16303
	public bool FadeOut;

	// Token: 0x04003FB0 RID: 16304
	public bool Turning;

	// Token: 0x04003FB1 RID: 16305
	public bool Fading = true;

	// Token: 0x04003FB2 RID: 16306
	public int SelectionCount = 8;

	// Token: 0x04003FB3 RID: 16307
	public int Selected;

	// Token: 0x04003FB4 RID: 16308
	public float InputTimer;

	// Token: 0x04003FB5 RID: 16309
	public float FadeSpeed = 1f;

	// Token: 0x04003FB6 RID: 16310
	public float LateTimer;

	// Token: 0x04003FB7 RID: 16311
	public float RotationY;

	// Token: 0x04003FB8 RID: 16312
	public float RotationZ;

	// Token: 0x04003FB9 RID: 16313
	public float Volume;

	// Token: 0x04003FBA RID: 16314
	public float Timer;

	// Token: 0x04003FBB RID: 16315
	public int Phase;
}
