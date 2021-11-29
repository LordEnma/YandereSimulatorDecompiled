using System;
using UnityEngine;

// Token: 0x02000143 RID: 323
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Subtract")]
public class CameraFilterPack_Blend2Camera_Subtract : MonoBehaviour
{
	// Token: 0x17000248 RID: 584
	// (get) Token: 0x06000C4D RID: 3149 RVA: 0x00071021 File Offset: 0x0006F221
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

	// Token: 0x06000C4E RID: 3150 RVA: 0x00071058 File Offset: 0x0006F258
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

	// Token: 0x06000C4F RID: 3151 RVA: 0x000710BC File Offset: 0x0006F2BC
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

	// Token: 0x06000C50 RID: 3152 RVA: 0x000711AC File Offset: 0x0006F3AC
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C51 RID: 3153 RVA: 0x000711E4 File Offset: 0x0006F3E4
	private void Update()
	{
	}

	// Token: 0x06000C52 RID: 3154 RVA: 0x000711E6 File Offset: 0x0006F3E6
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C53 RID: 3155 RVA: 0x0007121E File Offset: 0x0006F41E
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

	// Token: 0x04001090 RID: 4240
	private string ShaderName = "CameraFilterPack/Blend2Camera_Subtract";

	// Token: 0x04001091 RID: 4241
	public Shader SCShader;

	// Token: 0x04001092 RID: 4242
	public Camera Camera2;

	// Token: 0x04001093 RID: 4243
	private float TimeX = 1f;

	// Token: 0x04001094 RID: 4244
	private Material SCMaterial;

	// Token: 0x04001095 RID: 4245
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001096 RID: 4246
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001097 RID: 4247
	private RenderTexture Camera2tex;
}
