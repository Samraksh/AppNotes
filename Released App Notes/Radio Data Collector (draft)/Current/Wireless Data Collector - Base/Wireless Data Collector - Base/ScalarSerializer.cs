//using System;
//using Microsoft.SPOT;

//namespace Samraksh.AppNote.Utility {
//    public static class ScalarSerializer {


//        //public static long ToInt64(byte[] rcvPayloadBytes, int startPos) {
//        //    long scalar = 0;
//        //    for (int i = 0; i < 8; i++) {
//        //        scalar = scalar | (byte)(rcvPayloadBytes[startPos + i] >> i * 8);
//        //    }
//        //    return scalar;
//        //}

//        //public static int ToInt32(byte[] rcvPayloadBytes, int startPos) {
//        //    int scalar = 0;
//        //    for (int i = 0; i < 4; i++) {
//        //        scalar = scalar | (byte)(rcvPayloadBytes[startPos + i] >> i * 8);
//        //    }
//        //    return scalar;
//        //}

//        public static byte[] GetBytes(long value) {
//            return new byte[8] { 
//                    (byte)(value & 0xFF), 
//                    (byte)((value >> 8) & 0xFF), 
//                    (byte)((value >> 16) & 0xFF), 
//                    (byte)((value >> 24) & 0xFF),
//                    (byte)((value >> 32) & 0xFF),
//                    (byte)((value >> 40) & 0xFF),
//                    (byte)((value >> 48) & 0xFF),
//                    (byte)((value >> 56) & 0xFF)};
//        }
        
//        public static byte[] GetBytes(int value) {
//            return new byte[4] { 
//                    (byte)(value & 0xFF), 
//                    (byte)((value >> 8) & 0xFF), 
//                    (byte)((value >> 16) & 0xFF), 
//                    (byte)((value >> 24) & 0xFF) };
//        }

//        public static int ToInt32(byte[] value, int index = 0) {
//            return (
//                value[0 + index] << 0 |
//                value[1 + index] << 8 |
//                value[2 + index] << 16 |
//                value[3 + index] << 24);
//        }
        
//        public static long ToInt64(byte[] value, int index = 0) {
//            return (
//                (long)value[0 + index] << 0 |
//                (long)value[1 + index] << 8 |
//                (long)value[2 + index] << 16 |
//                (long)value[3 + index] << 24 |
//                (long)value[4 + index] << 32 |
//                (long)value[5 + index] << 40 |
//                (long)value[6 + index] << 48 |
//                (long)value[7 + index] << 56);
//        }

//    }
//}
