using System;
using UnityEngine;

// Token: 0x020001EB RID: 491
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision FX")]
public class CameraFilterPack_NightVisionFX : MonoBehaviour
{
	// Token: 0x170002EF RID: 751
	// (get) Token: 0x0600105E RID: 4190 RVA: 0x00082EFF File Offset: 0x000810FF
	private Material material
	{
		get
		{
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.SCMaterial;
		}
	}

	// Token: 0x0600105F RID: 4191 RVA: 0x00082F33 File Offset: 0x00081133
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/NightVisionFX");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001060 RID: 4192 RVA: 0x00082F54 File Offset: 0x00081154
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_OnOff", this.OnOff);
			this.material.SetFloat("_Greenness", this.Greenness);
			this.material.SetFloat("_Vignette", this.Vignette);
			this.material.SetFloat("_Vignette_Alpha", this.Vignette_Alpha);
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetFloat("_Noise", this.Noise);
			this.material.SetFloat("_Intensity", this.Intensity);
			this.material.SetFloat("_Light", this.Light);
			this.material.SetFloat("_Light2", this.Light2);
			this.material.SetFloat("_Line", this.Line);
			this.material.SetFloat("_Color_R", this.Color_R);
			this.material.SetFloat("_Color_G", this.Color_G);
			this.material.SetFloat("_Color_B", this.Color_B);
			this.material.SetFloat("_Size", this._Binocular_Size);
			this.material.SetFloat("_Dist", this._Binocular_Dist);
			this.material.SetFloat("_Smooth", this._Binocular_Smooth);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001061 RID: 4193 RVA: 0x00083150 File Offset: 0x00081350
	private void Update()
	{
		if (this.PresetMemo != this.Preset)
		{
			this.PresetMemo = this.Preset;
			float[] array = new float[]
			{
				0.757f,
				0.098f,
				0.458f,
				-2.49f,
				0.559f,
				-0.298f,
				1.202f,
				0.515f,
				1f,
				0f,
				0f,
				0f
			};
			float[] array2 = new float[]
			{
				0.2f,
				0.202f,
				0.68f,
				-1.49f,
				0.084f,
				-0.019f,
				2f,
				0.166f,
				1.948f,
				-0.1f,
				0.15f,
				-0.07f
			};
			float[] array3 = new float[]
			{
				1.45f,
				0.01f,
				0.112f,
				-0.07f,
				0.111f,
				-0.077f,
				0.071f,
				0f,
				0.245f,
				0f,
				0f,
				0f
			};
			float[] array4 = new float[]
			{
				0.779f,
				0.185f,
				0.706f,
				1.21f,
				0.24f,
				0.138f,
				2f,
				0.07f,
				1.224f,
				-0.21f,
				-0.34f,
				0f
			};
			float[] array5 = new float[]
			{
				0.2f,
				0.028f,
				0.706f,
				1.21f,
				0.397f,
				-0.24f,
				2f,
				0.298f,
				1.224f,
				-0.08f,
				0.48f,
				-0.57f
			};
			float[] array6 = new float[]
			{
				0.2f,
				0.159f,
				0.622f,
				-2.28f,
				0.409f,
				-0.24f,
				0.166f,
				0.028f,
				2f,
				-0.08f,
				0.22f,
				0.57f
			};
			float[] array7 = new float[]
			{
				2f,
				0.054f,
				1f,
				-2.28f,
				0.409f,
				-1f,
				2f,
				0.187f,
				0.241f,
				0f,
				1.58f,
				0.21f
			};
			float[] array8 = new float[]
			{
				2f,
				0.054f,
				1f,
				1.28f,
				0.409f,
				-1f,
				0.41f,
				0.656f,
				0.427f,
				0.95f,
				-0.35f,
				1.41f
			};
			float[] array9 = new float[]
			{
				2f,
				0.281f,
				0.156f,
				1.85f,
				0.709f,
				-1f,
				0.41f,
				0.109f,
				0.34f,
				0.95f,
				0.36f,
				-0.14f
			};
			float[] array10 = new float[]
			{
				0.905f,
				0.281f,
				0.156f,
				1.85f,
				0.558f,
				-0.974f,
				1.639f,
				0.252f,
				1.074f,
				0.46f,
				0.95f,
				0.58f
			};
			float[] array11 = new float[12];
			if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_FX)
			{
				array11 = array;
			}
			if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_Classic)
			{
				array11 = array2;
			}
			if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_Full)
			{
				array11 = array3;
			}
			if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_Dark)
			{
				array11 = array4;
			}
			if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_Sharp)
			{
				array11 = array5;
			}
			if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_BlueSky)
			{
				array11 = array6;
			}
			if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_Low_Light)
			{
				array11 = array7;
			}
			if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_Pinky)
			{
				array11 = array8;
			}
			if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_RedBurn)
			{
				array11 = array9;
			}
			if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_PurpleShadow)
			{
				array11 = array10;
			}
			if (this.Preset != CameraFilterPack_NightVisionFX.preset.Night_Vision_Personalized)
			{
				this.Greenness = array11[0];
				this.Vignette = array11[1];
				this.Vignette_Alpha = array11[2];
				this.Distortion = array11[3];
				this.Noise = array11[4];
				this.Intensity = array11[5];
				this.Light = array11[6];
				this.Light2 = array11[7];
				this.Line = array11[8];
				this.Color_R = array11[9];
				this.Color_G = array11[10];
				this.Color_B = array11[11];
			}
		}
	}

	// Token: 0x06001062 RID: 4194 RVA: 0x00083349 File Offset: 0x00081549
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014D2 RID: 5330
	public Shader SCShader;

	// Token: 0x040014D3 RID: 5331
	public CameraFilterPack_NightVisionFX.preset Preset;

	// Token: 0x040014D4 RID: 5332
	private CameraFilterPack_NightVisionFX.preset PresetMemo;

	// Token: 0x040014D5 RID: 5333
	private float TimeX = 1f;

	// Token: 0x040014D6 RID: 5334
	private Material SCMaterial;

	// Token: 0x040014D7 RID: 5335
	[Range(0f, 1f)]
	public float OnOff;

	// Token: 0x040014D8 RID: 5336
	[Range(0.2f, 2f)]
	public float Greenness = 1f;

	// Token: 0x040014D9 RID: 5337
	[Range(0f, 1f)]
	public float Vignette = 1f;

	// Token: 0x040014DA RID: 5338
	[Range(0f, 1f)]
	public float Vignette_Alpha = 1f;

	// Token: 0x040014DB RID: 5339
	[Range(-10f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040014DC RID: 5340
	[Range(0f, 1f)]
	public float Noise = 1f;

	// Token: 0x040014DD RID: 5341
	[Range(-2f, 1f)]
	public float Intensity = -1f;

	// Token: 0x040014DE RID: 5342
	[Range(0f, 2f)]
	public float Light = 1f;

	// Token: 0x040014DF RID: 5343
	[Range(0f, 1f)]
	public float Light2 = 1f;

	// Token: 0x040014E0 RID: 5344
	[Range(0f, 2f)]
	public float Line = 1f;

	// Token: 0x040014E1 RID: 5345
	[Range(-2f, 2f)]
	public float Color_R;

	// Token: 0x040014E2 RID: 5346
	[Range(-2f, 2f)]
	public float Color_G;

	// Token: 0x040014E3 RID: 5347
	[Range(-2f, 2f)]
	public float Color_B;

	// Token: 0x040014E4 RID: 5348
	[Range(0f, 1f)]
	public float _Binocular_Size = 0.499f;

	// Token: 0x040014E5 RID: 5349
	[Range(0f, 1f)]
	public float _Binocular_Smooth = 0.113f;

	// Token: 0x040014E6 RID: 5350
	[Range(0f, 1f)]
	public float _Binocular_Dist = 0.286f;

	// Token: 0x0200064E RID: 1614
	public enum preset
	{
		// Token: 0x04004EF4 RID: 20212
		Night_Vision_Personalized = -1,
		// Token: 0x04004EF5 RID: 20213
		Night_Vision_FX,
		// Token: 0x04004EF6 RID: 20214
		Night_Vision_Classic,
		// Token: 0x04004EF7 RID: 20215
		Night_Vision_Full,
		// Token: 0x04004EF8 RID: 20216
		Night_Vision_Dark,
		// Token: 0x04004EF9 RID: 20217
		Night_Vision_Sharp,
		// Token: 0x04004EFA RID: 20218
		Night_Vision_BlueSky,
		// Token: 0x04004EFB RID: 20219
		Night_Vision_Low_Light,
		// Token: 0x04004EFC RID: 20220
		Night_Vision_Pinky,
		// Token: 0x04004EFD RID: 20221
		Night_Vision_RedBurn,
		// Token: 0x04004EFE RID: 20222
		Night_Vision_PurpleShadow
	}
}
