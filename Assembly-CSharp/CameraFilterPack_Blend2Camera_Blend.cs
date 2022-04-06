using System;
using UnityEngine;

// Token: 0x02000126 RID: 294
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Blend")]
public class CameraFilterPack_Blend2Camera_Blend : MonoBehaviour
{
	// Token: 0x1700022A RID: 554
	// (get) Token: 0x06000B64 RID: 2916 RVA: 0x0006CF7C File Offset: 0x0006B17C
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

	// Token: 0x06000B65 RID: 2917 RVA: 0x0006CFB0 File Offset: 0x0006B1B0
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

	// Token: 0x06000B66 RID: 2918 RVA: 0x0006D014 File Offset: 0x0006B214
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetTexture("_MainTex2", this.Camera2tex);
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B67 RID: 2919 RVA: 0x0006D0E0 File Offset: 0x0006B2E0
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B68 RID: 2920 RVA: 0x0006D118 File Offset: 0x0006B318
	private void Update()
	{
	}

	// Token: 0x06000B69 RID: 2921 RVA: 0x0006D11A File Offset: 0x0006B31A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B6A RID: 2922 RVA: 0x0006D152 File Offset: 0x0006B352
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

	// Token: 0x04000F95 RID: 3989
	private string ShaderName = "CameraFilterPack/Blend2Camera_Blend";

	// Token: 0x04000F96 RID: 3990
	public Shader SCShader;

	// Token: 0x04000F97 RID: 3991
	public Camera Camera2;

	// Token: 0x04000F98 RID: 3992
	private float TimeX = 1f;

	// Token: 0x04000F99 RID: 3993
	private Material SCMaterial;

	// Token: 0x04000F9A RID: 3994
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000F9B RID: 3995
	private RenderTexture Camera2tex;
}
