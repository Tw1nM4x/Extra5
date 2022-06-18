using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using UISampleApp.Controls;
using UISampleApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Resource;
using AndroidX.Core.Content;
using Android.Text;
using Android.Text.Style;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(EditorWithSmiles), typeof(ImageEditorRenderer))]
namespace UISampleApp.Droid.Renderers
{
    public class ImageEditorRenderer : EditorRenderer
    {
        EditorWithSmiles element;
        string[] Smiles = new string[] { ":)", ":(", ":|" };
        string[] ImageSmiles = new string[] { "smile", "sad", "pokerface" };
        public ImageEditorRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == EditorWithSmiles.TextProperty.PropertyName)
            {
                AddImages();
            }
        }

        public void AddImages()
        {
            element = (EditorWithSmiles)this.Element;

            var editText = this.Control;

            SpannableStringBuilder ssb = (SpannableStringBuilder)editText.TextFormatted;

            for(int i = element.Text.Length - 1; i > 0; i--)
            {
                for(int j = 0; j < Smiles.Length; j++)
                {
                    if (element.Text[i] == Smiles[j][Smiles[j].Length - 1] && element.Text[i - 1] == Smiles[j][Smiles[j].Length - 2])
                        ssb.SetSpan(new ImageSpan(this.Context, GetBitmap(ImageSmiles[j])), i - 1, i + 1, SpanTypes.ExclusiveExclusive);
                }
            }
            editText.TextFormatted = ssb;
            editText.SetSelection(editText.Length());
        }

        private Bitmap GetBitmap(string imageEntryImage)
        {
            int resID = Resources.GetIdentifier(imageEntryImage, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth * 2, element.ImageHeight * 2, true)).Bitmap;
        }

    }
}