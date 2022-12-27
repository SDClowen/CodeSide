﻿using System.Drawing;
using System.Drawing.Drawing2D;

public static class DrawingExtensions
{
    public static bool InRegion(this Point point, Region region)
    {
        return region.IsVisible(point);
    }

    public static bool InRegion(this Point point, Point[] points)
    {
        using (var path = points.Path())
        {
            using (var region = path.Region())
            {
                return region.IsVisible(point);
            }
        }
    }

    public static bool InRegion(this PointF point, PointF[] points)
    {
        using (var path = points.Path())
        {
            using (var region = path.Region())
            {
                return region.IsVisible(point);
            }
        }
    }

    public static GraphicsPath Path(this Point[] points)
    {
        var path = new GraphicsPath();
        path.Reset();
        path.AddPolygon(points);
        return path;
    }

    public static GraphicsPath Path(this PointF[] points)
    {
        GraphicsPath path = new GraphicsPath();
        path.Reset();
        path.AddPolygon(points);
        return path;
    }

    public static Region Region(this GraphicsPath path)
    {
        Region region = new Region();
        region.MakeEmpty();
        region.Union(path);
        return region;
    }

    public static GraphicsPath GraphicsPath(this RectangleF rect)
    {
        var points = new PointF[] {
                new PointF(rect.Left, rect.Top),
                new PointF(rect.Right, rect.Top),
                new PointF(rect.Right, rect.Bottom),
                new PointF(rect.Left, rect.Bottom),

                new PointF(rect.Left, rect.Top) };
        return points.Path();
    }

    public static GraphicsPath CreateFanPath(this Graphics g, Point center, float d1, float d2, float startAngle, float sweepAngle)
    {
        return center.CreateFanPath(d1, d2, startAngle, sweepAngle);
    }

    public static GraphicsPath CreateFanPath(this Graphics g, PointF center, float d1, float d2, float startAngle, float sweepAngle)
    {
        return center.CreateFanPath(d1, d2, startAngle, sweepAngle);
    }

    public static GraphicsPath CreateFanPath(this Point center, float d1, float d2, float startAngle, float sweepAngle)
    {
        return new PointF(center.X, center.Y).CreateFanPath(d1, d2, startAngle, sweepAngle);
    }

    public static GraphicsPath CreateFanPath(this PointF center, float d1, float d2, float startAngle, float sweepAngle)
    {
        GraphicsPath path = new GraphicsPath();
        path.AddArc(center.X - d1, center.Y - d1, d1 * 2, d1 * 2, startAngle, sweepAngle);
        path.AddArc(center.X - d2, center.Y - d2, d2 * 2, d2 * 2, startAngle + sweepAngle, -sweepAngle);
        path.AddArc(center.X - d1, center.Y - d1, d1 * 2, d1 * 2, startAngle, 0.1f);
        return path;
    }

    public static void SetHighQuality(this Graphics g)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.CompositingQuality = CompositingQuality.HighQuality;
    }

    public static void SetDefaultQuality(this Graphics g)
    {
        g.SmoothingMode = SmoothingMode.Default;
        g.InterpolationMode = InterpolationMode.Default;
        g.CompositingQuality = CompositingQuality.Default;
    }

    public static void FillRectangle(this Graphics gfx, Color color, Rectangle rect)
    {
        var brush = color.Brush();
        gfx.FillRectangle(brush, rect);
    }

    public static void FillRectangle(this Graphics gfx, Color color, int x, int y, int width, int height)
    {
        var brush = color.Brush();
        gfx.FillRectangle(brush, new Rectangle(x, y, width, height));
    }

    public static void DrawRectangle(this Graphics gfx, Color color, Rectangle rect)
    {
        var pen = color.Pen();
        gfx.DrawRectangle(pen, rect);
    }

    public static void DrawRectangle(this Graphics gfx, Color color, int x, int y, int width, int height)
    {
        var pen = color.Pen();
        gfx.DrawRectangle(pen, new Rectangle(x, y, width, height));
    }

    public static void DrawLine(this Graphics gfx, Color color, int x1, int y1, int x2, int y2)
    {
        var pen = color.Pen();
        gfx.DrawLine(pen, x1, y1, x2, y2);
    }

    public static void DrawLine(this Graphics gfx, Color color, Point p1, Point p2)
    {
        var pen = color.Pen();
        gfx.DrawLine(pen, p1, p2);
    }

    internal static GraphicsPath CreateRoundPath(float v1, float v2, float v3, float v4, int v5)
    {
        return new RectangleF(v1, v2, v3, v4).Radius(v5);
    }

    internal static void DrawShadow(this Graphics graphics, Rectangle rect, float size, int radius, Color color = default)
        => DrawShadow(graphics, rect.ToRectangleF(), size, radius, color);

    internal static void DrawShadow(this Graphics graphics, RectangleF rect, float size, int radius, Color color = default)
    {
        if (size <= 0)
            return;

        if (color == default)
            color = Color.Red;

        for (float i = 0; i < size; i++)
        {
            var v = i * (size / 2);
            using (var pen = new Pen(color.Alpha(color.A / ((int)i + 1)), 1))
            {
                var rectF = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
                rectF.Inflate(v / size, v / size);
                using (var rectPath = rectF.Radius(radius))
                    graphics.DrawPath(pen, rectPath);
            }
        }
    }
}