using System;
using Android.Widget;
using Android.Graphics;
using Android.App;
using Android.Content;

namespace SafeTraveling
{
	public static class SetTypeface
	{
		public static class Italic
		{		
			public static void SetTypeFace (Context context,TextView obj)
			{
				Typeface tf = Typeface.CreateFromAsset(context.Assets, "Font/NunitoLight-K7dKW.ttf");
				obj.SetTypeface (tf,TypefaceStyle.Italic);
			}

			public static void SetTypeFace (Context context,Button obj)
			{
				Typeface tf = Typeface.CreateFromAsset(context.Assets, "Font/NunitoLight-K7dKW.ttf");
				obj.SetTypeface (tf,TypefaceStyle.Italic);
			}

			public static void SetTypeFace (Context context,CheckBox obj)
			{
				Typeface tf = Typeface.CreateFromAsset(context.Assets, "Font/NunitoLight-K7dKW.ttf");
				obj.SetTypeface (tf,TypefaceStyle.Italic);
			}

		}

		public static class Normal
		{
			public static void SetTypeFace (Context context,TextView obj)
			{
				Typeface tf = Typeface.CreateFromAsset(context.Assets, "Font/NunitoLight-K7dKW.ttf");
				obj.SetTypeface (tf,TypefaceStyle.Normal);
			}

			public static void SetTypeFace (Context context,Button obj)
			{
				Typeface tf = Typeface.CreateFromAsset(context.Assets, "Font/NunitoLight-K7dKW.ttf");
				obj.SetTypeface (tf,TypefaceStyle.Normal);
			}

			public static void SetTypeFace (Context context,CheckBox obj)
			{
				Typeface tf = Typeface.CreateFromAsset(context.Assets, "Font/NunitoLight-K7dKW.ttf");
				obj.SetTypeface (tf,TypefaceStyle.Normal);
			}
		}

		public static class Bold
		{
			public static void SetTypeFace (Context context,TextView obj)
			{
				Typeface tf = Typeface.CreateFromAsset(context.Assets, "Font/NunitoBold-1GD50.ttf");
				obj.SetTypeface (tf,TypefaceStyle.Bold);
			}

			public static void SetTypeFace (Context context,Button obj)
			{
				Typeface tf = Typeface.CreateFromAsset(context.Assets, "Font/NunitoLight-K7dKW.ttf");
				obj.SetTypeface (tf,TypefaceStyle.Bold);
			}

			public static void SetTypeFace (Context context,CheckBox obj)
			{
				Typeface tf = Typeface.CreateFromAsset(context.Assets, "Font/NunitoLight-K7dKW.ttf");
				obj.SetTypeface (tf,TypefaceStyle.Bold);
			}
		}
	}
}

