using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Sprite")]
public class UISprite : UIBasicSprite
{
	[HideInInspector]
	[SerializeField]
	private UnityEngine.Object mAtlas;

	[HideInInspector]
	[SerializeField]
	private string mSpriteName;

	[HideInInspector]
	[SerializeField]
	private bool mFixedAspect;

	[HideInInspector]
	[SerializeField]
	private bool mFillCenter = true;

	[NonSerialized]
	protected UISpriteData mSprite;

	[NonSerialized]
	private bool mSpriteSet;

	public override Texture mainTexture
	{
		get
		{
			Material material = null;
			if (mAtlas is INGUIAtlas iNGUIAtlas)
			{
				material = iNGUIAtlas.spriteMaterial;
			}
			if (!(material != null))
			{
				return null;
			}
			return material.mainTexture;
		}
		set
		{
			base.mainTexture = value;
		}
	}

	public override Material material
	{
		get
		{
			Material material = base.material;
			if (material != null)
			{
				return material;
			}
			if (mAtlas is INGUIAtlas iNGUIAtlas)
			{
				return iNGUIAtlas.spriteMaterial;
			}
			return null;
		}
		set
		{
			base.material = value;
		}
	}

	public INGUIAtlas atlas
	{
		get
		{
			return mAtlas as INGUIAtlas;
		}
		set
		{
			if (mAtlas as INGUIAtlas != value)
			{
				RemoveFromPanel();
				mAtlas = value as UnityEngine.Object;
				mSpriteSet = false;
				mSprite = null;
				if (string.IsNullOrEmpty(mSpriteName) && mAtlas is INGUIAtlas iNGUIAtlas && iNGUIAtlas.spriteList.Count > 0)
				{
					SetAtlasSprite(iNGUIAtlas.spriteList[0]);
					mSpriteName = mSprite.name;
				}
				if (!string.IsNullOrEmpty(mSpriteName))
				{
					string text = mSpriteName;
					mSpriteName = "";
					spriteName = text;
					MarkAsChanged();
				}
			}
		}
	}

	public bool fixedAspect
	{
		get
		{
			return mFixedAspect;
		}
		set
		{
			if (mFixedAspect != value)
			{
				mFixedAspect = value;
				mDrawRegion = new Vector4(0f, 0f, 1f, 1f);
				MarkAsChanged();
			}
		}
	}

	public string spriteName
	{
		get
		{
			return mSpriteName;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				if (!string.IsNullOrEmpty(mSpriteName))
				{
					mSpriteName = "";
					mSprite = null;
					mChanged = true;
					mSpriteSet = false;
					MarkAsChanged();
				}
			}
			else if (mSpriteName != value)
			{
				mSpriteName = value;
				mSprite = null;
				mChanged = true;
				mSpriteSet = false;
				MarkAsChanged();
			}
		}
	}

	public bool isValid => GetAtlasSprite() != null;

	[Obsolete("Use 'centerType' instead")]
	public bool fillCenter
	{
		get
		{
			return centerType != AdvancedType.Invisible;
		}
		set
		{
			if (value != (centerType != AdvancedType.Invisible))
			{
				centerType = (value ? AdvancedType.Sliced : AdvancedType.Invisible);
				MarkAsChanged();
			}
		}
	}

	public bool applyGradient
	{
		get
		{
			return mApplyGradient;
		}
		set
		{
			if (mApplyGradient != value)
			{
				mApplyGradient = value;
				MarkAsChanged();
			}
		}
	}

	public Color gradientTop
	{
		get
		{
			return mGradientTop;
		}
		set
		{
			if (mGradientTop != value)
			{
				mGradientTop = value;
				if (mApplyGradient)
				{
					MarkAsChanged();
				}
			}
		}
	}

	public Color gradientBottom
	{
		get
		{
			return mGradientBottom;
		}
		set
		{
			if (mGradientBottom != value)
			{
				mGradientBottom = value;
				if (mApplyGradient)
				{
					MarkAsChanged();
				}
			}
		}
	}

	public override Vector4 border
	{
		get
		{
			UISpriteData atlasSprite = GetAtlasSprite();
			if (atlasSprite == null)
			{
				return base.border;
			}
			return new Vector4(atlasSprite.borderLeft, atlasSprite.borderBottom, atlasSprite.borderRight, atlasSprite.borderTop);
		}
	}

	protected override Vector4 padding
	{
		get
		{
			UISpriteData atlasSprite = GetAtlasSprite();
			Vector4 result = new Vector4(0f, 0f, 0f, 0f);
			if (atlasSprite != null)
			{
				result.x = atlasSprite.paddingLeft;
				result.y = atlasSprite.paddingBottom;
				result.z = atlasSprite.paddingRight;
				result.w = atlasSprite.paddingTop;
			}
			return result;
		}
	}

	public override float pixelSize
	{
		get
		{
			if (mAtlas == null)
			{
				return 1f;
			}
			if (mAtlas is INGUIAtlas iNGUIAtlas)
			{
				return iNGUIAtlas.pixelSize;
			}
			return 1f;
		}
	}

	public override int minWidth
	{
		get
		{
			if (type == Type.Sliced || type == Type.Advanced)
			{
				float num = pixelSize;
				Vector4 vector = border * pixelSize;
				int num2 = Mathf.RoundToInt(vector.x + vector.z);
				UISpriteData atlasSprite = GetAtlasSprite();
				if (atlasSprite != null)
				{
					num2 += Mathf.RoundToInt(num * (float)(atlasSprite.paddingLeft + atlasSprite.paddingRight));
				}
				return Mathf.Max(base.minWidth, ((num2 & 1) == 1) ? (num2 + 1) : num2);
			}
			return base.minWidth;
		}
	}

	public override int minHeight
	{
		get
		{
			if (type == Type.Sliced || type == Type.Advanced)
			{
				float num = pixelSize;
				Vector4 vector = border * pixelSize;
				int num2 = Mathf.RoundToInt(vector.y + vector.w);
				UISpriteData atlasSprite = GetAtlasSprite();
				if (atlasSprite != null)
				{
					num2 += Mathf.RoundToInt(num * (float)(atlasSprite.paddingTop + atlasSprite.paddingBottom));
				}
				return Mathf.Max(base.minHeight, ((num2 & 1) == 1) ? (num2 + 1) : num2);
			}
			return base.minHeight;
		}
	}

	public override Vector4 drawingDimensions
	{
		get
		{
			Vector2 vector = base.pivotOffset;
			float num = (0f - vector.x) * (float)mWidth;
			float num2 = (0f - vector.y) * (float)mHeight;
			float num3 = num + (float)mWidth;
			float num4 = num2 + (float)mHeight;
			if (GetAtlasSprite() != null && mType != Type.Tiled)
			{
				int num5 = mSprite.paddingLeft;
				int num6 = mSprite.paddingBottom;
				int num7 = mSprite.paddingRight;
				int num8 = mSprite.paddingTop;
				if (mType != 0)
				{
					float num9 = pixelSize;
					if (num9 != 1f)
					{
						num5 = Mathf.RoundToInt(num9 * (float)num5);
						num6 = Mathf.RoundToInt(num9 * (float)num6);
						num7 = Mathf.RoundToInt(num9 * (float)num7);
						num8 = Mathf.RoundToInt(num9 * (float)num8);
					}
				}
				int num10 = mSprite.width + num5 + num7;
				int num11 = mSprite.height + num6 + num8;
				float num12 = 1f;
				float num13 = 1f;
				if (num10 > 0 && num11 > 0 && (mType == Type.Simple || mType == Type.Filled))
				{
					if (((uint)num10 & (true ? 1u : 0u)) != 0)
					{
						num7++;
					}
					if (((uint)num11 & (true ? 1u : 0u)) != 0)
					{
						num8++;
					}
					num12 = 1f / (float)num10 * (float)mWidth;
					num13 = 1f / (float)num11 * (float)mHeight;
				}
				if (mFlip == Flip.Horizontally || mFlip == Flip.Both)
				{
					num += (float)num7 * num12;
					num3 -= (float)num5 * num12;
				}
				else
				{
					num += (float)num5 * num12;
					num3 -= (float)num7 * num12;
				}
				if (mFlip == Flip.Vertically || mFlip == Flip.Both)
				{
					num2 += (float)num8 * num13;
					num4 -= (float)num6 * num13;
				}
				else
				{
					num2 += (float)num6 * num13;
					num4 -= (float)num8 * num13;
				}
			}
			if (mDrawRegion.x != 0f || mDrawRegion.y != 0f || mDrawRegion.z != 1f || mDrawRegion.w != 0f)
			{
				float num14;
				float num15;
				if (mFixedAspect)
				{
					num14 = 0f;
					num15 = 0f;
				}
				else
				{
					Vector4 vector2 = ((mAtlas != null) ? (border * pixelSize) : Vector4.zero);
					num14 = vector2.x + vector2.z;
					num15 = vector2.y + vector2.w;
				}
				float x = Mathf.Lerp(num, num3 - num14, mDrawRegion.x);
				float y = Mathf.Lerp(num2, num4 - num15, mDrawRegion.y);
				float z = Mathf.Lerp(num + num14, num3, mDrawRegion.z);
				float w = Mathf.Lerp(num2 + num15, num4, mDrawRegion.w);
				return new Vector4(x, y, z, w);
			}
			return new Vector4(num, num2, num3, num4);
		}
	}

	public override bool premultipliedAlpha
	{
		get
		{
			if (mAtlas is INGUIAtlas iNGUIAtlas)
			{
				return iNGUIAtlas.premultipliedAlpha;
			}
			return false;
		}
	}

	public UISpriteData GetSprite(string spriteName)
	{
		return atlas?.GetSprite(spriteName);
	}

	public override void MarkAsChanged()
	{
		mSprite = null;
		mSpriteSet = false;
		base.MarkAsChanged();
	}

	public UISpriteData GetAtlasSprite()
	{
		if (!mSpriteSet)
		{
			mSprite = null;
		}
		if (mSprite == null && mAtlas is INGUIAtlas iNGUIAtlas)
		{
			if (!string.IsNullOrEmpty(mSpriteName))
			{
				UISpriteData sprite = iNGUIAtlas.GetSprite(mSpriteName);
				if (sprite == null)
				{
					return null;
				}
				SetAtlasSprite(sprite);
			}
			if (mSprite == null && iNGUIAtlas.spriteList.Count > 0)
			{
				UISpriteData uISpriteData = iNGUIAtlas.spriteList[0];
				if (uISpriteData == null)
				{
					return null;
				}
				SetAtlasSprite(uISpriteData);
				if (mSprite == null)
				{
					Debug.LogError((iNGUIAtlas as UnityEngine.Object).name + " seems to have a null sprite!");
					return null;
				}
				mSpriteName = mSprite.name;
			}
		}
		return mSprite;
	}

	protected void SetAtlasSprite(UISpriteData sp)
	{
		mChanged = true;
		mSpriteSet = true;
		if (sp != null)
		{
			mSprite = sp;
			mSpriteName = mSprite.name;
		}
		else
		{
			mSpriteName = ((mSprite != null) ? mSprite.name : "");
			mSprite = sp;
		}
	}

	public override void MakePixelPerfect()
	{
		if (!isValid)
		{
			return;
		}
		base.MakePixelPerfect();
		if (mType == Type.Tiled)
		{
			return;
		}
		UISpriteData atlasSprite = GetAtlasSprite();
		if (atlasSprite == null)
		{
			return;
		}
		Texture texture = mainTexture;
		if (!(texture == null) && (mType == Type.Simple || mType == Type.Filled || !atlasSprite.hasBorder) && texture != null)
		{
			int num = Mathf.RoundToInt(pixelSize * (float)(atlasSprite.width + atlasSprite.paddingLeft + atlasSprite.paddingRight));
			int num2 = Mathf.RoundToInt(pixelSize * (float)(atlasSprite.height + atlasSprite.paddingTop + atlasSprite.paddingBottom));
			if ((num & 1) == 1)
			{
				num++;
			}
			if ((num2 & 1) == 1)
			{
				num2++;
			}
			base.width = num;
			base.height = num2;
		}
	}

	protected override void OnInit()
	{
		if (!mFillCenter)
		{
			mFillCenter = true;
			centerType = AdvancedType.Invisible;
		}
		base.OnInit();
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (mChanged || !mSpriteSet)
		{
			mSpriteSet = true;
			mSprite = null;
			mChanged = true;
		}
		if (mFixedAspect && ((mSpriteSet && mSprite != null) || GetAtlasSprite() != null) && mSprite != null)
		{
			int paddingLeft = mSprite.paddingLeft;
			int paddingBottom = mSprite.paddingBottom;
			int paddingRight = mSprite.paddingRight;
			int paddingTop = mSprite.paddingTop;
			int num = Mathf.RoundToInt(mSprite.width);
			int num2 = Mathf.RoundToInt(mSprite.height);
			int num3 = num + (paddingLeft + paddingRight);
			num2 += paddingTop + paddingBottom;
			float num4 = mWidth;
			float num5 = mHeight;
			float num6 = num4 / num5;
			float num7 = (float)num3 / (float)num2;
			if (num7 < num6)
			{
				float num8 = (num4 - num5 * num7) / num4 * 0.5f;
				base.drawRegion = new Vector4(num8, 0f, 1f - num8, 1f);
			}
			else
			{
				float num9 = (num5 - num4 / num7) / num5 * 0.5f;
				base.drawRegion = new Vector4(0f, num9, 1f, 1f - num9);
			}
		}
	}

	public override void OnFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
	{
		Texture texture = mainTexture;
		if (!(texture == null) && ((mSpriteSet && mSprite != null) || GetAtlasSprite() != null))
		{
			Rect rect = new Rect(mSprite.x, mSprite.y, mSprite.width, mSprite.height);
			Rect rect2 = new Rect(mSprite.x + mSprite.borderLeft, mSprite.y + mSprite.borderTop, mSprite.width - mSprite.borderLeft - mSprite.borderRight, mSprite.height - mSprite.borderBottom - mSprite.borderTop);
			rect = NGUIMath.ConvertToTexCoords(rect, texture.width, texture.height);
			rect2 = NGUIMath.ConvertToTexCoords(rect2, texture.width, texture.height);
			int count = verts.Count;
			Fill(verts, uvs, cols, rect, rect2);
			if (onPostFill != null)
			{
				onPostFill(this, count, verts, uvs, cols);
			}
		}
	}
}
