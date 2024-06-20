// Type: DodoTheGame.HardwareInfo


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DodoTheGame
{
    internal class ManagementObjectCollection : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        internal ManagementObjectEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        internal class ManagementObjectEnumerator : IDisposable
        {
            internal List<string> Current;

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            internal bool MoveNext()
            {
                throw new NotImplementedException();
            }
        }
    }
}