using System;

using UIKit;

namespace Xamarin.iOS.ScrollViewAutoLayout
{
    public partial class ViewController : UIViewController
    {
        //ui
        UIScrollView _scrollView;
        UIView _contentView;//required for scroll view to work

        UILabel _label;
        UILabel _label1;
        UILabel _label2;

        public ViewController() : base()
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            //ui
            View.BackgroundColor = UIColor.White;

            InitializeSubviews();
            SetupConstraints();
        }

        void InitializeSubviews()
        {
            
            _scrollView = new UIScrollView();
            _scrollView.TranslatesAutoresizingMaskIntoConstraints = false;
            _scrollView.BackgroundColor = UIColor.Green;

            _contentView = new UIView();
            _contentView.TranslatesAutoresizingMaskIntoConstraints = false;
            _contentView.BackgroundColor = UIColor.Red;

            _label = new UILabel();
            _label.TranslatesAutoresizingMaskIntoConstraints = false;
            _label.Text = "Text";
            _label.BackgroundColor = UIColor.Blue;

            _label1 = new UILabel();
            _label1.TranslatesAutoresizingMaskIntoConstraints = false;
            _label1.Text = "Text1";
            _label1.TextColor = UIColor.White;
            _label1.BackgroundColor = UIColor.Black;

            _label2 = new UILabel();
            _label2.TranslatesAutoresizingMaskIntoConstraints = false;
            _label2.Text = "Text2";
            _label2.BackgroundColor = UIColor.Yellow;

            _contentView.AddSubviews(new UIView[] { _label, _label1, _label2 });
            _scrollView.AddSubview(_contentView);
            View.AddSubview(_scrollView);
        }

        void SetupConstraints()
        {
            //UIScrollView can be any size 
            _scrollView.TopAnchor.ConstraintEqualTo(View.TopAnchor, 50).Active = true;
            _scrollView.LeftAnchor.ConstraintEqualTo(View.LeftAnchor, 10).Active = true;
            _scrollView.RightAnchor.ConstraintEqualTo(View.RightAnchor, -10).Active = true;
            _scrollView.BottomAnchor.ConstraintEqualTo(View.BottomAnchor, -50).Active = true;

            //Inner UIView has to be attached to all UIScrollView constraints
            _contentView.TopAnchor.ConstraintEqualTo(_contentView.Superview.TopAnchor).Active = true;
            _contentView.RightAnchor.ConstraintEqualTo(_contentView.Superview.RightAnchor).Active = true;
            _contentView.LeftAnchor.ConstraintEqualTo(_contentView.Superview.LeftAnchor).Active = true;
            _contentView.BottomAnchor.ConstraintEqualTo(_contentView.Superview.BottomAnchor).Active = true;
            _contentView.WidthAnchor.ConstraintEqualTo(_contentView.Superview.WidthAnchor).Active = true;

            _label.TopAnchor.ConstraintEqualTo(_label.Superview.TopAnchor, 100).Active = true;
            _label.LeftAnchor.ConstraintEqualTo(_label.Superview.LeftAnchor, 4).Active = true;
            _label.RightAnchor.ConstraintEqualTo(_label.Superview.RightAnchor, -4).Active = true;
            _label.HeightAnchor.ConstraintEqualTo(400).Active = true;

            _label1.TopAnchor.ConstraintEqualTo(_label.BottomAnchor, 100).Active = true;
            _label1.LeftAnchor.ConstraintEqualTo(_label1.Superview.LeftAnchor, 4).Active = true;
            _label1.RightAnchor.ConstraintEqualTo(_label1.Superview.RightAnchor, -4).Active = true;
            _label1.HeightAnchor.ConstraintEqualTo(400).Active = true;

            _label2.TopAnchor.ConstraintEqualTo(_label1.BottomAnchor, 100).Active = true;
            _label2.LeftAnchor.ConstraintEqualTo(_label2.Superview.LeftAnchor, 4).Active = true;
            _label2.RightAnchor.ConstraintEqualTo(_label2.Superview.RightAnchor, -4).Active = true;
            _label2.HeightAnchor.ConstraintEqualTo(400).Active = true;

            /* THIS IS WHAT MAKES IT WORK. THE MOST BOTTOM SUBVIEW NEEDS TO HAVE BTTOMANCHOR 
               ATTACHED TO CONTENT VIEW */
            _label2.BottomAnchor.ConstraintEqualTo(_label2.Superview.BottomAnchor, -20).Active = true;
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
