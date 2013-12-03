/*------------------------------------------------------------------------
 *      Declarations & constants that are common between Base and Sensing nodes
 * ---------------------------------------------------------------------*/


/*------------------------------------------------------------------------
 * Message Formats
 * 
 * Hello
 *      App Identifier (2)
 *      Payload Type (1) : Hello
 *      Payload Sequence Number (4)
 *      Payload Send Time (8)
 *  Data
 *      App Identifier (2)
 *      Payload Type (1) : Data
 *      Payload Sequence Number (4)
 *      Payload Send Time (8)
 *      
 *      Sensing Time 1 (8)
 *      Sensed Data 1 (4)
 *          ...
 *      Sensint Time N (8)
 *      Sensed Data N (4)
 *  Reply
 *      App Identifier (2)
 *      Payload Type (1) : Reply
 *      Payload Sequence Number (4)
 * ---------------------------------------------------------------------*/


using Microsoft.SPOT;

namespace Samraksh.AppNote {

    public partial class Program {
        private enum PayloadTypes : byte { Hello, Reply, Data };

        private const string ApplicationId = "DC";
        private static readonly int ApplicationIdSize = ApplicationId.Length;
        private const int ApplicationIdPos = 0;
        private static byte[] _applicationIdBytes = new byte[ApplicationIdSize];
        
        private static readonly int MessageTypeSize = sizeof(PayloadTypes);
        private static readonly int MessageTypePos = ApplicationIdPos + ApplicationIdSize;
        
        private const int MessageSequenceSize = sizeof(int);
        private static readonly int MessageSequencePos = MessageTypePos + MessageTypeSize;
        
        private const int MessageTimeSize = sizeof(long);
        private static readonly int MessageTimePos = MessageSequencePos + MessageSequenceSize;

        private static readonly int PayloadHeaderSize = ApplicationIdSize + MessageTypeSize + MessageSequenceSize + MessageTimeSize;

        private const int PayloadDataSize = sizeof(int);
        private const int PayloadTimeDataPos = MessageTimeSize + PayloadDataSize;
    }
}
