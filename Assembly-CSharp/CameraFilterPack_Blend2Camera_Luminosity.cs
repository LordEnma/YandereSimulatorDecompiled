using System;
using UnityEngine;

// Token: 0x0200013A RID: 314
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Luminosity")]
public class CameraFilterPack_Blend2Camera_Luminosity : MonoBehaviour
{
	// Token: 0x1700023E RID: 574
	// (get) Token: 0x06000BFF RID: 3071 RVA: 0x0006F6C7 File Offset: 0x0006D8C7
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

	// Token: 0x06000C00 RID: 3072 RVA: 0x0006F6FC File Offset: 0x0006D8FC
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C01 RID: 3073 RVA: 0x0006F760 File Offset: 0x0006D960
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

	// Token: 0x06000C02 RID: 3074 RVA: 0x0006F850 File Offset: 0x0006DA50
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C03 RID: 3075 RVA: 0x0006F888 File Offset: 0x0006DA88
	private void Update()
	{
	}

	// Token: 0x06000C04 RID: 3076 RVA: 0x0006F88A File Offset: 0x0006DA8A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C05 RID: 3077 RVA: 0x0006F8C2 File Offset: 0x0006DAC2
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

	// Token: 0x04001034 RID: 4148
	private string ShaderName = "CameraFilterPack/Blend2Camera_Luminosity";

	// Token: 0x04001035 RID: 4149
	public Shader SCShader;

	// Token: 0x04001036 RID: 4150
	public Camera Camera2;

	// Token: 0x04001037 RID: 4151
	private float TimeX = 1f;

	// Token: 0x04001038 RID: 4152
	private Material SCMaterial;

	// Token: 0x04001039 RID: 4153
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400103A RID: 4154
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400103B RID: 4155
	private RenderTexture Camera2tex;
}
