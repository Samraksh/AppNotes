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


#ifndef _REALTIMETIMER_SAMRAKSH_SPOT_REALTIME_TIMER_H_
#define _REALTIMETIMER_SAMRAKSH_SPOT_REALTIME_TIMER_H_

namespace Samraksh
{
    namespace SPOT
    {
        namespace RealTime
        {
            struct Timer
            {
                // Helper Functions to access fields of managed object
                // Declaration of stubs. These functions are implemented by Interop code developers
                static void Dispose( HRESULT &hr );
                static INT8 Change( UINT32 param0, UINT32 param1, HRESULT &hr );
                static void GenerateInterrupt( HRESULT &hr );
            };
        }
    }
}
#endif  //_REALTIMETIMER_SAMRAKSH_SPOT_REALTIME_TIMER_H_
