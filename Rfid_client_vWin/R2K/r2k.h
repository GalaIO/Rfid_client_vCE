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

//------------------- 起始码、长度----------------------------------------
#define NET_START_CODE1			(0x43)		// 网络起始码1
#define NET_START_CODE2			(0x4D)		// 网络起始码2
#define COM_START_CODE0			(0x1B)		// 串口起始码
#define ALIVE_CODE				(0x10)
#define HEAD_LENGTH				(0x06)		// 网络头长度，不含bcc
#define ANT_CFG_LENGTH			(36)		// 天线配置数据结构长度
#define VERSION_LENGTH			(16)		// 版本号数据长度
#define MAX_RECV_BUFFERSIZE		(65535)		// 最大缓冲区字节数
//--------------------命令ID------------------------------------------------
#define UHF_ALIVE				(0x10)		// 通讯心跳设定
#define UHF_INV_ONCE			(0x25)		// 寻卡一次
#define UHF_READ_TAG_DATA		(0x26)		// 读卡数据
#define UHF_WRITE_TAG_DATA		(0x27)		// 写卡数据
#define UHF_INV_MULTIPLY_BEGIN	(0x2A)		// 开始循环寻卡
#define UHF_INV_MULTIPLY_END	(0x2B)		// 停止循环寻卡
#define UHF_LOCK_TAG			(0x2D)		// 锁卡片
#define UHF_KILL_TAG			(0x2E)		// 注销卡片
#define UHF_GET_VERSION			(0x31)		// 读取设备版本号
#define UHF_GET_ANT_CONFIG		(0x32)		// 读取天线参数
#define UHF_SET_ANT_CONFIG		(0x33)		// 设定天线参数
#define UHF_GET_DI_STATE		(0x38)		// 读取Digital Input状态
#define UHF_SET_DO_STATE		(0x39)		// 设定Digital Output状态
//------------------------新增命令------------------------------------------
#define UHF_SET_READ_ZONE		(0x1B)		// 设定连续读卡区域
#define UHF_SET_DEFAULT_ZONE (0x17)		// 设置默认epc区域
#define UHF_SET_NEIGH_JUDGE		(0x1A)	    // 连续相邻判定时间
#define UHF_SET_PASSWORD		(0x1C)		// 设定读卡密码
#define UHF_SET_AB_MODE			(0x1D)		// 设定AB读卡方式
#define UHF_SET_DEVICE_NO		(0x20)		// 设定设备号
#define UHF_SET_CLOCK			(0x43)		// 设定设备时钟
#define UHF_GET_TAG_BUFFER		(0x3A)		// 读取标签缓存
#define UHF_RESET_TAG_BUFFER	(0x3B)		// 清空标签缓存
//-------------- 以下功能硬件暂未支持--------------------------------------
#define UHF_GET_REGION_CONFIG	(0x34)		// 读取频率区域参数
#define UHF_SET_REGION_CONFIG	(0x35)		// 设定频率区域参数
#define UHF_GET_POWMODE			(0x36)		// 读取电源工作模式
#define UHF_SET_POWMODE			(0x37)		// 设定电源工作模式
#define UHF_EXE_TAG_SPEC		(0x3C)		// 执行标签私有指令
#define UHF_ERASE_BLOCK_SPEC	(0x3D)		// 标签私有指令清除块数据
#define UHF_GET_STAT			(0x3E)		// 读取设备统计信息
#define UHF_GET_CONFIGURE		(0x3F)		// 读取设备扩充参数
#define UHF_SET_CONFIGURE		(0x40)		// 设定设备扩充参数

//----------------锁卡操作码及操作区块-------------------------------------
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
#define R_OK					0			// 正确结果
#define R_FAIL					-1			// 错误结果
#define HOST_ERROR				0x80		// 读卡器返回错误码
#define HOST_OK					0x0			// 读卡器返回正确码
#define SERVERPORT				20058		// 端口号

//------------------------错误信息-------------------------------------------
#define INVALID_HOST_IPADDRESS  -2		// 无效主机字符串
#define INVALID_COMM_PORT		-3		// 无效串口号
#define INVALID_HOST_PORTORBANDRATE		-4		// 无效端口号或者波特率
#define INVALID_POINTER		    -5		// 空指针
#define INVALID_COMM_MODE		-6		// 无效的通信模式
#define INVALID_BANK			-7		// 无效区域号
#define INVALID_BEGIN_SIZE		-8		// 无效的起始位置和大小
#define INVALID_PASSWORD		-9		// 无效口令
#define INVALID_ACCESS_PASSWORD	-10		// 无效访问口令
#define INVALID_KILL_PASSWORD	-11		// 无效灭活口令
#define INVALID_OPCODE			-12		// 无效操作码
#define INVALID_PORT_VALUE		-13		// 无效的端口
#define INVALID_STATE_VALUE		-14		// 无效状态值
#define INVALID_MODE_VALUE		-24		// 无效模式值
#define INVALID_CLOCK			-25     // 无效日期
#define INVALID_PARAMETERS		-28		// 无效参数

#define SOKET_CONNECT_FAIL		-15		// 网络连接失败
#define COM_CONNECT_FAIL		-16		// 串口连接失败
#define ERROR_GET_ANT			-26
#define ERROR_NET_INIT			-17		// 网络初始化错
#define ERROR_COM_INIT			-18		// 串口初始化错
#define ERROR_DEV_SEND			-19		// 设备发送错
#define ERROR_DEV_RECV			-20		// 设备接收错
#define ERROR_DEV_CONNECT		-21		// 设备未连接
#define ERROR_OPER_FAIL			-23		// 操作失败

#define ERROR_OPEN_COMM			-24		// 打开串口错
#define ERROR_SET_COMMBUFFER	-25		// 设置串口缓冲区
#define ERROR_SET_COMMTIMEOUT	-26		// 设置串口超时结构
#define ERROR_SET_DCB			-27		// 设置DCB出错
//--------------------- 网络命令包结构 ------------------------------------------
typedef struct _PACKAGE
{
	unsigned char STARTCODE[2];				// 2个字节的起始码
	unsigned char cmd;						// 命令码
	unsigned char seq;						// 顺序号
	unsigned char len[2];					// 长度，0为low,1为high
	unsigned char data[520];				// 数据
	unsigned char bcc;						// 校验位
}PACKAGE, *PPACKAGE;
//-------------------- 天线设置结构 -----------------------------------------
typedef struct _ant_cfg_
{
	unsigned char antEnable[4];				// 天线工作状态, 1:工作;0:不工作
	unsigned long dwell_time[4];			// 一次寻卡工作时间，单位ms
	unsigned long power[4];					// 输出功率,单位1/10(dbm)
}ANT_CFG, *PANT_CFG;
//---------------------------------------------------------------------------


/*******************************************************************************/
typedef void (CALLBACK* HANDLE_FUN)(unsigned char cmdID, void* pData, int length);
/*------------------------------------------------------------------------------- 
  调用者定义回调函数的格式
*********************************************************************************/
APP_DLL int WINAPI GetLastErrorMessage();		
/*-------------------------------------------------------------------------------
  1、名称：GetErrorNo()
  2、功能：获取错误号
  3、参数：无
  4、返回值：错误号
*********************************************************************************/
APP_DLL int  WINAPI deviceInit(char* pHost,int CommMode = 0, unsigned PortOrBaudRate = 20058);
/*-------------------------------------------------------------------------------
   1、名称：deviceInit
　 2、功能：设置主机串,确定连接方式，并初始化设备层各全局变量		
   3、参数：pHost表示通信方式的主机字符串
			CommMode　通信方式，0代表网络模式，1-9是串口模式，同时是串口号
			PortOrBaudRate是通信端口号或波特率。
   4、返回值
			R_OK 初始化成功
			R_FAIL　初始化失败
   5、错误值
			 INVALID_HOST_IPADDRESS  		// 无效IP地址
			 INVALID_COMM_PORT		 		// 无效串口号
			 INVALID_HOST_PORTORBANDRATE	// 无效端口号或波特率
			 INVALID_POINTER		    	// 空指针
			 INVALID_COMM_MODE				// 无效的通信模式
			 ERROR_NET_INIT					// 网络初始化错
			 ERROR_COM_INIT					// 串口初始化错
********************************************************************************/
APP_DLL int  WINAPI  deviceConnect();
/*------------------------------------------------------------------------------- 
   1、名称：deviceConnect
　 2、功能：连接设备
   3、参数：无
　 4、返回值：
			R_OK   连接成功
			R_FAIL 连接失败
   5、错误值
			SOKET_CONNECT_FAIL 				// 网络连接失败
			COM_CONNECT_FAIL				// 串口连接失败
/********************************************************************************/
APP_DLL void    WINAPI  deviceDisconnect();
/*------------------------------------------------------------------------------- 
　 1、名称：deviceDisconnect
　 2、功能：断开设备连接
   3、函数参数：无
　 4、返回值：无
*********************************************************************************/
APP_DLL void   WINAPI  deviceUnInit();
/*------------------------------------------------------------------------------- 
　 1、名称：deviceUnInit
　 2、功能：恢复初始值		
   3、参数：无
   4、返回值：无
*********************************************************************************/
APP_DLL int WINAPI GetDevVersion(unsigned char* pVer);
/*------------------------------------------------------------------------------- 
	1、名称:  GetDevVersion
	2、功能:  获取设备版本号（16Bytes）
	3、参数:  pVersion 接收数据的缓冲区地址    
	4、返回值
			  R_OK 数据正常读出
			  R_FAIL 读取失败
	5、错误值
			  INVALID_POINTER					// 无效指针
			  ERROR_DEV_CONNECT				    // 设备未连接
			  ERROR_DEV_SEND					// 设备发送错
			  ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL int   WINAPI   GetAnt(PANT_CFG pAntCfg);
/*------------------------------------------------------------------------------- 
	1、名称:  GetAnt
	2、功能:  获取天线工作参数
	3、参数　　pAntCfg　天线结构体指针
	4、返回值:
			R_OK   成功
			R_FAIL 失败
	5、错误值
			INVALID_POINTER					// 无效指针
			ERROR_GET_ANT					// 获取天线数据错误
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错

*********************************************************************************/
APP_DLL int    WINAPI   SetAnt(const PANT_CFG pAntCfg);
/*------------------------------------------------------------------------------- 
	1、名称:  SetAnt
	2、功能:  设置天线工作参数
	3、参数;  pAntCfg保存天线参数的结构体指针
	4、返回值:
			R_OK   成功
			R_FAIL 失败
	5、错误值
			INVALID_POINTER					// 无效指针
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_OPER_FAIL					// 操作失败
********************************************************************************/
APP_DLL int  WINAPI  WriteTagData(unsigned char bank, unsigned char begin,
				  unsigned char size,	const unsigned char* pData,
				  char* pPassword = "\0\0\0\0");
/*------------------------------------------------------------------------------- 
	1、名称: WriteTagData
	2、功能: 写标签到指定区域
	3、参数
			bank: 要写入的数据区域
			begin:开始地址
			size: 要写入的字数
			pPassword: 口令
			pData: 存储数据buffer
	4、返回值:
			R_OK : 成功
			R_FAIL:失败
	5、错误值
			INVALID_POINTER					// 无效指针
			INVALID_BANK					// 无效区域号
			INVALID_BEGIN_SIZE				// 无效的起始位置和大小
			INVALID_PASSWORD				// 无效口令
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL int   WINAPI  ReadTagData(unsigned char bank, unsigned char begin,				
				   unsigned char size, unsigned char* pOutData,	        
				   char* pPassword = "\0\0\0\0");	 
/*-------------------------------------------------------------------------------
	1、名称: ReadTagData
	2、功能: 获取读取标签指定区域的数据
	3、参数
			bank: 要读取的数据区域
			begin:开始地址
			size: 要读取的字数
			pPassword: 口令
			pData: 存储数据buffer
	4、返回值:
			R_OK   成功
			R_FAIL 失败
	5、错误值
			INVALID_POINTER					// 无效指针
			INVALID_BANK					// 无效区域号
			INVALID_BEGIN_SIZE				// 无效的起始位置和大小
			INVALID_PASSWORD				// 无效口令
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL int   WINAPI   BeginMultiInv(HANDLE_FUN f);
/*------------------------------------------------------------------------------- 
	1、名称:  BeginMultiInv
	2、功能:  连续寻卡
	3、参数:  f 调用者定义的回调函数
	4、返回值:
			R_OK 数据正常读出
			R_FAIL 读取失败
	5、错误值
			INVALID_POINTER					// 无效指针
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错
*********************************************************************************/
APP_DLL int  WINAPI  StopInv();
/*------------------------------------------------------------------------------- 
	1、名称:  StopInv
	2、功能:  停止连续寻卡
	3、参数:  无
	4、返回值:
			R_OK   成功
			R_FAIL 否则失败
	5、错误值
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错
*********************************************************************************/
APP_DLL int   WINAPI   BeginOnceInv(HANDLE_FUN f) ;
/*------------------------------------------------------------------------------- 
	1、名称:  BeginOnceInv
	2、功能:  寻卡一次
	3、参数:  f 调用者定义的回调函数	    
	4、返回值:
			R_OK 数据正常读出
			R_FAIL 读取失败
	5、错误值
		   INVALID_POINTER					// 无效指针
   		   ERROR_DEV_CONNECT				// 设备未连接
		   ERROR_DEV_SEND					// 设备发送错
*********************************************************************************/
APP_DLL int    WINAPI  SetAlive(unsigned char intervalSecond);
/*------------------------------------------------------------------------------- 
	1、名称:  SetAlive
	2、功能:  设置心跳包时间间隔
	3、参数
			intervalSecond 要设置的时间间隔(0-255)
	4、返回值:
			R_OK 设置成功
			R_FAIL 设置失败
	5、错误值
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
********************************************************************************/
APP_DLL int  WINAPI  KillTag(unsigned char* pKill_pwd,unsigned char* pAccess_pwd);
/*------------------------------------------------------------------------------- 
	1、名称:  KillTag
	2、功能:  销毁标签
	3、参数
			pKill_pwd 　　灭活密码
			pAccess_pwd　 访问密码
	4、返回值:
			R_OK   成功
			R_FAIL 否则失败
	5、错误值
			INVALID_PASSWORD				// 无效口令
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL int   WINAPI   LockTag(unsigned char opcode,  unsigned char block, char* pPassword);
/*------------------------------------------------------------------------------- 
	1、名称: LockTag
	2、功能: 锁定标签
	3、参数
			opcode 操作码
			block  操作区域
			pPassword: 口令
	4、返回值
			R_OK   成功
			R_FAIL 否则失败
	5、错误值
			INVALID_BANK					// 无效区域号
			INVALID_OPCODE			　		// 无效操作码
			INVALID_PASSWORD				// 无效口令
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL int   WINAPI   SetDefaultZone(bool bOpen);
/*------------------------------------------------------------------------------- 
	1、名称: SetDefaultZone
	2、功能: 设置默认读区域
	3、参数
			bOpen TRUE 打开默认的EPC
						FALSE 关闭默认的EPC，使用其它指定区域
	4、返回值
			R_OK   成功
			R_FAIL 否则失败
	5、错误值
			INVALID_BANK					// 无效区域号
			INVALID_BEGIN_SIZE		　		// 无效操作码
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL int   WINAPI   SetReadZone(unsigned char bank, unsigned char begin, unsigned char size);
/*------------------------------------------------------------------------------- 
	1、名称: SetReadZone
	2、功能: 设置连续寻卡区域
	3、参数
			bank: 数据区域
			begin:开始地址
			size: 读取的字数
	4、返回值
			R_OK   成功
			R_FAIL 否则失败
	5、错误值
			INVALID_BANK					// 无效区域号
			INVALID_BEGIN_SIZE		　		// 无效操作码
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL int   WINAPI   SetDeviceNo(unsigned char deviceNo);
/*------------------------------------------------------------------------------- 
	1、名称: SetDeviceNo
	2、功能: 设置设备号
	3、参数
			deviceNo 设备号
	4、返回值
			R_OK   成功
			R_FAIL 否则失败
	5、错误值
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL int   WINAPI   SetNeighJudgeTime(unsigned char time);
/*------------------------------------------------------------------------------- 
	1、名称: SetNeighJudgeTime
	2、功能: 设置相邻判定时间
	3、参数
			time 相邻判定时间
	4、返回值
			R_OK   成功
			R_FAIL 否则失败
	5、错误值
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL int   WINAPI   SetABMode(unsigned char ABMode);
/*------------------------------------------------------------------------------- 
	1、名称: SetABMode
	2、功能: 设置AB读卡模式
	3、参数
			ABMode(1. 设置AB模式　0. 取消AB模式) 
	4、返回值
			R_OK   成功
			R_FAIL 否则失败
	5、错误值
			INVALID_MODE_VALUE				// 无效模式值
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL int   WINAPI   SetReadPassword(char* pPassword);
/*------------------------------------------------------------------------------- 
	1、名称: SetReadPassword
	2、功能: 设置寻卡密码
	3、参数
			pPassword　8个字符缓冲区 
	4、返回值
			R_OK   成功
			R_FAIL 否则失败
	5、错误值
			INVALID_PASSWORD				// 无效密码
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL int   WINAPI   SetClock(char* pClock);
/*------------------------------------------------------------------------------- 
	1、名称: SetClock
	2、功能: 设置设备时钟
	3、参数
			pClock　时钟字符缓冲区（yy-mm-dd-ww-hh-mm-ss）
			分别为年、月、日、星期、时、分、秒
	4、返回值
			R_OK   成功
			R_FAIL 否则失败
	5、错误值
			INVALID_CLOCK  				    // 无效日期
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL int  WINAPI  ResetTagBuffer();
/*------------------------------------------------------------------------------- 
	1、名称: ResetTagBuffer
	2、功能: 清空设备读取的标签列表
	3、参数: 无
	4、返回值:
			R_OK 成功
			R_FAIL 失败
	5、错误值
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL int  WINAPI  ReadTagBuffer(HANDLE_FUN CallBackFunc);
/*------------------------------------------------------------------------------- 
	1、名称: ReadTagBuffer
	2、功能: 读取标签列表
	3、参数: CallBackFunc　回调函数名
	4、返回值:
			R_OK 成功
			R_FAIL 失败
	5、错误值
			INVALID_POINTER					// 无效指针
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL int  WINAPI  SetDO(const unsigned char port, const unsigned char state);
/*------------------------------------------------------------------------------- 
	1、名称: SetDO
	2、功能: 设置Digital Output状态
	3、参数
			port 要设定的端口
			state 状态值
	4、返回值:
			R_OK 设定成功
			R_FAIL 设定失败
	5、错误值
			INVALID_PORT_VALUE			　　// 无效的端口
			INVALID_STATE_VALUE		　		// 无效状态值
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL int  WINAPI  GetDI(unsigned char* pDIState);
/*------------------------------------------------------------------------------- 
	1、名称:  GetDI
	2、功能:  读取Digital Input状态
	3、参数
			pDIState 输出缓冲区，无符号字符格式
	4、返回值:
			R_OK 读取成功
			R_FAIL 读取失败
	5、错误值
			INVALID_POINTER					// 无效指针
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
*********************************************************************************/
APP_DLL void WINAPI ForceStop();
/*------------------------------------------------------------------------------- 
	1、名称:  ForceStop()
	2、功能:  强制设备终止连续读卡状态
	3、参数
			无
	4、返回值:
			无
*********************************************************************************/
#define MAX_WORK_THREAD 20	// 最多线程数
#define QUE_LEN	  10		// 队列长度
#define WORK_MSEC 2000		// 单根天线工作时间(ms)
#define WORK_POWER 300		// 工作功率（1/10dbm)
#define MAX_TAGS   36		// 一次读取的最大标签数

APP_DLL void  WINAPI PrintBuffer(unsigned char* pBuf, int leng);
/*------------------------------------------------------------------------------- 
	1、名称:  PrintBuffer
	2、功能:  按字节显示缓冲区内容
	3、参数:  pBuf 缓冲区地区
			　leng 长度
	4、返回值:
			无
*********************************************************************************/
APP_DLL bool  WINAPI  InitMTEnv(HANDLE_FUN f);
/*------------------------------------------------------------------------------- 
	1、名称:  InitMTEnv
	2、功能:  初始化多线程环境
	3、参数
			f 回调函数名称
	4、返回值:
			TRUE 读取成功
			FALSE 读取失败
	5、错误值
			INVALID_PARAMETERS				// 无效参数
*********************************************************************************/
APP_DLL bool  WINAPI DispatchThreadResource(char* pIP, int antId,int deviceId,unsigned port = 20058);
/*------------------------------------------------------------------------------- 
	1、名称:  DispatchThreadResource
	2、功能:  分发线程资源
	3、参数
			char* pIP　IP地址
			int antId　天线号
			int deviceId　设备号
			unsigned port 端口号
	4、返回值:
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_PARAMETERS				// 无效参数
*********************************************************************************/
APP_DLL void  WINAPI StopMTOnceInv();
/*------------------------------------------------------------------------------- 
	1、名称:  StopMTOnceInv
	2、功能:  结束多线程任务
	3、参数:　无
	4、返回值:元
*********************************************************************************/
#endif 