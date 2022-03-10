using System;
using UnityEngine;

// Token: 0x0200012A RID: 298
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/ColorDodge")]
public class CameraFilterPack_Blend2Camera_ColorDodge : MonoBehaviour
{
	// Token: 0x1700022E RID: 558
	// (get) Token: 0x06000B82 RID: 2946 RVA: 0x0006D46F File Offset: 0x0006B66F
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

	// Token: 0x06000B83 RID: 2947 RVA: 0x0006D4A4 File Offset: 0x0006B6A4
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

	// Token: 0x06000B84 RID: 2948 RVA: 0x0006D508 File Offset: 0x0006B708
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

	// Token: 0x06000B85 RID: 2949 RVA: 0x0006D5F8 File Offset: 0x0006B7F8
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B86 RID: 2950 RVA: 0x0006D630 File Offset: 0x0006B830
	private void Update()
	{
	}

	// Token: 0x06000B87 RID: 2951 RVA: 0x0006D632 File Offset: 0x0006B832
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B88 RID: 2952 RVA: 0x0006D66A File Offset: 0x0006B86A
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

	// Token: 0x04000FB3 RID: 4019
	private string ShaderName = "CameraFilterPack/Blend2Camera_ColorDodge";

	// Token: 0x04000FB4 RID: 4020
	public Shader SCShader;

	// Token: 0x04000FB5 RID: 4021
	public Camera Camera2;

	// Token: 0x04000FB6 RID: 4022
	private float TimeX = 1f;

	// Token: 0x04000FB7 RID: 4023
	private Material SCMaterial;

	// Token: 0x04000FB8 RID: 4024
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FB9 RID: 4025
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FBA RID: 4026
	private RenderTexture Camera2tex;
}
