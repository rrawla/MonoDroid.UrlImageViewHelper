using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace UrlImageViewHelper
{
    public class RoundedImage : BitmapDrawable
    {
        Bitmap mBitmap;
        Paint mPaint;
        RectF mRectF;
        int mBitmapWidth;
        int mBitmapHeight;

        public RoundedImage(Bitmap bitmap)
        {
            mBitmap = bitmap;
            mRectF = new RectF();
            mPaint = new Paint();
            mPaint.AntiAlias = true;
            mPaint.Dither = true;
            BitmapShader shader = new BitmapShader(bitmap, Shader.TileMode.Clamp, Shader.TileMode.Clamp);
            mPaint.SetShader(shader);

            // NOTE: we assume bitmap is properly scaled to current density
            mBitmapWidth = mBitmap.Width;
            mBitmapHeight = mBitmap.Height;
        }

        public override void Draw(Android.Graphics.Canvas canvas)
        {
            canvas.DrawOval(mRectF, mPaint);
        }

        protected override void OnBoundsChange(Rect bounds)
        {
            base.OnBoundsChange(bounds);
            mRectF.Set(bounds);
        }

        public override void SetAlpha(int alpha)
        {
            if (mPaint.Alpha != alpha)
            {
                mPaint.Alpha = alpha;
                InvalidateSelf();
            }
        }

        public override void SetColorFilter(ColorFilter cf)
        {
            mPaint.SetColorFilter(cf);
        }

        public override int Opacity
        {
            get
            {
                return (int)Format.Translucent;
            }
        }

        public override int IntrinsicWidth
        {
            get
            {
                return mBitmapWidth;
            }
        }

        public override int IntrinsicHeight
        {
            get
            {
                return mBitmapHeight;
            }
        }

        public void SetAntiAlias(bool aa)
        {
            mPaint.AntiAlias = aa;
            InvalidateSelf();
        }

        public override void SetFilterBitmap(bool filter)
        {
            mPaint.FilterBitmap = filter;
            InvalidateSelf();
        }

        public override void SetDither(bool dither)
        {
            mPaint.Dither = dither;
            InvalidateSelf();
        }

        public Bitmap Bitmap
        {
            get{ return mBitmap; }

        }
    }
}

