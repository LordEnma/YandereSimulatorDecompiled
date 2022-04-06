using System;
using UnityEngine;

// Token: 0x02000130 RID: 304
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Exclusion")]
public class CameraFilterPack_Blend2Camera_Exclusion : MonoBehaviour
{
	// Token: 0x17000234 RID: 564
	// (get) Token: 0x06000BB3 RID: 2995 RVA: 0x0006E747 File Offset: 0x0006C947
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

	// Token: 0x06000BB4 RID: 2996 RVA: 0x0006E77C File Offset: 0x0006C97C
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

	// Token: 0x06000BB5 RID: 2997 RVA: 0x0006E7E0 File Offset: 0x0006C9E0
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

	// Token: 0x06000BB6 RID: 2998 RVA: 0x0006E8D0 File Offset: 0x0006CAD0
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BB7 RID: 2999 RVA: 0x0006E908 File Offset: 0x0006CB08
	private void Update()
	{
	}

	// Token: 0x06000BB8 RID: 3000 RVA: 0x0006E90A File Offset: 0x0006CB0A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BB9 RID: 3001 RVA: 0x0006E942 File Offset: 0x0006CB42
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

	// Token: 0x04000FF1 RID: 4081
	private string ShaderName = "CameraFilterPack/Blend2Camera_Exclusion";

	// Token: 0x04000FF2 RID: 4082
	public Shader SCShader;

	// Token: 0x04000FF3 RID: 4083
	public Camera Camera2;

	// Token: 0x04000FF4 RID: 4084
	private float TimeX = 1f;

	// Token: 0x04000FF5 RID: 4085
	private Material SCMaterial;

	// Token: 0x04000FF6 RID: 4086
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FF7 RID: 4087
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FF8 RID: 4088
	private RenderTexture Camera2tex;
}
