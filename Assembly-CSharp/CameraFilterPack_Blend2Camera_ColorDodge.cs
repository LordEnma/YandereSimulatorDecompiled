using System;
using UnityEngine;

// Token: 0x0200012A RID: 298
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/ColorDodge")]
public class CameraFilterPack_Blend2Camera_ColorDodge : MonoBehaviour
{
	// Token: 0x1700022E RID: 558
	// (get) Token: 0x06000B82 RID: 2946 RVA: 0x0006D327 File Offset: 0x0006B527
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

	// Token: 0x06000B83 RID: 2947 RVA: 0x0006D35C File Offset: 0x0006B55C
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

	// Token: 0x06000B84 RID: 2948 RVA: 0x0006D3C0 File Offset: 0x0006B5C0
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

	// Token: 0x06000B85 RID: 2949 RVA: 0x0006D4B0 File Offset: 0x0006B6B0
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B86 RID: 2950 RVA: 0x0006D4E8 File Offset: 0x0006B6E8
	private void Update()
	{
	}

	// Token: 0x06000B87 RID: 2951 RVA: 0x0006D4EA File Offset: 0x0006B6EA
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B88 RID: 2952 RVA: 0x0006D522 File Offset: 0x0006B722
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

	// Token: 0x04000FAA RID: 4010
	private string ShaderName = "CameraFilterPack/Blend2Camera_ColorDodge";

	// Token: 0x04000FAB RID: 4011
	public Shader SCShader;

	// Token: 0x04000FAC RID: 4012
	public Camera Camera2;

	// Token: 0x04000FAD RID: 4013
	private float TimeX = 1f;

	// Token: 0x04000FAE RID: 4014
	private Material SCMaterial;

	// Token: 0x04000FAF RID: 4015
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FB0 RID: 4016
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FB1 RID: 4017
	private RenderTexture Camera2tex;
}
