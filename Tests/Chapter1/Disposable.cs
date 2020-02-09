using System;

namespace Tests.Chapter1
{
    public class Disposable : IDisposable
    {
        public void Dispose()
        {
            // Stupid Mock
            GC.SuppressFinalize(this);
            GC.ReRegisterForFinalize(this);
        }
    }
}