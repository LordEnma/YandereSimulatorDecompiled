using System;
using UnityEngine;

// Token: 0x02000137 RID: 311
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/LinearBurn")]
public class CameraFilterPack_Blend2Camera_LinearBurn : MonoBehaviour
{
	// Token: 0x1700023B RID: 571
	// (get) Token: 0x06000BEA RID: 3050 RVA: 0x0006F7E7 File Offset: 0x0006D9E7
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

	// Token: 0x06000BEB RID: 3051 RVA: 0x0006F81C File Offset: 0x0006DA1C
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

	// Token: 0x06000BEC RID: 3052 RVA: 0x0006F880 File Offset: 0x0006DA80
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

	// Token: 0x06000BED RID: 3053 RVA: 0x0006F970 File Offset: 0x0006DB70
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BEE RID: 3054 RVA: 0x0006F9A8 File Offset: 0x0006DBA8
	private void Update()
	{
	}

	// Token: 0x06000BEF RID: 3055 RVA: 0x0006F9AA File Offset: 0x0006DBAA
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BF0 RID: 3056 RVA: 0x0006F9E2 File Offset: 0x0006DBE2
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

	// Token: 0x0400102F RID: 4143
	private string ShaderName = "CameraFilterPack/Blend2Camera_LinearBurn";

	// Token: 0x04001030 RID: 4144
	public Shader SCShader;

	// Token: 0x04001031 RID: 4145
	public Camera Camera2;

	// Token: 0x04001032 RID: 4146
	private float TimeX = 1f;

	// Token: 0x04001033 RID: 4147
	private Material SCMaterial;

	// Token: 0x04001034 RID: 4148
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001035 RID: 4149
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001036 RID: 4150
	private RenderTexture Camera2tex;
}
