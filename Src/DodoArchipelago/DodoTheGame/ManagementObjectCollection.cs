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
            //
        }

        internal ManagementObjectEnumerator GetEnumerator()
        {
            //TODO
            return default;
        }

        internal class ManagementObjectEnumerator : IDisposable
        {
            internal List<string> Current;

            public void Dispose()
            {
                //
            }

            internal bool MoveNext()
            {
                //TODO
                return true;
            }
        }
    }
}