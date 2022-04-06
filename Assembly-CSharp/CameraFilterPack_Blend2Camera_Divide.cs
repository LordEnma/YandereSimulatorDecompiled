using System;
using UnityEngine;

// Token: 0x0200012F RID: 303
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Divide")]
public class CameraFilterPack_Blend2Camera_Divide : MonoBehaviour
{
	// Token: 0x17000233 RID: 563
	// (get) Token: 0x06000BAB RID: 2987 RVA: 0x0006E4EF File Offset: 0x0006C6EF
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

	// Token: 0x06000BAC RID: 2988 RVA: 0x0006E524 File Offset: 0x0006C724
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

	// Token: 0x06000BAD RID: 2989 RVA: 0x0006E588 File Offset: 0x0006C788
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

	// Token: 0x06000BAE RID: 2990 RVA: 0x0006E678 File Offset: 0x0006C878
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BAF RID: 2991 RVA: 0x0006E6B0 File Offset: 0x0006C8B0
	private void Update()
	{
	}

	// Token: 0x06000BB0 RID: 2992 RVA: 0x0006E6B2 File Offset: 0x0006C8B2
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BB1 RID: 2993 RVA: 0x0006E6EA File Offset: 0x0006C8EA
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

	// Token: 0x04000FE9 RID: 4073
	private string ShaderName = "CameraFilterPack/Blend2Camera_Divide";

	// Token: 0x04000FEA RID: 4074
	public Shader SCShader;

	// Token: 0x04000FEB RID: 4075
	public Camera Camera2;

	// Token: 0x04000FEC RID: 4076
	private float TimeX = 1f;

	// Token: 0x04000FED RID: 4077
	private Material SCMaterial;

	// Token: 0x04000FEE RID: 4078
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FEF RID: 4079
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FF0 RID: 4080
	private RenderTexture Camera2tex;
}
