using System;
using UnityEngine;

// Token: 0x0200013E RID: 318
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/PinLight")]
public class CameraFilterPack_Blend2Camera_PinLight : MonoBehaviour
{
	// Token: 0x17000242 RID: 578
	// (get) Token: 0x06000C23 RID: 3107 RVA: 0x00070AE6 File Offset: 0x0006ECE6
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

	// Token: 0x06000C24 RID: 3108 RVA: 0x00070B1C File Offset: 0x0006ED1C
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

	// Token: 0x06000C25 RID: 3109 RVA: 0x00070B80 File Offset: 0x0006ED80
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

	// Token: 0x06000C26 RID: 3110 RVA: 0x00070C70 File Offset: 0x0006EE70
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C27 RID: 3111 RVA: 0x00070CA8 File Offset: 0x0006EEA8
	private void Update()
	{
	}

	// Token: 0x06000C28 RID: 3112 RVA: 0x00070CAA File Offset: 0x0006EEAA
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C29 RID: 3113 RVA: 0x00070CE2 File Offset: 0x0006EEE2
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

	// Token: 0x04001069 RID: 4201
	private string ShaderName = "CameraFilterPack/Blend2Camera_PinLight";

	// Token: 0x0400106A RID: 4202
	public Shader SCShader;

	// Token: 0x0400106B RID: 4203
	public Camera Camera2;

	// Token: 0x0400106C RID: 4204
	private float TimeX = 1f;

	// Token: 0x0400106D RID: 4205
	private Material SCMaterial;

	// Token: 0x0400106E RID: 4206
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400106F RID: 4207
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001070 RID: 4208
	private RenderTexture Camera2tex;
}
