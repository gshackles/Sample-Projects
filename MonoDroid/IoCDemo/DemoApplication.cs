using System;
using Android.App;
using Funq;
using IoCDemo.Quotes;
using TinyIoC;

namespace IoCDemo
{
    [Application]
    public class DemoApplication : Application
    {
        public Container FunqContainer { get; private set; }

        public DemoApplication(IntPtr handle)
            : base(handle)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            initTinyIoC();
            initFunq();
        }

        private void initTinyIoC()
        {
            TinyIoCContainer.Current.Register<IMovieQuoteProvider>(new TheBigLebowskiQuoteProvider());
        }

        private void initFunq()
        {
            FunqContainer = new Container();

            FunqContainer.Register<IMovieQuoteProvider>(new SpaceballsQuoteProvider());
        }
    }
}