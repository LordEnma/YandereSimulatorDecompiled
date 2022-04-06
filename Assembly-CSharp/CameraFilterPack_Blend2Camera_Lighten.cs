using System;
using UnityEngine;

// Token: 0x02000135 RID: 309
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Lighten")]
public class CameraFilterPack_Blend2Camera_Lighten : MonoBehaviour
{
	// Token: 0x17000239 RID: 569
	// (get) Token: 0x06000BDA RID: 3034 RVA: 0x0006F337 File Offset: 0x0006D537
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

	// Token: 0x06000BDB RID: 3035 RVA: 0x0006F36C File Offset: 0x0006D56C
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

	// Token: 0x06000BDC RID: 3036 RVA: 0x0006F3D0 File Offset: 0x0006D5D0
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

	// Token: 0x06000BDD RID: 3037 RVA: 0x0006F4C0 File Offset: 0x0006D6C0
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BDE RID: 3038 RVA: 0x0006F4F8 File Offset: 0x0006D6F8
	private void Update()
	{
	}

	// Token: 0x06000BDF RID: 3039 RVA: 0x0006F4FA File Offset: 0x0006D6FA
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BE0 RID: 3040 RVA: 0x0006F532 File Offset: 0x0006D732
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

	// Token: 0x0400101F RID: 4127
	private string ShaderName = "CameraFilterPack/Blend2Camera_Lighten";

	// Token: 0x04001020 RID: 4128
	public Shader SCShader;

	// Token: 0x04001021 RID: 4129
	public Camera Camera2;

	// Token: 0x04001022 RID: 4130
	private float TimeX = 1f;

	// Token: 0x04001023 RID: 4131
	private Material SCMaterial;

	// Token: 0x04001024 RID: 4132
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001025 RID: 4133
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001026 RID: 4134
	private RenderTexture Camera2tex;
}
