using System;
using UnityEngine;

// Token: 0x02000141 RID: 321
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/SoftLight")]
public class CameraFilterPack_Blend2Camera_SoftLight : MonoBehaviour
{
	// Token: 0x17000245 RID: 581
	// (get) Token: 0x06000C39 RID: 3129 RVA: 0x00070D73 File Offset: 0x0006EF73
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

	// Token: 0x06000C3A RID: 3130 RVA: 0x00070DA8 File Offset: 0x0006EFA8
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

	// Token: 0x06000C3B RID: 3131 RVA: 0x00070E0C File Offset: 0x0006F00C
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

	// Token: 0x06000C3C RID: 3132 RVA: 0x00070EFC File Offset: 0x0006F0FC
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C3D RID: 3133 RVA: 0x00070F34 File Offset: 0x0006F134
	private void Update()
	{
	}

	// Token: 0x06000C3E RID: 3134 RVA: 0x00070F36 File Offset: 0x0006F136
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C3F RID: 3135 RVA: 0x00070F6E File Offset: 0x0006F16E
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

	// Token: 0x0400107A RID: 4218
	private string ShaderName = "CameraFilterPack/Blend2Camera_SoftLight";

	// Token: 0x0400107B RID: 4219
	public Shader SCShader;

	// Token: 0x0400107C RID: 4220
	public Camera Camera2;

	// Token: 0x0400107D RID: 4221
	private float TimeX = 1f;

	// Token: 0x0400107E RID: 4222
	private Material SCMaterial;

	// Token: 0x0400107F RID: 4223
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001080 RID: 4224
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001081 RID: 4225
	private RenderTexture Camera2tex;
}
