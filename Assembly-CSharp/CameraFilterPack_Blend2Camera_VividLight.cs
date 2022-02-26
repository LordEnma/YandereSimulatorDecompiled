using System;
using UnityEngine;

// Token: 0x02000145 RID: 325
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/VividLight")]
public class CameraFilterPack_Blend2Camera_VividLight : MonoBehaviour
{
	// Token: 0x17000249 RID: 585
	// (get) Token: 0x06000C59 RID: 3161 RVA: 0x000716D7 File Offset: 0x0006F8D7
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

	// Token: 0x06000C5A RID: 3162 RVA: 0x0007170C File Offset: 0x0006F90C
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

	// Token: 0x06000C5B RID: 3163 RVA: 0x00071770 File Offset: 0x0006F970
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

	// Token: 0x06000C5C RID: 3164 RVA: 0x00071860 File Offset: 0x0006FA60
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C5D RID: 3165 RVA: 0x00071898 File Offset: 0x0006FA98
	private void Update()
	{
	}

	// Token: 0x06000C5E RID: 3166 RVA: 0x0007189A File Offset: 0x0006FA9A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C5F RID: 3167 RVA: 0x000718D2 File Offset: 0x0006FAD2
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

	// Token: 0x040010A0 RID: 4256
	private string ShaderName = "CameraFilterPack/Blend2Camera_VividLight";

	// Token: 0x040010A1 RID: 4257
	public Shader SCShader;

	// Token: 0x040010A2 RID: 4258
	public Camera Camera2;

	// Token: 0x040010A3 RID: 4259
	private float TimeX = 1f;

	// Token: 0x040010A4 RID: 4260
	private Material SCMaterial;

	// Token: 0x040010A5 RID: 4261
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x040010A6 RID: 4262
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x040010A7 RID: 4263
	private RenderTexture Camera2tex;
}
