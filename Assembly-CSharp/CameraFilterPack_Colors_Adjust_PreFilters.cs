using System;
using UnityEngine;

// Token: 0x02000169 RID: 361
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/ColorsAdjust/Photo Filters")]
public class CameraFilterPack_Colors_Adjust_PreFilters : MonoBehaviour
{
	// Token: 0x1700026D RID: 621
	// (get) Token: 0x06000D33 RID: 3379 RVA: 0x00075056 File Offset: 0x00073256
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

	// Token: 0x06000D34 RID: 3380 RVA: 0x0007508C File Offset: 0x0007328C
	private void ChangeFilters()
	{
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Normal)
		{
			this.Matrix9 = new float[]
			{
				100f,
				0f,
				0f,
				0f,
				100f,
				0f,
				0f,
				0f,
				100f,
				0f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Deuteranomaly)
		{
			this.Matrix9 = new float[]
			{
				80f,
				20f,
				0f,
				25.833f,
				74.167f,
				0f,
				0f,
				14.167f,
				85.833f,
				0f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Protanopia)
		{
			this.Matrix9 = new float[]
			{
				56.667f,
				43.333f,
				0f,
				55.833f,
				44.167f,
				0f,
				0f,
				24.167f,
				75.833f,
				0f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Protanomaly)
		{
			this.Matrix9 = new float[]
			{
				81.667f,
				18.333f,
				0f,
				33.333f,
				66.667f,
				0f,
				0f,
				12.5f,
				87.5f,
				0f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Deuteranopia)
		{
			this.Matrix9 = new float[]
			{
				62.5f,
				37.5f,
				0f,
				70f,
				30f,
				0f,
				0f,
				30f,
				70f,
				0f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Tritanomaly)
		{
			this.Matrix9 = new float[]
			{
				96.667f,
				3.333f,
				0f,
				0f,
				73.333f,
				26.667f,
				0f,
				18.333f,
				81.667f,
				0f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Achromatopsia)
		{
			this.Matrix9 = new float[]
			{
				29.9f,
				58.7f,
				11.4f,
				29.9f,
				58.7f,
				11.4f,
				29.9f,
				58.7f,
				11.4f,
				0f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Achromatomaly)
		{
			this.Matrix9 = new float[]
			{
				61.8f,
				32f,
				6.2f,
				16.3f,
				77.5f,
				6.2f,
				16.3f,
				32f,
				51.6f,
				0f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Tritanopia)
		{
			this.Matrix9 = new float[]
			{
				95f,
				5f,
				0f,
				0f,
				43.333f,
				56.667f,
				0f,
				47.5f,
				52.5f,
				0f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlueLagoon)
		{
			this.Matrix9 = new float[]
			{
				100f,
				102f,
				0f,
				18f,
				100f,
				4f,
				28f,
				-26f,
				100f,
				-64f,
				0f,
				12f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.GoldenPink)
		{
			this.Matrix9 = new float[]
			{
				70f,
				200f,
				0f,
				0f,
				100f,
				8f,
				6f,
				12f,
				110f,
				0f,
				0f,
				-6f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlueMoon)
		{
			this.Matrix9 = new float[]
			{
				200f,
				98f,
				-116f,
				24f,
				100f,
				2f,
				30f,
				52f,
				20f,
				-48f,
				-20f,
				12f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.DarkPink)
		{
			this.Matrix9 = new float[]
			{
				60f,
				112f,
				36f,
				24f,
				100f,
				2f,
				0f,
				-26f,
				100f,
				-56f,
				-20f,
				12f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.RedWhite)
		{
			this.Matrix9 = new float[]
			{
				-42f,
				68f,
				108f,
				-96f,
				100f,
				116f,
				-92f,
				104f,
				96f,
				0f,
				2f,
				4f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.VintageYellow)
		{
			this.Matrix9 = new float[]
			{
				200f,
				109f,
				-104f,
				42f,
				126f,
				-1f,
				-40f,
				121f,
				-31f,
				-48f,
				-20f,
				12f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.NashVille)
		{
			this.Matrix9 = new float[]
			{
				130f,
				8f,
				7f,
				19f,
				89f,
				3f,
				-1f,
				11f,
				57f,
				10f,
				19f,
				47f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.PopRocket)
		{
			this.Matrix9 = new float[]
			{
				100f,
				6f,
				-17f,
				0f,
				107f,
				0f,
				10f,
				21f,
				100f,
				40f,
				0f,
				8f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.RedSoftLight)
		{
			this.Matrix9 = new float[]
			{
				-4f,
				200f,
				-30f,
				-58f,
				200f,
				-30f,
				-58f,
				200f,
				-30f,
				-11f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlackAndWhite_Blue)
		{
			this.Matrix9 = new float[]
			{
				0f,
				0f,
				100f,
				0f,
				0f,
				100f,
				0f,
				0f,
				100f,
				0f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlackAndWhite_Green)
		{
			this.Matrix9 = new float[]
			{
				0f,
				100f,
				0f,
				0f,
				100f,
				0f,
				0f,
				100f,
				0f,
				0f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlackAndWhite_Orange)
		{
			this.Matrix9 = new float[]
			{
				50f,
				50f,
				0f,
				50f,
				50f,
				0f,
				50f,
				50f,
				0f,
				0f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlackAndWhite_Red)
		{
			this.Matrix9 = new float[]
			{
				100f,
				0f,
				0f,
				100f,
				0f,
				0f,
				100f,
				0f,
				0f,
				0f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlackAndWhite_Yellow)
		{
			this.Matrix9 = new float[]
			{
				34f,
				66f,
				0f,
				34f,
				66f,
				0f,
				34f,
				66f,
				0f,
				0f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.YellowSunSet)
		{
			this.Matrix9 = new float[]
			{
				117f,
				-6f,
				53f,
				-68f,
				135f,
				19f,
				-146f,
				-61f,
				200f,
				0f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Walden)
		{
			this.Matrix9 = new float[]
			{
				99f,
				2f,
				13f,
				100f,
				1f,
				40f,
				50f,
				8f,
				71f,
				0f,
				2f,
				7f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.WhiteShine)
		{
			this.Matrix9 = new float[]
			{
				190f,
				24f,
				-33f,
				2f,
				200f,
				-6f,
				-10f,
				27f,
				200f,
				-6f,
				-13f,
				15f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Fluo)
		{
			this.Matrix9 = new float[]
			{
				100f,
				0f,
				0f,
				0f,
				113f,
				0f,
				200f,
				-200f,
				-200f,
				0f,
				0f,
				36f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.MarsSunRise)
		{
			this.Matrix9 = new float[]
			{
				50f,
				141f,
				-81f,
				-17f,
				62f,
				29f,
				-159f,
				-137f,
				-200f,
				7f,
				-34f,
				-6f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Amelie)
		{
			this.Matrix9 = new float[]
			{
				100f,
				11f,
				39f,
				1f,
				63f,
				53f,
				-24f,
				71f,
				20f,
				-25f,
				-10f,
				-24f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlueJeans)
		{
			this.Matrix9 = new float[]
			{
				181f,
				11f,
				15f,
				40f,
				40f,
				20f,
				40f,
				40f,
				20f,
				-59f,
				0f,
				0f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.NightVision)
		{
			this.Matrix9 = new float[]
			{
				200f,
				-200f,
				-200f,
				195f,
				4f,
				-160f,
				200f,
				-200f,
				-200f,
				-200f,
				10f,
				-200f
			};
		}
		if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlueParadise)
		{
			this.Matrix9 = new float[]
			{
				66f,
				200f,
				-200f,
				25f,
				38f,
				36f,
				30f,
				150f,
				114f,
				17f,
				0f,
				65f
			};
		}
	}

	// Token: 0x06000D35 RID: 3381 RVA: 0x000754CF File Offset: 0x000736CF
	private void Start()
	{
		this.ChangeFilters();
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D36 RID: 3382 RVA: 0x000754F8 File Offset: 0x000736F8
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
			this.material.SetFloat("_Red_R", this.Matrix9[0] / 100f);
			this.material.SetFloat("_Red_G", this.Matrix9[1] / 100f);
			this.material.SetFloat("_Red_B", this.Matrix9[2] / 100f);
			this.material.SetFloat("_Green_R", this.Matrix9[3] / 100f);
			this.material.SetFloat("_Green_G", this.Matrix9[4] / 100f);
			this.material.SetFloat("_Green_B", this.Matrix9[5] / 100f);
			this.material.SetFloat("_Blue_R", this.Matrix9[6] / 100f);
			this.material.SetFloat("_Blue_G", this.Matrix9[7] / 100f);
			this.material.SetFloat("_Blue_B", this.Matrix9[8] / 100f);
			this.material.SetFloat("_Red_C", this.Matrix9[9] / 100f);
			this.material.SetFloat("_Green_C", this.Matrix9[10] / 100f);
			this.material.SetFloat("_Blue_C", this.Matrix9[11] / 100f);
			this.material.SetFloat("_FadeFX", this.FadeFX);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D37 RID: 3383 RVA: 0x00075719 File Offset: 0x00073919
	private void OnValidate()
	{
		this.ChangeFilters();
	}

	// Token: 0x06000D38 RID: 3384 RVA: 0x00075721 File Offset: 0x00073921
	private void Update()
	{
	}

	// Token: 0x06000D39 RID: 3385 RVA: 0x00075723 File Offset: 0x00073923
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001182 RID: 4482
	private string ShaderName = "CameraFilterPack/Colors_Adjust_PreFilters";

	// Token: 0x04001183 RID: 4483
	public Shader SCShader;

	// Token: 0x04001184 RID: 4484
	public CameraFilterPack_Colors_Adjust_PreFilters.filters filterchoice;

	// Token: 0x04001185 RID: 4485
	[Range(0f, 1f)]
	public float FadeFX = 1f;

	// Token: 0x04001186 RID: 4486
	private float TimeX = 1f;

	// Token: 0x04001187 RID: 4487
	private Material SCMaterial;

	// Token: 0x04001188 RID: 4488
	private float[] Matrix9;

	// Token: 0x0200064B RID: 1611
	public enum filters
	{
		// Token: 0x04004EC0 RID: 20160
		Normal,
		// Token: 0x04004EC1 RID: 20161
		BlueLagoon,
		// Token: 0x04004EC2 RID: 20162
		BlueMoon,
		// Token: 0x04004EC3 RID: 20163
		RedWhite,
		// Token: 0x04004EC4 RID: 20164
		NashVille,
		// Token: 0x04004EC5 RID: 20165
		VintageYellow,
		// Token: 0x04004EC6 RID: 20166
		GoldenPink,
		// Token: 0x04004EC7 RID: 20167
		DarkPink,
		// Token: 0x04004EC8 RID: 20168
		PopRocket,
		// Token: 0x04004EC9 RID: 20169
		RedSoftLight,
		// Token: 0x04004ECA RID: 20170
		YellowSunSet,
		// Token: 0x04004ECB RID: 20171
		Walden,
		// Token: 0x04004ECC RID: 20172
		WhiteShine,
		// Token: 0x04004ECD RID: 20173
		Fluo,
		// Token: 0x04004ECE RID: 20174
		MarsSunRise,
		// Token: 0x04004ECF RID: 20175
		Amelie,
		// Token: 0x04004ED0 RID: 20176
		BlueJeans,
		// Token: 0x04004ED1 RID: 20177
		NightVision,
		// Token: 0x04004ED2 RID: 20178
		BlueParadise,
		// Token: 0x04004ED3 RID: 20179
		Blindness_Deuteranomaly,
		// Token: 0x04004ED4 RID: 20180
		Blindness_Protanopia,
		// Token: 0x04004ED5 RID: 20181
		Blindness_Protanomaly,
		// Token: 0x04004ED6 RID: 20182
		Blindness_Deuteranopia,
		// Token: 0x04004ED7 RID: 20183
		Blindness_Tritanomaly,
		// Token: 0x04004ED8 RID: 20184
		Blindness_Achromatopsia,
		// Token: 0x04004ED9 RID: 20185
		Blindness_Achromatomaly,
		// Token: 0x04004EDA RID: 20186
		Blindness_Tritanopia,
		// Token: 0x04004EDB RID: 20187
		BlackAndWhite_Blue,
		// Token: 0x04004EDC RID: 20188
		BlackAndWhite_Green,
		// Token: 0x04004EDD RID: 20189
		BlackAndWhite_Orange,
		// Token: 0x04004EDE RID: 20190
		BlackAndWhite_Red,
		// Token: 0x04004EDF RID: 20191
		BlackAndWhite_Yellow
	}
}
