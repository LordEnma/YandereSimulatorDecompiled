using System;
using UnityEngine;

// Token: 0x0200012E RID: 302
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Divide")]
public class CameraFilterPack_Blend2Camera_Divide : MonoBehaviour
{
	// Token: 0x17000233 RID: 563
	// (get) Token: 0x06000BA5 RID: 2981 RVA: 0x0006DACF File Offset: 0x0006BCCF
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

	// Token: 0x06000BA6 RID: 2982 RVA: 0x0006DB04 File Offset: 0x0006BD04
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

	// Token: 0x06000BA7 RID: 2983 RVA: 0x0006DB68 File Offset: 0x0006BD68
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

	// Token: 0x06000BA8 RID: 2984 RVA: 0x0006DC58 File Offset: 0x0006BE58
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BA9 RID: 2985 RVA: 0x0006DC90 File Offset: 0x0006BE90
	private void Update()
	{
	}

	// Token: 0x06000BAA RID: 2986 RVA: 0x0006DC92 File Offset: 0x0006BE92
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BAB RID: 2987 RVA: 0x0006DCCA File Offset: 0x0006BECA
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

	// Token: 0x04000FD1 RID: 4049
	private string ShaderName = "CameraFilterPack/Blend2Camera_Divide";

	// Token: 0x04000FD2 RID: 4050
	public Shader SCShader;

	// Token: 0x04000FD3 RID: 4051
	public Camera Camera2;

	// Token: 0x04000FD4 RID: 4052
	private float TimeX = 1f;

	// Token: 0x04000FD5 RID: 4053
	private Material SCMaterial;

	// Token: 0x04000FD6 RID: 4054
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FD7 RID: 4055
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FD8 RID: 4056
	private RenderTexture Camera2tex;
}
