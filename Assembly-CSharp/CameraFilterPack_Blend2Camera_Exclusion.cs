using System;
using UnityEngine;

// Token: 0x02000130 RID: 304
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Exclusion")]
public class CameraFilterPack_Blend2Camera_Exclusion : MonoBehaviour
{
	// Token: 0x17000234 RID: 564
	// (get) Token: 0x06000BB1 RID: 2993 RVA: 0x0006E2CB File Offset: 0x0006C4CB
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

	// Token: 0x06000BB2 RID: 2994 RVA: 0x0006E300 File Offset: 0x0006C500
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

	// Token: 0x06000BB3 RID: 2995 RVA: 0x0006E364 File Offset: 0x0006C564
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

	// Token: 0x06000BB4 RID: 2996 RVA: 0x0006E454 File Offset: 0x0006C654
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BB5 RID: 2997 RVA: 0x0006E48C File Offset: 0x0006C68C
	private void Update()
	{
	}

	// Token: 0x06000BB6 RID: 2998 RVA: 0x0006E48E File Offset: 0x0006C68E
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BB7 RID: 2999 RVA: 0x0006E4C6 File Offset: 0x0006C6C6
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

	// Token: 0x04000FEA RID: 4074
	private string ShaderName = "CameraFilterPack/Blend2Camera_Exclusion";

	// Token: 0x04000FEB RID: 4075
	public Shader SCShader;

	// Token: 0x04000FEC RID: 4076
	public Camera Camera2;

	// Token: 0x04000FED RID: 4077
	private float TimeX = 1f;

	// Token: 0x04000FEE RID: 4078
	private Material SCMaterial;

	// Token: 0x04000FEF RID: 4079
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FF0 RID: 4080
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FF1 RID: 4081
	private RenderTexture Camera2tex;
}
