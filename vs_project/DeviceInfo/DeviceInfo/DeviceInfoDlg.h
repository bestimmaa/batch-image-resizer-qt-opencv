
// DeviceInfoDlg.h : header file
//

#pragma once
#include "afxwin.h"


// CDeviceInfoDlg dialog
class CDeviceInfoDlg : public CDialogEx
{
// Construction
public:
	CDeviceInfoDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_DEVICEINFO_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnEnChangeEdit2();
private:
	CEdit editcontrol_path;
private:
	CEdit editcontrol_volume;
private:
	CEdit editcontrol_fs;
private:
	CEdit editcontrol_cmpntlen;
private:
	CComboBox combobox_device;
public:
	void ShowInfo();
};
