using System;
using UnityEngine;

// Token: 0x02000137 RID: 311
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/LinearBurn")]
public class CameraFilterPack_Blend2Camera_LinearBurn : MonoBehaviour
{
	// Token: 0x1700023B RID: 571
	// (get) Token: 0x06000BE8 RID: 3048 RVA: 0x0006F36B File Offset: 0x0006D56B
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

	// Token: 0x06000BE9 RID: 3049 RVA: 0x0006F3A0 File Offset: 0x0006D5A0
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

	// Token: 0x06000BEA RID: 3050 RVA: 0x0006F404 File Offset: 0x0006D604
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

	// Token: 0x06000BEB RID: 3051 RVA: 0x0006F4F4 File Offset: 0x0006D6F4
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BEC RID: 3052 RVA: 0x0006F52C File Offset: 0x0006D72C
	private void Update()
	{
	}

	// Token: 0x06000BED RID: 3053 RVA: 0x0006F52E File Offset: 0x0006D72E
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BEE RID: 3054 RVA: 0x0006F566 File Offset: 0x0006D766
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

	// Token: 0x04001028 RID: 4136
	private string ShaderName = "CameraFilterPack/Blend2Camera_LinearBurn";

	// Token: 0x04001029 RID: 4137
	public Shader SCShader;

	// Token: 0x0400102A RID: 4138
	public Camera Camera2;

	// Token: 0x0400102B RID: 4139
	private float TimeX = 1f;

	// Token: 0x0400102C RID: 4140
	private Material SCMaterial;

	// Token: 0x0400102D RID: 4141
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400102E RID: 4142
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400102F RID: 4143
	private RenderTexture Camera2tex;
}
