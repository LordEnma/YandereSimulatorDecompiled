using System;
using UnityEngine;

// Token: 0x02000471 RID: 1137
public class TitleMenuScript : MonoBehaviour
{
	// Token: 0x06001E9D RID: 7837 RVA: 0x001AD3E0 File Offset: 0x001AB5E0
	private void Start()
	{
		RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.25f, 1f);
		Time.timeScale = 1f;
	}

	// Token: 0x06001E9E RID: 7838 RVA: 0x001AD40C File Offset: 0x001AB60C
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

	// Token: 0x04003F29 RID: 16169
	public ColorCorrectionCurves ColorCorrection;

	// Token: 0x04003F2A RID: 16170
	public InputManagerScript InputManager;

	// Token: 0x04003F2B RID: 16171
	public TitleSaveFilesScript SaveFiles;

	// Token: 0x04003F2C RID: 16172
	public SelectiveGrayscale Grayscale;

	// Token: 0x04003F2D RID: 16173
	public TitleSponsorScript Sponsors;

	// Token: 0x04003F2E RID: 16174
	public TitleExtrasScript Extras;

	// Token: 0x04003F2F RID: 16175
	public PromptBarScript PromptBar;

	// Token: 0x04003F30 RID: 16176
	public SSAOEffect SSAO;

	// Token: 0x04003F31 RID: 16177
	public JsonScript JSON;

	// Token: 0x04003F32 RID: 16178
	public UISprite[] MediumSprites;

	// Token: 0x04003F33 RID: 16179
	public UISprite[] LightSprites;

	// Token: 0x04003F34 RID: 16180
	public UISprite[] DarkSprites;

	// Token: 0x04003F35 RID: 16181
	public UILabel TitleLabel;

	// Token: 0x04003F36 RID: 16182
	public UILabel SimulatorLabel;

	// Token: 0x04003F37 RID: 16183
	public UILabel[] ColoredLabels;

	// Token: 0x04003F38 RID: 16184
	public Color MediumColor;

	// Token: 0x04003F39 RID: 16185
	public Color LightColor;

	// Token: 0x04003F3A RID: 16186
	public Color DarkColor;

	// Token: 0x04003F3B RID: 16187
	public Transform VictimHead;

	// Token: 0x04003F3C RID: 16188
	public Transform RightHand;

	// Token: 0x04003F3D RID: 16189
	public Transform TwintailL;

	// Token: 0x04003F3E RID: 16190
	public Transform TwintailR;

	// Token: 0x04003F3F RID: 16191
	public Animation LoveSickYandere;

	// Token: 0x04003F40 RID: 16192
	public GameObject BloodProjector;

	// Token: 0x04003F41 RID: 16193
	public GameObject LoveSickLogo;

	// Token: 0x04003F42 RID: 16194
	public GameObject BloodCamera;

	// Token: 0x04003F43 RID: 16195
	public GameObject Yandere;

	// Token: 0x04003F44 RID: 16196
	public GameObject Knife;

	// Token: 0x04003F45 RID: 16197
	public GameObject Logo;

	// Token: 0x04003F46 RID: 16198
	public GameObject Sun;

	// Token: 0x04003F47 RID: 16199
	public AudioSource LoveSickMusic;

	// Token: 0x04003F48 RID: 16200
	public AudioSource CuteMusic;

	// Token: 0x04003F49 RID: 16201
	public AudioSource DarkMusic;

	// Token: 0x04003F4A RID: 16202
	public Renderer[] YandereEye;

	// Token: 0x04003F4B RID: 16203
	public Material CuteSkybox;

	// Token: 0x04003F4C RID: 16204
	public Material DarkSkybox;

	// Token: 0x04003F4D RID: 16205
	public Transform Highlight;

	// Token: 0x04003F4E RID: 16206
	public Transform[] Spine;

	// Token: 0x04003F4F RID: 16207
	public Transform[] Arm;

	// Token: 0x04003F50 RID: 16208
	public UISprite Darkness;

	// Token: 0x04003F51 RID: 16209
	public Vector3 PermaPositionL;

	// Token: 0x04003F52 RID: 16210
	public Vector3 PermaPositionR;

	// Token: 0x04003F53 RID: 16211
	public bool NeverChange;

	// Token: 0x04003F54 RID: 16212
	public bool LoveSick;

	// Token: 0x04003F55 RID: 16213
	public bool FadeOut;

	// Token: 0x04003F56 RID: 16214
	public bool Turning;

	// Token: 0x04003F57 RID: 16215
	public bool Fading = true;

	// Token: 0x04003F58 RID: 16216
	public int SelectionCount = 8;

	// Token: 0x04003F59 RID: 16217
	public int Selected;

	// Token: 0x04003F5A RID: 16218
	public float InputTimer;

	// Token: 0x04003F5B RID: 16219
	public float FadeSpeed = 1f;

	// Token: 0x04003F5C RID: 16220
	public float LateTimer;

	// Token: 0x04003F5D RID: 16221
	public float RotationY;

	// Token: 0x04003F5E RID: 16222
	public float RotationZ;

	// Token: 0x04003F5F RID: 16223
	public float Volume;

	// Token: 0x04003F60 RID: 16224
	public float Timer;

	// Token: 0x04003F61 RID: 16225
	public int Phase;
}
