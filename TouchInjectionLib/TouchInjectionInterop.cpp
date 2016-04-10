#include "stdafx.h"
#include "TouchInjectionInterop.h"

void WINAPI TouchTest()
{
	POINTER_TOUCH_INFO contact;
	BOOL bRet = TRUE;

	//
	// assume a maximum of 3 contacts and turn touch feedback off
	//
	InitializeTouchInjection(3, TOUCH_FEEDBACK_NONE);

	//
	// initialize the touch info structure
	//
	memset(&contact, 0, sizeof(POINTER_TOUCH_INFO));

	contact.pointerInfo.pointerType = PT_TOUCH; //we're sending touch input
	contact.pointerInfo.pointerId = 0;          //contact 0
	contact.pointerInfo.ptPixelLocation.x = 640;
	contact.pointerInfo.ptPixelLocation.y = 480;
	contact.pointerInfo.pointerFlags = POINTER_FLAG_DOWN | POINTER_FLAG_INRANGE | POINTER_FLAG_INCONTACT;
	contact.touchMask = TOUCH_MASK_CONTACTAREA | TOUCH_MASK_ORIENTATION | TOUCH_MASK_PRESSURE;
	contact.orientation = 90;
	contact.pressure = 32000;

	//
	// set the contact area depending on thickness
	//
	contact.rcContact.top = 480 - 2;
	contact.rcContact.bottom = 480 + 2;
	contact.rcContact.left = 640 - 2;
	contact.rcContact.right = 640 + 2;

	//
	// inject a touch down
	//
	bRet = InjectTouchInput(1, &contact);

	//
	// if touch down was succesfull, send a touch up
	//
	if (bRet) {
		contact.pointerInfo.pointerFlags = POINTER_FLAG_UP;

		//
		// inject a touch up
		//
		InjectTouchInput(1, &contact);
	}
}