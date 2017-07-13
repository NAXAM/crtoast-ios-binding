using System;

using UIKit;
using Foundation;
using CRToast;

namespace CRToastQS
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        UITextAlignment _TextAlignment;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            AutomaticallyAdjustsScrollViewInsets = false;
            EdgesForExtendedLayout = UIRectEdge.All;

            UIKeyboard.Notifications.ObserveWillShow(KeyboardWillShow);
            UIKeyboard.Notifications.ObserveWillHide(KeyboardWillHide);
            UIDevice.Notifications.ObserveOrientationDidChange(OrientationDidChange);

            Title = "CRToast";
            UpdateDurationLabel();
            var font = UIFont.BoldSystemFontOfSize(10);

            SegFromDirection.SetTitleTextAttributes(new UITextAttributes()
            {
                Font = font
            }, UIControlState.Normal);
            SegToDirection.SetTitleTextAttributes(new UITextAttributes()
            {
                Font = font
            }, UIControlState.Normal);
            InAnimationTypeSegmentedControl.SetTitleTextAttributes(new UITextAttributes()
            {
                Font = font
            }, UIControlState.Normal);
            OutAnimationTypeSegmentedControl.SetTitleTextAttributes(new UITextAttributes()
            {
                Font = font
            }, UIControlState.Normal);


            TxtSubtitleMessage.ShouldReturn = TextFieldShouldReturn;
            TxtSubtitleMessage.ShouldReturn = TextFieldShouldReturn;


            var tapGestureRecognizer = new UITapGestureRecognizer(ScrollViewTapped);
            ScrollView.AddGestureRecognizer(tapGestureRecognizer);

            AddHandlers();
            UpdateImageTintSwitch();

        }


        void AddHandlers() {
            NavigationBarSwitch.AddTarget( (sender, e) => {
                NavigationBarChanged(sender as UISwitch);   
            }, UIControlEvent.ValueChanged);

            StatusBarSwitch.AddTarget( (sender, e) => {
                StatusBarChanged(sender as UISwitch);
            }, UIControlEvent.ValueChanged);

            ImageTintSlider.AddTarget( (sender, e) => {
                SliderImageTintChanged(sender as UISlider);
            }, UIControlEvent.ValueChanged);

            SliderDuration.AddTarget( (sender, e) => {
                SliderDurationChanged(sender as UISlider);
            }, UIControlEvent.ValueChanged);

            BtnShow.Clicked += BtnShowNotificationPressed;
            BtnPrint.Clicked += BtnPrintNotificationPress;
            BtnDismiss.Clicked += BtnDismissNotificationPressed;

		}

	public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


		private void OrientationDidChange(object sender, NSNotificationEventArgs e)
		{
            LayoutSubviews();
		}

        public override bool PrefersStatusBarHidden()
        {
            return StatusBarSwitch == null ? false : !StatusBarSwitch.On;
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            LayoutSubviews();
        }

        void LayoutSubviews() {
            ScrollView.ContentInset = new UIEdgeInsets(TopLayoutGuide.Length, 0, BottomLayoutGuide.Length, 0);
			
        }

		private void KeyboardWillHide(object sender, UIKeyboardEventArgs e)
		{
            ScrollView.ContentInset = new UIEdgeInsets(TopLayoutGuide.Length, 0, BottomLayoutGuide.Length, 0);
            ScrollView.ScrollIndicatorInsets = ScrollView.ContentInset;
		}


		private void KeyboardWillShow(object sender, UIKeyboardEventArgs e)
		{
            ScrollView.ContentInset = new UIEdgeInsets(TopLayoutGuide.Length,
                                                       0,
                                                       e.FrameEnd.Height,
                                                       0);
            ScrollView.ScrollIndicatorInsets = ScrollView.ContentInset;
  		}

		private void UpdateImageTintSwitch()
		{
            ImageTintEnabledSwitch.OnTintColor = UIColor.FromHSB(ImageTintSlider.Value, 1.0f, 1.0f);
		}

		private void ScrollViewTapped()
		{
            TxtNotificationMessage.ResignFirstResponder();
		}

		private void UpdateDurationLabel()
		{
            LblDuration.Text = string.Format("{0:F1}", SliderDuration.Value);
		}

        void NavigationBarChanged(UISwitch sender)
        {
            NavigationController.SetNavigationBarHidden(!sender.On, true);
        }

        void StatusBarChanged(UISwitch sender)
        {
            SetNeedsStatusBarAppearanceUpdate();
        }

        void SliderImageTintChanged(UISlider sender)
        {
            UpdateImageTintSwitch();
        }

        void SliderPaddingChanged(UISlider sender)
        {
            UpdatePaddingLabel();
        }

        void UpdatePaddingLabel()
		{
            LblPadding.Text = string.Format("{0:D}", (int) Math.Round(SliderPadding.Value));
        }

        void SliderDurationChanged(UISlider sender)
        {
            UpdateDurationLabel();
        }

        void BtnShowNotificationPressed(object sender, EventArgs args)
        {
            CRToastManager.ShowNotificationWithOptions(
                Options(),
                () =>
                {
                System.Diagnostics.Debug.WriteLine("Appeared");
            }, () => {
                System.Diagnostics.Debug.WriteLine("Completed");   
            }
            );
        }

        NSDictionary Options() {
            var keys = new NSString[] {
                Constants.kCRToastNotificationTypeKey,
                Constants.kCRToastNotificationPresentationTypeKey,
                Constants.kCRToastUnderStatusBarKey,
                Constants.kCRToastTextKey,
                Constants.kCRToastTextAlignmentKey,
                Constants.kCRToastTimeIntervalKey,
                Constants.kCRToastAnimationInTypeKey,
                Constants.kCRToastAnimationOutTypeKey,
                Constants.kCRToastAnimationInDirectionKey,
                Constants.kCRToastAnimationOutDirectionKey,
                Constants.kCRToastNotificationPreferredPaddingKey
            };

            var objects = new NSObject[] {
                NSNumber.FromInt64((long) (coverNavBarSwitch.On ? CRToastType.NavigationBar : CRToastType.StatusBar)),
                NSNumber.FromInt64((long) (SlideOverSwitch.On ? CRToastPresentationType.Cover : CRToastPresentationType.Push)),
                NSNumber.FromBoolean(SlideUnderSwitch.On),
                (NSString) TxtNotificationMessage.Text,
                NSNumber.FromInt64((long)_TextAlignment),
                NSNumber.FromDouble(SliderDuration.Value),
                NSNumber.FromInt64(InAnimationTypeSegmentedControl.SelectedSegment),
                NSNumber.FromInt64(OutAnimationTypeSegmentedControl.SelectedSegment),
                NSNumber.FromInt64(SegFromDirection.SelectedSegment),
                NSNumber.FromInt64(SegToDirection.SelectedSegment),
                NSNumber.FromDouble(SliderPadding.Value)
            };

            var options = NSMutableDictionary.FromObjectsAndKeys(objects, keys);

            if (ShowImageSwitch.On) {
                options.Add(Constants.kCRToastImageKey, UIImage.FromFile("alert_icon.png"));
                options.Add(Constants.kCRToastImageAlignmentKey, NSNumber.FromInt64(ImageAlignmentSegmentedControl.SelectedSegment)) ;
            }

            if (ImageTintEnabledSwitch.On) {
                options.Add(Constants.kCRToastImageTintKey, UIColor.FromHSB(ImageTintSlider.Value, 1.0f, 1.0f));
            }

            if (ShowActivityIndicatorSwitch.On) {
                options.Add(Constants.kCRToastShowActivityIndicatorKey, NSNumber.FromBoolean(true));
                options.Add(Constants.kCRToastActivityIndicatorAlignmentKey, NSNumber.FromInt64(ActivityIndicatorAlignmentSegementControl.SelectedSegment));
            }

            if (ForceUserInteractionSwitch.On) {
                options.Add(Constants.kCRToastForceUserInteractionKey, NSNumber.FromBoolean(true));
            }

            if (!string.IsNullOrEmpty(TxtNotificationMessage.Text)) {
                options.Add(Constants.kCRToastIdentifierKey, (NSString) TxtNotificationMessage.Text);
            }

            if (!string.IsNullOrEmpty(TxtSubtitleMessage.Text) ) {
                options.Add(Constants.kCRToastSubtitleTextKey, (NSString) TxtSubtitleMessage.Text);
                options.Add(Constants.kCRToastSubtitleTextAlignmentKey, NSNumber.FromInt64(SegSubtitleAlignment.SelectedSegment));
            }

            if (DismissibleWithTapSwitch.On) {
                options.Add(Constants.kCRToastInteractionRespondersKey, 
                            CRToastInteractionResponder.InteractionResponderWithInteractionType(CRToastInteractionType.Tap,
                                                                                                true,
                                                                                                (interactionType) => {
                    System.Diagnostics.Debug.WriteLine($"Dismissed with {interactionType} interaction");   
                })
                           );
            }

            return NSDictionary.FromDictionary(options);
        }

		private void BtnDismissNotificationPressed(object sender, EventArgs e)
		{
			CRToastManager.DismissNotification(true);
		}

		private void BtnPrintNotificationPress(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(CRToastManager.NotificationIdentifiersInQueue);
		}


        private bool TextFieldShouldReturn(UITextField textField)
        {
            textField.ResignFirstResponder();
            return true;
        }
    }
}
