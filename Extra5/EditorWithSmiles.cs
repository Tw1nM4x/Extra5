using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UISampleApp.Controls
{
	public class EditorWithSmiles : Editor
	{
		public EditorWithSmiles()
		{
			this.HeightRequest = 50;
		}

		public static readonly BindableProperty ImageHeightProperty =
			BindableProperty.Create(nameof(ImageHeight), typeof(int), typeof(EditorWithSmiles), 40);

		public static readonly BindableProperty ImageWidthProperty =
			BindableProperty.Create(nameof(ImageWidth), typeof(int), typeof(EditorWithSmiles), 40);

		public int ImageWidth
		{
			get { return (int)GetValue(ImageWidthProperty); }
			set { SetValue(ImageWidthProperty, value); }
		}

		public int ImageHeight
		{
			get { return (int)GetValue(ImageHeightProperty); }
			set { SetValue(ImageHeightProperty, value); }
		}
	}
}