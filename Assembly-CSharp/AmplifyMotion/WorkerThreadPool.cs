using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x02000584 RID: 1412
	internal class WorkerThreadPool
	{
		// Token: 0x060023E7 RID: 9191 RVA: 0x001F7AD8 File Offset: 0x001F5CD8
		internal void InitializeAsyncUpdateThreads(int threadCount, bool systemThreadPool)
		{
			if (systemThreadPool)
			{
				this.m_threadPoolFallback = true;
				return;
			}
			try
			{
				this.m_threadPoolSize = threadCount;
				this.m_threadStateQueues = new Queue<MotionState>[this.m_threadPoolSize];
				this.m_threadStateQueueLocks = new object[this.m_threadPoolSize];
				this.m_threadPool = new Thread[this.m_threadPoolSize];
				this.m_threadPoolTerminateSignal = new ManualResetEvent(false);
				this.m_threadPoolContinueSignals = new AutoResetEvent[this.m_threadPoolSize];
				this.m_threadPoolLock = new object();
				this.m_threadPoolIndex = 0;
				for (int i = 0; i < this.m_threadPoolSize; i++)
				{
					this.m_threadStateQueues[i] = new Queue<MotionState>(1024);
					this.m_threadStateQueueLocks[i] = new object();
					this.m_threadPoolContinueSignals[i] = new AutoResetEvent(false);
					this.m_threadPool[i] = new Thread(new ParameterizedThreadStart(WorkerThreadPool.AsyncUpdateThread));
					this.m_threadPool[i].Start(new KeyValuePair<object, int>(this, i));
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("[AmplifyMotion] Non-critical error while initializing WorkerThreads. Falling back to using System.Threading.ThreadPool().\n" + ex.Message);
				this.m_threadPoolFallback = true;
			}
		}

		// Token: 0x060023E8 RID: 9192 RVA: 0x001F7BFC File Offset: 0x001F5DFC
		internal void FinalizeAsyncUpdateThreads()
		{
			if (!this.m_threadPoolFallback)
			{
				this.m_threadPoolTerminateSignal.Set();
				for (int i = 0; i < this.m_threadPoolSize; i++)
				{
					if (this.m_threadPool[i].IsAlive)
					{
						this.m_threadPoolContinueSignals[i].Set();
						this.m_threadPool[i].Join();
						this.m_threadPool[i] = null;
					}
					object obj = this.m_threadStateQueueLocks[i];
					lock (obj)
					{
						while (this.m_threadStateQueues[i].Count > 0)
						{
							this.m_threadStateQueues[i].Dequeue().AsyncUpdate();
						}
					}
				}
				this.m_threadStateQueues = null;
				this.m_threadStateQueueLocks = null;
				this.m_threadPoolSize = 0;
				this.m_threadPool = null;
				this.m_threadPoolTerminateSignal = null;
				this.m_threadPoolContinueSignals = null;
				this.m_threadPoolLock = null;
				this.m_threadPoolIndex = 0;
			}
		}

		// Token: 0x060023E9 RID: 9193 RVA: 0x001F7CF4 File Offset: 0x001F5EF4
		internal void EnqueueAsyncUpdate(MotionState state)
		{
			if (!this.m_threadPoolFallback)
			{
				object obj = this.m_threadStateQueueLocks[this.m_threadPoolIndex];
				lock (obj)
				{
					this.m_threadStateQueues[this.m_threadPoolIndex].Enqueue(state);
				}
				this.m_threadPoolContinueSignals[this.m_threadPoolIndex].Set();
				this.m_threadPoolIndex++;
				if (this.m_threadPoolIndex >= this.m_threadPoolSize)
				{
					this.m_threadPoolIndex = 0;
					return;
				}
			}
			else
			{
				ThreadPool.QueueUserWorkItem(new WaitCallback(WorkerThreadPool.AsyncUpdateCallback), state);
			}
		}

		// Token: 0x060023EA RID: 9194 RVA: 0x001F7D9C File Offset: 0x001F5F9C
		private static void AsyncUpdateCallback(object obj)
		{
			((MotionState)obj).AsyncUpdate();
		}

		// Token: 0x060023EB RID: 9195 RVA: 0x001F7DAC File Offset: 0x001F5FAC
		private static void AsyncUpdateThread(object obj)
		{
			KeyValuePair<object, int> keyValuePair = (KeyValuePair<object, int>)obj;
			WorkerThreadPool workerThreadPool = (WorkerThreadPool)keyValuePair.Key;
			int value = keyValuePair.Value;
			for (;;)
			{
				try
				{
					workerThreadPool.m_threadPoolContinueSignals[value].WaitOne();
					if (!workerThreadPool.m_threadPoolTerminateSignal.WaitOne(0))
					{
						for (;;)
						{
							MotionState motionState = null;
							object obj2 = workerThreadPool.m_threadStateQueueLocks[value];
							lock (obj2)
							{
								if (workerThreadPool.m_threadStateQueues[value].Count > 0)
								{
									motionState = workerThreadPool.m_threadStateQueues[value].Dequeue();
								}
							}
							if (motionState == null)
							{
								break;
							}
							motionState.AsyncUpdate();
						}
						continue;
					}
				}
				catch (Exception ex)
				{
					if (ex.GetType() != typeof(ThreadAbortException))
					{
						Debug.LogWarning(ex);
					}
					continue;
				}
				break;
			}
		}

		// Token: 0x04004B93 RID: 19347
		private const int ThreadStateQueueCapacity = 1024;

		// Token: 0x04004B94 RID: 19348
		internal Queue<MotionState>[] m_threadStateQueues;

		// Token: 0x04004B95 RID: 19349
		internal object[] m_threadStateQueueLocks;

		// Token: 0x04004B96 RID: 19350
		private int m_threadPoolSize;

		// Token: 0x04004B97 RID: 19351
		private ManualResetEvent m_threadPoolTerminateSignal;

		// Token: 0x04004B98 RID: 19352
		private AutoResetEvent[] m_threadPoolContinueSignals;

		// Token: 0x04004B99 RID: 19353
		private Thread[] m_threadPool;

		// Token: 0x04004B9A RID: 19354
		private bool m_threadPoolFallback;

		// Token: 0x04004B9B RID: 19355
		internal object m_threadPoolLock;

		// Token: 0x04004B9C RID: 19356
		internal int m_threadPoolIndex;
	}
}
