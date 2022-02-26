using System;
using UnityEngine;

// Token: 0x02000130 RID: 304
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Exclusion")]
public class CameraFilterPack_Blend2Camera_Exclusion : MonoBehaviour
{
	// Token: 0x17000234 RID: 564
	// (get) Token: 0x06000BB1 RID: 2993 RVA: 0x0006E183 File Offset: 0x0006C383
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

	// Token: 0x06000BB2 RID: 2994 RVA: 0x0006E1B8 File Offset: 0x0006C3B8
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

	// Token: 0x06000BB3 RID: 2995 RVA: 0x0006E21C File Offset: 0x0006C41C
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

	// Token: 0x06000BB4 RID: 2996 RVA: 0x0006E30C File Offset: 0x0006C50C
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BB5 RID: 2997 RVA: 0x0006E344 File Offset: 0x0006C544
	private void Update()
	{
	}

	// Token: 0x06000BB6 RID: 2998 RVA: 0x0006E346 File Offset: 0x0006C546
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BB7 RID: 2999 RVA: 0x0006E37E File Offset: 0x0006C57E
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

	// Token: 0x04000FE1 RID: 4065
	private string ShaderName = "CameraFilterPack/Blend2Camera_Exclusion";

	// Token: 0x04000FE2 RID: 4066
	public Shader SCShader;

	// Token: 0x04000FE3 RID: 4067
	public Camera Camera2;

	// Token: 0x04000FE4 RID: 4068
	private float TimeX = 1f;

	// Token: 0x04000FE5 RID: 4069
	private Material SCMaterial;

	// Token: 0x04000FE6 RID: 4070
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FE7 RID: 4071
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FE8 RID: 4072
	private RenderTexture Camera2tex;
}
