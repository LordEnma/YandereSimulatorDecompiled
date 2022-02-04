using System;
using UnityEngine;

// Token: 0x0200013C RID: 316
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Overlay")]
public class CameraFilterPack_Blend2Camera_Overlay : MonoBehaviour
{
	// Token: 0x17000240 RID: 576
	// (get) Token: 0x06000C0F RID: 3087 RVA: 0x0006FB77 File Offset: 0x0006DD77
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

	// Token: 0x06000C10 RID: 3088 RVA: 0x0006FBAC File Offset: 0x0006DDAC
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

	// Token: 0x06000C11 RID: 3089 RVA: 0x0006FC10 File Offset: 0x0006DE10
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

	// Token: 0x06000C12 RID: 3090 RVA: 0x0006FD00 File Offset: 0x0006DF00
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C13 RID: 3091 RVA: 0x0006FD38 File Offset: 0x0006DF38
	private void Update()
	{
	}

	// Token: 0x06000C14 RID: 3092 RVA: 0x0006FD3A File Offset: 0x0006DF3A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C15 RID: 3093 RVA: 0x0006FD72 File Offset: 0x0006DF72
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

	// Token: 0x04001044 RID: 4164
	private string ShaderName = "CameraFilterPack/Blend2Camera_Overlay";

	// Token: 0x04001045 RID: 4165
	public Shader SCShader;

	// Token: 0x04001046 RID: 4166
	public Camera Camera2;

	// Token: 0x04001047 RID: 4167
	private float TimeX = 1f;

	// Token: 0x04001048 RID: 4168
	private Material SCMaterial;

	// Token: 0x04001049 RID: 4169
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400104A RID: 4170
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400104B RID: 4171
	private RenderTexture Camera2tex;
}
