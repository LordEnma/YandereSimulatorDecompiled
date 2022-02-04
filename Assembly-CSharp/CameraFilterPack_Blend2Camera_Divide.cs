using System;
using UnityEngine;

// Token: 0x0200012F RID: 303
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Divide")]
public class CameraFilterPack_Blend2Camera_Divide : MonoBehaviour
{
	// Token: 0x17000233 RID: 563
	// (get) Token: 0x06000BA8 RID: 2984 RVA: 0x0006DCC7 File Offset: 0x0006BEC7
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

	// Token: 0x06000BA9 RID: 2985 RVA: 0x0006DCFC File Offset: 0x0006BEFC
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

	// Token: 0x06000BAA RID: 2986 RVA: 0x0006DD60 File Offset: 0x0006BF60
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

	// Token: 0x06000BAB RID: 2987 RVA: 0x0006DE50 File Offset: 0x0006C050
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BAC RID: 2988 RVA: 0x0006DE88 File Offset: 0x0006C088
	private void Update()
	{
	}

	// Token: 0x06000BAD RID: 2989 RVA: 0x0006DE8A File Offset: 0x0006C08A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BAE RID: 2990 RVA: 0x0006DEC2 File Offset: 0x0006C0C2
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

	// Token: 0x04000FD6 RID: 4054
	private string ShaderName = "CameraFilterPack/Blend2Camera_Divide";

	// Token: 0x04000FD7 RID: 4055
	public Shader SCShader;

	// Token: 0x04000FD8 RID: 4056
	public Camera Camera2;

	// Token: 0x04000FD9 RID: 4057
	private float TimeX = 1f;

	// Token: 0x04000FDA RID: 4058
	private Material SCMaterial;

	// Token: 0x04000FDB RID: 4059
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FDC RID: 4060
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FDD RID: 4061
	private RenderTexture Camera2tex;
}
