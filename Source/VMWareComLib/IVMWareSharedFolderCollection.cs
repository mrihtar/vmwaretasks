using System;
using System.Runtime.InteropServices;

namespace Vestris.VMWareComLib
{
    /// <summary>
    /// A COM interface to <see cref="Vestris.VMWareLib.VMWareSharedFolderCollection" />.
    /// </summary>
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("D43E20F9-F151-4b44-BD5B-13AFA7FB27D5")]
    public interface IVMWareSharedFolderCollection
    {
        void Add(string shareName, string hostPath, int flags);
        void Clear();
        bool Contains(string shareName);
        bool Remove(string shareName);
        int Count { get; }
        bool Enabled { set; }
        IVMWareSharedFolder this[int index] { get; }
        void SetState(string shareName, string hostPath, int flags);
    }
}
