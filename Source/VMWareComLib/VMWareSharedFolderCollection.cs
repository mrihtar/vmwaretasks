using System;
using System.Runtime.InteropServices;

namespace Vestris.VMWareComLib
{
    /// <summary>
    /// The default implementation of the <see cref="Vestris.VMWareComLib.IVMWareSharedFolderCollection" /> COM interface.
    /// </summary>
    [ComVisible(true)]
    [ComDefaultInterface(typeof(IVMWareSharedFolderCollection))]
    [Guid("A5C7F11C-6869-4e2d-8418-79A9E00E32FA")]
    [ProgId("VMWareComLib.VMWareSharedFolderCollection")]
    public class VMWareSharedFolderCollection : IVMWareSharedFolderCollection
    {
        private Vestris.VMWareLib.VMWareSharedFolderCollection _coll = null;

        public VMWareSharedFolderCollection()
        {

        }

        public VMWareSharedFolderCollection(Vestris.VMWareLib.VMWareSharedFolderCollection coll)
        {
            _coll = coll;
        }

        public void Add(string shareName, string hostPath, int flags)
        {
            Vestris.VMWareLib.VMWareSharedFolder SharedFolder;
            SharedFolder = new Vestris.VMWareLib.VMWareSharedFolder(shareName, hostPath, flags);
            _coll.Add(SharedFolder);
        }

        public void Clear()
        {
            _coll.Clear();
        }

        public bool Contains(string shareName)
        {
            for (int ii = 0; ii < _coll.Count; ii++)
                if (_coll[ii].ShareName == shareName)
                    return true;
            return false;
        }

        public bool Remove(string shareName)
        {
            for (int ii = 0; ii < _coll.Count; ii++)
                if (_coll[ii].ShareName == shareName)
                    return _coll.Remove(_coll[ii]);
            return false;
        }

        public int Count
        {
            get
            {
                return _coll.Count;
            }
        }

        public bool Enabled
        {
            set
            {
                _coll.Enabled = value;
            }
        }

        public IVMWareSharedFolder this[int index]
        {
            get
            {
                return new VMWareSharedFolder(_coll[index]);
            }
        }

        public void SetState(string shareName, string hostPath, int flags)
        {
            for (int ii = 0; ii < _coll.Count; ii++)
                if (_coll[ii].ShareName == shareName && _coll[ii].HostPath == hostPath)
                {
                    _coll.SetState(_coll[ii], flags);
                    return;
                }
        }
    }
}
