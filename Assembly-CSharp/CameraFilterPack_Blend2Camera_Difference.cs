using System;
using UnityEngine;

// Token: 0x0200012D RID: 301
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Difference")]
public class CameraFilterPack_Blend2Camera_Difference : MonoBehaviour
{
	// Token: 0x17000232 RID: 562
	// (get) Token: 0x06000B9D RID: 2973 RVA: 0x0006D877 File Offset: 0x0006BA77
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

	// Token: 0x06000B9E RID: 2974 RVA: 0x0006D8AC File Offset: 0x0006BAAC
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

	// Token: 0x06000B9F RID: 2975 RVA: 0x0006D910 File Offset: 0x0006BB10
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

	// Token: 0x06000BA0 RID: 2976 RVA: 0x0006DA00 File Offset: 0x0006BC00
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BA1 RID: 2977 RVA: 0x0006DA38 File Offset: 0x0006BC38
	private void Update()
	{
	}

	// Token: 0x06000BA2 RID: 2978 RVA: 0x0006DA3A File Offset: 0x0006BC3A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BA3 RID: 2979 RVA: 0x0006DA72 File Offset: 0x0006BC72
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

	// Token: 0x04000FC9 RID: 4041
	private string ShaderName = "CameraFilterPack/Blend2Camera_Difference";

	// Token: 0x04000FCA RID: 4042
	public Shader SCShader;

	// Token: 0x04000FCB RID: 4043
	public Camera Camera2;

	// Token: 0x04000FCC RID: 4044
	private float TimeX = 1f;

	// Token: 0x04000FCD RID: 4045
	private Material SCMaterial;

	// Token: 0x04000FCE RID: 4046
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FCF RID: 4047
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FD0 RID: 4048
	private RenderTexture Camera2tex;
}
