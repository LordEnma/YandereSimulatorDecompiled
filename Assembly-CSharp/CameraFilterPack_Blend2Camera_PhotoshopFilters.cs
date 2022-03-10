using System;
using UnityEngine;

// Token: 0x0200013D RID: 317
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/PhotoshopFilters")]
public class CameraFilterPack_Blend2Camera_PhotoshopFilters : MonoBehaviour
{
	// Token: 0x17000241 RID: 577
	// (get) Token: 0x06000C18 RID: 3096 RVA: 0x0007017B File Offset: 0x0006E37B
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

	// Token: 0x06000C19 RID: 3097 RVA: 0x000701B0 File Offset: 0x0006E3B0
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

	// Token: 0x06000C1A RID: 3098 RVA: 0x000703C0 File Offset: 0x0006E5C0
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

	// Token: 0x06000C1B RID: 3099 RVA: 0x00070438 File Offset: 0x0006E638
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

	// Token: 0x06000C1C RID: 3100 RVA: 0x00070528 File Offset: 0x0006E728
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

	// Token: 0x06000C1D RID: 3101 RVA: 0x000705D3 File Offset: 0x0006E7D3
	private void Update()
	{
	}

	// Token: 0x06000C1E RID: 3102 RVA: 0x000705D5 File Offset: 0x0006E7D5
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C1F RID: 3103 RVA: 0x0007060D File Offset: 0x0006E80D
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

	// Token: 0x04001058 RID: 4184
	private string ShaderName = "CameraFilterPack/Blend2Camera_Darken";

	// Token: 0x04001059 RID: 4185
	public Shader SCShader;

	// Token: 0x0400105A RID: 4186
	public Camera Camera2;

	// Token: 0x0400105B RID: 4187
	public CameraFilterPack_Blend2Camera_PhotoshopFilters.filters filterchoice;

	// Token: 0x0400105C RID: 4188
	private CameraFilterPack_Blend2Camera_PhotoshopFilters.filters filterchoicememo;

	// Token: 0x0400105D RID: 4189
	private float TimeX = 1f;

	// Token: 0x0400105E RID: 4190
	private Material SCMaterial;

	// Token: 0x0400105F RID: 4191
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001060 RID: 4192
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001061 RID: 4193
	private RenderTexture Camera2tex;

	// Token: 0x0200064C RID: 1612
	public enum filters
	{
		// Token: 0x04004ED3 RID: 20179
		Darken,
		// Token: 0x04004ED4 RID: 20180
		Multiply,
		// Token: 0x04004ED5 RID: 20181
		ColorBurn,
		// Token: 0x04004ED6 RID: 20182
		LinearBurn,
		// Token: 0x04004ED7 RID: 20183
		DarkerColor,
		// Token: 0x04004ED8 RID: 20184
		Lighten,
		// Token: 0x04004ED9 RID: 20185
		Screen,
		// Token: 0x04004EDA RID: 20186
		ColorDodge,
		// Token: 0x04004EDB RID: 20187
		LinearDodge,
		// Token: 0x04004EDC RID: 20188
		LighterColor,
		// Token: 0x04004EDD RID: 20189
		Overlay,
		// Token: 0x04004EDE RID: 20190
		SoftLight,
		// Token: 0x04004EDF RID: 20191
		HardLight,
		// Token: 0x04004EE0 RID: 20192
		VividLight,
		// Token: 0x04004EE1 RID: 20193
		LinearLight,
		// Token: 0x04004EE2 RID: 20194
		PinLight,
		// Token: 0x04004EE3 RID: 20195
		HardMix,
		// Token: 0x04004EE4 RID: 20196
		Difference,
		// Token: 0x04004EE5 RID: 20197
		Exclusion,
		// Token: 0x04004EE6 RID: 20198
		Subtract,
		// Token: 0x04004EE7 RID: 20199
		Divide,
		// Token: 0x04004EE8 RID: 20200
		Hue,
		// Token: 0x04004EE9 RID: 20201
		Saturation,
		// Token: 0x04004EEA RID: 20202
		Color,
		// Token: 0x04004EEB RID: 20203
		Luminosity
	}
}
