using System;
using UnityEngine;

// Token: 0x0200013D RID: 317
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/PhotoshopFilters")]
public class CameraFilterPack_Blend2Camera_PhotoshopFilters : MonoBehaviour
{
	// Token: 0x17000241 RID: 577
	// (get) Token: 0x06000C18 RID: 3096 RVA: 0x0006FF1F File Offset: 0x0006E11F
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

	// Token: 0x06000C19 RID: 3097 RVA: 0x0006FF54 File Offset: 0x0006E154
	private void ChangeFilters()
	{
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Darken)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_Darken";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Multiply)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_Multiply";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.ColorBurn)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_ColorBurn";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.LinearBurn)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_LinearBurn";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.DarkerColor)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_DarkerColor";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Lighten)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_Lighten";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Screen)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_Screen";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.ColorDodge)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_ColorDodge";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.LinearDodge)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_LinearDodge";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.LighterColor)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_LighterColor";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Overlay)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_Overlay";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.SoftLight)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_SoftLight";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.HardLight)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_HardLight";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.VividLight)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_VividLight";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.LinearLight)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_LinearLight";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.PinLight)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_PinLight";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.HardMix)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_HardMix";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Difference)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_Difference";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Exclusion)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_Exclusion";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Subtract)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_Subtract";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Divide)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_Divide";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Hue)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_Hue";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Saturation)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_Saturation";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Color)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_Color";
		}
		if (this.filterchoice == CameraFilterPack_Blend2Camera_PhotoshopFilters.filters.Luminosity)
		{
			this.ShaderName = "CameraFilterPack/Blend2Camera_Luminosity";
		}
	}

	// Token: 0x06000C1A RID: 3098 RVA: 0x00070164 File Offset: 0x0006E364
	private void Start()
	{
		this.filterchoicememo = this.filterchoice;
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.ChangeFilters();
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C1B RID: 3099 RVA: 0x000701DC File Offset: 0x0006E3DC
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			if (this.Camera2 != null)
			{
				this.material.SetTexture("_MainTex2", this.Camera2tex);
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetFloat("_Value2", this.SwitchCameraToCamera2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C1C RID: 3100 RVA: 0x000702CC File Offset: 0x0006E4CC
	private void OnValidate()
	{
		if (this.filterchoice != this.filterchoicememo)
		{
			this.ChangeFilters();
			this.SCShader = Shader.Find(this.ShaderName);
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
		}
		this.filterchoicememo = this.filterchoice;
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C1D RID: 3101 RVA: 0x00070377 File Offset: 0x0006E577
	private void Update()
	{
	}

	// Token: 0x06000C1E RID: 3102 RVA: 0x00070379 File Offset: 0x0006E579
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C1F RID: 3103 RVA: 0x000703B1 File Offset: 0x0006E5B1
	private void OnDisable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2.targetTexture = null;
		}
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400104F RID: 4175
	private string ShaderName = "CameraFilterPack/Blend2Camera_Darken";

	// Token: 0x04001050 RID: 4176
	public Shader SCShader;

	// Token: 0x04001051 RID: 4177
	public Camera Camera2;

	// Token: 0x04001052 RID: 4178
	public CameraFilterPack_Blend2Camera_PhotoshopFilters.filters filterchoice;

	// Token: 0x04001053 RID: 4179
	private CameraFilterPack_Blend2Camera_PhotoshopFilters.filters filterchoicememo;

	// Token: 0x04001054 RID: 4180
	private float TimeX = 1f;

	// Token: 0x04001055 RID: 4181
	private Material SCMaterial;

	// Token: 0x04001056 RID: 4182
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001057 RID: 4183
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001058 RID: 4184
	private RenderTexture Camera2tex;

	// Token: 0x0200064A RID: 1610
	public enum filters
	{
		// Token: 0x04004EA6 RID: 20134
		Darken,
		// Token: 0x04004EA7 RID: 20135
		Multiply,
		// Token: 0x04004EA8 RID: 20136
		ColorBurn,
		// Token: 0x04004EA9 RID: 20137
		LinearBurn,
		// Token: 0x04004EAA RID: 20138
		DarkerColor,
		// Token: 0x04004EAB RID: 20139
		Lighten,
		// Token: 0x04004EAC RID: 20140
		Screen,
		// Token: 0x04004EAD RID: 20141
		ColorDodge,
		// Token: 0x04004EAE RID: 20142
		LinearDodge,
		// Token: 0x04004EAF RID: 20143
		LighterColor,
		// Token: 0x04004EB0 RID: 20144
		Overlay,
		// Token: 0x04004EB1 RID: 20145
		SoftLight,
		// Token: 0x04004EB2 RID: 20146
		HardLight,
		// Token: 0x04004EB3 RID: 20147
		VividLight,
		// Token: 0x04004EB4 RID: 20148
		LinearLight,
		// Token: 0x04004EB5 RID: 20149
		PinLight,
		// Token: 0x04004EB6 RID: 20150
		HardMix,
		// Token: 0x04004EB7 RID: 20151
		Difference,
		// Token: 0x04004EB8 RID: 20152
		Exclusion,
		// Token: 0x04004EB9 RID: 20153
		Subtract,
		// Token: 0x04004EBA RID: 20154
		Divide,
		// Token: 0x04004EBB RID: 20155
		Hue,
		// Token: 0x04004EBC RID: 20156
		Saturation,
		// Token: 0x04004EBD RID: 20157
		Color,
		// Token: 0x04004EBE RID: 20158
		Luminosity
	}
}
