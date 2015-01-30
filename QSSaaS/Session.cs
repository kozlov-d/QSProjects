﻿using System;
using System.ServiceModel.Web;
using System.ServiceModel;
using NLog;
using System.Threading;

namespace QSSaaS
{
	public class Session
	{
		public static String SaaSService = "http://localhost:8080/SaaS";
		public static String SessionId = String.Empty;

		public static bool IsSaasConnection = false;

		private static TimerCallback callback;
		private static Timer timer;
		private static Logger logger = LogManager.GetCurrentClassLogger ();

		private static void Refresh(Object StateInfo)
		{
			if (SaaSService == String.Empty) {
				logger.Error ("Не задан адрес сервиса!");
				return;
			}
			if (SessionId == String.Empty) {
				logger.Error ("Не задан ID сессии!");
				return;
			}
			try{
				Uri address = new Uri (SaaSService);
				var factory = new WebChannelFactory<ISaaSService> (new WebHttpBinding { AllowCookies = true }, address);
				ISaaSService svc = factory.CreateChannel ();
				if (!svc.refreshSession(SessionId))
					logger.Warn("Не удалось продлить сессию " + SessionId + ".");
				factory.Close();
			} catch (Exception ex) {
				logger.ErrorException ("Ошибка при продлении сессии " + SessionId + ".", ex);
			}
		}

		public static void CheckAndStartSessionRefresh()
		{
			if (!IsSaasConnection)
				return;
			callback = new TimerCallback (Refresh);
			timer = new Timer (callback, null, 0, 300000);
		}

		public static void CheckAndStopSessionRefresh()
		{
			if (!IsSaasConnection)
				return;
			timer.Dispose ();
		}
	}
}

