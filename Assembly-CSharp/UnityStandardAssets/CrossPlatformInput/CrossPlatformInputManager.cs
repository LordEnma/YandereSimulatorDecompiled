using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000536 RID: 1334
	public static class CrossPlatformInputManager
	{
		// Token: 0x060021FE RID: 8702 RVA: 0x001ECE51 File Offset: 0x001EB051
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x060021FF RID: 8703 RVA: 0x001ECE71 File Offset: 0x001EB071
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

		// Token: 0x06002200 RID: 8704 RVA: 0x001ECE90 File Offset: 0x001EB090
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x06002201 RID: 8705 RVA: 0x001ECE9D File Offset: 0x001EB09D
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x06002202 RID: 8706 RVA: 0x001ECEAA File Offset: 0x001EB0AA
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x06002203 RID: 8707 RVA: 0x001ECEB7 File Offset: 0x001EB0B7
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x06002204 RID: 8708 RVA: 0x001ECEC4 File Offset: 0x001EB0C4
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x06002205 RID: 8709 RVA: 0x001ECEDF File Offset: 0x001EB0DF
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x06002206 RID: 8710 RVA: 0x001ECEEC File Offset: 0x001EB0EC
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x06002207 RID: 8711 RVA: 0x001ECEF9 File Offset: 0x001EB0F9
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x06002208 RID: 8712 RVA: 0x001ECF02 File Offset: 0x001EB102
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x06002209 RID: 8713 RVA: 0x001ECF0B File Offset: 0x001EB10B
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x0600220A RID: 8714 RVA: 0x001ECF19 File Offset: 0x001EB119
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x0600220B RID: 8715 RVA: 0x001ECF26 File Offset: 0x001EB126
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x0600220C RID: 8716 RVA: 0x001ECF33 File Offset: 0x001EB133
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x0600220D RID: 8717 RVA: 0x001ECF40 File Offset: 0x001EB140
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x0600220E RID: 8718 RVA: 0x001ECF4D File Offset: 0x001EB14D
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x0600220F RID: 8719 RVA: 0x001ECF5A File Offset: 0x001EB15A
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x06002210 RID: 8720 RVA: 0x001ECF67 File Offset: 0x001EB167
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x06002211 RID: 8721 RVA: 0x001ECF74 File Offset: 0x001EB174
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x06002212 RID: 8722 RVA: 0x001ECF81 File Offset: 0x001EB181
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06002213 RID: 8723 RVA: 0x001ECF8F File Offset: 0x001EB18F
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x06002214 RID: 8724 RVA: 0x001ECF9B File Offset: 0x001EB19B
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x06002215 RID: 8725 RVA: 0x001ECFA8 File Offset: 0x001EB1A8
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x06002216 RID: 8726 RVA: 0x001ECFB5 File Offset: 0x001EB1B5
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04004A1C RID: 18972
		private static VirtualInput activeInput;

		// Token: 0x04004A1D RID: 18973
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x04004A1E RID: 18974
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000682 RID: 1666
		public enum ActiveInputMethod
		{
			// Token: 0x04004FD2 RID: 20434
			Hardware,
			// Token: 0x04004FD3 RID: 20435
			Touch
		}

		// Token: 0x02000683 RID: 1667
		public class VirtualAxis
		{
			// Token: 0x1700057C RID: 1404
			// (get) Token: 0x060026E1 RID: 9953 RVA: 0x0020026F File Offset: 0x001FE46F
			// (set) Token: 0x060026E2 RID: 9954 RVA: 0x00200277 File Offset: 0x001FE477
			public string name { get; private set; }

			// Token: 0x1700057D RID: 1405
			// (get) Token: 0x060026E3 RID: 9955 RVA: 0x00200280 File Offset: 0x001FE480
			// (set) Token: 0x060026E4 RID: 9956 RVA: 0x00200288 File Offset: 0x001FE488
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026E5 RID: 9957 RVA: 0x00200291 File Offset: 0x001FE491
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x060026E6 RID: 9958 RVA: 0x0020029B File Offset: 0x001FE49B
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026E7 RID: 9959 RVA: 0x002002B1 File Offset: 0x001FE4B1
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x060026E8 RID: 9960 RVA: 0x002002BE File Offset: 0x001FE4BE
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x1700057E RID: 1406
			// (get) Token: 0x060026E9 RID: 9961 RVA: 0x002002C7 File Offset: 0x001FE4C7
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x1700057F RID: 1407
			// (get) Token: 0x060026EA RID: 9962 RVA: 0x002002CF File Offset: 0x001FE4CF
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x04004FD5 RID: 20437
			private float m_Value;
		}

		// Token: 0x02000684 RID: 1668
		public class VirtualButton
		{
			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x060026EB RID: 9963 RVA: 0x002002D7 File Offset: 0x001FE4D7
			// (set) Token: 0x060026EC RID: 9964 RVA: 0x002002DF File Offset: 0x001FE4DF
			public string name { get; private set; }

			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x060026ED RID: 9965 RVA: 0x002002E8 File Offset: 0x001FE4E8
			// (set) Token: 0x060026EE RID: 9966 RVA: 0x002002F0 File Offset: 0x001FE4F0
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026EF RID: 9967 RVA: 0x002002F9 File Offset: 0x001FE4F9
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x060026F0 RID: 9968 RVA: 0x00200303 File Offset: 0x001FE503
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026F1 RID: 9969 RVA: 0x00200329 File Offset: 0x001FE529
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x060026F2 RID: 9970 RVA: 0x00200346 File Offset: 0x001FE546
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x060026F3 RID: 9971 RVA: 0x0020035A File Offset: 0x001FE55A
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x060026F4 RID: 9972 RVA: 0x00200367 File Offset: 0x001FE567
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x060026F5 RID: 9973 RVA: 0x0020036F File Offset: 0x001FE56F
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x060026F6 RID: 9974 RVA: 0x00200380 File Offset: 0x001FE580
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x04004FD9 RID: 20441
			private int m_LastPressedFrame = -5;

			// Token: 0x04004FDA RID: 20442
			private int m_ReleasedFrame = -5;

			// Token: 0x04004FDB RID: 20443
			private bool m_Pressed;
		}
	}
}
