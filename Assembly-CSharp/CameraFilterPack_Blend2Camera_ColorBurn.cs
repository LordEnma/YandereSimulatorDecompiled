using System;
using UnityEngine;

// Token: 0x02000129 RID: 297
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/ColorBurn")]
public class CameraFilterPack_Blend2Camera_ColorBurn : MonoBehaviour
{
	// Token: 0x1700022D RID: 557
	// (get) Token: 0x06000B7A RID: 2938 RVA: 0x0006CFBB File Offset: 0x0006B1BB
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

	// Token: 0x06000B7B RID: 2939 RVA: 0x0006CFF0 File Offset: 0x0006B1F0
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

	// Token: 0x06000B7C RID: 2940 RVA: 0x0006D054 File Offset: 0x0006B254
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

	// Token: 0x06000B7D RID: 2941 RVA: 0x0006D144 File Offset: 0x0006B344
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B7E RID: 2942 RVA: 0x0006D17C File Offset: 0x0006B37C
	private void Update()
	{
	}

	// Token: 0x06000B7F RID: 2943 RVA: 0x0006D17E File Offset: 0x0006B37E
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B80 RID: 2944 RVA: 0x0006D1B6 File Offset: 0x0006B3B6
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

	// Token: 0x04000FA2 RID: 4002
	private string ShaderName = "CameraFilterPack/Blend2Camera_ColorBurn";

	// Token: 0x04000FA3 RID: 4003
	public Shader SCShader;

	// Token: 0x04000FA4 RID: 4004
	public Camera Camera2;

	// Token: 0x04000FA5 RID: 4005
	private float TimeX = 1f;

	// Token: 0x04000FA6 RID: 4006
	private Material SCMaterial;

	// Token: 0x04000FA7 RID: 4007
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FA8 RID: 4008
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FA9 RID: 4009
	private RenderTexture Camera2tex;
}
