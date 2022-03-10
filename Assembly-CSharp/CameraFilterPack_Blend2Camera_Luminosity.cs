using System;
using UnityEngine;

// Token: 0x0200013A RID: 314
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Luminosity")]
public class CameraFilterPack_Blend2Camera_Luminosity : MonoBehaviour
{
	// Token: 0x1700023E RID: 574
	// (get) Token: 0x06000C00 RID: 3072 RVA: 0x0006FA73 File Offset: 0x0006DC73
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

	// Token: 0x06000C01 RID: 3073 RVA: 0x0006FAA8 File Offset: 0x0006DCA8
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

	// Token: 0x06000C02 RID: 3074 RVA: 0x0006FB0C File Offset: 0x0006DD0C
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

	// Token: 0x06000C03 RID: 3075 RVA: 0x0006FBFC File Offset: 0x0006DDFC
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C04 RID: 3076 RVA: 0x0006FC34 File Offset: 0x0006DE34
	private void Update()
	{
	}

	// Token: 0x06000C05 RID: 3077 RVA: 0x0006FC36 File Offset: 0x0006DE36
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C06 RID: 3078 RVA: 0x0006FC6E File Offset: 0x0006DE6E
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

	// Token: 0x04001040 RID: 4160
	private string ShaderName = "CameraFilterPack/Blend2Camera_Luminosity";

	// Token: 0x04001041 RID: 4161
	public Shader SCShader;

	// Token: 0x04001042 RID: 4162
	public Camera Camera2;

	// Token: 0x04001043 RID: 4163
	private float TimeX = 1f;

	// Token: 0x04001044 RID: 4164
	private Material SCMaterial;

	// Token: 0x04001045 RID: 4165
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001046 RID: 4166
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001047 RID: 4167
	private RenderTexture Camera2tex;
}
