using System;
using UnityEngine;

// Token: 0x0200013E RID: 318
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/PinLight")]
public class CameraFilterPack_Blend2Camera_PinLight : MonoBehaviour
{
	// Token: 0x17000242 RID: 578
	// (get) Token: 0x06000C21 RID: 3105 RVA: 0x00070522 File Offset: 0x0006E722
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

	// Token: 0x06000C22 RID: 3106 RVA: 0x00070558 File Offset: 0x0006E758
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

	// Token: 0x06000C23 RID: 3107 RVA: 0x000705BC File Offset: 0x0006E7BC
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

	// Token: 0x06000C24 RID: 3108 RVA: 0x000706AC File Offset: 0x0006E8AC
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C25 RID: 3109 RVA: 0x000706E4 File Offset: 0x0006E8E4
	private void Update()
	{
	}

	// Token: 0x06000C26 RID: 3110 RVA: 0x000706E6 File Offset: 0x0006E8E6
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C27 RID: 3111 RVA: 0x0007071E File Offset: 0x0006E91E
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

	// Token: 0x04001059 RID: 4185
	private string ShaderName = "CameraFilterPack/Blend2Camera_PinLight";

	// Token: 0x0400105A RID: 4186
	public Shader SCShader;

	// Token: 0x0400105B RID: 4187
	public Camera Camera2;

	// Token: 0x0400105C RID: 4188
	private float TimeX = 1f;

	// Token: 0x0400105D RID: 4189
	private Material SCMaterial;

	// Token: 0x0400105E RID: 4190
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400105F RID: 4191
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001060 RID: 4192
	private RenderTexture Camera2tex;
}
