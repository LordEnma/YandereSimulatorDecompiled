using System;
using UnityEngine;

// Token: 0x02000137 RID: 311
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/LinearBurn")]
public class CameraFilterPack_Blend2Camera_LinearBurn : MonoBehaviour
{
	// Token: 0x1700023B RID: 571
	// (get) Token: 0x06000BE7 RID: 3047 RVA: 0x0006EFBF File Offset: 0x0006D1BF
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

	// Token: 0x06000BE8 RID: 3048 RVA: 0x0006EFF4 File Offset: 0x0006D1F4
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

	// Token: 0x06000BE9 RID: 3049 RVA: 0x0006F058 File Offset: 0x0006D258
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

	// Token: 0x06000BEA RID: 3050 RVA: 0x0006F148 File Offset: 0x0006D348
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BEB RID: 3051 RVA: 0x0006F180 File Offset: 0x0006D380
	private void Update()
	{
	}

	// Token: 0x06000BEC RID: 3052 RVA: 0x0006F182 File Offset: 0x0006D382
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BED RID: 3053 RVA: 0x0006F1BA File Offset: 0x0006D3BA
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

	// Token: 0x0400101C RID: 4124
	private string ShaderName = "CameraFilterPack/Blend2Camera_LinearBurn";

	// Token: 0x0400101D RID: 4125
	public Shader SCShader;

	// Token: 0x0400101E RID: 4126
	public Camera Camera2;

	// Token: 0x0400101F RID: 4127
	private float TimeX = 1f;

	// Token: 0x04001020 RID: 4128
	private Material SCMaterial;

	// Token: 0x04001021 RID: 4129
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001022 RID: 4130
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001023 RID: 4131
	private RenderTexture Camera2tex;
}
