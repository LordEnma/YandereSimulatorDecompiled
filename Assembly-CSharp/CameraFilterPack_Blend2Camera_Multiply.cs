using System;
using UnityEngine;

// Token: 0x0200013B RID: 315
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Multiply")]
public class CameraFilterPack_Blend2Camera_Multiply : MonoBehaviour
{
	// Token: 0x1700023F RID: 575
	// (get) Token: 0x06000C08 RID: 3080 RVA: 0x0006FCCB File Offset: 0x0006DECB
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

	// Token: 0x06000C09 RID: 3081 RVA: 0x0006FD00 File Offset: 0x0006DF00
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

	// Token: 0x06000C0A RID: 3082 RVA: 0x0006FD64 File Offset: 0x0006DF64
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

	// Token: 0x06000C0B RID: 3083 RVA: 0x0006FE54 File Offset: 0x0006E054
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C0C RID: 3084 RVA: 0x0006FE8C File Offset: 0x0006E08C
	private void Update()
	{
	}

	// Token: 0x06000C0D RID: 3085 RVA: 0x0006FE8E File Offset: 0x0006E08E
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C0E RID: 3086 RVA: 0x0006FEC6 File Offset: 0x0006E0C6
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

	// Token: 0x04001048 RID: 4168
	private string ShaderName = "CameraFilterPack/Blend2Camera_Multiply";

	// Token: 0x04001049 RID: 4169
	public Shader SCShader;

	// Token: 0x0400104A RID: 4170
	public Camera Camera2;

	// Token: 0x0400104B RID: 4171
	private float TimeX = 1f;

	// Token: 0x0400104C RID: 4172
	private Material SCMaterial;

	// Token: 0x0400104D RID: 4173
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400104E RID: 4174
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400104F RID: 4175
	private RenderTexture Camera2tex;
}
