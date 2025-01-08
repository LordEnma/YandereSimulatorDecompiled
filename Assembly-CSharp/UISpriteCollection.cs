using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Sprite Collection")]
public class UISpriteCollection : UIBasicSprite
{
	public struct Sprite
	{
		public UISpriteData sprite;

		public Vector2 pos;

		public float rot;

		public float width;

		public float height;

		public Color32 color;

		public Vector2 pivot;

		public Type type;

		public Flip flip;

		public bool enabled;

		public Vector4 GetDrawingDimensions(float pixelSize)
		{
			float num = (0f - pivot.x) * width;
			float num2 = (0f - pivot.y) * height;
			float num3 = num + width;
			float num4 = num2 + height;
			if (sprite != null && type != Type.Tiled)
			{
				int num5 = sprite.paddingLeft;
				int num6 = sprite.paddingBottom;
				int num7 = sprite.paddingRight;
				int num8 = sprite.paddingTop;
				if (type != 0 && pixelSize != 1f)
				{
					num5 = Mathf.RoundToInt(pixelSize * (float)num5);
					num6 = Mathf.RoundToInt(pixelSize * (float)num6);
					num7 = Mathf.RoundToInt(pixelSize * (float)num7);
					num8 = Mathf.RoundToInt(pixelSize * (float)num8);
				}
				int num9 = sprite.width + num5 + num7;
				int num10 = sprite.height + num6 + num8;
				float num11 = 1f;
				float num12 = 1f;
				if (num9 > 0 && num10 > 0 && (type == Type.Simple || type == Type.Filled))
				{
					if ((num9 & 1) != 0)
					{
						num7++;
					}
					if ((num10 & 1) != 0)
					{
						num8++;
					}
					num11 = 1f / (float)num9 * width;
					num12 = 1f / (float)num10 * height;
				}
				if (flip == Flip.Horizontally || flip == Flip.Both)
				{
					num += (float)num7 * num11;
					num3 -= (float)num5 * num11;
				}
				else
				{
					num += (float)num5 * num11;
					num3 -= (float)num7 * num11;
				}
				if (flip == Flip.Vertically || flip == Flip.Both)
				{
					num2 += (float)num8 * num12;
					num4 -= (float)num6 * num12;
				}
				else
				{
					num2 += (float)num6 * num12;
					num4 -= (float)num8 * num12;
				}
			}
			return new Vector4(num, num2, num3, num4);
		}
	}

	public delegate void OnHoverCB(object obj, bool isOver);

	public delegate void OnPressCB(object obj, bool isPressed);

	public delegate void OnClickCB(object obj);

	public delegate void OnDragCB(object obj, Vector2 delta);

	public delegate void OnTooltipCB(object obj, bool show);

	[HideInInspector]
	[SerializeField]
	private UnityEngine.Object mAtlas;

	[NonSerialized]
	private Dictionary<object, Sprite> mSprites = new Dictionary<object, Sprite>();

	[NonSerialized]
	private UISpriteData mSprite;

	public OnHoverCB onHover;

	public OnPressCB onPress;

	public OnClickCB onClick;

	public OnDragCB onDrag;

	public OnTooltipCB onTooltip;

	[NonSerialized]
	private object mLastHover;

	[NonSerialized]
	private object mLastPress;

	[NonSerialized]
	private object mLastTooltip;

	public override Texture mainTexture
	{
		get
		{
			Material material = null;
			INGUIAtlas iNGUIAtlas = atlas;
			if (iNGUIAtlas != null)
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
			return atlas?.spriteMaterial;
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
				mSprites.Clear();
				MarkAsChanged();
			}
		}
	}

	public override float pixelSize => atlas?.pixelSize ?? 1f;

	public override bool premultipliedAlpha => atlas?.premultipliedAlpha ?? false;

	public override Vector4 border
	{
		get
		{
			if (mSprite == null)
			{
				return base.border;
			}
			return new Vector4(mSprite.borderLeft, mSprite.borderBottom, mSprite.borderRight, mSprite.borderTop);
		}
	}

	protected override Vector4 padding
	{
		get
		{
			Vector4 result = new Vector4(0f, 0f, 0f, 0f);
			if (mSprite != null)
			{
				result.x = mSprite.paddingLeft;
				result.y = mSprite.paddingBottom;
				result.z = mSprite.paddingRight;
				result.w = mSprite.paddingTop;
			}
			return result;
		}
	}

	public override void OnFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
	{
		Texture texture = mainTexture;
		if (texture == null)
		{
			return;
		}
		int count = verts.Count;
		_ = base.drawRegion;
		foreach (KeyValuePair<object, Sprite> mSprite in mSprites)
		{
			Sprite value = mSprite.Value;
			if (!value.enabled)
			{
				continue;
			}
			this.mSprite = value.sprite;
			if (this.mSprite == null)
			{
				continue;
			}
			Color c = value.color;
			c.a = finalAlpha;
			if (c.a == 0f)
			{
				continue;
			}
			Rect rect = new Rect(this.mSprite.x, this.mSprite.y, this.mSprite.width, this.mSprite.height);
			Rect rect2 = new Rect(this.mSprite.x + this.mSprite.borderLeft, this.mSprite.y + this.mSprite.borderTop, this.mSprite.width - this.mSprite.borderLeft - this.mSprite.borderRight, this.mSprite.height - this.mSprite.borderBottom - this.mSprite.borderTop);
			mOuterUV = NGUIMath.ConvertToTexCoords(rect, texture.width, texture.height);
			mInnerUV = NGUIMath.ConvertToTexCoords(rect2, texture.width, texture.height);
			mFlip = value.flip;
			Vector4 v = value.GetDrawingDimensions(pixelSize);
			Vector4 u = base.drawingUVs;
			if (premultipliedAlpha)
			{
				c = NGUITools.ApplyPMA(c);
			}
			int count2 = verts.Count;
			switch (value.type)
			{
			case Type.Simple:
				SimpleFill(verts, uvs, cols, ref v, ref u, ref c);
				break;
			case Type.Sliced:
				SlicedFill(verts, uvs, cols, ref v, ref u, ref c);
				break;
			case Type.Filled:
				FilledFill(verts, uvs, cols, ref v, ref u, ref c);
				break;
			case Type.Tiled:
				TiledFill(verts, uvs, cols, ref v, ref c);
				break;
			case Type.Advanced:
				AdvancedFill(verts, uvs, cols, ref v, ref u, ref c);
				break;
			}
			if (value.rot != 0f)
			{
				float f = value.rot * ((float)Math.PI / 180f) * 0.5f;
				float num = Mathf.Sin(f);
				float num2 = Mathf.Cos(f);
				float num3 = num * 2f;
				float num4 = num * num3;
				float num5 = num2 * num3;
				int i = count2;
				for (int count3 = verts.Count; i < count3; i++)
				{
					Vector3 vector = verts[i];
					vector = new Vector3((1f - num4) * vector.x - num5 * vector.y, num5 * vector.x + (1f - num4) * vector.y, vector.z);
					vector.x += value.pos.x;
					vector.y += value.pos.y;
					verts[i] = vector;
				}
			}
			else
			{
				int j = count2;
				for (int count4 = verts.Count; j < count4; j++)
				{
					Vector3 value2 = verts[j];
					value2.x += value.pos.x;
					value2.y += value.pos.y;
					verts[j] = value2;
				}
			}
		}
		this.mSprite = null;
		if (onPostFill != null)
		{
			onPostFill(this, count, verts, uvs, cols);
		}
	}

	public void Add(object obj, string spriteName, Vector2 pos, float width, float height)
	{
		AddSprite(obj, spriteName, pos, width, height, new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), new Vector2(0.5f, 0.5f));
	}

	public void Add(object obj, string spriteName, Vector2 pos, float width, float height, Color32 color)
	{
		AddSprite(obj, spriteName, pos, width, height, color, new Vector2(0.5f, 0.5f));
	}

	public void AddSprite(object id, string spriteName, Vector2 pos, float width, float height, Color32 color, Vector2 pivot, float rot = 0f, Type type = Type.Simple, Flip flip = Flip.Nothing, bool enabled = true)
	{
		if (mAtlas == null)
		{
			Debug.LogError("Atlas must be assigned first");
			return;
		}
		Sprite value = default(Sprite);
		INGUIAtlas iNGUIAtlas = atlas;
		if (iNGUIAtlas != null)
		{
			value.sprite = iNGUIAtlas.GetSprite(spriteName);
		}
		if (value.sprite != null)
		{
			value.pos = pos;
			value.rot = rot;
			value.width = width;
			value.height = height;
			value.color = color;
			value.pivot = pivot;
			value.type = type;
			value.flip = flip;
			value.enabled = enabled;
			mSprites[id] = value;
			if (enabled && !mChanged)
			{
				MarkAsChanged();
			}
		}
	}

	public Sprite? GetSprite(object id)
	{
		if (mSprites.TryGetValue(id, out var value))
		{
			return value;
		}
		return null;
	}

	public bool RemoveSprite(object id)
	{
		if (mSprites.Remove(id))
		{
			if (!mChanged)
			{
				MarkAsChanged();
			}
			return true;
		}
		return false;
	}

	public bool SetSprite(object id, Sprite sp)
	{
		mSprites[id] = sp;
		if (!mChanged)
		{
			MarkAsChanged();
		}
		return true;
	}

	[ContextMenu("Clear")]
	public void Clear()
	{
		if (mSprites.Count != 0)
		{
			mSprites.Clear();
			MarkAsChanged();
		}
	}

	public bool IsActive(object id)
	{
		if (mSprites.TryGetValue(id, out var value))
		{
			return value.enabled;
		}
		return false;
	}

	public bool SetActive(object id, bool visible)
	{
		if (mSprites.TryGetValue(id, out var value))
		{
			if (value.enabled != visible)
			{
				value.enabled = visible;
				mSprites[id] = value;
				if (!mChanged)
				{
					MarkAsChanged();
				}
			}
			return true;
		}
		return false;
	}

	public bool SetPosition(object id, Vector2 pos, bool visible = true)
	{
		if (mSprites.TryGetValue(id, out var value))
		{
			if (value.pos != pos)
			{
				value.pos = pos;
				value.enabled = visible;
				mSprites[id] = value;
				if (!mChanged)
				{
					MarkAsChanged();
				}
			}
			else if (value.enabled != visible)
			{
				value.enabled = visible;
				mSprites[id] = value;
				if (!mChanged)
				{
					MarkAsChanged();
				}
			}
			return true;
		}
		return false;
	}

	private static Vector2 Rotate(Vector2 pos, float rot)
	{
		float f = rot * ((float)Math.PI / 180f) * 0.5f;
		float num = Mathf.Sin(f);
		float num2 = Mathf.Cos(f);
		float num3 = num * 2f;
		float num4 = num * num3;
		float num5 = num2 * num3;
		return new Vector2((1f - num4) * pos.x - num5 * pos.y, num5 * pos.x + (1f - num4) * pos.y);
	}

	public object GetCurrentSpriteID()
	{
		return GetCurrentSpriteID(UICamera.lastWorldPosition);
	}

	public Sprite? GetCurrentSprite()
	{
		return GetCurrentSprite(UICamera.lastWorldPosition);
	}

	public object GetCurrentSpriteID(Vector3 worldPos)
	{
		Vector2 vector = mTrans.InverseTransformPoint(worldPos);
		foreach (KeyValuePair<object, Sprite> mSprite in mSprites)
		{
			Sprite value = mSprite.Value;
			Vector2 pos = vector - value.pos;
			if (value.rot != 0f)
			{
				pos = Rotate(pos, 0f - value.rot);
			}
			Vector4 vector2 = value.GetDrawingDimensions(pixelSize);
			if (!(pos.x < vector2.x) && !(pos.y < vector2.y) && !(pos.x > vector2.z) && !(pos.y > vector2.w))
			{
				return mSprite.Key;
			}
		}
		return null;
	}

	public Sprite? GetCurrentSprite(Vector3 worldPos)
	{
		Vector2 vector = mTrans.InverseTransformPoint(worldPos);
		foreach (KeyValuePair<object, Sprite> mSprite in mSprites)
		{
			Sprite value = mSprite.Value;
			Vector2 pos = vector - value.pos;
			if (value.rot != 0f)
			{
				pos = Rotate(pos, 0f - value.rot);
			}
			Vector4 vector2 = value.GetDrawingDimensions(pixelSize);
			if (!(pos.x < vector2.x) && !(pos.y < vector2.y) && !(pos.x > vector2.z) && !(pos.y > vector2.w))
			{
				return mSprite.Value;
			}
		}
		return null;
	}

	protected void OnClick()
	{
		if (onClick != null)
		{
			object currentSpriteID = GetCurrentSpriteID();
			if (currentSpriteID != null)
			{
				onClick(currentSpriteID);
			}
		}
	}

	protected void OnPress(bool isPressed)
	{
		if (onPress == null || (isPressed && mLastPress != null))
		{
			return;
		}
		if (isPressed)
		{
			mLastPress = GetCurrentSpriteID();
			if (mLastPress != null)
			{
				onPress(mLastPress, isPressed: true);
			}
		}
		else if (mLastPress != null)
		{
			onPress(mLastPress, isPressed: false);
			mLastPress = null;
		}
	}

	protected void OnHover(bool isOver)
	{
		if (onHover != null)
		{
			if (isOver)
			{
				UICamera.onMouseMove = (UICamera.MoveDelegate)Delegate.Combine(UICamera.onMouseMove, new UICamera.MoveDelegate(OnMove));
				OnMove(Vector2.zero);
			}
			else
			{
				UICamera.onMouseMove = (UICamera.MoveDelegate)Delegate.Remove(UICamera.onMouseMove, new UICamera.MoveDelegate(OnMove));
			}
		}
	}

	protected void OnMove(Vector2 delta)
	{
		if (!this || onHover == null)
		{
			return;
		}
		object currentSpriteID = GetCurrentSpriteID();
		if (mLastHover != currentSpriteID)
		{
			if (mLastHover != null)
			{
				onHover(mLastHover, isOver: false);
			}
			mLastHover = currentSpriteID;
			if (mLastHover != null)
			{
				onHover(mLastHover, isOver: true);
			}
		}
	}

	protected void OnDrag(Vector2 delta)
	{
		if (onDrag != null && mLastPress != null)
		{
			onDrag(mLastPress, delta);
		}
	}

	protected void OnTooltip(bool show)
	{
		if (onTooltip == null)
		{
			return;
		}
		if (show)
		{
			if (mLastTooltip != null)
			{
				onTooltip(mLastTooltip, show: false);
			}
			mLastTooltip = GetCurrentSpriteID();
			if (mLastTooltip != null)
			{
				onTooltip(mLastTooltip, show: true);
			}
		}
		else
		{
			onTooltip(mLastTooltip, show: false);
			mLastTooltip = null;
		}
	}
}
