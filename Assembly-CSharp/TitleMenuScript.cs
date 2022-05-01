using System;
using UnityEngine;

// Token: 0x0200047F RID: 1151
public class TitleMenuScript : MonoBehaviour
{
	// Token: 0x06001F02 RID: 7938 RVA: 0x001B6CA4 File Offset: 0x001B4EA4
	private void Start()
	{
		RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.25f, 1f);
		Time.timeScale = 1f;
	}

	// Token: 0x06001F03 RID: 7939 RVA: 0x001B6CD0 File Offset: 0x001B4ED0
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

	// Token: 0x0400405D RID: 16477
	public ColorCorrectionCurves ColorCorrection;

	// Token: 0x0400405E RID: 16478
	public InputManagerScript InputManager;

	// Token: 0x0400405F RID: 16479
	public TitleSaveFilesScript SaveFiles;

	// Token: 0x04004060 RID: 16480
	public SelectiveGrayscale Grayscale;

	// Token: 0x04004061 RID: 16481
	public TitleSponsorScript Sponsors;

	// Token: 0x04004062 RID: 16482
	public TitleExtrasScript Extras;

	// Token: 0x04004063 RID: 16483
	public PromptBarScript PromptBar;

	// Token: 0x04004064 RID: 16484
	public SSAOEffect SSAO;

	// Token: 0x04004065 RID: 16485
	public JsonScript JSON;

	// Token: 0x04004066 RID: 16486
	public UISprite[] MediumSprites;

	// Token: 0x04004067 RID: 16487
	public UISprite[] LightSprites;

	// Token: 0x04004068 RID: 16488
	public UISprite[] DarkSprites;

	// Token: 0x04004069 RID: 16489
	public UILabel TitleLabel;

	// Token: 0x0400406A RID: 16490
	public UILabel SimulatorLabel;

	// Token: 0x0400406B RID: 16491
	public UILabel[] ColoredLabels;

	// Token: 0x0400406C RID: 16492
	public Color MediumColor;

	// Token: 0x0400406D RID: 16493
	public Color LightColor;

	// Token: 0x0400406E RID: 16494
	public Color DarkColor;

	// Token: 0x0400406F RID: 16495
	public Transform VictimHead;

	// Token: 0x04004070 RID: 16496
	public Transform RightHand;

	// Token: 0x04004071 RID: 16497
	public Transform TwintailL;

	// Token: 0x04004072 RID: 16498
	public Transform TwintailR;

	// Token: 0x04004073 RID: 16499
	public Animation LoveSickYandere;

	// Token: 0x04004074 RID: 16500
	public GameObject BloodProjector;

	// Token: 0x04004075 RID: 16501
	public GameObject LoveSickLogo;

	// Token: 0x04004076 RID: 16502
	public GameObject BloodCamera;

	// Token: 0x04004077 RID: 16503
	public GameObject Yandere;

	// Token: 0x04004078 RID: 16504
	public GameObject Knife;

	// Token: 0x04004079 RID: 16505
	public GameObject Logo;

	// Token: 0x0400407A RID: 16506
	public GameObject Sun;

	// Token: 0x0400407B RID: 16507
	public AudioSource LoveSickMusic;

	// Token: 0x0400407C RID: 16508
	public AudioSource CuteMusic;

	// Token: 0x0400407D RID: 16509
	public AudioSource DarkMusic;

	// Token: 0x0400407E RID: 16510
	public Renderer[] YandereEye;

	// Token: 0x0400407F RID: 16511
	public Material CuteSkybox;

	// Token: 0x04004080 RID: 16512
	public Material DarkSkybox;

	// Token: 0x04004081 RID: 16513
	public Transform Highlight;

	// Token: 0x04004082 RID: 16514
	public Transform[] Spine;

	// Token: 0x04004083 RID: 16515
	public Transform[] Arm;

	// Token: 0x04004084 RID: 16516
	public UISprite Darkness;

	// Token: 0x04004085 RID: 16517
	public Vector3 PermaPositionL;

	// Token: 0x04004086 RID: 16518
	public Vector3 PermaPositionR;

	// Token: 0x04004087 RID: 16519
	public bool NeverChange;

	// Token: 0x04004088 RID: 16520
	public bool LoveSick;

	// Token: 0x04004089 RID: 16521
	public bool FadeOut;

	// Token: 0x0400408A RID: 16522
	public bool Turning;

	// Token: 0x0400408B RID: 16523
	public bool Fading = true;

	// Token: 0x0400408C RID: 16524
	public int SelectionCount = 8;

	// Token: 0x0400408D RID: 16525
	public int Selected;

	// Token: 0x0400408E RID: 16526
	public float InputTimer;

	// Token: 0x0400408F RID: 16527
	public float FadeSpeed = 1f;

	// Token: 0x04004090 RID: 16528
	public float LateTimer;

	// Token: 0x04004091 RID: 16529
	public float RotationY;

	// Token: 0x04004092 RID: 16530
	public float RotationZ;

	// Token: 0x04004093 RID: 16531
	public float Volume;

	// Token: 0x04004094 RID: 16532
	public float Timer;

	// Token: 0x04004095 RID: 16533
	public int Phase;
}
