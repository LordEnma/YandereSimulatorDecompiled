using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000543 RID: 1347
	public static class CrossPlatformInputManager
	{
		// Token: 0x0600224B RID: 8779 RVA: 0x001F3021 File Offset: 0x001F1221
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x0600224C RID: 8780 RVA: 0x001F3041 File Offset: 0x001F1241
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

		// Token: 0x0600224D RID: 8781 RVA: 0x001F3060 File Offset: 0x001F1260
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x0600224E RID: 8782 RVA: 0x001F306D File Offset: 0x001F126D
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x001F307A File Offset: 0x001F127A
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x06002250 RID: 8784 RVA: 0x001F3087 File Offset: 0x001F1287
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x06002251 RID: 8785 RVA: 0x001F3094 File Offset: 0x001F1294
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x06002252 RID: 8786 RVA: 0x001F30AF File Offset: 0x001F12AF
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x06002253 RID: 8787 RVA: 0x001F30BC File Offset: 0x001F12BC
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x06002254 RID: 8788 RVA: 0x001F30C9 File Offset: 0x001F12C9
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x06002255 RID: 8789 RVA: 0x001F30D2 File Offset: 0x001F12D2
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x06002256 RID: 8790 RVA: 0x001F30DB File Offset: 0x001F12DB
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x06002257 RID: 8791 RVA: 0x001F30E9 File Offset: 0x001F12E9
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x06002258 RID: 8792 RVA: 0x001F30F6 File Offset: 0x001F12F6
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x06002259 RID: 8793 RVA: 0x001F3103 File Offset: 0x001F1303
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x0600225A RID: 8794 RVA: 0x001F3110 File Offset: 0x001F1310
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x0600225B RID: 8795 RVA: 0x001F311D File Offset: 0x001F131D
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x0600225C RID: 8796 RVA: 0x001F312A File Offset: 0x001F132A
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x0600225D RID: 8797 RVA: 0x001F3137 File Offset: 0x001F1337
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x001F3144 File Offset: 0x001F1344
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x0600225F RID: 8799 RVA: 0x001F3151 File Offset: 0x001F1351
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06002260 RID: 8800 RVA: 0x001F315F File Offset: 0x001F135F
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x06002261 RID: 8801 RVA: 0x001F316B File Offset: 0x001F136B
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x06002262 RID: 8802 RVA: 0x001F3178 File Offset: 0x001F1378
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x06002263 RID: 8803 RVA: 0x001F3185 File Offset: 0x001F1385
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04004AF9 RID: 19193
		private static VirtualInput activeInput;

		// Token: 0x04004AFA RID: 19194
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x04004AFB RID: 19195
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000691 RID: 1681
		public enum ActiveInputMethod
		{
			// Token: 0x040050B4 RID: 20660
			Hardware,
			// Token: 0x040050B5 RID: 20661
			Touch
		}

		// Token: 0x02000692 RID: 1682
		public class VirtualAxis
		{
			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x06002737 RID: 10039 RVA: 0x00206657 File Offset: 0x00204857
			// (set) Token: 0x06002738 RID: 10040 RVA: 0x0020665F File Offset: 0x0020485F
			public string name { get; private set; }

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x06002739 RID: 10041 RVA: 0x00206668 File Offset: 0x00204868
			// (set) Token: 0x0600273A RID: 10042 RVA: 0x00206670 File Offset: 0x00204870
			public bool matchWithInputManager { get; private set; }

			// Token: 0x0600273B RID: 10043 RVA: 0x00206679 File Offset: 0x00204879
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x0600273C RID: 10044 RVA: 0x00206683 File Offset: 0x00204883
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x0600273D RID: 10045 RVA: 0x00206699 File Offset: 0x00204899
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x0600273E RID: 10046 RVA: 0x002066A6 File Offset: 0x002048A6
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x0600273F RID: 10047 RVA: 0x002066AF File Offset: 0x002048AF
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x06002740 RID: 10048 RVA: 0x002066B7 File Offset: 0x002048B7
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x040050B7 RID: 20663
			private float m_Value;
		}

		// Token: 0x02000693 RID: 1683
		public class VirtualButton
		{
			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x06002741 RID: 10049 RVA: 0x002066BF File Offset: 0x002048BF
			// (set) Token: 0x06002742 RID: 10050 RVA: 0x002066C7 File Offset: 0x002048C7
			public string name { get; private set; }

			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x06002743 RID: 10051 RVA: 0x002066D0 File Offset: 0x002048D0
			// (set) Token: 0x06002744 RID: 10052 RVA: 0x002066D8 File Offset: 0x002048D8
			public bool matchWithInputManager { get; private set; }

			// Token: 0x06002745 RID: 10053 RVA: 0x002066E1 File Offset: 0x002048E1
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x06002746 RID: 10054 RVA: 0x002066EB File Offset: 0x002048EB
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x06002747 RID: 10055 RVA: 0x00206711 File Offset: 0x00204911
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x06002748 RID: 10056 RVA: 0x0020672E File Offset: 0x0020492E
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x06002749 RID: 10057 RVA: 0x00206742 File Offset: 0x00204942
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x0600274A RID: 10058 RVA: 0x0020674F File Offset: 0x0020494F
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000588 RID: 1416
			// (get) Token: 0x0600274B RID: 10059 RVA: 0x00206757 File Offset: 0x00204957
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000589 RID: 1417
			// (get) Token: 0x0600274C RID: 10060 RVA: 0x00206768 File Offset: 0x00204968
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x040050BB RID: 20667
			private int m_LastPressedFrame = -5;

			// Token: 0x040050BC RID: 20668
			private int m_ReleasedFrame = -5;

			// Token: 0x040050BD RID: 20669
			private bool m_Pressed;
		}
	}
}
