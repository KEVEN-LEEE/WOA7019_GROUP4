#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif





struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
struct String_t;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;



IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct CalendarTriggerData_t95CDF224E7B6165CE42899A54B3BADAE1B4BBB23 
{
	int32_t ___year;
	int32_t ___month;
	int32_t ___day;
	int32_t ___hour;
	int32_t ___minute;
	int32_t ___second;
	uint8_t ___repeats;
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2  : public ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_pinvoke
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_com
{
};
struct IntPtr_t 
{
	void* ___m_value;
};
struct LocationTriggerData_t6C709C3123CDD15B8FA218B532776BAB4B0172FC 
{
	double ___latitude;
	double ___longitude;
	float ___radius;
	uint8_t ___notifyOnEntry;
	uint8_t ___notifyOnExit;
	uint8_t ___repeats;
};
struct RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 
{
	int32_t ___m_XMin;
	int32_t ___m_YMin;
	int32_t ___m_Width;
	int32_t ___m_Height;
};
struct TimeTriggerData_t110F07D01BDEC0F8D7C1E625A581638C9AEE6823 
{
	int32_t ___interval;
	uint8_t ___repeats;
};
struct Vector2Int_t69B2886EBAB732D9B880565E18E7568F3DE0CE6A 
{
	int32_t ___m_X;
	int32_t ___m_Y;
};
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
struct iOSAuthorizationRequestData_t216987B5D9A6729184F783B5F68AE9124B9321AC 
{
	int32_t ___granted;
	String_t* ___error;
	String_t* ___deviceToken;
};
struct iOSAuthorizationRequestData_t216987B5D9A6729184F783B5F68AE9124B9321AC_marshaled_pinvoke
{
	int32_t ___granted;
	char* ___error;
	char* ___deviceToken;
};
struct iOSAuthorizationRequestData_t216987B5D9A6729184F783B5F68AE9124B9321AC_marshaled_com
{
	int32_t ___granted;
	Il2CppChar* ___error;
	Il2CppChar* ___deviceToken;
};
struct ARWorldMapRequestStatus_tA497BB9193D2D0C1734F9B47F5D1F438E6C146CC 
{
	int32_t ___value__;
};
struct NSError_t2D5B776DCC1C16BD32BA4EB06DE60A3068378E80 
{
	intptr_t ___m_Self;
};
struct TextureFormat_t87A73E4A3850D3410DC211676FC14B94226C1C1D 
{
	int32_t ___value__;
};
struct TriggerData_t5B00176E3EB034DB9078E419981580696EB8D39E 
{
	union
	{
		#pragma pack(push, tp, 1)
		struct
		{
			TimeTriggerData_t110F07D01BDEC0F8D7C1E625A581638C9AEE6823 ___timeInterval;
		};
		#pragma pack(pop, tp)
		struct
		{
			TimeTriggerData_t110F07D01BDEC0F8D7C1E625A581638C9AEE6823 ___timeInterval_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			CalendarTriggerData_t95CDF224E7B6165CE42899A54B3BADAE1B4BBB23 ___calendar;
		};
		#pragma pack(pop, tp)
		struct
		{
			CalendarTriggerData_t95CDF224E7B6165CE42899A54B3BADAE1B4BBB23 ___calendar_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			LocationTriggerData_t6C709C3123CDD15B8FA218B532776BAB4B0172FC ___location;
		};
		#pragma pack(pop, tp)
		struct
		{
			LocationTriggerData_t6C709C3123CDD15B8FA218B532776BAB4B0172FC ___location_forAlignmentOnly;
		};
	};
};
struct AsyncConversionStatus_tB9035BBA640774DAFF34FEEE5DF141A2F24E1236 
{
	int32_t ___value__;
};
struct Transformation_t26ED8CF20E035506740A8504E00ECD67AF5FD137 
{
	int32_t ___value__;
};
struct iOSNotificationData_t57D24EBD788D6C71F203ACE14688358AFA08BDED 
{
	String_t* ___identifier;
	String_t* ___title;
	String_t* ___body;
	int32_t ___badge;
	String_t* ___subtitle;
	String_t* ___categoryIdentifier;
	String_t* ___threadIdentifier;
	int32_t ___soundType;
	float ___soundVolume;
	String_t* ___soundName;
	int32_t ___interruptionLevel;
	double ___relevanceScore;
	intptr_t ___userInfo;
	intptr_t ___attachments;
	int32_t ___triggerType;
	TriggerData_t5B00176E3EB034DB9078E419981580696EB8D39E ___trigger;
};
struct iOSNotificationData_t57D24EBD788D6C71F203ACE14688358AFA08BDED_marshaled_pinvoke
{
	char* ___identifier;
	char* ___title;
	char* ___body;
	int32_t ___badge;
	char* ___subtitle;
	char* ___categoryIdentifier;
	char* ___threadIdentifier;
	int32_t ___soundType;
	float ___soundVolume;
	char* ___soundName;
	int32_t ___interruptionLevel;
	double ___relevanceScore;
	intptr_t ___userInfo;
	intptr_t ___attachments;
	int32_t ___triggerType;
	TriggerData_t5B00176E3EB034DB9078E419981580696EB8D39E ___trigger;
};
struct iOSNotificationData_t57D24EBD788D6C71F203ACE14688358AFA08BDED_marshaled_com
{
	Il2CppChar* ___identifier;
	Il2CppChar* ___title;
	Il2CppChar* ___body;
	int32_t ___badge;
	Il2CppChar* ___subtitle;
	Il2CppChar* ___categoryIdentifier;
	Il2CppChar* ___threadIdentifier;
	int32_t ___soundType;
	float ___soundVolume;
	Il2CppChar* ___soundName;
	int32_t ___interruptionLevel;
	double ___relevanceScore;
	intptr_t ___userInfo;
	intptr_t ___attachments;
	int32_t ___triggerType;
	TriggerData_t5B00176E3EB034DB9078E419981580696EB8D39E ___trigger;
};
struct ConversionParams_t062706B15E2C508C54473A1FD72013C4381CCB62 
{
	RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___m_InputRect;
	Vector2Int_t69B2886EBAB732D9B880565E18E7568F3DE0CE6A ___m_OutputDimensions;
	int32_t ___m_Format;
	int32_t ___m_Transformation;
};
struct IntPtr_t_StaticFields
{
	intptr_t ___Zero;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif

extern "C" void DEFAULT_CALL ReversePInvokeWrapper_ARCameraBackground_BeforeBackgroundRenderHandler_m3B215B54CFB6F6F00A724D9A6BE66808593ABFCD(int32_t ___0_eventId);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_ARKitSessionDelegate_CoachingOverlayViewDidDeactivate_m65EDACCF49DE4C8A6E4CA7F6E3A7104D116432EE(intptr_t ___0_subsystemHandle);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_ARKitSessionDelegate_CoachingOverlayViewWillActivate_m3F9ECC227F1E397CE7C57A505FB3FFB8ADBE573B(intptr_t ___0_subsystemHandle);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_ARKitSessionDelegate_ConfigurationChanged_m476431686AC17DA3287883D35C2CAF98A1FA8558(intptr_t ___0_subsystemHandle);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_ARKitSessionDelegate_SessionDidFailWithError_mC4CFE813C1C8FCF592EE9B661DB1E51C8DD12399(intptr_t ___0_subsystemHandle, NSError_t2D5B776DCC1C16BD32BA4EB06DE60A3068378E80 ___1_error);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_ARKitSessionSubsystem_OnAsyncConversionComplete_m644D3F9DB9A9E22010B098BCF12F296ED7B219E6(int32_t ___0_status, int32_t ___1_worldMapId, intptr_t ___2_context);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_CultureInfo_OnCultureInfoChangedInAppX_m407BCFC1029A4485B7B063BC2F3601968C3BE577(Il2CppChar* ___0_language);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_HighResolutionCpuImagePromise_OnPromiseComplete_m444E8F248DC80401DF6C4D497B2BA2CCF47B7C55(int32_t ___0_wasSuccessful);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_OSSpecificSynchronizationContext_InvocationEntry_mF93C3CF6DBEC86E377576D840CAF517CB6E4D7E3(intptr_t ___0_arg);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_XRCpuImage_OnAsyncConversionComplete_mDC3A0C88A34909C9D08E4BE7E94C8E27E2BB3D3C(int32_t ___0_status, ConversionParams_t062706B15E2C508C54473A1FD72013C4381CCB62 ___1_conversionParams, intptr_t ___2_dataPtr, int32_t ___3_dataLength, intptr_t ___4_context);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_iOSNotificationsWrapper_AuthorizationRequestReceived_m4A6C75E5BFEA2C3E529F2F8CEEA8A813F428B3CD(intptr_t ___0_request, iOSAuthorizationRequestData_t216987B5D9A6729184F783B5F68AE9124B9321AC_marshaled_pinvoke ___1_data);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_iOSNotificationsWrapper_NotificationReceived_mB7F4859AF321D5AF115D70F4BD8AB131543D7524(iOSNotificationData_t57D24EBD788D6C71F203ACE14688358AFA08BDED_marshaled_pinvoke ___0_data);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_iOSNotificationsWrapper_ReceiveNSDictionaryKeyValue_m57E371B7275602846E05E0770BFA78C6641BC856(intptr_t ___0_dict, char* ___1_key, char* ___2_value);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_iOSNotificationsWrapper_ReceiveUNNotificationAttachment_mF8194BDA3434E46D10AF292C61D4F3E00B654652(intptr_t ___0_array, char* ___1_id, char* ___2_url);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_iOSNotificationsWrapper_RemoteNotificationReceived_mBF44180FD060AC5811C9979FE6E771650AA35212(iOSNotificationData_t57D24EBD788D6C71F203ACE14688358AFA08BDED_marshaled_pinvoke ___0_data);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_iOSStepCounter_OnDataReceived_m5026961D9D4D64A5930020A91D82DF64E65591C0(int32_t ___0_deviceId, int32_t ___1_numberOfSteps);


IL2CPP_EXTERN_C const Il2CppMethodPointer g_ReversePInvokeWrapperPointers[];
const Il2CppMethodPointer g_ReversePInvokeWrapperPointers[16] = 
{
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_ARCameraBackground_BeforeBackgroundRenderHandler_m3B215B54CFB6F6F00A724D9A6BE66808593ABFCD),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_ARKitSessionDelegate_CoachingOverlayViewDidDeactivate_m65EDACCF49DE4C8A6E4CA7F6E3A7104D116432EE),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_ARKitSessionDelegate_CoachingOverlayViewWillActivate_m3F9ECC227F1E397CE7C57A505FB3FFB8ADBE573B),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_ARKitSessionDelegate_ConfigurationChanged_m476431686AC17DA3287883D35C2CAF98A1FA8558),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_ARKitSessionDelegate_SessionDidFailWithError_mC4CFE813C1C8FCF592EE9B661DB1E51C8DD12399),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_ARKitSessionSubsystem_OnAsyncConversionComplete_m644D3F9DB9A9E22010B098BCF12F296ED7B219E6),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_CultureInfo_OnCultureInfoChangedInAppX_m407BCFC1029A4485B7B063BC2F3601968C3BE577),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_HighResolutionCpuImagePromise_OnPromiseComplete_m444E8F248DC80401DF6C4D497B2BA2CCF47B7C55),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_OSSpecificSynchronizationContext_InvocationEntry_mF93C3CF6DBEC86E377576D840CAF517CB6E4D7E3),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_XRCpuImage_OnAsyncConversionComplete_mDC3A0C88A34909C9D08E4BE7E94C8E27E2BB3D3C),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_iOSNotificationsWrapper_AuthorizationRequestReceived_m4A6C75E5BFEA2C3E529F2F8CEEA8A813F428B3CD),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_iOSNotificationsWrapper_NotificationReceived_mB7F4859AF321D5AF115D70F4BD8AB131543D7524),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_iOSNotificationsWrapper_ReceiveNSDictionaryKeyValue_m57E371B7275602846E05E0770BFA78C6641BC856),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_iOSNotificationsWrapper_ReceiveUNNotificationAttachment_mF8194BDA3434E46D10AF292C61D4F3E00B654652),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_iOSNotificationsWrapper_RemoteNotificationReceived_mBF44180FD060AC5811C9979FE6E771650AA35212),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_iOSStepCounter_OnDataReceived_m5026961D9D4D64A5930020A91D82DF64E65591C0),
};
