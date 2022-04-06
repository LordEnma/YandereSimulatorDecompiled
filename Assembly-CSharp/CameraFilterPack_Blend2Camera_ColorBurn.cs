using System;
using UnityEngine;

// Token: 0x02000129 RID: 297
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/ColorBurn")]
public class CameraFilterPack_Blend2Camera_ColorBurn : MonoBehaviour
{
	// Token: 0x1700022D RID: 557
	// (get) Token: 0x06000B7C RID: 2940 RVA: 0x0006D693 File Offset: 0x0006B893
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

	// Token: 0x06000B7D RID: 2941 RVA: 0x0006D6C8 File Offset: 0x0006B8C8
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

	// Token: 0x06000B7E RID: 2942 RVA: 0x0006D72C File Offset: 0x0006B92C
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

	// Token: 0x06000B7F RID: 2943 RVA: 0x0006D81C File Offset: 0x0006BA1C
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B80 RID: 2944 RVA: 0x0006D854 File Offset: 0x0006BA54
	private void Update()
	{
	}

	// Token: 0x06000B81 RID: 2945 RVA: 0x0006D856 File Offset: 0x0006BA56
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B82 RID: 2946 RVA: 0x0006D88E File Offset: 0x0006BA8E
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

	// Token: 0x04000FB2 RID: 4018
	private string ShaderName = "CameraFilterPack/Blend2Camera_ColorBurn";

	// Token: 0x04000FB3 RID: 4019
	public Shader SCShader;

	// Token: 0x04000FB4 RID: 4020
	public Camera Camera2;

	// Token: 0x04000FB5 RID: 4021
	private float TimeX = 1f;

	// Token: 0x04000FB6 RID: 4022
	private Material SCMaterial;

	// Token: 0x04000FB7 RID: 4023
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FB8 RID: 4024
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FB9 RID: 4025
	private RenderTexture Camera2tex;
}
