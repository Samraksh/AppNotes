using System;
using Microsoft.SPOT;

namespace Samraksh.AppNote {
    public partial class Program {
        // These must be the same in Base and Sensing programs
        private const string PayloadIdentifier = "DC";
        private enum MsgTypes : byte { Hello, Reply, Data };

        private static readonly int PayloadIdentifierSize = PayloadIdentifier.Length;
        private static readonly int PayloadTypeSize = sizeof(MsgTypes);
        private const int PayloadSequenceSize = sizeof(int);
        private const int PayloadTimeSize = sizeof(long);
        private static readonly int PayloadHeaderSize = PayloadIdentifierSize + PayloadTypeSize + PayloadSequenceSize + PayloadTimeSize;

        private const int PayloadIdentifierPos = 0;
        private static readonly int PayloadTypePos = PayloadIdentifierPos + PayloadIdentifierSize;
        private static readonly int PayloadSequencePos = PayloadTypePos + PayloadTypeSize;
        private static readonly int PayloadTimePos = PayloadSequencePos + PayloadSequenceSize;


        private const int PayloadDataSize = sizeof(int);
        private const int PayloadTimeDataSize = PayloadTimeSize + PayloadDataSize;
        private static byte[] _payloadIdentifierBytes = new byte[PayloadIdentifierSize];


    }
}
