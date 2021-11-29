using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000574 RID: 1396
	public static class GraphicsUtils
	{
		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x0600236C RID: 9068 RVA: 0x001F0774 File Offset: 0x001EE974
		public static bool isLinearColorSpace
		{
			get
			{
				return QualitySettings.activeColorSpace == ColorSpace.Linear;
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x0600236D RID: 9069 RVA: 0x001F077E File Offset: 0x001EE97E
		public static bool supportsDX11
		{
			get
			{
				return SystemInfo.graphicsShaderLevel >= 50 && SystemInfo.supportsComputeShaders;
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x0600236E RID: 9070 RVA: 0x001F0790 File Offset: 0x001EE990
		public static Texture2D whiteTexture
		{
			get
			{
				if (GraphicsUtils.s_WhiteTexture != null)
				{
					return GraphicsUtils.s_WhiteTexture;
				}
				GraphicsUtils.s_WhiteTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
				GraphicsUtils.s_WhiteTexture.SetPixel(0, 0, new Color(1f, 1f, 1f, 1f));
				GraphicsUtils.s_WhiteTexture.Apply();
				return GraphicsUtils.s_WhiteTexture;
			}
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x0600236F RID: 9071 RVA: 0x001F07F4 File Offset: 0x001EE9F4
		public static Mesh quad
		{
			get
			{
				if (GraphicsUtils.s_Quad != null)
				{
					return GraphicsUtils.s_Quad;
				}
				Vector3[] vertices = new Vector3[]
				{
					new Vector3(-1f, -1f, 0f),
					new Vector3(1f, 1f, 0f),
					new Vector3(1f, -1f, 0f),
					new Vector3(-1f, 1f, 0f)
				};
				Vector2[] uv = new Vector2[]
				{
					new Vector2(0f, 0f),
					new Vector2(1f, 1f),
					new Vector2(1f, 0f),
					new Vector2(0f, 1f)
				};
				int[] triangles = new int[]
				{
					0,
					1,
					2,
					1,
					0,
					3
				};
				GraphicsUtils.s_Quad = new Mesh
				{
					vertices = vertices,
					uv = uv,
					triangles = triangles
				};
				GraphicsUtils.s_Quad.RecalculateNormals();
				GraphicsUtils.s_Quad.RecalculateBounds();
				return GraphicsUtils.s_Quad;
			}
		}

		// Token: 0x06002370 RID: 9072 RVA: 0x001F0930 File Offset: 0x001EEB30
		public static void Blit(Material material, int pass)
		{
			GL.PushMatrix();
			GL.LoadOrtho();
			material.SetPass(pass);
			GL.Begin(5);
			GL.TexCoord2(0f, 0f);
			GL.Vertex3(0f, 0f, 0.1f);
			GL.TexCoord2(1f, 0f);
			GL.Vertex3(1f, 0f, 0.1f);
			GL.TexCoord2(0f, 1f);
			GL.Vertex3(0f, 1f, 0.1f);
			GL.TexCoord2(1f, 1f);
			GL.Vertex3(1f, 1f, 0.1f);
			GL.End();
			GL.PopMatrix();
		}

		// Token: 0x06002371 RID: 9073 RVA: 0x001F09EC File Offset: 0x001EEBEC
		public static void ClearAndBlit(Texture source, RenderTexture destination, Material material, int pass, bool clearColor = true, bool clearDepth = false)
		{
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = destination;
			GL.Clear(false, clearColor, Color.clear);
			GL.PushMatrix();
			GL.LoadOrtho();
			material.SetTexture("_MainTex", source);
			material.SetPass(pass);
			GL.Begin(5);
			GL.TexCoord2(0f, 0f);
			GL.Vertex3(0f, 0f, 0.1f);
			GL.TexCoord2(1f, 0f);
			GL.Vertex3(1f, 0f, 0.1f);
			GL.TexCoord2(0f, 1f);
			GL.Vertex3(0f, 1f, 0.1f);
			GL.TexCoord2(1f, 1f);
			GL.Vertex3(1f, 1f, 0.1f);
			GL.End();
			GL.PopMatrix();
			RenderTexture.active = active;
		}

		// Token: 0x06002372 RID: 9074 RVA: 0x001F0AD0 File Offset: 0x001EECD0
		public static void Destroy(Object obj)
		{
			if (obj != null)
			{
				Object.Destroy(obj);
			}
		}

		// Token: 0x06002373 RID: 9075 RVA: 0x001F0AE1 File Offset: 0x001EECE1
		public static void Dispose()
		{
			GraphicsUtils.Destroy(GraphicsUtils.s_Quad);
		}

		// Token: 0x04004AC2 RID: 19138
		private static Texture2D s_WhiteTexture;

		// Token: 0x04004AC3 RID: 19139
		private static Mesh s_Quad;
	}
}
