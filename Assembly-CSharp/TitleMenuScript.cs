using System;
using UnityEngine;

// Token: 0x02000477 RID: 1143
public class TitleMenuScript : MonoBehaviour
{
	// Token: 0x06001ECC RID: 7884 RVA: 0x001B1668 File Offset: 0x001AF868
	private void Start()
	{
		RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.25f, 1f);
		Time.timeScale = 1f;
	}

	// Token: 0x06001ECD RID: 7885 RVA: 0x001B1694 File Offset: 0x001AF894
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

	// Token: 0x04003FA5 RID: 16293
	public ColorCorrectionCurves ColorCorrection;

	// Token: 0x04003FA6 RID: 16294
	public InputManagerScript InputManager;

	// Token: 0x04003FA7 RID: 16295
	public TitleSaveFilesScript SaveFiles;

	// Token: 0x04003FA8 RID: 16296
	public SelectiveGrayscale Grayscale;

	// Token: 0x04003FA9 RID: 16297
	public TitleSponsorScript Sponsors;

	// Token: 0x04003FAA RID: 16298
	public TitleExtrasScript Extras;

	// Token: 0x04003FAB RID: 16299
	public PromptBarScript PromptBar;

	// Token: 0x04003FAC RID: 16300
	public SSAOEffect SSAO;

	// Token: 0x04003FAD RID: 16301
	public JsonScript JSON;

	// Token: 0x04003FAE RID: 16302
	public UISprite[] MediumSprites;

	// Token: 0x04003FAF RID: 16303
	public UISprite[] LightSprites;

	// Token: 0x04003FB0 RID: 16304
	public UISprite[] DarkSprites;

	// Token: 0x04003FB1 RID: 16305
	public UILabel TitleLabel;

	// Token: 0x04003FB2 RID: 16306
	public UILabel SimulatorLabel;

	// Token: 0x04003FB3 RID: 16307
	public UILabel[] ColoredLabels;

	// Token: 0x04003FB4 RID: 16308
	public Color MediumColor;

	// Token: 0x04003FB5 RID: 16309
	public Color LightColor;

	// Token: 0x04003FB6 RID: 16310
	public Color DarkColor;

	// Token: 0x04003FB7 RID: 16311
	public Transform VictimHead;

	// Token: 0x04003FB8 RID: 16312
	public Transform RightHand;

	// Token: 0x04003FB9 RID: 16313
	public Transform TwintailL;

	// Token: 0x04003FBA RID: 16314
	public Transform TwintailR;

	// Token: 0x04003FBB RID: 16315
	public Animation LoveSickYandere;

	// Token: 0x04003FBC RID: 16316
	public GameObject BloodProjector;

	// Token: 0x04003FBD RID: 16317
	public GameObject LoveSickLogo;

	// Token: 0x04003FBE RID: 16318
	public GameObject BloodCamera;

	// Token: 0x04003FBF RID: 16319
	public GameObject Yandere;

	// Token: 0x04003FC0 RID: 16320
	public GameObject Knife;

	// Token: 0x04003FC1 RID: 16321
	public GameObject Logo;

	// Token: 0x04003FC2 RID: 16322
	public GameObject Sun;

	// Token: 0x04003FC3 RID: 16323
	public AudioSource LoveSickMusic;

	// Token: 0x04003FC4 RID: 16324
	public AudioSource CuteMusic;

	// Token: 0x04003FC5 RID: 16325
	public AudioSource DarkMusic;

	// Token: 0x04003FC6 RID: 16326
	public Renderer[] YandereEye;

	// Token: 0x04003FC7 RID: 16327
	public Material CuteSkybox;

	// Token: 0x04003FC8 RID: 16328
	public Material DarkSkybox;

	// Token: 0x04003FC9 RID: 16329
	public Transform Highlight;

	// Token: 0x04003FCA RID: 16330
	public Transform[] Spine;

	// Token: 0x04003FCB RID: 16331
	public Transform[] Arm;

	// Token: 0x04003FCC RID: 16332
	public UISprite Darkness;

	// Token: 0x04003FCD RID: 16333
	public Vector3 PermaPositionL;

	// Token: 0x04003FCE RID: 16334
	public Vector3 PermaPositionR;

	// Token: 0x04003FCF RID: 16335
	public bool NeverChange;

	// Token: 0x04003FD0 RID: 16336
	public bool LoveSick;

	// Token: 0x04003FD1 RID: 16337
	public bool FadeOut;

	// Token: 0x04003FD2 RID: 16338
	public bool Turning;

	// Token: 0x04003FD3 RID: 16339
	public bool Fading = true;

	// Token: 0x04003FD4 RID: 16340
	public int SelectionCount = 8;

	// Token: 0x04003FD5 RID: 16341
	public int Selected;

	// Token: 0x04003FD6 RID: 16342
	public float InputTimer;

	// Token: 0x04003FD7 RID: 16343
	public float FadeSpeed = 1f;

	// Token: 0x04003FD8 RID: 16344
	public float LateTimer;

	// Token: 0x04003FD9 RID: 16345
	public float RotationY;

	// Token: 0x04003FDA RID: 16346
	public float RotationZ;

	// Token: 0x04003FDB RID: 16347
	public float Volume;

	// Token: 0x04003FDC RID: 16348
	public float Timer;

	// Token: 0x04003FDD RID: 16349
	public int Phase;
}
