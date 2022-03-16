using System;
using UnityEngine;

// Token: 0x0200047A RID: 1146
public class TitleMenuScript : MonoBehaviour
{
	// Token: 0x06001EE1 RID: 7905 RVA: 0x001B34E0 File Offset: 0x001B16E0
	private void Start()
	{
		RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.25f, 1f);
		Time.timeScale = 1f;
	}

	// Token: 0x06001EE2 RID: 7906 RVA: 0x001B350C File Offset: 0x001B170C
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

	// Token: 0x04004007 RID: 16391
	public ColorCorrectionCurves ColorCorrection;

	// Token: 0x04004008 RID: 16392
	public InputManagerScript InputManager;

	// Token: 0x04004009 RID: 16393
	public TitleSaveFilesScript SaveFiles;

	// Token: 0x0400400A RID: 16394
	public SelectiveGrayscale Grayscale;

	// Token: 0x0400400B RID: 16395
	public TitleSponsorScript Sponsors;

	// Token: 0x0400400C RID: 16396
	public TitleExtrasScript Extras;

	// Token: 0x0400400D RID: 16397
	public PromptBarScript PromptBar;

	// Token: 0x0400400E RID: 16398
	public SSAOEffect SSAO;

	// Token: 0x0400400F RID: 16399
	public JsonScript JSON;

	// Token: 0x04004010 RID: 16400
	public UISprite[] MediumSprites;

	// Token: 0x04004011 RID: 16401
	public UISprite[] LightSprites;

	// Token: 0x04004012 RID: 16402
	public UISprite[] DarkSprites;

	// Token: 0x04004013 RID: 16403
	public UILabel TitleLabel;

	// Token: 0x04004014 RID: 16404
	public UILabel SimulatorLabel;

	// Token: 0x04004015 RID: 16405
	public UILabel[] ColoredLabels;

	// Token: 0x04004016 RID: 16406
	public Color MediumColor;

	// Token: 0x04004017 RID: 16407
	public Color LightColor;

	// Token: 0x04004018 RID: 16408
	public Color DarkColor;

	// Token: 0x04004019 RID: 16409
	public Transform VictimHead;

	// Token: 0x0400401A RID: 16410
	public Transform RightHand;

	// Token: 0x0400401B RID: 16411
	public Transform TwintailL;

	// Token: 0x0400401C RID: 16412
	public Transform TwintailR;

	// Token: 0x0400401D RID: 16413
	public Animation LoveSickYandere;

	// Token: 0x0400401E RID: 16414
	public GameObject BloodProjector;

	// Token: 0x0400401F RID: 16415
	public GameObject LoveSickLogo;

	// Token: 0x04004020 RID: 16416
	public GameObject BloodCamera;

	// Token: 0x04004021 RID: 16417
	public GameObject Yandere;

	// Token: 0x04004022 RID: 16418
	public GameObject Knife;

	// Token: 0x04004023 RID: 16419
	public GameObject Logo;

	// Token: 0x04004024 RID: 16420
	public GameObject Sun;

	// Token: 0x04004025 RID: 16421
	public AudioSource LoveSickMusic;

	// Token: 0x04004026 RID: 16422
	public AudioSource CuteMusic;

	// Token: 0x04004027 RID: 16423
	public AudioSource DarkMusic;

	// Token: 0x04004028 RID: 16424
	public Renderer[] YandereEye;

	// Token: 0x04004029 RID: 16425
	public Material CuteSkybox;

	// Token: 0x0400402A RID: 16426
	public Material DarkSkybox;

	// Token: 0x0400402B RID: 16427
	public Transform Highlight;

	// Token: 0x0400402C RID: 16428
	public Transform[] Spine;

	// Token: 0x0400402D RID: 16429
	public Transform[] Arm;

	// Token: 0x0400402E RID: 16430
	public UISprite Darkness;

	// Token: 0x0400402F RID: 16431
	public Vector3 PermaPositionL;

	// Token: 0x04004030 RID: 16432
	public Vector3 PermaPositionR;

	// Token: 0x04004031 RID: 16433
	public bool NeverChange;

	// Token: 0x04004032 RID: 16434
	public bool LoveSick;

	// Token: 0x04004033 RID: 16435
	public bool FadeOut;

	// Token: 0x04004034 RID: 16436
	public bool Turning;

	// Token: 0x04004035 RID: 16437
	public bool Fading = true;

	// Token: 0x04004036 RID: 16438
	public int SelectionCount = 8;

	// Token: 0x04004037 RID: 16439
	public int Selected;

	// Token: 0x04004038 RID: 16440
	public float InputTimer;

	// Token: 0x04004039 RID: 16441
	public float FadeSpeed = 1f;

	// Token: 0x0400403A RID: 16442
	public float LateTimer;

	// Token: 0x0400403B RID: 16443
	public float RotationY;

	// Token: 0x0400403C RID: 16444
	public float RotationZ;

	// Token: 0x0400403D RID: 16445
	public float Volume;

	// Token: 0x0400403E RID: 16446
	public float Timer;

	// Token: 0x0400403F RID: 16447
	public int Phase;
}
