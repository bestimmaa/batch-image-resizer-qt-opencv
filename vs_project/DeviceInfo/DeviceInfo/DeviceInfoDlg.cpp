
// DeviceInfoDlg.cpp : implementation file
//

#include "stdafx.h"
#include "DeviceInfo.h"
#include "DeviceInfoDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CAboutDlg dialog used for App About

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// CDeviceInfoDlg dialog



CDeviceInfoDlg::CDeviceInfoDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CDeviceInfoDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CDeviceInfoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, EDITCONTROL_PATH, editcontrol_path);
	DDX_Control(pDX, EDITCONTROL_VOLUME, editcontrol_volume);
	DDX_Control(pDX, EDITCONTROL_FS, editcontrol_fs);
	DDX_Control(pDX, EDITCONTROL_CMPNTLEN, editcontrol_cmpntlen);
	DDX_Control(pDX, DEVICE_SELECTOR, combobox_device);
}

BEGIN_MESSAGE_MAP(CDeviceInfoDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_EN_CHANGE(DEVICE_SELECTOR, &CDeviceInfoDlg::OnEnChangeEdit2)
END_MESSAGE_MAP()


// CDeviceInfoDlg message handlers

BOOL CDeviceInfoDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// Add all drive letters to combo box
	CString s;
	DWORD dwDrives = ::GetLogicalDrives();
	for (int i = 0; dwDrives != 0; ++i, dwDrives >>= 1)
	{
		if ((dwDrives & 0x01) == 0x01){
			s.Format(_T("%c:"), 'A' + i);
			combobox_device.AddString(s);
		}
	}

	combobox_device.SetCurSel(0);
	ShowInfo();

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CDeviceInfoDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CDeviceInfoDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CDeviceInfoDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CDeviceInfoDlg::OnEnChangeEdit2()
{
	// TODO:  If this is a RICHEDIT control, the control will not
	// send this notification unless you override the CDialogEx::OnInitDialog()
	// function and call CRichEditCtrl().SetEventMask()
	// with the ENM_CHANGE flag ORed into the mask.

	// TODO:  Add your control notification handler code here
}


void CDeviceInfoDlg::ShowInfo()
{
	CString s;
	CString sRootPathName;
	CString sVolumeName;
	DWORD dwVolumeSerialNumber;
	DWORD dwMaxComponentLength;
	DWORD dwFileSystemFlags;
	CString sFileSystemName;

	combobox_device.GetWindowText(s);
	sRootPathName.Format(_T("%s\\"), s);

	BOOL bSuccess = ::GetVolumeInformation(sRootPathName,
		sVolumeName.GetBufferSetLength(MAX_PATH + 1),
		MAX_PATH + 1,
		&dwVolumeSerialNumber,
		&dwMaxComponentLength,
		&dwFileSystemFlags,
		sFileSystemName.GetBufferSetLength(MAX_PATH+1),
		MAX_PATH+1);

	if (bSuccess){
		editcontrol_path.SetWindowText(sRootPathName);
		editcontrol_volume.SetWindowText(sVolumeName);
		editcontrol_fs.SetWindowText(sFileSystemName);
		s.Format(_T("%u"), dwMaxComponentLength);
		editcontrol_cmpntlen.SetWindowText(s);
	}
	else{
		s = _T("Volume not available!");
		editcontrol_volume.SetWindowText(s);
	}
}
