using System;
using UnityEngine;

// Token: 0x02000168 RID: 360
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/ColorsAdjust/Photo Filters")]
public class CameraFilterPack_Colors_Adjust_PreFilters : MonoBehaviour
{
	// Token: 0x1700026D RID: 621
	// (get) Token: 0x06000D2F RID: 3375 RVA: 0x00074D0E File Offset: 0x00072F0E
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

	// Token: 0x06000D30 RID: 3376 RVA: 0x00074D44 File Offset: 0x00072F44
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

	// Token: 0x06000D31 RID: 3377 RVA: 0x00075187 File Offset: 0x00073387
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

	// Token: 0x06000D32 RID: 3378 RVA: 0x000751B0 File Offset: 0x000733B0
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

	// Token: 0x06000D33 RID: 3379 RVA: 0x000753D1 File Offset: 0x000735D1
	private void OnValidate()
	{
		this.ChangeFilters();
	}

	// Token: 0x06000D34 RID: 3380 RVA: 0x000753D9 File Offset: 0x000735D9
	private void Update()
	{
	}

	// Token: 0x06000D35 RID: 3381 RVA: 0x000753DB File Offset: 0x000735DB
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400117A RID: 4474
	private string ShaderName = "CameraFilterPack/Colors_Adjust_PreFilters";

	// Token: 0x0400117B RID: 4475
	public Shader SCShader;

	// Token: 0x0400117C RID: 4476
	public CameraFilterPack_Colors_Adjust_PreFilters.filters filterchoice;

	// Token: 0x0400117D RID: 4477
	[Range(0f, 1f)]
	public float FadeFX = 1f;

	// Token: 0x0400117E RID: 4478
	private float TimeX = 1f;

	// Token: 0x0400117F RID: 4479
	private Material SCMaterial;

	// Token: 0x04001180 RID: 4480
	private float[] Matrix9;

	// Token: 0x0200064B RID: 1611
	public enum filters
	{
		// Token: 0x04004E6E RID: 20078
		Normal,
		// Token: 0x04004E6F RID: 20079
		BlueLagoon,
		// Token: 0x04004E70 RID: 20080
		BlueMoon,
		// Token: 0x04004E71 RID: 20081
		RedWhite,
		// Token: 0x04004E72 RID: 20082
		NashVille,
		// Token: 0x04004E73 RID: 20083
		VintageYellow,
		// Token: 0x04004E74 RID: 20084
		GoldenPink,
		// Token: 0x04004E75 RID: 20085
		DarkPink,
		// Token: 0x04004E76 RID: 20086
		PopRocket,
		// Token: 0x04004E77 RID: 20087
		RedSoftLight,
		// Token: 0x04004E78 RID: 20088
		YellowSunSet,
		// Token: 0x04004E79 RID: 20089
		Walden,
		// Token: 0x04004E7A RID: 20090
		WhiteShine,
		// Token: 0x04004E7B RID: 20091
		Fluo,
		// Token: 0x04004E7C RID: 20092
		MarsSunRise,
		// Token: 0x04004E7D RID: 20093
		Amelie,
		// Token: 0x04004E7E RID: 20094
		BlueJeans,
		// Token: 0x04004E7F RID: 20095
		NightVision,
		// Token: 0x04004E80 RID: 20096
		BlueParadise,
		// Token: 0x04004E81 RID: 20097
		Blindness_Deuteranomaly,
		// Token: 0x04004E82 RID: 20098
		Blindness_Protanopia,
		// Token: 0x04004E83 RID: 20099
		Blindness_Protanomaly,
		// Token: 0x04004E84 RID: 20100
		Blindness_Deuteranopia,
		// Token: 0x04004E85 RID: 20101
		Blindness_Tritanomaly,
		// Token: 0x04004E86 RID: 20102
		Blindness_Achromatopsia,
		// Token: 0x04004E87 RID: 20103
		Blindness_Achromatomaly,
		// Token: 0x04004E88 RID: 20104
		Blindness_Tritanopia,
		// Token: 0x04004E89 RID: 20105
		BlackAndWhite_Blue,
		// Token: 0x04004E8A RID: 20106
		BlackAndWhite_Green,
		// Token: 0x04004E8B RID: 20107
		BlackAndWhite_Orange,
		// Token: 0x04004E8C RID: 20108
		BlackAndWhite_Red,
		// Token: 0x04004E8D RID: 20109
		BlackAndWhite_Yellow
	}
}
