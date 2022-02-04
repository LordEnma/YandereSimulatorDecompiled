using System;
using UnityEngine;

// Token: 0x0200013B RID: 315
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Multiply")]
public class CameraFilterPack_Blend2Camera_Multiply : MonoBehaviour
{
	// Token: 0x1700023F RID: 575
	// (get) Token: 0x06000C07 RID: 3079 RVA: 0x0006F91F File Offset: 0x0006DB1F
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

	// Token: 0x06000C08 RID: 3080 RVA: 0x0006F954 File Offset: 0x0006DB54
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

	// Token: 0x06000C09 RID: 3081 RVA: 0x0006F9B8 File Offset: 0x0006DBB8
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

	// Token: 0x06000C0A RID: 3082 RVA: 0x0006FAA8 File Offset: 0x0006DCA8
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C0B RID: 3083 RVA: 0x0006FAE0 File Offset: 0x0006DCE0
	private void Update()
	{
	}

	// Token: 0x06000C0C RID: 3084 RVA: 0x0006FAE2 File Offset: 0x0006DCE2
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C0D RID: 3085 RVA: 0x0006FB1A File Offset: 0x0006DD1A
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

	// Token: 0x0400103C RID: 4156
	private string ShaderName = "CameraFilterPack/Blend2Camera_Multiply";

	// Token: 0x0400103D RID: 4157
	public Shader SCShader;

	// Token: 0x0400103E RID: 4158
	public Camera Camera2;

	// Token: 0x0400103F RID: 4159
	private float TimeX = 1f;

	// Token: 0x04001040 RID: 4160
	private Material SCMaterial;

	// Token: 0x04001041 RID: 4161
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001042 RID: 4162
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001043 RID: 4163
	private RenderTexture Camera2tex;
}
