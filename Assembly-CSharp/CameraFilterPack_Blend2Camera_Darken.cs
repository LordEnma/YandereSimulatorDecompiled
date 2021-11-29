using System;
using UnityEngine;

// Token: 0x0200012B RID: 299
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Darken")]
public class CameraFilterPack_Blend2Camera_Darken : MonoBehaviour
{
	// Token: 0x17000230 RID: 560
	// (get) Token: 0x06000B8D RID: 2957 RVA: 0x0006D3C7 File Offset: 0x0006B5C7
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

	// Token: 0x06000B8E RID: 2958 RVA: 0x0006D3FC File Offset: 0x0006B5FC
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

	// Token: 0x06000B8F RID: 2959 RVA: 0x0006D460 File Offset: 0x0006B660
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

	// Token: 0x06000B90 RID: 2960 RVA: 0x0006D550 File Offset: 0x0006B750
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B91 RID: 2961 RVA: 0x0006D588 File Offset: 0x0006B788
	private void Update()
	{
	}

	// Token: 0x06000B92 RID: 2962 RVA: 0x0006D58A File Offset: 0x0006B78A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B93 RID: 2963 RVA: 0x0006D5C2 File Offset: 0x0006B7C2
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

	// Token: 0x04000FB9 RID: 4025
	private string ShaderName = "CameraFilterPack/Blend2Camera_Darken";

	// Token: 0x04000FBA RID: 4026
	public Shader SCShader;

	// Token: 0x04000FBB RID: 4027
	public Camera Camera2;

	// Token: 0x04000FBC RID: 4028
	private float TimeX = 1f;

	// Token: 0x04000FBD RID: 4029
	private Material SCMaterial;

	// Token: 0x04000FBE RID: 4030
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FBF RID: 4031
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FC0 RID: 4032
	private RenderTexture Camera2tex;
}
