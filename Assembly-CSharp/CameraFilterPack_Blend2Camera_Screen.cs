using System;
using UnityEngine;

// Token: 0x02000140 RID: 320
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Screen")]
public class CameraFilterPack_Blend2Camera_Screen : MonoBehaviour
{
	// Token: 0x17000244 RID: 580
	// (get) Token: 0x06000C33 RID: 3123 RVA: 0x00070F97 File Offset: 0x0006F197
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

	// Token: 0x06000C34 RID: 3124 RVA: 0x00070FCC File Offset: 0x0006F1CC
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

	// Token: 0x06000C35 RID: 3125 RVA: 0x00071030 File Offset: 0x0006F230
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

	// Token: 0x06000C36 RID: 3126 RVA: 0x00071120 File Offset: 0x0006F320
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C37 RID: 3127 RVA: 0x00071158 File Offset: 0x0006F358
	private void Update()
	{
	}

	// Token: 0x06000C38 RID: 3128 RVA: 0x0007115A File Offset: 0x0006F35A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C39 RID: 3129 RVA: 0x00071192 File Offset: 0x0006F392
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

	// Token: 0x04001079 RID: 4217
	private string ShaderName = "CameraFilterPack/Blend2Camera_Screen";

	// Token: 0x0400107A RID: 4218
	public Shader SCShader;

	// Token: 0x0400107B RID: 4219
	public Camera Camera2;

	// Token: 0x0400107C RID: 4220
	private float TimeX = 1f;

	// Token: 0x0400107D RID: 4221
	private Material SCMaterial;

	// Token: 0x0400107E RID: 4222
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400107F RID: 4223
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001080 RID: 4224
	private RenderTexture Camera2tex;
}
