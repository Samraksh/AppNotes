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


#ifndef _SAMRAKSH_EMOTE_NET_SAMRAKSH_EMOTE_NET_RADIO_RADIO_802_15_4_BASE_H_
#define _SAMRAKSH_EMOTE_NET_SAMRAKSH_EMOTE_NET_RADIO_RADIO_802_15_4_BASE_H_

namespace Samraksh
{
    namespace eMote
    {
        namespace Net
        {
            namespace Radio
            {
                struct Radio_802_15_4_Base
                {
                    // Helper Functions to access fields of managed object
                    static UNSUPPORTED_TYPE& Get_dataBuffer( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_UNSUPPORTED_TYPE( pMngObj, Library_Samraksh_eMote_Net_Samraksh_eMote_Net_Radio_Radio_802_15_4_Base::FIELD__dataBuffer ); }

                    static UNSUPPORTED_TYPE& Get_marshalBuffer( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_UNSUPPORTED_TYPE( pMngObj, Library_Samraksh_eMote_Net_Samraksh_eMote_Net_Radio_Radio_802_15_4_Base::FIELD__marshalBuffer ); }

                    // Declaration of stubs. These functions are implemented by Interop code developers
                    static INT32 UnInitialize( CLR_RT_HeapBlock* pMngObj, HRESULT &hr );
                    static UINT16 GetRadioAddress( CLR_RT_HeapBlock* pMngObj, UINT8 param0, HRESULT &hr );
                    static INT8 SetRadioAddress( CLR_RT_HeapBlock* pMngObj, UINT8 param0, UINT16 param1, HRESULT &hr );
                    static INT32 TurnOnRx( CLR_RT_HeapBlock* pMngObj, UINT8 param0, HRESULT &hr );
                    static INT32 Sleep( CLR_RT_HeapBlock* pMngObj, UINT8 param0, UINT8 param1, HRESULT &hr );
                    static INT32 PreLoad( CLR_RT_HeapBlock* pMngObj, CLR_RT_TypedArray_UINT8 param0, UINT16 param1, HRESULT &hr );
                    static INT32 SendStrobe( CLR_RT_HeapBlock* pMngObj, UINT8 param0, UINT16 param1, HRESULT &hr );
                    static INT32 Send( CLR_RT_HeapBlock* pMngObj, UINT8 param0, CLR_RT_TypedArray_UINT8 param1, UINT16 param2, HRESULT &hr );
                    static INT32 SendTimeStamped( CLR_RT_HeapBlock* pMngObj, UINT8 param0, CLR_RT_TypedArray_UINT8 param1, UINT16 param2, UINT32 param3, HRESULT &hr );
                    static INT8 ClearChannelAssesment( CLR_RT_HeapBlock* pMngObj, UINT8 param0, HRESULT &hr );
                    static INT8 ClearChannelAssesment( CLR_RT_HeapBlock* pMngObj, UINT8 param0, UINT16 param1, HRESULT &hr );
                    static INT32 TurnOffRx( CLR_RT_HeapBlock* pMngObj, UINT8 param0, HRESULT &hr );
                };
            }
        }
    }
}
#endif  //_SAMRAKSH_EMOTE_NET_SAMRAKSH_EMOTE_NET_RADIO_RADIO_802_15_4_BASE_H_
