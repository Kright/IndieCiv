using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQWorkerJob
    {
        public enum BIQWorkerJobSizes
        {
            WorkerName = 32,
            CivilopediaEntry = 32,
            Order = 32,
        };

		string WorkerName { get; set; }
        string CivilopediaEntry { get; set; }
        int Turns { get; set; }
        int Required { get; set; }
        int RequireResource1 { get; set; }
        int RequireResource2 { get; set; }
        string Order { get; set; }

        public void Load( BinaryFormatter formatter )
        {
            WorkerName = formatter.ReadChars( ( int ) BIQWorkerJobSizes.WorkerName );
            CivilopediaEntry = formatter.ReadChars( ( int ) BIQWorkerJobSizes.CivilopediaEntry );

            Turns = formatter.ReadInt32();
            Required = formatter.ReadInt32();
            RequireResource1 = formatter.ReadInt32();
            RequireResource2 = formatter.ReadInt32();
            Order = formatter.ReadChars( ( int ) BIQWorkerJobSizes.Order );
        }
    }
}
