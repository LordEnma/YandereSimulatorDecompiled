using System;
using UnityEngine;

// Token: 0x02000135 RID: 309
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Lighten")]
public class CameraFilterPack_Blend2Camera_Lighten : MonoBehaviour
{
	// Token: 0x17000239 RID: 569
	// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x0006EEBB File Offset: 0x0006D0BB
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

	// Token: 0x06000BD9 RID: 3033 RVA: 0x0006EEF0 File Offset: 0x0006D0F0
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

	// Token: 0x06000BDA RID: 3034 RVA: 0x0006EF54 File Offset: 0x0006D154
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

	// Token: 0x06000BDB RID: 3035 RVA: 0x0006F044 File Offset: 0x0006D244
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BDC RID: 3036 RVA: 0x0006F07C File Offset: 0x0006D27C
	private void Update()
	{
	}

	// Token: 0x06000BDD RID: 3037 RVA: 0x0006F07E File Offset: 0x0006D27E
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BDE RID: 3038 RVA: 0x0006F0B6 File Offset: 0x0006D2B6
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

	// Token: 0x04001018 RID: 4120
	private string ShaderName = "CameraFilterPack/Blend2Camera_Lighten";

	// Token: 0x04001019 RID: 4121
	public Shader SCShader;

	// Token: 0x0400101A RID: 4122
	public Camera Camera2;

	// Token: 0x0400101B RID: 4123
	private float TimeX = 1f;

	// Token: 0x0400101C RID: 4124
	private Material SCMaterial;

	// Token: 0x0400101D RID: 4125
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400101E RID: 4126
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400101F RID: 4127
	private RenderTexture Camera2tex;
}
