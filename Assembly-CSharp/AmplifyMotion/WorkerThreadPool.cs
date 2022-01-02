using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x02000581 RID: 1409
	internal class WorkerThreadPool
	{
		// Token: 0x060023D6 RID: 9174 RVA: 0x001F5BC8 File Offset: 0x001F3DC8
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

		// Token: 0x060023D7 RID: 9175 RVA: 0x001F5CEC File Offset: 0x001F3EEC
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

		// Token: 0x060023D8 RID: 9176 RVA: 0x001F5DE4 File Offset: 0x001F3FE4
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

		// Token: 0x060023D9 RID: 9177 RVA: 0x001F5E8C File Offset: 0x001F408C
		private static void AsyncUpdateCallback(object obj)
		{
			((MotionState)obj).AsyncUpdate();
		}

		// Token: 0x060023DA RID: 9178 RVA: 0x001F5E9C File Offset: 0x001F409C
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

		// Token: 0x04004B6D RID: 19309
		private const int ThreadStateQueueCapacity = 1024;

		// Token: 0x04004B6E RID: 19310
		internal Queue<MotionState>[] m_threadStateQueues;

		// Token: 0x04004B6F RID: 19311
		internal object[] m_threadStateQueueLocks;

		// Token: 0x04004B70 RID: 19312
		private int m_threadPoolSize;

		// Token: 0x04004B71 RID: 19313
		private ManualResetEvent m_threadPoolTerminateSignal;

		// Token: 0x04004B72 RID: 19314
		private AutoResetEvent[] m_threadPoolContinueSignals;

		// Token: 0x04004B73 RID: 19315
		private Thread[] m_threadPool;

		// Token: 0x04004B74 RID: 19316
		private bool m_threadPoolFallback;

		// Token: 0x04004B75 RID: 19317
		internal object m_threadPoolLock;

		// Token: 0x04004B76 RID: 19318
		internal int m_threadPoolIndex;
	}
}
