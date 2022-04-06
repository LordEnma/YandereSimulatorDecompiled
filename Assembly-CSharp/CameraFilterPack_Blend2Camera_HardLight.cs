using System;
using UnityEngine;

// Token: 0x02000132 RID: 306
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/HardLight")]
public class CameraFilterPack_Blend2Camera_HardLight : MonoBehaviour
{
	// Token: 0x17000236 RID: 566
	// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x0006EC2F File Offset: 0x0006CE2F
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

	// Token: 0x06000BC3 RID: 3011 RVA: 0x0006EC64 File Offset: 0x0006CE64
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

	// Token: 0x06000BC4 RID: 3012 RVA: 0x0006ECC8 File Offset: 0x0006CEC8
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

	// Token: 0x06000BC5 RID: 3013 RVA: 0x0006EDB8 File Offset: 0x0006CFB8
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BC6 RID: 3014 RVA: 0x0006EDF0 File Offset: 0x0006CFF0
	private void Update()
	{
	}

	// Token: 0x06000BC7 RID: 3015 RVA: 0x0006EDF2 File Offset: 0x0006CFF2
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BC8 RID: 3016 RVA: 0x0006EE2A File Offset: 0x0006D02A
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

	// Token: 0x04001007 RID: 4103
	private string ShaderName = "CameraFilterPack/Blend2Camera_HardLight";

	// Token: 0x04001008 RID: 4104
	public Shader SCShader;

	// Token: 0x04001009 RID: 4105
	public Camera Camera2;

	// Token: 0x0400100A RID: 4106
	private float TimeX = 1f;

	// Token: 0x0400100B RID: 4107
	private Material SCMaterial;

	// Token: 0x0400100C RID: 4108
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400100D RID: 4109
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400100E RID: 4110
	private RenderTexture Camera2tex;
}
