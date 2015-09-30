﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace Vestris.VMWareComLib
{
    /// <summary>
    /// The default implementation of the <see cref="Vestris.VMWareComLib.IVMWareSnapshotCollection" /> COM interface.
    /// </summary>
    [ComVisible(true)]
    [ComDefaultInterface(typeof(IVMWareSnapshotCollection))]
    [Guid("943582FB-8CC2-47a7-83F6-7D44A5CB62E0")]
    [ProgId("VMWareComLib.VMWareSnapshotCollection")]
    public class VMWareSnapshotCollection : IVMWareSnapshotCollection
    {
        private Vestris.VMWareLib.VMWareSnapshotCollection _snapshots = null;

        public VMWareSnapshotCollection()
        {
        }

        public VMWareSnapshotCollection(Vestris.VMWareLib.VMWareSnapshotCollection snapshots)
        {
            _snapshots = snapshots;
        }

        public IVMWareSnapshot FindSnapshot(string pathToSnapshot)
        {
            Vestris.VMWareLib.VMWareSnapshot snapshot = _snapshots.FindSnapshot(pathToSnapshot);
            return (snapshot == null ? null : new VMWareSnapshot(snapshot));
        }

        public IVMWareSnapshot FindSnapshotByName(string name)
        {
            Vestris.VMWareLib.VMWareSnapshot snapshot = _snapshots.FindSnapshotByName(name);
            return (snapshot == null ? null : new VMWareSnapshot(snapshot));
        }

        public object FindSnapshotsByName(string name)
        {
            List<Vestris.VMWareLib.VMWareSnapshot> snapshots = new List<Vestris.VMWareLib.VMWareSnapshot>(_snapshots.FindSnapshotsByName(name));
            List<VMWareSnapshot> result = new List<VMWareSnapshot>(snapshots.Count);
            foreach (Vestris.VMWareLib.VMWareSnapshot snapshot in snapshots)
            {
                result.Add(new VMWareSnapshot(snapshot));
            }
            return result.Cast<object>().ToArray();
        }

        public int Count
        {
            get
            {
                return _snapshots.Count;
            }
        }
    }
}
