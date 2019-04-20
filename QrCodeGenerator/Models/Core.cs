using Prism.Mvvm;
using QrCodeGenerator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QrCodeGenerator.Models
{
    public class Core : BindableBase
    {
        #region Fields
        #endregion

        #region Properties

        public QrGeneralConfiguration Config => this._qrHelper.Config;
        #endregion

        #region Helpers
        private QrCodeHelper _qrHelper;
        public QrCodeHelper QrHelper => _qrHelper;
        #endregion

        private Core()
        {
            _qrHelper = new QrCodeHelper();
        }

        private void OnConstructed()
        {
        }

        #region Sigleton
        static Core()
        {
            __instanceLocker.WaitOne(100);

            if (__instance == null)
            {
                __instance = new Core();
                __instance.OnConstructed();
            }
            __instanceLocker.ReleaseMutex();
        }

        private static Core __instance;
        private static Mutex __instanceLocker = new Mutex();

        public static Core Instance
        {
            get
            {
                __instanceLocker.WaitOne(100);

                if (__instance == null)
                {
                    __instance = new Core();
                    __instance.OnConstructed();
                }
                __instanceLocker.ReleaseMutex();
                return __instance;
            }
        }
        #endregion

        #region Dispose
        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Close()
        {
            Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                _disposed = true;
            }
        }
        public static void StaticClose()
        {
            if (__instance != null)
            {
                __instance.Dispose();
                __instance = null;
            }
        }
        #endregion
    }
}
