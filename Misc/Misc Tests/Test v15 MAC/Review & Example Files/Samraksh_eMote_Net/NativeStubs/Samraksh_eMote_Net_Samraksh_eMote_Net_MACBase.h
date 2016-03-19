//-----------------------------------------------------------------------------
//
//                   ** WARNING! ** 
//    This file was generated automatically by a tool.
//    Re-running the tool will overwrite this file.
//    You should copy this file to a custom location
//    before adding any customization in the copy to
//    prevent loss of your changes when the tool is
//    re-run.
//
//-----------------------------------------------------------------------------


#ifndef _SAMRAKSH_EMOTE_NET_SAMRAKSH_EMOTE_NET_MACBASE_H_
#define _SAMRAKSH_EMOTE_NET_SAMRAKSH_EMOTE_NET_MACBASE_H_

namespace Samraksh
{
    namespace eMote
    {
        namespace Net
        {
            struct MACBase
            {
                // Helper Functions to access fields of managed object
                static UNSUPPORTED_TYPE& Get_NeighborList( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_UNSUPPORTED_TYPE( pMngObj, Library_Samraksh_eMote_Net_Samraksh_eMote_Net_MACBase::FIELD__NeighborList ); }

                static UNSUPPORTED_TYPE& Get_ByteNeighbor( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_UNSUPPORTED_TYPE( pMngObj, Library_Samraksh_eMote_Net_Samraksh_eMote_Net_MACBase::FIELD__ByteNeighbor ); }

                static UNSUPPORTED_TYPE& Get_MarshalBuffer( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_UNSUPPORTED_TYPE( pMngObj, Library_Samraksh_eMote_Net_Samraksh_eMote_Net_MACBase::FIELD__MarshalBuffer ); }

                static UNSUPPORTED_TYPE& Get_MACConfig( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_UNSUPPORTED_TYPE( pMngObj, Library_Samraksh_eMote_Net_Samraksh_eMote_Net_MACBase::FIELD__MACConfig ); }

                static UNSUPPORTED_TYPE& Get_MACRadioObj( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_UNSUPPORTED_TYPE( pMngObj, Library_Samraksh_eMote_Net_Samraksh_eMote_Net_MACBase::FIELD__MACRadioObj ); }

                static UNSUPPORTED_TYPE& Get_packet( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_UNSUPPORTED_TYPE( pMngObj, Library_Samraksh_eMote_Net_Samraksh_eMote_Net_MACBase::FIELD__packet ); }

                static INT32& Get_MACType( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_INT32( pMngObj, Library_Samraksh_eMote_Net_Samraksh_eMote_Net_MACBase::FIELD__MACType ); }

                // Declaration of stubs. These functions are implemented by Interop code developers
                static INT32 UnInitialize( CLR_RT_HeapBlock* pMngObj, HRESULT &hr );
                static INT32 RemovePacket( CLR_RT_HeapBlock* pMngObj, CLR_RT_TypedArray_UINT8 param0, HRESULT &hr );
                static UINT8 GetPendingPacketCount_Receive( CLR_RT_HeapBlock* pMngObj, HRESULT &hr );
                static UINT8 GetPendingPacketCount_Send( CLR_RT_HeapBlock* pMngObj, HRESULT &hr );
                static UINT8 GetMACType( CLR_RT_HeapBlock* pMngObj, HRESULT &hr );
                static INT32 SetRadioAddress( CLR_RT_HeapBlock* pMngObj, UINT16 param0, HRESULT &hr );
                static UINT16 GetRadioAddress( CLR_RT_HeapBlock* pMngObj, HRESULT &hr );
                static INT32 Send( CLR_RT_HeapBlock* pMngObj, UINT16 param0, CLR_RT_TypedArray_UINT8 param1, UINT16 param2, UINT16 param3, HRESULT &hr );
                static INT32 SetRadioType( CLR_RT_HeapBlock* pMngObj, UINT8 param0, HRESULT &hr );
                static INT32 SetTxPower( CLR_RT_HeapBlock* pMngObj, UINT8 param0, INT32 param1, HRESULT &hr );
                static INT32 SetChannel( CLR_RT_HeapBlock* pMngObj, UINT8 param0, INT32 param1, HRESULT &hr );
                static INT32 InternalInitialize( CLR_RT_HeapBlock* pMngObj, CLR_RT_TypedArray_UINT8 param0, UINT8 param1, HRESULT &hr );
                static INT32 InternalReConfigure( CLR_RT_HeapBlock* pMngObj, CLR_RT_TypedArray_UINT8 param0, HRESULT &hr );
                static INT32 GetNextPacket( CLR_RT_HeapBlock* pMngObj, CLR_RT_TypedArray_UINT8 param0, HRESULT &hr );
                static INT32 GetNeighborInternal( CLR_RT_HeapBlock* pMngObj, UINT16 param0, CLR_RT_TypedArray_UINT8 param1, HRESULT &hr );
                static INT32 GetNeighborListInternal( CLR_RT_HeapBlock* pMngObj, CLR_RT_TypedArray_UINT16 param0, HRESULT &hr );
                static INT32 SendTimeStamped( CLR_RT_HeapBlock* pMngObj, UINT16 param0, CLR_RT_TypedArray_UINT8 param1, UINT16 param2, UINT16 param3, HRESULT &hr );
                static INT32 SendTimeStamped( CLR_RT_HeapBlock* pMngObj, UINT16 param0, CLR_RT_TypedArray_UINT8 param1, UINT16 param2, UINT16 param3, UINT32 param4, HRESULT &hr );
            };
        }
    }
}
#endif  //_SAMRAKSH_EMOTE_NET_SAMRAKSH_EMOTE_NET_MACBASE_H_
