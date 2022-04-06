using System;
using UnityEngine;

// Token: 0x02000138 RID: 312
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/LinearDodge")]
public class CameraFilterPack_Blend2Camera_LinearDodge : MonoBehaviour
{
	// Token: 0x1700023C RID: 572
	// (get) Token: 0x06000BF2 RID: 3058 RVA: 0x0006FA3F File Offset: 0x0006DC3F
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

	// Token: 0x06000BF3 RID: 3059 RVA: 0x0006FA74 File Offset: 0x0006DC74
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

	// Token: 0x06000BF4 RID: 3060 RVA: 0x0006FAD8 File Offset: 0x0006DCD8
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

	// Token: 0x06000BF5 RID: 3061 RVA: 0x0006FBC8 File Offset: 0x0006DDC8
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BF6 RID: 3062 RVA: 0x0006FC00 File Offset: 0x0006DE00
	private void Update()
	{
	}

	// Token: 0x06000BF7 RID: 3063 RVA: 0x0006FC02 File Offset: 0x0006DE02
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BF8 RID: 3064 RVA: 0x0006FC3A File Offset: 0x0006DE3A
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

	// Token: 0x04001037 RID: 4151
	private string ShaderName = "CameraFilterPack/Blend2Camera_LinearDodge";

	// Token: 0x04001038 RID: 4152
	public Shader SCShader;

	// Token: 0x04001039 RID: 4153
	public Camera Camera2;

	// Token: 0x0400103A RID: 4154
	private float TimeX = 1f;

	// Token: 0x0400103B RID: 4155
	private Material SCMaterial;

	// Token: 0x0400103C RID: 4156
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400103D RID: 4157
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400103E RID: 4158
	private RenderTexture Camera2tex;
}
