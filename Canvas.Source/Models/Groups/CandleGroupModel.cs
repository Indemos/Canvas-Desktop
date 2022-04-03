using Canvas.Source.ModelSpace;
using System;
using System.Collections.Generic;

namespace Canvas.Source.ModelSpace
{
  public class CandleGroupModel : GroupModel, IGroupModel
  {
    /// <summary>
    /// Get Min and Max for the current point
    /// </summary>
    /// <param name="position"></param>
    /// <param name="name"></param>
    /// <param name="items"></param>
    /// <returns></returns>
    public override double[] CreateDomain(int position, string name, IList<IGroupModel> items)
    {
      var currentModel = Composer.GetGroup(position, name, items);

      if (currentModel is null)
      {
        return null;
      }

      return new double[]
      {
        currentModel.Low ?? currentModel.Point,
        currentModel.High ?? currentModel.Point
      };
    }

    /// <summary>
    /// Render the shape
    /// </summary>
    /// <param name="position"></param>
    /// <param name="name"></param>
    /// <param name="items"></param>
    /// <returns></returns>
    public override void CreateShape(int position, string name, IList<IGroupModel> items)
    {
      var currentModel = Composer.GetGroup(position, name, items);

      if (currentModel is null)
      {
        return;
      }

      var L = currentModel.Low ?? currentModel.Point;
      var H = currentModel.High ?? currentModel.Point;
      var O = currentModel.Open ?? currentModel.Point;
      var C = currentModel.Close ?? currentModel.Point;
      var size = 1.0 / 4.0;
      var upSide = Math.Max(O, C);
      var downSide = Math.Min(O, C);

      var points = new IPointModel[]
      {
        Composer.GetPixels(Panel, position - size, upSide),
        Composer.GetPixels(Panel, position + size, upSide),
        Composer.GetPixels(Panel, position + size, downSide),
        Composer.GetPixels(Panel, position - size, downSide),
        Composer.GetPixels(Panel, position - size, upSide)
      };

      var linePoints = new IPointModel[]
      {
        Composer.GetPixels(Panel, position, L),
        Composer.GetPixels(Panel, position, H),
      };

      Color = currentModel.Color ?? Color;

      Panel.CreateShape(points, this);
      Panel.CreateLine(linePoints, this);
    }
  }
}
