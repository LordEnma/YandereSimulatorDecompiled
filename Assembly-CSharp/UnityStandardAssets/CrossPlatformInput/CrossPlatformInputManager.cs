using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000538 RID: 1336
	public static class CrossPlatformInputManager
	{
		// Token: 0x0600220E RID: 8718 RVA: 0x001EDEE5 File Offset: 0x001EC0E5
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x0600220F RID: 8719 RVA: 0x001EDF05 File Offset: 0x001EC105
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

		// Token: 0x06002210 RID: 8720 RVA: 0x001EDF24 File Offset: 0x001EC124
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x06002211 RID: 8721 RVA: 0x001EDF31 File Offset: 0x001EC131
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x06002212 RID: 8722 RVA: 0x001EDF3E File Offset: 0x001EC13E
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x06002213 RID: 8723 RVA: 0x001EDF4B File Offset: 0x001EC14B
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x06002214 RID: 8724 RVA: 0x001EDF58 File Offset: 0x001EC158
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x06002215 RID: 8725 RVA: 0x001EDF73 File Offset: 0x001EC173
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x06002216 RID: 8726 RVA: 0x001EDF80 File Offset: 0x001EC180
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x06002217 RID: 8727 RVA: 0x001EDF8D File Offset: 0x001EC18D
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x06002218 RID: 8728 RVA: 0x001EDF96 File Offset: 0x001EC196
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x06002219 RID: 8729 RVA: 0x001EDF9F File Offset: 0x001EC19F
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x0600221A RID: 8730 RVA: 0x001EDFAD File Offset: 0x001EC1AD
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x0600221B RID: 8731 RVA: 0x001EDFBA File Offset: 0x001EC1BA
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x0600221C RID: 8732 RVA: 0x001EDFC7 File Offset: 0x001EC1C7
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x0600221D RID: 8733 RVA: 0x001EDFD4 File Offset: 0x001EC1D4
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x0600221E RID: 8734 RVA: 0x001EDFE1 File Offset: 0x001EC1E1
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x001EDFEE File Offset: 0x001EC1EE
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001EDFFB File Offset: 0x001EC1FB
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x06002221 RID: 8737 RVA: 0x001EE008 File Offset: 0x001EC208
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x06002222 RID: 8738 RVA: 0x001EE015 File Offset: 0x001EC215
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06002223 RID: 8739 RVA: 0x001EE023 File Offset: 0x001EC223
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x06002224 RID: 8740 RVA: 0x001EE02F File Offset: 0x001EC22F
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x06002225 RID: 8741 RVA: 0x001EE03C File Offset: 0x001EC23C
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x06002226 RID: 8742 RVA: 0x001EE049 File Offset: 0x001EC249
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04004A35 RID: 18997
		private static VirtualInput activeInput;

		// Token: 0x04004A36 RID: 18998
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x04004A37 RID: 18999
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000686 RID: 1670
		public enum ActiveInputMethod
		{
			// Token: 0x04004FF0 RID: 20464
			Hardware,
			// Token: 0x04004FF1 RID: 20465
			Touch
		}

		// Token: 0x02000687 RID: 1671
		public class VirtualAxis
		{
			// Token: 0x1700057F RID: 1407
			// (get) Token: 0x060026FA RID: 9978 RVA: 0x002013CB File Offset: 0x001FF5CB
			// (set) Token: 0x060026FB RID: 9979 RVA: 0x002013D3 File Offset: 0x001FF5D3
			public string name { get; private set; }

			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x060026FC RID: 9980 RVA: 0x002013DC File Offset: 0x001FF5DC
			// (set) Token: 0x060026FD RID: 9981 RVA: 0x002013E4 File Offset: 0x001FF5E4
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026FE RID: 9982 RVA: 0x002013ED File Offset: 0x001FF5ED
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x060026FF RID: 9983 RVA: 0x002013F7 File Offset: 0x001FF5F7
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x06002700 RID: 9984 RVA: 0x0020140D File Offset: 0x001FF60D
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x06002701 RID: 9985 RVA: 0x0020141A File Offset: 0x001FF61A
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x06002702 RID: 9986 RVA: 0x00201423 File Offset: 0x001FF623
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x06002703 RID: 9987 RVA: 0x0020142B File Offset: 0x001FF62B
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x04004FF3 RID: 20467
			private float m_Value;
		}

		// Token: 0x02000688 RID: 1672
		public class VirtualButton
		{
			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x06002704 RID: 9988 RVA: 0x00201433 File Offset: 0x001FF633
			// (set) Token: 0x06002705 RID: 9989 RVA: 0x0020143B File Offset: 0x001FF63B
			public string name { get; private set; }

			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x06002706 RID: 9990 RVA: 0x00201444 File Offset: 0x001FF644
			// (set) Token: 0x06002707 RID: 9991 RVA: 0x0020144C File Offset: 0x001FF64C
			public bool matchWithInputManager { get; private set; }

			// Token: 0x06002708 RID: 9992 RVA: 0x00201455 File Offset: 0x001FF655
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x06002709 RID: 9993 RVA: 0x0020145F File Offset: 0x001FF65F
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x0600270A RID: 9994 RVA: 0x00201485 File Offset: 0x001FF685
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x0600270B RID: 9995 RVA: 0x002014A2 File Offset: 0x001FF6A2
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x0600270C RID: 9996 RVA: 0x002014B6 File Offset: 0x001FF6B6
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x0600270D RID: 9997 RVA: 0x002014C3 File Offset: 0x001FF6C3
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x0600270E RID: 9998 RVA: 0x002014CB File Offset: 0x001FF6CB
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x0600270F RID: 9999 RVA: 0x002014DC File Offset: 0x001FF6DC
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x04004FF7 RID: 20471
			private int m_LastPressedFrame = -5;

			// Token: 0x04004FF8 RID: 20472
			private int m_ReleasedFrame = -5;

			// Token: 0x04004FF9 RID: 20473
			private bool m_Pressed;
		}
	}
}
