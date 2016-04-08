#ifndef _R2K_H
#define _R2K_H
#define _DEBUG_
#include <windows.h>
#include <winsock2.h>

#ifdef APP_EXPORT
#define APP_DLL   __declspec(dllexport)
#else
#define APP_DLL   __declspec(dllimport)
#endif
//#define APP_DLL

//------------------- ��ʼ�롢����----------------------------------------
#define NET_START_CODE1			(0x43)		// ������ʼ��1
#define NET_START_CODE2			(0x4D)		// ������ʼ��2
#define COM_START_CODE0			(0x1B)		// ������ʼ��
#define ALIVE_CODE				(0x10)
#define HEAD_LENGTH				(0x06)		// ����ͷ���ȣ�����bcc
#define ANT_CFG_LENGTH			(36)		// �����������ݽṹ����
#define VERSION_LENGTH			(16)		// �汾�����ݳ���
#define MAX_RECV_BUFFERSIZE		(65535)		// ��󻺳����ֽ���
//--------------------����ID------------------------------------------------
#define UHF_ALIVE				(0x10)		// ͨѶ�����趨
#define UHF_INV_ONCE			(0x25)		// Ѱ��һ��
#define UHF_READ_TAG_DATA		(0x26)		// ��������
#define UHF_WRITE_TAG_DATA		(0x27)		// д������
#define UHF_INV_MULTIPLY_BEGIN	(0x2A)		// ��ʼѭ��Ѱ��
#define UHF_INV_MULTIPLY_END	(0x2B)		// ֹͣѭ��Ѱ��
#define UHF_LOCK_TAG			(0x2D)		// ����Ƭ
#define UHF_KILL_TAG			(0x2E)		// ע����Ƭ
#define UHF_GET_VERSION			(0x31)		// ��ȡ�豸�汾��
#define UHF_GET_ANT_CONFIG		(0x32)		// ��ȡ���߲���
#define UHF_SET_ANT_CONFIG		(0x33)		// �趨���߲���
#define UHF_GET_DI_STATE		(0x38)		// ��ȡDigital Input״̬
#define UHF_SET_DO_STATE		(0x39)		// �趨Digital Output״̬
//------------------------��������------------------------------------------
#define UHF_SET_READ_ZONE		(0x1B)		// �趨������������
#define UHF_SET_DEFAULT_ZONE (0x17)		// ����Ĭ��epc����
#define UHF_SET_NEIGH_JUDGE		(0x1A)	    // ���������ж�ʱ��
#define UHF_SET_PASSWORD		(0x1C)		// �趨��������
#define UHF_SET_AB_MODE			(0x1D)		// �趨AB������ʽ
#define UHF_SET_DEVICE_NO		(0x20)		// �趨�豸��
#define UHF_SET_CLOCK			(0x43)		// �趨�豸ʱ��
#define UHF_GET_TAG_BUFFER		(0x3A)		// ��ȡ��ǩ����
#define UHF_RESET_TAG_BUFFER	(0x3B)		// ��ձ�ǩ����
//-------------- ���¹���Ӳ����δ֧��--------------------------------------
#define UHF_GET_REGION_CONFIG	(0x34)		// ��ȡƵ���������
#define UHF_SET_REGION_CONFIG	(0x35)		// �趨Ƶ���������
#define UHF_GET_POWMODE			(0x36)		// ��ȡ��Դ����ģʽ
#define UHF_SET_POWMODE			(0x37)		// �趨��Դ����ģʽ
#define UHF_EXE_TAG_SPEC		(0x3C)		// ִ�б�ǩ˽��ָ��
#define UHF_ERASE_BLOCK_SPEC	(0x3D)		// ��ǩ˽��ָ�����������
#define UHF_GET_STAT			(0x3E)		// ��ȡ�豸ͳ����Ϣ
#define UHF_GET_CONFIGURE		(0x3F)		// ��ȡ�豸�������
#define UHF_SET_CONFIGURE		(0x40)		// �趨�豸�������

//----------------���������뼰��������-------------------------------------
#define UNLOCK					(0x0)
#define PERMANENCE_WRIALBE		(0x1)
#define SECURITY_LOCK			(0x2)
#define PERMANENCE_UNWRIABLE	(0x3)

#define BLOCK_KILL				(0x0)
#define BLOCK_ACCESS			(0x1)
#define BLOCK_EPC				(0x2)
#define BLOCK_TID				(0x3)
#define BLOCK_USER				(0x4)
//---------------------------------------------------------------------------
#define R_OK					0			// ��ȷ���
#define R_FAIL					-1			// ������
#define HOST_ERROR				0x80		// ���������ش�����
#define HOST_OK					0x0			// ������������ȷ��
#define SERVERPORT				20058		// �˿ں�

//------------------------������Ϣ-------------------------------------------
#define INVALID_HOST_IPADDRESS  -2		// ��Ч�����ַ���
#define INVALID_COMM_PORT		-3		// ��Ч���ں�
#define INVALID_HOST_PORTORBANDRATE		-4		// ��Ч�˿ںŻ��߲�����
#define INVALID_POINTER		    -5		// ��ָ��
#define INVALID_COMM_MODE		-6		// ��Ч��ͨ��ģʽ
#define INVALID_BANK			-7		// ��Ч�����
#define INVALID_BEGIN_SIZE		-8		// ��Ч����ʼλ�úʹ�С
#define INVALID_PASSWORD		-9		// ��Ч����
#define INVALID_ACCESS_PASSWORD	-10		// ��Ч���ʿ���
#define INVALID_KILL_PASSWORD	-11		// ��Ч������
#define INVALID_OPCODE			-12		// ��Ч������
#define INVALID_PORT_VALUE		-13		// ��Ч�Ķ˿�
#define INVALID_STATE_VALUE		-14		// ��Ч״ֵ̬
#define INVALID_MODE_VALUE		-24		// ��Чģʽֵ
#define INVALID_CLOCK			-25     // ��Ч����
#define INVALID_PARAMETERS		-28		// ��Ч����

#define SOKET_CONNECT_FAIL		-15		// ��������ʧ��
#define COM_CONNECT_FAIL		-16		// ��������ʧ��
#define ERROR_GET_ANT			-26
#define ERROR_NET_INIT			-17		// �����ʼ����
#define ERROR_COM_INIT			-18		// ���ڳ�ʼ����
#define ERROR_DEV_SEND			-19		// �豸���ʹ�
#define ERROR_DEV_RECV			-20		// �豸���մ�
#define ERROR_DEV_CONNECT		-21		// �豸δ����
#define ERROR_OPER_FAIL			-23		// ����ʧ��

#define ERROR_OPEN_COMM			-24		// �򿪴��ڴ�
#define ERROR_SET_COMMBUFFER	-25		// ���ô��ڻ�����
#define ERROR_SET_COMMTIMEOUT	-26		// ���ô��ڳ�ʱ�ṹ
#define ERROR_SET_DCB			-27		// ����DCB����
//--------------------- ����������ṹ ------------------------------------------
typedef struct _PACKAGE
{
	unsigned char STARTCODE[2];				// 2���ֽڵ���ʼ��
	unsigned char cmd;						// ������
	unsigned char seq;						// ˳���
	unsigned char len[2];					// ���ȣ�0Ϊlow,1Ϊhigh
	unsigned char data[520];				// ����
	unsigned char bcc;						// У��λ
}PACKAGE, *PPACKAGE;
//-------------------- �������ýṹ -----------------------------------------
typedef struct _ant_cfg_
{
	unsigned char antEnable[4];				// ���߹���״̬, 1:����;0:������
	unsigned long dwell_time[4];			// һ��Ѱ������ʱ�䣬��λms
	unsigned long power[4];					// �������,��λ1/10(dbm)
}ANT_CFG, *PANT_CFG;
//---------------------------------------------------------------------------


/*******************************************************************************/
typedef void (CALLBACK* HANDLE_FUN)(unsigned char cmdID, void* pData, int length);
/*------------------------------------------------------------------------------- 
  �����߶���ص������ĸ�ʽ
*********************************************************************************/
APP_DLL int WINAPI GetLastErrorMessage();		
/*-------------------------------------------------------------------------------
  1�����ƣ�GetErrorNo()
  2�����ܣ���ȡ�����
  3����������
  4������ֵ�������
*********************************************************************************/
APP_DLL int  WINAPI deviceInit(char* pHost,int CommMode = 0, unsigned PortOrBaudRate = 20058);
/*-------------------------------------------------------------------------------
   1�����ƣ�deviceInit
�� 2�����ܣ�����������,ȷ�����ӷ�ʽ������ʼ���豸���ȫ�ֱ���		
   3��������pHost��ʾͨ�ŷ�ʽ�������ַ���
			CommMode��ͨ�ŷ�ʽ��0��������ģʽ��1-9�Ǵ���ģʽ��ͬʱ�Ǵ��ں�
			PortOrBaudRate��ͨ�Ŷ˿ںŻ����ʡ�
   4������ֵ
			R_OK ��ʼ���ɹ�
			R_FAIL����ʼ��ʧ��
   5������ֵ
			 INVALID_HOST_IPADDRESS  		// ��ЧIP��ַ
			 INVALID_COMM_PORT		 		// ��Ч���ں�
			 INVALID_HOST_PORTORBANDRATE	// ��Ч�˿ںŻ�����
			 INVALID_POINTER		    	// ��ָ��
			 INVALID_COMM_MODE				// ��Ч��ͨ��ģʽ
			 ERROR_NET_INIT					// �����ʼ����
			 ERROR_COM_INIT					// ���ڳ�ʼ����
********************************************************************************/
APP_DLL int  WINAPI  deviceConnect();
/*------------------------------------------------------------------------------- 
   1�����ƣ�deviceConnect
�� 2�����ܣ������豸
   3����������
�� 4������ֵ��
			R_OK   ���ӳɹ�
			R_FAIL ����ʧ��
   5������ֵ
			SOKET_CONNECT_FAIL 				// ��������ʧ��
			COM_CONNECT_FAIL				// ��������ʧ��
/********************************************************************************/
APP_DLL void    WINAPI  deviceDisconnect();
/*------------------------------------------------------------------------------- 
�� 1�����ƣ�deviceDisconnect
�� 2�����ܣ��Ͽ��豸����
   3��������������
�� 4������ֵ����
*********************************************************************************/
APP_DLL void   WINAPI  deviceUnInit();
/*------------------------------------------------------------------------------- 
�� 1�����ƣ�deviceUnInit
�� 2�����ܣ��ָ���ʼֵ		
   3����������
   4������ֵ����
*********************************************************************************/
APP_DLL int WINAPI GetDevVersion(unsigned char* pVer);
/*------------------------------------------------------------------------------- 
	1������:  GetDevVersion
	2������:  ��ȡ�豸�汾�ţ�16Bytes��
	3������:  pVersion �������ݵĻ�������ַ    
	4������ֵ
			  R_OK ������������
			  R_FAIL ��ȡʧ��
	5������ֵ
			  INVALID_POINTER					// ��Чָ��
			  ERROR_DEV_CONNECT				    // �豸δ����
			  ERROR_DEV_SEND					// �豸���ʹ�
			  ERROR_OPER_FAIL					// ����ʧ��
*********************************************************************************/
APP_DLL int   WINAPI   GetAnt(PANT_CFG pAntCfg);
/*------------------------------------------------------------------------------- 
	1������:  GetAnt
	2������:  ��ȡ���߹�������
	3����������pAntCfg�����߽ṹ��ָ��
	4������ֵ:
			R_OK   �ɹ�
			R_FAIL ʧ��
	5������ֵ
			INVALID_POINTER					// ��Чָ��
			ERROR_GET_ANT					// ��ȡ�������ݴ���
			ERROR_DEV_CONNECT				// �豸δ����
			ERROR_DEV_SEND					// �豸���ʹ�

*********************************************************************************/
APP_DLL int    WINAPI   SetAnt(const PANT_CFG pAntCfg);
/*------------------------------------------------------------------------------- 
	1������:  SetAnt
	2������:  �������߹�������
	3������;  pAntCfg�������߲����Ľṹ��ָ��
	4������ֵ:
			R_OK   �ɹ�
			R_FAIL ʧ��
	5������ֵ
			INVALID_POINTER					// ��Чָ��
			ERROR_DEV_CONNECT				// �豸δ����
			ERROR_OPER_FAIL					// ����ʧ��
********************************************************************************/
APP_DLL int  WINAPI  WriteTagData(unsigned char bank, unsigned char begin,
				  unsigned char size,	const unsigned char* pData,
				  char* pPassword = "\0\0\0\0");
/*------------------------------------------------------------------------------- 
	1������: WriteTagData
	2������: д��ǩ��ָ������
	3������
			bank: Ҫд�����������
			begin:��ʼ��ַ
			size: Ҫд�������
			pPassword: ����
			pData: �洢����buffer
	4������ֵ:
			R_OK : �ɹ�
			R_FAIL:ʧ��
	5������ֵ
			INVALID_POINTER					// ��Чָ��
			INVALID_BANK					// ��Ч�����
			INVALID_BEGIN_SIZE				// ��Ч����ʼλ�úʹ�С
			INVALID_PASSWORD				// ��Ч����
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_DEV_RECV					// �豸���մ�
			ERROR_DEV_CONNECT				// �豸δ����
			ERROR_OPER_FAIL					// ����ʧ��
*********************************************************************************/
APP_DLL int   WINAPI  ReadTagData(unsigned char bank, unsigned char begin,				
				   unsigned char size, unsigned char* pOutData,	        
				   char* pPassword = "\0\0\0\0");	 
/*-------------------------------------------------------------------------------
	1������: ReadTagData
	2������: ��ȡ��ȡ��ǩָ�����������
	3������
			bank: Ҫ��ȡ����������
			begin:��ʼ��ַ
			size: Ҫ��ȡ������
			pPassword: ����
			pData: �洢����buffer
	4������ֵ:
			R_OK   �ɹ�
			R_FAIL ʧ��
	5������ֵ
			INVALID_POINTER					// ��Чָ��
			INVALID_BANK					// ��Ч�����
			INVALID_BEGIN_SIZE				// ��Ч����ʼλ�úʹ�С
			INVALID_PASSWORD				// ��Ч����
			ERROR_DEV_CONNECT				// �豸δ����
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_OPER_FAIL					// ����ʧ��
*********************************************************************************/
APP_DLL int   WINAPI   BeginMultiInv(HANDLE_FUN f);
/*------------------------------------------------------------------------------- 
	1������:  BeginMultiInv
	2������:  ����Ѱ��
	3������:  f �����߶���Ļص�����
	4������ֵ:
			R_OK ������������
			R_FAIL ��ȡʧ��
	5������ֵ
			INVALID_POINTER					// ��Чָ��
			ERROR_DEV_CONNECT				// �豸δ����
			ERROR_DEV_SEND					// �豸���ʹ�
*********************************************************************************/
APP_DLL int  WINAPI  StopInv();
/*------------------------------------------------------------------------------- 
	1������:  StopInv
	2������:  ֹͣ����Ѱ��
	3������:  ��
	4������ֵ:
			R_OK   �ɹ�
			R_FAIL ����ʧ��
	5������ֵ
			ERROR_DEV_CONNECT				// �豸δ����
			ERROR_DEV_SEND					// �豸���ʹ�
*********************************************************************************/
APP_DLL int   WINAPI   BeginOnceInv(HANDLE_FUN f) ;
/*------------------------------------------------------------------------------- 
	1������:  BeginOnceInv
	2������:  Ѱ��һ��
	3������:  f �����߶���Ļص�����	    
	4������ֵ:
			R_OK ������������
			R_FAIL ��ȡʧ��
	5������ֵ
		   INVALID_POINTER					// ��Чָ��
   		   ERROR_DEV_CONNECT				// �豸δ����
		   ERROR_DEV_SEND					// �豸���ʹ�
*********************************************************************************/
APP_DLL int    WINAPI  SetAlive(unsigned char intervalSecond);
/*------------------------------------------------------------------------------- 
	1������:  SetAlive
	2������:  ����������ʱ����
	3������
			intervalSecond Ҫ���õ�ʱ����(0-255)
	4������ֵ:
			R_OK ���óɹ�
			R_FAIL ����ʧ��
	5������ֵ
			ERROR_DEV_CONNECT				// �豸δ����
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_DEV_RECV					// �豸���մ�
			ERROR_OPER_FAIL					// ����ʧ��
********************************************************************************/
APP_DLL int  WINAPI  KillTag(unsigned char* pKill_pwd,unsigned char* pAccess_pwd);
/*------------------------------------------------------------------------------- 
	1������:  KillTag
	2������:  ���ٱ�ǩ
	3������
			pKill_pwd �����������
			pAccess_pwd�� ��������
	4������ֵ:
			R_OK   �ɹ�
			R_FAIL ����ʧ��
	5������ֵ
			INVALID_PASSWORD				// ��Ч����
			ERROR_DEV_CONNECT				// �豸δ����
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_DEV_RECV					// �豸���մ�
			ERROR_OPER_FAIL					// ����ʧ��
*********************************************************************************/
APP_DLL int   WINAPI   LockTag(unsigned char opcode,  unsigned char block, char* pPassword);
/*------------------------------------------------------------------------------- 
	1������: LockTag
	2������: ������ǩ
	3������
			opcode ������
			block  ��������
			pPassword: ����
	4������ֵ
			R_OK   �ɹ�
			R_FAIL ����ʧ��
	5������ֵ
			INVALID_BANK					// ��Ч�����
			INVALID_OPCODE			��		// ��Ч������
			INVALID_PASSWORD				// ��Ч����
			ERROR_DEV_CONNECT				// �豸δ����
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_DEV_RECV					// �豸���մ�
			ERROR_OPER_FAIL					// ����ʧ��
*********************************************************************************/
APP_DLL int   WINAPI   SetDefaultZone(bool bOpen);
/*------------------------------------------------------------------------------- 
	1������: SetDefaultZone
	2������: ����Ĭ�϶�����
	3������
			bOpen TRUE ��Ĭ�ϵ�EPC
						FALSE �ر�Ĭ�ϵ�EPC��ʹ������ָ������
	4������ֵ
			R_OK   �ɹ�
			R_FAIL ����ʧ��
	5������ֵ
			INVALID_BANK					// ��Ч�����
			INVALID_BEGIN_SIZE		��		// ��Ч������
			ERROR_DEV_CONNECT				// �豸δ����
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_DEV_RECV					// �豸���մ�
			ERROR_OPER_FAIL					// ����ʧ��
*********************************************************************************/
APP_DLL int   WINAPI   SetReadZone(unsigned char bank, unsigned char begin, unsigned char size);
/*------------------------------------------------------------------------------- 
	1������: SetReadZone
	2������: ��������Ѱ������
	3������
			bank: ��������
			begin:��ʼ��ַ
			size: ��ȡ������
	4������ֵ
			R_OK   �ɹ�
			R_FAIL ����ʧ��
	5������ֵ
			INVALID_BANK					// ��Ч�����
			INVALID_BEGIN_SIZE		��		// ��Ч������
			ERROR_DEV_CONNECT				// �豸δ����
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_DEV_RECV					// �豸���մ�
			ERROR_OPER_FAIL					// ����ʧ��
*********************************************************************************/
APP_DLL int   WINAPI   SetDeviceNo(unsigned char deviceNo);
/*------------------------------------------------------------------------------- 
	1������: SetDeviceNo
	2������: �����豸��
	3������
			deviceNo �豸��
	4������ֵ
			R_OK   �ɹ�
			R_FAIL ����ʧ��
	5������ֵ
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_DEV_RECV					// �豸���մ�
			ERROR_OPER_FAIL					// ����ʧ��
*********************************************************************************/
APP_DLL int   WINAPI   SetNeighJudgeTime(unsigned char time);
/*------------------------------------------------------------------------------- 
	1������: SetNeighJudgeTime
	2������: ���������ж�ʱ��
	3������
			time �����ж�ʱ��
	4������ֵ
			R_OK   �ɹ�
			R_FAIL ����ʧ��
	5������ֵ
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_DEV_RECV					// �豸���մ�
			ERROR_OPER_FAIL					// ����ʧ��
*********************************************************************************/
APP_DLL int   WINAPI   SetABMode(unsigned char ABMode);
/*------------------------------------------------------------------------------- 
	1������: SetABMode
	2������: ����AB����ģʽ
	3������
			ABMode(1. ����ABģʽ��0. ȡ��ABģʽ) 
	4������ֵ
			R_OK   �ɹ�
			R_FAIL ����ʧ��
	5������ֵ
			INVALID_MODE_VALUE				// ��Чģʽֵ
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_DEV_RECV					// �豸���մ�
			ERROR_OPER_FAIL					// ����ʧ��
*********************************************************************************/
APP_DLL int   WINAPI   SetReadPassword(char* pPassword);
/*------------------------------------------------------------------------------- 
	1������: SetReadPassword
	2������: ����Ѱ������
	3������
			pPassword��8���ַ������� 
	4������ֵ
			R_OK   �ɹ�
			R_FAIL ����ʧ��
	5������ֵ
			INVALID_PASSWORD				// ��Ч����
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_DEV_RECV					// �豸���մ�
			ERROR_OPER_FAIL					// ����ʧ��
*********************************************************************************/
APP_DLL int   WINAPI   SetClock(char* pClock);
/*------------------------------------------------------------------------------- 
	1������: SetClock
	2������: �����豸ʱ��
	3������
			pClock��ʱ���ַ���������yy-mm-dd-ww-hh-mm-ss��
			�ֱ�Ϊ�ꡢ�¡��ա����ڡ�ʱ���֡���
	4������ֵ
			R_OK   �ɹ�
			R_FAIL ����ʧ��
	5������ֵ
			INVALID_CLOCK  				    // ��Ч����
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_DEV_RECV					// �豸���մ�
			ERROR_OPER_FAIL					// ����ʧ��
*********************************************************************************/
APP_DLL int  WINAPI  ResetTagBuffer();
/*------------------------------------------------------------------------------- 
	1������: ResetTagBuffer
	2������: ����豸��ȡ�ı�ǩ�б�
	3������: ��
	4������ֵ:
			R_OK �ɹ�
			R_FAIL ʧ��
	5������ֵ
			ERROR_DEV_CONNECT				// �豸δ����
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_DEV_RECV					// �豸���մ�
			ERROR_OPER_FAIL					// ����ʧ��
*********************************************************************************/
APP_DLL int  WINAPI  ReadTagBuffer(HANDLE_FUN CallBackFunc);
/*------------------------------------------------------------------------------- 
	1������: ReadTagBuffer
	2������: ��ȡ��ǩ�б�
	3������: CallBackFunc���ص�������
	4������ֵ:
			R_OK �ɹ�
			R_FAIL ʧ��
	5������ֵ
			INVALID_POINTER					// ��Чָ��
			ERROR_DEV_CONNECT				// �豸δ����
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_DEV_RECV					// �豸���մ�
			ERROR_OPER_FAIL					// ����ʧ��
*********************************************************************************/
APP_DLL int  WINAPI  SetDO(const unsigned char port, const unsigned char state);
/*------------------------------------------------------------------------------- 
	1������: SetDO
	2������: ����Digital Output״̬
	3������
			port Ҫ�趨�Ķ˿�
			state ״ֵ̬
	4������ֵ:
			R_OK �趨�ɹ�
			R_FAIL �趨ʧ��
	5������ֵ
			INVALID_PORT_VALUE			����// ��Ч�Ķ˿�
			INVALID_STATE_VALUE		��		// ��Ч״ֵ̬
			ERROR_DEV_CONNECT				// �豸δ����
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_DEV_RECV					// �豸���մ�
			ERROR_OPER_FAIL					// ����ʧ��
*********************************************************************************/
APP_DLL int  WINAPI  GetDI(unsigned char* pDIState);
/*------------------------------------------------------------------------------- 
	1������:  GetDI
	2������:  ��ȡDigital Input״̬
	3������
			pDIState ������������޷����ַ���ʽ
	4������ֵ:
			R_OK ��ȡ�ɹ�
			R_FAIL ��ȡʧ��
	5������ֵ
			INVALID_POINTER					// ��Чָ��
			ERROR_DEV_CONNECT				// �豸δ����
			ERROR_DEV_SEND					// �豸���ʹ�
			ERROR_DEV_RECV					// �豸���մ�
*********************************************************************************/
APP_DLL void WINAPI ForceStop();
/*------------------------------------------------------------------------------- 
	1������:  ForceStop()
	2������:  ǿ���豸��ֹ��������״̬
	3������
			��
	4������ֵ:
			��
*********************************************************************************/
#define MAX_WORK_THREAD 20	// ����߳���
#define QUE_LEN	  10		// ���г���
#define WORK_MSEC 2000		// �������߹���ʱ��(ms)
#define WORK_POWER 300		// �������ʣ�1/10dbm)
#define MAX_TAGS   36		// һ�ζ�ȡ������ǩ��

APP_DLL void  WINAPI PrintBuffer(unsigned char* pBuf, int leng);
/*------------------------------------------------------------------------------- 
	1������:  PrintBuffer
	2������:  ���ֽ���ʾ����������
	3������:  pBuf ����������
			��leng ����
	4������ֵ:
			��
*********************************************************************************/
APP_DLL bool  WINAPI  InitMTEnv(HANDLE_FUN f);
/*------------------------------------------------------------------------------- 
	1������:  InitMTEnv
	2������:  ��ʼ�����̻߳���
	3������
			f �ص���������
	4������ֵ:
			TRUE ��ȡ�ɹ�
			FALSE ��ȡʧ��
	5������ֵ
			INVALID_PARAMETERS				// ��Ч����
*********************************************************************************/
APP_DLL bool  WINAPI DispatchThreadResource(char* pIP, int antId,int deviceId,unsigned port = 20058);
/*------------------------------------------------------------------------------- 
	1������:  DispatchThreadResource
	2������:  �ַ��߳���Դ
	3������
			char* pIP��IP��ַ
			int antId�����ߺ�
			int deviceId���豸��
			unsigned port �˿ں�
	4������ֵ:
			TRUE �ɹ�
			FALSE ʧ��
	5������ֵ
			INVALID_PARAMETERS				// ��Ч����
*********************************************************************************/
APP_DLL void  WINAPI StopMTOnceInv();
/*------------------------------------------------------------------------------- 
	1������:  StopMTOnceInv
	2������:  �������߳�����
	3������:����
	4������ֵ:Ԫ
*********************************************************************************/
#endif 