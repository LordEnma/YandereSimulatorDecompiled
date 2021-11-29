using System;
using UnityEngine;

// Token: 0x0200013B RID: 315
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Overlay")]
public class CameraFilterPack_Blend2Camera_Overlay : MonoBehaviour
{
	// Token: 0x17000240 RID: 576
	// (get) Token: 0x06000C0C RID: 3084 RVA: 0x0006F97F File Offset: 0x0006DB7F
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

	// Token: 0x06000C0D RID: 3085 RVA: 0x0006F9B4 File Offset: 0x0006DBB4
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

	// Token: 0x06000C0E RID: 3086 RVA: 0x0006FA18 File Offset: 0x0006DC18
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

	// Token: 0x06000C0F RID: 3087 RVA: 0x0006FB08 File Offset: 0x0006DD08
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C10 RID: 3088 RVA: 0x0006FB40 File Offset: 0x0006DD40
	private void Update()
	{
	}

	// Token: 0x06000C11 RID: 3089 RVA: 0x0006FB42 File Offset: 0x0006DD42
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C12 RID: 3090 RVA: 0x0006FB7A File Offset: 0x0006DD7A
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

	// Token: 0x0400103F RID: 4159
	private string ShaderName = "CameraFilterPack/Blend2Camera_Overlay";

	// Token: 0x04001040 RID: 4160
	public Shader SCShader;

	// Token: 0x04001041 RID: 4161
	public Camera Camera2;

	// Token: 0x04001042 RID: 4162
	private float TimeX = 1f;

	// Token: 0x04001043 RID: 4163
	private Material SCMaterial;

	// Token: 0x04001044 RID: 4164
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001045 RID: 4165
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001046 RID: 4166
	private RenderTexture Camera2tex;
}
