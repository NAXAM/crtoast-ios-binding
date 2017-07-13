using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace CRToast
{
	// @interface CRToastManager : NSObject
	[BaseType(typeof(NSObject))]
	interface CRToastManager
	{
		// +(void)setDefaultOptions:(NSDictionary *)defaultOptions;
		[Static]
		[Export("setDefaultOptions:")]
		void SetDefaultOptions(NSDictionary defaultOptions);

		// +(void)showNotificationWithOptions:(NSDictionary *)options apperanceBlock:(void (^)(void))appearance completionBlock:(void (^)(void))completion;
		[Static]
		[Export("showNotificationWithOptions:apperanceBlock:completionBlock:")]
		void ShowNotificationWithOptions(NSDictionary options, Action appearance, Action completion);

		// +(void)showNotificationWithOptions:(NSDictionary *)options completionBlock:(void (^)(void))completion;
		[Static]
		[Export("showNotificationWithOptions:completionBlock:")]
		void ShowNotificationWithOptions(NSDictionary options, Action completion);

		// +(void)showNotificationWithMessage:(NSString *)message completionBlock:(void (^)(void))completion;
		[Static]
		[Export("showNotificationWithMessage:completionBlock:")]
		void ShowNotificationWithMessage(string message, Action completion);

		// +(void)dismissNotification:(BOOL)animated;
		[Static]
		[Export("dismissNotification:")]
		void DismissNotification(bool animated);

		// +(void)dismissAllNotifications:(BOOL)animated;
		[Static]
		[Export("dismissAllNotifications:")]
		void DismissAllNotifications(bool animated);

		// +(void)dismissAllNotificationsWithIdentifier:(NSString *)identifer animated:(BOOL)animated;
		[Static]
		[Export("dismissAllNotificationsWithIdentifier:animated:")]
		void DismissAllNotificationsWithIdentifier(string identifer, bool animated);

		// +(NSArray *)notificationIdentifiersInQueue;
		[Static]
		[Export("notificationIdentifiersInQueue")]
		//[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
		NSObject[] NotificationIdentifiersInQueue { get; }

		// +(BOOL)isShowingNotification;
		[Static]
		[Export("isShowingNotification")]
		//[Verify(MethodToProperty)]
		bool IsShowingNotification { get; }
	}

	// @interface CRToastInteractionResponder : NSObject
	[BaseType(typeof(NSObject))]
	interface CRToastInteractionResponder
	{
		// +(instancetype)interactionResponderWithInteractionType:(CRToastInteractionType)interactionType automaticallyDismiss:(BOOL)automaticallyDismiss block:(void (^)(CRToastInteractionType))block;
		[Static]
		[Export("interactionResponderWithInteractionType:automaticallyDismiss:block:")]
		CRToastInteractionResponder InteractionResponderWithInteractionType(CRToastInteractionType interactionType, bool automaticallyDismiss, Action<CRToastInteractionType> block);
	}

	[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const kCRToastNotificationTypeKey;
		[Field("kCRToastNotificationTypeKey", "__Internal")]
		NSString kCRToastNotificationTypeKey { get; }

		// extern NSString *const kCRToastNotificationPreferredHeightKey;
		[Field("kCRToastNotificationPreferredHeightKey", "__Internal")]
		NSString kCRToastNotificationPreferredHeightKey { get; }

		// extern NSString *const kCRToastNotificationPreferredPaddingKey;
		[Field("kCRToastNotificationPreferredPaddingKey", "__Internal")]
		NSString kCRToastNotificationPreferredPaddingKey { get; }

		// extern NSString *const kCRToastNotificationPresentationTypeKey;
		[Field("kCRToastNotificationPresentationTypeKey", "__Internal")]
		NSString kCRToastNotificationPresentationTypeKey { get; }

		// extern NSString *const kCRToastUnderStatusBarKey;
		[Field("kCRToastUnderStatusBarKey", "__Internal")]
		NSString kCRToastUnderStatusBarKey { get; }

		// extern NSString *const kCRToastKeepNavigationBarBorderKey;
		[Field("kCRToastKeepNavigationBarBorderKey", "__Internal")]
		NSString kCRToastKeepNavigationBarBorderKey { get; }

		// extern NSString *const kCRToastAnimationInTypeKey;
		[Field("kCRToastAnimationInTypeKey", "__Internal")]
		NSString kCRToastAnimationInTypeKey { get; }

		// extern NSString *const kCRToastAnimationOutTypeKey;
		[Field("kCRToastAnimationOutTypeKey", "__Internal")]
		NSString kCRToastAnimationOutTypeKey { get; }

		// extern NSString *const kCRToastAnimationInDirectionKey;
		[Field("kCRToastAnimationInDirectionKey", "__Internal")]
		NSString kCRToastAnimationInDirectionKey { get; }

		// extern NSString *const kCRToastAnimationOutDirectionKey;
		[Field("kCRToastAnimationOutDirectionKey", "__Internal")]
		NSString kCRToastAnimationOutDirectionKey { get; }

		// extern NSString *const kCRToastAnimationInTimeIntervalKey;
		[Field("kCRToastAnimationInTimeIntervalKey", "__Internal")]
		NSString kCRToastAnimationInTimeIntervalKey { get; }

		// extern NSString *const kCRToastTimeIntervalKey;
		[Field("kCRToastTimeIntervalKey", "__Internal")]
		NSString kCRToastTimeIntervalKey { get; }

		// extern NSString *const kCRToastAnimationOutTimeIntervalKey;
		[Field("kCRToastAnimationOutTimeIntervalKey", "__Internal")]
		NSString kCRToastAnimationOutTimeIntervalKey { get; }

		// extern NSString *const kCRToastAnimationSpringDampingKey;
		[Field("kCRToastAnimationSpringDampingKey", "__Internal")]
		NSString kCRToastAnimationSpringDampingKey { get; }

		// extern NSString *const kCRToastAnimationSpringInitialVelocityKey;
		[Field("kCRToastAnimationSpringInitialVelocityKey", "__Internal")]
		NSString kCRToastAnimationSpringInitialVelocityKey { get; }

		// extern NSString *const kCRToastAnimationGravityMagnitudeKey;
		[Field("kCRToastAnimationGravityMagnitudeKey", "__Internal")]
		NSString kCRToastAnimationGravityMagnitudeKey { get; }

		// extern NSString *const kCRToastTextKey;
		[Field("kCRToastTextKey", "__Internal")]
		NSString kCRToastTextKey { get; }

		// extern NSString *const kCRToastFontKey;
		[Field("kCRToastFontKey", "__Internal")]
		NSString kCRToastFontKey { get; }

		// extern NSString *const kCRToastTextColorKey;
		[Field("kCRToastTextColorKey", "__Internal")]
		NSString kCRToastTextColorKey { get; }

		// extern NSString *const kCRToastTextAlignmentKey;
		[Field("kCRToastTextAlignmentKey", "__Internal")]
		NSString kCRToastTextAlignmentKey { get; }

		// extern NSString *const kCRToastTextShadowColorKey;
		[Field("kCRToastTextShadowColorKey", "__Internal")]
		NSString kCRToastTextShadowColorKey { get; }

		// extern NSString *const kCRToastTextShadowOffsetKey;
		[Field("kCRToastTextShadowOffsetKey", "__Internal")]
		NSString kCRToastTextShadowOffsetKey { get; }

		// extern NSString *const kCRToastTextMaxNumberOfLinesKey;
		[Field("kCRToastTextMaxNumberOfLinesKey", "__Internal")]
		NSString kCRToastTextMaxNumberOfLinesKey { get; }

		// extern NSString *const kCRToastSubtitleTextKey;
		[Field("kCRToastSubtitleTextKey", "__Internal")]
		NSString kCRToastSubtitleTextKey { get; }

		// extern NSString *const kCRToastSubtitleFontKey;
		[Field("kCRToastSubtitleFontKey", "__Internal")]
		NSString kCRToastSubtitleFontKey { get; }

		// extern NSString *const kCRToastSubtitleTextColorKey;
		[Field("kCRToastSubtitleTextColorKey", "__Internal")]
		NSString kCRToastSubtitleTextColorKey { get; }

		// extern NSString *const kCRToastSubtitleTextAlignmentKey;
		[Field("kCRToastSubtitleTextAlignmentKey", "__Internal")]
		NSString kCRToastSubtitleTextAlignmentKey { get; }

		// extern NSString *const kCRToastSubtitleTextShadowColorKey;
		[Field("kCRToastSubtitleTextShadowColorKey", "__Internal")]
		NSString kCRToastSubtitleTextShadowColorKey { get; }

		// extern NSString *const kCRToastSubtitleTextShadowOffsetKey;
		[Field("kCRToastSubtitleTextShadowOffsetKey", "__Internal")]
		NSString kCRToastSubtitleTextShadowOffsetKey { get; }

		// extern NSString *const kCRToastSubtitleTextMaxNumberOfLinesKey;
		[Field("kCRToastSubtitleTextMaxNumberOfLinesKey", "__Internal")]
		NSString kCRToastSubtitleTextMaxNumberOfLinesKey { get; }

		// extern NSString *const kCRToastStatusBarStyleKey;
		[Field("kCRToastStatusBarStyleKey", "__Internal")]
		NSString kCRToastStatusBarStyleKey { get; }

		// extern NSString *const kCRToastBackgroundColorKey;
		[Field("kCRToastBackgroundColorKey", "__Internal")]
		NSString kCRToastBackgroundColorKey { get; }

		// extern NSString *const kCRToastBackgroundViewKey;
		[Field("kCRToastBackgroundViewKey", "__Internal")]
		NSString kCRToastBackgroundViewKey { get; }

		// extern NSString *const kCRToastImageKey;
		[Field("kCRToastImageKey", "__Internal")]
		NSString kCRToastImageKey { get; }

		// extern NSString *const kCRToastImageContentModeKey;
		[Field("kCRToastImageContentModeKey", "__Internal")]
		NSString kCRToastImageContentModeKey { get; }

		// extern NSString *const kCRToastImageAlignmentKey;
		[Field("kCRToastImageAlignmentKey", "__Internal")]
		NSString kCRToastImageAlignmentKey { get; }

		// extern NSString *const kCRToastImageTintKey;
		[Field("kCRToastImageTintKey", "__Internal")]
		NSString kCRToastImageTintKey { get; }

		// extern NSString *const kCRToastShowActivityIndicatorKey;
		[Field("kCRToastShowActivityIndicatorKey", "__Internal")]
		NSString kCRToastShowActivityIndicatorKey { get; }

		// extern NSString *const kCRToastActivityIndicatorViewStyleKey;
		[Field("kCRToastActivityIndicatorViewStyleKey", "__Internal")]
		NSString kCRToastActivityIndicatorViewStyleKey { get; }

		// extern NSString *const kCRToastActivityIndicatorAlignmentKey;
		[Field("kCRToastActivityIndicatorAlignmentKey", "__Internal")]
		NSString kCRToastActivityIndicatorAlignmentKey { get; }

		// extern NSString *const kCRToastInteractionRespondersKey;
		[Field("kCRToastInteractionRespondersKey", "__Internal")]
		NSString kCRToastInteractionRespondersKey { get; }

		// extern NSString *const kCRToastForceUserInteractionKey;
		[Field("kCRToastForceUserInteractionKey", "__Internal")]
		NSString kCRToastForceUserInteractionKey { get; }

		// extern NSString *const kCRToastAutorotateKey;
		[Field("kCRToastAutorotateKey", "__Internal")]
		NSString kCRToastAutorotateKey { get; }

		// extern NSString *const kCRToastIdentifierKey;
		[Field("kCRToastIdentifierKey", "__Internal")]
		NSString kCRToastIdentifierKey { get; }

		// extern NSString *const kCRToastCaptureDefaultWindowKey;
		[Field("kCRToastCaptureDefaultWindowKey", "__Internal")]
		NSString kCRToastCaptureDefaultWindowKey { get; }
	}


 //   // @interface CRToast : NSObject <UIGestureRecognizerDelegate>
 //   [BaseType(typeof(NSObject))]
	//interface CRToast : IUIGestureRecognizerDelegate
	//{
	//	// @property (nonatomic, strong) NSUUID * uuid;
	//	[Export("uuid", ArgumentSemantic.Strong)]
	//	NSUuid Uuid { get; set; }

	//	// @property (assign, nonatomic) CRToastState state;
	//	[Export("state", ArgumentSemantic.Assign)]
	//	CRToastState State { get; set; }

	//	// @property (nonatomic, strong) NSDictionary * options;
	//	[Export("options", ArgumentSemantic.Strong)]
	//	NSDictionary Options { get; set; }

	//	// @property (copy, nonatomic) void (^completion)();
	//	[Export("completion", ArgumentSemantic.Copy)]
	//	Action Completion { get; set; }

	//	// @property (copy, nonatomic) void (^appearance)();
	//	[Export("appearance", ArgumentSemantic.Copy)]
	//	Action Appearance { get; set; }

	//	// @property (nonatomic, strong) NSArray * gestureRecognizers;
	//	[Export("gestureRecognizers", ArgumentSemantic.Strong)]
	//	//[Verify(StronglyTypedNSArray)]
	//	NSObject[] GestureRecognizers { get; set; }

	//	// @property (assign, nonatomic) BOOL autorotate;
	//	[Export("autorotate")]
	//	bool Autorotate { get; set; }

	//	// @property (readonly, nonatomic) UIView * notificationView;
	//	[Export("notificationView")]
	//	UIView NotificationView { get; }

	//	// @property (readonly, nonatomic) CGRect notificationViewAnimationFrame1;
	//	[Export("notificationViewAnimationFrame1")]
	//	CGRect NotificationViewAnimationFrame1 { get; }

	//	// @property (readonly, nonatomic) CGRect notificationViewAnimationFrame2;
	//	[Export("notificationViewAnimationFrame2")]
	//	CGRect NotificationViewAnimationFrame2 { get; }

	//	// @property (readonly, nonatomic) UIView * statusBarView;
	//	[Export("statusBarView")]
	//	UIView StatusBarView { get; }

	//	// @property (readonly, nonatomic) CGRect statusBarViewAnimationFrame1;
	//	[Export("statusBarViewAnimationFrame1")]
	//	CGRect StatusBarViewAnimationFrame1 { get; }

	//	// @property (readonly, nonatomic) CGRect statusBarViewAnimationFrame2;
	//	[Export("statusBarViewAnimationFrame2")]
	//	CGRect StatusBarViewAnimationFrame2 { get; }

	//	// @property (nonatomic, strong) UIDynamicAnimator * animator;
	//	[Export("animator", ArgumentSemantic.Strong)]
	//	UIDynamicAnimator Animator { get; set; }

	//	// @property (readonly, nonatomic) CRToastType notificationType;
	//	[Export("notificationType")]
	//	CRToastType NotificationType { get; }

	//	// @property (assign, nonatomic) CGFloat preferredHeight;
	//	[Export("preferredHeight")]
	//	nfloat PreferredHeight { get; set; }

	//	// @property (assign, nonatomic) CGFloat preferredPadding;
	//	[Export("preferredPadding")]
	//	nfloat PreferredPadding { get; set; }

	//	// @property (readonly, nonatomic) CRToastPresentationType presentationType;
	//	[Export("presentationType")]
	//	CRToastPresentationType PresentationType { get; }

	//	// @property (readonly, nonatomic) BOOL displayUnderStatusBar;
	//	[Export("displayUnderStatusBar")]
	//	bool DisplayUnderStatusBar { get; }

	//	// @property (readonly, nonatomic) BOOL shouldKeepNavigationBarBorder;
	//	[Export("shouldKeepNavigationBarBorder")]
	//	bool ShouldKeepNavigationBarBorder { get; }

	//	// @property (readonly, nonatomic) CRToastAnimationType inAnimationType;
	//	[Export("inAnimationType")]
	//	CRToastAnimationType InAnimationType { get; }

	//	// @property (readonly, nonatomic) CRToastAnimationType outAnimationType;
	//	[Export("outAnimationType")]
	//	CRToastAnimationType OutAnimationType { get; }

	//	// @property (readonly, nonatomic) CRToastAnimationDirection inAnimationDirection;
	//	[Export("inAnimationDirection")]
	//	CRToastAnimationDirection InAnimationDirection { get; }

	//	// @property (readonly, nonatomic) CRToastAnimationDirection outAnimationDirection;
	//	[Export("outAnimationDirection")]
	//	CRToastAnimationDirection OutAnimationDirection { get; }

	//	// @property (readonly, nonatomic) NSTimeInterval animateInTimeInterval;
	//	[Export("animateInTimeInterval")]
	//	double AnimateInTimeInterval { get; }

	//	// @property (readonly, nonatomic) NSTimeInterval timeInterval;
	//	[Export("timeInterval")]
	//	double TimeInterval { get; }

	//	// @property (readonly, nonatomic) NSTimeInterval animateOutTimeInterval;
	//	[Export("animateOutTimeInterval")]
	//	double AnimateOutTimeInterval { get; }

	//	// @property (readonly, nonatomic) CGFloat animationSpringDamping;
	//	[Export("animationSpringDamping")]
	//	nfloat AnimationSpringDamping { get; }

	//	// @property (readonly, nonatomic) CGFloat animationSpringInitialVelocity;
	//	[Export("animationSpringInitialVelocity")]
	//	nfloat AnimationSpringInitialVelocity { get; }

	//	// @property (readonly, nonatomic) CGFloat animationGravityMagnitude;
	//	[Export("animationGravityMagnitude")]
	//	nfloat AnimationGravityMagnitude { get; }

	//	// @property (readonly, nonatomic) NSString * text;
	//	[Export("text")]
	//	string Text { get; }

	//	// @property (readonly, nonatomic) UIFont * font;
	//	[Export("font")]
	//	UIFont Font { get; }

	//	// @property (readonly, nonatomic) UIColor * textColor;
	//	[Export("textColor")]
	//	UIColor TextColor { get; }

	//	// @property (readonly, nonatomic) UITextAlignment textAlignment;
	//	[Export("textAlignment")]
	//	UITextAlignment TextAlignment { get; }

	//	// @property (readonly, nonatomic) UIColor * textShadowColor;
	//	[Export("textShadowColor")]
	//	UIColor TextShadowColor { get; }

	//	// @property (readonly, nonatomic) CGSize textShadowOffset;
	//	[Export("textShadowOffset")]
	//	CGSize TextShadowOffset { get; }

	//	// @property (readonly, nonatomic) NSInteger textMaxNumberOfLines;
	//	[Export("textMaxNumberOfLines")]
	//	nint TextMaxNumberOfLines { get; }

	//	// @property (readonly, nonatomic) NSString * subtitleText;
	//	[Export("subtitleText")]
	//	string SubtitleText { get; }

	//	// @property (readonly, nonatomic) UIFont * subtitleFont;
	//	[Export("subtitleFont")]
	//	UIFont SubtitleFont { get; }

	//	// @property (readonly, nonatomic) UIColor * subtitleTextColor;
	//	[Export("subtitleTextColor")]
	//	UIColor SubtitleTextColor { get; }

	//	// @property (readonly, nonatomic) UITextAlignment subtitleTextAlignment;
	//	[Export("subtitleTextAlignment")]
	//	UITextAlignment SubtitleTextAlignment { get; }

	//	// @property (readonly, nonatomic) UIColor * subtitleTextShadowColor;
	//	[Export("subtitleTextShadowColor")]
	//	UIColor SubtitleTextShadowColor { get; }

	//	// @property (readonly, nonatomic) CGSize subtitleTextShadowOffset;
	//	[Export("subtitleTextShadowOffset")]
	//	CGSize SubtitleTextShadowOffset { get; }

	//	// @property (readonly, nonatomic) NSInteger subtitleTextMaxNumberOfLines;
	//	[Export("subtitleTextMaxNumberOfLines")]
	//	nint SubtitleTextMaxNumberOfLines { get; }

	//	// @property (readonly, nonatomic) UIStatusBarStyle statusBarStyle;
	//	[Export("statusBarStyle")]
	//	UIStatusBarStyle StatusBarStyle { get; }

	//	// @property (readonly, nonatomic) UIColor * backgroundColor;
	//	[Export("backgroundColor")]
	//	UIColor BackgroundColor { get; }

	//	// @property (readonly, nonatomic) UIView * backgroundView;
	//	[Export("backgroundView")]
	//	UIView BackgroundView { get; }

	//	// @property (readonly, nonatomic) UIImage * image;
	//	[Export("image")]
	//	UIImage Image { get; }

	//	// @property (readonly, nonatomic) UIViewContentMode imageContentMode;
	//	[Export("imageContentMode")]
	//	UIViewContentMode ImageContentMode { get; }

	//	// @property (readonly, nonatomic) CRToastAccessoryViewAlignment imageAlignment;
	//	[Export("imageAlignment")]
	//	CRToastAccessoryViewAlignment ImageAlignment { get; }

	//	// @property (readonly, nonatomic) UIColor * imageTint;
	//	[Export("imageTint")]
	//	UIColor ImageTint { get; }

	//	// @property (readonly, nonatomic) UIActivityIndicatorViewStyle activityIndicatorViewStyle;
	//	[Export("activityIndicatorViewStyle")]
	//	UIActivityIndicatorViewStyle ActivityIndicatorViewStyle { get; }

	//	// @property (readonly, nonatomic) CRToastAccessoryViewAlignment activityViewAlignment;
	//	[Export("activityViewAlignment")]
	//	CRToastAccessoryViewAlignment ActivityViewAlignment { get; }

	//	// @property (readonly, nonatomic) BOOL showActivityIndicator;
	//	[Export("showActivityIndicator")]
	//	bool ShowActivityIndicator { get; }

	//	// @property (readonly, nonatomic) BOOL forceUserInteraction;
	//	[Export("forceUserInteraction")]
	//	bool ForceUserInteraction { get; }

	//	// @property (readonly, nonatomic) CGVector inGravityDirection;
	//	[Export("inGravityDirection")]
	//	CGVector InGravityDirection { get; }

	//	// @property (readonly, nonatomic) CGVector outGravityDirection;
	//	[Export("outGravityDirection")]
	//	CGVector OutGravityDirection { get; }

	//	// @property (readonly, nonatomic) CGPoint inCollisionPoint1;
	//	[Export("inCollisionPoint1")]
	//	CGPoint InCollisionPoint1 { get; }

	//	// @property (readonly, nonatomic) CGPoint inCollisionPoint2;
	//	[Export("inCollisionPoint2")]
	//	CGPoint InCollisionPoint2 { get; }

	//	// @property (readonly, nonatomic) CGPoint outCollisionPoint1;
	//	[Export("outCollisionPoint1")]
	//	CGPoint OutCollisionPoint1 { get; }

	//	// @property (readonly, nonatomic) CGPoint outCollisionPoint2;
	//	[Export("outCollisionPoint2")]
	//	CGPoint OutCollisionPoint2 { get; }

	//	// -(void)swipeGestureRecognizerSwiped:(CRToastSwipeGestureRecognizer *)swipeGestureRecognizer;
	//	[Export("swipeGestureRecognizerSwiped:")]
	//	void SwipeGestureRecognizerSwiped(CRToastSwipeGestureRecognizer swipeGestureRecognizer);

	//	// -(void)tapGestureRecognizerTapped:(CRToastTapGestureRecognizer *)tapGestureRecognizer;
	//	[Export("tapGestureRecognizerTapped:")]
	//	void TapGestureRecognizerTapped(CRToastTapGestureRecognizer tapGestureRecognizer);

	//	// -(void)initiateAnimator:(UIView *)view;
	//	[Export("initiateAnimator:")]
	//	void InitiateAnimator(UIView view);
	//}

	//// @interface CRToastView : UIView
	//[BaseType(typeof(UIView))]
	//interface CRToastView
	//{
	//	// @property (nonatomic, strong) CRToast * toast;
	//	[Export("toast", ArgumentSemantic.Strong)]
	//	CRToast Toast { get; set; }

	//	// @property (nonatomic, strong) UIView * backgroundView;
	//	[Export("backgroundView", ArgumentSemantic.Strong)]
	//	UIView BackgroundView { get; set; }

	//	// @property (nonatomic, strong) UIImageView * imageView;
	//	[Export("imageView", ArgumentSemantic.Strong)]
	//	UIImageView ImageView { get; set; }

	//	// @property (nonatomic, strong) UILabel * label;
	//	[Export("label", ArgumentSemantic.Strong)]
	//	UILabel Label { get; set; }

	//	// @property (nonatomic, strong) UILabel * subtitleLabel;
	//	[Export("subtitleLabel", ArgumentSemantic.Strong)]
	//	UILabel SubtitleLabel { get; set; }

	//	// @property (nonatomic, strong) UIActivityIndicatorView * activityIndicator;
	//	[Export("activityIndicator", ArgumentSemantic.Strong)]
	//	UIActivityIndicatorView ActivityIndicator { get; set; }
	//}

	//// @interface CRToastViewController : UIViewController
	//[BaseType(typeof(UIViewController))]
	//interface CRToastViewController
	//{
	//	// @property (assign, nonatomic) BOOL autorotate;
	//	[Export("autorotate")]
	//	bool Autorotate { get; set; }

	//	// @property (nonatomic, weak) CRToast * notification;
	//	[Export("notification", ArgumentSemantic.Weak)]
	//	CRToast Notification { get; set; }

	//	// @property (nonatomic, weak) UIView * toastView;
	//	[Export("toastView", ArgumentSemantic.Weak)]
	//	UIView ToastView { get; set; }

	//	// @property (assign, nonatomic) UIStatusBarStyle statusBarStyle;
	//	[Export("statusBarStyle", ArgumentSemantic.Assign)]
	//	UIStatusBarStyle StatusBarStyle { get; set; }
	//}

	// @interface CRToastWindow : UIWindow
	[BaseType(typeof(UIWindow))]
	interface CRToastWindow
	{
	}

}
