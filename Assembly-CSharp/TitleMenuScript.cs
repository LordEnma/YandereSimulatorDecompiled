using System;
using UnityEngine;

// Token: 0x02000480 RID: 1152
public class TitleMenuScript : MonoBehaviour
{
	// Token: 0x06001F0B RID: 7947 RVA: 0x001B7F18 File Offset: 0x001B6118
	private void Start()
	{
		RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.25f, 1f);
		Time.timeScale = 1f;
	}

	// Token: 0x06001F0C RID: 7948 RVA: 0x001B7F44 File Offset: 0x001B6144
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

	// Token: 0x0400407B RID: 16507
	public ColorCorrectionCurves ColorCorrection;

	// Token: 0x0400407C RID: 16508
	public InputManagerScript InputManager;

	// Token: 0x0400407D RID: 16509
	public TitleSaveFilesScript SaveFiles;

	// Token: 0x0400407E RID: 16510
	public SelectiveGrayscale Grayscale;

	// Token: 0x0400407F RID: 16511
	public TitleSponsorScript Sponsors;

	// Token: 0x04004080 RID: 16512
	public TitleExtrasScript Extras;

	// Token: 0x04004081 RID: 16513
	public PromptBarScript PromptBar;

	// Token: 0x04004082 RID: 16514
	public SSAOEffect SSAO;

	// Token: 0x04004083 RID: 16515
	public JsonScript JSON;

	// Token: 0x04004084 RID: 16516
	public UISprite[] MediumSprites;

	// Token: 0x04004085 RID: 16517
	public UISprite[] LightSprites;

	// Token: 0x04004086 RID: 16518
	public UISprite[] DarkSprites;

	// Token: 0x04004087 RID: 16519
	public UILabel TitleLabel;

	// Token: 0x04004088 RID: 16520
	public UILabel SimulatorLabel;

	// Token: 0x04004089 RID: 16521
	public UILabel[] ColoredLabels;

	// Token: 0x0400408A RID: 16522
	public Color MediumColor;

	// Token: 0x0400408B RID: 16523
	public Color LightColor;

	// Token: 0x0400408C RID: 16524
	public Color DarkColor;

	// Token: 0x0400408D RID: 16525
	public Transform VictimHead;

	// Token: 0x0400408E RID: 16526
	public Transform RightHand;

	// Token: 0x0400408F RID: 16527
	public Transform TwintailL;

	// Token: 0x04004090 RID: 16528
	public Transform TwintailR;

	// Token: 0x04004091 RID: 16529
	public Animation LoveSickYandere;

	// Token: 0x04004092 RID: 16530
	public GameObject BloodProjector;

	// Token: 0x04004093 RID: 16531
	public GameObject LoveSickLogo;

	// Token: 0x04004094 RID: 16532
	public GameObject BloodCamera;

	// Token: 0x04004095 RID: 16533
	public GameObject Yandere;

	// Token: 0x04004096 RID: 16534
	public GameObject Knife;

	// Token: 0x04004097 RID: 16535
	public GameObject Logo;

	// Token: 0x04004098 RID: 16536
	public GameObject Sun;

	// Token: 0x04004099 RID: 16537
	public AudioSource LoveSickMusic;

	// Token: 0x0400409A RID: 16538
	public AudioSource CuteMusic;

	// Token: 0x0400409B RID: 16539
	public AudioSource DarkMusic;

	// Token: 0x0400409C RID: 16540
	public Renderer[] YandereEye;

	// Token: 0x0400409D RID: 16541
	public Material CuteSkybox;

	// Token: 0x0400409E RID: 16542
	public Material DarkSkybox;

	// Token: 0x0400409F RID: 16543
	public Transform Highlight;

	// Token: 0x040040A0 RID: 16544
	public Transform[] Spine;

	// Token: 0x040040A1 RID: 16545
	public Transform[] Arm;

	// Token: 0x040040A2 RID: 16546
	public UISprite Darkness;

	// Token: 0x040040A3 RID: 16547
	public Vector3 PermaPositionL;

	// Token: 0x040040A4 RID: 16548
	public Vector3 PermaPositionR;

	// Token: 0x040040A5 RID: 16549
	public bool NeverChange;

	// Token: 0x040040A6 RID: 16550
	public bool LoveSick;

	// Token: 0x040040A7 RID: 16551
	public bool FadeOut;

	// Token: 0x040040A8 RID: 16552
	public bool Turning;

	// Token: 0x040040A9 RID: 16553
	public bool Fading = true;

	// Token: 0x040040AA RID: 16554
	public int SelectionCount = 8;

	// Token: 0x040040AB RID: 16555
	public int Selected;

	// Token: 0x040040AC RID: 16556
	public float InputTimer;

	// Token: 0x040040AD RID: 16557
	public float FadeSpeed = 1f;

	// Token: 0x040040AE RID: 16558
	public float LateTimer;

	// Token: 0x040040AF RID: 16559
	public float RotationY;

	// Token: 0x040040B0 RID: 16560
	public float RotationZ;

	// Token: 0x040040B1 RID: 16561
	public float Volume;

	// Token: 0x040040B2 RID: 16562
	public float Timer;

	// Token: 0x040040B3 RID: 16563
	public int Phase;
}
