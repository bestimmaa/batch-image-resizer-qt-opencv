
// BBP_MFC.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// CBBP_MFCApp:
// See BBP_MFC.cpp for the implementation of this class
//

class CBBP_MFCApp : public CWinApp
{
public:
	CBBP_MFCApp();

// Overrides
public:
	virtual BOOL InitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
};

extern CBBP_MFCApp theApp;