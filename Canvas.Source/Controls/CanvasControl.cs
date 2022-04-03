using Canvas.Source.ModelSpace;
using System;
using System.Collections.Generic;

namespace Canvas.Source.ControlSpace
{
  public interface ICanvasControl : IDisposable
  {
    /// <summary>
    /// Name
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Width
    /// </summary>
    double IndexSize { get; set; }

    /// <summary>
    /// Height
    /// </summary>
    double ValueSize { get; set; }

    /// <summary>
    /// Create circle
    /// </summary>
    /// <param name="point"></param>
    void CreateCircle(IPointModel point, IShapeModel shape);

    /// <summary>
    /// Create box
    /// </summary>
    /// <param name="points"></param>
    /// <param name="shape"></param>
    void CreateBox(IList<IPointModel> points, IShapeModel shape);

    /// <summary>
    /// Create line
    /// </summary>
    /// <param name="points"></param>
    /// <param name="shape"></param>
    void CreateLine(IList<IPointModel> points, IShapeModel shape);

    /// <summary>
    /// Create shape
    /// </summary>
    /// <param name="points"></param>
    /// <param name="shape"></param>
    void CreateShape(IList<IPointModel> points, IShapeModel shape);

    /// <summary>
    /// Create label
    /// </summary>
    /// <param name="point"></param>
    /// <param name="shape"></param>
    /// <param name="content"></param>
    void CreateLabel(IPointModel point, IShapeModel shape, string content);

    /// <summary>
    /// Measure content
    /// </summary>
    /// <param name="content"></param>
    /// <param name="size"></param>
    IPointModel GetContentMeasure(string content, double size);

    /// <summary>
    /// Clear canvas
    /// </summary>
    void Clear();
  }

  public abstract class CanvasControl : ICanvasControl
  {
    /// <summary>
    /// Name
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// Width
    /// </summary>
    public virtual double IndexSize { get; set; }

    /// <summary>
    /// Height
    /// </summary>
    public virtual double ValueSize { get; set; }

    /// <summary>
    /// Create circle
    /// </summary>
    /// <param name="point"></param>
    public virtual void CreateCircle(IPointModel point, IShapeModel shape)
    {
    }

    /// <summary>
    /// Create box
    /// </summary>
    /// <param name="points"></param>
    /// <param name="shape"></param>
    public virtual void CreateBox(IList<IPointModel> points, IShapeModel shape)
    {
    }

    /// <summary>
    /// Create line
    /// </summary>
    /// <param name="points"></param>
    /// <param name="shape"></param>
    public virtual void CreateLine(IList<IPointModel> points, IShapeModel shape)
    { 
    }

    /// <summary>
    /// Create shape
    /// </summary>
    /// <param name="points"></param>
    /// <param name="shape"></param>
    public virtual void CreateShape(IList<IPointModel> points, IShapeModel shape)
    {
    }

    /// <summary>
    /// Create label
    /// </summary>
    /// <param name="point"></param>
    /// <param name="shape"></param>
    /// <param name="content"></param>
    public virtual void CreateLabel(IPointModel point, IShapeModel shape, string content)
    {
    }

    /// <summary>
    /// Measure content
    /// </summary>
    /// <param name="content"></param>
    /// <param name="size"></param>
    public virtual IPointModel GetContentMeasure(string content, double size) => null;

    /// <summary>
    /// Clear canvas
    /// </summary>
    public virtual void Clear()
    {
    }

    /// <summary>
    /// Dispose
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public virtual void Dispose()
    {
    }
  }
}
