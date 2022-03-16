using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053D RID: 1341
	public static class CrossPlatformInputManager
	{
		// Token: 0x0600222C RID: 8748 RVA: 0x001F0825 File Offset: 0x001EEA25
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x0600222D RID: 8749 RVA: 0x001F0845 File Offset: 0x001EEA45
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

		// Token: 0x0600222E RID: 8750 RVA: 0x001F0864 File Offset: 0x001EEA64
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x0600222F RID: 8751 RVA: 0x001F0871 File Offset: 0x001EEA71
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x06002230 RID: 8752 RVA: 0x001F087E File Offset: 0x001EEA7E
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x06002231 RID: 8753 RVA: 0x001F088B File Offset: 0x001EEA8B
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x06002232 RID: 8754 RVA: 0x001F0898 File Offset: 0x001EEA98
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x06002233 RID: 8755 RVA: 0x001F08B3 File Offset: 0x001EEAB3
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x06002234 RID: 8756 RVA: 0x001F08C0 File Offset: 0x001EEAC0
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x06002235 RID: 8757 RVA: 0x001F08CD File Offset: 0x001EEACD
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x06002236 RID: 8758 RVA: 0x001F08D6 File Offset: 0x001EEAD6
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x06002237 RID: 8759 RVA: 0x001F08DF File Offset: 0x001EEADF
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x06002238 RID: 8760 RVA: 0x001F08ED File Offset: 0x001EEAED
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x06002239 RID: 8761 RVA: 0x001F08FA File Offset: 0x001EEAFA
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x0600223A RID: 8762 RVA: 0x001F0907 File Offset: 0x001EEB07
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x0600223B RID: 8763 RVA: 0x001F0914 File Offset: 0x001EEB14
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x0600223C RID: 8764 RVA: 0x001F0921 File Offset: 0x001EEB21
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x0600223D RID: 8765 RVA: 0x001F092E File Offset: 0x001EEB2E
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x0600223E RID: 8766 RVA: 0x001F093B File Offset: 0x001EEB3B
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x0600223F RID: 8767 RVA: 0x001F0948 File Offset: 0x001EEB48
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x06002240 RID: 8768 RVA: 0x001F0955 File Offset: 0x001EEB55
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06002241 RID: 8769 RVA: 0x001F0963 File Offset: 0x001EEB63
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x06002242 RID: 8770 RVA: 0x001F096F File Offset: 0x001EEB6F
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x06002243 RID: 8771 RVA: 0x001F097C File Offset: 0x001EEB7C
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x06002244 RID: 8772 RVA: 0x001F0989 File Offset: 0x001EEB89
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04004AB1 RID: 19121
		private static VirtualInput activeInput;

		// Token: 0x04004AB2 RID: 19122
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x04004AB3 RID: 19123
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x0200068B RID: 1675
		public enum ActiveInputMethod
		{
			// Token: 0x0400506C RID: 20588
			Hardware,
			// Token: 0x0400506D RID: 20589
			Touch
		}

		// Token: 0x0200068C RID: 1676
		public class VirtualAxis
		{
			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x06002718 RID: 10008 RVA: 0x00203D0B File Offset: 0x00201F0B
			// (set) Token: 0x06002719 RID: 10009 RVA: 0x00203D13 File Offset: 0x00201F13
			public string name { get; private set; }

			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x0600271A RID: 10010 RVA: 0x00203D1C File Offset: 0x00201F1C
			// (set) Token: 0x0600271B RID: 10011 RVA: 0x00203D24 File Offset: 0x00201F24
			public bool matchWithInputManager { get; private set; }

			// Token: 0x0600271C RID: 10012 RVA: 0x00203D2D File Offset: 0x00201F2D
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x0600271D RID: 10013 RVA: 0x00203D37 File Offset: 0x00201F37
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x0600271E RID: 10014 RVA: 0x00203D4D File Offset: 0x00201F4D
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x0600271F RID: 10015 RVA: 0x00203D5A File Offset: 0x00201F5A
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x06002720 RID: 10016 RVA: 0x00203D63 File Offset: 0x00201F63
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x06002721 RID: 10017 RVA: 0x00203D6B File Offset: 0x00201F6B
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x0400506F RID: 20591
			private float m_Value;
		}

		// Token: 0x0200068D RID: 1677
		public class VirtualButton
		{
			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x06002722 RID: 10018 RVA: 0x00203D73 File Offset: 0x00201F73
			// (set) Token: 0x06002723 RID: 10019 RVA: 0x00203D7B File Offset: 0x00201F7B
			public string name { get; private set; }

			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x06002724 RID: 10020 RVA: 0x00203D84 File Offset: 0x00201F84
			// (set) Token: 0x06002725 RID: 10021 RVA: 0x00203D8C File Offset: 0x00201F8C
			public bool matchWithInputManager { get; private set; }

			// Token: 0x06002726 RID: 10022 RVA: 0x00203D95 File Offset: 0x00201F95
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x06002727 RID: 10023 RVA: 0x00203D9F File Offset: 0x00201F9F
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x06002728 RID: 10024 RVA: 0x00203DC5 File Offset: 0x00201FC5
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x06002729 RID: 10025 RVA: 0x00203DE2 File Offset: 0x00201FE2
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x0600272A RID: 10026 RVA: 0x00203DF6 File Offset: 0x00201FF6
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x0600272B RID: 10027 RVA: 0x00203E03 File Offset: 0x00202003
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x0600272C RID: 10028 RVA: 0x00203E0B File Offset: 0x0020200B
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000588 RID: 1416
			// (get) Token: 0x0600272D RID: 10029 RVA: 0x00203E1C File Offset: 0x0020201C
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x04005073 RID: 20595
			private int m_LastPressedFrame = -5;

			// Token: 0x04005074 RID: 20596
			private int m_ReleasedFrame = -5;

			// Token: 0x04005075 RID: 20597
			private bool m_Pressed;
		}
	}
}
