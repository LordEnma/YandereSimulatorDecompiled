using System;
using UnityEngine;

// Token: 0x0200047D RID: 1149
public class TitleMenuScript : MonoBehaviour
{
	// Token: 0x06001EEB RID: 7915 RVA: 0x001B4A54 File Offset: 0x001B2C54
	private void Start()
	{
		RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.25f, 1f);
		Time.timeScale = 1f;
	}

	// Token: 0x06001EEC RID: 7916 RVA: 0x001B4A80 File Offset: 0x001B2C80
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

	// Token: 0x04004034 RID: 16436
	public ColorCorrectionCurves ColorCorrection;

	// Token: 0x04004035 RID: 16437
	public InputManagerScript InputManager;

	// Token: 0x04004036 RID: 16438
	public TitleSaveFilesScript SaveFiles;

	// Token: 0x04004037 RID: 16439
	public SelectiveGrayscale Grayscale;

	// Token: 0x04004038 RID: 16440
	public TitleSponsorScript Sponsors;

	// Token: 0x04004039 RID: 16441
	public TitleExtrasScript Extras;

	// Token: 0x0400403A RID: 16442
	public PromptBarScript PromptBar;

	// Token: 0x0400403B RID: 16443
	public SSAOEffect SSAO;

	// Token: 0x0400403C RID: 16444
	public JsonScript JSON;

	// Token: 0x0400403D RID: 16445
	public UISprite[] MediumSprites;

	// Token: 0x0400403E RID: 16446
	public UISprite[] LightSprites;

	// Token: 0x0400403F RID: 16447
	public UISprite[] DarkSprites;

	// Token: 0x04004040 RID: 16448
	public UILabel TitleLabel;

	// Token: 0x04004041 RID: 16449
	public UILabel SimulatorLabel;

	// Token: 0x04004042 RID: 16450
	public UILabel[] ColoredLabels;

	// Token: 0x04004043 RID: 16451
	public Color MediumColor;

	// Token: 0x04004044 RID: 16452
	public Color LightColor;

	// Token: 0x04004045 RID: 16453
	public Color DarkColor;

	// Token: 0x04004046 RID: 16454
	public Transform VictimHead;

	// Token: 0x04004047 RID: 16455
	public Transform RightHand;

	// Token: 0x04004048 RID: 16456
	public Transform TwintailL;

	// Token: 0x04004049 RID: 16457
	public Transform TwintailR;

	// Token: 0x0400404A RID: 16458
	public Animation LoveSickYandere;

	// Token: 0x0400404B RID: 16459
	public GameObject BloodProjector;

	// Token: 0x0400404C RID: 16460
	public GameObject LoveSickLogo;

	// Token: 0x0400404D RID: 16461
	public GameObject BloodCamera;

	// Token: 0x0400404E RID: 16462
	public GameObject Yandere;

	// Token: 0x0400404F RID: 16463
	public GameObject Knife;

	// Token: 0x04004050 RID: 16464
	public GameObject Logo;

	// Token: 0x04004051 RID: 16465
	public GameObject Sun;

	// Token: 0x04004052 RID: 16466
	public AudioSource LoveSickMusic;

	// Token: 0x04004053 RID: 16467
	public AudioSource CuteMusic;

	// Token: 0x04004054 RID: 16468
	public AudioSource DarkMusic;

	// Token: 0x04004055 RID: 16469
	public Renderer[] YandereEye;

	// Token: 0x04004056 RID: 16470
	public Material CuteSkybox;

	// Token: 0x04004057 RID: 16471
	public Material DarkSkybox;

	// Token: 0x04004058 RID: 16472
	public Transform Highlight;

	// Token: 0x04004059 RID: 16473
	public Transform[] Spine;

	// Token: 0x0400405A RID: 16474
	public Transform[] Arm;

	// Token: 0x0400405B RID: 16475
	public UISprite Darkness;

	// Token: 0x0400405C RID: 16476
	public Vector3 PermaPositionL;

	// Token: 0x0400405D RID: 16477
	public Vector3 PermaPositionR;

	// Token: 0x0400405E RID: 16478
	public bool NeverChange;

	// Token: 0x0400405F RID: 16479
	public bool LoveSick;

	// Token: 0x04004060 RID: 16480
	public bool FadeOut;

	// Token: 0x04004061 RID: 16481
	public bool Turning;

	// Token: 0x04004062 RID: 16482
	public bool Fading = true;

	// Token: 0x04004063 RID: 16483
	public int SelectionCount = 8;

	// Token: 0x04004064 RID: 16484
	public int Selected;

	// Token: 0x04004065 RID: 16485
	public float InputTimer;

	// Token: 0x04004066 RID: 16486
	public float FadeSpeed = 1f;

	// Token: 0x04004067 RID: 16487
	public float LateTimer;

	// Token: 0x04004068 RID: 16488
	public float RotationY;

	// Token: 0x04004069 RID: 16489
	public float RotationZ;

	// Token: 0x0400406A RID: 16490
	public float Volume;

	// Token: 0x0400406B RID: 16491
	public float Timer;

	// Token: 0x0400406C RID: 16492
	public int Phase;
}
