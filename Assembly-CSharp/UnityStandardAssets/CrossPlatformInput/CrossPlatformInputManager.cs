using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000536 RID: 1334
	public static class CrossPlatformInputManager
	{
		// Token: 0x060021FB RID: 8699 RVA: 0x001ECC4D File Offset: 0x001EAE4D
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x060021FC RID: 8700 RVA: 0x001ECC6D File Offset: 0x001EAE6D
		public static void SwitchActiveInputMethod(CrossPlatformInputManager.ActiveInputMethod activeInputMethod)
		{
			if (activeInputMethod == CrossPlatformInputManager.ActiveInputMethod.Hardware)
			{
				CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
				return;
			}
			if (activeInputMethod != CrossPlatformInputManager.ActiveInputMethod.Touch)
			{
				return;
			}
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_TouchInput;
		}

		// Token: 0x060021FD RID: 8701 RVA: 0x001ECC8C File Offset: 0x001EAE8C
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x060021FE RID: 8702 RVA: 0x001ECC99 File Offset: 0x001EAE99
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x060021FF RID: 8703 RVA: 0x001ECCA6 File Offset: 0x001EAEA6
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x06002200 RID: 8704 RVA: 0x001ECCB3 File Offset: 0x001EAEB3
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x06002201 RID: 8705 RVA: 0x001ECCC0 File Offset: 0x001EAEC0
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x06002202 RID: 8706 RVA: 0x001ECCDB File Offset: 0x001EAEDB
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x06002203 RID: 8707 RVA: 0x001ECCE8 File Offset: 0x001EAEE8
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x06002204 RID: 8708 RVA: 0x001ECCF5 File Offset: 0x001EAEF5
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x06002205 RID: 8709 RVA: 0x001ECCFE File Offset: 0x001EAEFE
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x06002206 RID: 8710 RVA: 0x001ECD07 File Offset: 0x001EAF07
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x06002207 RID: 8711 RVA: 0x001ECD15 File Offset: 0x001EAF15
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x06002208 RID: 8712 RVA: 0x001ECD22 File Offset: 0x001EAF22
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x06002209 RID: 8713 RVA: 0x001ECD2F File Offset: 0x001EAF2F
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x0600220A RID: 8714 RVA: 0x001ECD3C File Offset: 0x001EAF3C
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x0600220B RID: 8715 RVA: 0x001ECD49 File Offset: 0x001EAF49
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x0600220C RID: 8716 RVA: 0x001ECD56 File Offset: 0x001EAF56
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x0600220D RID: 8717 RVA: 0x001ECD63 File Offset: 0x001EAF63
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x0600220E RID: 8718 RVA: 0x001ECD70 File Offset: 0x001EAF70
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x0600220F RID: 8719 RVA: 0x001ECD7D File Offset: 0x001EAF7D
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06002210 RID: 8720 RVA: 0x001ECD8B File Offset: 0x001EAF8B
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x06002211 RID: 8721 RVA: 0x001ECD97 File Offset: 0x001EAF97
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x06002212 RID: 8722 RVA: 0x001ECDA4 File Offset: 0x001EAFA4
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x06002213 RID: 8723 RVA: 0x001ECDB1 File Offset: 0x001EAFB1
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04004A19 RID: 18969
		private static VirtualInput activeInput;

		// Token: 0x04004A1A RID: 18970
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x04004A1B RID: 18971
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000682 RID: 1666
		public enum ActiveInputMethod
		{
			// Token: 0x04004FCF RID: 20431
			Hardware,
			// Token: 0x04004FD0 RID: 20432
			Touch
		}

		// Token: 0x02000683 RID: 1667
		public class VirtualAxis
		{
			// Token: 0x1700057B RID: 1403
			// (get) Token: 0x060026DE RID: 9950 RVA: 0x0020006B File Offset: 0x001FE26B
			// (set) Token: 0x060026DF RID: 9951 RVA: 0x00200073 File Offset: 0x001FE273
			public string name { get; private set; }

			// Token: 0x1700057C RID: 1404
			// (get) Token: 0x060026E0 RID: 9952 RVA: 0x0020007C File Offset: 0x001FE27C
			// (set) Token: 0x060026E1 RID: 9953 RVA: 0x00200084 File Offset: 0x001FE284
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026E2 RID: 9954 RVA: 0x0020008D File Offset: 0x001FE28D
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x060026E3 RID: 9955 RVA: 0x00200097 File Offset: 0x001FE297
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026E4 RID: 9956 RVA: 0x002000AD File Offset: 0x001FE2AD
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x060026E5 RID: 9957 RVA: 0x002000BA File Offset: 0x001FE2BA
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x1700057D RID: 1405
			// (get) Token: 0x060026E6 RID: 9958 RVA: 0x002000C3 File Offset: 0x001FE2C3
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x1700057E RID: 1406
			// (get) Token: 0x060026E7 RID: 9959 RVA: 0x002000CB File Offset: 0x001FE2CB
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x04004FD2 RID: 20434
			private float m_Value;
		}

		// Token: 0x02000684 RID: 1668
		public class VirtualButton
		{
			// Token: 0x1700057F RID: 1407
			// (get) Token: 0x060026E8 RID: 9960 RVA: 0x002000D3 File Offset: 0x001FE2D3
			// (set) Token: 0x060026E9 RID: 9961 RVA: 0x002000DB File Offset: 0x001FE2DB
			public string name { get; private set; }

			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x060026EA RID: 9962 RVA: 0x002000E4 File Offset: 0x001FE2E4
			// (set) Token: 0x060026EB RID: 9963 RVA: 0x002000EC File Offset: 0x001FE2EC
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026EC RID: 9964 RVA: 0x002000F5 File Offset: 0x001FE2F5
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x060026ED RID: 9965 RVA: 0x002000FF File Offset: 0x001FE2FF
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026EE RID: 9966 RVA: 0x00200125 File Offset: 0x001FE325
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x060026EF RID: 9967 RVA: 0x00200142 File Offset: 0x001FE342
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x060026F0 RID: 9968 RVA: 0x00200156 File Offset: 0x001FE356
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x060026F1 RID: 9969 RVA: 0x00200163 File Offset: 0x001FE363
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x060026F2 RID: 9970 RVA: 0x0020016B File Offset: 0x001FE36B
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x060026F3 RID: 9971 RVA: 0x0020017C File Offset: 0x001FE37C
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x04004FD6 RID: 20438
			private int m_LastPressedFrame = -5;

			// Token: 0x04004FD7 RID: 20439
			private int m_ReleasedFrame = -5;

			// Token: 0x04004FD8 RID: 20440
			private bool m_Pressed;
		}
	}
}
