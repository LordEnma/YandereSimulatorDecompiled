using System;
using UnityEngine;

// Token: 0x02000140 RID: 320
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Screen")]
public class CameraFilterPack_Blend2Camera_Screen : MonoBehaviour
{
	// Token: 0x17000244 RID: 580
	// (get) Token: 0x06000C31 RID: 3121 RVA: 0x000708BF File Offset: 0x0006EABF
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

	// Token: 0x06000C32 RID: 3122 RVA: 0x000708F4 File Offset: 0x0006EAF4
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

	// Token: 0x06000C33 RID: 3123 RVA: 0x00070958 File Offset: 0x0006EB58
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

	// Token: 0x06000C34 RID: 3124 RVA: 0x00070A48 File Offset: 0x0006EC48
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C35 RID: 3125 RVA: 0x00070A80 File Offset: 0x0006EC80
	private void Update()
	{
	}

	// Token: 0x06000C36 RID: 3126 RVA: 0x00070A82 File Offset: 0x0006EC82
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C37 RID: 3127 RVA: 0x00070ABA File Offset: 0x0006ECBA
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
	private string ShaderName = "CameraFilterPack/Blend2Camera_Screen";

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
