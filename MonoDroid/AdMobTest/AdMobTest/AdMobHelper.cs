using System;
using Android.Runtime;
using Android.Views;

namespace AdMobTest
{
    public static class AdMobHelper
    {
        private static IntPtr _helperClass = JNIEnv.FindClass("samples/admobtest/AdMobHelper");

        public static void RegisterEmulatorAsTestDevice()
        {
            IntPtr methodId = JNIEnv.GetStaticMethodID(_helperClass, "registerEmulatorAsTestDevice", "()V");
            JNIEnv.CallStaticVoidMethod(_helperClass, methodId);
        }

        public static void RequestFreshAd(View view)
        {
            IntPtr methodId = JNIEnv.GetStaticMethodID(_helperClass, "requestFreshAd", "(Landroid/view/View;)V");
            JNIEnv.CallStaticVoidMethod(_helperClass, methodId, new JValue(view));
        }
    }
}