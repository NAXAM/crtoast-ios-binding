using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace CRToast
{
    [Native]
public enum CRToastInteractionType : long
{
    SwipeUp = 1 << 0,
    SwipeLeft = 1 << 1,
    SwipeDown = 1 << 2,
    SwipeRight = 1 << 3,
    TapOnce = 1 << 4,
    TapTwice = 1 << 5,
    TwoFingerTapOnce = 1 << 6,
    TwoFingerTapTwice = 1 << 7,
    Swipe = (SwipeUp | SwipeLeft | SwipeDown | SwipeRight),
    Tap = (TapOnce | TapTwice | TwoFingerTapOnce | TwoFingerTapTwice),
    All = (Swipe | Tap)
}

//static class CFunctions
//{
//    // extern NSString * NSStringFromCRToastInteractionType (CRToastInteractionType interactionType);
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern NSString NSStringFromCRToastInteractionType (CRToastInteractionType interactionType);

//    // BOOL CRFrameAutoAdjustedForOrientation ();
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern bool CRFrameAutoAdjustedForOrientation ();

//    // BOOL CRUseSizeClass ();
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern bool CRUseSizeClass ();

//    // BOOL CRHorizontalSizeClassRegular ();
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern bool CRHorizontalSizeClassRegular ();

//    // UIInterfaceOrientation CRGetDeviceOrientation ();
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern UIInterfaceOrientation CRGetDeviceOrientation ();

//    // CGFloat CRGetStatusBarHeightForOrientation (UIInterfaceOrientation orientation);
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern nfloat CRGetStatusBarHeightForOrientation (UIInterfaceOrientation orientation);

//    // CGFloat CRGetStatusBarWidthForOrientation (UIInterfaceOrientation orientation);
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern nfloat CRGetStatusBarWidthForOrientation (UIInterfaceOrientation orientation);

//    // CGFloat CRGetStatusBarWidth ();
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern nfloat CRGetStatusBarWidth ();

//    // CGFloat CRGetNavigationBarHeightForOrientation (UIInterfaceOrientation orientation);
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern nfloat CRGetNavigationBarHeightForOrientation (UIInterfaceOrientation orientation);

//    // CGFloat CRGetNotificationViewHeightForOrientation (CRToastType type, CGFloat preferredNotificationHeight, UIInterfaceOrientation orientation);
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern nfloat CRGetNotificationViewHeightForOrientation (CRToastType type, nfloat preferredNotificationHeight, UIInterfaceOrientation orientation);

//    // CGFloat CRGetNotificationViewHeight (CRToastType type, CGFloat preferredNotificationHeight);
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern nfloat CRGetNotificationViewHeight (CRToastType type, nfloat preferredNotificationHeight);

//    // CGFloat CRGetStatusBarHeight ();
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern nfloat CRGetStatusBarHeight ();

//    // CGSize CRNotificationViewSizeForOrientation (CRToastType notificationType, CGFloat preferredNotificationHeight, UIInterfaceOrientation orientation);
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern CGSize CRNotificationViewSizeForOrientation (CRToastType notificationType, nfloat preferredNotificationHeight, UIInterfaceOrientation orientation);

//    // CGSize CRNotificationViewSize (CRToastType notificationType, CGFloat preferredNotificationHeight);
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern CGSize CRNotificationViewSize (CRToastType notificationType, nfloat preferredNotificationHeight);

//    // CGRect CRNotificationViewFrame (CRToastType type, CRToastAnimationDirection direction, CGFloat preferredNotificationHeight);
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern CGRect CRNotificationViewFrame (CRToastType type, CRToastAnimationDirection direction, nfloat preferredNotificationHeight);

//    // CGRect CRStatusBarViewFrame (CRToastType type, CRToastAnimationDirection direction, CGFloat preferredNotificationHeight);
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern CGRect CRStatusBarViewFrame (CRToastType type, CRToastAnimationDirection direction, nfloat preferredNotificationHeight);

//    // CGRect CRGetNotificationContainerFrame (UIInterfaceOrientation statusBarOrientation, CGSize notificationSize);
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern CGRect CRGetNotificationContainerFrame (UIInterfaceOrientation statusBarOrientation, CGSize notificationSize);

//    // UIView * CRStatusBarSnapShotView (BOOL underStatusBar);
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern UIView CRStatusBarSnapShotView (bool underStatusBar);

//    // extern CGFloat CRContentWidthForAccessoryViewsWithAlignments (CGFloat fullContentWidth, CGFloat fullContentHeight, CGFloat preferredPadding, BOOL showingImage, CRToastAccessoryViewAlignment imageAlignment, BOOL showingActivityIndicator, CRToastAccessoryViewAlignment activityIndicatorAlignment);
//    [DllImport ("__Internal")]
//    [Verify (PlatformInvoke)]
//    static extern nfloat CRContentWidthForAccessoryViewsWithAlignments (nfloat fullContentWidth, nfloat fullContentHeight, nfloat preferredPadding, bool showingImage, CRToastAccessoryViewAlignment imageAlignment, bool showingActivityIndicator, CRToastAccessoryViewAlignment activityIndicatorAlignment);
//}

[Native]
public enum CRToastType : long
{
    StatusBar,
    NavigationBar,
    Custom
}

[Native]
public enum CRToastPresentationType : long
{
    Cover,
    Push
}

[Native]
public enum CRToastAnimationDirection : long
{
    Top,
    Bottom,
    Left,
    Right
}

[Native]
public enum CRToastAnimationType : long
{
    Linear,
    Spring,
    Gravity
}

[Native]
public enum CRToastState : long
{
    Waiting,
    Entering,
    Displaying,
    Exiting,
    Completed
}

[Native]
public enum CRToastAccessoryViewAlignment : long
{
    Left,
    Center,
    Right
}
}
