using System;
using UnityEngine;

// Token: 0x02000128 RID: 296
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Color")]
public class CameraFilterPack_Blend2Camera_Color : MonoBehaviour
{
	// Token: 0x1700022C RID: 556
	// (get) Token: 0x06000B74 RID: 2932 RVA: 0x0006D43C File Offset: 0x0006B63C
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

	// Token: 0x06000B75 RID: 2933 RVA: 0x0006D470 File Offset: 0x0006B670
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

	// Token: 0x06000B76 RID: 2934 RVA: 0x0006D4D4 File Offset: 0x0006B6D4
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

	// Token: 0x06000B77 RID: 2935 RVA: 0x0006D5C4 File Offset: 0x0006B7C4
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B78 RID: 2936 RVA: 0x0006D5FC File Offset: 0x0006B7FC
	private void Update()
	{
	}

	// Token: 0x06000B79 RID: 2937 RVA: 0x0006D5FE File Offset: 0x0006B7FE
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B7A RID: 2938 RVA: 0x0006D636 File Offset: 0x0006B836
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
	private string ShaderName = "CameraFilterPack/Blend2Camera_Color";

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
