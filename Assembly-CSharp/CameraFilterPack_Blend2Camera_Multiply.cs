using System;
using UnityEngine;

// Token: 0x0200013B RID: 315
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Multiply")]
public class CameraFilterPack_Blend2Camera_Multiply : MonoBehaviour
{
	// Token: 0x1700023F RID: 575
	// (get) Token: 0x06000C0A RID: 3082 RVA: 0x00070147 File Offset: 0x0006E347
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

	// Token: 0x06000C0B RID: 3083 RVA: 0x0007017C File Offset: 0x0006E37C
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

	// Token: 0x06000C0C RID: 3084 RVA: 0x000701E0 File Offset: 0x0006E3E0
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

	// Token: 0x06000C0D RID: 3085 RVA: 0x000702D0 File Offset: 0x0006E4D0
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C0E RID: 3086 RVA: 0x00070308 File Offset: 0x0006E508
	private void Update()
	{
	}

	// Token: 0x06000C0F RID: 3087 RVA: 0x0007030A File Offset: 0x0006E50A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C10 RID: 3088 RVA: 0x00070342 File Offset: 0x0006E542
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
	private string ShaderName = "CameraFilterPack/Blend2Camera_Multiply";

	// Token: 0x04001050 RID: 4176
	public Shader SCShader;

	// Token: 0x04001051 RID: 4177
	public Camera Camera2;

	// Token: 0x04001052 RID: 4178
	private float TimeX = 1f;

	// Token: 0x04001053 RID: 4179
	private Material SCMaterial;

	// Token: 0x04001054 RID: 4180
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001055 RID: 4181
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001056 RID: 4182
	private RenderTexture Camera2tex;
}
